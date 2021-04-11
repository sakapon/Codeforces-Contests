using System;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, p) = ((int, long))Read2();
		var a = Read();

		if (a.Any(x => x == 1)) return n - 1;

		var r = (n - 1) * p;
		var u = new bool[n];

		var q = a.Select((x, i) => (x, i)).Where(t => t.x < p).OrderBy(t => t.x);
		foreach (var (x, v) in q)
		{
			if (u[v]) continue;

			u[v] = true;
			var c = 1;

			for (int i = v + 1; i < n; i++)
			{
				if (a[i] % x != 0) break;
				if (u[i])
				{
					c++;
					break;
				}
				else
				{
					u[i] = true;
					c++;
				}
			}
			for (int i = v - 1; i >= 0; i--)
			{
				if (a[i] % x != 0) break;
				if (u[i])
				{
					c++;
					break;
				}
				else
				{
					u[i] = true;
					c++;
				}
			}

			r -= (c - 1) * (p - x);
		}
		return r;
	}
}
