using System;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var c0 = a.Where((x, i) => i % 2 == 0 && x % 2 != 0).Count();
		var c1 = a.Where((x, i) => i % 2 == 1 && x % 2 != 1).Count();
		return c0 == c1 ? c0 : -1;
	}
}
