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

		if (a.Sum() == 0) return "NO";

		Array.Sort(a);
		if (a.Where(x => x > 0).Sum() > -a.Where(x => x < 0).Sum())
			Array.Reverse(a);
		return "YES\n" + string.Join(" ", a);
	}
}
