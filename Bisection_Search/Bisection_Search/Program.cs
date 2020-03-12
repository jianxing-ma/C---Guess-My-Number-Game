using System;
using System.Collections.Generic;
using System.Linq;

namespace Bisection_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n------------------ Implement bisection algorithm ------------\n"); 

            int[] list = new int[10];
            for (int i = 0; i < 10;i++)
            {
                list[i] = i + 1;
            }

            Console.Write("Input a number between 1 to 10: ");
            bool judge;            
            do
            {
                judge = int.TryParse(Console.ReadLine(), out int input) && (input >= 1 && input <= 10);
                if (judge)
                {
                    Bisection_Search(input, list);
                }
                else
                {
                    Console.Write("\nInput must be a number between 1 and 10.\n " +
                        "Choose your number: ");
                }
            } while (!judge);


            Console.WriteLine("\n-------------------Guess my number, human plays---------------\n");


            GuessMyNumberHuman(1000);


            Console.WriteLine("\n-------------------Guess my number, computer plays-------------------\n");
            

            Console.Write("Let the computer guess your number, choose your number between 1 and 100: ");
            bool invalid;
            do
            {
                invalid = int.TryParse(Console.ReadLine(), out int mynumber) && (mynumber >= 1 && mynumber <= 100);
                if (invalid)
                {
                    GuessMyNumberComputer(mynumber, 100);
                }
                else
                {
                    Console.Write("\nInput must be a number between 1 and 100.\n" +
                        "Choose your number: ");
                }
            } while (!invalid);


        }

//__________________________________________________________________________________________________________________

        public static void Bisection_Search(int x, int[] list)
        {
            int mid = (list[0] + list[list.Length - 1]) / 2;
            if (x < mid)
            {
                Console.WriteLine($"Value is lower than {mid}");
                Bisection_Search(x, list.TakeWhile(n => n < mid).ToArray());
            }
            else if (x > mid)
            {
                Console.WriteLine($"Value is higher than {mid}");
                Bisection_Search(x, list.SkipWhile(n => n <= mid).ToArray());
            }
            else
            {
                Console.WriteLine($"Value is equal to {mid}");
                Console.WriteLine($"The value searched for, {x}, has been found."); 
            }
        }

        public static void GuessMyNumberHuman(int range)
        {
            int number = new Random().Next(range + 1);
            int counter = 0;
            Console.Write("Guess the number(between 1 and 1000): ");
            do
            {
                bool valid = int.TryParse(Console.ReadLine(), out int guess) && (guess >= 1 && guess <= 1000);
                if (valid)
                {
                    if (guess < number)
                    {
                        Console.Write("Your guess was too low, guess another number: ");
                        counter++;
                    }
                    else if (guess > number)
                    {
                        Console.Write("Your guess was too high, guess another number: ");
                        counter++;
                    }
                    else
                    {
                        counter++;
                        Console.WriteLine($"\nYou guessed the number! It took you {counter} times.");
                        break;
                    }
                }
                else
                {
                    Console.Write("Input must be a number between 1 and 1000.\n" +
                        "Choose your number again: ");
                }
            } while (true);
        }

        public static void GuessMyNumberComputer(int number, int range)
        {
            int counter = 0;
            int lowbound = 0;
            int highbound = range;
            do
            {
                int guess = (lowbound + highbound) / 2;

                if (guess < number)
                {
                    Console.WriteLine($"Computer guessed {guess}, it was too low.");
                    lowbound = guess;
                    counter++;
                }
                else if (guess > number)
                {
                    Console.WriteLine($"Computer guessed {guess}, it was too high.");
                    highbound = guess;
                    counter++;
                }
                else
                {
                    counter++;
                    Console.WriteLine($"Computer guessed the number {number}. It took computer {counter} times.");
                    break;
                }
            } while (true);
        }

    }
    
}
