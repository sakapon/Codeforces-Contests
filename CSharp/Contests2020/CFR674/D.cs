using System;
using System.Collections.Generic;
using System.Linq;

class D
{
	static void Main()
	{
		var n = int.Parse(Console.ReadLine());
		var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

		var r = 0;
		var seq = new Seq(a);
		var s = seq.s;
		var set = new HashSet<long> { 0 };

		for (int i = 1; i <= n; i++)
		{
			var x = s[i];
			if (set.Contains(x))
			{
				r++;
				set.Clear();
				set.Add(s[i - 1]);
				set.Add(x);
			}
			else
			{
				set.Add(x);
			}
		}

		Console.WriteLine(r);
	}
}

class Seq
{
	int[] a;
	public long[] s;
	public Seq(int[] _a)
	{
		a = _a;
		s = new long[a.Length + 1];
		for (int i = 0; i < a.Length; ++i) s[i + 1] = s[i] + a[i];
	}

	public long Sum(int minIn, int maxEx)
	{
		return s[maxEx] - s[minIn];
	}

	// C# 8.0
	//public long Sum(Range r) => Sum(r.Start.GetOffset(a.Length), r.End.GetOffset(a.Length));
}
