using System;
using System.Linq;

class A
{
	static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
	static void Main()
	{
		Console.SetOut(new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
		var (n, qc) = Read2();
		var a = Read();
		var qs = Array.ConvertAll(new bool[qc], _ => Read2());

		var c = a.Count(x => x == 1);

		foreach (var (t, k) in qs)
		{
			if (t == 1)
			{
				if (a[k - 1] == 0)
				{
					a[k - 1] = 1;
					c++;
				}
				else
				{
					a[k - 1] = 0;
					c--;
				}
			}
			else
			{
				Console.WriteLine(k <= c ? 1 : 0);
			}
		}
		Console.Out.Flush();
	}
}
