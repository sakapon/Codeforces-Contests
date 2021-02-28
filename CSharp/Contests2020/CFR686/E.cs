using System;
using System.Collections.Generic;
using System.Linq;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var n = long.Parse(Console.ReadLine());
		var es = Array.ConvertAll(new bool[n], _ => Read());

		var map = Array.ConvertAll(new bool[n + 1], _ => new HashSet<int>());
		foreach (var e in es)
		{
			map[e[0]].Add(e[1]);
			map[e[1]].Add(e[0]);
		}

		var counts = Array.ConvertAll(new bool[n + 1], _ => 1L);
		var q = new Queue<int>();

		for (int v = 1; v <= n; v++)
		{
			if (map[v].Count == 1) q.Enqueue(v);
		}

		while (q.TryDequeue(out var v))
		{
			var nv = map[v].First();
			map[nv].Remove(v);
			counts[nv] += counts[v];
			if (map[nv].Count == 1) q.Enqueue(nv);
		}

		// Either.
		return n * (n - 1) - Enumerable.Range(1, (int)n).Where(v => map[v].Count == 2).Select(v => counts[v]).Sum(c => c * (c - 1) / 2);
		//return Enumerable.Range(1, (int)n).Where(v => map[v].Count == 2).Select(v => counts[v]).Sum(c => c * (c - 1) / 2 + c * (n - c));
	}
}
