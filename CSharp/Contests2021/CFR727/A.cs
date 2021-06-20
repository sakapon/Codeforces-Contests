using System;
using System.Linq;

class A
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static (long, long, long) Read3L() { var a = ReadL(); return (a[0], a[1], a[2]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, x, t) = Read3L();

		var d = t / x;
		if (n <= d) return n * (n - 1) / 2;
		return n * d - d * (d + 1) / 2;
	}
}
