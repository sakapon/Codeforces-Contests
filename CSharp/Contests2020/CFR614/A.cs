using System;
using System.Collections.Generic;
using System.Linq;

class A
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var h = Read();
		int n = h[0], s = h[1];
		var a = new HashSet<int>(Read());

		for (int t, i = 0; ; i++)
		{
			if ((t = s - i) > 0 && !a.Contains(t)) return i;
			if ((t = s + i) <= n && !a.Contains(t)) return i;
		}
	}
}
