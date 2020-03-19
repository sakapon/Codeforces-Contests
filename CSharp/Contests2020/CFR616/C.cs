using System;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var h = Read();
		int n = h[0], m = h[1], k = Math.Min(h[2], m - 1), k2 = m - 1 - k;
		var a = Read();

		return Last(0, 1 << 30, x =>
		{
			var b = Array.ConvertAll(a, v => v >= x);

			for (int i = 0; i <= k; i++)
			{
				int l1 = i, r1 = n - 1 - k + i;

				var ok = true;
				for (int j = 0; j <= k2; j++)
				{
					int l2 = l1 + j, r2 = r1 - k2 + j;
					if (!b[l2] && !b[r2]) { ok = false; break; }
				}
				if (ok) return true;
			}
			return false;
		});
	}

	static int Last(int l, int r, Func<int, bool> f)
	{
		int m;
		while (l < r) if (f(m = r - (r - l - 1) / 2)) l = m; else r = m - 1;
		return l;
	}
}
