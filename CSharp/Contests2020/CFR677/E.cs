using System;

class E
{
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		Console.WriteLine(Ncr(n, n / 2) / 2 * Factorial(n / 2 - 1) * Factorial(n / 2 - 1));
	}

	public static long Factorial(int n) { for (long x = 1, i = 1; ; x *= ++i) if (i >= n) return x; }
	public static long Npr(int n, int r)
	{
		if (n < r) return 0;
		for (long x = 1, i = n - r; ; x *= ++i) if (i >= n) return x;
	}
	public static long Ncr(int n, int r) => n < r ? 0 : n - r < r ? Ncr(n, n - r) : Npr(n, r) / Factorial(r);
}
