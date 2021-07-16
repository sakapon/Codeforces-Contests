using System;
using System.Collections.Generic;
using System.Linq;
using Bang.Graphs.Int.Spp;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var (n, m) = Read2();
		var es = GraphConsole.ReadEdges(m);
		var k = int.Parse(Console.ReadLine());
		var p = Read();

		var map = new UnweightedMap(n + 1, es, true);
		var map_r = new UnweightedMap(n + 1, Array.ConvertAll(es, e => e.Reverse()), true);

		var r = map_r.Bfs(p.Last());
		var (min, max) = (0, 0);

		for (int i = 0; i < k - 1; i++)
		{
			if (r[p[i]] <= r[p[i + 1]])
			{
				min++;
				max++;
			}
			else
			{
				if (map[p[i]].Count(v => r[v] < r[p[i]]) > 1) max++;
			}
		}
		return $"{min} {max}";
	}
}
