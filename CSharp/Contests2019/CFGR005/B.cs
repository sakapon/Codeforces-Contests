using System;
using System.Collections.Generic;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();
		var b = Read();

		var r = 0;
		var q = new Queue<int>(b);
		var u = new bool[n + 1];

		foreach (var x in a)
		{
			if (u[x]) continue;

			while (q.Peek() != x)
			{
				var y = q.Dequeue();
				if (u[y]) continue;

				r++;
				u[y] = true;
			}

			q.Dequeue();
			u[x] = true;
		}
		return r;
	}
}
