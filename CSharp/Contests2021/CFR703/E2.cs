using System;
using System.Collections.Generic;
using System.Linq;
using Bang.Graphs.Grid.Spp;

class E2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main()
	{
		var (n, m) = Read2();
		var es = Array.ConvertAll(new bool[m], _ => Read());

		var map = EdgesToMap2(n + 1, es, false);

		// 辺を静的に構築すると MLE。
		var r = ShortestPathCore.Dijkstra(n + 1, 51, v =>
		{
			if (v.j == 0)
			{
				return Array.ConvertAll(map[v.i].ToArray(), e => new Edge(v, (e[1], e[2]), 0));
			}
			else
			{
				return Array.ConvertAll(map[v.i].ToArray(), e => new Edge(v, (e[1], 0), (v.j + e[2]) * (v.j + e[2])));
			}
		}, (1, 0), (-1, -1));

		Console.WriteLine(string.Join(" ", Enumerable.Range(1, n).Select(v => r.GetCost((v, 0)))));
	}

	static List<int[]>[] EdgesToMap2(int n, int[][] es, bool directed)
	{
		var map = Array.ConvertAll(new bool[n], _ => new List<int[]>());
		foreach (var e in es)
		{
			map[e[0]].Add(new[] { e[0], e[1], e[2] });
			if (!directed) map[e[1]].Add(new[] { e[1], e[0], e[2] });
		}
		return map;
	}
}
