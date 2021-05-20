using System;

class C
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = ReadL();

		Array.Sort(a);

		var dp = new MemoDP2<long>(n, n, -1, (t, i, j) =>
		{
			return Math.Min(t[i + 1, j], t[i, j - 1]) + a[j] - a[i];
		});

		for (int i = 0; i < n; i++)
		{
			dp[i, i] = 0;
		}

		return dp[0, n - 1];
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
