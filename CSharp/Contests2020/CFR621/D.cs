using System;
using System.Collections.Generic;
using System.Linq;
using Bang.Graphs.Int.Spp;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static (int, int, int) Read3() { var a = Read(); return (a[0], a[1], a[2]); }
	static void Main()
	{
		var (n, m, k) = Read3();
		var a = Read();
		var es = Array.ConvertAll(new bool[m], _ => (Edge)Read());
		var map = new UnweightedMap(n + 1, es, false);

		var set = a.ToHashSet();
		var already = es.Any(e => set.Contains(e.From) && set.Contains(e.To));

		if (already)
		{
			var r1 = map.Bfs(1, n);
			Console.WriteLine(r1[n]);
		}
		else
		{
			var r1 = map.Bfs(1, -1);
			var rn = map.Bfs(n, -1);

			var max = 0L;
			var q = PriorityQueue<long>.Create(true);
			var vs = a.Select(i => (i, d: r1[i] - rn[i])).OrderBy(v => v.d);
			foreach (var (i, _) in vs)
			{
				if (q.Any) max = Math.Max(max, q.First + rn[i]);
				q.Push(r1[i]);
			}
			max++;
			Console.WriteLine(Math.Min(r1[n], max));
		}
	}
}
