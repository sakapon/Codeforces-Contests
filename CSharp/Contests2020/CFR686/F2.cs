using System;
using System.Collections.Generic;
using System.Linq;

class F2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var map = new CompressionHashMap(a);
		a = map.Compressed;
		var b = a.Reverse().ToArray();
		var max = map.Count - 1;

		string ReturnValue(int x, int y, int z)
		{
			var r = $"YES\n{x} {y} {z}";
			//var mx = map.Raw.Take(x).Max();
			//var my = map.Raw.Skip(x).Take(y).Min();
			//var mz = map.Raw.Skip(x + y).Take(z).Max();
			//if (mx != my || my != mz)
			//	r += $"\n  {n}\n  " + string.Join(" ", map.Raw);
			return r;
		}

		// 最大値が3つ以上含まれている場合
		var maxIndexes = Enumerable.Range(0, n).Where(i => a[i] == max).ToArray();
		if (maxIndexes.Length >= 3) return ReturnValue(maxIndexes[1], 1, n - maxIndexes[1] - 1);
		// 最小値
		if (a[0] == 0 && a[^1] == 0 && a.Count(v => v == 0) >= 3) return ReturnValue(1, n - 2, 1);

		var max1 = a.CumMax();
		var max2 = b.CumMax();

		(int x, bool dup)[] Tally(int[] a, int[] cummax)
		{
			var r = new (int, bool)[map.Count];
			for (int i = 1; i < n; i++)
			{
				var v = cummax[i];
				if (v < cummax[i + 1])
				{
					var dup = cummax[i - 1] == v && a[i - 1] == v;
					r[v] = (dup ? i - 1 : i, dup);
				}
			}
			return r;
		}

		var t1 = Tally(a, max1);
		var t2 = Tally(b, max2);

		// [l, r]
		var (l, r) = (maxIndexes[0], maxIndexes[^1]);
		// y = r - l + 1;
		var min = a.Skip(l).Take(r - l + 1).Min();

		for (int m = max - 1; m >= 0; m--)
		{
			if (t1[m].x > 0)
			{
				var nl = t1[m].x;
				while (nl < l) min = Math.Min(min, a[--l]);
			}
			if (t2[m].x > 0)
			{
				var nr = n - t2[m].x - 1;
				while (r < nr) min = Math.Min(min, a[++r]);
			}

			if (t1[m].x > 0 && t2[m].x > 0 && m == min)
				return ReturnValue(t1[m].x, r - l + 1, t2[m].x);

			while (max1[l] >= m) min = Math.Min(min, a[--l]);
			while (max2[n - r - 1] >= m) min = Math.Min(min, a[++r]);
		}

		return "NO";
	}
}

public class CompressionHashMap
{
	public int[] Raw { get; }
	public int[] ReverseMap { get; }
	public Dictionary<int, int> Map { get; }
	public int this[int v] => Map[v];
	public int Count => ReverseMap.Length;

	int[] c;
	public int[] Compressed => c ??= Array.ConvertAll(Raw, v => Map[v]);

	public CompressionHashMap(int[] a)
	{
		// r = a.Distinct().OrderBy(v => v).ToArray();
		var hs = new HashSet<int>();
		foreach (var v in a) hs.Add(v);
		var r = new int[hs.Count];
		hs.CopyTo(r);
		Array.Sort(r);
		var map = new Dictionary<int, int>();
		for (int i = 0; i < r.Length; ++i) map[r[i]] = i;

		(Raw, ReverseMap, Map) = (a, r, map);
	}
}

//static class Seq
//{
//	public static TR[] Cumulate<TS, TR>(this TS[] a, TR r0, Func<TR, TS, TR> func)
//	{
//		var r = new TR[a.Length + 1];
//		r[0] = r0;
//		for (int i = 0; i < a.Length; ++i) r[i + 1] = func(r[i], a[i]);
//		return r;
//	}
//	public static int[] CumMax(this int[] a, int v0 = int.MinValue) => Cumulate(a, v0, Math.Max);
//	public static int[] CumMin(this int[] a, int v0 = int.MaxValue) => Cumulate(a, v0, Math.Min);
//}
