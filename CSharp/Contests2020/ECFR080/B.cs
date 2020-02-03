using System;
using System.Linq;

class B
{
	static long[] Read() => Console.ReadLine().Split().Select(long.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var h = Read();
		return h[0] * Enumerable.Range(1, 9).Count(i => Math.Pow(10, i) - 1 <= h[1]);
	}
}
