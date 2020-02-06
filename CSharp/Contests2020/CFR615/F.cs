using System;
using System.Collections.Generic;
using System.Linq;

class F
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		n = int.Parse(Console.ReadLine());
		map = UndirectedMap(n, new int[n - 1].Select(_ => Read()).ToArray());

		parents = new int[n + 1];
		u = new int[n + 1];
		var a = Bfs(1).p;
		parents[a] = 0;
		var (b, ab) = Bfs(a);

		var cd = (p: b, d: 0);
		for (int i = b; i != a; i = parents[i])
		{
			var p = parents[i];
			foreach (var p2 in map[p])
			{
				if (p2 == i) continue;
				if (p2 == parents[p]) continue;
				var (p3, d3) = Bfs(p2);
				if (d3 >= cd.d) cd = (p3, d3 + 1);
			}
		}
		var c = cd.p == b ? parents[b] : cd.p;

		Console.WriteLine(ab + cd.d);
		Console.WriteLine($"{a} {b} {c}");
	}

	static int n;
	static List<int>[] map;
	static int[] parents;
	static int[] u;

	static (int p, int d) Bfs(int sp)
	{
		u[sp] = 0;
		var r = (sp, d: 0);
		var q = new Queue<int>();
		q.Enqueue(sp);

		while (q.Any())
		{
			var p = q.Dequeue();
			foreach (var p2 in map[p])
			{
				if (p2 == parents[p]) continue;
				parents[p2] = p;
				u[p2] = u[p] + 1;
				r = (p2, u[p2]);
				q.Enqueue(p2);
			}
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
