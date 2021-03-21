using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var b = Read();

		// b_i - i
		var d = b.Select((v, i) => v - i).ToArray();

		var s = new long[600000 + 1];

		for (int i = 0; i < n; i++)
		{
			s[d[i] + 200000] += b[i];
		}

		return s.Max();
	}
}
