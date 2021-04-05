using System;
using System.Linq;

class A2
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var s = Console.ReadLine();
		var n = s.Length;

		if (s.All(c => c == 'a')) return "NO";

		var s1 = s + 'a';
		var s2 = 'a' + s;
		return "YES\n" + (IsPalindrome(s1) ? s2 : s1);
	}

	static bool IsPalindrome(string s)
	{
		for (int i = 0; i < s.Length; ++i) if (s[i] != s[s.Length - 1 - i]) return false;
		return true;
	}
}
