using System;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var h = Read();
		var k = h[1];
		var a = Read();
		var b = Read();
		Array.Sort(a);
		Array.Sort(b);
		Array.Reverse(b);

		for (int i = 0; i < k && a[i] < b[i]; i++)
			a[i] = b[i];
		return a.Sum();
	}
}
