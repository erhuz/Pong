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

            Console.Clear ();
            Console.CursorVisible = false;

            this.Start ();
        }

        private void Start () {
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
            Bot player1 = new Bot (
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

            while (playing) {

                ball.CleanDraw ();
                player1.CleanDraw ();
                player2.CleanDraw ();

                ball.Move (player1, player2);
                player1.FollowBall (ball);
                player2.FollowBall (ball);

                ball.Draw ();
                player1.Draw ();
                player2.Draw ();

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