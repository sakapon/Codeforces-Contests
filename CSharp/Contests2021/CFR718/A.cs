using System;
using System.Linq;

class A
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = long.Parse(Console.ReadLine());

		var r = 0L;
		for (long d = 2050000000000000000; d >= 2050; d /= 10)
			r += Math.DivRem(n, d, out n);
		if (n > 0) return -1;
		return r;
	}
}
