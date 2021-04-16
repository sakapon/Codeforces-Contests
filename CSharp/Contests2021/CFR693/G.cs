using System;
using System.Collections.Generic;
using System.Linq;
using Bang.Graphs.Int.Spp;

class G
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		Console.ReadLine();
		var (n, m) = Read2();
		var map = GraphConsole.ReadUnweightedMap(n + 1, m, true);

		var r = map.Bfs(1);
		var dp = r.RawCosts.ToArray();

		var q = Enumerable.Range(1, n).Select(v => (v, d: r[v])).OrderBy(t => -t.d);
		foreach (var (v, d) in q)
		{
			foreach (var nv in map[v])
			{
				if (r[nv] <= r[v])
				{
					dp[v] = Math.Min(dp[v], r[nv]);
				}
				else
				{
					dp[v] = Math.Min(dp[v], dp[nv]);
				}
			}
		}
		return string.Join(" ", dp[1..]);
	}
}
