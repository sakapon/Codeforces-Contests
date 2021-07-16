using System;
using System.Linq;

class B
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var s = Console.ReadLine();
		var n = s.Length;

		var r = -2;
		var for1 = true;

		for (int i = 0; i < n; i++)
		{
			if (for1)
			{
				if (s[i] == '1')
				{
					if (r == i - 1)
					{
						for1 = false;
					}
					else
					{
						r = i;
					}
				}
				else
				{

				}
			}
			else
			{
				if (s[i] == '0')
				{
					if (r == i - 1) return false;
					r = i;
				}
				else
				{

				}
			}
		}
		return true;
	}
}
