using System;
using System.Collections.Generic;
using System.Linq;

class C2
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		if (cubes == null) cubes = Enumerable.Range(1, 10000).Select(i => (long)i * i * i).ToHashSet();

		var x = long.Parse(Console.ReadLine());
		return Enumerable.Range(1, 10000).Any(a => cubes.Contains(x - (long)a * a * a));
	}

	static HashSet<long> cubes;
}
