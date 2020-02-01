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
		var M = Array.BinarySearch(s, m);
		if (M < 0) M = ~M - 1;

		for (int i = 0; i < n; i++)
		{
			var t = Array.BinarySearch(s, m + a[i]);
			if (t < 0) t = ~t - 1;
			if (t - 1 < i) continue;
			t--;

			if (t > M)
			{
				r = i + 1;
				M = t;
			}
		}

		return r;
	}
}
