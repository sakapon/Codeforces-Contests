using System;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var rn = (int)Math.Sqrt(n);

		var r = 1 << 30;
		for (int x = Math.Max(1, rn - 5); x <= rn + 5; x++)
		{
			var t = x - 1 + (n + x - 1) / x - 1;
			r = Math.Min(r, t);
		}
		return r;
	}
}
