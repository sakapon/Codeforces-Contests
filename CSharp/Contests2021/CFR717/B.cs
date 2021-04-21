using System;
using System.Collections.Generic;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var t = a[0];
		var set = new HashSet<int> { t };

		for (int i = 1; i < n - 1; i++)
		{
			t ^= a[i];
			set.Add(t);
		}

		foreach (var x in set.ToArray())
		{
			var c = 0;
			t = 0;

			for (int i = 0; i < n; i++)
			{
				t ^= a[i];
				if (t == x)
				{
					t = 0;
					c++;
				}
			}

			if (t == 0 && c >= 2) return true;
		}
		return false;
	}
}
