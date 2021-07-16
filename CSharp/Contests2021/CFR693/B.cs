using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var sum = a.Sum();

		if (sum % 2 != 0) return false;
		if (sum % 4 == 0) return true;
		return a.Contains(1);
	}
}
