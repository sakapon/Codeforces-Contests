using System;

class CL
{
	static int Query(int i)
	{
		Console.WriteLine($"? {i}");
		return int.Parse(Console.ReadLine());
	}
	static void Main() => Console.WriteLine($"! {Solve()}");
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());

		var a = new int[n + 1];
		int Get(int i) => a[i] > 0 ? a[i] : a[i] = Query(i);

		return ArgTrue(0, n + 1, (m, o) => Get(m) < Get(o));
	}

	// (inside, outside) => isInsideMore
	static int ArgTrue(int l, int r, Func<int, int, bool> f)
	{
		var m = l + (r - l) / 2;
		int t;

		while (m - l > 1 || r - m > 1)
			if (m - l >= r - m)
			{
				if (f(t = m - (m - l) / 2, m)) (m, r) = (t, m);
				else l = t;
			}
			else
			{
				if (f(t = m + (r - m) / 2, m)) (m, l) = (t, m);
				else r = t;
			}
		return m;
	}
}
