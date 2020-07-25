using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var h = Read();
		var n = h[0];
		var rs = new int[h[1]].Select(_ => Read()).ToArray();

		var map = UndirectedMap(n, rs);

		var u = Enumerable.Repeat(1L << 60, n + 1).ToArray();
		var from = new int[n + 1];
		var pq = PQ<int>.Create(p => u[p]);
		u[1] = 0;
		pq.Push(1);

		while (pq.Any())
		{
			var p = pq.Pop();
			foreach (var r in map[p])
			{
				if (u[r.p] <= u[p] + r.w) continue;
				u[r.p] = u[p] + r.w;
				from[r.p] = p;
				pq.Push(r.p);
			}
		}

		var path = new List<int> { n };
		var t = n;
		while ((t = from[t]) > 0) path.Add(t);
		path.Reverse();
		Console.WriteLine(path[0] == 1 ? string.Join(" ", path) : "-1");
	}

	static List<(int p, int w)>[] UndirectedMap(int n, int[][] rs)
	{
		var map = Array.ConvertAll(new int[n + 1], _ => new List<(int, int)>());
		foreach (var r in rs)
		{
			map[r[0]].Add((r[1], r[2]));
			map[r[1]].Add((r[0], r[2]));
		}
		return map;
	}
}

class PQ<T> : List<T>
{
	public static PQ<T> Create(T[] vs = null, bool desc = false)
	{
		var c = Comparer<T>.Default;
		return desc ?
			new PQ<T>(vs, (x, y) => c.Compare(y, x)) :
			new PQ<T>(vs, c.Compare);
	}

	public static PQ<T> Create<TKey>(Func<T, TKey> getKey, T[] vs = null, bool desc = false)
	{
		var c = Comparer<TKey>.Default;
		return desc ?
			new PQ<T>(vs, (x, y) => c.Compare(getKey(y), getKey(x))) :
			new PQ<T>(vs, (x, y) => c.Compare(getKey(x), getKey(y)));
	}

	Comparison<T> c;
	public T First => this[0];

	PQ(T[] vs, Comparison<T> _c)
	{
		c = _c;
		if (vs != null) foreach (var v in vs) Push(v);
	}

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
	public T Pop()
	{
		var r = this[0];
		this[0] = this[Count - 1];
		RemoveAt(Count - 1);
		DownHeap(0);
		return r;
	}
}
