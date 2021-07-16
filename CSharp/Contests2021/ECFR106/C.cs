using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var c = Read();

		var c0 = c.Where((v, i) => i % 2 == 0).ToArray();
		var c1 = c.Where((v, i) => i % 2 == 1).ToArray();

		var s0 = Sum(n, c0);
		var s1 = Sum(n, c1);

		var r = 1L << 60;
		for (int i = 0; i < s1.Length; i++)
			r = Math.Min(r, s0[i] + s1[i]);
		for (int i = 1; i < s0.Length; i++)
			r = Math.Min(r, s0[i] + s1[i - 1]);
		return r;
	}

	static long[] Sum(int n, int[] c)
	{
		var r = new long[c.Length];
		var s = 0L;
		var min = 1L << 30;

		for (int i = 0; i < c.Length; i++)
		{
			s += c[i];
			min = Math.Min(min, c[i]);
			r[i] = s + (n - 1 - i) * min;
		}
		return r;
	}
}
