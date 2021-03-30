using System;
using System.Collections.Generic;
using System.Linq;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var r1 = a.ToArray();
		var r2 = a.ToArray();

		var q1 = new Queue<int>();
		var q2 = PQ<int>.Create(true);
		var t = 0;

		for (int i = 0; i < n; i++)
		{
			if (t == a[i])
			{
				r1[i] = q1.Dequeue();
				r2[i] = q2.Pop();
			}
			else
			{
				for (t++; t < a[i]; t++)
				{
					q1.Enqueue(t);
					q2.Push(t);
				}
			}
		}

		return string.Join(" ", r1) + "\n" + string.Join(" ", r2);
	}
}
