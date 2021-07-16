using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, m) = Read2();
		var b = Array.ConvertAll(new bool[n], _ => Read().OrderBy(x => x).ToList());

		var r = NewArray2<int>(n, m);
		var mins = b.SelectMany((p, i) => p.Select(x => (x, i))).OrderBy(t => t.x).Take(m).ToArray();

		for (int j = 0; j < m; j++)
		{
			var (x0, i0) = mins[j];
			r[i0][j] = x0;

			for (int i = 0; i < n; i++)
			{
				if (i == i0) continue;

				r[i][j] = b[i].Last();
				b[i].RemoveAt(b[i].Count - 1);
			}
		}
		return string.Join("\n", r.Select(l => string.Join(" ", l)));
	}

	static T[][] NewArray2<T>(int n1, int n2, T v = default) => Array.ConvertAll(new bool[n1], _ => Array.ConvertAll(new bool[n2], __ => v));
}
