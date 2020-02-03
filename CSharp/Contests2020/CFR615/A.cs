using System;
using System.Linq;

class A
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var h = Read();
		return h.Sum() % 3 == 0 && h.Take(3).Max() <= h.Sum() / 3 ? "YES" : "NO";
	}
}
