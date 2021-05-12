using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (a, b) = Read2();
		var n = a + b;
		var s = Console.ReadLine().ToCharArray();

		void Decr(int i)
		{
			if (s[i] == '0') a--;
			if (s[i] == '1') b--;
		}

		// 対になる必要条件
		for (var (i, j) = (0, n - 1); i <= j; i++, j--)
		{
			if (i == j) continue;
			if (s[i] == s[j]) continue;
			if (s[i] != '?' && s[j] != '?') return -1;

			if (s[i] == '?')
				s[i] = s[j];
			else
				s[j] = s[i];
		}

		for (int i = 0; i < n; i++)
		{
			Decr(i);
		}

		if (a < 0 || b < 0) return -1;

		for (var (i, j) = (0, n - 1); i <= j; i++, j--)
		{
			if (s[i] != '?') continue;

			if (i == j)
			{
				if (a >= 1)
				{
					s[i] = '0';
				}
				else
				{
					s[i] = '1';
				}
				Decr(i);
			}
			else
			{
				if (a >= 2)
				{
					s[i] = s[j] = '0';
				}
				else if (b >= 2)
				{
					s[i] = s[j] = '1';
				}
				else
				{
					return -1;
				}
				Decr(i);
				Decr(j);
			}
		}

		return new string(s);
	}
}
