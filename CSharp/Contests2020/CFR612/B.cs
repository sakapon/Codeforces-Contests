using System;
using System.Collections.Generic;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var h = Read();
		int n = h[0], k = h[1];
		var c = new int[n].Select(_ => Console.ReadLine()).ToArray();

		d = new Dictionary<int, char> { { 'S' + 'E', 'T' }, { 'E' + 'T', 'S' }, { 'T' + 'S', 'E' } };
		var set = new HashSet<string>(c);
		var rk = Enumerable.Range(0, k).ToArray();

		var r = 0;
		for (int i = 0; i < n; i++)
			for (int j = i + 1; j < n; j++)
			{
				var s = new string(rk.Select(l => Another(c[i][l], c[j][l])).ToArray());
				if (set.Contains(s)) r++;
			}
		Console.WriteLine(r / 3);
	}

	static Dictionary<int, char> d;
	static char Another(char c1, char c2) => c1 == c2 ? c1 : d[c1 + c2];
}
