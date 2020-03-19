using System;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read().OrderBy(x => x).ToArray();
		return a[n] - a[n - 1];
	}
}
