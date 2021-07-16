using System;
using System.Linq;

class F
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var r = Read();
		var c = Read();

		var ps = r.Zip(c).OrderBy(t => t.First).Prepend((1, 1)).ToArray();

		return Enumerable.Range(1, n).Sum(i =>
		{
			if (ps[i - 1] == ps[i]) return 0;

			var (r1, c1) = ps[i - 1];
			var (r2, c2) = ps[i];

			var groupDelta = (r2 - c2) / 2 - (r1 - c1) / 2;
			if (groupDelta > 0) return groupDelta;

			if ((r1 + c1) % 2 == 1 || (r2 + c2) % 2 == 1) return 0;
			return r2 - r1;
		});
	}
}
