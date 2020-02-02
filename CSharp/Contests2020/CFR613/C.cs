using System;

class C
{
	static void Main()
	{
		var x = long.Parse(Console.ReadLine());

		long a = 0, b = 0;
		for (long i = 1; ; i++)
		{
			var q = Math.DivRem(x, i, out var rem);
			if (q < i) break;
			if (rem != 0) continue;
			if (Lcm(i, q) != x) continue;

			a = i; b = q;
		}
		Console.WriteLine($"{a} {b}");
	}

	static long Gcd(long x, long y) { for (long r; (r = x % y) > 0; x = y, y = r) ; return y; }
	static long Lcm(long x, long y) => x / Gcd(x, y) * y;
}
