using System;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main()
	{
		Console.SetOut(new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
		var (n, qc) = Read2();
		var a = Read();
		var qs = Array.ConvertAll(new bool[qc], _ => Read2());

		var rn = (int)Math.Sqrt(n);

		// 出現回数が √n 以上の数のインデックス
		var indexMap = a.Select((x, i) => (x, i))
			.GroupBy(t => t.x)
			.Where(g => g.Count() >= rn)
			.ToDictionary(g => g.Key, g => g.Select(t => t.i).ToArray());

		foreach (var (l, r) in qs)
		{
			var c = r - l + 1;

			if (c <= 2 * rn)
			{
				var k = Enumerable.Range(l - 1, c).Select(i => a[i]).GroupBy(x => x).Max(g => g.Count());
				Console.WriteLine(GetPieces(c, k));
			}
			else
			{
				var k = indexMap.Max(p =>
				{
					var b = p.Value;
					var il = First(0, b.Length, x => b[x] >= l - 1);
					var ir = First(0, b.Length, x => b[x] >= r);
					return ir - il;
				});
				Console.WriteLine(GetPieces(c, k));
			}
		}
		Console.Out.Flush();
	}

	// k: 最も多い数の出現回数
	static int GetPieces(int n, int k) => Math.Max(1, 2 * k - n);

	static int First(int l, int r, Func<int, bool> f)
	{
		int m;
		while (l < r) if (f(m = l + (r - l - 1) / 2)) r = m; else l = m + 1;
		return r;
	}
}
