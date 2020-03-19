using System;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var ps = new int[n].Select(_ => Read()).OrderBy(p => p[0]).ThenBy(p => p[1]).ToList();

		var ys = ps.Select(p => p[1]).ToArray();
		if (!ys.OrderBy(y => y).SequenceEqual(ys)) return "NO";

		ps.Insert(0, new[] { 0, 0 });
		return "YES\n" + string.Join("", Enumerable.Range(0, n).Select(i => Move(ps[i], ps[i + 1])));
	}

	static string Move(int[] p, int[] q) => new string('R', q[0] - p[0]) + new string('U', q[1] - p[1]);
}
