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

		var a2 = a.Concat(a).Concat(a).ToArray();
		var q = PQ<int>.CreateWithKey(i => a2[i], true);
		var end = new int[a2.Length];

		for (int i = 0; i < a2.Length; i++)
		{
			while (q.Any() && (q.First.Key + 1) / 2 > a2[i])
			{
				var i0 = q.Pop().Value;
				for (int j = i0; j >= 0 && end[j] == 0; j--)
					end[j] = i;
			}
			q.Push(i);
		}

		return string.Join(" ", end.Take(n).Select((x, i) => x - i));
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
