using System;
using System.Collections.Generic;
using System.Linq;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int, int, int, int) Read5() { var a = Read(); return (a[0], a[1], a[2], a[3], a[4]); }
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var es = Array.ConvertAll(new bool[n - 1], _ => Read());
		var qc = int.Parse(Console.ReadLine());
		var qs = Array.ConvertAll(new bool[qc], _ => Read5());

		var tree = new Tree(n + 1, 1, es);
		var lca = new BLLca(tree);

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

public class Tree
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

	public int Count { get; }
	public int Root { get; }
	public List<int>[] Map { get; }
	public int[] Depths { get; }
	public int[] Parents { get; }

	public Tree(int n, int root, int[][] ues) : this(n, root, ToMap(n, ues, false)) { }
	public Tree(int n, int root, List<int>[] map)
	{
		Count = n;
		Root = root;
		Map = map;
		Depths = Array.ConvertAll(Map, _ => -1);
		Parents = Array.ConvertAll(Map, _ => -1);

		Depths[root] = 0;
		Dfs(root, -1);

		void Dfs(int v, int pv)
		{
			foreach (var nv in Map[v])
			{
				if (nv == pv) continue;
				Depths[nv] = Depths[v] + 1;
				Parents[nv] = v;
				Dfs(nv, v);
			}
		}
	}
}

public class BLLca
{
	Tree tree;
	// j から 2^i 番目の親
	int[][] parents;

	public BLLca(Tree tree)
	{
		this.tree = tree;
		var n = tree.Count;

		var ln = 0;
		while ((1 << ln) < n) ++ln;
		parents = new int[ln + 1][];
		parents[0] = Array.ConvertAll(tree.Parents, v => v == -1 ? tree.Root : v);

		for (int i = 0; i < ln; ++i)
		{
			parents[i + 1] = new int[n];
			for (int j = 0; j < n; ++j)
				parents[i + 1][j] = parents[i][parents[i][j]];
		}
	}

	public int GetAncestor(int v, int depth)
	{
		var delta = tree.Depths[v] - depth;
		if (delta < 0) throw new ArgumentOutOfRangeException(nameof(depth));
		if (delta == 0) return v;

		for (int i = 0; ; ++i, delta >>= 1)
			if (delta == 1) return GetAncestor(parents[i][v], depth);
	}

	public int GetLca(int v1, int v2)
	{
		var depth = Math.Min(tree.Depths[v1], tree.Depths[v2]);
		v1 = GetAncestor(v1, depth);
		v2 = GetAncestor(v2, depth);
		return GetLcaForLevel(v1, v2);
	}

	int GetLcaForLevel(int v1, int v2)
	{
		if (v1 == v2) return v1;
		for (int i = 0; ; ++i)
			if (parents[i + 1][v1] == parents[i + 1][v2]) return GetLcaForLevel(parents[i][v1], parents[i][v2]);
	}

	public int GetDistance(int v1, int v2)
	{
		var lca = GetLca(v1, v2);
		return tree.Depths[v1] + tree.Depths[v2] - 2 * tree.Depths[lca];
	}
}
