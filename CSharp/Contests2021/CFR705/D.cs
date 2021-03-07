using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static (long i, long x) Read2L() { var a = ReadL(); return (a[0], a[1]); }
	static void Main()
	{
		var (n, qc) = Read2();
		var a = ReadL();
		var qs = Array.ConvertAll(new bool[qc], _ => Read2L());

		var fmaps = Array.ConvertAll(a, v =>
		{
			var map = new Map<long, int>();
			foreach (var p in Factorize(v))
				map[p]++;
			return map;
		});
		// final state
		foreach (var (i, x) in qs)
			foreach (var p in Factorize(x))
				fmaps[i - 1][p]++;

		// final GCD
		var gcdMap = new Map<long, int>();
		foreach (var (k, v) in fmaps[0])
			gcdMap[k] = v;
		for (int i = 1; i < n; i++)
		{
			var keys = gcdMap.Keys.ToArray();
			foreach (var k in keys)
			{
				var v = Math.Min(gcdMap[k], fmaps[i][k]);
				if (v > 0) gcdMap[k] = v;
				else gcdMap.Remove(k);
			}
		}
		var gcd = 1L;
		foreach (var (k, v) in gcdMap)
		{
			gcd *= MPow(k, v);
			gcd %= M;
		}

		var r = new List<long> { gcd };
		Array.Reverse(qs);
		foreach (var (i, x) in qs)
		{
			var nv = r.Last();
			foreach (var p in Factorize(x))
			{
				fmaps[i - 1][p]--;
				if (fmaps[i - 1][p] < gcdMap[p])
				{
					gcdMap[p]--;
					nv *= MInv(p);
					nv %= M;
				}
			}
			r.Add(nv);
		}

		r.RemoveAt(r.Count - 1);
		r.Reverse();
		Console.WriteLine(string.Join("\n", r));
	}

	const long M = 1000000007;
	static long MPow(long b, long i)
	{
		long r = 1;
		for (; i != 0; b = b * b % M, i >>= 1) if ((i & 1) != 0) r = r * b % M;
		return r;
	}
	static long MInv(long x) => MPow(x, M - 2);

	static long Gcd(long a, long b) { for (long r; (r = a % b) > 0; a = b, b = r) ; return b; }
	static long Lcm(long a, long b) => a / Gcd(a, b) * b;

	static long[] Factorize(long n)
	{
		var r = new List<long>();
		for (long x = 2; x * x <= n && n > 1; ++x) while (n % x == 0) { r.Add(x); n /= x; }
		if (n > 1) r.Add(n);
		return r.ToArray();
	}
}

class Map<TK, TV> : Dictionary<TK, TV>
{
	TV _v0;
	public Map(TV v0 = default(TV)) { _v0 = v0; }

	public new TV this[TK key]
	{
		get { return ContainsKey(key) ? base[key] : _v0; }
		set { base[key] = value; }
	}
}
