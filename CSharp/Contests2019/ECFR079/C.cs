using System;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve(Read(), Read(), Read()))));
	static long Solve(int[] h, int[] a, int[] b)
	{
		int n = h[0], m = h[1];

		var u = new long[n + 1];
		for (int t = 0, j = 0; j < m; j++)
		{
			if (u[b[j]] == 1) continue;
			var k = Array.IndexOf(a, b[j], t);
			u[b[j]] = 2 * (k - j) + 1;
			for (int i = t; i < k; i++)
				u[a[i]] = 1;
			t = k + 1;
		}
		return b.Sum(x => u[x]);
	}
}
