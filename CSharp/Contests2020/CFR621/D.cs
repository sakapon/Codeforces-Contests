using System;
using System.Collections.Generic;
using System.Linq;
using Bang.Graphs.Int.Spp;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
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

			long M = 0, M1 = -1;
			var vs = a.Select(i => (i, d: r1[i] - rn[i])).OrderBy(v => v.d);
			foreach (var (i, _) in vs)
			{
				if (M1 != -1) M = Math.Max(M, M1 + rn[i]);
				M1 = Math.Max(M1, r1[i]);
			}
			M++;
			Console.WriteLine(Math.Min(r1[n], M));
		}
	}
}
