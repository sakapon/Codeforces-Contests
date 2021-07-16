using System;
using System.Linq;

class C
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static (long x, long y) Read2L() { var a = ReadL(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var ps = Array.ConvertAll(new bool[2 * n], _ => Read2L());

		var xs = ps.Where(p => p.y == 0).Select(p => Math.Abs(p.x)).ToArray();
		var ys = ps.Where(p => p.x == 0).Select(p => Math.Abs(p.y)).ToArray();
		Array.Sort(xs);
		Array.Sort(ys);

		return xs.Zip(ys, (x, y) => Math.Sqrt(x * x + y * y)).Sum();
	}
}
