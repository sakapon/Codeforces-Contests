using System;
using System.Linq;

class E
{
	const int max = 1 << 29;
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = Read();
		var a = Array.ConvertAll(new bool[4], _ => Read());
		var m1 = int.Parse(Console.ReadLine());
		var b01 = Array.ConvertAll(new bool[m1], _ => Read2()).ToHashSet();
		var m2 = int.Parse(Console.ReadLine());
		var b12 = Array.ConvertAll(new bool[m2], _ => Read2()).ToHashSet();
		var m3 = int.Parse(Console.ReadLine());
		var b23 = Array.ConvertAll(new bool[m3], _ => Read2()).ToHashSet();

		// for each second, min(a0 + a1)
		var a0 = a[0].Select((v, i) => (v, i)).OrderBy(t => t.v).ToArray();
		var min01 = Array.ConvertAll(new bool[n[1]], _ => max);
		for (int i1 = 0; i1 < n[1]; i1++)
			foreach (var (v, i0) in a0)
			{
				if (b01.Contains((i0 + 1, i1 + 1))) continue;
				min01[i1] = v + a[1][i1];
				break;
			}
		if (min01.Min() >= max) return -1;

		// for each drink, min(a2 + a3)
		var a3 = a[3].Select((v, i) => (v, i)).OrderBy(t => t.v).ToArray();
		var min23 = Array.ConvertAll(new bool[n[2]], _ => max);
		for (int i2 = 0; i2 < n[2]; i2++)
			foreach (var (v, i3) in a3)
			{
				if (b23.Contains((i2 + 1, i3 + 1))) continue;
				min23[i2] = a[2][i2] + v;
				break;
			}
		if (min23.Min() >= max) return -1;

		// for each drink, min(min01 + min23)
		var a01 = min01.Select((v, i) => (v, i)).OrderBy(t => t.v).ToArray();
		var min12 = Array.ConvertAll(new bool[n[2]], _ => max);
		for (int i2 = 0; i2 < n[2]; i2++)
			foreach (var (v, i1) in a01)
			{
				if (b12.Contains((i1 + 1, i2 + 1))) continue;
				min12[i2] = v + min23[i2];
				break;
			}
		var r = min12.Min();
		if (r >= max) return -1;
		return r;
	}
}
