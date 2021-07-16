using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var (n, k) = Read2();
		var a = Read();
		if (k == 0) return n;

		Array.Sort(a);
		var max = a.Last();

		if (max == n - 1) return n + k;

		var set = a.ToHashSet();
		var mex = Enumerable.Range(0, n).First(i => !set.Contains(i));

		var m = (mex + max + 1) / 2;
		return set.Contains(m) ? n : n + 1;
	}
}
