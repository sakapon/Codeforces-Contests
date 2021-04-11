using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	//static void Main() => Console.WriteLine(Solve());
	//static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, k) = Read2();

		if (k > (n - 1) / 2) return -1;

		var a = new int[n];
		var id = 0;

		for (int i = 0; i <= k; i++)
		{
			a[2 * i] = ++id;
		}
		for (int i = 0; i < k; i++)
		{
			a[2 * i + 1] = ++id;
		}
		for (int i = 2 * k + 1; i < n; i++)
		{
			a[i] = ++id;
		}
		return string.Join(" ", a);
	}
}
