using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Console.ReadLine();

		var d = new Dictionary<long, int>();
		int l = 0, r = 0, m = int.MaxValue;

		var p = (0, 0);
		d[ToId(p)] = 0;

		for (int i = 0; i < n; i++)
		{
			p = Next(p, s[i]);
			var id = ToId(p);

			if (d.ContainsKey(id))
			{
				var length = i + 2 - d[id];
				if (length < m)
				{
					l = d[id] + 1;
					r = i + 1;
					m = length;
				}
			}
			d[id] = i + 1;
		}

		return m == int.MaxValue ? "-1" : $"{l} {r}";
	}

	static long ToId((int x, int y) p) => 10000000L * (p.x + 1000000) + (p.y + 1000000);

	static (int, int) Next((int x, int y) p, char c)
	{
		if (c == 'L') return (p.x - 1, p.y);
		if (c == 'R') return (p.x + 1, p.y);
		if (c == 'U') return (p.x, p.y + 1);
		return (p.x, p.y - 1);
	}
}
