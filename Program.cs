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
            //ChallengeDuckbear();
            //DuckbearMore();
            //KingChallenge();
            DefenseChallenge();
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

        static void KingChallenge()
        {
            bool isValid = true;
            int pointTotal;
            //Console.BackgroundColor = ConsoleColor.DarkYellow;
            //Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            //Console.Title = "King Greatness";

            while (isValid)
            {
                Console.Write("Hello, what is your name? ");
                string name = Console.ReadLine();
                Console.WriteLine($"\nNice to meet you King {name}.");
                Console.WriteLine("Let's determine how great your kingdom is.");
                Console.WriteLine("We are going to calculate your greatness based on the number of estates, duchies and provinces you have.");
                Console.Write("\nHow many estates do you have? ");
                int estates = int.Parse(Console.ReadLine());
                Console.Write("How many duchies do you have? ");
                int duchies = int.Parse(Console.ReadLine());
                Console.Write("How many provinces do you have? ");
                int provinces = int.Parse(Console.ReadLine());

                pointTotal = estates * 1 + duchies * 3 + provinces * 6;
                Console.WriteLine($"King {name} your greatness is equal to {pointTotal}.");

                Console.Write("\nWould you like to calculate the greatness of another king? (Y or N) ");
                string response = Console.ReadLine();
                if (!string.Equals(response, "y", StringComparison.OrdinalIgnoreCase))
                {
                    isValid = false;
                    Console.WriteLine($"Exiting the program. Good-bye King {name}.");
                }
            }
        }

        static void DefenseChallenge()
        {
            bool isValid = true;
            while (isValid)
            {
                Console.Clear();
                Console.WriteLine("Let\'s defend our city. I need to know the target row and column locations so i can deploy the squad.");
                Console.Write("\nWhat is the target row? ");
                int targetRow = int.Parse(Console.ReadLine());
                Console.Write("What is the target column? ");
                int targetColumn = int.Parse(Console.ReadLine());
                if (targetColumn - 1 >= 1 && targetRow - 1 >= 1)
                {
                    //Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Deploy the squad to:");
                    Console.WriteLine($"({targetRow}, {targetColumn - 1})");
                    Console.WriteLine($"({targetRow - 1}, {targetColumn})");
                    Console.WriteLine($"({targetRow}, {targetColumn + 1})");
                    Console.WriteLine($"({targetRow + 1}, {targetColumn})");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I am not able to defend against that attack.\nWe received damage.");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Are there any additional targets? (Y or N) ");
                string response = Console.ReadLine();
                if (!string.Equals(response, "Y", StringComparison.OrdinalIgnoreCase))
                {
                    isValid = false;
                    Console.WriteLine("Thanks for helping keep our city safe!");
                }

            }
        }
    }
}
