using System;
using System.Linq;

class A2
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var h = ReadL();

		for (int i = 0; i < n - 1; i++)
			if ((h[i + 1] += h[i] - i) < i + 1) return false;
		return true;
	}
}
