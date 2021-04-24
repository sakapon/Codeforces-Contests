using System;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int, int) Read3() { var a = Read(); return (a[0], a[1], a[2]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var (n, m, k) = Read3();
		var yoko = Array.ConvertAll(new bool[n], _ => Read());
		var tate = Array.ConvertAll(new bool[n - 1], _ => Read());

		if (k % 2 != 0) return string.Join("\n", new bool[n].Select(_ => string.Join(" ", Enumerable.Repeat(-1, m))));
		k /= 2;

		var dp = NewArray3(k + 1, n, m, 1 << 30);

		for (int i = 0; i < n; i++)
			for (int j = 0; j < m - 1; j++)
				for (int q = 0; q <= k; q++)
				{
					var v = 2 * q * yoko[i][j];
					dp[q][i][j] = Math.Min(dp[q][i][j], v);
					dp[q][i][j + 1] = Math.Min(dp[q][i][j + 1], v);
				}
		for (int i = 0; i < n - 1; i++)
			for (int j = 0; j < m; j++)
				for (int q = 0; q <= k; q++)
				{
					var v = 2 * q * tate[i][j];
					dp[q][i][j] = Math.Min(dp[q][i][j], v);
					dp[q][i + 1][j] = Math.Min(dp[q][i + 1][j], v);
				}

		for (int q = 2; q <= k; q++)
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
				{
					if (j > 0) dp[q][i][j] = Math.Min(dp[q][i][j], 2 * yoko[i][j - 1] + dp[q - 1][i][j - 1]);
					if (j + 1 < m) dp[q][i][j] = Math.Min(dp[q][i][j], 2 * yoko[i][j] + dp[q - 1][i][j + 1]);
					if (i > 0) dp[q][i][j] = Math.Min(dp[q][i][j], 2 * tate[i - 1][j] + dp[q - 1][i - 1][j]);
					if (i + 1 < n) dp[q][i][j] = Math.Min(dp[q][i][j], 2 * tate[i][j] + dp[q - 1][i + 1][j]);
				}

		return string.Join("\n", dp[k].Select(l => string.Join(" ", l)));
	}

	static T[][][] NewArray3<T>(int n1, int n2, int n3, T v = default) => Array.ConvertAll(new bool[n1], _ => Array.ConvertAll(new bool[n2], __ => Array.ConvertAll(new bool[n3], ___ => v)));
}
