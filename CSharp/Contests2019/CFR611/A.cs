using System;
using System.Linq;

class A
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(ToMinutes)));
	static int ToMinutes(int[] x) => 1440 - 60 * x[0] - x[1];
}
