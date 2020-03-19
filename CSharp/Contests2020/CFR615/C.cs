using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var rn = (int)Math.Sqrt(n);

		var l = new List<int>();
		for (int i = 2; i <= rn; i++)
		{
			if (n % i != 0) continue;
			n /= i;
			if (n <= i) return "NO";
			l.Add(i);
			if (l.Count == 2) { l.Add(n); break; }
		}
		if (l.Count < 3) return "NO";
		return "YES\n" + string.Join(" ", l);
	}
}
