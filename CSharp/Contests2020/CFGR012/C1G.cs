using System;
using System.Collections.Generic;
using System.Linq;

class C1G
{
	const char X = 'X', O = 'O';
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static string Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var s = Array.ConvertAll(new bool[n], _ => Console.ReadLine().ToCharArray());

		// WA
		var t = NewArray2<int>(n, n);
		var triplets = new RectGridMap<List<PB>>(n, n, () => new List<PB>());

		// Horizontal
		for (int i = 0; i < n; i++)
			for (int j = 1; j < n - 1; j++)
				if (s[i][j - 1] == X && s[i][j] == X && s[i][j + 1] == X)
				{
					t[i][j - 1]++;
					t[i][j]++;
					t[i][j + 1]++;

					var pb = new PB { p = new Point(i, j) };
					triplets[i, j - 1].Add(pb);
					triplets[i, j].Add(pb);
					triplets[i, j + 1].Add(pb);
				}
		// Vertical
		for (int j = 0; j < n; j++)
			for (int i = 1; i < n - 1; i++)
				if (s[i - 1][j] == X && s[i][j] == X && s[i + 1][j] == X)
				{
					t[i - 1][j]++;
					t[i][j]++;
					t[i + 1][j]++;

					var pb = new PB { p = new Point(i, j), vertical = true };
					triplets[i - 1, j].Add(pb);
					triplets[i, j].Add(pb);
					triplets[i + 1, j].Add(pb);
				}

		var q = PQ<Point>.CreateWithKey(p => t[p.i][p.j], true);
		for (int i = 0; i < n; i++)
			for (int j = 0; j < n; j++)
				if (t[i][j] > 0)
					q.Push(new Point(i, j));

		while (q.Count > 0)
		{
			var (c, p) = q.Pop();
			if (t[p.i][p.j] != c) continue;

			s[p.i][p.j] = O;

			foreach (var pb in triplets[p])
			{
				if (pb.end) continue;
				pb.end = true;

				var (i, j) = pb.p;
				if (!pb.vertical)
				{
					t[i][j - 1]--;
					t[i][j]--;
					t[i][j + 1]--;

					if (t[i][j - 1] > 0) q.Push(new Point(i, j - 1));
					if (t[i][j] > 0) q.Push(new Point(i, j));
					if (t[i][j + 1] > 0) q.Push(new Point(i, j + 1));
				}
				else
				{
					t[i - 1][j]--;
					t[i][j]--;
					t[i + 1][j]--;

					if (t[i - 1][j] > 0) q.Push(new Point(i - 1, j));
					if (t[i][j] > 0) q.Push(new Point(i, j));
					if (t[i + 1][j] > 0) q.Push(new Point(i + 1, j));
				}
			}
		}

		return string.Join("\n", s.Select(cs => new string(cs)));
	}

	static T[][] NewArray2<T>(int n1, int n2, T v = default) => Array.ConvertAll(new bool[n1], _ => Array.ConvertAll(new bool[n2], __ => v));
}

class PB
{
	public Point p;
	public bool vertical, end;
}

public struct Point : IEquatable<Point>
{
	public int i, j;
	public Point(int i, int j) { this.i = i; this.j = j; }
	public void Deconstruct(out int i, out int j) { i = this.i; j = this.j; }
	public override string ToString() => $"{i} {j}";
	public static Point Parse(string s) => Array.ConvertAll(s.Split(), int.Parse);

	public static implicit operator Point(int[] v) => (v[0], v[1]);
	public static explicit operator int[](Point v) => new[] { v.i, v.j };
	public static implicit operator Point((int i, int j) v) => new Point(v.i, v.j);
	public static explicit operator (int, int)(Point v) => (v.i, v.j);

	public bool Equals(Point other) => i == other.i && j == other.j;
	public static bool operator ==(Point v1, Point v2) => v1.Equals(v2);
	public static bool operator !=(Point v1, Point v2) => !v1.Equals(v2);
	public override bool Equals(object obj) => obj is Point v && Equals(v);
	public override int GetHashCode() => (i, j).GetHashCode();

	public static Point operator -(Point v) => new Point(-v.i, -v.j);
	public static Point operator +(Point v1, Point v2) => new Point(v1.i + v2.i, v1.j + v2.j);
	public static Point operator -(Point v1, Point v2) => new Point(v1.i - v2.i, v1.j - v2.j);

	public bool IsInRange(int height, int width) => 0 <= i && i < height && 0 <= j && j < width;
	public Point[] Nexts() => new[] { new Point(i - 1, j), new Point(i + 1, j), new Point(i, j - 1), new Point(i, j + 1), this };
	public static Point[] NextsByDelta { get; } = new[] { new Point(-1, 0), new Point(1, 0), new Point(0, -1), new Point(0, 1) };

	public int NormL1 => Math.Abs(i) + Math.Abs(j);
	public double Norm => Math.Sqrt(i * i + j * j);
}

public class RectGridMap<TValue>
{
	TValue[,] a;
	public int Height => a.GetLength(0);
	public int Width => a.GetLength(1);
	public RectGridMap(TValue[,] a) { this.a = a; }
	public RectGridMap(int height, int width, TValue iv)
	{
		a = new TValue[height, width];
		for (int i = 0; i < height; ++i)
			for (int j = 0; j < width; ++j)
				a[i, j] = iv;
	}
	public RectGridMap(int height, int width, Func<TValue> getIV)
	{
		a = new TValue[height, width];
		for (int i = 0; i < height; ++i)
			for (int j = 0; j < width; ++j)
				a[i, j] = getIV();
	}
	public TValue this[Point key] { get => a[key.i, key.j]; set => a[key.i, key.j] = value; }
	public TValue this[int i, int j] { get => a[i, j]; set => a[i, j] = value; }
}

class PQ<T> : List<T>
{
	public static PQ<T> Create(bool desc = false)
	{
		var c = Comparer<T>.Default;
		return desc ?
			new PQ<T>((x, y) => c.Compare(y, x)) :
			new PQ<T>(c.Compare);
	}

	public static PQ<T> Create<TKey>(Func<T, TKey> toKey, bool desc = false)
	{
		var c = Comparer<TKey>.Default;
		return desc ?
			new PQ<T>((x, y) => c.Compare(toKey(y), toKey(x))) :
			new PQ<T>((x, y) => c.Compare(toKey(x), toKey(y)));
	}

	public static PQ<T, TKey> CreateWithKey<TKey>(Func<T, TKey> toKey, bool desc = false)
	{
		var c = Comparer<TKey>.Default;
		return desc ?
			new PQ<T, TKey>(toKey, (x, y) => c.Compare(y.Key, x.Key)) :
			new PQ<T, TKey>(toKey, (x, y) => c.Compare(x.Key, y.Key));
	}

	Comparison<T> c;
	public T First => this[0];
	internal PQ(Comparison<T> _c) { c = _c; }

	void Swap(int i, int j) { var o = this[i]; this[i] = this[j]; this[j] = o; }
	void UpHeap(int i) { for (int j; i > 0 && c(this[j = (i - 1) / 2], this[i]) > 0; Swap(i, i = j)) ; }
	void DownHeap(int i)
	{
		for (int j; (j = 2 * i + 1) < Count;)
		{
			if (j + 1 < Count && c(this[j], this[j + 1]) > 0) j++;
			if (c(this[i], this[j]) > 0) Swap(i, i = j); else break;
		}
	}

	public void Push(T v)
	{
		Add(v);
		UpHeap(Count - 1);
	}
	public void PushRange(T[] vs) { foreach (var v in vs) Push(v); }

	public T Pop()
	{
		var r = this[0];
		this[0] = this[Count - 1];
		RemoveAt(Count - 1);
		DownHeap(0);
		return r;
	}
}

class PQ<T, TKey> : PQ<KeyValuePair<TKey, T>>
{
	Func<T, TKey> ToKey;
	internal PQ(Func<T, TKey> toKey, Comparison<KeyValuePair<TKey, T>> c) : base(c) { ToKey = toKey; }

	public void Push(T v) => Push(new KeyValuePair<TKey, T>(ToKey(v), v));
	public void PushRange(T[] vs) { foreach (var v in vs) Push(v); }
}
