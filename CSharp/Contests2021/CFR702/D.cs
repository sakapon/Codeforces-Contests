using System;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var ds = new int[n];
		Dfs(0, n, 0);

		void Dfs(int l, int r, int d)
		{
			if (l == r) return;

			var mi = l + a[l..r].FirstArgMax();
			ds[mi] = d;
			Dfs(l, mi, d + 1);
			Dfs(mi + 1, r, d + 1);
		}

		return string.Join(" ", ds);
	}
}

static class ArrayHelper
{
	public static int FirstArgMax(this int[] a)
	{
		if (a.Length == 0) throw new ArgumentException();
		var (mi, mv) = (0, a[0]);
		for (int i = 1; i < a.Length; i++)
			if (mv < a[i]) (mi, mv) = (i, a[i]);
		return mi;
	}
}
