using System;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var h = Read();
		var n = h[0];
		var q = new int[h[1]].Select(_ => Read());

		var c = new bool[3, n + 2];
		var s = 0;

		Func<int[], bool> toggle = p =>
		{
			var f = c[p[0], p[1]];
			c[p[0], p[1]] = !f;

			var i = p[0] == 1 ? 2 : 1;
			for (int j = p[1] - 1; j <= p[1] + 1; j++)
				if (c[i, j])
					if (f) --s;
					else ++s;
			return s == 0;
		};
		Console.WriteLine(string.Join("\n", q.Select(p => toggle(p) ? "Yes" : "No")));
	}
}
