using System;
using System.Linq;

class B2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (h, m) = Read2();
		var s = Array.ConvertAll(Console.ReadLine().Split(':'), int.Parse);

		const string map = "015//2//8/";
		int Mirror(int x) => int.Parse(string.Join("", x.ToString("D2").Reverse().Select(c => map[c - 48])));
		bool IsValid1(int i) => !i.ToString().Select(c => map[c - 48]).Contains('/');
		bool IsValid2(int i, int j) => Mirror(j) < h && Mirror(i) < m;

		(int, int) Find()
		{
			for (int i = s[0]; i <= s[0]; i++)
			{
				if (!IsValid1(i)) continue;
				for (int j = s[1]; j < m; j++)
				{
					if (!IsValid1(j)) continue;
					if (!IsValid2(i, j)) continue;
					return (i, j);
				}
			}
			for (int i = s[0] + 1; i < h; i++)
			{
				if (!IsValid1(i)) continue;
				for (int j = 0; j < m; j++)
				{
					if (!IsValid1(j)) continue;
					if (!IsValid2(i, j)) continue;
					return (i, j);
				}
			}
			return (0, 0);
		}

		var (i, j) = Find();
		return $"{i:D2}:{j:D2}";
	}
}
