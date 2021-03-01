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

		var M = Enumerable.Range(0, n - 1).Max(i => Math.Abs(a[i + 1] - a[i]));
		if (M == 0) return Math.Min(u, v) + v;
		if (M == 1) return Math.Min(u, v);
		return 0;
	}
}
