using System;
using System.Linq;

class D
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var z = Read();
		int n = z[0], a = z[1], b = z[2], k = z[3], ab = a + b;
		var h = Read();

		h = h.Select(x => (x - 1) % ab / a).OrderBy(x => x).ToArray();

		var s = new long[n + 1];
		for (int i = 0; i < n; i++) s[i + 1] = s[i] + h[i];

		Console.WriteLine(Enumerable.Range(0, n + 1).TakeWhile(i => s[i] <= k).Last());
	}
}
