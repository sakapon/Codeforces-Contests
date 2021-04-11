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

		for (int i = 0; i < 30; i++)
		{
			var f = 1 << i;
			if (a.All(x => (x & f) != 0))
			{
				a = Array.ConvertAll(a, x => x - f);
			}
		}

		var c0 = a.Count(x => x == 0);
		if (c0 < 2) return 0;
		return (long)c0 * (c0 - 1) % M * MFactorial(n - 2) % M;
	}

	const long M = 1000000007;
	static long MFactorial(int n) { for (long x = 1, i = 1; ; x = x * ++i % M) if (i >= n) return x; }
}
