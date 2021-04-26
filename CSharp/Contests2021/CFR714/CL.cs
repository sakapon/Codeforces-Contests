using System;
using System.Linq;

class CL
{
	const long M = 1000000007;
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var dp1 = new MemoDP1<long>(200000 + 10, 0, (dp, i) => (dp[i - 10] + dp[i - 9]) % M);
		for (int i = 0; i < 10; i++)
			dp1[i] = 1;

		long SolveTest()
		{
			var (n, m) = Read2();
			return n.ToString().Sum(c => dp1[m + c - '0']) % M;
		}

		var tc = int.Parse(Console.ReadLine());
		return string.Join("\n", new bool[tc].Select(_ => SolveTest()));
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
