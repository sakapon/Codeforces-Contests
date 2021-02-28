using System;
using System.Collections.Generic;

class C
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static (int, int, int) Read3() { var a = Read(); return (a[0], a[1], a[2]); }
	static void Main()
	{
		var (r, n) = Read2();
		var ps = Array.ConvertAll(new bool[n], _ => Read3());

		var M = 0;
		var dp = new List<(int t, IntV p, int c, int M)> { (0, new IntV(1, 1), 0, 0) };

		foreach (var (t, x, y) in ps)
		{
			var p = new IntV(x, y);
			var c = 0;

			for (int i = dp.Count - 1; i >= 0; i--)
			{
				var (t0, p0, c0, M0) = dp[i];
				if (t - t0 > r << 1)
				{
					c = Math.Max(c, M0 + 1);
					break;
				}
				if (t - t0 < (p - p0).NormL1) continue;

				c = Math.Max(c, c0 + 1);
			}
			if (c > 0)
			{
				M = Math.Max(M, c);
				dp.Add((t, p, c, M));
			}
		}
		Console.WriteLine(M);
	}
}

struct IntV : IEquatable<IntV>
{
	public static IntV Zero = new IntV();
	public static IntV UnitX = new IntV(1, 0);
	public static IntV UnitY = new IntV(0, 1);

	public long X, Y;
	public IntV(long x, long y) { X = x; Y = y; }
	public override string ToString() => $"{X} {Y}";
	public static IntV Parse(string s) => Array.ConvertAll(s.Split(), long.Parse);

	public static implicit operator IntV(long[] v) => new IntV(v[0], v[1]);
	public static explicit operator long[](IntV v) => new[] { v.X, v.Y };

	public bool Equals(IntV other) => X == other.X && Y == other.Y;
	public static bool operator ==(IntV v1, IntV v2) => v1.Equals(v2);
	public static bool operator !=(IntV v1, IntV v2) => !v1.Equals(v2);
	public override bool Equals(object obj) => obj is IntV && Equals((IntV)obj);
	public override int GetHashCode() => Tuple.Create(X, Y).GetHashCode();

	public static IntV operator -(IntV v) => new IntV(-v.X, -v.Y);
	public static IntV operator +(IntV v1, IntV v2) => new IntV(v1.X + v2.X, v1.Y + v2.Y);
	public static IntV operator -(IntV v1, IntV v2) => new IntV(v1.X - v2.X, v1.Y - v2.Y);

	public long NormL1 => Math.Abs(X) + Math.Abs(Y);
	public double Norm => Math.Sqrt(X * X + Y * Y);
}
