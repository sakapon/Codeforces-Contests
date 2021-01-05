using System;

class F
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int, int) Read3() { var a = Read(); return (a[0], a[1], a[2]); }
	static void Main()
	{
		var (n, m, k) = Read3();
		var a = Array.ConvertAll(new bool[n], _ => Read());

		// row, count, remainder
		var dp = NewArray3(n, m / 2 + 1, k, -1);

		for (int i = 0; i < n; i++)
		{
			dp[i][0][0] = 0;
			for (int j = 0; j < m; j++)
			{
				for (int c = m / 2 - 1; c >= 0; c--)
				{
					for (int r = 0; r < k; r++)
					{
						if (dp[i][c][r] < 0) continue;
						var nv = dp[i][c][r] + a[i][j];
						dp[i][c + 1][nv % k] = Math.Max(dp[i][c + 1][nv % k], nv);
					}
				}
			}

			for (int c = m / 2; c > 0; c--)
			{
				for (int r = 0; r < k; r++)
				{
					dp[i][0][r] = Math.Max(dp[i][0][r], dp[i][c][r]);
				}
			}
		}

		var sum = NewArray1(k, -1);
		sum[0] = 0;

		for (int i = 0; i < n; i++)
		{
			var t = NewArray1(k, -1);

			for (int r = 0; r < k; r++)
			{
				for (int ir = 0; ir < k; ir++)
				{
					if (sum[r] < 0 || dp[i][0][ir] < 0) continue;
					var nv = sum[r] + dp[i][0][ir];
					t[nv % k] = Math.Max(t[nv % k], nv);
				}
			}
			sum = t;
		}

		Console.WriteLine(sum[0]);
	}

	static T[] NewArray1<T>(int n, T v = default) => Array.ConvertAll(new bool[n], _ => v);
	static T[][][] NewArray3<T>(int n1, int n2, int n3, T v = default) => Array.ConvertAll(new bool[n1], _ => Array.ConvertAll(new bool[n2], __ => Array.ConvertAll(new bool[n3], ___ => v)));
}
