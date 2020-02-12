using System;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var s = Console.ReadLine();

		var t = "".ToList();
		t.Add(s[0]);
		var u = new bool[26];
		u[s[0] - 'a'] = true;

		for (int i = 1; i < s.Length; i++)
		{
			if (u[s[i] - 'a'])
			{
				var j = t.IndexOf(s[i]);
				if ((j == 0 || t[j - 1] != s[i - 1]) && (j == t.Count - 1 || t[j + 1] != s[i - 1])) return "NO";
			}
			else
			{
				if (t[0] == s[i - 1])
				{
					t.Insert(0, s[i]);
				}
				else if (t.Last() == s[i - 1])
				{
					t.Add(s[i]);
				}
				else
				{
					return "NO";
				}
				u[s[i] - 'a'] = true;
			}
		}

		return "YES\n" + new string(t.ToArray()) + new string(Enumerable.Range(0, 26).Where(i => !u[i]).Select(i => (char)('a' + i)).ToArray());
	}
}
