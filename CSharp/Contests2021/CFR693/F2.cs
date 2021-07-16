using System;
using System.Linq;

class F2
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
			.ToArray();

		for (int i = 1; i < bs.Length; i++)
		{
			var (j, f) = bs[i];
			var (j0, f0) = bs[i - 1];

			if (f0 > 0 && (j - j0) % 2 == 0) f0 ^= 3;
			if ((f & f0) != f0) return false;

			f -= f0;
			bs[i] = (j, f == 3 ? 0 : f);
		}
		return bs[^1].f == 0;
	}
}
