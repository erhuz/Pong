using System;

namespace Pong
{
    public class Player : Entity
    {
        private readonly string name;
        private int score = 0;
        private int size;

        public Player(string name, int xPos, int yPos, int size = 5, ConsoleColor = ConsoleColor.Blue)
        {
            this.name = name;
            this.xPos = xPos;
            this.yPos = yPos;
            this.size = size;
        }

        public void Draw(){
            //TODO (5) is to be replaced with left border coordinate
            Console.SetCursorPosition((5)+2, this.yPos);
        }
    }
}