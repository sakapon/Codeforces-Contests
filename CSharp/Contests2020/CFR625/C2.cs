using System;
using System.Collections.Generic;

class C2
{
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var s = new LinkedList<char>(Console.ReadLine());

		for (char c = 'y'; c >= 'a'; c--)
		{
			for (var ln = s.First; ln != null; ln = ln.Next)
			{
				if (ln.Value != c) continue;

				while (ln.Previous?.Value == c + 1)
					s.Remove(ln.Previous);
				while (ln.Next?.Value == c + 1)
					s.Remove(ln.Next);
			}
		}
		return n - s.Count;
	}
}
