using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	struct P
	{
		public int p, x, d;
		public P(int _p, int _x, int _d) { p = _p; x = _x; d = _d; }
	}

	static void Main()
	{
		Func<int[]> read = () => Console.ReadLine().Split().Select(int.Parse).ToArray();
		var z = read();
		int n = z[0], m = z[1];
		var a = read();

		var u = new HashSet<int>(a);
		var q = new Queue<P>(a.Select(x => new P(x, x, -1)).Concat(a.Select(x => new P(x, x, 1))));
		var r = new List<int>();
		var sum = 0L;

		while (r.Count < m)
		{
			var p = q.Dequeue();
			var x = new P(p.p + p.d, p.x, p.d);
			if (u.Contains(x.p)) continue;
			u.Add(x.p);
			q.Enqueue(x);
			r.Add(x.p);
			sum += x.d * (x.p - x.x);
		}
		Console.WriteLine(sum);
		Console.WriteLine(string.Join(" ", r));
	}
}
