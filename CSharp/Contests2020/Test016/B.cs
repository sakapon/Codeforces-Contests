using System;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var r1 = Read();
		var r2 = Read();
		Array.Sort(r1);
		Array.Sort(r2);
		return r1[1] == r2[1] && r1[0] + r2[0] == r1[1] ? "YES" : "NO";
	}
}
