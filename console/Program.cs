using System;
using business;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            var expressions = new []
                {
                    "(2-0)(6/2)",
                    "2+(3-1)3"
                };
            
            var calculator = new Calculator();

            foreach(var expression in expressions)
            {
                var result = calculator.Calculate(expression);
                Console.WriteLine($"{expression} = {result}");
            }
        }
    }
}
