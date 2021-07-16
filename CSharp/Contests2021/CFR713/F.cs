using System;
using System.Linq;

class F
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, c) = Read2();
		var a = ReadL();
		var b = ReadL();

		// position i に移ったとき
		var dp = new (long day, long sum)[n];

		for (int i = 0; i < n - 1; i++)
		{
			var (d0, s0) = dp[i];
			var d = b[i] <= s0 ? 0 : (b[i] - s0 - 1) / a[i] + 1;
			dp[i + 1] = (d0 + d + 1, s0 + a[i] * d - b[i]);
		}

		var r = 1L << 60;

		for (int i = 0; i < n; i++)
		{
			var (d0, s0) = dp[i];
			var d = c <= s0 ? 0 : (c - s0 - 1) / a[i] + 1;
			r = Math.Min(r, d + d0);
		}

		return r;
	}
}
