using System;
using System.Collections.Generic;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var t = 0;
		var set = new HashSet<int>();

		for (int i = 0; i < n - 1; i++)
		{
			set.Add(t ^= a[i]);
		}

		foreach (var x in set)
		{
			t = 0;
			var c = 0;

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
