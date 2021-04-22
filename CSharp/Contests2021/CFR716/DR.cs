using System;
using System.Linq;

class DR
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main()
	{
		var (n, qc) = Read2();
		var a = Read();
		var qs = Array.ConvertAll(new bool[qc], _ => Read2());

		// 出現するインデックス
		var indexMap = a.Select((x, i) => (x, i))
			.GroupBy(t => t.x)
			.ToDictionary(g => g.Key, g => g.Select(t => t.i).ToArray());

		// [l, r)
		int GetCount(int x, int l, int r)
		{
			var b = indexMap[x];
			var il = First(0, b.Length, x => b[x] >= l);
			var ir = First(0, b.Length, x => b[x] >= r);
			return ir - il;
		}

		var random = new Random();

		int ByRandom(int l, int r)
		{
			var c = r - l;

			for (int t = 0; t < 28; t++)
			{
				var ai = random.Next(l, r);
				var k = GetCount(a[ai], l, r);
				if (2 * k >= c + 1) return GetPieces(c, k);
			}
			return 1;
		}

		Console.SetOut(new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
		foreach (var (l, r) in qs)
			Console.WriteLine(ByRandom(l - 1, r));
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
