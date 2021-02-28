using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		if (a.Distinct().Count() == 1) return "NO";

		var r = new List<string>();

		var v2 = 0;
		for (int i = 1; i < n; i++)
		{
			if (a[i] != a[0])
			{
				r.Add($"1 {i + 1}");
				v2 = i;
			}
		}
		for (int i = 1; i < n; i++)
		{
			if (a[i] == a[0])
			{
				r.Add($"{v2 + 1} {i + 1}");
			}
		}

		return "YES\n" + string.Join("\n", r);
	}
}
