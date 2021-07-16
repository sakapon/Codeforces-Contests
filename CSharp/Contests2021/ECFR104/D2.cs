using System;
using System.Linq;

class D2
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = long.Parse(Console.ReadLine());

		// [√(2n-1)]
		// これでも通った:
		//var a = (int)Math.Floor(Math.Sqrt(2 * n - 1));
		var f = FloorSqrt();
		var a = f(2 * n - 1);
		return (a - 1) / 2;
	}

	public static Func<long, long> Floor(long l, long r, Func<long, long> f) => y => Last(l, r, x => f(x) <= y);
	public static Func<long, long> FloorSqrt() => Floor(-1, 1L << 31, x => x * x);

	static long Last(long l, long r, Func<long, bool> f)
	{
		long m;
		while (l < r) if (f(m = r - (r - l - 1) / 2)) l = m; else r = m - 1;
		return l;
	}
}
