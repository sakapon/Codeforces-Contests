using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var r = 0;

		for (int i = 1; i < n; i++)
		{
			var min = Math.Min(a[i], a[i - 1]);
			var max = Math.Max(a[i], a[i - 1]);

			while (2 * min < max)
			{
				r++;
				min *= 2;
			}
		}
		return r;
	}
}
