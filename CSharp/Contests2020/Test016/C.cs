using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var s = Console.ReadLine();
		var d = new Dictionary<char, V> { { 'S', new V(0, -1) }, { 'N', new V(0, 1) }, { 'W', new V(-1, 0) }, { 'E', new V(1, 0) } };

		var l = new List<long>();
		var v = new V();
		foreach (var c in s)
		{
			v += d[c];
			l.Add(v.X * (1 << 20) + v.Y);
			v += d[c];
		}
		return l.GroupBy(x => x).Sum(g => g.Count() + 4);
	}
}

struct V
{
	public long X, Y;
	public V(long x, long y) { X = x; Y = y; }

	public static V operator +(V v1, V v2) => new V(v1.X + v2.X, v1.Y + v2.Y);
}
