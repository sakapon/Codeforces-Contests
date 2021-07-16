using System;

class C1
{
	static void Main() => Console.WriteLine($"! {Solve()}");
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());

		var (l, r) = (1, n);
		var m = -1;
		var p2 = -1;

		while (l < r)
		{
			p2 = Query(l, r);

			if (r - l == 1)
			{
				return p2 == l ? r : l;
			}

			m = l + (r - l - 1) / 2;
			// 存在するほうを尋ねる
			if (p2 <= m)
			{
				if (m - l >= 1 && Query(l, m) == p2) r = m;
				else l = m + 1;
			}
			else
			{
				if (r - m - 1 >= 1 && Query(m + 1, r) == p2) l = m + 1;
				else r = m;
			}
		}
		return l;
	}

	static int Query(int l, int r)
	{
		Console.WriteLine($"? {l} {r}");
		return int.Parse(Console.ReadLine());
	}
}
