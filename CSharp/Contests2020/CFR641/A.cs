using System;
using System.Linq;

class A
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var h = Read();
		return Query(h[0], h[1]);
	}

	static int Query(int n, int k)
	{
		if (n % 2 == 0) return n + 2 * k;

		for (int i = 3; ; i += 2)
			if (n % i == 0)
				return Query(n + i, k - 1);
	}
}
