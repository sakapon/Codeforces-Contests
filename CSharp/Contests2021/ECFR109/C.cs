using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	//static void Main() => Console.WriteLine(Solve());
	//static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, m) = Read2();
		var xs = Read();
		var lrs = Console.ReadLine().Split();

		var ps = Enumerable.Range(0, n).Select(i => (i, x: xs[i], isL: lrs[i][0] == 'L')).OrderBy(_ => _.x).ToArray();
		var r = Array.ConvertAll(new int[n], _ => -1);

		ForParity(ps.Where(_ => _.x % 2 == 0).ToArray(), m, r);
		ForParity(ps.Where(_ => _.x % 2 == 1).ToArray(), m, r);

		return string.Join(" ", r);
	}

	static void ForParity((int i, int x, bool isL)[] ps, int m, int[] r)
	{
		var q = new Stack<(int i, int x, bool isL)>();

		foreach (var p in ps)
		{
			var (i, x, isL) = p;

			if (q.Count == 0 || !isL)
			{
				q.Push(p);
			}
			else
			{
				var (j, x0, isL2) = q.Pop();
				if (isL2)
				{
					// LL
					var t = (x + x0) / 2;
					r[i] = t;
					r[j] = t;
				}
				else
				{
					// RL
					var t = (x - x0) / 2;
					r[i] = t;
					r[j] = t;
				}
			}
		}

		while (q.Count >= 2)
		{
			var (j, x2, _) = q.Pop();
			var (i1, x1, isL1) = q.Pop();

			if (isL1)
			{
				// LR
				var t = m - (x2 + x1) / 2 + x1;
				r[i1] = t;
				r[j] = t;
			}
			else
			{
				// RR
				var t = m - (x2 + x1) / 2;
				r[i1] = t;
				r[j] = t;
			}
		}
	}
}
