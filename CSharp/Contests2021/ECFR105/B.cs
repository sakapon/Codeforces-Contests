using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve() ? "YES" : "NO")));
	static bool Solve()
	{
		var a = Read();
		var n = a[0];

		var ft = new[] { 0, 1 };

		foreach (var lt in ft)
			foreach (var rt in ft)
				foreach (var rb in ft)
					foreach (var lb in ft)
					{
						var r = new[] { a[1] - lt - rt, a[2] - rt - rb, a[3] - rb - lb, a[4] - lb - lt };
						if (r.All(x => 0 <= x && x <= n - 2))
							return true;
					}
		return false;
	}
}
