using System;
using System.Linq;

class A2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, k) = Read2();

		var rn = Enumerable.Range(0, n + 1).ToArray();
		var r = rn[((k + 1) / 2)..k].Concat(rn[(k + 1)..]).ToArray();
		return $"{r.Length}\n{string.Join(" ", r)}";
	}
}
