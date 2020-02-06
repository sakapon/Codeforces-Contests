using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		pcs = new int[n].Select(_ => Read()).ToArray();
		map = GetDirectedMap(n, pcs.Select((x, i) => new[] { x[0], i + 1 }).ToArray());

		try
		{
			var l = Dfs(map[0][0], 0);
			Console.WriteLine("YES");
			Console.WriteLine(string.Join(" ", l.Select((p, i) => (p: p, a: i + 1)).OrderBy(_ => _.p).Select(_ => _.a)));
		}
		catch (Exception)
		{
			Console.WriteLine("NO");
		}
	}

	static int[][] pcs;
	static List<int>[] map;

	static List<int> Dfs(int p, int p0)
	{
		List<int> l = null;
		foreach (var p2 in map[p])
		{
			if (p2 == p0) continue;
			if (l == null) l = Dfs(p2, p);
			else l.AddRange(Dfs(p2, p));
		}

		if (l == null) l = new List<int>();
		l.Insert(pcs[p - 1][1], p);
		return l;
	}

	static List<int>[] GetDirectedMap(int n, int[][] rs)
	{
		var map = Array.ConvertAll(new int[n + 1], _ => new List<int>());
		foreach (var r in rs)
			map[r[0]].Add(r[1]);
		return map;
	}
}
