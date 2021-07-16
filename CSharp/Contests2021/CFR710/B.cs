using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, k) = Read2();
		var s = Console.ReadLine();

		var sc = s.Count(c => c == '*');
		if (sc <= 2) return sc;

		var start = s.IndexOf('*');
		var end = s.LastIndexOf('*');

		var r = 1;
		for (int i = start; i < end; i = SearchLastStar(i))
			r++;
		return r;

		int SearchLastStar(int si)
		{
			for (int i = Math.Min(n - 1, si + k); i > si; i--)
				if (s[i] == '*') return i;
			throw new InvalidOperationException();
		}
	}
}
