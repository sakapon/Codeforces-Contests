using System;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		Array.Sort(a);
		Array.Reverse(a);

		var (p0, p1) = (0L, 0L);
		for (int i = 0; i < n; i++)
		{
			if (i % 2 == 0)
			{
				if (a[i] % 2 == 0)
				{
					p0 += a[i];
				}
			}
			else
			{
				if (a[i] % 2 == 1)
				{
					p1 += a[i];
				}
			}
		}
		return p0 > p1 ? "Alice" : p0 < p1 ? "Bob" : "Tie";
	}
}
