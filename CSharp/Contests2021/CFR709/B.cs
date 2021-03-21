using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	//static void Main() => Console.WriteLine(Solve());
	//static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();
		if (n == 1) return 0;

		var d = Enumerable.Range(0, n - 1).Select(i => a[i + 1] - a[i])
			.Distinct()
			.ToArray();
		if (d.Length == 1) return 0;
		if (d.Length > 2) return -1;

		var c1 = d.Min();
		var c2 = d.Max();
		var m = c2 - c1;

		if (m <= a.Max()) return -1;
		return $"{m} {c2}";
	}
}
