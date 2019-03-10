using System;

namespace Pong
{
    public class Ball : Entity
    {
        public Ball(int xPos, int yPos, ConsoleColor color = ConsoleColor.White)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.color = color;
        }

        public void Draw(){
            ConsoleColor initialColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
            
            Console.SetCursorPosition(this.xPos - 1, this.yPos);
            Console.Write(" ");
            Console.SetCursorPosition(this.xPos, this.yPos);
            Console.Write(" ");

            Console.BackgroundColor = initialColor;
            Console.SetCursorPosition (0, 0);
        }
    }
}