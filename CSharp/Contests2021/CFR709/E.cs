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

		// 負の建物が低い建物に含まれる場合の部分和
		var segs = new List<(int l, int r, long b)>();

		// 負の建物が右側の低い建物に含まれる場合の部分和
		// h は単調増加
		var qr = new Stack<(int l, int h, long b)>();
		qr.Push((-1, 0, 0));

		for (int i = 0; i < n; i++)
		{
			var (h, b) = (hs[i], bs[i]);

			while (qr.Peek().h > h)
			{
				var (l0, h0, b0) = qr.Pop();
				if (b0 < 0) segs.Add((l0, i - 1, b0));

				var (lt, ht, bt) = qr.Pop();
				qr.Push((lt, ht, bt + b0));
			}

			if (b >= 0)
			{
				var (lt, ht, bt) = qr.Pop();
				qr.Push((lt, ht, bt + b));
			}
			else
			{
				qr.Push((i, h, b));
			}
		}

		// 負の建物が左側の低い建物に含まれる場合の部分和
		// h は単調増加
		var ql = new Stack<(int r, int h, long b)>();
		ql.Push((n, 0, 0));

		for (int i = n - 1; i >= 0; i--)
		{
			var (h, b) = (hs[i], bs[i]);

			while (ql.Peek().h > h)
			{
				var (r0, h0, b0) = ql.Pop();
				if (b0 < 0) segs.Add((i + 1, r0, b0));

				var (rt, ht, bt) = ql.Pop();
				ql.Push((rt, ht, bt + b0));
			}

			if (b >= 0)
			{
				var (rt, ht, bt) = ql.Pop();
				ql.Push((rt, ht, bt + b));
			}
			else
			{
				ql.Push((i, h, b));
			}
		}

		var q = new Queue<(int l, int r, long b)>(segs.OrderBy(t => t.l));
		q.Enqueue((n, n, 0));

		var dp = new long[n + 1];

		for (int i = 0; i < n; i++)
		{
			dp[i + 1] = Math.Min(dp[i + 1], dp[i]);

			while (q.Peek().l == i)
			{
				var (l, r, b) = q.Dequeue();
				dp[r + 1] = Math.Min(dp[r + 1], dp[i] + b);
			}
		}

		return bs.Sum() - dp[n];
	}
}
