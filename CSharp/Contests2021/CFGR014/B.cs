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
			values = new HashSet<int>();
			for (int x = 1; x * x <= 1000000000 / 2; x++)
			{
				var x2 = x * x;
				values.Add(2 * x2);
				values.Add(4 * x2);
			}
		}

		var n = int.Parse(Console.ReadLine());
		return values.Contains(n);
	}

	static HashSet<int> values;
}
