﻿using System;
using System.Linq;

class A
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static long Solve()
	{
		Console.ReadLine();
		return Console.ReadLine().TrimStart('P').Split('A').Max(s => s.Length);
	}
}
