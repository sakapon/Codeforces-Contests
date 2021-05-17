using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		if (Enumerable.Range(1, n).SequenceEqual(a)) return 0;
		if (a[0] == 1 || a[^1] == n) return 1;
		if (a[0] != n || a[^1] != 1) return 2;
		return 3;
	}
}
