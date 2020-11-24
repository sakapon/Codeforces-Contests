using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		Console.ReadLine();
		var s = Console.ReadLine();
		//var (n, m) = Read2();
		var n = int.Parse(Console.ReadLine());
		var a = Read();
		var ps = Array.ConvertAll(new bool[n], _ => Read());

		var r = 0L;
		return r;
	}
}
