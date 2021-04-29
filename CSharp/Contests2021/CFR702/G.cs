using System;
using System.Linq;

class G
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, m) = Read2();
		var a = ReadL();
		var x = ReadL();

		var s = a.Sum();
		var cs = CumSumL(a);
		cs = cs[1..];

		for (int i = 1; i < n; i++)
		{
			cs[i] = Math.Max(cs[i], cs[i - 1]);
		}

		int GetCount(long v) => First(0, n, i => v <= cs[i]);

		var r = new long[m];

		if (s <= 0)
		{
			for (int j = 0; j < m; j++)
			{
				var si = GetCount(x[j]);
				r[j] = si == n ? -1 : si;
			}
		}
		else
		{
			for (int j = 0; j < m; j++)
			{
				if (x[j] <= cs[^1])
				{
					r[j] = GetCount(x[j]);
				}
				else
				{
					// k: additional turns
					var d = x[j] - cs[^1];
					var k = (d - 1) / s + 1;
					r[j] = k * n + GetCount(x[j] - k * s);
				}
			}
		}

		return string.Join(" ", r);
	}

	static long[] CumSumL(long[] a)
	{
		var s = new long[a.Length + 1];
		for (int i = 0; i < a.Length; ++i) s[i + 1] = s[i] + a[i];
		return s;
	}

	static int First(int l, int r, Func<int, bool> f)
	{
		int m;
		while (l < r) if (f(m = l + (r - l - 1) / 2)) r = m; else l = m + 1;
		return r;
	}
}
