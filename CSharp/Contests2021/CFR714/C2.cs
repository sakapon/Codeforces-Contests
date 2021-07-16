using System;
using System.Linq;

class C2
{
	const long M = 1000000007;
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var dp = new long[200000 + 10];
		for (int i = 0; i < 10; i++)
		{
			dp[i] = 1;
		}

		long Get(int i)
		{
			if (dp[i] != 0) return dp[i];
			return dp[i] = (Get(i - 10) + Get(i - 9)) % M;
		}

		long SolveTest()
		{
			var (n, m) = Read2();
			return n.ToString().Sum(c => Get(m + c - '0')) % M;
		}

		var tc = int.Parse(Console.ReadLine());
		return string.Join("\n", new bool[tc].Select(_ => SolveTest()));
	}
}
