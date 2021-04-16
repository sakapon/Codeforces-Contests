using System;
using System.Linq;

class F
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int i, int j) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		Console.ReadLine();
		var (n, m) = Read2();
		var ps = Array.ConvertAll(new bool[m], _ => Read2());

		var cols = ps
			.Append((1, j: 0))
			.Append((2, j: 0))
			.GroupBy(p => p.j)
			.Select(g =>
			{
				var (b1, b2) = (false, false);
				foreach (var (i, _) in g)
					if (i == 1) b1 = true;
					else b2 = true;
				return (j: g.Key, b1, b2);
			})
			.OrderBy(t => t.j)
			.ToArray();

		// WW が 2 列続く場合は削除
		for (int k = 1; k < cols.Length; k++)
		{
			var (j, b1, b2) = cols[k];
			var d = j - cols[k - 1].j - 1;
			d = d / 2 * 2;
			cols[k] = (j - d, b1, b2);
		}

		var grid = NewArray2(cols[^1].j + 1, 2, true);
		foreach (var (j, b1, b2) in cols)
		{
			grid[j][0] = !b1;
			grid[j][1] = !b2;
		}

		var tb = new[] { false, false };
		for (int i = 0; i < grid.Length; i++)
		{
			if (!grid[i][0] && !grid[i][1])
			{
				if (tb[0] ^ tb[1]) return false;
			}
			else if (grid[i][0] && grid[i][1])
			{
				if (tb[0] ^ tb[1])
				{
					tb[0] ^= true;
					tb[1] ^= true;
				}
			}
			else if (grid[i][0])
			{
				if (tb[1]) return false;
				tb[0] ^= grid[i][0];
				tb[1] ^= grid[i][1];
			}
			else
			{
				if (tb[0]) return false;
				tb[0] ^= grid[i][0];
				tb[1] ^= grid[i][1];
			}
		}
		if (tb[0] ^ tb[1]) return false;

		return true;
	}

	static T[][] NewArray2<T>(int n1, int n2, T v = default) => Array.ConvertAll(new bool[n1], _ => Array.ConvertAll(new bool[n2], __ => v));
}
