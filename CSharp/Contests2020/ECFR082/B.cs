using System;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var h = Read();
		int n = h[0], g = h[1], b = h[2];
		int n2 = (n + 1) / 2, gb = g + b;

		return First(0, 1L << 60, x =>
		{
			var turn = Math.DivRem(x, gb, out var rem);
			return x >= n && g * turn + Math.Min(rem, g) >= n2;
		});
	}

	static long First(long l, long r, Func<long, bool> f)
	{
		long m;
		while (l < r) if (f(m = l + (r - l - 1) / 2)) r = m; else l = m + 1;
		return r;
	}
}
