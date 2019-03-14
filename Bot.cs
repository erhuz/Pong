using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pong {
    public class Bot : Player {
        public Bot (string name, int xPos, int yPos, int topBarrier, int bottomBarrier, int size = 3)
         : base (name, xPos, yPos, topBarrier, bottomBarrier, size, ConsoleColor.Red) {
            this.speed = 1;
        }

        // Make some sort of movement method / algorithm

        public void ChangeDirection () {
            this.speed *= -1;
        }

        public void Move () {
            if(this.WillEntityHitBarrier(this.topBarrier, this.bottomBarrier)){
                this.ChangeDirection();
            }

            this.yPos += this.speed;
        }
    }
}