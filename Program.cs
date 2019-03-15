using System;

namespace Pong {
    class Program {
        static void Main (string[] args) {

            Console.Clear();

            Console.WriteLine("Welcome to Pong!");
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press Q to exit the game at any time.");

            if(Console.ReadKey().Key == ConsoleKey.Q){
                System.Environment.Exit(0);
            }

            Game game = new Game ();

            Console.SetCursorPosition (0, 50);
        }
    }
}