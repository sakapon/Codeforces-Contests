using System;
using System.Linq;

class C2
{
	const char X = 'X', O = 'O';
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Array.ConvertAll(new bool[n], _ => Console.ReadLine().ToCharArray());

		var cx = new int[3];
		var co = new int[3];

		for (int i = 0; i < n; i++)
			for (int j = 0; j < n; j++)
				if (s[i][j] == X)
					cx[(i + j) % 3]++;
				else if (s[i][j] == O)
					co[(i + j) % 3]++;

		var k = cx.Sum() + co.Sum();
		var (mx, mo) = ArgMin();
		(int, int) ArgMin()
		{
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					if (i != j && cx[i] + co[j] <= k / 3)
						return (i, j);
			throw new InvalidOperationException();
		}

		for (int i = 0; i < n; i++)
			for (int j = 0; j < n; j++)
				if (s[i][j] == X && (i + j) % 3 == mx)
					s[i][j] = O;
				else if (s[i][j] == O && (i + j) % 3 == mo)
					s[i][j] = X;

		return string.Join("\n", s.Select(cs => new string(cs)));
	}
}
