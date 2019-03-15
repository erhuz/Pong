using System;

namespace Pong {
    public class Player : Entity {
        private readonly string name;
        private int score = 0;
        protected int topBarrier;
        protected int bottomBarrier;

        public Player (
            string name,
            int xPos,
            int yPos,
            int topBarrier,
            int bottomBarrier,
            int size = 3,
            ConsoleColor color = ConsoleColor.Blue
        ) {

            this.name = name;
            this.xPos = xPos;
            this.yPos = yPos - (size / 2); // Center player position vertically
            this.topBarrier = topBarrier;
            this.bottomBarrier = bottomBarrier;
            this.size = size;
            this.color = color;
        }
        public bool Move(int direction){
            if(WillEntityHitBarrier(topBarrier, bottomBarrier)){
                string determinedBarrier = WhichBarrierWillEntityHit(topBarrier, bottomBarrier);

                if(
                    (direction == -1 && determinedBarrier == "top") ||
                    (direction == 1 && determinedBarrier == "bottom")
                ){
                    return false;
                }
            }

            this.yPos += direction * this.speed;

            return true;
        }

        public bool WillEntityHitBarrier (int top, int bottom) {

            if (
                this.yPos - 1 <= top ||
                this.yPos + this.size >= bottom
            ) {
                return true;
            }

            return false;
        }
        
        public string WhichBarrierWillEntityHit (int top, int bottom, int speed = 1) {
            if (this.yPos - speed <= top) {
                return "top";
            }
            else if (this.yPos + this.size >= bottom) 
            {
                return "bottom";
            }
            else 
            {
                return null;
            }
        }

        public override void Draw () {
            ConsoleColor initialColor = Console.BackgroundColor;
            Console.BackgroundColor = color;

            for (int i = 0; i < this.size; i++) {
                Console.SetCursorPosition (this.xPos, this.yPos + i);
                Console.Write (" ");
            }

            Console.BackgroundColor = initialColor;
            Console.SetCursorPosition (0, 0);
        }

        public override void CleanDraw () {
            Console.SetCursorPosition (this.xPos, this.yPos);
            Console.Write (" ");
            Console.SetCursorPosition (this.xPos, this.yPos + this.size - 1);
            Console.Write (" ");
        }
    }
}