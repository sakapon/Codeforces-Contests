using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var h = Read();
		int n = h[0], m = h[1];
		var ps = Array.ConvertAll(new bool[n], _ => new[] { Read(), Read() });

		if (m % 2 == 1) return false;
		return ps.Any(p => p[0][1] == p[1][0]);
	}
}
