using System;

class E
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main()
	{
		var h = Read();
		int n = h[0], m = h[1];
		var a = Array.ConvertAll(new int[n], _ => Read());

		for (int i = 0; i < n; i++)
			for (int j = 0; j < m; j++)
			{
				var q = Math.DivRem(a[i][j] - (j + 1), m, out var rem);
				a[i][j] = rem == 0 && 0 <= q && q < n ? Mod(q - i, n) : -1;
			}

		var r = 0;
		for (int j = 0; j < m; j++)
		{
			var u = new int[n];
			for (int i = 0; i < n; i++)
				if (a[i][j] != -1)
					++u[a[i][j]];

			var min = n;
			for (int i = 0; i < n; i++)
				min = Math.Min(min, (n - i) % n + n - u[i]);
			r += min;
		}
		Console.WriteLine(r);
	}

	static int Mod(int x, int m) => (x %= m) < 0 ? x + m : x;
}
