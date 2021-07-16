using System;
using System.Linq;

class B2
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var b = ReadL();
		return b.Select((v, i) => (v, d: v - i)).GroupBy(t => t.d).Max(g => g.Sum(t => t.v));
	}
}
