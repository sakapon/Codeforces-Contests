using System;
using System.Collections.Generic;
using System.Linq;

class E
{
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

		map = new int[n].Select(_ => new List<int>()).ToArray();
		for (int x, i = 0; i < n; i++)
		{
			if ((x = i - a[i]) >= 0) map[x].Add(i);
			if ((x = i + a[i]) < n) map[x].Add(i);
		}

		var u0 = Array.ConvertAll(a, x => x % 2 == 0 ? 0 : -1);
		var u1 = Array.ConvertAll(a, x => x % 2 != 0 ? 0 : -1);
		Search(u0);
		Search(u1);
		Console.WriteLine(string.Join(" ", u0.Zip(u1, (x, y) => x + y)));
	}

	static List<int>[] map;

	static void Search(int[] u)
	{
		var q = new Queue<int>(Enumerable.Range(0, u.Length).Where(i => u[i] == 0));

		while (q.Any())
		{
			var p = q.Dequeue();
			foreach (var x in map[p])
			{
				if (u[x] >= 0) continue;
				u[x] = u[p] + 1;
				q.Enqueue(x);
			}
		}
	}
}
