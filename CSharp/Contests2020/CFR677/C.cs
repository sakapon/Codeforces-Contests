using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		if (a.Distinct().Count() == 1) return -1;

		var oa = a.Select((x, i) => (x, i)).OrderBy(v => -v.x).ToArray();

		foreach (var (x, i) in oa)
		{
			if (i > 0 && a[i - 1] < a[i] || i + 1 < n && a[i] > a[i + 1])
			{
				return i + 1;
			}
		}
		return -1;
	}
}
