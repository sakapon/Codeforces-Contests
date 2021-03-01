using System;
using System.Linq;

class C1
{
	const char X = 'X', O = 'O';
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Array.ConvertAll(new bool[n], _ => Console.ReadLine().ToCharArray());

		var c = new int[3];

		for (int i = 0; i < n; i++)
			for (int j = 0; j < n; j++)
				if (s[i][j] == X)
					c[(i + j) % 3]++;

		var m = Enumerable.Range(0, 3).OrderBy(x => c[x]).First();

		for (int i = 0; i < n; i++)
			for (int j = 0; j < n; j++)
				if (s[i][j] == X && (i + j) % 3 == m)
					s[i][j] = O;

		return string.Join("\n", s.Select(cs => new string(cs)));
	}
}
