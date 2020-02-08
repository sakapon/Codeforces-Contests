using System;
using System.Linq;

class A
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		Console.ReadLine();
		var s = new string(Console.ReadLine().Where(c => (c - '0') % 2 == 1).Take(2).ToArray());
		return s.Length < 2 ? "-1" : s;
	}
}
