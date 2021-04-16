using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class D2
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
		var l = new Stack<int>();

		bool Dfs(int v)
		{
			for (int j = 0; j < k; j++)
			{
				if (u[v, j]) continue;
				u[v, j] = true;
				l.Push(j);

				if (l.Count == k2) return true;
				var r = Dfs(j);
				if (r) return true;

				u[v, j] = false;
				l.Pop();
			}
			return false;
		}

		Dfs(0);
		return string.Join("", l.Select(i => (char)(i + 'a')));
	}
}
