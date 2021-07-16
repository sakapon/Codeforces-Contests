using System;
using System.Linq;

class D2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, p) = Read2();
		var a = Read();

		var r = Array.ConvertAll(new bool[n - 1], _ => (long)p);

		var q = a.Select((x, i) => (x, i)).Where(t => t.x < p).OrderBy(t => t.x);
		foreach (var (x, v) in q)
		{
			for (int i = v + 1; i < n; i++)
			{
				if (r[i - 1] <= x) break;
				if (a[i] % x != 0) break;
				r[i - 1] = x;
			}
			for (int i = v - 1; i >= 0; i--)
			{
				if (r[i] <= x) break;
				if (a[i] % x != 0) break;
				r[i] = x;
			}
		}
		return r.Sum();
	}
}
