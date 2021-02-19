using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var h = Console.ReadLine().Split();
		var n = int.Parse(h[0]);
		var s = h[1];

		var min = Enumerable.Range(1, n).Reverse().ToArray();
		var max = new List<int>();

		var min_s = -1;

		for (int i = 0; i < s.Length; i++)
		{
			if (s[i] == '>')
			{
				if (min_s == -1) continue;

				Array.Reverse(min, min_s, i - min_s + 1);
				min_s = -1;
			}
			else
			{
				if (min_s == -1) min_s = i;
				max.AddRange(Enumerable.Range(max.Count + 1, i + 1 - max.Count).Reverse());
			}
		}

		if (min_s != -1) Array.Reverse(min, min_s, n - min_s);
		max.AddRange(Enumerable.Range(max.Count + 1, n - max.Count).Reverse());

		return string.Join(" ", min) + "\n" + string.Join(" ", max);
	}
}
