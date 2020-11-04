using System;
using static System.Math;

class E2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();
		var b = Read();

		var max = Min(a[0], b[1]) + Min(a[1], b[2]) + Min(a[2], b[0]);
		var min_ = 0;

		var pairs = new[] { (0, 0), (1, 1), (2, 2), (0, 2), (1, 0), (2, 1) };

		Permutation(pairs, 6, ps =>
		{
			var c = (int[])a.Clone();
			var d = (int[])b.Clone();

			var t = 0;
			foreach (var (i, j) in ps)
			{
				var m = Min(c[i], d[j]);
				t += m;
				c[i] -= m;
				d[j] -= m;
			}
			min_ = Max(min_, t);
		});

		Console.WriteLine($"{n - min_} {max}");
	}

	static void Permutation<T>(T[] values, int r, Action<T[]> action)
	{
		var n = values.Length;
		var p = new T[r];
		var u = new bool[n];

		if (r > 0) Dfs(0);
		else action(p);

		void Dfs(int i)
		{
			var i2 = i + 1;
			for (int j = 0; j < n; ++j)
			{
				if (u[j]) continue;
				p[i] = values[j];
				u[j] = true;

				if (i2 < r) Dfs(i2);
				else action(p);

				u[j] = false;
			}
		}
	}
}
