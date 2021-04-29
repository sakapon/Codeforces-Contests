using System;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = ReadL();
		var b = ReadL();

		var sum = a.Zip(b, (x, y) => x * y).Sum();
		var dmax = 0L;

		// 奇数個
		for (int c = 0; c < n; c++)
		{
			var d = 0L;
			for (var (l, r) = (c, c); l >= 0 && r < n; l--, r++)
			{
				d += (a[r] - a[l]) * (b[l] - b[r]);
				dmax = Math.Max(dmax, d);
			}
		}

		// 偶数個
		for (int c = 0; c < n; c++)
		{
			var d = 0L;
			for (var (l, r) = (c, c + 1); l >= 0 && r < n; l--, r++)
			{
				d += (a[r] - a[l]) * (b[l] - b[r]);
				dmax = Math.Max(dmax, d);
			}
		}

		return sum + dmax;
	}
}
