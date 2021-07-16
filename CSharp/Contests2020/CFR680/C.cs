using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static (long, long) Read2L() { var a = ReadL(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var (a, b) = Read2L();

		if (a % b == 0)
		{
			var d = Factorize(b).GroupBy(p => p).ToDictionary(g => g.Key, g => g.Count());

			var r = 0L;
			foreach (var (p, c) in d)
			{
				var t = a;
				while (t % p == 0) t /= p;
				for (int i = 0; i < c - 1; i++) t *= p;
				r = Math.Max(r, t);
			}
			return r;
		}
		else
		{
			return a;
		}
	}

	static long[] Factorize(long n)
	{
		var r = new List<long>();
		for (long x = 2; x * x <= n && n > 1; ++x) while (n % x == 0) { r.Add(x); n /= x; }
		if (n > 1) r.Add(n);
		return r.ToArray();
	}
}
