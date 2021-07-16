using System;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var r = NewArray2<int>(n, n);

		for (int k = 0; k < n; k++)
		{
			var v = a[k];

			var (i, j) = (k, k);
			r[i][j] = v;

			for (int m = 1; m < v; m++)
			{
				if (j > 0 && r[i][j - 1] == 0)
				{
					j--;
				}
				else
				{
					i++;
				}
				r[i][j] = v;
			}
		}

		for (int i = 0; i < n; i++)
			Console.WriteLine(string.Join(" ", r[i][..(i + 1)]));
	}

	static T[][] NewArray2<T>(int n1, int n2, T v = default) => Array.ConvertAll(new bool[n1], _ => Array.ConvertAll(new bool[n2], __ => v));
}
