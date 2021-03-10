using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var local = new List<int> { 0 };
		// 初めに下がる場合は追加。奇数番目が極大。
		if (a[0] > a[1]) local.Add(0);

		for (int i = 1; i < n - 1; i++)
		{
			if (a[i - 1] < a[i] && a[i] > a[i + 1])
			{
				local.Add(i);
			}
			else if (a[i - 1] > a[i] && a[i] < a[i + 1])
			{
				local.Add(i);
			}
		}
		if (a[^2] < a[^1]) local.Add(n - 1);
		local.Add(n - 1);

		var max = Enumerable.Range(0, local.Count - 1)
			.Max(i => Math.Abs(local[i] - local[i + 1]));
		var deltas = Enumerable.Range(0, local.Count)
			.Where(i => i % 2 == 1)
			.Select(i => (x: local[i + 1] - local[i], y: local[i] - local[i - 1]))
			.ToArray();

		var filter = deltas.Where(t => t.x == max || t.y == max).ToArray();
		if (filter.Length > 1)
		{
			Console.WriteLine(0);
			return;
		}

		var (x, y) = filter.First();
		Console.WriteLine(x == y && x % 2 == 0 ? 1 : 0);
	}
}
