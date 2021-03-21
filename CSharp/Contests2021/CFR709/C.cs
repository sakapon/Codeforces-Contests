using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, m) = Read2();
		var fss = Array.ConvertAll(new bool[m], _ => Read());

		var m2 = (m + 1) / 2;

		var counts = new int[n + 1];
		foreach (var fs in fss)
		{
			if (fs[0] == 1)
			{
				counts[fs[1]]++;
			}
		}
		if (counts.Any(x => x > m2)) return "NO";

		var r = new int[m];
		for (int i = 0; i < m; i++)
		{
			var fs = fss[i];
			if (fs[0] == 1)
				r[i] = fs[1];
		}

		for (int i = 0; i < m; i++)
		{
			var fs = fss[i];
			if (fs[0] == 1) continue;

			for (int j = 1; j <= fs[0]; j++)
			{
				var f = fs[j];
				if (counts[f] + 1 > m2) continue;

				r[i] = f;
				counts[f]++;
				break;
			}
		}

		return "YES\n" + string.Join(" ", r);
	}
}
