using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int x, int y, int z) Read3() { var a = Read(); return (a[0], a[1], a[2]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var ps = Enumerable.Range(1, n).Select(i =>
		{
			var a = Read();
			return (i, x: a[0], y: a[1], z: a[2]);
		}).ToArray();

		var r = new List<(int i, int j)>();
		RemoveZ(ref ps);
		return string.Join("\n", r.Select(t => $"{t.i} {t.j}"));

		void RemoveZ(ref (int i, int x, int y, int z)[] a)
		{
			a = a.GroupBy(t => t.z)
				.OrderBy(g => g.Key)
				.Select(g =>
				{
					var sub = g.ToArray();
					RemoveY(ref sub);
					return sub;
				})
				.Where(sub => sub != null)
				.Select(sub => sub[0])
				.ToArray();

			var c = a.Length / 2;
			for (int k = 0; k < c; k++)
				r.Add((a[2 * k].i, a[2 * k + 1].i));
			a = a.Length % 2 == 0 ? null : new[] { a.Last() };
		}

		void RemoveY(ref (int i, int x, int y, int z)[] a)
		{
			a = a.GroupBy(t => t.y)
				.OrderBy(g => g.Key)
				.Select(g =>
				{
					var sub = g.ToArray();
					RemoveX(ref sub);
					return sub;
				})
				.Where(sub => sub != null)
				.Select(sub => sub[0])
				.ToArray();

			var c = a.Length / 2;
			for (int k = 0; k < c; k++)
				r.Add((a[2 * k].i, a[2 * k + 1].i));
			a = a.Length % 2 == 0 ? null : new[] { a.Last() };
		}

		void RemoveX(ref (int i, int x, int y, int z)[] a)
		{
			a = a.OrderBy(t => t.x).ToArray();
			var c = a.Length / 2;
			for (int k = 0; k < c; k++)
				r.Add((a[2 * k].i, a[2 * k + 1].i));
			a = a.Length % 2 == 0 ? null : new[] { a.Last() };
		}
	}
}
