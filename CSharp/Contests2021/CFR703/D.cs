using System;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main()
	{
		var (n, k) = Read2();
		var a = Read();

		Console.WriteLine(Last(1, n, x =>
		{
			var b = Array.ConvertAll(a, v => v < x ? -1 : 1);

			var s = new int[n + 1];
			for (int i = 0; i < n; ++i) s[i + 1] = s[i] + b[i];

			var min = 0;
			for (int i = k; i <= n; i++)
			{
				min = Math.Min(min, s[i - k]);
				if (min < s[i]) return true;
			}
			return false;
		}));
	}

	static int Last(int l, int r, Func<int, bool> f)
	{
		int m;
		while (l < r) if (f(m = r - (r - l - 1) / 2)) l = m; else r = m - 1;
		return l;
	}
}
