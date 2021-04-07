﻿using System;
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

		var l = new LinkedList<(int h, long b)>(hs.Zip(bs));

		for (var ln = l.Last.Previous; ln != null; ln = ln.Previous)
		{
			var ln2 = ln.Next;
			var (h1, b1) = ln.Value;
			var (h2, b2) = ln2.Value;

			if (b1 >= 0)
			{
				if (b2 >= 0) continue;
				if (h1 > h2) continue;
				l.Remove(ln2);
			}
			else
			{
				if (b2 >= 0)
				{
					if (h1 < h2) continue;
					l.Remove(ln);
					ln = ln2;
				}
				else
				{
					if (h1 > h2) (ln, ln2) = (ln2, ln);
					l.Remove(ln2);
				}
			}
		}

		for (var ln = l.Last.Previous; ln != null; ln = ln.Previous)
		{
			var ln2 = ln.Next;
			var (h1, b1) = ln.Value;
			var (h2, b2) = ln2.Value;

			if (b1 >= 0 && b2 >= 0)
			{
				ln.Value = (Math.Min(h1, h2), b1 + b2);
				l.Remove(ln2);
			}
		}

		var a = l.ToArray();
		n = a.Length;

		var dp = new long[n];
		dp[0] = a[0].b;

		for (int i = 1; i < n; i++)
		{
			var (h, b) = a[i];
			if (b >= 0)
			{
				// 右から消される場合
				if (i - 2 < 0)
				{
					dp[i] = dp[i - 1] + b;
				}
				else
				{
					dp[i] = Math.Max(dp[i - 2], dp[i - 2] + a[i - 1].b + b);
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
					if (a[i - 2].h < h)
					{
						dp[i] = Math.Max(dp[i - 2], dp[i - 2] + a[i - 1].b + b);
					}
					else
					{
						dp[i] = Math.Max(b, dp[i - 1] + b);
					}
				}
			}
		}

		if (a[^1].b < 0 || n < 2) return dp[^1];
		return dp[^2] + a[^1].b;
	}
}
