using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	//static void Main() => Console.WriteLine(Solve());
	//static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, x) = Read2();
		var w = Read();

		var sum = w.Sum();
		if (sum == x) return "NO";
		if (sum < x) return "YES\n" + string.Join(" ", w);

		Array.Sort(w);

		sum = 0;
		for (int i = 0; i < n; i++)
		{
			sum += w[i];
			if (sum == x)
			{
				(w[i], w[i + 1]) = (w[i + 1], w[i]);
				return "YES\n" + string.Join(" ", w);
			}
		}

		return "YES\n" + string.Join(" ", w);
	}
}
