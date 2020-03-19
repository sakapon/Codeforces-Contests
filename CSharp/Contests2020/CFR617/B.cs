using System;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var s = int.Parse(Console.ReadLine());

		var r = 0L;
		while (s > 0)
		{
			var x = s < 10 ? s : s - s % 10;
			r += x;
			s = s - x + x / 10;
		}
		return r;
	}
}
