using System;
using System.Linq;

class A
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Console.ReadLine().Select(c => c - '0').ToList();

		while (s.Any() && s.Last() % 2 == 0)
			s.RemoveAt(s.Count - 1);
		if (!s.Any()) return "-1";

		if (s.Sum() % 2 == 0) return string.Join("", s);

		while (s.Any())
		{
			if (s[0] % 2 == 0) s.RemoveAt(0);
			else { s.RemoveAt(0); break; }
		}
		while (s.Any() && s[0] == 0)
			s.RemoveAt(0);

		if (!s.Any()) return "-1";
		return string.Join("", s);
	}
}
