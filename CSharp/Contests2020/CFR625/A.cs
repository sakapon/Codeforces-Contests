using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var r = Read();
		var b = Read();

		var w = Enumerable.Range(0, n).Count(i => r[i] == 1 && b[i] == 0);
		var l = Enumerable.Range(0, n).Count(i => r[i] == 0 && b[i] == 1);

		if (w == 0) return -1;
		return l / w + 1;
	}
}
