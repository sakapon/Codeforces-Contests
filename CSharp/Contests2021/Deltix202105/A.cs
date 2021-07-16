using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, m) = Read2();
		var s = Console.ReadLine().ToCharArray();

		var t = s.ToArray();
		var next = true;

		for (int k = 0; k < m && next; k++)
		{
			next = false;

			for (int i = 0; i < n; i++)
			{
				if (s[i] == '1')
				{
					t[i] = '1';
				}
				else if ((i - 1 >= 0 && s[i - 1] == '1') ^ (i + 1 < n && s[i + 1] == '1'))
				{
					t[i] = '1';
					next = true;
				}
			}

			(s, t) = (t, s);
		}
		return new string(s);
	}
}
