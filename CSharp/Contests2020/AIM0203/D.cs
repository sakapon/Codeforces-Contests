using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var h = Read();
		var n = h[0];
		var map = UndirectedMap(n, new int[h[1]].Select(_ => Read()).ToArray());

		var u = Enumerable.Repeat(long.MaxValue, n + 1).ToArray();
		var q = new Queue<int>();
		u[1] = 0;
		q.Enqueue(1);

		while (q.Any())
		{
			var p = q.Dequeue();
			foreach (var r in map[p])
			{
				var v = u[p] + r.cost;
				if (v >= u[r.to]) continue;
				u[r.to] = v;
				q.Enqueue(r.to);
			}
		}
		Console.WriteLine(u[n] < long.MaxValue ? u[n] : -1);
	}

	struct R
	{
		public int to, cost;
	}

	static List<R>[] UndirectedMap(int n, int[][] rs)
	{
		var map = Array.ConvertAll(new int[n + 1], _ => new List<R>());
		foreach (var r in rs)
		{
			map[r[0]].Add(new R { to = r[1], cost = r[2] });
			if (r[0] != r[1])
				map[r[1]].Add(new R { to = r[0], cost = r[2] });
		}
		return map;
	}
}
