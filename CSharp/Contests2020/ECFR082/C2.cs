using System;
using System.Linq;

class C2
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var s = Console.ReadLine().Select(c => c - 'a').ToArray();

		var u = new int[26];
		u[s[0]] = 100;

		for (int i = 1; i < s.Length; i++)
		{
			var j = u[s[i - 1]];
			if (u[s[i]] == 0)
			{
				if (!u.Contains(j + 1)) u[s[i]] = j + 1;
				else if (!u.Contains(j - 1)) u[s[i]] = j - 1;
				else return "NO";
			}
			else
			{
				if (Math.Abs(u[s[i]] - j) != 1) return "NO";
			}
		}

		return "YES\n" + new string(u.Select((x, i) => new { x, i }).OrderBy(_ => _.x).Select(_ => (char)('a' + _.i)).ToArray());
	}
}
