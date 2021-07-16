using System;
using System.Linq;

class B2
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var n = long.Parse(Console.ReadLine());
		return n % 2 == 0 && IsSquare(n / 2) || n % 4 == 0 && IsSquare(n / 4);
	}

	static bool IsSquare(long x)
	{
		var r = (long)Math.Sqrt(x);
		return r * r == x;
	}
}
