using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static string Solve()
	{
		var n = long.Parse(Console.ReadLine());

		var ps = Factorize(n).GroupBy(p => p).ToDictionary(g => g.Key, g => g.Count());
		var p1 = ps.OrderBy(p => -p.Value).First();

		var k = p1.Value;
		var a_last = n / Pow(p1.Key, k - 1);

		return $"{k}\n" + string.Join(" ", Enumerable.Repeat(p1.Key, k - 1).Append(a_last));
	}

	static long[] Factorize(long n)
	{
		var r = new List<long>();
		for (long x = 2; x * x <= n && n > 1; ++x) while (n % x == 0) { r.Add(x); n /= x; }
		if (n > 1) r.Add(n);
		return r.ToArray();
	}

	static long Pow(long b, long i)
	{
		for (long r = 1; ; b *= b)
		{
			if ((i & 1) != 0) r *= b;
			if ((i >>= 1) == 0) return r;
		}
	}
}
