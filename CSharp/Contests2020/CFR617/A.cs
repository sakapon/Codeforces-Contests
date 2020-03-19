using System;
using System.Linq;

class A
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		if (a.Sum() % 2 == 1) return "YES";
		return a.Any(x => x % 2 == 0) && a.Any(x => x % 2 == 1) ? "YES" : "NO";
	}
}
