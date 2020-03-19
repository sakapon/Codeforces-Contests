using System;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var h = Read();
		int n = h[0], x = h[1];
		var s = Console.ReadLine();

		var t = new int[n + 1];
		for (int i = 0; i < n; i++) t[i + 1] = t[i] + (s[i] == '0' ? 1 : -1);

		if (t[n] == 0)
		{
			return Enumerable.Range(0, n).Any(i => t[i] == x) ? -1 : 0;
		}
		else
		{
			var r = 0;
			for (int i = 0; i < n; i++)
			{
				var q = Math.DivRem(x - t[i], t[n], out var rem);
				if (rem == 0 && q >= 0) r++;
			}
			return r;
		}
	}
}
