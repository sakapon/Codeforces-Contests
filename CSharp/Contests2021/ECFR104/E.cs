using System;
using System.Collections.Generic;
using System.Linq;

class E
{
	const int max = 1 << 29;
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = Read();
		var a = Array.ConvertAll(new bool[4], _ => Read());
		var b = Array.ConvertAll(new bool[3], _ =>
		{
			var m = int.Parse(Console.ReadLine());
			return Array.ConvertAll(new bool[m], _ => Read2()).ToHashSet();
		});

		var r = a[0];
		for (int i = 0; i < 3; i++)
		{
			r = MinSum(r, a[i + 1], b[i]);
			if (r.Min() == max) return -1;
		}
		return r.Min();
	}

	// for each i in [0, a2.Length), min(a1 + a2)
	static int[] MinSum(int[] a1, int[] a2, HashSet<(int, int)> b)
	{
		var o1 = a1.Select((v, i) => (v, i)).OrderBy(t => t.v).ToArray();
		return a2.Select((v2, i2) =>
		{
			var (v1, _) = o1.FirstOrDefault(t => !b.Contains((t.i + 1, i2 + 1)));
			return v1 == 0 ? max : v1 + v2;
		}).ToArray();
	}
}
