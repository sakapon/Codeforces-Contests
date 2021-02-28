using System;

class F
{
	const long M = 1000000007;
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Console.ReadLine();

		var dp = new long[4];
		dp[0] = 1;

		foreach (var c in s)
		{
			if (c == '?')
			{
				var t = Array.ConvertAll(dp, x => x * 3);
				for (int i = 0; i < 3; i++)
					t[i + 1] += dp[i];
				Array.Copy(t, dp, 4);
			}
			else
			{
				var i = c - 'a';
				dp[i + 1] += dp[i];
			}

			for (int i = 0; i < 4; i++)
				dp[i] %= M;
		}
		Console.WriteLine(dp[3]);
	}
}
