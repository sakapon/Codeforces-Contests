using System;
using System.Collections.Generic;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main()
	{
		var (n, m) = Read2();
		var ss = Array.ConvertAll(new bool[n], _ => Console.ReadLine());

		var center = ss.FirstOrDefault(IsPalindrome) ?? "";

		var r = "";
		var set = new HashSet<string>();

		foreach (var s in ss)
			if (set.Contains(Reverse(s)))
				r += s;
			else
				set.Add(s);

		r = r + center + Reverse(r);
		Console.WriteLine(r.Length);
		Console.WriteLine(r);
	}

	static string Reverse(string s)
	{
		var c = s.ToCharArray();
		Array.Reverse(c);
		return new string(c);
	}

	static bool IsPalindrome(string s)
	{
		for (int i = 0; i < s.Length; ++i) if (s[i] != s[s.Length - 1 - i]) return false;
		return true;
	}
}
