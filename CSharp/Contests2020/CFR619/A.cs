using System;
using System.Linq;

class A
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var a = Console.ReadLine();
		var b = Console.ReadLine();
		var c = Console.ReadLine();

		return Enumerable.Range(0, a.Length).All(i => a[i] == c[i] || b[i] == c[i]) ? "YES" : "NO";
	}
}
