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
		var idMap = new List<(int v, int w)>(Enumerable.Range(0, n + 1).Select(i => (i, 0)));

		var id = n;
		var used = new int[n + 1, 51];

		int GetId(int v, int w)
		{
			if (used[v, w] != 0) return used[v, w];
			idMap.Add((v, w));
			return used[v, w] = ++id;
		}

		foreach (var (u, v, w) in es)
		{
			GetId(u, (int)w);
			GetId(v, (int)w);
		}

		// 辺を静的に構築すると MLE。
		var r = ShortestPathCore.Dijkstra(id + 1, v =>
		{
			if (v <= n)
			{
				return Array.ConvertAll(map[v], e => new Edge(v, used[e.To, e.Cost], 0));
			}
			else
			{
				var (v0, w) = idMap[v];
				return Array.ConvertAll(map[v0], e => new Edge(v, e.To, (w + e.Cost) * (w + e.Cost)));
			}
		}, 1);

		Console.WriteLine(string.Join(" ", Enumerable.Range(1, n).Select(v => r.GetCost(v))));
	}
}
