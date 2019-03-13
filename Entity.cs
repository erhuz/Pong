using System;

namespace Pong
{
    public abstract class Entity
    {
        protected int xPos;
        protected int yPos;
        protected ConsoleColor color;


        protected bool DidEntityHitBarrier(int top, int bottom, int left, int right){
            if(
                this.yPos <= top ||
                this.yPos >= bottom ||
                this.xPos <= left ||
                this.xPos >= right
            ){
                return true;
            }

            return false;
        }

        protected bool WillEntityHitBarrier(int top, int bottom, int left, int right){
            
            if(
                this.yPos - 1 <= top ||
                this.yPos + 1 >= bottom ||
                this.xPos + 1 <= left ||
                this.xPos - 1 >= right
            ){
                return true;
            }
            
            return false;
        }
    }
}