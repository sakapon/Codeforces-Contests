using System;
using System.Linq;
using System.Text;

static class C
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
			var ci = s[i].ToIndexForLower();
			counts[ci]--;

			for (ci++; ci < 26; ci++)
			{
				counts[ci]++;

				var gap = n - 1 - i - Remain();
				if (gap >= 0)
				{
					var sb = new StringBuilder(s[..i]);
					sb.Append(ci.ToLower())
						.Append('a', gap);

					for (int cj = 0; cj < 26; cj++)
					{
						var x = counts[cj];
						if (x % k == 0) continue;
						sb.Append(cj.ToLower(), k - x % k);
					}
					return sb.ToString();
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

	static int ToIndexForLower(this char c) => c - 97;
	static char ToLower(this int i) => (char)(i + 97);
}
