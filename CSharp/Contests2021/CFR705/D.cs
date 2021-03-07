using System;
using System.Collections.Generic;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main()
	{
		Console.SetOut(new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
		var (n, qc) = Read2();
		var a = Read();
		var qs = Array.ConvertAll(new bool[qc], _ => Read2());

		var pmaps = Array.ConvertAll(a, v => new Map<long, int>());
		var counts = new Map<(long, int), int>();
		var gcd = 1L;

		void Multiply(long i, long x)
		{
			foreach (var p in Factorize(x))
			{
				var t = (p, ++pmaps[i][p]);
				if (++counts[t] == n)
					gcd = gcd * p % M;
			}
		}

		for (int i = 0; i < n; i++)
		{
			Multiply(i, a[i]);
		}
		foreach (var (i, x) in qs)
		{
			Multiply(i - 1, x);
			Console.WriteLine(gcd);
		}
		Console.Out.Flush();
	}

	const long M = 1000000007;

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
