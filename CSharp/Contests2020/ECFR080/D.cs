using System;
using System.Linq;

class D
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var h = Read();
		int n = h[0], m = h[1];
		var a = new int[n].Select(_ => Read()).ToArray();
		var p2 = Enumerable.Range(0, m + 1).Select(i => 1 << i).ToArray();

		int ri = 1, rj = 1;
		var rm = Enumerable.Range(0, m).ToArray();
		var M = Last(0, 1000000000, x =>
		{
			var u = new int[p2[m]];
			for (int i = 0; i < n; i++)
			{
				var f = rm.Select(j => a[i][j] >= x ? p2[j] : 0).Aggregate((y, z) => y | z);
				u[f] = i + 1;
			}

			for (int f = p2[m] - 1; f >= 0; f--)
			{
				if (u[f] == 0) continue;
				for (int g = f; g >= 0; g--)
				{
					if (u[g] == 0) continue;
					if ((f | g) == p2[m] - 1)
					{
						ri = u[f];
						rj = u[g];
						return true;
					}
				}
			}
			return false;
		});
		Console.WriteLine($"{ri} {rj}");
	}

	static int Last(int l, int r, Func<int, bool> f)
	{
		int m;
		while (l < r) if (f(m = r - (r - l - 1) / 2)) l = m; else r = m - 1;
		return l;
	}
}
