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

		// unblocked: flagged
		var bs = ps.GroupBy(p => p.j)
			.Select(g => (j: g.Key, f: 3 - g.Sum(p => p.i)))
			.OrderBy(t => t.j)
			.Prepend((j: 0, f: 0))
			.ToArray();

		// empty が 2 列続く場合は削除 (左に詰める)
		for (int k = 1; k < bs.Length; k++)
		{
			var (j, f) = bs[k];
			var d = j - bs[k - 1].j - 1;
			d = d / 2 * 2;
			bs[k] = (j - d, f);
		}

		var cols = Array.ConvertAll(new bool[bs[^1].j + 1], _ => 3);
		foreach (var (j, f) in bs)
		{
			cols[j] = f;
		}

		for (int j = 1; j < cols.Length; j++)
		{
			if ((cols[j] & cols[j - 1]) != cols[j - 1]) return false;
			cols[j] -= cols[j - 1];
			if (cols[j] == 3) cols[j] = 0;
		}
		return cols[^1] == 0;
	}
}
