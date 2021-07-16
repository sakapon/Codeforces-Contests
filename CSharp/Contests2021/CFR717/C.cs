using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var sum = a.Sum();
		if (sum % 2 != 0) return 0;

		var u = Comb(n, a, sum);
		if (!u[sum / 2]) return 0;

		while (true)
		{
			var odds = Enumerable.Range(0, n).Where(i => a[i] % 2 == 1).ToArray();
			if (odds.Any()) return $"1\n{odds[0] + 1}";

			a = a.Select(x => x / 2).ToArray();
		}
	}

	static bool[] Comb(int n, int[] a, int max)
	{
		var u = new bool[max + 1];
		u[0] = true;

		for (int i = 0; i < n; i++)
		{
			for (int j = max; j >= 0; j--)
			{
				if (u[j])
				{
					u[j + a[i]] = true;
				}
			}
		}
		return u;
	}
}
