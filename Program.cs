using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

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
            //MagicCannon();
            //ArrayChallenge1();
            //ArrayChallenge2();
            //CountToTen();
            //Count(22);
            //Count(20, 30);
            RecursionChallenge();

            /*
            int resultNumber = AskForNumber("Please enter an integer");
            if (!(resultNumber == -1))
                Console.WriteLine(resultNumber);
            resultNumber = AskForNumberInRange("Please enter a number in the following range", 20, 30);
            if (!(resultNumber == -1))
                Console.WriteLine(resultNumber);

            */
        }

        // Part of Recursion Challenge.
        static void RecursionChallenge()
        {
            // Recursion Challenge. Count down with no loops
            int minCountToNumber = 1;
            int maxCountFromNumber = 10;
            Console.WriteLine("Let's do some counting. We are going to count down from a number you supply to the number " + minCountToNumber);
            int fromNumber = AskForNumberInRange("Please provide an integer in the following range", minCountToNumber + 1, maxCountFromNumber);
            if (fromNumber == -1) return;
            Console.WriteLine(RecursionCount(fromNumber, minCountToNumber));
        }

        // Part of the Triangle Farmer Challenge.
        static float PythagCalc(float height, float length)
        {
            return length * height / 2.0f;
        }

        // Part of Overload a Method Example
        static void Count(int numberToCountTo)
        {
            for (int current = 0; current <= numberToCountTo; current++)
                Console.WriteLine(current);
        }

        // Part of Overload a Method Example
        static void Count(int startingNumber, int numberToCountTo)
        {
            for (int current = startingNumber; current <= numberToCountTo; current++)
                Console.WriteLine(current);
        }

        // Part of Recursion Challenge.
        static int RecursionCount(int fromNumber, int toNumber)
        {
            if (fromNumber == toNumber) return toNumber;
            Console.WriteLine(fromNumber);
            return RecursionCount(fromNumber - 1, toNumber);
        }

        // Part of Taking a Number Challenge
        /// <summary>
        /// Enable a user to specify a (integer) number. User supplies a text prompt that informs the user what input is required.
        /// Simple error checking used. If method returns from an unacceptable response a -1 is returned and the calling program can use this value to deal with the unacceptable response.
        /// </summary>
        /// <param name="promptText"></param>
        /// <returns>Integer number or an error value</returns>
        static int AskForNumber(string promptText)
        {
            Console.Write($"{promptText}: ");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            Console.WriteLine("You did not enter an integer.");
            return -1;
        }

        // Part of Taking a Number Challenge
        /// <summary>
        /// Enable a user to specify a (integer) number in a specified range. User supplies a text prompt that asks the user for the number. Currently the explanation of what the number is for must reside in the calling program.
        /// Simple error checking used. Method will keep prompting for an integer in the acceptable range. If method returns from an unacceptable response (e.g. a float) a -1 is returned and the calling program can use this value to deal with the unacceptable response.
        /// </summary>
        /// <param name="promptText"></param>
        /// <param name="minNumber"></param>
        /// <param name="maxNumber"></param>
        /// <returns>Integer number in a specified range or an error value</returns>
        static int AskForNumberInRange(string promptText, int minNumber, int maxNumber)
        {
            while (true)
            {
                Console.Write($"{promptText}: Min = {minNumber} - Max = {maxNumber}: ");
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    if (result >= minNumber && result <= maxNumber)
                        return result;
                    else
                    {
                        Console.WriteLine("Sorry, Your response was not valid. Let's try this again.");
                        continue;
                    }
                }
                Console.WriteLine("You did not enter an integer.");
                return -1;
            }
        }

        // Part of the Triangle Farmer Challenge.
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

        // Part of the Four Sisters and the Duckbear Challenge.
        static void ChallengeDuckbear()
        {
            //Console.WriteLine("How many eggs were gathered today?");
            //int eggCount = int.Parse(Console.ReadLine());
            int eggCount = AskForNumber("How many eggs were gathered today");
            if (!(eggCount == -1))
            {
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
        }

        // Part of the Four Sisters and the Duckbear Challenge.
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

        // Part of the Dominion of Kings Challenge.
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

        // Part of the Defense of Consolas Challenge.
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

        // Part of the Watchtower Challenge.
        static void WatchTower()
        {
            bool isValid = true;
            string attackDirection;

            while (isValid)
            {
                int minXCoord = 1;
                int maxXCoord = 20;
                int minYCoord = 1;
                int maxYCoord = 15;

                Console.WriteLine("What are the X-coordinates?");
                int xCoord = AskForNumberInRange("Please enter an integer in the following range", minXCoord, maxXCoord);
                if (xCoord == -1)
                    return;
                Console.WriteLine("What are the Y-coordinates?");
                int yCoord = AskForNumberInRange("Please enter an integer in the following range", minYCoord, maxYCoord);
                if (yCoord == -1)
                    return;

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

        // Part of the Repairing the Clocktower Challenge.
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

        // Part of the Discounted Inventory Challenge. Based on the Buying Inventory Challenge
        static void BuyInventory()
        {
            int minNumberItem = 1;
            int maxNumberItem = 7;
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
            Console.Write("What item do you want to see the price of? ");
            int itemNumber = AskForNumberInRange("Enter the number of the item in the following range", minNumberItem, maxNumberItem);

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

        // Part of the Prototype Challenge.
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

        // Part of the Prototype Challenge.
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

        // Part of the Prototype Challenge.
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

        // Part of the Magic Cannon Challenge.
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
                else
                {
                    Console.ForegroundColor = NormalColor;
                    Console.WriteLine(NormalText);
                }
            }
        }

        // Part of the Replicator of D'To Challenge.
        static void ArrayChallenge1()
        {
            int originalArrayLength = 5;
            int[] originalArray = new int[originalArrayLength];
            int[] newArray = new int[originalArray.Length];

            Console.WriteLine($"Please provide {originalArray.Length} integer values.");
            for (int index = 0; index < originalArray.Length; index++)
            {
                Console.Write($"{index + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    originalArray[index] = number;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Exiting program.");
                    return;
                }
            }

            Console.WriteLine("You entered the following values:");
            for (int index = 0; index < originalArray.Length; index++)
            {
                Console.WriteLine(originalArray[index]);
            }

            Console.WriteLine("Copying your original array into a new array...");
            for (int index = 0; index < originalArray.Length; index++)
            {
                newArray[index] = originalArray[index];
            }

            Console.WriteLine("Here's the contents of both arrays...");
            for (int index = 0; index < originalArray.Length; index++)
            {
                Console.Write($"({index + 1}) Original array value: {originalArray[index]} - ");
                Console.Write($"New array value: {newArray[index]}\n");
            }
        }

        // Part of the Laws of Freach Challenge.
        static void ArrayChallenge2()
        {
            int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

            Console.Write("Given the following array: { ");
            for (int index = 0; index < array.Length; index++)
            {
                if (index < array.Length - 1)
                {
                    Console.Write($"{array[index]}, ");
                }
                else
                {
                    Console.Write(array[index] + " }\n");
                }
            }
            int currentSmallest = int.MaxValue;
            foreach (int value in array)
            {
                if (value < currentSmallest)
                    currentSmallest = value;
            }

            Console.WriteLine($"Smallest value in the array: {currentSmallest}");

            int total = 0;
            foreach (int value in array)
                total += value;

            float average = (float)total / array.Length;
            Console.WriteLine($"The average of all the array values is {average}");
        }
    }
}
