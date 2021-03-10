using System;

class C
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

		var (l, m, r) = (0, (n + 1) / 2, n + 1);
		var am = Query(m);
		int t;

		// Keep a[l] > a[m] < a[r].
		while (m - l > 1 || r - m > 1)
		{
			if (m - l >= r - m)
			{
				// left-side
				var v = Query(t = m - (m - l) / 2);
				if (v <= am)
				{
					(m, r) = (t, m);
					am = v;
				}
				else
				{
					l = t;
				}
			}
			else
			{
				// right-side
				var v = Query(t = m + (r - m) / 2);
				if (v <= am)
				{
					(m, l) = (t, m);
					am = v;
				}
				else
				{
					r = t;
				}
			}
		}

		return m;
	}
}
