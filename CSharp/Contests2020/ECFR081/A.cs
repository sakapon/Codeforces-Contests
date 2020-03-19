using System;
using System.Linq;

class A
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var c1 = n / 2 - 1;
		return (n - 2 * c1 == 2 ? "1" : "7") + new string('1', c1);
	}
}
