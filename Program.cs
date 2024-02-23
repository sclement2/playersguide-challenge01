using System;
using System.Runtime.Intrinsics.X86;
using System.Threading;

namespace dotnetcore
{
    class Program
    {

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            bool isValid = true;
            while (isValid)
            {
                Console.WriteLine("Enter the height and the base length for the triangle you want to calculate the area for.");
                Console.Write("Height: ");
                if (float.TryParse(Console.ReadLine(), out float height))
                {
                    Console.WriteLine($"You input {height} for the height");
                }
                else
                {
                    Console.WriteLine("Please enter a valid number for the height");
                    Console.WriteLine("Exiting the program");
                    break;
                }
                Console.Write("Length: ");
                if (float.TryParse(Console.ReadLine(), out float length))
                {
                    Console.WriteLine($"You input {length} for the height");
                }
                else
                {
                    Console.WriteLine("Please enter a valid number for the length");
                    Console.WriteLine("Exiting the program");
                    break;
                }

                float area = PythagCalc(height, length);
                Console.WriteLine($"\nThe area of your triangle is {area}");

                Console.Write($"\nDo you want to calculate the area of another triangle? (Y or N) ");
                string response = Console.ReadLine();
                if (!string.Equals(response, "y", StringComparison.OrdinalIgnoreCase))
                {
                    isValid = false;
                    Console.WriteLine("Exiting the program. Good-bye");
                }
            }
        }

        static float PythagCalc(float height, float length)
        {
            return length * height / 2.0f;
        }
    }
}
