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

		var a = new int[n];
		var id = n;

		for (int i = 0; i < k; i++)
		{
			if (2 * i + 1 >= n - 1) return -1;
			a[2 * i + 1] = id--;
		}
		for (int i = 0; i < n; i++)
		{
			if (a[i] != 0) continue;
			a[i] = id--;
		}
		return string.Join(" ", a);
	}
}
