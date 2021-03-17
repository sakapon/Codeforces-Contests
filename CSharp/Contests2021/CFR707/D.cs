using System;
using System.Collections.Generic;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static (long, long, long) Read3L() { var a = ReadL(); return (a[0], a[1], a[2]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var (n, m, k) = Read3L();
		var a = Read();
		var b = Read();

		var g = Gcd(n, m);
		var l = Lcm(n, m);

		var cmax = 2 * (int)Math.Max(n, m);
		var oa = ToOrderMap(a, cmax);
		var ob = ToOrderMap(b, cmax);

		var days = new List<long>();
		for (int c = 1; c <= cmax; c++)
		{
			if (oa[c] == -1) continue;
			if (ob[c] == -1) continue;
			if (oa[c] % g != ob[c] % g) continue;

			var index = Crt2(n, m, oa[c], ob[c], g);
			days.Add(index);
		}
		days.Sort();

		return KthFalseDay(k - 1, l, days.ToArray()) + 1;
	}

	static int[] ToOrderMap(int[] a, int max)
	{
		var o = Array.ConvertAll(new bool[max + 1], _ => -1);
		for (int i = 0; i < a.Length; ++i) o[a[i]] = i;
		return o;
	}

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

	// a mod m かつ b mod n である値 (mod lcm(m, n) で唯一)
	static long Crt2(long m, long n, long a, long b, long g)
	{
		// 繰り返し呼び出す場合、ここを先に判定します。
		//var g = Gcd(m, n);
		//if (a % g != b % g) return -1;

		// 0 <= r0 < lcm(m, n) / gcd(m, n)
		var r0 = Crt(m / g, n / g, a / g, b / g);
		return r0 * g + a % g;
	}

	// k 回目に false となる日を求めます。
	// k, day: 0-indexed
	// 0 <= trueDay < period
	static long KthFalseDay(long k, long period, long[] trueDays)
	{
		var turns = Math.DivRem(k, period - trueDays.Length, out k);
		for (int i = 0; i < trueDays.Length; ++i)
			if (k + i < trueDays[i])
				return turns * period + k + i;
		return turns * period + k + trueDays.Length;
	}
}
