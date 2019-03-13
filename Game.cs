using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pong {
    public class Game {

        private int speed = 10;
        private int duration;

        public Game (int width, int height, int xOffset, int yOffset) {

            Console.Clear ();
            Console.CursorVisible = false;

            bool playing = true;

            GameBoard board = new GameBoard (width, height, xOffset, yOffset);
            Ball ball = new Ball(board.GetCenterHorizontal(), board.GetCenterVertical(), ConsoleColor.Green);
            Player player1 = new Player("John", board.GetBorderLeft() + 2, (board.GetCenterVertical()), 3, ConsoleColor.Blue);
            Bot player2 = new Bot("Bot", board.GetBorderRight() - 2, (board.GetCenterVertical()));
            
            board.Draw ();
            ball.Draw();
            player1.Draw();
            player2.Draw();

            while(playing){
                player2.CleanDraw();
                if(player2.WillEntityHitBarrier(
                    board.GetBorderTop(),
                    board.GetBorderBottom(),
                    board.GetBorderLeft(),
                    board.GetBorderRight())
                ){
                    player2.ChangeDirection();
                }
                player2.Move();
                player2.Draw();
                
                Thread.Sleep(this.speed);
            }

            // this.Start();
        }

            
        // }

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