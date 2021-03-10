using System;
using System.Collections.Generic;
using System.Linq;

class D2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		a = a.GroupCountsBySeq(x => x).Select(g => g.Key).ToArray();
		n = a.Length;

		var indexes = Array.ConvertAll(new bool[100001], _ => new List<int>());
		for (int i = 0; i < n; i++)
			indexes[a[i]].Add(i);

		var to = Array.ConvertAll(new bool[n], _ => -1);
		foreach (var l in indexes)
		{
			for (int i = 1; i < l.Count; i++)
				to[l[i - 1]] = l[i];
			//if (l.Any()) to[l.Last()] = n;
		}

		var from = Array.ConvertAll(new bool[n + 1], _ => -1);
		var dp = Array.ConvertAll(new bool[n + 1], _ => -1);
		dp[0] = 0;
		for (int i = 0; i < n; i++)
		{
			{
				var ni = i + 1;
				var nv = dp[i];
				if (dp[ni] < nv)
				{
					dp[ni] = nv;
					from[ni] = i;
				}
			}

			if (to[i] != -1)
			{
				var ni = to[i];
				var nv = dp[i] + 1;
				if (dp[ni] < nv)
				{
					dp[ni] = nv;
					from[ni] = i;
				}
			}
		}

		var a0 = new List<int>();
		var a1 = new List<int>();

		for (int i = n - 1; i >= 0; i = from[i])
		{
			if (!a0.Any() || a0.Last() != a[i]) a0.Add(a[i]);
			for (int j = i - 1; j > from[i]; j--)
				if (!a1.Any() || a1.Last() != a[j]) a1.Add(a[j]);
		}
		Console.WriteLine(a0.Count + a1.Count);
	}
}
