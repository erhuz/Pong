using System;

namespace Pong {
    public abstract class Entity {
        protected int xPos;
        protected int yPos;
        protected int speed;
        protected int size;
        protected ConsoleColor color;

        public bool WillEntityHitBarrier (int top, int bottom, int left, int right) {

            if (
                this.yPos - 1 <= top ||
                this.yPos + this.size >= bottom ||
                this.xPos + 1 <= left ||
                this.xPos - 1 >= right
            ) {
                return true;
            }

            return false;
        }
    }
}