using System;
using System.Threading;
using System.Collections.Generic;

namespace BinaryToDecimal
{
    class Program
    {
        static int indexMainMenu = 0;

        // checks if digit is other than 0 and 1 
        public static bool isBinary(int number)
        {
            while (number > 0)
            {
                int digit = number % 10;

             
                if (digit > 1)
                    return false;
                number /= 10;
            }
            return true;
        }

        static void Main(string[] args)
        {
        start:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the number you want to convert (1 or 0 only):");
            Console.ForegroundColor = ConsoleColor.Cyan;

            int num;

            while (!int.TryParse(Console.ReadLine(), out num))
            {
                
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The input must be a number!");
                Console.ForegroundColor = ConsoleColor.White;
                goto start;
            }
            
              if (!isBinary(num))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The input must include 1 or 0 only!");
                Console.ForegroundColor = ConsoleColor.White;
                goto start;

            } else if (num < 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The input must include 1 or 0 only!");
                Console.ForegroundColor = ConsoleColor.White;
                goto start;
            }
            else
            {
                int shownum = num; // stores old [entered] number

                // binary value
                int value = 0;

                // initializing base value to 1 (-=- 2^0)
                int Vbase = 1; // [Value Base]
                while (num > 0)
                {
                    int token = num % 10; // modulo operation
                    num = num / 10;
                    value += token * Vbase;
                    Vbase = Vbase * 2;
                }



                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Number ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(shownum);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" in decimal number (system) is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(value);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                Thread.Sleep(1000);
                RunMenu();

                // menu list
                List<string> selectItems = new List<string>()
            {
                "                                Continue",
                "                                  Exit"
            };

                Console.CursorVisible = false;
                while (true)
                {
                    string selectedMenuItem = RunEndMenuEvent(selectItems);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (selectedMenuItem == "                                Continue")
                    {
                        Console.Clear();
                        goto start;
                    }
                    else if (selectedMenuItem == "                                  Exit")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Thanks for using this app");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("- made by Vojtěch Gistr");
                        Console.Write("- GitHub respority: https://github.com/VojtaG/Square-Root-Console-App");


                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("App is closing in 10..");
                        Thread.Sleep(7000);

                        Console.Clear();
                        Console.WriteLine("App is closing in 3..");
                        Thread.Sleep(1000);

                        Console.Clear();
                        Console.WriteLine("App is closing in 2..");
                        Thread.Sleep(1000);

                        Console.Clear();
                        Console.WriteLine("App is closing in 1..");
                        Thread.Sleep(1000);

                        Console.Clear();
                        Console.WriteLine("App was closed.");

                        Environment.Exit(0);
                    }
                }
            }
        }
        //public menu selection - text
        public static void RunMenu()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("       -------------------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("         Do you want to Continue or Exit? Select one of the options");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("       -------------------------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        // example menu code from [edited] -> https://www.codegrepper.com/code-examples/csharp/c%23+console+application+menu+system
        //menu public function
        public static string RunEndMenuEvent(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i == indexMainMenu)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);

                }
                Console.ResetColor();
            }

            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.DownArrow)
            {
                RunMenu();
                if (indexMainMenu == items.Count - 1) { }
                else { indexMainMenu++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                RunMenu();
                if (indexMainMenu <= 0) { }
                else { indexMainMenu--; }
            }
            else if (ckey.Key == ConsoleKey.W)
            {
                RunMenu();
                if (indexMainMenu <= 0) { }
                else { indexMainMenu--; }
            }
            else if (ckey.Key == ConsoleKey.S)
            {
                RunMenu();
                if (indexMainMenu == items.Count - 1) { }
                else { indexMainMenu++; }
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                return items[indexMainMenu];
            }
            else
            {
                Console.Clear();
                RunMenu();
                return "";
            }
            Console.Clear();
            RunMenu();
            return "";
        }
    }
}
