using System;
using System.Collections.Generic;
using System.Linq;

class C
{
	static void Main()
	{
		var s = Console.ReadLine();

		var map = new Map<string, long>();

		foreach (var c in s)
		{
			for (char c0 = 'a'; c0 <= 'z'; c0++)
			{
				map[$"{c0}{c}"] += map[c0.ToString()];
			}
			map[c.ToString()]++;
		}
		Console.WriteLine(map.Values.Max());
	}
}

class Map<TK, TV> : Dictionary<TK, TV>
{
	TV _v0;
	public Map(TV v0 = default(TV)) { _v0 = v0; }

	public new TV this[TK key]
	{
		get { return ContainsKey(key) ? base[key] : _v0; }
		set { base[key] = value; }
	}
}
