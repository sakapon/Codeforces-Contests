using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Array.ConvertAll(new bool[n], _ => Read());

		var id = n;
		var salary = new int[100000];
		var es = new List<(int i, int j)>();

		for (int i = 0; i < n; i++)
			salary[i + 1] = a[i][i];

		var parent = Enumerable.Range(0, 100000).ToArray();
		var root = Enumerable.Range(0, 100000).ToArray();
		// Data: Root ID
		var uf = new UF<int>(n + 1, (x, y) =>
		{
			if (salary[x] > 0 && salary[y] > 0)
				return ++id;
			else
				return salary[x] == 0 ? x : y;
		},
		root.ToArray());

		var rn = Enumerable.Range(0, n).ToArray();
		var q =
			from i in rn
			from j in rn
			where i < j
			select (i: i + 1, j: j + 1, v: a[i][j]);
		var gs = q.GroupBy(t => t.v).OrderBy(g => g.Key);

		foreach (var g in gs)
		{
			var pairs = g.ToArray();
			foreach (var (i, j, _) in pairs)
			{
				uf.Unite(i, j);
			}
			foreach (var (i, j, _) in pairs)
			{
				var p = uf.GetValue(i);
				salary[p] = g.Key;

				parent[root[i]] = p;
				parent[root[j]] = p;
				root[root[i]] = p;
				root[root[j]] = p;
				root[i] = p;
				root[j] = p;
			}
		}

		Console.WriteLine(id);
		Console.WriteLine(string.Join(" ", salary.Skip(1).Take(id)));
		Console.WriteLine(id);
		Console.WriteLine(string.Join("\n", Enumerable.Range(1, id - 1).Select(i => $"{i} {parent[i]}")));
	}
}

class UF
{
	int[] p, sizes;
	public int GroupsCount;
	public UF(int n)
	{
		p = Enumerable.Range(0, n).ToArray();
		sizes = Array.ConvertAll(p, _ => 1);
		GroupsCount = n;
	}

	public int GetRoot(int x) => p[x] == x ? x : p[x] = GetRoot(p[x]);
	public int GetSize(int x) => sizes[GetRoot(x)];

	public bool AreUnited(int x, int y) => GetRoot(x) == GetRoot(y);
	public bool Unite(int x, int y)
	{
		if ((x = GetRoot(x)) == (y = GetRoot(y))) return false;

		// 要素数が大きいほうのグループにマージします。
		if (sizes[x] < sizes[y]) Merge(y, x);
		else Merge(x, y);
		return true;
	}
	protected virtual void Merge(int x, int y)
	{
		p[y] = x;
		sizes[x] += sizes[y];
		--GroupsCount;
	}
	public int[][] ToGroups() => Enumerable.Range(0, p.Length).GroupBy(GetRoot).Select(g => g.ToArray()).ToArray();
}

class UF<T> : UF
{
	T[] a;
	// (parent, child) => result
	Func<T, T, T> MergeData;
	public UF(int n, Func<T, T, T> merge, T[] a0) : base(n)
	{
		a = a0;
		MergeData = merge;
	}

	public T GetValue(int x) => a[GetRoot(x)];
	protected override void Merge(int x, int y)
	{
		base.Merge(x, y);
		a[x] = MergeData(a[x], a[y]);
	}
}
