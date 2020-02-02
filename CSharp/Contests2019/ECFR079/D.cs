using System;
using System.Linq;

class D
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = new int[n].Select(_ => Console.ReadLine().Split().Skip(1).Select(int.Parse).ToArray()).ToArray();

		var items_kids = a.SelectMany((g, i) => g.Select(x => (x: x, i: i))).GroupBy(_ => _.x, _ => _.i).ToDictionary(g => g.Key, g => g.ToArray());
		var kids_inv = Array.ConvertAll(a, g => (MInt)1 / g.Length);

		MInt t = 0;
		foreach (var p in items_kids)
			t += items_kids[p.Key].Select(i => kids_inv[i]).Aggregate((x, y) => x + y) * p.Value.Length;
		Console.WriteLine(t / n / n);
	}
}

struct MInt
{
	const int M = 998244353;
	public long V;
	public MInt(long v) { V = (v %= M) < 0 ? v + M : v; }

	public static implicit operator MInt(long v) => new MInt(v);
	public static MInt operator +(MInt x, MInt y) => x.V + y.V;
	public static MInt operator -(MInt x, MInt y) => x.V - y.V;
	public static MInt operator *(MInt x, MInt y) => x.V * y.V;
	public static MInt operator /(MInt x, MInt y) => x * y.Inv();

	public MInt Pow(int i) => MPow(V, i);
	public MInt Inv() => MPow(V, M - 2);
	public override string ToString() => $"{V}";

	static long MPow(long b, int i)
	{
		for (var r = 1L; ; b = b * b % M)
		{
			if (i % 2 > 0) r = r * b % M;
			if ((i /= 2) < 1) return r;
		}
	}
}
