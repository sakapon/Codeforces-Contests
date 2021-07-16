using System;
using System.Linq;

class A
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var s = Console.ReadLine();
		var n = s.Length;

		if (n % 2 != 0) return false;

		foreach (var a in "()")
		{
			var sa = s.Replace('A', a);
			foreach (var b in "()")
			{
				var sb = sa.Replace('B', b);
				foreach (var c in "()")
				{
					var sc = sb.Replace('C', c);
					if (IsRegularBracket(sc))
						return true;
				}
			}
		}
		return false;
	}

	static bool IsRegularBracket(string s)
	{
		var t = 0;
		foreach (var c in s)
			if (c == '(') ++t;
			else if (c == ')') if (--t < 0) return false;
		return t == 0;
	}
}
