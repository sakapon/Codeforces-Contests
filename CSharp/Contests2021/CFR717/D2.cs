using System;
using System.Collections.Generic;

class D2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main()
	{
		var (n, qc) = Read2();
		var a = Read();
		var qs = Array.ConvertAll(new bool[qc], _ => Read2());

		// a_i の次のグループのインデックス
		var to = Array.ConvertAll(new bool[n + 1], _ => n);
		// 各素数の出現したインデックス
		var ps = Array.ConvertAll(new bool[100000], _ => -1);

		for (int i = 0; i < n; i++)
		{
			if (a[i] == 1) continue;
			foreach (var f in Factorize(a[i]))
			{
				if (ps[f] != -1 && to[ps[f]] == n)
				{
					to[ps[f]] = i;
				}
				ps[f] = i;
			}
		}

		for (int i = n - 1; i >= 0; i--)
		{
			to[i] = Math.Min(to[i], to[i + 1]);
		}

		// a_j から 2^i 個目のグループのインデックス
		var dp = NewArray2<int>(20, n + 1);
		dp[0] = to;

		for (int i = 0; i < 20 - 1; i++)
		{
			for (int j = 0; j <= n; j++)
			{
				dp[i + 1][j] = dp[i][dp[i][j]];
			}
		}

		// [l, r)
		int GetCount(int l, int r)
		{
			if (l == r) return 0;
			if (dp[0][l] >= r) return 1;

			var i = 0;
			while (dp[i + 1][l] < r) i++;
			return (1 << i) + GetCount(dp[i][l], r);
		}

		Console.SetOut(new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
		foreach (var (l, r) in qs)
			Console.WriteLine(GetCount(l - 1, r));
		Console.Out.Flush();
	}

	static T[][] NewArray2<T>(int n1, int n2, T v = default) => Array.ConvertAll(new bool[n1], _ => Array.ConvertAll(new bool[n2], __ => v));

	// Distinct
	static long[] Factorize(long n)
	{
		var r = new List<long>();
		for (long x = 2; x * x <= n && n > 1; ++x)
		{
			if (n % x == 0) r.Add(x);
			while (n % x == 0) n /= x;
		}
		if (n > 1) r.Add(n);
		return r.ToArray();
	}
}
