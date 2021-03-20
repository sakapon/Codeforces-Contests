using System;
using System.Linq;

class B2
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var s = Console.ReadLine();

		var i1 = s.IndexOf("11");
		var i0 = s.LastIndexOf("00");
		return i1 == -1 || i0 == -1 || i1 > i0;
	}
}
