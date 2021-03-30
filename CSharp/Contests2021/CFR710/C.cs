using System;
using System.Linq;

class C
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var a = Console.ReadLine();
		var b = Console.ReadLine();

		if (a.Length > b.Length) (a, b) = (b, a);
		var n = a.Length;
		var m = b.Length;

		for (int length = n; length > 0; length--)
		{
			for (int i = 0; i <= n - length; i++)
			{
				var sub = a.Substring(i, length);
				if (b.Contains(sub))
					return n + m - 2 * length;
			}
		}
		return n + m;
	}
}
