using System;
using System.Collections.Generic;
using System.Linq;

class D2
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = new int[n].Select(_ => Console.ReadLine().Split().Skip(1).Select(int.Parse).ToArray()).ToArray();

		var items_kids = new List<int>[1000001];
		for (int i = 0; i < n; i++)
			foreach (var j in a[i])
				if (items_kids[j] == null) items_kids[j] = new List<int> { i };
				else items_kids[j].Add(i);

		var kids_inv = Array.ConvertAll(a, g => (MInt)1 / g.Length);

		MInt t = 0;
		foreach (var l in items_kids)
			if (l != null)
				t += l.Select(i => kids_inv[i]).Aggregate((x, y) => x + y) * l.Count;
		Console.WriteLine(t / n / n);
	}
}
