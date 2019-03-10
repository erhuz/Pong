using System;

namespace Pong
{
    public class Game
    {
        private int duration = 0;
        public Game(){

            // Initialize game
            Console.CursorVisible = false;
            GameBoard board = new GameBoard (60, 16, 4, 2);
            board.Draw ();
        }
    }
}