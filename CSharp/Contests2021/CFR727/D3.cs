using System;
using System.Linq;

class D3
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static (long a, long b) Read2L() { var a = ReadL(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var ps = Array.ConvertAll(new bool[n], _ => Read2L());

		var sum = ps.Sum(p => p.a);
		var r = sum;
		var c = 0L;

		foreach (var (a, b) in ps.OrderBy(_ => _.b))
		{
			if (c < b)
			{
				var d2 = Math.Min(sum, b - c);
				sum -= d2;
				r += d2;
				c += d2;
			}

			var d1 = Math.Min(sum, a);
			sum -= d1;
			c += d1;
		}
		return r;
	}
}
