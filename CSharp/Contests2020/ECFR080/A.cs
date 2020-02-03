using System;
using System.Linq;

class A
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var h = Read();
		int n = h[0], d = h[1], rd = (int)Math.Sqrt(d);
		return Enumerable.Range(0, 2 * rd).Any(x => x + Math.Ceiling((double)d / (x + 1)) <= n) ? "YES" : "NO";
	}
}
