using System;
using System.Collections.Generic;

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

			var (b, qi) = Next(a);
			var (i, j) = qs[qi].Dequeue();
			Console.WriteLine($"{b} {i} {j}");
		}

		(int, int) Next(int a)
		{
			if (qs[1].Count == 0) return (a == a0 ? b01[0] : a0, 0);
			if (qs[0].Count == 0) return (a == a0 ? b01[1] : a0, 1);

			var qi = a == b01[1] ? 0 : 1;
			return (b01[qi], qi);
		}
	}
}
