using System;
using System.Linq;

class D2
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main()
	{
		var qc = int.Parse(Console.ReadLine());
		var qs = Array.ConvertAll(new bool[qc], _ => Read());

		var f30 = Enumerable.Range(0, 30).Select(i => 1 << i).ToArray();
		Console.WriteLine(string.Join("\n", qs.Select(q => Solve(q) ? "YES" : "NO")));

		bool Solve(int[] q)
		{
			var (u, v) = (q[0], q[1]);

			if (u > v) return false;
			if (u == v) return true;

			var fu = Array.FindAll(f30, f => (u & f) != 0);
			var fv = Array.FindAll(f30, f => (v & f) != 0);

			if (fu.Length < fv.Length) return false;

			for (int i = 0; i < fv.Length; i++)
				if (fu[i] > fv[i]) return false;
			return true;
		}
	}
}
