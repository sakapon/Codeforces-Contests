using System;
using System.Collections.Generic;
using System.Linq;

class D2
{
	static void Main()
	{
		Func<int[]> read = () => Console.ReadLine().Split().Select(int.Parse).ToArray();
		var z = read();
		int n = z[0], m = z[1];

		var u = read().ToDictionary(x => x, x => 0L);
		var q = new Queue<int>(u.Keys);

		Func<int, int, bool> next = (x, x0) =>
		{
			if (u.ContainsKey(x)) return false;
			u[x] = u[x0] + 1;
			q.Enqueue(x);
			return u.Count == n + m;
		};
		while (true)
		{
			var x = q.Dequeue();
			if (next(x - 1, x)) break;
			if (next(x + 1, x)) break;
		}
		Console.WriteLine(u.Sum(p => p.Value));
		Console.WriteLine(string.Join(" ", u.Where(p => p.Value > 0).Select(p => p.Key)));
	}
}
