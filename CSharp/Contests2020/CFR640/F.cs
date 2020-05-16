using System;
using System.Linq;

class F
{
	static int[] Read() => Console.ReadLine().Split().Select(int.Parse).ToArray();
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));

	static string Solve()
	{
		var n = Read();

		var r = "";
		if (n[0] > 0) r += new string('0', n[0] + 1);

		if (n[2] > 0)
		{
			if (r != "") n[1]--;
			r += new string('1', n[2] + 1);
		}

		if (r == "") r = "0";
		var n1e = r.Last() == '1';
		r += string.Join("", Enumerable.Range(0, n[1]).Select(x => (x % 2 == 0) == n1e ? "0" : "1"));

		return r;
	}
}
