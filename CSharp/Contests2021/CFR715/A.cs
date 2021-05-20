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

		var a0 = Array.FindAll(a, x => x % 2 == 0);
		var a1 = Array.FindAll(a, x => x % 2 == 1);
		return string.Join(" ", a0.Concat(a1));
	}
}
