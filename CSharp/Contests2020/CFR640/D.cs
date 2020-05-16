using System;
using System.Linq;

class D
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var c = Read();
		int m = 0, a = 0, b = 0, t = 0, l = -1, r = n;

		while (true)
		{
			m++;
			var sa = 0;
			while (sa <= t)
			{
				if (++l == r) return $"{m} {a} {b}";
				a += c[l];
				sa += c[l];
			}
			t = sa;
			if (l + 1 == r) return $"{m} {a} {b}";

			m++;
			var sb = 0;
			while (sb <= t)
			{
				if (l == --r) return $"{m} {a} {b}";
				b += c[r];
				sb += c[r];
			}
			t = sb;
			if (l + 1 == r) return $"{m} {a} {b}";
		}
	}
}
