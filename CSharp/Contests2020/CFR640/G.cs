using System;
using System.Collections.Generic;
using System.Linq;

class G
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		if (n < 4) return "-1";

		var l = new List<int>();
		for (int i = 1; i <= n; i += 2) l.Add(i);
		l.Reverse();
		l.Add(4);
		l.Add(2);
		for (int i = 6; i <= n; i += 2) l.Add(i);
		return string.Join(" ", l);
	}
}
