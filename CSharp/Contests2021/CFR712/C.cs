using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	//static void Main() => Console.WriteLine(Solve());
	//static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Console.ReadLine();

		var c0 = s.Count(c => c == '0');
		var c1 = n - c0;

		if (c0 % 2 != 0) return "NO";
		if (s[0] != '1') return "NO";
		if (s[^1] != '1') return "NO";

		var rn = Enumerable.Range(0, n).ToArray();
		var r1 = new char[n];
		foreach (var j in rn.Where(i => s[i] == '1').Take(c1 / 2))
			r1[j] = '(';
		foreach (var j in rn.Where(i => s[i] == '1').Skip(c1 / 2))
			r1[j] = ')';

		var r2 = (char[])r1.Clone();

		var f = false;
		for (int i = 0; i < n; i++)
		{
			if (s[i] == '1') continue;
			r1[i] = f ? '(' : ')';
			r2[i] = f ? ')' : '(';
			f = !f;
		}

		return "YES\n" + $"{new string(r1)}\n{new string(r2)}";
	}
}
