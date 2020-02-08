using System;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var h = Read();
		var n = h[0];
		var qs = new int[h[1]].Select(_ => Read()).ToArray();

		var c = new bool[3, n + 2];
		var s = 0;
		foreach (var q in qs)
		{
			var f = c[q[0], q[1]];
			c[q[0], q[1]] = !f;
			var i = q[0] == 1 ? 2 : 1;
			if (f)
			{
				for (int j = q[1] - 1; j <= q[1] + 1; j++)
					if (c[i, j]) --s;
			}
			else
			{
				for (int j = q[1] - 1; j <= q[1] + 1; j++)
					if (c[i, j]) ++s;
			}
			Console.WriteLine(s == 0 ? "Yes" : "No");
		}
	}
}
