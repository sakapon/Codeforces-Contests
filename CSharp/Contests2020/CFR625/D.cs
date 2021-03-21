using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var (n, m) = Read2();
		var map = ReadUnweightedMap(n + 1, m, true);
		var k = int.Parse(Console.ReadLine());
		var p = Read();

		var (costs, dup) = Bfs(n + 1, v => map[v], p.Last(), -1);
		var (min, max) = (0, 0);

		for (int j = 0; j < k - 1; j++)
		{
			if (costs[p[j]] - costs[p[j + 1]] > 1) throw new InvalidOperationException();

			var far = costs[p[j]] - costs[p[j + 1]] < 1;
			if (far)
			{
				min++;
				max++;
			}
			else
			{
				if (dup[p[j]]) max++;
			}
		}

		return $"{min} {max}";
	}

	public static Edge[] ReadRevEdges(int count)
	{
		return Array.ConvertAll(new bool[count], _ => ((Edge)Read()).Reverse());
	}

	public static UnweightedMap ReadUnweightedMap(int vertexesCount, int edgesCount, bool directed)
	{
		return new UnweightedMap(vertexesCount, ReadRevEdges(edgesCount), directed);
	}

	static (long[], bool[]) Bfs(int n, Func<int, int[]> getNextVertexes, int sv, int ev = -1)
	{
		var costs = Array.ConvertAll(new bool[n], _ => long.MaxValue);
		var dup = new bool[n];
		var q = new Queue<int>();
		costs[sv] = 0;
		q.Enqueue(sv);

		while (q.Count > 0)
		{
			var v = q.Dequeue();
			var nc = costs[v] + 1;

			foreach (var nv in getNextVertexes(v))
			{
				if (costs[nv] < nc) continue;

				if (costs[nv] == nc)
				{
					dup[nv] = true;
				}
				else
				{
					costs[nv] = nc;
					dup[nv] = false;
					if (nv == ev) return (costs, dup);
					q.Enqueue(nv);
				}
			}
		}
		return (costs, dup);
	}
}

public struct Edge
{
	public static Edge Invalid { get; } = new Edge(-1, -1, long.MinValue);

	public int From { get; }
	public int To { get; }
	public long Cost { get; }

	public Edge(int from, int to, long cost = 1) { From = from; To = to; Cost = cost; }
	public void Deconstruct(out int from, out int to) { from = From; to = To; }
	public void Deconstruct(out int from, out int to, out long cost) { from = From; to = To; cost = Cost; }
	public override string ToString() => $"{From} {To} {Cost}";

	public static implicit operator Edge(int[] e) => new Edge(e[0], e[1], e.Length > 2 ? e[2] : 1);
	public static implicit operator Edge(long[] e) => new Edge((int)e[0], (int)e[1], e.Length > 2 ? e[2] : 1);
	public static implicit operator Edge((int from, int to) v) => new Edge(v.from, v.to);
	public static implicit operator Edge((int from, int to, long cost) v) => new Edge(v.from, v.to, v.cost);

	public Edge Reverse() => new Edge(To, From, Cost);
}

public static class GraphConvert
{
	public static void UnweightedEdgesToMap(List<int>[] map, Edge[] edges, bool directed)
	{
		foreach (var e in edges)
		{
			map[e.From].Add(e.To);
			if (!directed) map[e.To].Add(e.From);
		}
	}

	public static void UnweightedEdgesToMap(List<int>[] map, int[][] edges, bool directed)
	{
		foreach (var e in edges)
		{
			map[e[0]].Add(e[1]);
			if (!directed) map[e[1]].Add(e[0]);
		}
	}

	public static void WeightedEdgesToMap(List<Edge>[] map, Edge[] edges, bool directed)
	{
		foreach (var e in edges)
		{
			map[e.From].Add(e);
			if (!directed) map[e.To].Add(e.Reverse());
		}
	}

	public static void WeightedEdgesToMap(List<Edge>[] map, int[][] edges, bool directed)
	{
		foreach (var e0 in edges)
		{
			Edge e = e0;
			map[e.From].Add(e);
			if (!directed) map[e.To].Add(e.Reverse());
		}
	}

	public static List<int>[] UnweightedEdgesToMap(int vertexesCount, Edge[] edges, bool directed)
	{
		var map = Array.ConvertAll(new bool[vertexesCount], _ => new List<int>());
		UnweightedEdgesToMap(map, edges, directed);
		return map;
	}

	public static List<int>[] UnweightedEdgesToMap(int vertexesCount, int[][] edges, bool directed)
	{
		var map = Array.ConvertAll(new bool[vertexesCount], _ => new List<int>());
		UnweightedEdgesToMap(map, edges, directed);
		return map;
	}

	public static List<Edge>[] WeightedEdgesToMap(int vertexesCount, Edge[] edges, bool directed)
	{
		var map = Array.ConvertAll(new bool[vertexesCount], _ => new List<Edge>());
		WeightedEdgesToMap(map, edges, directed);
		return map;
	}

	public static List<Edge>[] WeightedEdgesToMap(int vertexesCount, int[][] edges, bool directed)
	{
		var map = Array.ConvertAll(new bool[vertexesCount], _ => new List<Edge>());
		WeightedEdgesToMap(map, edges, directed);
		return map;
	}
}

public class UnweightedMap
{
	public int VertexesCount { get; }
	List<int>[] map;
	public List<int>[] RawMap => map;
	public int[] this[int vertex] => map[vertex].ToArray();

	public UnweightedMap(int vertexesCount, List<int>[] map)
	{
		VertexesCount = vertexesCount;
		this.map = map;
	}

	public UnweightedMap(int vertexesCount)
	{
		VertexesCount = vertexesCount;
		map = Array.ConvertAll(new bool[vertexesCount], _ => new List<int>());
	}

	public UnweightedMap(int vertexesCount, Edge[] edges, bool directed) : this(vertexesCount)
	{
		AddEdges(edges, directed);
	}

	public UnweightedMap(int vertexesCount, int[][] edges, bool directed) : this(vertexesCount)
	{
		AddEdges(edges, directed);
	}

	public void AddEdges(Edge[] edges, bool directed)
	{
		GraphConvert.UnweightedEdgesToMap(map, edges, directed);
	}

	public void AddEdges(int[][] edges, bool directed)
	{
		GraphConvert.UnweightedEdgesToMap(map, edges, directed);
	}

	public void AddEdge(Edge edge, bool directed)
	{
		map[edge.From].Add(edge.To);
		if (!directed) map[edge.To].Add(edge.From);
	}

	public void AddEdge(int from, int to, bool directed)
	{
		map[from].Add(to);
		if (!directed) map[to].Add(from);
	}
}
