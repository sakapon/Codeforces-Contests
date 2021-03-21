using System;
using System.Linq;

class C
{
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Console.ReadLine().ToList();

		for (char c = 'z'; c > 'a'; c--)
		{
			while (true)
			{
				var ok = false;
				for (int i = 0; i < s.Count; i++)
				{
					if (HasPrevious(i, c))
					{
						s.RemoveAt(i);
						ok = true;
						break;
					}
				}
				if (!ok) break;
			}
		}
		return n - s.Count;

		bool HasPrevious(int i, char c)
		{
			if (s[i] != c) return false;
			if (i - 1 >= 0 && s[i - 1] == c - 1) return true;
			if (i + 1 < s.Count && s[i + 1] == c - 1) return true;
			return false;
		}
	}
}
