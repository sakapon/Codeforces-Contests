using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var u = Read();
		var s = Read();

		var r = new long[n];

		foreach (var g in u.Zip(s).GroupBy(_ => _.First))
		{
			var a = g.Select(_ => _.Second).OrderBy(x => -x).ToArray();

			var m = a.Length;
			var cs = CumSumL(a);

			for (int k = 1; k <= m; k++)
			{
				var c = m - m % k;
				r[k - 1] += cs[c];
			}
		}

		return string.Join(" ", r);
	}

	static long[] CumSumL(int[] a)
	{
		var s = new long[a.Length + 1];
		for (int i = 0; i < a.Length; ++i) s[i + 1] = s[i] + a[i];
		return s;
	}
}
