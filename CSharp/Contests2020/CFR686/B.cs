using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var g = a.Select((x, i) => (x, i)).GroupBy(v => v.x).OrderBy(g => g.Key).FirstOrDefault(g => g.Count() == 1);
		return g == null ? -1 : g.First().i + 1;
	}
}
