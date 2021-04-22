using System;
using System.Linq;

class A2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, k) = Read2();
		var a = Read();

		for (int i = 0; i < n - 1; i++)
		{
			var t = Math.Min(k, a[i]);
			a[i] -= t;
			a[^1] += t;
			k -= t;
		}
		return string.Join(" ", a);
	}
}
