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
		var s = Console.ReadLine();
		var n = s.Length;

		if (s.All(c => c == 'a')) return "NO";

		var si = Enumerable.Range(0, n).First(i => s[i] != 'a');
		if (si >= n / 2) si++;
		s = s.Insert(n - si, "a");
		return "YES\n" + s;
	}
}
