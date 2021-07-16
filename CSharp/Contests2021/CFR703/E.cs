using System;
using System.Collections.Generic;
using System.Linq;
using Bang.Graphs.Int.Spp;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main()
	{
		var (n, m) = Read2();
		var es = Array.ConvertAll(new bool[m], _ => (Edge)Read());

		var map = new WeightedMap(n + 1, es, false);

		var id = n;
		var idMap = new int[n + 1, 51];
		var idMap_r = new List<(int v, long w)>(Enumerable.Range(0, n + 1).Select(i => (i, 0L)));

		void InitId(int v, long w)
		{
			if (idMap[v, w] != 0) return;
			idMap[v, w] = ++id;
			idMap_r.Add((v, w));
		}

		foreach (var (v, u, w) in es)
		{
			InitId(v, w);
			InitId(u, w);
		}

		// 辺を静的に構築すると MLE。
		var r = ShortestPathCore.Dijkstra(id + 1, v =>
		{
			if (v <= n)
			{
				return Array.ConvertAll(map[v], e => new Edge(v, idMap[e.To, e.Cost], 0));
			}
			else
			{
				var (v0, w) = idMap_r[v];
				return Array.ConvertAll(map[v0], e => new Edge(v, e.To, (w + e.Cost) * (w + e.Cost)));
			}
		}, 1);

		Console.WriteLine(string.Join(" ", Enumerable.Range(1, n).Select(v => r.GetCost(v))));
	}
}
