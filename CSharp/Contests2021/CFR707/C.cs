using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();
		const int a_max = 2500000;

		// u+v=u+v が存在する場合
		{
			var c = new int[a_max + 1];
			foreach (var x in a) ++c[x];

			var vs = Enumerable.Range(1, a_max).Where(x => c[x] >= 2).Take(2).ToArray();
			if (vs.Length == 2)
			{
				var i2 = vs.Select(x => Enumerable.Range(0, n).Where(i => a[i] == x).Take(2).ToArray()).ToArray();
				return $"YES\n{i2[0][0] + 1} {i2[1][0] + 1} {i2[0][1] + 1} {i2[1][1] + 1}";
			}
		}

		// 以下、a に同じ値が存在したとしても1組のみ
		var map = new Dictionary<int, (int, int)>();

		for (int i = 0; i < n; i++)
		{
			for (int j = i + 1; j < n; j++)
			{
				var key = a[i] + a[j];
				if (map.ContainsKey(key))
				{
					var (x, y) = map[key];
					if (x == i || x == j || y == i || y == j) continue;
					return $"YES\n{x + 1} {y + 1} {i + 1} {j + 1}";
				}
				else
				{
					map[key] = (i, j);
				}
			}
		}

		return "NO";
	}
}
