using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	struct P
	{
		public int x, d, v;
		public P(int _x, int _d, int _v) { x = _x; d = _d; v = _v; }
		public P Next => new P(x + v, d + 1, v);
	}

	static void Main()
	{
		Func<int[]> read = () => Console.ReadLine().Split().Select(int.Parse).ToArray();
		var z = read();
		int n = z[0], m = z[1];
		var a = read();

		var u = a.ToDictionary(x => x, x => 0L);
		var q = new Queue<P>(a.SelectMany(x => new[] { new P(x, 0, -1), new P(x, 0, 1) }));
		var r = new List<int>();

		while (r.Count < m)
		{
			var x = q.Dequeue().Next;
			if (u.ContainsKey(x.x)) continue;
			u[x.x] = x.d;
			q.Enqueue(x);
			r.Add(x.x);
		}
		Console.WriteLine(u.Sum(p => p.Value));
		Console.WriteLine(string.Join(" ", r));
	}
}
