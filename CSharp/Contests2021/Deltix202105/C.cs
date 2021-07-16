using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Array.ConvertAll(new bool[n], _ => int.Parse(Console.ReadLine()));

		var r = new List<string> { "1" };
		var q = new Stack<int[]>();
		q.Push(new[] { 1 });

		for (int i = 1; i < n; i++)
		{
			var x = a[i];

			if (x == 1)
			{
				var nv = q.Peek().Append(1).ToArray();
				r.Add(string.Join(".", nv));
				q.Push(nv);
			}
			else
			{
				while (q.Peek()[^1] + 1 != x)
				{
					q.Pop();
				}

				var nv = q.Peek();
				nv[^1] = x;
				r.Add(string.Join(".", nv));
			}
		}

		return string.Join("\n", r);
	}
}
