using System;
using System.Collections.Generic;
using System.Linq;

class E
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static (long, long) Read2L() { var a = ReadL(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, k) = ((int, long))Read2L();

		var p2 = Pows2L();
		var r = new List<int>();

		try
		{
			Dfs(1, k);
		}
		catch (Exception)
		{
			return -1;
		}

		return string.Join(" ", r);

		void Dfs(int sn, long k2)
		{
			if (sn > n) return;
			if (n - sn < 63 && p2[n - sn] < k2) throw new InvalidOperationException();

			if (n - sn >= 63)
			{
				r.Add(sn);
				Dfs(sn + 1, k2);
				return;
			}

			var length = n - sn + 1;
			var k_rev = p2[n - sn] - k2;

			for (int i = 0; i < length; i++)
			{
				if (k_rev < p2[i])
				{
					r.AddRange(Enumerable.Range(sn, length - i).Reverse());
					Dfs(sn + length - i, k2 - p2[length - 1] + p2[i]);
					break;
				}
			}
		}
	}

	static long[] Pows2L() => Enumerable.Range(0, 63).Select(i => 1L << i).ToArray();
}
