using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curry.Demo
{
	public class Program
	{
		static void Main(string[] args)
		{
			// "the process of transforming a function that takes multiple arguments into a function that takes just a single argument and returns another function if any arguments are still needed." 

			// using add is probably not that great an example since it takes two arguments always
			// need an example with variable arguments that demonstrates usefulness of currying
			Func<int, Func<int, int>> add = delegate(int x)
			{
				return delegate(int y)
				{
					return x + y;
				};
			};

			//Func<int, Func<int, int>> addd = (x) =>
			//{
			//	return y => x + y;
			//};

			int value = add(1)(41);

			// create arbitrary specifialied functions
			// this is a function where 42 is set as the first argument (in a closure)
			Func<int, int> add42 = add(42);

			Console.WriteLine(value);
			Console.WriteLine(add42(1));
		}
	}
}
