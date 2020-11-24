using System;
using System.Linq;

class B
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		Console.ReadLine();
		return Console.ReadLine().Replace(" ", "").Trim('0').Count(c => c == '0');
	}
}
