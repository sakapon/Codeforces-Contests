using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		if (a.Sum() == 0) return "NO";

		var a_pos = a.Where(x => x > 0).ToArray();
		var a_neg = a.Where(x => x < 0).ToArray();
		var a_0 = a.Where(x => x == 0).ToArray();

		var sum_pos = a_pos.Sum();
		var sum_neg = a_neg.Sum();

		if (sum_pos > -sum_neg)
			return "YES\n" + string.Join(" ", a_pos.Concat(a_neg).Concat(a_0));
		else
			return "YES\n" + string.Join(" ", a_neg.Concat(a_pos).Concat(a_0));
	}
}
