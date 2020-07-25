using System;
using System.Text.RegularExpressions;

class A
{
	static void Main()
	{
		var s = Regex.Replace(Console.ReadLine(), "/+", "/");
		Console.WriteLine(s == "/" ? s : s.TrimEnd('/'));
	}
}
