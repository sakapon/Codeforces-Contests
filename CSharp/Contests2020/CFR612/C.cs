﻿using System;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var p = Read();

		var even = n / 2;
		var odd = (n + 1) / 2;
		var max = 1 << 20;

		var dp = new int[n + 1, even + 1, 2];
		for (int i = 0; i <= n; i++)
			for (int j = 0; j <= even; j++)
				for (int k = 0; k < 2; k++)
					dp[i, j, k] = max;
		dp[0, 0, 0] = 0;
		dp[0, 0, 1] = 0;

		for (int i = 1; i <= n; i++)
		{
			var v = p[i - 1];
			var e_max = Math.Min(i, even);
			var e_min = Math.Max(i - odd, 0);

			for (int j = e_min; j <= e_max; j++)
			{
				if ((v == 0 || v % 2 == 0) && j > 0)
					dp[i, j, 0] = Math.Min(dp[i - 1, j - 1, 0], dp[i - 1, j - 1, 1] + 1);
				if (v == 0 || v % 2 == 1)
					dp[i, j, 1] = Math.Min(dp[i - 1, j, 0] + 1, dp[i - 1, j, 1]);
			}
		}
		Console.WriteLine(Math.Min(dp[n, even, 0], dp[n, even, 1]));
	}
}
