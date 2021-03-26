using System;
using System.Linq;

class B3
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var ranges = a.Select((v, i) => (i + 1 - v, i + 1)).ToArray();
		var r = TallyRanges(ranges, n - 1);
		return string.Join(" ", r.Select(b => b ? 1 : 0));
	}

	// 値の範囲が比較的小さい場合に使います。
	static bool[] TallyRanges((int l_in, int r_ex)[] ranges, int max)
	{
		// ソート済である場合は不要です。
		ranges = ranges.OrderBy(t => t.l_in).ToArray();

		var b = new bool[max + 1];
		var i = 0;
		foreach (var (l, r) in ranges)
			for (i = Math.Max(i, l); i < r && i <= max; ++i)
				b[i] = true;
		return b;
	}
}
