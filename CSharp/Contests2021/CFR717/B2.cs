using System;
using System.Linq;

class B2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var u = 0;
		for (int i = 0; i < n; i++)
		{
			u ^= a[i];
			var t = 0;
			var c = 1;

			for (int j = i + 1; j < n; j++)
			{
				t ^= a[j];
				if (t == u)
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
