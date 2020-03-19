using System;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var h = Read();
		long n = h[0], m = h[1];

		var mid = (n + 1) / (m + 1);
		return mid * (mid + 1) / 2 * m + (n - mid) * (n - mid + 1) / 2;
	}
}
