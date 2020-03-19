using System;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var p2 = Enumerable.Range(0, 31).Select(i => 1 << i).ToArray();
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var i_max = -1;
		for (int k = 29; k >= 0 && i_max == -1; --k)
			for (int i = 0; i < n; ++i)
			{
				if ((a[i] & p2[k]) == 0) continue;
				if (i_max != -1) { i_max = -1; break; }
				i_max = i;
			}

		if (i_max != -1) Swap(a, 0, i_max);
		Console.WriteLine(string.Join(" ", a));
	}

	static void Swap<T>(T[] a, int i, int j) { var o = a[i]; a[i] = a[j]; a[j] = o; }
}
