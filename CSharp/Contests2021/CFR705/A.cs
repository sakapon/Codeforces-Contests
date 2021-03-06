using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, k) = Read2();

		var r = Enumerable.Range((k + 1) / 2, k / 2).Concat(Enumerable.Range(k + 1, n - k)).ToArray();
		return $"{r.Length}\n{string.Join(" ", r)}";
	}
}
