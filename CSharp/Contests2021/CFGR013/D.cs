using System;
using System.Collections;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main()
	{
		var qc = int.Parse(Console.ReadLine());
		var qs = Array.ConvertAll(new bool[qc], _ => Read());

		var r30 = Enumerable.Range(0, 30).ToArray();
		Console.WriteLine(string.Join("\n", qs.Select(q => Solve(q) ? "YES" : "NO")));

		bool Solve(int[] q)
		{
			var (u, v) = (q[0], q[1]);

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
	}
}
