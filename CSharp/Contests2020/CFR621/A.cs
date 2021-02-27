using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var (n, d) = Read2();
		var a = Read();

		for (int i = 1; i < n; i++)
		{
			var t = Math.Min(a[i], d / i);
			a[0] += t;
			d -= t * i;
		}
		return a[0];
	}
}
