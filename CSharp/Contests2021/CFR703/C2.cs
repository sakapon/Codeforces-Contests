using System;

class C2
{
	static void Main() => Console.WriteLine($"! {Solve()}");
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());

		var s = Query(1, n);

		if (1 < s && Query(1, s) == s)
			return Last(1, s - 1, x => Query(x, s) == s);
		else
			return First(s + 1, n, x => Query(s, x) == s);
	}

	static int Query(int l, int r)
	{
		Console.WriteLine($"? {l} {r}");
		return int.Parse(Console.ReadLine());
	}

	static int First(int l, int r, Func<int, bool> f)
	{
		int m;
		while (l < r) if (f(m = l + (r - l - 1) / 2)) r = m; else l = m + 1;
		return r;
	}

	static int Last(int l, int r, Func<int, bool> f)
	{
		int m;
		while (l < r) if (f(m = r - (r - l - 1) / 2)) l = m; else r = m - 1;
		return l;
	}
}
