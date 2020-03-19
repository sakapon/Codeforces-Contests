using System;
using System.Collections.Generic;
using System.Linq;

class C2
{
	struct P
	{
		public int i, j;
		public P(int _i, int _j) { i = _i; j = _j; }
		public P Next(char c) => new P(c == 'L' ? i - 1 : c == 'R' ? i + 1 : i, c == 'D' ? j - 1 : c == 'U' ? j + 1 : j);
		public override string ToString() => $"{i} {j}";
	}

	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Console.ReadLine();

		var d = new Dictionary<string, List<int>>();
		var p = new P(0, 0);
		d[p.ToString()] = new List<int> { 0 };

		for (int i = 0; i < n; i++)
		{
			p = p.Next(s[i]);
			var id = p.ToString();
			if (d.ContainsKey(id)) d[id].Add(i + 1);
			else d[id] = new List<int> { i + 1 };
		}

		int m = int.MaxValue, l = 0, r = 0;
		foreach (var u in d.Values)
			if (u.Count >= 2)
				for (int t, i = 1; i < u.Count; i++)
					if ((t = u[i] - u[i - 1]) < m)
					{
						m = t;
						l = u[i - 1];
						r = u[i];
					}
		return m == int.MaxValue ? "-1" : $"{l + 1} {r}";
	}
}
