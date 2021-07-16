using System;
using System.Collections.Generic;
using System.Linq;

class EL
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

		var dp1 = new MemoDP1<long>(Math.Max(n, m) + 1, -1, (dp, i) => (dp[i - 1] + 2 * dp[i - 2] + p2[i - 2]) % M);
		dp1[0] = dp1[1] = 0;

		var r = 0L;

		for (int i = 0; i < n; i++)
		{
			var q = rm.Select(j => s[i][j]).GroupCountsBySeq(c => c).Where(g => g.Key == 'o');
			foreach (var (_, x) in q)
			{
				r += p2[w - x] * dp1[x];
				r %= M;
			}
		}
		for (int j = 0; j < m; j++)
		{
			var q = rn.Select(i => s[i][j]).GroupCountsBySeq(c => c).Where(g => g.Key == 'o');
			foreach (var (_, x) in q)
			{
				r += p2[w - x] * dp1[x];
				r %= M;
			}
		}
		return r;
	}

	const long M = 998244353;
	static long[] MPows(long b, int n)
	{
		var p = new long[n + 1];
		p[0] = 1;
		for (int i = 0; i < n; ++i) p[i + 1] = p[i] * b % M;
		return p;
	}
}

class MemoDP1<T>
{
	static readonly Func<T, T, bool> TEquals = System.Collections.Generic.EqualityComparer<T>.Default.Equals;
	public T[] Raw { get; }
	T iv;
	Func<MemoDP1<T>, int, T> rec;

	public MemoDP1(int n, T iv, Func<MemoDP1<T>, int, T> rec)
	{
		Raw = Array.ConvertAll(new bool[n], _ => iv);
		this.iv = iv;
		this.rec = rec;
	}

	public T this[int i]
	{
		get => TEquals(Raw[i], iv) ? Raw[i] = rec(this, i) : Raw[i];
		set => Raw[i] = value;
	}
}
