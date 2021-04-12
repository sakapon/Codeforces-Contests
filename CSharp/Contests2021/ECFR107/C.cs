using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var (n, qc) = Read2();
		var a = Read();
		var t = Read();

		var f = new int[51];
		for (int i = 0; i < n; i++)
		{
			var c = a[i];
			if (f[c] != 0) continue;
			f[c] = i + 1;
		}

		var r = new int[qc];

		for (int qi = 0; qi < qc; qi++)
		{
			var c = t[qi];
			r[qi] = f[c];

			for (int fi = 0; fi < f.Length; fi++)
			{
				if (f[fi] == 0) continue;
				if (f[fi] >= r[qi]) continue;
				f[fi]++;
			}
			f[c] = 1;
		}

		return string.Join(" ", r);
	}
}
