using System;
using System.Linq;

class F
{
	const long M = 1000000007;
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Console.ReadLine();

		var dp = NewArray2<long>(n + 1, 4);
		dp[0][0] = 1;

		for (int i = 0; i < n; i++)
		{
			switch (s[i])
			{
				case 'a':
					dp[i + 1][0] = dp[i][0];
					dp[i + 1][1] = dp[i][1] + dp[i][0];
					dp[i + 1][2] = dp[i][2];
					dp[i + 1][3] = dp[i][3];
					break;
				case 'b':
					dp[i + 1][0] = dp[i][0];
					dp[i + 1][1] = dp[i][1];
					dp[i + 1][2] = dp[i][2] + dp[i][1];
					dp[i + 1][3] = dp[i][3];
					break;
				case 'c':
					dp[i + 1][0] = dp[i][0];
					dp[i + 1][1] = dp[i][1];
					dp[i + 1][2] = dp[i][2];
					dp[i + 1][3] = dp[i][3] + dp[i][2];
					break;
				case '?':
					dp[i + 1][0] = dp[i][0] * 3;
					dp[i + 1][1] = dp[i][1] * 3 + dp[i][0];
					dp[i + 1][2] = dp[i][2] * 3 + dp[i][1];
					dp[i + 1][3] = dp[i][3] * 3 + dp[i][2];
					break;
				default:
					break;
			}

			for (int j = 0; j < 4; j++)
				dp[i + 1][j] %= M;
		}
		Console.WriteLine(dp[n][3]);
	}

	static T[][] NewArray2<T>(int n1, int n2, T v = default(T)) => NewArrayF(n1, () => NewArray1(n2, v));
	static T[] NewArray1<T>(int n, T v = default(T))
	{
		var a = new T[n];
		for (int i = 0; i < n; ++i) a[i] = v;
		return a;
	}

	static T[] NewArrayF<T>(int n, Func<T> newItem)
	{
		var a = new T[n];
		for (int i = 0; i < n; ++i) a[i] = newItem();
		return a;
	}
}
