using System;
using System.Linq;

class A
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var s = Console.ReadLine().ToCharArray();
		s = s.Select((c, i) => i % 2 == 0 ? (c == 'a' ? 'b' : 'a') : (c == 'z' ? 'y' : 'z')).ToArray();
		return new string(s);
	}
}
