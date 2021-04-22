using System;
using System.Collections.Generic;

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
		var indexMap = Array.ConvertAll(new bool[n + 1], _ => new List<int>());
		for (int i = 0; i < n; i++)
			indexMap[a[i]].Add(i);

		var random = new Random();

		// [l, r)
		int ByRandom(int l, int r)
		{
			var c = r - l;

			for (int t = 0; t < 24; t++)
			{
				var ai = random.Next(l, r);
				var b = indexMap[a[ai]];
				var il = First(0, b.Count, x => b[x] >= l);
				var ir = First(0, b.Count, x => b[x] >= r);
				var k = ir - il;
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
