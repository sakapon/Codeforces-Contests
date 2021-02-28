using System;
using System.Collections.Generic;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var (n, k) = Read2();
		var s = Console.ReadLine();

		if (s.Count(c => c == 'W') + k >= n) return 2 * n - 1;

		var gs = s.GroupCountsBySeq(c => c).ToList();
		if (gs.Any() && gs[0].Key == 'L') gs.RemoveAt(0);
		if (gs.Any() && gs[^1].Key == 'L') gs.RemoveAt(gs.Count - 1);

		var r = gs.Where(g => g.Key == 'W').Select(g => g.Value).Sum(x => 2 * x - 1);
		var a = gs.Where(g => g.Key == 'L').Select(g => g.Value).OrderBy(x => x).ToArray();
		foreach (var x in a)
		{
			if (k < x) break;
			k -= x;
			r += 2 * x + 1;
		}
		if (k > 0)
		{
			if (r > 0) r += 2 * k;
			else r += 2 * k - 1;
		}
		return r;
	}
}

static class GE
{
	public static IEnumerable<KeyValuePair<TK, int>> GroupCountsBySeq<TS, TK>(this IEnumerable<TS> source, Func<TS, TK> toKey)
	{
		var c = EqualityComparer<TK>.Default;
		TK k = default(TK), kt;
		var count = 0;

		foreach (var o in source)
		{
			if (!c.Equals(k, kt = toKey(o)))
			{
				if (count > 0) yield return new KeyValuePair<TK, int>(k, count);
				k = kt;
				count = 0;
			}
			++count;
		}
		if (count > 0) yield return new KeyValuePair<TK, int>(k, count);
	}
}
