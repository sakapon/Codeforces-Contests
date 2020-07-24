using System;
using System.Collections.Generic;
using System.Linq;

class A
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());

		var l = new List<int>();
		for (int d = 10, r; n > 0; d *= 10)
		{
			n -= r = n % d;
			if (r > 0) l.Add(r);
		}
		return $"{l.Count}\n{string.Join(" ", l)}";
	}
}
