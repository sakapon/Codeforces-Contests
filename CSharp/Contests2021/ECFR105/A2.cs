using System;
using System.Linq;

class A2
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var s = Console.ReadLine();
		var n = s.Length;

		if (s[0] == s[^1]) return false;

		s = s.Replace(s[0], '(');
		s = s.Replace(s[^1], ')');

		var upper = s.FirstOrDefault(char.IsUpper);
		if (upper == 0)
		{
			return IsRegularBracket(s);
		}
		else
		{
			var sl = s.Replace(upper, '(');
			var sr = s.Replace(upper, ')');
			return IsRegularBracket(sl) || IsRegularBracket(sr);
		}
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
