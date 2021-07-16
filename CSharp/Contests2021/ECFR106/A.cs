using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static (int, int, int) Read3() { var a = Read(); return (a[0], a[1], a[2]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var (n, k1, k2) = Read3();
		var (w, b) = Read2();

		var wmax = Math.Min(k1, k2) + Math.Abs(k1 - k2) / 2;
		var bmax = Math.Min(n - k1, n - k2) + Math.Abs(k1 - k2) / 2;
		return w <= wmax && b <= bmax;
	}
}
