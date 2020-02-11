using System;
using System.Linq;

class B2
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var s1 = new long[n + 1];
		for (int i = 0; i < n; i++)
			if ((s1[i + 1] = s1[i] + a[i]) <= 0) return "NO";

		var s2 = new long[n + 1];
		for (int i = n - 1; i >= 0; i--)
			if ((s2[i] = s2[i + 1] + a[i]) <= 0) return "NO";

		return "YES";
	}
}
