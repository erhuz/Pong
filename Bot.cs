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

        public void FollowBall (Ball ball) {
            if(WillEntityHitBarrier(topBarrier, bottomBarrier)){
                string determinedBarrier = WhichBarrierWillEntityHit(topBarrier, bottomBarrier);

                if(
                    !(determinedBarrier == "top" && ball.ySpeed < 0) &&
                    !(determinedBarrier == "bottom" && ball.ySpeed > 0)
                ){
                    if(size % 2 == 0){
                        if(determinedBarrier == "top"){
                            this.yPos = ball.yPos - (size / 2) + 1;
                        }else{
                            this.yPos = ball.yPos - (size / 2);
                        }
                    }else{
                        this.yPos = ball.yPos - (size / 2) + 1;
                    }
                }

            }
            else
            {
                this.yPos = ball.yPos - (size / 2);
            }
        }
    }
}