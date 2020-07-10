using System;
using System.Linq;

class D
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var s = Console.ReadLine().GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
		var m = int.Parse(Console.ReadLine());
		var b = Read();

		var t = new char[m];
		foreach (var p in s.OrderBy(p => -p.Key))
		{
			var dis = b.Select((d, i) => new { d, i }).Where(_ => _.d == 0).ToArray();
			if (dis.Length > p.Value) continue;

			foreach (var _ in dis)
			{
				var i = _.i;
				t[i] = p.Key;
				for (int j = 0; j < m; j++)
					b[j] -= Math.Abs(i - j);
				b[i]--;
			}
		}
		return new string(t);
	}
}
