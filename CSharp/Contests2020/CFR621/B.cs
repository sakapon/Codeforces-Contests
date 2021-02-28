using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var (n, x) = Read2();
		var a = Read();

		var M = a.Max();
		if (x < M)
		{
			return a.Any(v => v == x) ? 1 : 2;
		}
		else
		{
			return (x + M - 1) / M;
		}
	}
}
