using System;
using System.Collections.Generic;
using System.Linq;
using Bang.Graphs.Grid.Spp;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static (int u, int v, int w) Read3() { var a = Read(); return (a[0], a[1], a[2]); }
	static void Main()
	{
		var (n, m) = Read2();
		var es = Array.ConvertAll(new bool[m], _ => Read3());

		var map = new WeightedMap(n + 1, 51);
		foreach (var (u, v, w) in es)
		{
			map.AddEdge((u, 0), (v, w), 0, true);
			map.AddEdge((v, 0), (u, w), 0, true);

			for (int k = 1; k <= 50; k++)
			{
				var w2 = (k + w) * (k + w);
				map.AddEdge((u, k), (v, 0), w2, true);
				map.AddEdge((v, k), (u, 0), w2, true);
			}
		}

		var r = map.Dijkstra((1, 0), (-1, -1));
		Console.WriteLine(string.Join(" ", Enumerable.Range(1, n).Select(v => r.GetCost((v, 0)))));
	}
}
