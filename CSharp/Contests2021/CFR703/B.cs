using System;
using System.Linq;

class B
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static (long x, long y) Read2L() { var a = ReadL(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var ps = Array.ConvertAll(new bool[n], _ => Read2L());

		var xs = Array.ConvertAll(ps, p => p.x);
		var ys = Array.ConvertAll(ps, p => p.y);
		Array.Sort(xs);
		Array.Sort(ys);

		var l = (n - 1) / 2;
		var r = n / 2;
		var (d, u) = (l, r);

		return (xs[r] - xs[l] + 1) * (ys[u] - ys[d] + 1);
	}
}
