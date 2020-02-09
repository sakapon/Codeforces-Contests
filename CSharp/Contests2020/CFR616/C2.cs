using System;
using System.Linq;

class C2
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var h = Read();
		int n = h[0], m = h[1], k = Math.Min(h[2], m - 1), k2 = m - 1 - k;
		var a = Read();

		var max = 0;
		for (int i = 0; i <= k; i++)
		{
			int l1 = i, r1 = n - 1 - k + i;
			var min = int.MaxValue;
			for (int j = 0; j <= k2; j++)
			{
				int l2 = l1 + j, r2 = r1 - k2 + j;
				min = Math.Min(min, Math.Max(a[l2], a[r2]));
			}
			max = Math.Max(max, min);
		}
		return max;
	}
}
