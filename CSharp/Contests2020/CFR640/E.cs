using System;
using System.Linq;

class E
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var b = new bool[8001];
		for (int i = 0; i < n; ++i)
			for (int j = i + 1, s = a[i]; j < n && (s += a[j]) <= 8000; ++j)
				b[s] = true;
		return a.Count(x => b[x]);
	}
}
