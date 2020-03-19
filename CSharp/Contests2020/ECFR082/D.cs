using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static long[] Read() => Console.ReadLine().Split().Select(long.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long[] p2;
	static Dictionary<long, int> p2d;

	static long Solve()
	{
		if (p2 == null)
		{
			p2 = Enumerable.Range(0, 63).Select(i => 1L << i).ToArray();
			p2d = p2.Select((x, i) => new { x, i }).ToDictionary(_ => _.x, _ => _.i);
		}

		var h = Read();
		var n = h[0];
		var a = Read();

		if (a.Sum() < n) return -1;

		var b = new long[61];
		foreach (var x in a) ++b[p2d[x]];

		var r = 0L;
		for (int k = 0; k < 60; k++)
		{
			if ((n & p2[k]) == 0)
			{
				var c = b[k] / 2;
				b[k + 1] += c;
				b[k] -= 2 * c;
			}
			else
			{
				if (b[k] == 0)
				{
					var j = Array.FindIndex(b, k + 1, x => x > 0);
					b[j]--;
					for (int i = k + 1; i < j; i++)
					{
						b[i]++;
					}
					b[k] = 2;
					r += j - k;
				}

				var c = (b[k] - 1) / 2;
				b[k + 1] += c;
				b[k] -= 2 * c;
			}
		}
		return r;
	}
}
