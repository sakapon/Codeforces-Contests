using System;
using System.Linq;

class E
{
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
		Array.Sort(a);

		var m = new bool[n + 2];
		var M = new bool[n + 2];

		foreach (var i in a)
		{
			if (Enumerable.Range(i - 1, 3).All(j => !m[j]))
				m[i + 1] = true;

			for (int j = i - 1; j <= i + 1; j++)
				if (!M[j]) { M[j] = true; break; }
		}
		Console.WriteLine($"{m.Count(x => x)} {M.Count(x => x)}");
	}
}
