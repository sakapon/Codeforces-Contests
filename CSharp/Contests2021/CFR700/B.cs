using System;
using System.Linq;

class B
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static (long, long, long) Read3L() { var a = ReadL(); return (a[0], a[1], a[2]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var (A, B, n) = Read3L();
		var a = ReadL();
		var b = ReadL();

		var sum = Enumerable.Range(0, (int)n).Sum(i => (b[i] + A - 1) / A * a[i]);
		return B > sum - a.Max();
	}
}
