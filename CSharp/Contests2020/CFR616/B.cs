using System;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var k1 = Enumerable.Range(0, n).TakeWhile(i => a[i] >= i).Count();
		Array.Reverse(a);
		var k2 = Enumerable.Range(0, n).TakeWhile(i => a[i] >= i).Count();

		return k1 + k2 >= n + 1 ? "Yes" : "No";
	}
}
