using System;
using System.Linq;

class B
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Console.ReadLine();

		var ct = s.Count(c => c == 'T');
		var cm = s.Count(c => c == 'M');
		if (ct != 2 * cm) return false;

		var rev = s.ToCharArray();
		Array.Reverse(rev);
		return Try(s.ToCharArray(), cm) && Try(rev, cm);
	}

	static bool Try(char[] s, int cm)
	{
		var ct = 0;
		var l = 0;
		for (int k = 1; k <= cm; k++, l++)
		{
			for (; s[l] == 'T'; l++)
			{
				ct++;
			}

			if (ct < k) return false;
		}
		return true;
	}
}
