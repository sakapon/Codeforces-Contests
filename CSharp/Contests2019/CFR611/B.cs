using System;
using System.Linq;

class B
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => MaxCandies(x[0], x[1]))));
	static int MaxCandies(int n, int k) => Math.Min(n, n / k * k + k / 2);
}
