using System;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		if (a.All(x => x == -1)) return "0 0";

		var M = 0;
		for (int i = 1; i < n; i++)
		{
			if (a[i - 1] > -1 && a[i] > -1)
				M = Math.Max(M, Math.Abs(a[i] - a[i - 1]));
		}

		int min = 1 << 30, max = 0;
		for (int i = 0; i < n; i++)
		{
			if (a[i] == -1) continue;

			if (i > 0 && a[i - 1] == -1 || i < a.Length - 1 && a[i + 1] == -1)
			{
				max = Math.Max(max, a[i]);
				min = Math.Min(min, a[i]);
			}
		}
		var k = (max + min + 1) / 2;
		M = Math.Max(M, (max - min + 1) / 2);
		return $"{M} {k}";
	}
}
