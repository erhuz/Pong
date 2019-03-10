using System;

namespace Pong
{
    public class Player : Entity
    {
        private readonly string name;
        private int score = 0;
        private int size;

        public Player(string name, int xPos, int yPos, ConsoleColor color = ConsoleColor.Blue, int size = 3)
        {
            this.name = name;
            this.xPos = xPos;
            this.yPos = (yPos / 2);
            this.size = size;
            this.color = color;
        }

        public void Draw(){
            ConsoleColor initialColor = Console.BackgroundColor;
            Console.BackgroundColor = color;

            for (int i = 0; i < this.size; i++)
            {
                Console.SetCursorPosition(this.xPos, this.yPos + i);
                Console.Write(" ");
            }

            Console.BackgroundColor = initialColor;
            Console.SetCursorPosition (0, 0);
        }
    }
}