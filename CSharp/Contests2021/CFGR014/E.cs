using System;
using System.Linq;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		(int n, long M) = Read2();

		var mc = new MCombination(n + 1, M);

		// 長さ i の区間を j steps でオンにする方法
		var dp2 = new MemoDP2<long>(n + 1, n + 1, -1, (dp, i, j) =>
		{
			var d = i - j - 1;
			var v = 0L;

			for (int k = 1; k < j; k++)
			{
				v += dp[k + d, k] * dp[j - k, j - k] % M * mc.MNcr(j, k) % M;
			}
			return v % M;
		});

		for (int i = 0; i <= n; i++)
		{
			for (int j = 0; i >= 2 * j; j++)
			{
				dp2[i, j] = 0;
			}
		}

		dp2[1, 1] = 1;
		for (int i = 1; i < n; i++)
		{
			dp2[i + 1, i + 1] = dp2[i, i] * 2 % M;
		}

		return Enumerable.Range(1, n).Sum(j => dp2[n, j]) % M;
	}
}

class MemoDP2<T>
{
	static readonly Func<T, T, bool> TEquals = System.Collections.Generic.EqualityComparer<T>.Default.Equals;
	public T[,] Raw { get; }
	T iv;
	Func<MemoDP2<T>, int, int, T> rec;

	public MemoDP2(int n1, int n2, T iv, Func<MemoDP2<T>, int, int, T> rec)
	{
		Raw = new T[n1, n2];
		for (int i = 0; i < n1; ++i)
			for (int j = 0; j < n2; ++j)
				Raw[i, j] = iv;
		this.iv = iv;
		this.rec = rec;
	}

	public T this[int i, int j]
	{
		get => TEquals(Raw[i, j], iv) ? Raw[i, j] = rec(this, i, j) : Raw[i, j];
		set => Raw[i, j] = value;
	}
}

public class MCombination
{
	long M;
	long MPow(long b, long i)
	{
		long r = 1;
		for (; i != 0; b = b * b % M, i >>= 1) if ((i & 1) != 0) r = r * b % M;
		return r;
	}
	long MInv(long x) => MPow(x, M - 2);

	long[] MFactorials(int n)
	{
		var f = new long[n + 1];
		f[0] = 1;
		for (int i = 1; i <= n; ++i) f[i] = f[i - 1] * i % M;
		return f;
	}

	// nPr, nCr を O(1) で求めるため、階乗を O(n) で求めておきます。
	long[] f, f_;
	public MCombination(int nMax, long M)
	{
		this.M = M;
		f = MFactorials(nMax);
		f_ = Array.ConvertAll(f, MInv);
	}

	public long MFactorial(int n) => f[n];
	public long MInvFactorial(int n) => f_[n];
	public long MNpr(int n, int r) => n < r ? 0 : f[n] * f_[n - r] % M;
	public long MNcr(int n, int r) => n < r ? 0 : f[n] * f_[n - r] % M * f_[r] % M;
}
