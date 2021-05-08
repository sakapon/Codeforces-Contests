using System;
using System.Collections.Generic;
using System.Linq;

class B
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		if (values == null)
		{
			values = new HashSet<long>();
			for (long x = 1; x * x <= 4 * 10000000000L; x++)
			{
				var x2 = x * x;
				values.Add(2 * x2);
				values.Add(4 * x2);
			}
		}

		var n = long.Parse(Console.ReadLine());
		return values.Contains(n);
	}

	static HashSet<long> values;
}
