using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select((_, i) => Solve(i) ? "YES" : "NO")));
	static bool Solve(int k)
	{
		if (k != 0) Console.ReadLine();
		var (n, x) = Read2();
		var a = Read();
		var b = Read();

		Array.Sort(a);
		Array.Sort(b);
		Array.Reverse(b);

		return a.Zip(b, (u, v) => u + v <= x).All(b => b);
	}
}
