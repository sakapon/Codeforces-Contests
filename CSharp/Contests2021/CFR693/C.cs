using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var dp = new long[n];

		void Rec(int i)
		{
			if (dp[i] > 0) return;

			dp[i] = a[i];

			var ni = i + a[i];
			if (ni < n)
			{
				Rec(ni);
				dp[i] += dp[ni];
			}
		}

		for (int i = 0; i < n; i++)
		{
			Rec(i);
		}
		return dp.Max();
	}
}
