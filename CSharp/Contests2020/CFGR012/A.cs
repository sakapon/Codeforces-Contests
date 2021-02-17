using System;
using System.Linq;

class A
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Console.ReadLine();
		return string.Join("", s.OrderBy(c => c));
	}
}
