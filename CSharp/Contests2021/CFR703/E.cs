using System;
using System.Collections.Generic;
using System.Linq;
using Bang.Graphs.Int.Spp;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static (int, int, int) Read3() { var a = Read(); return (a[0], a[1], a[2]); }
	static void Main()
	{
		var (n, m) = Read2();
		var es = Array.ConvertAll(new bool[m], _ => Read3());

		var id = n;
		var es2 = new List<Edge>();
		var used = new int[n + 1, 51];

		int GetId(int v, int w)
		{
			if (used[v, w] != 0) return used[v, w];
			return used[v, w] = ++id;
		}

		foreach (var (u, v, w) in es)
		{
			es2.Add(new Edge(u, GetId(v, w), 0));
			es2.Add(new Edge(v, GetId(u, w), 0));
		}

		foreach (var (u, v, w) in es)
		{
			for (int j = 1; j <= 50; j++)
			{
				var w2 = (j + w) * (j + w);
				if (used[u, j] != 0) es2.Add(new Edge(GetId(u, j), v, w2));
				if (used[v, j] != 0) es2.Add(new Edge(GetId(v, j), u, w2));
			}
		}

		var map = new WeightedMap(id + 1, es2.ToArray(), true);
		var r = map.Dijkstra(1);
		Console.WriteLine(string.Join(" ", Enumerable.Range(1, n).Select(v => r.GetCost(v))));
	}
}
