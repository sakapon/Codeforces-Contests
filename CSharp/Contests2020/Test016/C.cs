using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var s = Console.ReadLine();

		long x = 0, y = 0;
		Action<char> move = c =>
		{
			switch (c)
			{
				case 'S': --y; break;
				case 'N': ++y; break;
				case 'W': --x; break;
				case 'E': ++x; break;
			}
		};

		var l = new List<long>();
		foreach (var c in s)
		{
			move(c);
			l.Add(x * (1 << 20) + y);
			move(c);
		}
		return l.GroupBy(v => v).Sum(g => g.Count() + 4);
	}
}
