using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	//static void Main() => Console.WriteLine(Solve());
	//static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var raq = new StaticRAQ(n);
		for (int i = 0; i < n; i++)
		{
			if (a[i] > 0)
				raq.Add(i + 1 - a[i], i + 1, 1);
		}

		var r = raq.GetAll();
		return string.Join(" ", r.Select(x => x > 0 ? 1 : 0));
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
