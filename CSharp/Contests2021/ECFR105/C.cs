using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, m) = Read2();
		var a = Read();
		var b = Read();

		int[] FilterPos(int[] c) => c.Where(x => x > 0).ToArray();
		int[] FilterNeg(int[] c) => c.Where(x => x < 0).Select(x => -x).Reverse().ToArray();

		return SolveHalf(FilterPos(a), FilterPos(b)) + SolveHalf(FilterNeg(a), FilterNeg(b));
	}

	static int SolveHalf(int[] a, int[] b)
	{
		var n = a.Length;
		var m = b.Length;

		// a_n = 2^30
		a = a.Append(1 << 30).ToArray();

		var bset = b.ToHashSet();
		var placed = new int[n + 1];
		for (int i = n - 1; i >= 0; i--)
			placed[i] = placed[i + 1] + (bset.Contains(a[i]) ? 1 : 0);

		var max = placed[0];

		for (int k = 1; k <= n; k++)
		{
			// k個連結した箱が動く範囲: (a_{k-1} - k, a_k)
			// k個連結した箱の左端が動く範囲: (a_{k-1} - k, a_k - k]
			// k個連結した箱の右端が動く範囲: [a_{k-1}, a_k)

			var bmax = 0;
			var bstart = First(0, m, x => b[x] > a[k - 1] - k);
			for (int l = bstart; l < m && b[l] <= a[k] - k; l++)
			{
				var r = Last(-1, m - 1, x => b[x] < b[l] + k);
				bmax = Math.Max(bmax, r - l + 1);
			}
			max = Math.Max(max, bmax + placed[k]);
		}
		return max;
	}

	static int First(int l, int r, Func<int, bool> f)
	{
		int m;
		while (l < r) if (f(m = l + (r - l - 1) / 2)) r = m; else l = m + 1;
		return r;
	}

	static int Last(int l, int r, Func<int, bool> f)
	{
		int m;
		while (l < r) if (f(m = r - (r - l - 1) / 2)) l = m; else r = m - 1;
		return l;
	}
}
