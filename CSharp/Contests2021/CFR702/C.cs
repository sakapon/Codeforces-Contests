using System;
using System.Linq;

class C
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		if (cubes == null)
		{
			cubes = new long[10000 + 1];
			for (long i = 1; i <= 10000; i++)
				cubes[i] = i * i * i;
		}

		var x = long.Parse(Console.ReadLine());

		for (long a = 1; a <= 10000; a++)
		{
			var b3 = x - cubes[a];

			// Excepts 0.
			if (Array.BinarySearch(cubes, b3) > 0)
			{
				return true;
			}
		}
		return false;
	}

	static long[] cubes;
}
