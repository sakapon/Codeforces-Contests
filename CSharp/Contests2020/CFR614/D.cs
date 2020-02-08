using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static long[] Read() => Console.ReadLine().Split().Select(long.Parse).ToArray();
	static void Main()
	{
		var h = Read();
		var z = Read();
		var sp = (x: z[0], y: z[1]);
		var t = z[2];

		var max = 1L << 55;
		var ps = new List<(long x, long y)> { (h[0], h[1]) };
		while (true)
		{
			var (x_, y_) = ps.Last();
			var p = (x: h[2] * x_ + h[4], y: h[3] * y_ + h[5]);
			if (p.x > max || p.y > max) break;
			ps.Add(p);
		}

		var s = new long[ps.Count];
		for (int i = 0; i < ps.Count - 1; i++) s[i + 1] = s[i] + Norm(ps[i], ps[i + 1]);

		var M = 0;
		for (int i = 0; i < ps.Count; i++)
		{
			var t0 = t - Norm(sp, ps[i]);
			if (t0 < 0) continue;

			M = Math.Max(M, Enumerable.Range(0, i).Reverse().TakeWhile(j => s[i] - s[j] <= t0).Count() + 1);
			M = Math.Max(M, Enumerable.Range(i + 1, ps.Count - 1 - i).TakeWhile(j => s[j] - s[i] <= t0).Count() + 1);
		}
		Console.WriteLine(M);
	}

	static long Norm((long x, long y) p, (long x, long y) q) => Math.Abs(q.x - p.x) + Math.Abs(q.y - p.y);
}
