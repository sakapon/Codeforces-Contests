using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static void Main()
	{
		Console.ReadLine();
		var s = Console.ReadLine();
		var c = new HashSet<char>(Console.ReadLine().Replace(" ", ""));

		s = new string(s.Select(x => c.Contains(x) ? '?' : ' ').ToArray());
		Console.WriteLine(s.Split().Select(x => x.Length).Sum(x => (long)x * (x + 1) / 2));
	}
}
