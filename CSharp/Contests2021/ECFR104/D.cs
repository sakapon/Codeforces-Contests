using System;
using System.Linq;

class D
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = long.Parse(Console.ReadLine());

		var r = 0;
		for (long x = 3; ; x += 2)
		{
			var c = (x * x + 1) / 2;
			if (c > n) return r;
			r++;
		}
	}
}
