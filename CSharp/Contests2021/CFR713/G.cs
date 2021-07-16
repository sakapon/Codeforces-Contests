using System;
using System.Linq;

class G
{
	const int max = 10000000;
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var qc = int.Parse(Console.ReadLine());
		var qs = Array.ConvertAll(new bool[qc], _ => int.Parse(Console.ReadLine()));

		var sum = Array.ConvertAll(new bool[max], _ => 1L);

		for (int d = 2; d < max; d++)
		{
			for (int x = d; x < max; x += d)
			{
				sum[x] += d;
			}
		}

		var dinv = Array.ConvertAll(new bool[max + 1], _ => -1);

		for (int x = max - 1; x > 0; x--)
		{
			if (sum[x] > max) continue;
			dinv[sum[x]] = x;
		}

		return string.Join("\n", qs.Select(c => dinv[c]));
	}
}
