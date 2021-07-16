using System;
using System.Linq;

class B3
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

		for (var (i, j) = (s[0], s[1]); ;)
		{
			if (IsValid1(i) && IsValid1(j) && IsValid2(i, j))
				return $"{i:D2}:{j:D2}";

			if (++j == m)
			{
				j = 0;
				if (++i == h) i = 0;
			}
		}
	}
}
