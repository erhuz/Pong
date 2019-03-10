using System;

namespace Pong {
    public class Game {
        private int duration = 0;
        public Game () {

            // Initialize game
            Console.Clear ();
            Console.CursorVisible = false;
            GameBoard board = new GameBoard (60, 16, 4, 2);

            Ball ball = new Ball(board.GetCenterHorizontal(), board.GetCenterVertical(), ConsoleColor.Green);

            Player player1 = new Player("John", board.GetBorderLeft() + 2, (board.GetCenterVertical()), ConsoleColor.Blue);
            Player player2 = new Player("John", board.GetBorderRight() - 2, (board.GetCenterVertical()), ConsoleColor.Red);
            
            
            board.Draw ();
            ball.Draw();
            player1.Draw();
            player2.Draw();
        }
    }
}