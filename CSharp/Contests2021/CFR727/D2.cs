using System;
using System.Collections.Generic;
using System.Linq;

class D2
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static (long a, long b) Read2L() { var a = ReadL(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var ps = Array.ConvertAll(new bool[n], _ => Read2L());

		ps = ps.OrderBy(_ => _.b).ToArray();

		var r = 0L;
		var c = 0L;

		// Two Pointers
		var q = new Queue<int>(Enumerable.Range(0, n).Reverse());

		for (int i = 0; i < n; i++)
		{
			var (a, b) = ps[i];

			while (c < b && q.Count > 0)
			{
				var j = q.Peek();
				Buy2(j, b - c);
				if (ps[j].a == 0) q.Dequeue();
			}

			if (c < b) Buy2(i, b - c);
			Buy1(i);
		}

		void Buy1(int i)
		{
			var (a, b) = ps[i];

			r += a;
			c += a;
			ps[i] = (0, b);
		}

		void Buy2(int i, long dMax)
		{
			var (a, b) = ps[i];
			var d = Math.Min(a, dMax);

			r += 2 * d;
			c += d;
			ps[i] = (a - d, b);
		}

		return r;
	}
}
