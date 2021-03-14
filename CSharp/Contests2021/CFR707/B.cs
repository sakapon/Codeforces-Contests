using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var raq = new StaticRAQ(n);
		for (int i = 0; i < n; i++)
			raq.Add(i + 1 - a[i], i + 1, 1);

		return string.Join(" ", raq.GetAll().Select(Math.Sign));
	}
}

class StaticRAQ
{
	long[] d;
	public StaticRAQ(int n) { d = new long[n]; }

	// O(1)
	// 範囲外のインデックスも可。
	public void Add(int l_in, int r_ex, long v)
	{
		if (l_in >= d.Length) return;
		d[Math.Max(0, l_in)] += v;
		if (r_ex < d.Length) d[r_ex] -= v;
	}

	// O(n)
	public long[] GetAll()
	{
		var a = new long[d.Length];
		a[0] = d[0];
		for (int i = 1; i < d.Length; ++i) a[i] = a[i - 1] + d[i];
		return a;
	}
}
