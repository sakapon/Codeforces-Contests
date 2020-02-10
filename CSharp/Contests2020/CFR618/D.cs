using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var ps = new int[n].Select(_ => Read()).Select(v => new V(v[0], v[1])).ToArray();

		var l = new List<string>();
		for (int i = 0; i < n; i++)
		{
			l.Add((ps[(i + 1) % n] - ps[i]).ToString());
			l.Add((ps[(i - 1 + n) % n] - ps[i]).ToString());
		}
		Console.WriteLine(l.Distinct().Count() == n ? "YES" : "NO");
	}
}

struct V
{
	public int X, Y;
	public V(int x, int y) { X = x; Y = y; }

	public static V operator +(V v1, V v2) => new V(v1.X + v2.X, v1.Y + v2.Y);
	public static V operator -(V v1, V v2) => new V(v1.X - v2.X, v1.Y - v2.Y);

	public override string ToString() => $"{X} {Y}";
}
