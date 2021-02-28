using System;

class E2
{
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		Console.WriteLine(Factorial(n - 1) * 2 / n);
	}

	static long Factorial(int n) { for (long x = 1, i = 1; ; x *= ++i) if (i >= n) return x; }
}
