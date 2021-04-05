using System;
using System.Linq;

class A
{
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Array.ConvertAll(new bool[n], _ => int.Parse(Console.ReadLine()));

		var b = new int[n];
		for (int i = 0; i < n; i++)
			b[i] = (a[i] + 800) / 2 - 400;

		var odds = Enumerable.Range(0, n).Where(i => a[i] % 2 != 0).ToArray();
		foreach (var i in odds.Take(odds.Length / 2))
			b[i]++;

		return string.Join("\n", b);
	}
}
