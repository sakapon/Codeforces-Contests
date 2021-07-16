using System;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static (int, int, int) Read3() { var a = Read(); return (a[0], a[1], a[2]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, l, r) = Read3();
		var c = Read();

		var cl = c.Take(l).ToArray();
		var cr = c.Skip(l).ToArray();

		if (l > r)
		{
			(l, r) = (r, l);
			(cl, cr) = (cr, cl);
		}

		var dl = Tally(cl, n);
		var dr = Tally(cr, n);

		var count = 0;

		for (int i = 1; i <= n; i++)
		{
			var t = Math.Min(dl[i], dr[i]);
			l -= t;
			r -= t;
			dl[i] -= t;
			dr[i] -= t;
		}

		for (int i = 1; i <= n; i++)
		{
			while (l < r && dr[i] >= 2)
			{
				r -= 2;
				dr[i] -= 2;
				count++;
			}
			if (l == r) break;
		}

		return count + r;
	}

	static int[] Tally(int[] a, int max)
	{
		var c = new int[max + 1];
		foreach (var x in a) ++c[x];
		return c;
	}
}
