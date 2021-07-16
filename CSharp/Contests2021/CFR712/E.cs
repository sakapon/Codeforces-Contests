using System;
using System.Linq;

class E
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static (long a, long c) Read2L() { var a = ReadL(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var ps = Array.ConvertAll(new bool[n], _ => Read2L());

		var r = ps.Sum(t => t.c);
		ps = ps.OrderBy(t => t.a).ToArray();
		var max = ps[0].a;

		foreach (var (a, c) in ps)
		{
			if (a > max) r += a - max;
			max = Math.Max(max, a + c);
		}
		return r;
	}
}
