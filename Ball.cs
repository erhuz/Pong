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

            this.xSpeed = speed * 2;
            this.ySpeed = speed;
        }

        private bool WillBallHitAPlayer (Player player1, Player player2){
            for (int i = player1.yPos; i < player1.yPos + player1.size; i++)
            {
                if(this.yPos == i && this.xPos <= player1.xPos + 2){
                    return true;
                }
            }

            for (int i = player2.yPos; i < player2.yPos + player2.size; i++)
            {
                if(this.yPos == i && this.xPos >= player2.xPos - 1){
                    return true;
                }
            }
            
            return false;
        }

        public bool WillEntityHitBarrier (int top, int bottom, int left, int right, int xSpeed = 2, int ySpeed = 1) {

            if (
                this.yPos - ySpeed <= top ||
                this.yPos + ySpeed >= bottom ||
                this.xPos - xSpeed - 1 <= left ||
                this.xPos + xSpeed >= right
            ){
                return true;
            }

            return false;
        }

        public string WhichBarrierWillEntityHit (int top, int bottom, int left, int right, int xSpeed = 2, int ySpeed = 1) {
            if(
                (this.yPos - ySpeed <= top && this.xPos - xSpeed - 1 <= left) || // top left
                (this.yPos - ySpeed <= top && this.xPos + xSpeed >= right) || // top right
                (this.yPos + ySpeed >= bottom && this.xPos - xSpeed - 1 <= left) || // bottom left
                (this.yPos + ySpeed >= bottom && this.xPos + xSpeed >= right) // bottom right
            ){
                return "corner";
            }

            if (this.yPos + ySpeed >= bottom) {
                return "bottom";
            }
            
            if (this.yPos - ySpeed <= top) 
            {
                return "top";
            }
            
            if (this.xPos - xSpeed - 1 <= left) 
            {
                return "left";
            }
            
            if (this.xPos + xSpeed >= right) 
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

        public void Move (Player player1, Player player2) {
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
                        System.Environment.Exit(1);
                        // ChangeXDirection();
                        break;
                    
                    case "right":
                        System.Environment.Exit(1);
                        // ChangeXDirection();
                        break;

                    case "corner":
                        ChangeXDirection();
                        ChangeYDirection();
                        break;
                }
                
            }

            if(WillBallHitAPlayer(player1, player2)){
                ChangeXDirection();
            }

            // this.yPos += this.ySpeed;
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