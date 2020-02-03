using System;
using System.Collections.Generic;
using System.Linq;

class B2
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var h = Read();
		int n = h[0], k = h[1];
		var c = new int[n].Select(_ => Console.ReadLine()).OrderBy(x => x).ToArray();

		var set = new HashSet<string>(c);
		var rk = Enumerable.Range(0, k).ToArray();

		var r = 0;
		for (int i = 0; i < n; i++)
			for (int j = i + 1; j < n; j++)
			{
				var s = new string(Array.ConvertAll(rk, l => Another(c[i][l], c[j][l])));
				if (set.Contains(s) && c[j].CompareTo(s) < 0) r++;
			}
		Console.WriteLine(r);
	}

	static int se = 'S' + 'E', et = 'E' + 'T';
	static char Another(char c1, char c2) => c1 == c2 ? c1 : c1 + c2 == se ? 'T' : c1 + c2 == et ? 'S' : 'E';
}
