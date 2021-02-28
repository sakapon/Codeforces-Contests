using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var exp = Enumerable.Range(1, n).ToArray();

		var r = new List<string>();

		while (!a.SequenceEqual(exp))
		{
			var o = ToOrder(a);
			for (int x = 1; x < n; x++)
			{
				if (o[x] < o[x + 1]) continue;

				var decks = new List<int[]>();
				if (o[x + 1] > 0) decks.Add(a[..o[x + 1]]);

				var t = o[x + 1] + 1;
				while (a[t - 1] + 1 == a[t])
				{
					t++;
				}
				decks.Add(a[o[x + 1]..t]);

				decks.Add(a[t..(o[x] + 1)]);
				if (o[x] + 1 < n) decks.Add(a[(o[x] + 1)..]);

				r.Add($"{decks.Count} " + string.Join(" ", decks.Select(v => v.Length)));

				decks.Reverse();
				a = decks.SelectMany(v => v).ToArray();

				break;
			}
		}

		Console.WriteLine(r.Count);
		foreach (var s in r) Console.WriteLine(s);
	}

	static int[] ToOrder(int[] a)
	{
		var c = new int[a.Length + 1];
		for (int i = 0; i < a.Length; i++) c[a[i]] = i;
		return c;
	}
}
