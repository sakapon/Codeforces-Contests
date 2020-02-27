using System;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var nexts = Enumerable.Range(0, n - 1).Where(i => a[i] != -1 ^ a[i + 1] != -1).Select(i => a[i] != -1 ? a[i] : a[i + 1]).ToArray();
		if (!nexts.Any()) return "0 0";

		var k = (nexts.Max() + nexts.Min()) / 2;
		var b = Array.ConvertAll(a, x => x == -1 ? k : x);
		var m = Enumerable.Range(0, n - 1).Max(i => Math.Abs(b[i + 1] - b[i]));
		return $"{m} {k}";
	}
}
