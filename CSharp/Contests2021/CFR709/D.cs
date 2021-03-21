using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var r = new List<int>();
		var t = -1;
		var deleted = new bool[n];
		var next = Enumerable.Range(1, n).Select(i => i % n).ToArray();
		var q = new Queue<(int, int)>();

		for (int i = 0; i < n; i++)
		{
			var j = (i + 1) % n;
			if (Gcd(a[i], a[j]) == 1) q.Enqueue((i, j));
		}

		while (q.Any())
		{
			var (i, j) = q.Dequeue();
			if (deleted[i] || deleted[j]) continue;

			if (i == t)
			{
				q.Enqueue((i, j));
			}
			else
			{
				r.Add(j + 1);
				if (r.Count == n) break;

				t = j;
				deleted[j] = true;
				j = next[j];
				next[i] = j;
				if (Gcd(a[i], a[j]) == 1) q.Enqueue((i, j));
			}
		}

		if (r.Count == 0) return 0;
		return $"{r.Count} " + string.Join(" ", r);
	}

	static int Gcd(int a, int b) { for (int r; (r = a % b) > 0; a = b, b = r) ; return b; }
}
