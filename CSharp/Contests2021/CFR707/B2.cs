using System;
using System.Linq;

class B2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		for (int i = n - 2; i >= 0; i--)
			a[i] = Math.Max(a[i], a[i + 1] - 1);
		return string.Join(" ", a.Select(Math.Sign));
	}
}
