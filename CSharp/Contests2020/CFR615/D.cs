using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var h = Read();
		var x = h[1];
		var q = new int[h[0]].Select(_ => int.Parse(Console.ReadLine()) % x);

		var r = new List<int>();
		var t = 0;
		var rem = new int[x];
		foreach (var y in q)
		{
			++rem[y];
			while (rem[t % x] > 0)
				--rem[t++ % x];
			r.Add(t);
		}
		Console.WriteLine(string.Join("\n", r));
	}
}
