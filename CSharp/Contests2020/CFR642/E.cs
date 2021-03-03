using System;
using System.Linq;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var (n, k) = Read2();
		var s = Console.ReadLine();

		var all = s.Count(c => c == '1');
		var min = all;

		for (int j = 0; j < k; j++)
		{
			// オン区間の前・中・後
			var (c1, c2, c3) = (0, 0, 0);
			var count = 0;

			for (int i = j; i < n; i += k)
			{
				if (s[i] == '1')
				{
					count++;
					(c2, c3) = (Math.Min(c1, c2), Math.Min(c2, c3) + 1);
					c1++;
				}
				else
				{
					(c2, c3) = (Math.Min(c1, c2) + 1, Math.Min(c2, c3));
				}
			}
			var target = Math.Min(c1, Math.Min(c2, c3));
			min = Math.Min(min, target + all - count);
		}
		return min;
	}
}
