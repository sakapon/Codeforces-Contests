using System;
using System.Collections.Generic;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var r = new List<string>();

		for (int k = 0; k < n / 2; k++)
		{
			var ij = $"{2 * k + 1} {2 * k + 2}";
			r.Add("1 " + ij);
			r.Add("1 " + ij);
			r.Add("2 " + ij);
			r.Add("1 " + ij);
			r.Add("1 " + ij);
			r.Add("2 " + ij);
		}

		return $"{r.Count}\n" + string.Join("\n", r);
	}
}
