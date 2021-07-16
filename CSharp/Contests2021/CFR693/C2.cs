using System;
using System.Linq;

class C2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var dp = a.ToArray();

		for (int i = n - 1; i >= 0; i--)
		{
			var ni = i + a[i];
			if (ni < n) dp[i] += dp[ni];
		}
		return dp.Max();
	}
}
