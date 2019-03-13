using System;

namespace Pong {
    class Program {
        static void Main (string[] args) {

            // Build a menu

            Game game = new Game (60, 16, 4, 2);

            Console.SetCursorPosition(0,50);
        }
    }
}