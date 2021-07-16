using System;
using System.Collections.Generic;
using System.Linq;

class G
{
	const int max = 1 << 30;
	static void Main() => Console.WriteLine(string.Join("\n", new int[int.Parse(Console.ReadLine())].Select(_ => Solve())));
	static object Solve()
	{
		var s = Console.ReadLine();
		var n = s.Length;

		var d = new Dictionary<char, Queue<int>>();
		var lastIndexes = new Dictionary<char, int>();
		for (char c = 'a'; c <= 'z'; c++)
		{
			d[c] = new Queue<int>();
			lastIndexes[c] = max;
		}

		for (int i = 0; i < n; i++)
		{
			d[s[i]].Enqueue(i);
			lastIndexes[s[i]] = i;
		}

		var length = d.Count(p => p.Value.Any());
		var r = new char[length];

		for (int i = 0; i < length; i++)
		{
			for (char c = 'z'; c >= 'a'; c--)
			{
				if (lastIndexes[c] == max) continue;

				if (IsNext(c))
				{
					r[i] = c;

					var index = d[c].Dequeue();
					d[c].Clear();
					lastIndexes[c] = max;

					for (char c2 = 'a'; c2 <= 'z'; c2++)
					{
						if (lastIndexes[c2] == max) continue;

						var q = d[c2];
						while (q.Peek() < index)
							q.Dequeue();
					}
					break;
				}
			}
		}

		return new string(r);

		bool IsNext(char c)
		{
			var index = d[c].Peek();

			for (c--; c >= 'a'; c--)
			{
				if (lastIndexes[c] < index) return false;
			}
			return true;
		}
	}
}
