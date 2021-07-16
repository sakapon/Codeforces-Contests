using System;
using System.Collections.Generic;
using System.Linq;

class D2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var rn = Enumerable.Range(0, n).ToArray();
		var is1 = Array.FindAll(rn, i => a[i] == 1); // i
		var is0 = Array.FindAll(rn, i => a[i] == 0); // j

		var m = is1.Length;

		var dp = new MemoDP2<int>(m + 1, n - m + 1, 1 << 30, (t, i, j) =>
		{
			return Math.Min(t[i - 1, j - 1] + Math.Abs(is1[i - 1] - is0[j - 1]), t[i, j - 1]);
		});

		for (int j = 0; j <= n - m; j++)
		{
			dp[0, j] = 0;
		}
		for (int i = 0; i < m; i++)
		{
			dp[i + 1, i + 1] = dp[i, i] + Math.Abs(is1[i] - is0[i]);
		}

		return Enumerable.Range(m, n - 2 * m + 1).Min(j => dp[m, j]);
	}
}
