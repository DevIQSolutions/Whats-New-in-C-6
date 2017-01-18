using System;
using DevIQ.NewInCSharpSixDemo.Demos;

namespace DevIQ.NewInCSharpSixDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();
                uint numberSelection = GetUserInput();
                if (numberSelection == 0) break;

                RunSelectedDemo(numberSelection);
                                
                Console.WriteLine("Press Enter to Continue.");
                Console.ReadLine();
            }
        }

        private static void RunSelectedDemo(uint numberSelection)
        {
            switch (numberSelection)
            {
                case 0: // exit
                    return;
                case 1:
                    AutoPropertyInitialization.RunDemo();
                    break;
                case 2:
                    ExpressionBodiedMembers.RunDemo();
                    break;
                case 3:
                    StringImprovements.RunDemo();
                    break;
                case 4:
                    InLineCodeImprovements.RunDemo();
                    break;
                case 5:
                    ExceptionImprovements.RunDemo();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public static uint GetUserInput()
        {
            string userInput = Console.ReadLine();
            uint numberSelection;
            while (!uint.TryParse(userInput, out numberSelection) && numberSelection < 6)
            {
                Console.WriteLine("Invalid selection please try again: ");
                userInput = Console.ReadLine();
            }
            return numberSelection;
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Please select a demo: ");
            Console.WriteLine("1 - Auto-Property Initialization");
            Console.WriteLine("2 - Expression-Bodied Members");
            Console.WriteLine("3 - String Improvements");
            Console.WriteLine("4 - In-Line Code Improvements");
            Console.WriteLine("5 - Exception Improvements");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
