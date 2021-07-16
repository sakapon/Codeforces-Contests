using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		Array.Sort(a);
		return string.Join(" ", Enumerable.Range(0, 2 * n).Select(i => a[i / 2 + (i % 2 == 0 ? 0 : n)]));
	}
}
