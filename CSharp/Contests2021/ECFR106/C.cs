using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
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
		var s = new CumSum(c);
		var min = 1L << 30;

		for (int i = 0; i < c.Length; i++)
		{
			min = Math.Min(min, c[i]);
			r[i] = s.Sum(0, i + 1) + (n - 1 - i) * min;
		}
		return r;
	}
}

class CumSum
{
	long[] s;
	public CumSum(int[] a)
	{
		s = new long[a.Length + 1];
		for (int i = 0; i < a.Length; ++i) s[i + 1] = s[i] + a[i];
	}
	public long Sum(int l_in, int r_ex) => s[r_ex] - s[l_in];
}
