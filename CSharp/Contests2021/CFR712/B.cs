using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	//static void Main() => Console.WriteLine(Solve());
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	//static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static bool Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Console.ReadLine();
		var b = Console.ReadLine();

		var s = new int[n + 1];
		for (int i = 0; i < n; ++i)
			s[i + 1] = s[i] + (a[i] == '0' ? -1 : 1);

		var rn = Enumerable.Range(0, n + 1).ToArray();
		var seg = rn.Where(i => s[i] == 0).ToArray();

		for (int i = 1; i < seg.Length; i++)
		{
			if (!IsAllSame(seg[i - 1], seg[i]) && !IsAllDiff(seg[i - 1], seg[i])) return false;
		}
		return IsAllSame(seg[^1], n);

		bool IsAllSame(int l, int r)
		{
			for (int i = l; i < r; i++)
			{
				if (a[i] != b[i]) return false;
			}
			return true;
		}

		bool IsAllDiff(int l, int r)
		{
			for (int i = l; i < r; i++)
			{
				if (a[i] == b[i]) return false;
			}
			return true;
		}
	}

	public static int[] CumSum(int[] a)
	{
		var s = new int[a.Length + 1];
		for (int i = 0; i < a.Length; ++i) s[i + 1] = s[i] + a[i];
		return s;
	}
}
