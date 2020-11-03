using System;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var h = Read();
		int n = h[0], m = h[1];
		var ps = Array.ConvertAll(new int[n], _ => new[] { Read(), Read() });

		if (m % 2 == 1) return "NO";

		if (m == 2)
		{
			return ps.Any(p => p[0][1] == p[1][0]) ? "YES" : "NO";
		}
		else
		{
			if (!ps.Any(p => p[0][1] == p[1][0])) return "NO";

			for (int i = 0; i < n; i++)
			{
				var pi = ps[i];
				for (int j = i; j < n; j++)
				{
					var pj = ps[j];
					if (pi[0][0] == pj[0][0] && pi[1][1] == pj[1][1] && pi[0][1] == pj[1][0] && pi[1][0] == pj[0][1])
					{
						return "YES";
					}

				}
			}
			return "NO";
		}
	}
}
