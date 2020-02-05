using System;
using System.Collections.Generic;
using System.Linq;

class E
{
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Console.ReadLine().Select((c, i) => (c: c, i: i)).ToArray();

		map = new int[n].Select(_ => new List<int>()).ToArray();
		for (int i = 0; i < n; i++)
			for (int j = n - 1; j > i; j--)
				if (s[j - 1].CompareTo(s[j]) > 0)
				{
					map[s[j - 1].i].Add(s[j].i);
					map[s[j].i].Add(s[j - 1].i);
					Swap(s, j - 1, j);
				}

		u = Enumerable.Repeat(-1, n).ToArray();
		var ok = true;
		for (int i = 0; i < n; i++)
			if (u[i] == -1)
				ok &= Search(i);
		Console.WriteLine(ok ? $"YES\n{new string(u.Select(x => x < 1 ? '0' : '1').ToArray())}" : "NO");
	}

	static void Swap<T>(T[] a, int i, int j) { var o = a[i]; a[i] = a[j]; a[j] = o; }

	static List<int>[] map;
	static int[] u;

	static bool Search(int sp)
	{
		var q = new Queue<int>();
		u[sp] = 0;
		q.Enqueue(sp);

		while (q.Any())
		{
			var p = q.Dequeue();
			var v = u[p] ^ 1;
			foreach (var x in map[p])
			{
				if (u[x] == v) continue;
				if (u[x] > -1) return false;
				u[x] = v;
				q.Enqueue(x);
			}
		}
		return true;
	}
}
