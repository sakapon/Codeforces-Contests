using System;
using System.Linq;

class E
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var h = Read();
		int n = h[0], k = h[1];
		var s = Console.ReadLine().GroupBy(x => x).Select(g => g.Count()).OrderBy(x => -x).ToArray();

		var r = 0;
		for (int i = 1; i <= s[0]; i++)
			for (int j = s.Sum(x => x / i); j > 0; j--)
				if (k % j == 0)
				{
					r = Math.Max(r, i * j);
					break;
				}
		return r;
	}
}
