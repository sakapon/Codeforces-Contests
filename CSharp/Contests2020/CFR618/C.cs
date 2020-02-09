using System;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var p2 = Enumerable.Range(0, 31).Select(i => 1 << i).ToArray();
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var indexes = Enumerable.Repeat(-1, 30).ToArray();
		for (int k = 0; k < 30; ++k)
		{
			for (int i = 0; i < n; ++i)
			{
				if ((a[i] & p2[k]) == 0) continue;
				if (indexes[k] != -1) { indexes[k] = -1; break; }
				indexes[k] = i;
			}
		}

		var o = indexes
			.Select((i, k) => new { i, k })
			.Where(_ => _.i != -1)
			.GroupBy(_ => _.i, _ => _.k)
			.Select(g => new { i = g.Key, v = g.Sum(k => p2[k]) })
			.OrderBy(_ => -_.v)
			.ToArray();
		var mi = o.Length == 0 ? 0 : o[0].i;

		Swap(a, 0, mi);
		Console.WriteLine(string.Join(" ", a));
	}

	static void Swap<T>(T[] a, int i, int j) { var o = a[i]; a[i] = a[j]; a[j] = o; }
}
