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

		// WW が 2 列続く場合は削除
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

		var t = 0;
		foreach (var f in cols)
		{
			if (f == 0)
			{
				if (t > 0) return false;
			}
			else if (f == 1)
			{
				if (t == 2) return false;
				t ^= f;
			}
			else if (f == 2)
			{
				if (t == 1) return false;
				t ^= f;
			}
			else
			{
				if (t > 0) t ^= f;
			}
		}
		return t == 0;
	}
}
