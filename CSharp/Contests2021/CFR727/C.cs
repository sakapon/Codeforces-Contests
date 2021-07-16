using System;
using System.Linq;

class C
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static (long, long, long) Read3L() { var a = ReadL(); return (a[0], a[1], a[2]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var (n, k, x) = Read3L();
		var a = ReadL();

		Array.Sort(a);

		var d = Enumerable.Range(0, (int)n - 1).Select(i => Math.Max(0, (a[i + 1] - a[i] - 1) / x)).ToArray();
		Array.Sort(d);

		var t = 0L;
		var r = d.TakeWhile(v => (t += v) <= k).Count();
		return n - r;
	}
}
