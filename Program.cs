using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Sources;
using System.Windows.Markup;

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
            //DefenseChallenge();
            //WatchTower();
            //RepairClockTower();
            //BuyInventory();
            //Prototype();
            MagicCannon();
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

        static void WatchTower()
        {
            bool isValid = true;
            string attackDirection;

            while (isValid)
            {
                Console.Write("What are the X-coordinates? ");
                int xCoord = Convert.ToInt32(Console.ReadLine());
                Console.Write("What are the Y-coordinates? ");
                int yCoord = Convert.ToInt32(Console.ReadLine());

                // Find the direction the enemy is coming from

                if (xCoord == 0 && yCoord == 0)
                {
                    attackDirection = "here";
                }
                else
                {
                    char xDir = xCoord < 0 ? 'W' : (xCoord > 0 ? 'E' : '\0');
                    char yDir = yCoord < 0 ? 'S' : (yCoord > 0 ? 'N' : '\0');

                    if (xDir == '\0')
                    {
                        attackDirection = $"{yDir}";
                    }
                    else if (yDir == '\0')
                    {
                        attackDirection = $"{xDir}";
                    }
                    else
                    {
                        attackDirection = $"{yDir}{xDir}";
                    }
                }

                if (attackDirection == "here")
                {
                    Console.WriteLine("The enemy is here!");
                }
                else
                {
                    Console.WriteLine($"The enemy is to the {attackDirection}.");
                }

                Console.Write("Do you want to determine the location of another enemy? (Y or N) ");
                string response = Console.ReadLine();
                if (response != null && response.Length == 1)
                {
                    response = response.ToUpper();
                    isValid = response.StartsWith('Y') == true;

                }
                else
                {
                    Console.WriteLine("You did not provide a valid response.");
                    isValid = false;
                }

            }
            Console.WriteLine("Thanks for defending our city.");
        }

        static void RepairClockTower()
        {
            Console.WriteLine("Please enter a number.");
            int number = int.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine("Tick");
            }
            else
            {
                Console.WriteLine("Tock");
            }
        }

        static void BuyInventory()
        {
            Console.WriteLine("Welcome to Tortuga's Supply Store.");
            Console.Write("Who do I have the pleasure of talking to? ");
            string name = Console.ReadLine();

            float discount = 1.0f;
            string welcome = $"Nice to meet you {name}.";

            if (string.Equals(name, "Scott", StringComparison.OrdinalIgnoreCase))
            {
                // Program creator receives a discount on the prices
                discount = 1.0f - 0.5f;
                welcome = $"Glad to see you again {name}.";
            }

            Console.WriteLine($"{welcome}\n");
            Console.WriteLine("The following items are available for purchase:");
            Console.WriteLine("1. Rope");
            Console.WriteLine("2. Torches");
            Console.WriteLine("3. Climbing Equipment");
            Console.WriteLine("4. Clean Water");
            Console.WriteLine("5. Machete");
            Console.WriteLine("6. Canoe");
            Console.WriteLine("7. Food Rations");
            Console.Write("What item do you want to see the price of? Enter the number of the item: ");

            int itemNumber = int.Parse(Console.ReadLine());
            string response = itemNumber switch
            {
                1 => $"Rope cost {(Math.Round(10 * discount) <= 0 ? 1 : Math.Round(10 * discount))} gold",
                2 => $"Torches cost {(Math.Round(15 * discount) <= 0 ? 1 : Math.Round(15 * discount))} gold",
                3 => $"Climbing Equipment cost {(Math.Round(25 * discount) <= 0 ? 1 : Math.Round(25 * discount))} gold",
                4 => $"Clean Water cost {(Math.Round(1 * discount) <= 0 ? 1 : Math.Round(1 * discount))} gold",
                5 => $"Machete cost {(Math.Round(20 * discount) <= 0 ? 1 : Math.Round(20 * discount))} gold",
                6 => $"Canoe cost {(Math.Round(200 * discount) <= 0 ? 1 : Math.Round(200 * discount))} gold",
                7 => $"Food Rations cost {(Math.Round(1 * discount) <= 0 ? 1 : Math.Round(1 * discount))} gold",
                _ => "Invalid item number",
            };

            Console.WriteLine(response);


        }

        static void Prototype()
        {
            const int minNumber = 0;
            const int maxNumber = 100;

            bool playAgain = true;
            while (playAgain)
            {
                int userNumber = GetUserNumber(minNumber, maxNumber);
                if (userNumber == -1) // Error occurred
                    return;
                else if (userNumber == -2)
                    continue;

                Console.WriteLine($"User1 entered {userNumber}");
                //Console.Clear();

                int guessedNumber = GuessNumber(userNumber);
                if (guessedNumber == -2)
                    continue;

                Console.WriteLine($"You guessed right! {guessedNumber} is the number.");
                Console.Write("Do you want to play again? (Y or N) ");
                char response = char.ToUpper(Console.ReadKey().KeyChar);

                Console.WriteLine();
                playAgain = response == 'Y';
            }
        }

        static int GetUserNumber(int minNumber, int maxNumber)
        {
            Console.WriteLine($"User1, please enter an integer between {minNumber} and {maxNumber}.");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if (result >= minNumber && result <= maxNumber)
                    return result;
                else
                {
                    Console.WriteLine($"Invalid response. Your integer was not between {minNumber} and {maxNumber}.");
                    return -2; // error, try again
                }
            }
            else
                Console.WriteLine("You entered an invalid response. Next time please follow the instructions. Program is exiting.");

            return -1;
        }

        static int GuessNumber(int pilotInput)
        {
            //bool isValid = true;
            Console.WriteLine("User2, you need to guess User1's number");
            while (true)
            {
                Console.Write("What is your next guess? ");
                if (int.TryParse(Console.ReadLine(), out int user2Guess))
                {
                    if (user2Guess < pilotInput)
                        Console.WriteLine($"{user2Guess} is too low.");
                    else if (user2Guess > pilotInput)
                        Console.WriteLine($"{user2Guess} is too high.");
                    else
                        return user2Guess; // guessed correctly
                }
                else
                {
                    Console.WriteLine("You entered an invalid response. Program is restarting.");
                    return -2; // error, restart the game
                }
            }
        }

        static void MagicCannon()
        {
            const int MaxNumber = 100;
            const int DivideByThree = 3;
            const int DivideByFive = 5;

            const string FireText = "Fire";
            const string ElectricText = "Electric";
            const string ElectricAndFireText = "Electric and Fire";
            const string NormalText = "Normal";

            const ConsoleColor NormalColor = ConsoleColor.White;
            const ConsoleColor FireColor = ConsoleColor.Red;
            const ConsoleColor ElectricColor = ConsoleColor.Blue;
            const ConsoleColor ElectricAndFireColor = ConsoleColor.Yellow;

            for (int number = 1; number <= MaxNumber; number++)
            {

                Console.ForegroundColor = NormalColor;
                Console.Write($"{number}: ");
                if (number % DivideByThree == 0 && number % DivideByFive == 0)
                {
                    Console.ForegroundColor = ElectricAndFireColor;
                    Console.WriteLine(ElectricAndFireText);
                }
                else if (number % DivideByThree == 0)
                {
                    Console.ForegroundColor = FireColor;
                    Console.WriteLine(FireText);
                }
                else if (number % DivideByFive == 0)
                {
                    Console.ForegroundColor = ElectricColor;
                    Console.WriteLine(ElectricText);
                }
                else{
                    Console.ForegroundColor = NormalColor;
                    Console.WriteLine(NormalText);
                }
            }
        }
    }
}
