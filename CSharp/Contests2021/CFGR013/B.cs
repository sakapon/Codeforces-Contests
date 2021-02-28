using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int, int) Read3() { var a = Read(); return (a[0], a[1], a[2]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var (n, u, v) = Read3();
		var a = Read();

		var d = Enumerable.Range(0, n - 1).Select(i => Math.Abs(a[i + 1] - a[i])).ToArray();
		if (d.Any(x => x >= 2)) return 0;
		if (d.Any(x => x >= 1)) return Math.Min(u, v);
		return Math.Min(u, v) + v;
	}
}
