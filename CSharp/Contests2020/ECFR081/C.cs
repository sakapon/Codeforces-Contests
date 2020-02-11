using System;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		var s = Console.ReadLine();
		var t = Console.ReadLine();

		var d = s.Select((c, i) => new { c, i }).GroupBy(_ => _.c, _ => _.i).ToDictionary(g => g.Key, g => g.ToArray());
		int turn = 1, index = 0;

		foreach (var c in t)
		{
			if (!d.ContainsKey(c)) return -1;
			var i2 = Array.BinarySearch(d[c], index);
			if (i2 < 0) i2 = ~i2;
			if (i2 < d[c].Length)
			{
				index = d[c][i2] + 1;
			}
			else
			{
				turn++;
				index = d[c][0] + 1;
			}
		}
		return turn;
	}
}
