using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var (n, k) = Read2();
		var ps = Array.ConvertAll(new bool[n], _ => Read());

		for (int i = 0; i < n; i++)
		{
			var ok = true;
			for (int j = 0; j < n; j++)
				if (NormL1(Subtract(ps[i], ps[j])) > k) { ok = false; break; }
			if (ok) return 1;
		}
		return -1;
	}

	static int[] Subtract(int[] v1, int[] v2) => new[] { v1[0] - v2[0], v1[1] - v2[1] };
	static int NormL1(int[] v) => Math.Abs(v[0]) + Math.Abs(v[1]);
}
