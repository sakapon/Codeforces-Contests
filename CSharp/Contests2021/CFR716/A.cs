using System;
using System.Collections.Generic;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		if (sqs == null) sqs = Enumerable.Range(1, 100).Select(x => x * x).ToHashSet();

		return a.Any(x => !sqs.Contains(x));
	}

	static HashSet<int> sqs;
}
