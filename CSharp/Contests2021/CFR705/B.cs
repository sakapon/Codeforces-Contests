using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (h, m) = Read2();
		var s = Array.ConvertAll(Console.ReadLine().Split(':'), int.Parse);

		const string map = "015//2//8/";
		string Mirror(int x) => string.Join("", x.ToString("D2").Reverse().Select(c => map[c - '0']));

		bool IsValid(int i, int j)
		{
			var hs = Mirror(j);
			var ms = Mirror(i);

			if (hs.Contains('/') || ms.Contains('/')) return false;
			return int.Parse(hs) < h && int.Parse(ms) < m;
		}

		for (int j = s[1]; j < m; j++)
		{
			if (IsValid(s[0], j)) return $"{s[0]:D2}:{j:D2}";
		}
		for (int i = s[0] + 1; i < h; i++)
		{
			for (int j = 0; j < m; j++)
			{
				if (IsValid(i, j)) return $"{i:D2}:{j:D2}";
			}
		}
		return "00:00";
	}
}
