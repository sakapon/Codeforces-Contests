using System;
using System.Linq;

class B
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var x = int.Parse(Console.ReadLine());

		if (x >= 11 * 111) return true;

		for (int i = 0; i < 111; i++)
		{
			for (int j = 0; j < 11; j++)
			{
				if (x == 11 * i + 111 * j) return true;
			}
		}
		return false;
	}
}
