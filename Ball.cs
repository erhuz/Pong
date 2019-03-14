using System;

namespace Pong {
    public class Ball : Entity {

        private int ySpeed;
        private int xSpeed;

        private int topBarrier;
        private int bottomBarrier;
        private int leftBarrier;
        private int rightBarrier;

        public Ball (
            int xPos,
            int yPos,
            int topBarrier,
            int bottomBarrier,
            int leftBarrier,
            int rightBarrier,
            ConsoleColor color = ConsoleColor.White,
            int speed = 1
        ) {
            this.xPos = xPos;
            this.yPos = yPos;
            this.color = color;

            this.topBarrier = topBarrier;
            this.bottomBarrier = bottomBarrier;
            this.leftBarrier = leftBarrier;
            this.rightBarrier = rightBarrier;

            this.xSpeed = speed * 1; // 2
            this.ySpeed = speed;
        }

        public bool WillEntityHitBarrier (int top, int bottom, int left, int right, int speed = 1) {

            if (
                this.yPos - speed <= top ||
                this.yPos + speed >= bottom ||
                this.xPos - speed - 1 <= left ||
                this.xPos + speed >= right
            ){
                return true;
            }

            return false;
        }

        public string WhichBarrierWillEntityHit (int top, int bottom, int left, int right, int speed = 1) {
            if(
                (this.yPos + speed >= bottom && this.xPos - speed - 2 <= left) || // bottom left
                (this.yPos - speed <= top && this.xPos - speed - 2 <= left) || // top left
                (this.yPos + speed >= bottom && this.xPos + speed + 1 >= right) || // bottom right
                (this.yPos - speed <= top && this.xPos + speed + 1 >= right) // top right
            ){
                return "corner";
            }

            if (this.yPos + speed >= bottom) {
                return "bottom";
            }
            
            if (this.yPos - speed <= top) 
            {
                return "top";
            }
            
            if (this.xPos - speed - 2 <= left) 
            {
                return "left";
            }
            
            if (this.xPos + speed + 1 >= right) 
            {
                return "right";
            }
            
            return null;
        }

        public void ChangeXDirection () {
            this.xSpeed *= -1;
        }

        public void ChangeYDirection () {
            this.ySpeed *= -1;
        }

        public void Move () {
            if(this.WillEntityHitBarrier(this.topBarrier, this.bottomBarrier, this.leftBarrier, this.rightBarrier)){
                string determinedBarrier = WhichBarrierWillEntityHit(this.topBarrier, this.bottomBarrier, this.leftBarrier, this.rightBarrier);
                
                switch (determinedBarrier)
                {
                    case "top":
                        ChangeYDirection();
                        break;

                    case "bottom":
                        ChangeYDirection();
                        break;
                    
                    case "left":
                        ChangeXDirection();
                        break;
                    
                    case "right":
                        ChangeXDirection();
                        break;

                    case "corner":
                        ChangeXDirection();
                        ChangeYDirection();
                        break;
                }
                
            }

            this.yPos += this.ySpeed;
            this.xPos += this.xSpeed;
        }

        public override void Draw () {
            ConsoleColor initialColor = Console.BackgroundColor;
            Console.BackgroundColor = color;

            Console.SetCursorPosition (this.xPos - 1, this.yPos);
            Console.Write (" ");
            Console.SetCursorPosition (this.xPos, this.yPos);
            Console.Write (" ");

            Console.BackgroundColor = initialColor;
            Console.SetCursorPosition (0, 0);
        }

        public override void CleanDraw () {
            Console.SetCursorPosition (this.xPos - 1, this.yPos);
            Console.Write (" ");
            Console.SetCursorPosition (this.xPos, this.yPos);
            Console.Write (" ");
        }
    }
}