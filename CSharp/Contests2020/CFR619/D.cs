using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var h = Read();
		int n = h[0], m = h[1], k = h[2];

		if (k > 4 * n * m - 2 * n - 2 * m) { Console.WriteLine("NO"); return; }

		var r = new List<string>();
		foreach (var s in GetPath(n, m))
		{
			if (s.f == 0) continue;
			if (s.f < k)
			{
				k -= s.f;
				r.Add($"{s.f} {s.move}");
			}
			else
			{
				r.Add($"{k} {s.move}");
				break;
			}
		}

		Console.WriteLine("YES");
		Console.WriteLine(r.Count);
		Console.WriteLine(string.Join("\n", r));
	}

	static IEnumerable<Step> GetPath(int n, int m)
	{
		for (int i = 1; i < m; i++)
		{
			yield return new Step(1, "R");
			yield return new Step(n - 1, "D");
			yield return new Step(n - 1, "U");
		}
		yield return new Step(m - 1, "L");

		for (int i = 1; i < n; i++)
		{
			yield return new Step(1, "D");
			yield return new Step(m - 1, "R");
			yield return new Step(m - 1, "L");
		}
		yield return new Step(n - 1, "U");
	}

	struct Step
	{
		public int f;
		public string move;
		public Step(int _f, string _move) { f = _f; move = _move; }
	}
}
