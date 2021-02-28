using System;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var d = a.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
		var k1 = d.Count == n ? "1" : "0";

		int l = 0, r = 1;
		for (int i = 1; i < n; i++)
		{
			if (!d.ContainsKey(i)) return new string('0', n + 1 - i) + new string('1', i - 1);
			if (a[l] != i && a[^r] != i || d[i] > 1) return k1 + new string('0', n - 1 - i) + new string('1', i);
			if (a[l] == i) l++;
			else r++;
		}
		return new string('1', n);
	}
}
