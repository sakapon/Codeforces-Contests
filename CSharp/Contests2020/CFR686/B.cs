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

		var t = a.Select((x, i) => (x, i: i + 1)).GroupBy(v => v.x).Where(g => g.Count() == 1).OrderBy(g => g.Key).FirstOrDefault()?.First();
		return t?.i ?? -1;
	}
}
