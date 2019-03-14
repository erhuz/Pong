using System;

namespace Pong {
    public abstract class Entity {
        protected int xPos;
        protected int yPos;
        protected int speed;
        protected int size;
        protected ConsoleColor color;

        public abstract void Draw();
        public abstract void CleanDraw();

        
    }
}