using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static void Main() => Console.WriteLine(Solve());
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Read();

		var amax = a.Max();
		if (a.All(x => x >= (amax + 1) / 2))
			return string.Join(" ", Enumerable.Repeat(-1, n));

		var ll = new LinkedList<(int i, int min, int max)>(a.Concat(a).Concat(a).Select((x, i) => (i, x, x)));

		// 単調増加 なら同じグループ
		for (var ln = ll.Last.Previous; ln != null; ln = ln.Previous)
		{
			if (ln.Value.max > ln.Next.Value.min) continue;

			var (i, min, max) = ln.Value;
			ln.Value = (i, min, ln.Next.Value.max);
			ll.Remove(ln.Next);
		}

		// 半減しない かつ 最小値が単調増加 かつ 最大値が単調増加 なら同じグループ
		for (var ln = ll.Last.Previous; ln != null; ln = ln.Previous)
		{
			if ((ln.Value.max + 1) / 2 > ln.Next.Value.min) continue;
			if (ln.Value.min > ln.Next.Value.min) continue;
			if (ln.Value.max > ln.Next.Value.max) continue;

			var (i, min, max) = ln.Value;
			ln.Value = (i, min, ln.Next.Value.max);
			ll.Remove(ln.Next);
		}

		var gs = ll.ToArray();
		var g_end = new int[gs.Length];

		var q = PQ<int>.CreateWithKey(gi => gs[gi].max, true);

		for (int gi = 0; gi < gs.Length; gi++)
		{
			var (i, min, _) = gs[gi];

			while (q.Any() && (q.First.Key + 1) / 2 > min)
			{
				var (_, gj) = q.Pop();
				g_end[gj] = i;
			}
			q.Push(gi);
		}

		for (int gi = gs.Length - 1; gi > 0; gi--)
		{
			if (g_end[gi - 1] == 0 || g_end[gi] > 0 && g_end[gi - 1] > g_end[gi])
				g_end[gi - 1] = g_end[gi];
		}

		var c = new int[n];
		for (int gi = 0; gi < gs.Length - 1; gi++)
		{
			var l = gs[gi].i;
			var r = gs[gi + 1].i;

			for (int i = l; i < r && i < n; i++)
				c[i] = g_end[gi] - i;
		}
		return string.Join(" ", c);
	}
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
