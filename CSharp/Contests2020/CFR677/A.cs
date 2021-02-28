using System;
using System.Linq;

class A
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var s = Console.ReadLine();

		var c = new[] { 1, 3, 6, 10 };
		return 10 * (s[0] - '1') + c[s.Length - 1];
	}
}
