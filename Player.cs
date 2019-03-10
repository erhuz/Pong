using System;

namespace Pong
{
    public class Player : Entity
    {
        private readonly string name;
        private int score = 0;

        public Player(string name, int xPos, int yPos, int size = 5, ConsoleColor = ConsoleColor.Blue)
        {
            this.name = name;
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public void Draw(){
            
        }
    }
}