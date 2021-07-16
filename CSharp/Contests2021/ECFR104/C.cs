using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var n2 = (n - 1) / 2;

		var r = new int[n, n];

		for (int k = 1; k <= n2; k++)
		{
			for (int i = 0; i < n; i++)
			{
				// i defeates i+k
				var j = (i + k) % n;
				if (i < j)
					r[i, j] = 1;
				else
					r[j, i] = -1;
			}
		}

		if (n % 2 == 0)
		{
			for (int i = 0; i < n / 2; i++)
			{
				// tie
				r[i, i + n / 2] = 0;
			}
		}
		else
		{
		}

		var l = new List<int>();
		for (int i = 0; i < n; i++)
			for (int j = i + 1; j < n; j++)
				l.Add(r[i, j]);
		return string.Join(" ", l);
	}
}
