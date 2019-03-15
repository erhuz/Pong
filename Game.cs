using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pong {
    public class Game {

        private int speed = 100;
        private Int64 duration = 0;
        private int playerSize = 4;

        private int boardWidth = 82; // Only (n % 0) + 2 values
        private int boardHeight = 30;
        private int boardXOffset = 4;
        private int boardYOffset = 2;

        public Game () {

            
            Console.CursorVisible = false;
            Console.Clear ();

            for (int i = 4; i > 0; i--)
            {
                Console.WriteLine($"The game will start in {i}");
                Thread.Sleep(1000);
            }

            this.Start ();
        }

        private void Start () {
            ConsoleKey? input = null;
            bool playing = true;

            GameBoard board = new GameBoard (
                this.boardWidth,
                this.boardHeight,
                this.boardXOffset,
                this.boardYOffset
            );
            Ball ball = new Ball (
                board.GetCenterHorizontal (),
                board.GetCenterVertical (),
                board.GetBorderTop (),
                board.GetBorderBottom (),
                board.GetBorderLeft (),
                board.GetBorderRight (),
                ConsoleColor.Green
            );
            Player player1 = new Player (
                "John",
                board.GetBorderLeft () + 2,
                board.GetCenterVertical (),
                board.GetBorderTop (),
                board.GetBorderBottom (),
                this.playerSize
            );
            Bot player2 = new Bot (
                "Bot",
                board.GetBorderRight () - 2,
                board.GetCenterVertical (),
                board.GetBorderTop (),
                board.GetBorderBottom (),
                this.playerSize
            );

            board.Draw ();
            ball.Draw ();
            player1.Draw ();
            player2.Draw ();


            // Read input on separate thread to not block the game-loop
            Task.Factory.StartNew(() =>
            {
                while (playing)
                {

                    input = Console.ReadKey().Key;
                    if(input == ConsoleKey.Q){
                        System.Environment.Exit(0);
                    }
                    Thread.Sleep(this.speed / 2);
                }
            });

            while (playing) {

                ball.CleanDraw ();
                player1.CleanDraw ();
                player2.CleanDraw ();


                if(input == ConsoleKey.UpArrow){
                    player1.Move (-1);
                }else if(input == ConsoleKey.DownArrow){
                    player1.Move (1);
                }
                player2.FollowBall (ball);
                ball.Move (player1, player2);

                ball.Draw ();
                player1.Draw ();            
                player2.Draw ();

                // input = null; Don't reset input due to clumpsy movement
                Thread.Sleep (this.speed);
            }
        }

        private void KeypressListener(Player player)
        {

            ConsoleKey key;
            do
            {
                /*
                 * while (!Console.KeyAvailable) { }
                 */

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        if (player.Move(-1))
                        {
                            player.Draw();
                        }
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        if (player.Move(1))
                        {
                            player.Draw();
                        }
                        break;
                    }
                }

            } while (key != ConsoleKey.Escape);

            Environment.Exit(0);
        }
    }
}