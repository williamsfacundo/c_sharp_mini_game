using System;

namespace Juego
{
    class Player
    {
        struct_position_data position;
               
        public Player(short x, short y) 
        {
            position.X = x;
            position.Y = y;
        }

        public void Input(short worldMinX, short worldMaxX, short worldMinY, short worldMaxY, ref ConsoleKeyInfo cki) 
        {
            if (cki.Key == ConsoleKey.LeftArrow && position.X - 1 > worldMinX)
            {                
                position.X--;
            }

            if (cki.Key == ConsoleKey.RightArrow && position.X + 1 < worldMaxX)
            {
                position.X++;
            }

            if (cki.Key == ConsoleKey.DownArrow && position.Y + 1 < worldMaxY) 
            {
                position.Y++;
            }

            if (cki.Key == ConsoleKey.UpArrow && position.Y > worldMinY) 
            {
                position.Y--;
            }
        }

        public void Draw() 
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write("☻");
        }
    }
}
