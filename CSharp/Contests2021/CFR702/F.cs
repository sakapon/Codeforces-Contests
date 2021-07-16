using System;
using System.Linq;

class F
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var counts = a.GroupBy(x => x).Select(g => g.Count()).Prepend(0).ToArray();
		Array.Sort(counts);
		var cs = CumSum(counts);

		return Enumerable.Range(0, counts.Length).Min(i => cs[^1] - counts[i] * (counts.Length - i));
	}

	public static int[] CumSum(int[] a)
	{
		var s = new int[a.Length + 1];
		for (int i = 0; i < a.Length; ++i) s[i + 1] = s[i] + a[i];
		return s;
	}
}
