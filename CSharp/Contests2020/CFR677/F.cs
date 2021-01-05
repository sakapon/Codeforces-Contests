using System;
using System.Linq;

class F
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int, int) Read3() { var a = Read(); return (a[0], a[1], a[2]); }
	static void Main()
	{
		var (n, m, k) = Read3();
		var a = Array.ConvertAll(new bool[n], _ => Read());

		var max = NewArray3(n, k, m / 2 + 1, int.MinValue);
		var dp = NewArray2(n + 1, k, int.MinValue);
		dp[0][0] = 0;

		for (int i = 0; i < n; i++)
		{
			max[i][0][0] = 0;
			for (int aj = 0; aj < m; aj++)
			{
				for (int c = m / 2 - 1; c >= 0; c--)
				{
					for (int r = 0; r < k; r++)
					{
						if (max[i][r][c] < 0) continue;
						var nv = max[i][r][c] + a[i][aj];
						max[i][nv % k][c + 1] = Math.Max(max[i][nv % k][c + 1], nv);
					}
				}
			}
			for (int j = 0; j < k; j++)
			{
				max[i][j][0] = max[i][j].Max();
			}
		}

		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < k; j++)
			{
				for (int l = 0; l < k; l++)
				{
					if (dp[i][j] < 0 || max[i][l][0] < 0) continue;
					var nk = (j + l) % k;
					dp[i + 1][nk] = Math.Max(dp[i + 1][nk], dp[i][j] + max[i][l][0]);
				}
			}
		}

		Console.WriteLine(dp[n][0]);
	}

	static T[] NewArray1<T>(int n, T v = default) => Array.ConvertAll(new bool[n], _ => v);
	static T[][] NewArray2<T>(int n1, int n2, T v = default) => Array.ConvertAll(new bool[n1], _ => Array.ConvertAll(new bool[n2], __ => v));
	static T[][][] NewArray3<T>(int n1, int n2, int n3, T v = default) => Array.ConvertAll(new bool[n1], _ => Array.ConvertAll(new bool[n2], __ => Array.ConvertAll(new bool[n3], ___ => v)));
}
