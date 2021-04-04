using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var n2 = n * n;

		var qs = Array.ConvertAll(new bool[2], _ => new Queue<(int i, int j)>());
		for (int i = 1; i <= n; i++)
			for (int j = 1; j <= n; j++)
				qs[(i + j) % 2].Enqueue((i, j));

		var a0 = 0;
		int[] b01 = null;

		for (int k = 0; k < n2; k++)
		{
			var a = int.Parse(Console.ReadLine());
			if (k == 0)
			{
				a0 = a;
				b01 = Array.FindAll(new[] { 1, 2, 3 }, x => x != a);
			}

			var (b, i, j) = Next(a);
			Console.WriteLine($"{b} {i} {j }");
		}

		(int b, int i, int j) Next(int a)
		{
			if (a == a0)
			{
				if (qs[0].Any())
				{
					var (i, j) = qs[0].Dequeue();
					return (b01[0], i, j);
				}
				else
				{
					var (i, j) = qs[1].Dequeue();
					return (b01[1], i, j);
				}
			}
			else if (a == b01[1])
			{
				if (qs[0].Any())
				{
					var (i, j) = qs[0].Dequeue();
					return (b01[0], i, j);
				}
				else
				{
					var (i, j) = qs[1].Dequeue();
					return (a0, i, j);
				}
			}
			else
			{
				if (qs[1].Any())
				{
					var (i, j) = qs[1].Dequeue();
					return (b01[1], i, j);
				}
				else
				{
					var (i, j) = qs[0].Dequeue();
					return (a0, i, j);
				}
			}
		}
	}
}
