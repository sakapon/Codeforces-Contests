using System;
using System.Collections.Generic;
using System.Linq;
using Bang.Graphs.Int.Spp;

class G2
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
		var dp = Array.ConvertAll(new bool[n + 1], _ => -1L);

		void Dfs(int v)
		{
			if (dp[v] >= 0) return;
			dp[v] = r[v];

			foreach (var nv in map[v])
			{
				if (r[nv] <= r[v])
				{
					dp[v] = Math.Min(dp[v], r[nv]);
				}
				else
				{
					Dfs(nv);
					dp[v] = Math.Min(dp[v], dp[nv]);
				}
			}
		}

		Dfs(1);
		return string.Join(" ", dp[1..]);
	}
}
