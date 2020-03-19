using System;
using System.Linq;

class A
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var c0 = a.Count(x => x == 0);
		var sum = a.Sum() + c0;
		return sum == 0 ? c0 + 1 : c0;
	}
}
