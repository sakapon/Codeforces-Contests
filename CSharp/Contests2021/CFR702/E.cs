using System;
using System.Linq;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var b = a.ToArray();
		Array.Sort(b);
		var cs = CumSumL(b);

		var min = b[^1];

		// Whether defeat i
		for (int i = n - 1; i >= 0; i--)
		{
			if (cs[i] < b[i])
			{
				break;
			}
			else
			{
				min = b[i - 1];
			}
		}

		var r = Enumerable.Range(1, n).Where(i => a[i - 1] >= min).ToArray();
		return r.Length + "\n" + string.Join(" ", r);
	}

	public static long[] CumSumL(int[] a)
	{
		var s = new long[a.Length + 1];
		for (int i = 0; i < a.Length; ++i) s[i + 1] = s[i] + a[i];
		return s;
	}
}
