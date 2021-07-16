using System;
using System.Linq;

class C1
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var dp = new MemoDP2<long>(n + 1, n + 1, long.MinValue, (t, i, j) =>
		{
			var v = t[i - 1, j];
			if (t[i - 1, j - 1] >= 0) v = Math.Max(v, t[i - 1, j - 1] + a[i - 1]);
			return v;
		});

		for (int i = 0; i <= n; i++)
			dp[i, 0] = 0;
		for (int j = 1; j <= n; j++)
			dp[0, j] = -1;

		return Enumerable.Range(0, n + 1).Last(j => dp[n, j] >= 0);
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
