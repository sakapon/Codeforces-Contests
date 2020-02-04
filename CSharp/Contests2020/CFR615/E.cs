using System;
using System.Linq;

class E
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var h = Read();
		int n = h[0], m = h[1];
		var a = new int[n].Select(_ => Read()).ToArray();

		for (int i = 0; i < n; i++)
			for (int j = 0; j < m; j++)
			{
				var q = Math.DivRem(a[i][j] - (j + 1), m, out var rem);
				a[i][j] = rem == 0 && 0 <= q && q < n ? Mod(q - i, n) : -1;
			}

		var r = 0L;
		for (int j = 0; j < m; j++)
		{
			var gs = Enumerable.Range(0, n).Select(i => a[i][j]).Where(x => x != -1).GroupBy(x => x);
			var min = n;
			foreach (var g in gs)
				min = Math.Min(min, (n - g.Key) % n + n - g.Count());
			r += min;
		}
		Console.WriteLine(r);
	}

	static int Mod(int x, int m) => (x %= m) < 0 ? x + m : x;
}
