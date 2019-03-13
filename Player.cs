using System;

namespace Pong
{
    public class Player : Entity
    {
        private readonly string name;
        private int score = 0;
        private int size;

        public Player(
            string name,
            int xPos,
            int yPos,
            int size = 3,
            ConsoleColor color = ConsoleColor.Blue
        ){
        
            this.name = name;
            this.xPos = xPos;
            this.size = size;
            this.color = color;
            this.yPos = yPos - (size / 2); // Center player position vertically
        }

        // public bool Move(int y){
        //     if(this.WillEntityHitBarrier())
        // }

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

        public void CleanDraw(){
                Console.SetCursorPosition(this.xPos, this.yPos);
                Console.Write(" ");
                Console.SetCursorPosition(this.xPos, this.yPos + this.size - 1);
                Console.Write(" ");
        }
    }
}