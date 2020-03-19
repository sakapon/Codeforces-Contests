using System;
using System.Linq;

class A
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).Select(Solve)));
	static string Solve(long[] x) => x.Max() <= (x.Sum() + 1) / 2 ? "Yes" : "No";
}
