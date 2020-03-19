using System;
using System.Linq;

class B
{
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		Console.WriteLine(Enumerable.Range(1, n).Sum(i => 1.0 / i));
	}
}
