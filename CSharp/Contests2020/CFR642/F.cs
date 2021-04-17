using System;
using System.Collections.Generic;
using System.Linq;

class F
{
	const long max = 1L << 60;
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, m) = Read2();
		var a = Array.ConvertAll(new bool[n], _ => ReadL());

		var deltas = new HashSet<long> { 0 };

		var a00 = a[0][0];
		for (int i = 0; i < n; i++)
			for (int j = 0; j < m; j++)
			{
				var v = a[i][j] = a[i][j] - a00 - i - j;
				if (v < 0) deltas.Add(-v);
			}

		var b = new long[n + 1, m + 1];
		var dp = new long[n + 1, m + 1];

		return deltas.Where(d => d >= -a[n - 1][m - 1]).Min(d => Spp(d));

		long Spp(long d)
		{
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
				{
					var v = a[i][j] + d;
					b[i, j] = v < 0 ? max : v;
				}
			return d + SppDP();
		}

		long SppDP()
		{
			for (int i = 0; i <= n; i++)
				for (int j = 0; j <= m; j++)
					dp[i, j] = max;
			dp[0, 0] = 0;

			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
				{
					dp[i + 1, j] = Math.Min(dp[i + 1, j], dp[i, j] + b[i + 1, j]);
					dp[i, j + 1] = Math.Min(dp[i, j + 1], dp[i, j] + b[i, j + 1]);
				}
			return dp[n - 1, m - 1];
		}
	}
}
