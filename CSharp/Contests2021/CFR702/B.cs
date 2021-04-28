using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var n3 = n / 3;

		var c = new int[3];
		foreach (var g in a.GroupBy(x => x % 3))
		{
			c[g.Key] = g.Count();
		}

		var r = 0;
		for (int i = 0; i < 6; i++)
		{
			var i1 = i % 3;
			var i2 = (i + 1) % 3;

			if (c[i1] > n3)
			{
				var d = c[i1] - n3;
				r += d;
				c[i2] += d;
				c[i1] = n3;
			}
		}
		return r;
	}
}
