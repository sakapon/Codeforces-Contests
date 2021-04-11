using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(Solve());
	//static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	//static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var t = int.Parse(Console.ReadLine());
		var nms = Array.ConvertAll(new bool[t], _ => Read2());

		var dp = NewArray2<long>(200000 + 10, 10);
		dp[0][0] = 1;
		for (int i = 0; i < dp.Length - 1; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				dp[i + 1][j + 1] += dp[i][j];
			}
			dp[i + 1][0] += dp[i][9];
			dp[i + 1][1] += dp[i][9];

			for (int j = 0; j < 10; j++)
			{
				dp[i + 1][j] %= M;
			}
		}

		return string.Join("\n", nms.Select(nm =>
		{
			var (n, m) = nm;
			var r = Enumerable.Range(0, 10).Select(x => dp[m + x].Sum() % M).ToArray();
			return n.ToString().Sum(c => r[c - '0']) % M;
		}));
	}

	const long M = 1000000007;
	static T[][] NewArray2<T>(int n1, int n2, T v = default) => Array.ConvertAll(new bool[n1], _ => Array.ConvertAll(new bool[n2], __ => v));
}
