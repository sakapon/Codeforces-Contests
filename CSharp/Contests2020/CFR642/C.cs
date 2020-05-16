using System;
using System.Linq;

class C
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var n = long.Parse(Console.ReadLine()) / 2;
		return n * (n + 1) * (2 * n + 1) * 4 / 3;
	}
}
