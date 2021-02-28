using System;
using System.Collections;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int u, int v) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main()
	{
		var qc = int.Parse(Console.ReadLine());
		var qs = Array.ConvertAll(new bool[qc], _ => Read2());

		var r30 = Enumerable.Range(0, 30).ToArray();

		bool Try(int u, int v)
		{
			if (u > v) return false;
			if (u == v) return true;

			var bu = new BitArray(new[] { u });
			var bv = new BitArray(new[] { v });
			var iu = Array.FindAll(r30, i => bu[i]);
			var iv = Array.FindAll(r30, i => bv[i]);

			if (iu.Length < iv.Length) return false;

			for (int i = 0; i < iv.Length; i++)
			{
				if (iu[i] > iv[i]) return false;
			}
			return true;
		}

		Console.WriteLine(string.Join("\n", qs.Select(q => Try(q.u, q.v) ? "YES" : "NO")));
	}

	static int FlagCount(int x)
	{
		var r = 0;
		for (; x != 0; x >>= 1) if ((x & 1) != 0) ++r;
		return r;
	}
}
