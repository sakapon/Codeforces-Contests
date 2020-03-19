using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

		var remains = Enumerable.Range(1, n).Except(a).ToArray();
		var r0 = Array.FindAll(remains, x => a[x - 1] == 0);
		var r1 = new Queue<int>(remains.Except(r0));

		if (r0.Length == 1)
		{
			a[r0[0] - 1] = r1.Dequeue();
			r1.Enqueue(r0[0]);
		}
		else if (r0.Length > 1)
		{
			for (int i = 0; i < r0.Length; i++)
				a[r0[i] - 1] = r0[(i + 1) % r0.Length];
		}

		for (int i = 0; i < n; i++)
			if (a[i] == 0) a[i] = r1.Dequeue();

		Console.WriteLine(string.Join(" ", a));
	}
}
