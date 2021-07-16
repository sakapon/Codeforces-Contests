using System;
using System.Linq;

class B2
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Console.ReadLine();

		var rn = Enumerable.Range(0, n).ToArray();

		var it = rn.Where(i => s[i] == 'T').ToArray();
		var im = rn.Where(i => s[i] == 'M').ToArray();
		if (it.Length != 2 * im.Length) return false;

		var m = im.Length;
		var rm = Enumerable.Range(0, m).ToArray();
		return rm.All(i => it[i] < im[i] && im[i] < it[m + i]);
	}
}
