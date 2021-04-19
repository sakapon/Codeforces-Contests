using System;
using System.Collections.Generic;
using System.Linq;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var hs = Read();
		var bs = ReadL();

		(int h, long b)[] hbs = hs.Zip(bs).ToArray();

		// 負の建物が低い建物に含まれる場合の部分和
		var segs = NegativeSegments(hbs);

		Array.Reverse(hbs);
		var segs_r = NegativeSegments(hbs);
		segs.AddRange(segs_r.Select(t => (n - t.r, n - t.l, t.b)));

		var q = new Queue<(int l, int r, long b)>(segs.OrderBy(t => t.l));
		q.Enqueue((n, n, 0));

		var dp = new long[n + 1];

		for (int i = 0; i < n; i++)
		{
			dp[i + 1] = Math.Min(dp[i + 1], dp[i]);

			while (q.Peek().l == i)
			{
				var (l, r, b) = q.Dequeue();
				dp[r] = Math.Min(dp[r], dp[i] + b);
			}
		}

		return bs.Sum() - dp[n];
	}

	// 負の建物が右側の低い建物に含まれる場合の部分和
	// [l, r)
	static List<(int l, int r, long b)> NegativeSegments((int h, long b)[] hbs)
	{
		var n = hbs.Length;
		var segs = new List<(int l, int r, long b)>();

		// h は単調増加
		var q = new Stack<(int l, int h, long b)>();
		q.Push((-1, 0, 0));

		for (int i = 0; i < n; i++)
		{
			var (h, b) = hbs[i];

			while (q.Peek().h > h)
			{
				var (l0, h0, b0) = q.Pop();
				if (b0 < 0) segs.Add((l0, i, b0));

				var (lt, ht, bt) = q.Pop();
				q.Push((lt, ht, bt + b0));
			}

			if (b >= 0)
			{
				var (lt, ht, bt) = q.Pop();
				q.Push((lt, ht, bt + b));
			}
			else
			{
				q.Push((i, h, b));
			}
		}
		return segs;
	}
}
