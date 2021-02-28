using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;

class E
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();
		var b = Read();

		var max = Min(a[0], b[1]) + Min(a[1], b[2]) + Min(a[2], b[0]);

		var dg = new List<long[]>();
		var sv = 6;
		var ev = 7;
		for (long i = 0; i < 3; i++)
		{
			dg.Add(new[] { sv, i, a[i] });
			dg.Add(new[] { 3 + i, ev, b[i] });
		}
		dg.Add(new[] { 0L, 3, Min(a[0], b[0]) });
		dg.Add(new[] { 1L, 4, Min(a[1], b[1]) });
		dg.Add(new[] { 2L, 5, Min(a[2], b[2]) });
		dg.Add(new[] { 0L, 5, Min(a[0], b[2]) });
		dg.Add(new[] { 1L, 3, Min(a[1], b[0]) });
		dg.Add(new[] { 2L, 4, Min(a[2], b[1]) });

		var min = n - MaxFlow(ev, sv, ev, dg.ToArray());
		Console.WriteLine($"{min} {max}");
	}

	// dg: { from, to, capacity }
	static long MaxFlow(int n, int sv, int ev, long[][] dg)
	{
		var map = Array.ConvertAll(new int[n + 1], _ => new List<long[]>());
		foreach (var e in dg)
		{
			map[e[0]].Add(new[] { e[0], e[1], e[2], map[e[1]].Count });
			map[e[1]].Add(new[] { e[1], e[0], 0, map[e[0]].Count - 1 });
		}

		long Bfs()
		{
			var from = new long[n + 1][];
			var minFlow = new long[n + 1];
			Array.Fill(minFlow, long.MaxValue);
			var q = new Queue<long>();
			q.Enqueue(sv);

			while (q.TryDequeue(out var v))
			{
				if (v == ev) break;
				foreach (var e in map[v])
				{
					if (from[e[1]] != null || e[2] == 0) continue;
					from[e[1]] = e;
					minFlow[e[1]] = Math.Min(minFlow[v], e[2]);
					q.Enqueue(e[1]);
				}
			}

			if (from[ev] == null) return 0;
			for (long v = ev; v != sv; v = from[v][0])
			{
				var e = from[v];
				e[2] -= minFlow[ev];
				map[e[1]][(int)e[3]][2] += minFlow[ev];
			}
			return minFlow[ev];
		}

		long M = 0, t;
		while ((t = Bfs()) > 0) M += t;
		return M;
	}
}
