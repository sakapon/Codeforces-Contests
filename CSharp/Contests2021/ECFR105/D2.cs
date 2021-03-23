using System;
using System.Collections.Generic;
using System.Linq;

class D2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Array.ConvertAll(new bool[n], _ => Read());

		var id = n;
		var salary = new int[2 * n];
		var es = new List<(int i, int j)>();

		var root = id++;
		var q = Lower(0, 1 << 30);
		Dfs(root, q);

		Queue<(int s, int[] lvs)> Lower(int i, int maxSalary)
		{
			var sub = Enumerable.Range(i, n - i)
				.Where(j => a[i][j] < maxSalary)
				.GroupBy(j => a[i][j])
				.Select(g => (s: g.Key, g.ToArray()))
				.OrderBy(t => -t.s);
			return new Queue<(int, int[])>(sub);
		}

		void Dfs(int v, Queue<(int s, int[] lvs)> q)
		{
			var (s, lvs) = q.Dequeue();
			salary[v] = s;

			if (!q.Any()) return;

			{
				var nv = q.Count == 1 ? q.Peek().lvs[0] : id++;
				es.Add((nv, v));
				Dfs(nv, q);
			}

			foreach (var lv in lvs)
			{
				if (salary[lv] > 0) continue;

				var q2 = Lower(lv, s);
				var nv = q2.Count == 1 ? q2.Peek().lvs[0] : id++;
				es.Add((nv, v));
				Dfs(nv, q2);
			}
		}

		Console.WriteLine(id);
		Console.WriteLine(string.Join(" ", salary.Take(id)));
		Console.WriteLine(root + 1);
		Console.WriteLine(string.Join("\n", es.Select(e => $"{e.i + 1} {e.j + 1}")));
	}
}
