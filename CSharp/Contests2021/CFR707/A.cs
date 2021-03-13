using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int a, int b) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var ps = Array.ConvertAll(new bool[n], _ => Read2());
		var t = Read();

		int r = 0, dep = 0;
		for (int i = 0; i < n; i++)
		{
			var (a, b) = ps[i];

			if (i == 0)
				r = a + t[i];
			else
				r = dep + a - ps[i - 1].b + t[i];

			var t2 = (b - a + 1) / 2;
			dep = Math.Max(r + t2, b);
		}

		return r;
	}
}
