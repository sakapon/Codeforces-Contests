using System;
using System.Collections.Generic;
using System.Linq;

class G
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, m) = Read2();
		var a = Read();
		var x = Read();

		var s = a.Sum();

		var tsum = 0L;
		var steps = new List<(int i, long v)> { (-1, 0) };

		for (int i = 0; i < n; i++)
		{
			tsum += a[i];
			if (tsum > steps.Last().v)
			{
				steps.Add((i, tsum));
			}
		}
		steps.RemoveAt(0);
		if (steps.Count == 0) return string.Join(" ", Enumerable.Repeat(-1, m));

		var r = new long[m];

		if (s <= 0)
		{
			for (int j = 0; j < m; j++)
			{
				var si = First(0, steps.Count, i => steps[i].v >= x[j]);
				r[j] = si == steps.Count ? -1 : steps[si].i;
			}
		}
		else
		{
			for (int j = 0; j < m; j++)
			{
				var d = x[j] - steps[^1].v;
				var k = (d + s - 1) / s;
				r[j] = k * n;

				x[j] -= (int)(k * s);
				var si = First(0, steps.Count, i => steps[i].v >= x[j]);
				r[j] += steps[si].i;
			}
		}

		return string.Join(" ", r);
	}

	static int First(int l, int r, Func<int, bool> f)
	{
		int m;
		while (l < r) if (f(m = l + (r - l - 1) / 2)) r = m; else l = m + 1;
		return r;
	}
}
