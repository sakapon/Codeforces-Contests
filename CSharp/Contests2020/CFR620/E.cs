using System;
using System.Collections.Generic;
using System.Linq;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static (int, int, int, int, int) Read5() { var a = Read(); return (a[0], a[1], a[2], a[3], a[4]); }
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var es = Array.ConvertAll(new bool[n - 1], _ => Read());
		var qc = int.Parse(Console.ReadLine());
		var qs = Array.ConvertAll(new bool[qc], _ => Read5());

		var lca = new DoublingLca(n + 1, 1, es);

		Console.WriteLine(string.Join("\n", qs
			.Select(q =>
			{
				var (x, y, a, b, k) = q;
				var ab = lca.GetDistance(a, b);
				if (ab <= k && ab % 2 == k % 2) return true;

				ab = Math.Min(lca.GetDistance(a, x) + lca.GetDistance(y, b), lca.GetDistance(a, y) + lca.GetDistance(x, b)) + 1;
				return ab <= k && ab % 2 == k % 2;
			})
			.Select(b => b ? "YES" : "NO")));
	}
}

class DoublingLca
{
	static List<int>[] ToMap(int n, int[][] es, bool directed)
	{
		var map = Array.ConvertAll(new bool[n], _ => new List<int>());
		foreach (var e in es)
		{
			map[e[0]].Add(e[1]);
			if (!directed) map[e[1]].Add(e[0]);
		}
		return map;
	}

	List<int>[] map;
	int[] depths;
	int[][] parents;

	public DoublingLca(int n, int root, List<int>[] _map)
	{
		map = _map;
		depths = new int[n];
		parents = new int[n][];

		var t = 1;
		var n2l = new List<int> { t };
		while ((t <<= 1) <= n) n2l.Add(t);
		var n2 = n2l.ToArray();

		parents[root] = new int[0];
		var path = new List<int> { root };
		Dfs(root, -1);

		void Dfs(int v, int pv)
		{
			var p = Array.ConvertAll(n2, i => i <= path.Count ? path[path.Count - i] : -1);

			foreach (var nv in map[v])
			{
				if (nv == pv) continue;

				depths[nv] = depths[v] + 1;
				parents[nv] = p;
				path.Add(nv);
				Dfs(nv, v);
				path.RemoveAt(path.Count - 1);
			}
		}
	}

	public DoublingLca(int n, int root, int[][] es) : this(n, root, ToMap(n, es, false)) { }

	public int GetAncestor(int v, int depth)
	{
		var delta = depths[v] - depth;
		if (delta == 0) return v;
		if (delta < 0) throw new InvalidOperationException();

		for (int i = 0; ; i++, delta >>= 1)
			if (delta == 1) return GetAncestor(parents[v][i], depth);
	}

	public int GetLca(int v1, int v2)
	{
		if (v1 == v2) return v1;

		if (depths[v1] != depths[v2])
		{
			var md = Math.Min(depths[v1], depths[v2]);
			return GetLca(GetAncestor(v1, md), GetAncestor(v2, md));
		}

		if (parents[v1][0] == parents[v2][0]) return parents[v1][0];
		for (int i = 1; ; i++)
			if (parents[v1][i] == parents[v2][i]) return GetLca(parents[v1][i - 1], parents[v2][i - 1]);
	}

	public int GetDistance(int v1, int v2)
	{
		var lca = GetLca(v1, v2);
		return depths[v1] + depths[v2] - 2 * depths[lca];
	}
}
