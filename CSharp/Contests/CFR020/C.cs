﻿using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main()
	{
		var h = Read();
		var n = h[0];
		var es = new int[h[1]].Select(_ => Read()).ToArray();

		var r = Dijkstra(n, 1, n, es);
		Console.WriteLine(r == null ? "-1" : string.Join(" ", r));
	}

	static int[] Dijkstra(int n, int sv, int ev, int[][] es)
	{
		var map = Array.ConvertAll(new int[n + 1], _ => new List<int[]>());
		foreach (var e in es)
		{
			map[e[0]].Add(new[] { e[1], e[2] });
			map[e[1]].Add(new[] { e[0], e[2] });
		}

		var from = Enumerable.Repeat(-1, n + 1).ToArray();
		var u = Enumerable.Repeat(long.MaxValue, n + 1).ToArray();
		var pq = PQ<int>.Create(v => u[v]);
		u[sv] = 0;
		pq.Push(sv);

		while (pq.Count > 0)
		{
			var v = pq.Pop();
			if (v == ev) break;
			foreach (var e in map[v])
			{
				if (u[e[0]] <= u[v] + e[1]) continue;
				from[e[0]] = v;
				u[e[0]] = u[v] + e[1];
				pq.Push(e[0]);
			}
		}

		if (from[ev] == -1) return null;
		var path = new List<int>();
		for (var v = ev; v != -1; v = from[v])
			path.Add(v);
		path.Reverse();
		return path.ToArray();
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
