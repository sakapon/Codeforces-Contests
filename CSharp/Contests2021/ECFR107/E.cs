using System;
using System.Collections.Generic;
using System.Linq;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var (n, m) = Read2();
		var s = Array.ConvertAll(new bool[n], _ => Console.ReadLine());

		var w = s.Sum(row => row.Count(c => c == 'o'));

		var p2 = MPows(2, n * m);
		var rn = Enumerable.Range(0, n).ToArray();
		var rm = Enumerable.Range(0, m).ToArray();

		var r = 0L;

		for (int i = 0; i < n; i++)
		{
			var q = rm.Select(j => s[i][j]).GroupCountsBySeq(c => c).Where(g => g.Key == 'o');
			foreach (var (_, x) in q)
			{
				r += p2[w - x] * GetConsecutive(x);
				r %= M;
			}
		}
		for (int j = 0; j < m; j++)
		{
			var q = rn.Select(i => s[i][j]).GroupCountsBySeq(c => c).Where(g => g.Key == 'o');
			foreach (var (_, x) in q)
			{
				r += p2[w - x] * GetConsecutive(x);
				r %= M;
			}
		}

		return r;

		long GetConsecutive(int n)
		{
			var dp = new long[n + 1];

			for (int i = 2; i <= n; i++)
			{
				dp[i] = (dp[i - 1] + 2 * dp[i - 2] + p2[i - 2]) % M;
			}
			return dp[n];
		}
	}

	const long M = 998244353;
	const long MHalf = (M + 1) / 2;
	static long MPow(long b, long i)
	{
		long r = 1;
		for (; i != 0; b = b * b % M, i >>= 1) if ((i & 1) != 0) r = r * b % M;
		return r;
	}

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
	public static Dictionary<TK, int> GroupCounts<TS, TK>(this IEnumerable<TS> source, Func<TS, TK> toKey)
	{
		var d = new Dictionary<TK, int>();
		TK k;
		foreach (var o in source)
			if (d.ContainsKey(k = toKey(o))) ++d[k];
			else d[k] = 1;
		return d;
	}

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

	public static IEnumerable<IGrouping<TK, TS>> GroupBySeq<TS, TK>(this IEnumerable<TS> source, Func<TS, TK> toKey)
	{
		var c = EqualityComparer<TK>.Default;
		var k = default(TK);
		var l = new List<TS>();

		foreach (var o in source)
		{
			var kt = toKey(o);
			if (!c.Equals(kt, k))
			{
				if (l.Count > 0) yield return new G<TK, TS>(k, l.ToArray());
				k = kt;
				l.Clear();
			}
			l.Add(o);
		}
		if (l.Count > 0) yield return new G<TK, TS>(k, l.ToArray());
	}

	class G<TK, TE> : IGrouping<TK, TE>
	{
		public TK Key { get; }
		IEnumerable<TE> Values;
		public G(TK key, TE[] values) { Key = key; Values = values; }

		public IEnumerator<TE> GetEnumerator() => Values.GetEnumerator();
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
