using System;
using System.Linq;

class D
{
	static long[] ReadL() => Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	static (long a, long b) Read2L() { var a = ReadL(); return (a[0], a[1]); }
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var ps = Array.ConvertAll(new bool[n], _ => Read2L());

		var q = new DQ<(long a, long b)>();
		foreach (var p in ps.OrderBy(_ => _.b))
			q.PushLast(p);

		var r = 0L;
		var c = 0L;

		// b の大きいほうから 2 で購入する
		// b の小さいほうから 1 で購入する
		while (q.Length >= 2)
		{
			var (af, bf) = q.First;
			var (al, bl) = q.Last;

			if (bf <= c + al)
			{
				var d = bf - c;
				r += 2 * d;
				c += d;
				if (d == al)
				{
					q.PopLast();
				}
				else
				{
					q[q.Length - 1] = (al - d, bl);
				}

				while (q.Length > 0 && q.First.b <= c)
				{
					var (a, b) = q.PopFirst();
					r += a;
					c += a;
				}
			}
			else
			{
				r += 2 * al;
				c += al;
				q.PopLast();
			}
		}

		if (q.Length == 1)
		{
			var (a, b) = q.PopFirst();

			if (b <= c)
			{
				r += a;
			}
			else if (b <= c + a)
			{
				var d = b - c;
				r += 2 * d;
				r += a - d;
			}
			else
			{
				r += 2 * a;
			}
		}

		return r;
	}
}

class DQ<T>
{
	T[] a;
	int fiIn, liEx;

	public DQ(int size = 8)
	{
		a = new T[size << 1];
		fiIn = liEx = size;
	}

	public int Length => liEx - fiIn;
	public T First => a[fiIn];
	public T Last => a[liEx - 1];
	public T this[int i]
	{
		get { return a[fiIn + i]; }
		set { a[fiIn + i] = value; }
	}

	public void PushFirst(T v)
	{
		if (fiIn == 0) Expand();
		a[--fiIn] = v;
	}
	public void PushLast(T v)
	{
		if (liEx == a.Length) Expand();
		a[liEx++] = v;
	}

	public T PopFirst() => a[fiIn++];
	public T PopLast() => a[--liEx];

	void Expand()
	{
		var b = new T[a.Length << 1];
		var d = a.Length >> 1;
		a.CopyTo(b, d);
		a = b;
		fiIn += d;
		liEx += d;
	}
}
