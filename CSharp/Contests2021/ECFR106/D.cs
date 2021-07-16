﻿using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int, int) Read3() { var a = Read(); return (a[0], a[1], a[2]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (c, d, x) = Read3();

		var r = 0L;
		foreach (var div in Divisors(x))
		{
			var q = Math.DivRem(div + d, c, out var rem);
			if (rem != 0) continue;
			r += 1L << pt[q];
		}
		return r;
	}

	static long[] Divisors(long n)
	{
		var r = new List<long>();
		for (long x = 1; x * x <= n; ++x) if (n % x == 0) r.Add(x);
		var i = r.Count - 1;
		if (r[i] * r[i] == n) --i;
		for (; i >= 0; --i) r.Add(n / r[i]);
		return r.ToArray();
	}

	static long[] Factorize(long n)
	{
		var r = new List<long>();
		for (long x = 2; x * x <= n && n > 1; ++x) while (n % x == 0) { r.Add(x); n /= x; }
		if (n > 1) r.Add(n);
		return r.ToArray();
	}

	static int[] pt = GetPrimeTypes(20000000);

	// n 以下のすべての数に対する、素因数の種類の数 O(n)?
	static int[] GetPrimeTypes(int n)
	{
		var t = new int[n + 1];
		for (int p = 2; p <= n; ++p) if (t[p] == 0) for (int x = p; x <= n; x += p) ++t[x];
		return t;
	}
}
