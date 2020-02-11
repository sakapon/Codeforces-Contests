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

		var gcd = Gcd(a, m);

		var divs = Divisors(m);
		var d = new Dictionary<long, long>();

		for (int i = divs.Length - 1; i >= 0; i--)
		{
			d[divs[i]] = m / divs[i];

			for (int j = i + 1; j < divs.Length; j++)
			{
				if (divs[j] % divs[i] == 0) d[divs[i]] -= d[divs[j]];
			}
		}

		return d[gcd];
	}

	static long Gcd(long x, long y) { for (long r; (r = x % y) > 0; x = y, y = r) ; return y; }

	static long[] Divisors(long v)
	{
		var d = new List<long>();
		var c = 0;
		for (long i = 1, j, rv = (long)Math.Sqrt(v); i <= rv; i++)
			if (v % i == 0)
			{
				d.Insert(c, i);
				if ((j = v / i) != i) d.Insert(++c, j);
			}
		return d.ToArray();
	}
}
