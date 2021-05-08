using System;
using System.Linq;

class D2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int, int) Read3() { var a = Read(); return (a[0], a[1], a[2]); }
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

		var lr = dl.Zip(dr, (x, y) => Math.Min(x, y)).Sum();
		var m = dl.Zip(dr, (x, y) => (y - Math.Min(x, y)) / 2).Sum();
		return r - lr - Math.Min((r - l) / 2, m);
	}

	static int[] Tally(int[] a, int max)
	{
		var c = new int[max + 1];
		foreach (var x in a) ++c[x];
		return c;
	}
}
