using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var h = Read();
		var n = h[0];
		var map = UndirectedMap(n, new int[h[1]].Select(_ => Read()).ToArray());

		var c = Enumerable.Repeat(long.MaxValue, n + 1).ToArray();
		c[1] = 0;
		var u = new bool[n + 1];
		// BUG: descending order
		var pq = PQ<R>.Create(new[] { new R { to = 1 } }, x => x.cost, true);

		while (pq.Any())
		{
			var p = pq.Pop().to;
			if (u[p]) continue;
			u[p] = true;

			foreach (var r in map[p])
			{
				var v = c[p] + r.cost;
				if (v >= c[r.to]) continue;
				c[r.to] = v;
				pq.Push(new R { to = r.to, cost = v });
			}
		}
		Console.WriteLine(c[n] < long.MaxValue ? c[n] : -1);
	}

	struct R
	{
		public int to;
		public long cost;
	}

	static List<R>[] UndirectedMap(int n, int[][] rs)
	{
		var map = Array.ConvertAll(new int[n + 1], _ => new List<R>());
		foreach (var r in rs)
		{
			map[r[0]].Add(new R { to = r[1], cost = r[2] });
			if (r[0] != r[1])
				map[r[1]].Add(new R { to = r[0], cost = r[2] });
		}
		return map;
	}
}

class PQ<T> : List<T>
{
	public static PQ<T> CreateDesc(T[] vs)
	{
		var c = Comparer<T>.Default;
		return new PQ<T>(vs, (x, y) => c.Compare(y, x));
	}

	public static PQ<T> Create<TKey>(T[] vs, Func<T, TKey> getKey, bool desc = false)
	{
		var c = Comparer<TKey>.Default;
		return desc ?
			new PQ<T>(vs, (x, y) => c.Compare(getKey(y), getKey(x))) :
			new PQ<T>(vs, (x, y) => c.Compare(getKey(x), getKey(y)));
	}

	Comparison<T> _c;
	public T First => this[0];

	public PQ(T[] vs = null, Comparison<T> c = null)
	{
		_c = c ?? Comparer<T>.Default.Compare;
		if (vs != null) foreach (var v in vs) Push(v);
	}

	void Swap(int i, int j) { var o = this[i]; this[i] = this[j]; this[j] = o; }
	void UpHeap(int i) { for (int j; i > 0 && _c(this[j = (i - 1) / 2], this[i]) > 0; Swap(i, j), i = j) ; }
	void DownHeap(int i)
	{
		for (int j; (j = 2 * i + 1) < Count; i = j)
		{
			if (j + 1 < Count && _c(this[j], this[j + 1]) > 0) j++;
			if (_c(this[i], this[j]) > 0) Swap(i, j); else break;
		}
	}

	public void Push(T v) { Add(v); UpHeap(Count - 1); }
	public T Pop()
	{
		var r = this[0];
		this[0] = this[Count - 1];
		RemoveAt(Count - 1);
		DownHeap(0);
		return r;
	}
}
