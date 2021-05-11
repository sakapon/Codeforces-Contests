using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var c = Array.ConvertAll(new bool[n], _ => Console.ReadLine().ToCharArray());

		var rn = Enumerable.Range(0, n).ToArray();
		var ais = rn.Where(i => c[i].Contains('*')).ToArray();

		if (ais.Length == 1)
		{
			var ai = ais[0];
			var ti = ai == 0 ? 1 : 0;
			c[ti] = c[ai];
		}
		else
		{
			var ajs = ais.Select(i => Array.IndexOf(c[i], '*')).ToArray();
			if (ajs[0] == ajs[1])
			{
				var aj = ajs[0];
				var tj = aj == 0 ? 1 : 0;
				c[ais[0]][tj] = '*';
				c[ais[1]][tj] = '*';
			}
			else
			{
				foreach (var i in ais)
					foreach (var j in ajs)
						c[i][j] = '*';
			}
		}

		return string.Join("\n", c.Select(r => new string(r)));
	}
}
