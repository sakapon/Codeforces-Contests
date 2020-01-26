using System;
using System.Linq;

class A
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(Solve)));
	static int Solve(int[] x) => 2 * Math.Max(0, x.Max() - x.Min() - 2);
}
