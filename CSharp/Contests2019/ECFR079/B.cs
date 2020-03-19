using System;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve(Read(), Read()))));
	static int Solve(int[] h, int[] a)
	{
		int n = h[0], m = h[1];

		var s = new long[n + 1];
		for (int i = 0; i < n; i++) s[i + 1] = s[i] + a[i];

		var r = 0;
		var M = Search(s, m);

		for (int j, i = 0; i < n; i++)
		{
			if ((j = Search(s, m + a[i]) - 1) < i) break;

			if (j > M)
			{
				r = i + 1;
				M = j;
			}
		}
		return r;
	}

	static int Search(long[] s, int v)
	{
		var i = Array.BinarySearch(s, v);
		return i >= 0 ? i : ~i - 1;
	}
}
