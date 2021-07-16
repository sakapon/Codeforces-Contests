using System;
using System.Linq;
using System.Text;

class D
{
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var n = int.Parse(Console.ReadLine());
		var ss = Array.ConvertAll(new bool[3], _ => Console.ReadLine());

		var ss0 = ss.Where(s => s.Count(c => c == '0') >= n).ToArray();
		if (ss0.Length >= 2) return Create(ss0[..2], '0');

		var ss1 = ss.Where(s => s.Count(c => c == '1') >= n).ToArray();
		if (ss1.Length >= 2) return Create(ss1[..2], '1');

		return -1;

		string Create(string[] sc, char c)
		{
			var sb = new StringBuilder();

			var (i0, i1) = (0, 0);
			for (int k = 0; k < n; k++, i0++, i1++)
			{
				for (; sc[0][i0] != c; i0++)
				{
					sb.Append(sc[0][i0]);
				}
				for (; sc[1][i1] != c; i1++)
				{
					sb.Append(sc[1][i1]);
				}

				sb.Append(c);
			}

			for (; i0 < 2 * n; i0++)
			{
				sb.Append(sc[0][i0]);
			}
			for (; i1 < 2 * n; i1++)
			{
				sb.Append(sc[1][i1]);
			}

			return sb.ToString();
		}
	}
}
