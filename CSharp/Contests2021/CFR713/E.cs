using System;
using System.Linq;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int, int, int) Read4() { var a = Read(); return (a[0], a[1], a[2], a[3]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, l, r, s) = Read4();

		var sub = GetBySum(n, r - l + 1, s);
		if (sub == null) return -1;
		var rem = Enumerable.Range(1, n).Except(sub).ToArray();
		return string.Join(" ", rem[..(l - 1)].Concat(sub).Concat(rem[(l - 1)..]));
	}

	// m: length
	static int[] GetBySum(int n, int m, int s)
	{
		var d = n - m;
		var a = Enumerable.Range(1, m).ToArray();

		s -= m * (m + 1) / 2;
		if (s < 0) return null;
		if (s > d * m) return null;

		for (int i = m - 1; i >= 0; i--)
		{
			var t = Math.Min(s, d);
			a[i] += t;
			s -= t;
		}

		return a;
	}
}
