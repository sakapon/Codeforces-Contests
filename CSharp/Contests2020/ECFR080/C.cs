using System;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var h = Read();
		int n = h[0], m = h[1];

		var dp = new MInt[m + 1, n + 1];
		dp[0, 1] = 1;
		for (int i = 0; i < m; i++)
			for (int j = 1; j <= n; j++)
				dp[i + 1, j] = dp[i + 1, j - 1] + dp[i, j];

		var s = new MInt[n + 1];
		for (int i = 0; i < n; i++) s[i + 1] = s[i] + dp[m, i + 1];

		Console.WriteLine(Enumerable.Range(1, n).Select(i => dp[m, i] * s[n + 1 - i]).Aggregate((x, y) => x + y));
	}
}

struct MInt
{
	const int M = 1000000007;
	public long V;
	public MInt(long v) { V = (v %= M) < 0 ? v + M : v; }

	public static implicit operator MInt(long v) => new MInt(v);
	public static MInt operator +(MInt x, MInt y) => x.V + y.V;
	public static MInt operator *(MInt x, MInt y) => x.V * y.V;
	public override string ToString() => $"{V}";
}
