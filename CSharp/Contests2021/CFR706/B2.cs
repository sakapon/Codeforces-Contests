using System;
using System.Linq;

class B2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var (n, k) = Read2();
		var a = Read();
		if (k == 0) return n;

		Array.Sort(a);
		var max = a.Last();
		if (max == n - 1) return n + k;

		var mex = Enumerable.Range(0, n).First(i => a[i] != i);
		var m = (mex + max + 1) / 2;
		return a.Contains(m) ? n : n + 1;
	}
}
