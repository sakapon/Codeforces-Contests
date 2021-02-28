using System;

class B
{
	static void Main()
	{
		var h = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
		double a = h[0], b = h[1], c = h[2];
		if (a < 0) (a, b, c) = (-a, -b, -c);
		var d = b * b - 4 * a * c;

		if (a != 0)
		{
			if (d > 0)
			{
				Console.WriteLine(2);
				Write((-b - Math.Sqrt(d)) / (2 * a));
				Write((-b + Math.Sqrt(d)) / (2 * a));
			}
			else if (d == 0)
			{
				Console.WriteLine(1);
				Write(-b / (2 * a));
			}
			else
			{
				Console.WriteLine(0);
			}
			return;
		}

		if (b != 0)
		{
			Console.WriteLine(1);
			Write(-c / b);
			return;
		}

		Console.WriteLine(c == 0 ? -1 : 0);
	}

	static void Write(double d) => Console.WriteLine($"{d:F6}");
}
