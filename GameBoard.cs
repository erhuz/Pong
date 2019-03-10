using System;

namespace Pong {
    public class GameBoard {
        private readonly int width;
        private readonly int height;
        private readonly int xOffset;
        private readonly int yOffset;

        private ConsoleColor backgroundColor;
        private ConsoleColor outlineColor;

        public GameBoard (
            int width,
            int height,
            int xOffset = 2,
            int yOffset = 2,
            ConsoleColor backgroundColor = ConsoleColor.Black,
            ConsoleColor outlineColor = ConsoleColor.White
        ) {

            this.width = width;
            this.height = height;
            this.xOffset = xOffset;
            this.yOffset = yOffset;
            this.backgroundColor = backgroundColor;
            this.outlineColor = outlineColor;
        }

        public int GetBorderTop () {
            return yOffset;
        }

        public int GetBorderBottom () {
            return (yOffset + height - 1);
        }

        public int GetBorderLeft () {
            return xOffset;
        }

        public int GetBorderRight () {
            return (xOffset + width - 1);
        }

        public int GetCenterVertical(){
            return (this.GetBorderTop() + this.GetBorderBottom() / 2);
        }
        
        public int GetCenterHorizontal(){
            return (this.GetBorderLeft() + this.GetBorderRight() / 2);
        }

        public void Draw () {

            for (int y = 0; y < height + (this.yOffset * 2); y++) {
                for (int x = 0; x < (width + this.xOffset * 2); x++) {
                    Console.SetCursorPosition (x, y);
                    Console.BackgroundColor = backgroundColor;
                    Console.Write (" ");
                }
            }

            for (int y = this.yOffset; y < height + this.yOffset; y++) {
                Console.BackgroundColor = outlineColor;
                Console.SetCursorPosition (this.xOffset, y);
                Console.Write (" ");

                Console.SetCursorPosition (this.xOffset + width - 1, y);
                Console.Write (" ");
            }

            for (int x = this.xOffset; x < width + this.xOffset; x++) {
                Console.BackgroundColor = outlineColor;
                Console.SetCursorPosition (x, this.yOffset);
                Console.Write (" ");

                Console.SetCursorPosition (x, this.yOffset + height - 1);
                Console.Write (" ");
            }

            Console.BackgroundColor = backgroundColor;
            Console.SetCursorPosition (0, 0);
        }

    }
}