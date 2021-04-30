using System;
using System.Collections.Generic;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main()
	{
		var (n, qc) = Read2();
		var a = Read();
		var qs = Array.ConvertAll(new bool[qc], _ => Read2());

		var afs = Array.ConvertAll(a, x => Factorize(x));

		// a_i の次のグループのインデックス
		var to = Array.ConvertAll(new bool[n + 1], _ => n);
		var ps = new bool[100000];

		bool IsCoprime(int i)
		{
			foreach (var f in afs[i])
				if (ps[f]) return false;
			return true;
		}

		for (var (l, r) = (0, 0); r < n; r++)
		{
			if (a[r] == 1) continue;

			while (!IsCoprime(r))
			{
				to[l] = r;
				foreach (var f in afs[l])
					ps[f] = false;
				l++;
			}

			foreach (var f in afs[r])
				ps[f] = true;
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
			var c = 1;
			while (l < r)
			{
				var i = -1;
				while (dp[i + 1][l] < r) i++;

				if (i == -1) break;
				c += 1 << i;
				l = dp[i][l];
			}
			return c;
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
