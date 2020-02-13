using System;
using System.Linq;

class B2
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var h = Read();
		long n = h[0], g = h[1], b = h[2];

		var q = Math.DivRem((n + 1) / 2, g, out var rem);
		if (rem == 0) { q--; rem = g; }
		var r = q * (g + b) + rem;
		return r < n ? n : r;
	}
}
