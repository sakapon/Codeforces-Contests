using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static (long, long, long) Read3L() { var a = ReadL(); return (a[0], a[1], a[2]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var (n, m, k) = ((int, int, long))Read3L();
		var a = Read();
		var b = Read();

		if (n > m)
		{
			(n, m) = (m, n);
			(a, b) = (b, a);
		}

		if (m % n == 0)
		{
			var days = new List<int>();
			for (int i = 0; i < m; i++)
				if (a[i % n] == b[i])
					days.Add(i);

			var d = m - days.Count;
			var turn = Math.DivRem(k, d, out k);
			if (k == 0)
			{
				turn--;
				k = d;
			}

			// sentinel
			days.Add(m);
			for (int i = 0; i < days.Count; i++)
				if (k + i - 1 < days[i])
					return m * turn + k + i;
		}
		else if (Gcd(n, m) == 1)
		{
			var max_c = 2 * Math.Max(n, m);
			var oa = ToOrder(a, max_c);
			var ob = ToOrder(b, max_c);

			var days = new List<long>();
			for (int c = 1; c <= max_c; c++)
			{
				if (oa[c] == -1 || ob[c] == -1) continue;

				var index = Crt(n, m, oa[c], ob[c]);
				days.Add(index);
			}
			days.Sort();

			var nm = (long)n * m;
			var d = nm - days.Count;
			var turn = Math.DivRem(k, d, out k);
			if (k == 0)
			{
				turn--;
				k = d;
			}

			// sentinel
			days.Add(nm);
			for (int i = 0; i < days.Count; i++)
				if (k + i - 1 < days[i])
					return nm * turn + k + i;
		}
		else
		{
			var g = Gcd(n, m);
			var nm = Lcm((long)n, m);

			var max_c = 2 * Math.Max(n, m);
			var oa = ToOrder(a, max_c);
			var ob = ToOrder(b, max_c);

			var days = new List<long>();
			for (int c = 1; c <= max_c; c++)
			{
				if (oa[c] == -1 || ob[c] == -1) continue;

				if (oa[c] % g == ob[c] % g)
				{
					var index = Crt(n / g, m / g, oa[c] / g, ob[c] / g);
					days.Add(index * g + oa[c] % g);
				}
			}
			days.Sort();

			var d = nm - days.Count;
			var turn = Math.DivRem(k, d, out k);
			if (k == 0)
			{
				turn--;
				k = d;
			}

			// sentinel
			days.Add(nm);
			for (int i = 0; i < days.Count; i++)
				if (k + i - 1 < days[i])
					return nm * turn + k + i;
		}

		throw new InvalidOperationException();
	}

	static int[] ToOrder(int[] a, int max)
	{
		var o = Array.ConvertAll(new bool[max + 1], _ => -1);
		for (int i = 0; i < a.Length; ++i) o[a[i]] = i;
		return o;
	}

	static int Gcd(int a, int b) { for (int r; (r = a % b) > 0; a = b, b = r) ; return b; }
	static int Lcm(int a, int b) => a / Gcd(a, b) * b;

	static long Gcd(long a, long b) { for (long r; (r = a % b) > 0; a = b, b = r) ; return b; }
	static long Lcm(long a, long b) => a / Gcd(a, b) * b;

	// ax + by = 1 の解 (x, y)
	// 前提: a と b は互いに素。
	// ax + by = GCD(a, b) の解を求める場合、予め GCD(a, b) で割ってからこの関数を利用します。
	static long[] ExtendedEuclid(long a, long b)
	{
		if (b == 1) return new[] { 1, 1 - a };
		long r;
		var q = Math.DivRem(a, b, out r);
		var t = ExtendedEuclid(b, r);
		return new[] { t[1], t[0] - q * t[1] };
	}

	// a mod m かつ b mod n である値 (mod mn で唯一)
	// 前提: m と n は互いに素。
	static long Crt(long m, long n, long a, long b)
	{
		var v = ExtendedEuclid(m, n);
		var r = a * n * v[1] + b * m * v[0];
		return (r %= m * n) < 0 ? r + m * n : r;
	}
}
