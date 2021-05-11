using System;
using System.Linq;

class D
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var b = ReadL();

		Array.Sort(b);
		var sumn = b[..n].Sum();

		if (b[^2] == sumn) return string.Join(" ", b[..n]);

		var b2 = b[..(n + 1)];
		var d = sumn + b[^2] - b[^1];

		var i = Array.IndexOf(b2, d);
		if (i == -1) return -1;

		return string.Join(" ", b2.Where((v, j) => j != i));
	}
}
