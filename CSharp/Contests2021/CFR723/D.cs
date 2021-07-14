using System;
using System.Linq;

class D
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var s = Console.ReadLine();
		var n = s.Length;

		var sa = s.ToCharArray();
		var d = s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
		var rd = Enumerable.Range(1, d.Count).ToArray();

		var max = -1L;
		char[] perm = null;

		Permutation(d.Keys.ToArray(), d.Count, p =>
		{
			var vMap = rd.ToDictionary(i => p[i - 1]);
			var s2 = Array.ConvertAll(sa, c => vMap[c]);

			var v = InversionNumber(n, s2);
			if (max < v)
			{
				max = v;
				perm = p.ToArray();
			}
		});

		return perm.Select(c => new string(c, d[c])).Aggregate((x, y) => x + y);
	}

	public static void Permutation<T>(T[] values, int r, Action<T[]> action)
	{
		var n = values.Length;
		var p = new T[r];
		var u = new bool[n];

		if (r > 0) Dfs(0);
		else action(p);

		void Dfs(int i)
		{
			var i2 = i + 1;
			for (int j = 0; j < n; ++j)
			{
				if (u[j]) continue;
				p[i] = values[j];
				u[j] = true;

				if (i2 < r) Dfs(i2);
				else action(p);

				u[j] = false;
			}
		}
	}

	public static long InversionNumber(int n, int[] a)
	{
		var r = 0L;
		var bit = new BIT(n);
		for (int i = 0; i < n; ++i)
		{
			r += i - bit.Sum(a[i]);
			bit.Add(a[i], 1);
		}
		return r;
	}
}

// 機能限定版
class BIT
{
	// Power of 2
	int n2 = 1;
	long[] a;

	public BIT(int n)
	{
		while (n2 < n) n2 <<= 1;
		a = new long[n2 + 1];
	}

	public long this[int i] => Sum(i) - Sum(i - 1);

	public void Add(int i, long v)
	{
		for (; i <= n2; i += i & -i) a[i] += v;
	}

	public long Sum(int r_in)
	{
		var r = 0L;
		for (var i = r_in; i > 0; i -= i & -i) r += a[i];
		return r;
	}
}
