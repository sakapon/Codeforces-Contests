using System;
using System.Linq;

class B
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var (n, k) = Read2();
		k--;

		if (n % 2 == 0)
		{
			return k % n + 1;
		}
		else
		{
			var period = n / 2;
			var r = k % period;
			var k0 = k - r;
			return (n - k0 % n + r) % n + 1;
		}
	}
}
