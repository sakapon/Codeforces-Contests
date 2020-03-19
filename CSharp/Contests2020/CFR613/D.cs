using System;
using System.Linq;

class D
{
	static void Main()
	{
		p2 = Enumerable.Range(0, 31).Select(i => 1 << i).ToArray();
		var n = int.Parse(Console.ReadLine());
		var a = Console.ReadLine().Split().Select(int.Parse).Distinct().ToArray();

		Console.WriteLine(Dfs(a, 29));
	}

	static int[] p2;

	static int Dfs(int[] a, int k)
	{
		if (a.Length == 1) return 0;
		if (k == 0) return 1;

		var a0 = Array.FindAll(a, x => (x & p2[k]) == 0);
		var a1 = Array.FindAll(a, x => (x & p2[k]) != 0);

		if (a0.Length == 0) return Dfs(a1, k - 1);
		if (a1.Length == 0) return Dfs(a0, k - 1);
		return p2[k] | Math.Min(Dfs(a0, k - 1), Dfs(a1, k - 1));
	}
}
