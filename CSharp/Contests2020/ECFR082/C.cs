using System;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var s = Console.ReadLine();

		var t = $"{s[0]}";
		for (int i = 1; i < s.Length; i++)
		{
			var j = t.IndexOf(s[i]);
			if (j >= 0)
			{
				if (j > 0 && t[j - 1] == s[i - 1]) continue;
				if (j < t.Length - 1 && t[j + 1] == s[i - 1]) continue;
				return "NO";
			}
			else
			{
				if (t[0] == s[i - 1]) t = s[i] + t;
				else if (t.Last() == s[i - 1]) t += s[i];
				else return "NO";
			}
		}

		return "YES\n" + t + new string(Enumerable.Range(0, 26).Select(i => (char)('a' + i)).Except(t).ToArray());
	}
}
