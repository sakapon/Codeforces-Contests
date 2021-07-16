using System;
using System.Collections.Generic;
using System.Linq;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var (n, m) = Read2();
		var s = Array.ConvertAll(new bool[n], _ => Console.ReadLine());

		var w = s.Sum(row => row.Count(c => c == 'o'));

		var p2 = MPows(2, n * m);
		var rn = Enumerable.Range(0, n).ToArray();
		var rm = Enumerable.Range(0, m).ToArray();

		var dp = new long[Math.Max(n, m) + 1];
		long Rec(int i)
		{
			if (i < 2 || dp[i] > 0) return dp[i];
			return dp[i] = (Rec(i - 1) + 2 * Rec(i - 2) + p2[i - 2]) % M;
		}
		// OEIS A045883
		//var d9 = MInv(9);
		//long Rec(int i) => ((3 * i - 2) * p2[i - 1] + (i % 2 == 0 ? 1 : M - 1)) % M * d9 % M;

		var r = 0L;

		for (int i = 0; i < n; i++)
		{
			var q = rm.Select(j => s[i][j]).GroupCountsBySeq(c => c).Where(g => g.Key == 'o');
			foreach (var (_, x) in q)
			{
				r += p2[w - x] * Rec(x);
				r %= M;
			}
		}
		for (int j = 0; j < m; j++)
		{
			var q = rn.Select(i => s[i][j]).GroupCountsBySeq(c => c).Where(g => g.Key == 'o');
			foreach (var (_, x) in q)
			{
				r += p2[w - x] * Rec(x);
				r %= M;
			}
		}
		return r;
	}

	const long M = 998244353;
	static long MPow(long b, long i)
	{
		long r = 1;
		for (; i != 0; b = b * b % M, i >>= 1) if ((i & 1) != 0) r = r * b % M;
		return r;
	}
	static long MInv(long x) => MPow(x, M - 2);

	static long[] MPows(long b, int n)
	{
		var p = new long[n + 1];
		p[0] = 1;
		for (int i = 0; i < n; ++i) p[i + 1] = p[i] * b % M;
		return p;
	}
}

static class GE
{
	public static IEnumerable<KeyValuePair<TK, int>> GroupCountsBySeq<TS, TK>(this IEnumerable<TS> source, Func<TS, TK> toKey)
	{
		var c = EqualityComparer<TK>.Default;
		TK k = default(TK), kt;
		var count = 0;

		foreach (var o in source)
		{
			if (!c.Equals(k, kt = toKey(o)))
			{
				if (count > 0) yield return new KeyValuePair<TK, int>(k, count);
				k = kt;
				count = 0;
			}
			++count;
		}
		if (count > 0) yield return new KeyValuePair<TK, int>(k, count);
	}
}
