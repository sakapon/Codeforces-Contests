using System;
using System.Linq;

class B2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var amin = a.Min();
		if (!Array.TrueForAll(a, x => (x & amin) == amin)) return 0;

		var cmin = a.LongCount(x => x == amin);
		return cmin * (cmin - 1) % M * MFactorial(n - 2) % M;
	}

	const long M = 1000000007;
	static long MFactorial(int n) { for (long x = 1, i = 1; ; x = x * ++i % M) if (i >= n) return x; }
}
