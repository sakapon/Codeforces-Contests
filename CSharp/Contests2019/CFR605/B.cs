using System;
using System.Linq;

class B
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Console.ReadLine()).Select(Solve)));
	static string Solve(string s)
	{
		var d = s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
		d = "LRUD".ToDictionary(c => c, c => d.ContainsKey(c) ? d[c] : 0);

		var lr = Math.Min(d['L'], d['R']);
		var ud = Math.Min(d['U'], d['D']);

		if (lr == 0 && ud == 0) return "0\n";
		if (ud == 0) return "2\nLR";
		if (lr == 0) return "2\nUD";
		return $"{2 * (lr + ud)}\n{new string('L', lr)}{new string('U', ud)}{new string('R', lr)}{new string('D', ud)}";
	}
}
