using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var (n, k) = Read2();

		if (k == 1) return new string('a', n);

		var unit = GetUnit(k);

		var sb = new StringBuilder();
		while (sb.Length < n)
		{
			sb.Append(unit);
		}
		sb.Remove(n, sb.Length - n);
		return sb.ToString();
	}

	static string GetUnit(int k)
	{
		var k2 = k * k;

		var u = new bool[k, k];
		var l = new List<int> { 0 };

		for (int p = 1, t = 0; p < k2; p++)
		{
			for (int j = k - 1; j >= 0; j--)
			{
				if (u[t, j]) continue;
				u[t, j] = true;
				l.Add(t = j);
				break;
			}
		}
		return string.Join("", l.Select(i => (char)(i + 'a')));
	}
}
