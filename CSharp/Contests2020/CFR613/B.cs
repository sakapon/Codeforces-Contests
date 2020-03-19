using System;
using System.Collections.Generic;
using System.Linq;

class B
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var s = new long[n + 1];
		for (int i = 0; i < n; i++) s[i + 1] = s[i] + a[i];

		var q = new Queue<int>(s.Select((x, i) => (x: x, i: i)).OrderBy(_ => -_.x).Select(_ => _.i));
		var M = s.Skip(1).Take(n - 1).Max();
		for (int j, i = 1; i < n; i++)
		{
			while ((j = q.Peek()) <= i)
				q.Dequeue();
			M = Math.Max(M, s[j] - s[i]);
		}
		return M < s[n] ? "YES" : "NO";
	}
}
