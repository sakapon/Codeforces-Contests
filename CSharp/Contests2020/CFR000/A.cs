using System;
using System.Linq;

class A
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var h = Read();
		//int n = h[0], m = h[1];
		var s = Console.ReadLine();

		var r = 0L;
		return r;
	}
}
