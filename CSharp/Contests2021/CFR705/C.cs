using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, k) = Read2();
		var s = Console.ReadLine();

		if (n % k != 0) return -1;

		var counts = Tally(s);
		int Remain() => counts.Sum(x => x % k == 0 ? 0 : k - x % k);

		if (Remain() == 0) return s;

		for (int i = n - 1; i >= 0; i--)
		{
			var ci = s[i] - 97;
			counts[ci]--;

			for (ci++; ci < 26; ci++)
			{
				counts[ci]++;

				if (Remain() < n - i)
				{
					var l = new List<char>();

					for (int cj = 0; cj < 26; cj++)
					{
						var x = counts[cj];
						if (x % k == 0) continue;
						l.AddRange(Enumerable.Repeat((char)(cj + 97), k - x % k));
					}
					if (l.Count < n - i)
						l.InsertRange(0, Enumerable.Repeat('a', n - 1 - i - l.Count));
					l.Insert(0, (char)(ci + 97));
					l.InsertRange(0, s[..i]);

					return new string(l.ToArray());
				}
				counts[ci]--;
			}
		}

		return -1;
	}

	static int[] Tally(string s)
	{
		var c = new int[26];
		foreach (var x in s) ++c[x - 97];
		return c;
	}
}
