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

		var l = new LinkedList<(int h, long b)>(hs.Zip(bs));

		for (var ln = l.Last.Previous; ln != null; ln = ln.Previous)
		{
			var ln2 = ln.Next;
			var (h1, b1) = ln.Value;
			var (h2, b2) = ln2.Value;

			if (b1 >= 0)
			{
				if (b2 >= 0) continue;
				if (h1 > h2) continue;
				l.Remove(ln2);
			}
			else
			{
				if (b2 >= 0)
				{
					if (h1 < h2) continue;
					l.Remove(ln);
					ln = ln2;
				}
				else
				{
					if (h1 > h2) (ln, ln2) = (ln2, ln);
					l.Remove(ln2);
				}
			}
		}

		for (var ln = l.Last.Previous; ln != null; ln = ln.Previous)
		{
			var ln2 = ln.Next;
			var (h1, b1) = ln.Value;
			var (h2, b2) = ln2.Value;

			if (b1 >= 0 && b2 >= 0)
			{
				ln.Value = (Math.Min(h1, h2), b1 + b2);
				l.Remove(ln2);
			}
		}

		{
			var ln = l.Last;
			if (ln.Value.b >= 0) ln = ln.Previous;

			for (; ln != null;)
			{
				var ln1 = ln.Previous?.Previous;
				var ln2 = ln.Next?.Next;
				var sum1 = ln1 == null || ln1.Value.h > ln.Value.h ? 0 : ln.Value.b + ln.Previous.Value.b;
				var sum2 = ln2 == null || ln2.Value.h > ln.Value.h ? 0 : ln.Value.b + ln.Next.Value.b;

				if (sum1 <= sum2 && sum1 < 0)
				{
					l.Remove(ln.Previous);
					l.Remove(ln);
					ln = ln2 != null ? ln2 : ln1;
				}
				else if (sum1 > sum2 && sum2 < 0)
				{
					l.Remove(ln.Next);
					l.Remove(ln);
					ln = ln2;
				}
				else
				{
					ln = ln1;
				}
			}
		}

		return l.Sum(t => t.b);
	}
}
