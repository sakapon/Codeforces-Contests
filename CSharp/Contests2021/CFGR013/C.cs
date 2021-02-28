using System;
using System.Linq;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static long Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Read();

		var r = 0L;
		var t = new int[n];

		for (int i = 0; i < n; i++)
		{
			if (t[i] > 0)
			{
				// n に飛び越す場合
				var ns = Math.Max(1, n - 1 - i);
				var c = Math.Min(t[i], Math.Max(0, s[i] - ns));
				s[i] -= c;
				t[i] -= c;
			}
			while (t[i] > 0 && s[i] > 1 && i + s[i] < n)
			{
				// 次に飛ぶ場合
				t[i + s[i]]++;
				s[i]--;
				t[i]--;
			}
			if (i + 1 < n && t[i] > 0)
			{
				// 隣に飛ぶ場合
				t[i + 1] += t[i];
			}

			if (s[i] > 1 && i + s[i] >= n)
			{
				var ns = Math.Max(1, n - 1 - i);
				r += s[i] - ns;
				s[i] = ns;
			}

			while (s[i] > 1)
			{
				r++;
				t[i + s[i]]++;
				s[i]--;
			}
		}
		return r;
	}
}
