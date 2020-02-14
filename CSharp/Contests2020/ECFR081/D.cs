using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static long[] Read() => Console.ReadLine().Split().Select(long.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var h = Read();
		long a = h[0], m = h[1];

		m /= Gcd(a, m);
		return Factorize(m).Distinct().Aggregate(m, (x, p) => x / p * (p - 1));
	}

	static long Gcd(long x, long y) { for (long r; (r = x % y) > 0; x = y, y = r) ; return y; }

	static long[] Factorize(long n)
	{
		long rn = (long)Math.Ceiling(Math.Sqrt(n)), x = 2;
		var r = new List<long>();
		while (n % x == 0) { r.Add(x); n /= x; }
		for (x++; x <= rn && n > 1; x += 2)
			while (n % x == 0) { r.Add(x); n /= x; }
		if (n > 1) r.Add(n);
		return r.ToArray();
	}
}
