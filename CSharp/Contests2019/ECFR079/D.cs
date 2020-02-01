using System;
using System.Linq;

class D
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = new int[n].Select(_ => Console.ReadLine().Split().Skip(1).Select(int.Parse).ToArray()).ToArray();

		var items_kids = a.SelectMany((g, i) => g.Select(x => (x: x, i: i))).ToLookup(_ => _.x, _ => _.i);
		var inv = a.Select(x => ((MInt)x.Length).Inv()).ToArray();
		var s = a.SelectMany(x => x).GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

		MInt t = 0;
		var items = items_kids.Select(g => g.Key).ToArray();
		foreach (var j in items)
			t += items_kids[j].Select(i => inv[i]).Aggregate((x, y) => x + y) * s[j];
		Console.WriteLine(t / n / n);
	}
}

struct MInt
{
	const int M = 998244353;
	public long V;
	public MInt(long v) { V = (v %= M) < 0 ? v + M : v; }

	public static implicit operator MInt(long v) => new MInt(v);
	public static MInt operator +(MInt x) => x;
	public static MInt operator -(MInt x) => -x.V;
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
