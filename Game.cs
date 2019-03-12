using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pong {
    public class Game {

        private int duration = 0;

        public Game () {

            Console.Clear ();
            Console.CursorVisible = false;

            GameBoard board = new GameBoard (60, 16, 4, 2);
            Ball ball = new Ball(board.GetCenterHorizontal(), board.GetCenterVertical(), ConsoleColor.Green);
            Player player1 = new Player("John", board.GetBorderLeft() + 2, (board.GetCenterVertical()), ConsoleColor.Blue);
            Player player2 = new Player("Alex", board.GetBorderRight() - 2, (board.GetCenterVertical()), ConsoleColor.Red);
            
            board.Draw ();
            ball.Draw();
            player1.Draw();
            player2.Draw();

            this.Start();
        }

        public void Start()
        {
            ConsoleKey? input = null;
            bool playing = true;

            // Read input on separate thread to not block game-loop
            Task.Factory.StartNew(() =>
            {
                while (playing)
                {

                    input = Console.ReadKey().Key;
                    Thread.Sleep(10);
                }
            });

            while (playing)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(Console.KeyAvailable);
                input = null;

                Thread.Sleep(50);
            }

            
        }
    }
}