﻿using System;
using System.Linq;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var ps = Enumerable.Range(0, n).Select(i =>
		{
			var (h, w) = Read2();
			return h > w ? (i, h: w, w: h) : (i, h, w);
		}).ToArray();

		var r = new int[n];
		var min = (i: 0, w: 1 << 30);

		var q = ps.OrderBy(t => t.h).ThenBy(t => -t.w);
		foreach (var (i, _, w) in q)
		{
			if (min.w < w)
			{
				r[i] = min.i + 1;
			}
			else
			{
				r[i] = -1;
				min = (i, w);
			}
		}
		return string.Join(" ", r);
	}
}
