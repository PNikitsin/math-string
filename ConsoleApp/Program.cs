using MathLibrary;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();

                Console.Write("Enter expression: ");
                string expression = Console.ReadLine();

                if (expression == "")
                {
                    Console.WriteLine("Missing expression input!");
                    Console.ReadKey();
                    continue;
                }

                try
                {
                    int result = Calculator.Calculate(expression);
                    Console.WriteLine($"The expression result is: {result}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Division by zero is prohibited!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid expression!");
                }

                Console.ReadKey();
            }
        }
    }
}