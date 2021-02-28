using System;
using System.Linq;

class D
{
	static long[] Read() => Console.ReadLine().Split().Select(long.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var h = Read();
		long a = h[0], m = h[1];
		return Totient(m / Gcd(a, m));
	}

	static long Gcd(long x, long y) { for (long r; (r = x % y) > 0; x = y, y = r) ; return y; }

	static long Totient(long n)
	{
		var r = n;
		for (long x = 2; x * x <= n && n > 1; ++x)
			if (n % x == 0)
			{
				r = r / x * (x - 1);
				while ((n /= x) % x == 0) ;
			}
		if (n > 1) r = r / n * (n - 1);
		return r;
	}
}
