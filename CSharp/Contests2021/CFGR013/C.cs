using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Read();

		var r = 0L;
		var t = new int[n + 1];

		for (int i = 0; i < n; i++)
		{
			// i を通過する回数
			var c = Math.Max(t[i], s[i] - 1);
			r += c - t[i];

			for (int d = 2; d <= s[i] && i + d < n; d++)
				t[i + d]++;
			if (c == t[i]) t[i + 1] += t[i] - s[i] + 1;
		}
		return r;
	}
}
