using System;

namespace Pong
{
    public abstract class Entity
    {
        private int xPos { get; }
        private int yPos { get; }
        private int size { get; }
        private ConsoleColor color;
    }
}