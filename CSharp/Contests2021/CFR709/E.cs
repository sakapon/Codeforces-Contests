using System;
using System.Collections.Generic;
using System.Linq;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var hs = Read();
		var bs = ReadL();

		var l = new List<(int h, long b)>();

		foreach (var (h, b) in hs.Zip(bs))
		{
			if (l.Count == 0)
			{
				l.Add((h, b));
			}
			else if (b > 0)
			{
				var (h0, b0) = l[^1];
				if (h0 > h && b0 <= 0) l.RemoveAt(l.Count - 1);
				l.Add((h, b));
			}
			else
			{
				var (h0, b0) = l[^1];
				if (h0 < h) continue;
				if (b0 <= 0) l.RemoveAt(l.Count - 1);
				l.Add((h, b));
			}
		}

		n = l.Count;

		var dp = new long[n];
		dp[0] = l[0].b;

		for (int i = 1; i < n; i++)
		{
			var (h, b) = l[i];
			if (b >= 0)
			{
				// 右から消される場合
				if (i - 2 < 0)
				{
					dp[i] = dp[i - 1] + b;
				}
				else
				{
					dp[i] = Math.Max(dp[i - 2], dp[i - 2] + l[i - 1].b + b);
				}
			}
			else
			{
				if (i - 2 < 0)
				{
					dp[i] = dp[i - 1] + b;
				}
				else
				{
					if (l[i - 2].h < h)
					{
						dp[i] = Math.Max(dp[i - 2], dp[i - 2] + l[i - 1].b + b);
					}
					else
					{
						dp[i] = Math.Max(b, dp[i - 1] + b);
					}
				}
			}
		}

		if (l[^1].b < 0 || n < 2) return dp[^1];
		return dp[^2] + l[^1].b;
	}
}
