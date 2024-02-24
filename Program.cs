using System;
using System.Collections.Generic;
 
namespace dotnetcore
{
    class Program
    {

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //ChallengeFarmer();
            ChallengeDuckbear();
            DuckbearMore();
        }

        static float PythagCalc(float height, float length)
        {
            return length * height / 2.0f;
        }

        static void ChallengeFarmer()
        {
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

        static void ChallengeDuckbear()
        {
            Console.WriteLine("How many eggs were gathered today?");
            int eggCount = int.Parse(Console.ReadLine());
            int remainingEggs = eggCount % 4;
            if (remainingEggs == 0)
            {
                Console.WriteLine($"The number of eggs each sister receives: {eggCount / 4}.\nThe duckbear does not receive any eggs. Sorry duckbear.");
            }
            else
            {
                Console.WriteLine($"The number of eggs each sister receives: {(eggCount - remainingEggs) / 4}.\nThe number of eggs the duckbear receives: {remainingEggs}");
            }
        }

        static void DuckbearMore()
        {
            int count = 0;
            List<int> eggCounts = [];
            int remainingEggs;
            int eggCount = 1;

            while (count < 3)
            {
                remainingEggs = eggCount % 4;
                if (remainingEggs > (eggCount - remainingEggs) / 4)
                {
                    eggCounts.Add(eggCount);
                    count++;
                }
                eggCount++;

            }

            foreach (var item in eggCounts)
            {
                Console.WriteLine($"Egg count where the Duckbear receives more than the sisters: {item}");
            }
        }
    }
}
