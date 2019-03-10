using System;

namespace Pong {
    public class Game {
        private int duration = 0;
        public Game () {

            // Initialize game
            Console.Clear ();
            Console.CursorVisible = false;
            GameBoard board = new GameBoard (60, 16, 4, 2);
            board.Draw ();

            Player player1 = new Player("John", board.GetBorderLeft() + 2, (board.GetBorderBottom()), ConsoleColor.Blue);
            Player player2 = new Player("John", board.GetBorderRight() - 2, (board.GetBorderBottom()), ConsoleColor.Red);
            player1.Draw();
            player2.Draw();
        }
    }
}