using System;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		const int a_max = 2500000;
		var set = new (int, int)?[2 * a_max + 1];

		for (int i = 0; i < n; i++)
		{
			for (int j = i + 1; j < n; j++)
			{
				var key = a[i] + a[j];
				if (set[key].HasValue)
				{
					var (x, y) = set[key].Value;
					if (x == i || x == j || y == i || y == j) continue;
					return $"YES\n{x + 1} {y + 1} {i + 1} {j + 1}";
				}
				else
				{
					set[key] = (i, j);
				}
			}
		}
		return "NO";
	}
}
