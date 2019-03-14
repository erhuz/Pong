using System;

namespace Pong {
    public abstract class Entity {
        public int xPos { get; protected set; }
        public int yPos { get; protected set; }
        public int size { get; protected set; }
        protected int speed;
        protected ConsoleColor color;

        public abstract void Draw();
        public abstract void CleanDraw();

        
    }
}