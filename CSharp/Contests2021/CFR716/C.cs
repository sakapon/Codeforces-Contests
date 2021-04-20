using System;
using System.Linq;

class C
{
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());

		var a = Enumerable.Range(1, n - 1).Where(i => Gcd(i, n) == 1).ToArray();
		var f = a.Aggregate(1L, (x, y) => x * y % n);
		if (f != 1) a = a.Where(i => i != f).ToArray();

		return $"{a.Length}\n" + string.Join(" ", a);
	}

	static int Gcd(int a, int b) { for (int r; (r = a % b) > 0; a = b, b = r) ; return b; }
}
