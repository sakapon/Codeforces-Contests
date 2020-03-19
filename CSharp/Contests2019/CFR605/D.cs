using System;
using System.Linq;

class D
{
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

		var s1 = new int[n];
		s1[0] = 1;
		var s2 = new int[n];
		s2[n - 1] = 1;

		for (int i = 1; i < n; i++)
			s1[i] = a[i - 1] < a[i] ? s1[i - 1] + 1 : 1;
		for (int i = n - 1; i > 0; i--)
			s2[i - 1] = a[i - 1] < a[i] ? s2[i] + 1 : 1;
		var M = s1.Max();

		for (int i = 1; i < n - 1; i++)
			if (a[i - 1] < a[i + 1])
				M = Math.Max(M, s1[i - 1] + s2[i + 1]);
		Console.WriteLine(M);
	}
}
