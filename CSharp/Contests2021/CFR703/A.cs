using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var h = Read();

		long s = 0, t = 0;
		for (int i = 0; i < n; i++)
		{
			s += h[i];
			t += i;
			if (s < t) return false;
		}
		return true;
	}
}
