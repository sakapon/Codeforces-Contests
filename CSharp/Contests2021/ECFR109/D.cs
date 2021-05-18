using System;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var rn = Enumerable.Range(0, n).ToArray();
		var is0 = Array.FindAll(rn, i => a[i] == 0); // i
		var is1 = Array.FindAll(rn, i => a[i] == 1); // j

		var m = is0.Length;

		var dp = new MemoDP2<int>(m + 1, n - m + 1, -1, (t, i, j) =>
		{
			return Math.Min(t[i - 1, j - 1] + Math.Abs(is0[i - 1] - is1[j - 1]), t[i - 1, j]);
		});

		for (int i = 0; i <= m; i++)
		{
			dp[i, 0] = 0;

			for (int j = i + 1; j <= n - m; j++)
			{
				dp[i, j] = 1 << 30;
			}
		}

		return dp[m, n - m];
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
