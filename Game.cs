using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pong {
    public class Game {

        private int speed = 100;
        private int duration;
        private int playerSize = 4;

        private int boardWidth = 80;
        private int boardHeight = 24;
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

                // Move Player / Bot
                player1.CleanDraw ();
                player2.CleanDraw ();
                ball.CleanDraw ();

                // Move Player / Bot
                player1.Move ();
                player2.Move ();
                ball.Move ();

                player1.Draw ();
                player2.Draw ();
                ball.Draw ();

                Thread.Sleep (this.speed);
            }
        }

        // private void KeypressListener()
        // {

        //     DateTime lastDrawnProjectile = DateTime.MinValue;

        //     ConsoleKey key;
        //     do
        //     {
        //         /*
        //          * while (!Console.KeyAvailable) { }
        //          */

        //         key = Console.ReadKey(true).Key;

        //         switch (key)
        //         {
        //             case ConsoleKey.UpArrow:
        //             {
        //                 if (Player.Move(-1))
        //                     Player.Draw();
        //                 break;
        //             }
        //             case ConsoleKey.DownArrow:
        //             {
        //                 if (Player.Move(1))
        //                     Player.Draw();
        //                 break;
        //             }
        //             case ConsoleKey.Spacebar:
        //             {
        //                 if (DateTime.Now > lastDrawnProjectile.AddSeconds(1))
        //                 {
        //                     var projectile = new Projectile(Console.WindowHeight - 3,Player.Position, 1);
        //                     Projectiles.Add(projectile);
        //                     projectile.Draw();
        //                     lastDrawnProjectile = DateTime.Now;
        //                 }

        //                 break;
        //             }
        //         }

        //     } while (key != ConsoleKey.Escape);

        //     Environment.Exit(0);
        // }
    }
}