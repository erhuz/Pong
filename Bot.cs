using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pong
{
    public class Bot : Player
    {
        public Bot(string name, int xPos, int yPos)
        : base(name, xPos, yPos, 3, ConsoleColor.Red){
            this.speed = 1;
        }

        // Make some sort of movement method / algorithm
        
        public void ChangeDirection(){
            this.speed *= -1;
        }

        public void Move(){
            this.yPos += this.speed;
        }
    }
}