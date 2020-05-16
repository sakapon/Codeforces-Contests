using System;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var h = Read();
		int n = h[0], k = h[1];

		var c = 0;
		if (n % 2 == 0)
		{
			if (k % 2 == 0) c = 1;
			else c = 2;
		}
		else
		{
			if (k % 2 == 0) return "NO";
			else c = 1;
		}

		if (n < c * k) return "NO";
		var l = Enumerable.Repeat(c, k - 1).ToList();
		l.Add(n - c * (k - 1));
		return $"YES\n{string.Join(" ", l)}";
	}
}
