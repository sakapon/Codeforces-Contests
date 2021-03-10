using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var (n, k) = Read2();
		var s = Console.ReadLine();

		var c = Enumerable.Range(0, n / 2).TakeWhile(i => s[i] == s[^(i + 1)]).Count();
		c = Math.Min(c, (n - 1) / 2);
		return c >= k;
	}
}
