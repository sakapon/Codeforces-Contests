using System;
using System.Linq;

class A
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var b = Console.ReadLine();
		return new string(b.Where((x, i) => i % 2 == 0).ToArray()) + b.Last();
	}
}
