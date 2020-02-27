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

		if (a.All(x => x == -1)) return "0 0";

		var diffs = Enumerable.Range(0, n - 1).Where(i => a[i] != -1 && a[i + 1] != -1).Select(i => Math.Abs(a[i + 1] - a[i])).ToArray();
		var nexts = Enumerable.Range(0, n - 1).Where(i => a[i] != -1 ^ a[i + 1] != -1).Select(i => a[i] != -1 ? a[i] : a[i + 1]).ToArray();

		var max = nexts.Max();
		var min = nexts.Min();
		var k = (max + min) / 2;
		var m = (max - min + 1) / 2;
		if (diffs.Any()) m = Math.Max(m, diffs.Max());

		return $"{m} {k}";
	}
}
