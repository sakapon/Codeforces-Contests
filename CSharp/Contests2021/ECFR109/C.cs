using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, m) = Read2();
		var xs = Read();
		var lrs = Console.ReadLine().Split();

		var ps = Enumerable.Range(0, n).Select(i => (i, x: xs[i], left: lrs[i][0] == 'L')).OrderBy(_ => _.x).ToArray();
		var r = Array.ConvertAll(new int[n], _ => -1);

		ForParity(Array.FindAll(ps, _ => _.x % 2 == 0), m, r);
		ForParity(Array.FindAll(ps, _ => _.x % 2 == 1), m, r);

		return string.Join(" ", r);
	}

	static void ForParity((int, int, bool)[] ps, int m, int[] r)
	{
		var q = new Stack<(int, int, bool)>();

		foreach (var p in ps)
		{
			var (j, x, l) = p;

			if (q.Count == 0 || !l)
			{
				q.Push(p);
			}
			else
			{
				var (i, x0, l0) = q.Pop();

				// LL, RL
				var t = (l0 ? x + x0 : x - x0) / 2;
				r[i] = t;
				r[j] = t;
			}
		}

		while (q.Count >= 2)
		{
			var (j, x, _) = q.Pop();
			var (i, x0, l0) = q.Pop();

			// LR, RR
			var t = m - (l0 ? x - x0 : x + x0) / 2;
			r[i] = t;
			r[j] = t;
		}
	}
}
