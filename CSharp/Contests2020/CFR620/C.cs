﻿using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static (int t, int l, int h) Read3() { var a = Read(); return (a[0], a[1], a[2]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var (n, m) = Read2();
		var ps = Array.ConvertAll(new bool[n], _ => Read3());

		var (t, l, h) = (0, m, m);
		foreach (var (t_, l_, h_) in ps)
		{
			l -= t_ - t;
			h += t_ - t;
			t = t_;

			if (h < l_ || h_ < l) return false;

			l = Math.Max(l, l_);
			h = Math.Min(h, h_);
		}
		return true;
	}
}
