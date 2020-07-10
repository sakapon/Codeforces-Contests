using System;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var h = Read();
		int n = h[0], k = h[1];
		var s = Console.ReadLine();

		var z = s.Split('1').Select(x => x.Length).ToArray();
		if (z.Length == 0) return 0;
		if (z.Length == 1) return (z[0] + k) / (k + 1);
		return z[0] / (k + 1) + z.Last() / (k + 1) + z.Skip(1).Take(z.Length - 2).Sum(x => (x - k) / (k + 1));
	}
}
