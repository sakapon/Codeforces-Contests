using System;
using System.Linq;

class D1T
{
	static void Main()
	{
		const int n = 6;

		Power(Enumerable.Range(1, n).ToArray(), n, a =>
		{
			var expected = Naive(a);
			var actual = Solve(a);
			if (expected == actual) return;

			Console.WriteLine(string.Join(" ", a));
			Console.WriteLine($"expected: {expected}, actual: {actual}");
		});
	}

	static int Solve(int[] a)
	{
		var gs = a.GroupCountsBySeq(x => x).ToArray();
		var r = gs.Sum(g => g.Value == 1 ? 1 : 2);

		var bigIndexes = gs.Select((g, i) => (g, i))
			.Where(t => t.g.Value > 1)
			.ToArray();

		for (int i = 1; i < bigIndexes.Length; i++)
		{
			var (b1, b2) = (bigIndexes[i - 1], bigIndexes[i]);
			if (b1.g.Key != b2.g.Key) continue;

			var key = b2.g.Key;
			if (Enumerable.Range(b1.i + 1, b2.i - b1.i - 1).All(j => gs[j].Key == key || gs[j - 1].Key == gs[j + 1].Key))
				r--;
		}
		return r;
	}

	static int Naive(int[] a)
	{
		var M = 0;
		var rn = Enumerable.Range(0, a.Length).ToArray();
		Power(new[] { false, true }, a.Length, f =>
		{
			var c0 = rn.Where(i => f[i]).GroupCountsBySeq(i => a[i]).Count();
			var c1 = rn.Where(i => !f[i]).GroupCountsBySeq(i => a[i]).Count();
			M = Math.Max(M, c0 + c1);
		});
		return M;
	}

	public static void Power<T>(T[] values, int r, Action<T[]> action)
	{
		var n = values.Length;
		var p = new T[r];

		if (r > 0) Dfs(0);
		else action(p);

		void Dfs(int i)
		{
			var i2 = i + 1;
			for (int j = 0; j < n; ++j)
			{
				p[i] = values[j];

				if (i2 < r) Dfs(i2);
				else action(p);
			}
		}
	}
}
