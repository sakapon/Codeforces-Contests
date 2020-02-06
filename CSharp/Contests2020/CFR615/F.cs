﻿using System;
using System.Collections.Generic;
using System.Linq;

class F
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		map = UndirectedMap(n, new int[n - 1].Select(_ => Read()).ToArray());

		parents = new int[n + 1];
		var a = Dfs(1, 0).p;
		parents[a] = 0;
		var (b, ab) = Dfs(a, 0);

		var cd = (p: b, d: 0);
		for (int i = b; i != a; i = parents[i])
		{
			var pd = Dfs2(parents[i], i);
			if (pd.d > cd.d) cd = pd;
		}
		var c = cd.p;
		if (c == b) c = parents[c];

		Console.WriteLine(ab + cd.d);
		Console.WriteLine($"{a} {b} {c}");
	}

	static List<int>[] map;
	static int[] parents;

	static (int p, int d) Dfs(int p, int p0)
	{
		var r = (p, d: 0);
		foreach (var p2 in map[p])
		{
			if (p2 == p0) continue;
			parents[p2] = p;
			var pd = Dfs(p2, p);
			if (pd.d >= r.d) r = (pd.p, pd.d + 1);
		}
		return r;
	}

	static (int p, int d) Dfs2(int p, int p0)
	{
		var r = (p, d: 0);
		foreach (var p2 in map[p])
		{
			if (p2 == p0) continue;
			if (p2 == parents[p]) continue;
			var pd = Dfs2(p2, p);
			if (pd.d >= r.d) r = (pd.p, pd.d + 1);
		}
		return r;
	}

	static List<int>[] UndirectedMap(int n, int[][] rs)
	{
		var map = Array.ConvertAll(new int[n + 1], _ => new List<int>());
		foreach (var r in rs)
		{
			map[r[0]].Add(r[1]);
			map[r[1]].Add(r[0]);
		}
		return map;
	}
}
