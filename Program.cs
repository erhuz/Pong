using System;

namespace Pong {
    class Program {
        static void Main (string[] args) {



            // Initialize game
            Console.CursorVisible = false;
            
            GameBoard board = new GameBoard(60, 16, 4, 2);
            board.Draw();
        }
    }
}