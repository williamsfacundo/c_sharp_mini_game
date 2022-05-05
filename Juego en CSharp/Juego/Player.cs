using System;

namespace Juego
{
    class Player : Character
    {              
        public Player(short x, short y) : base(x, y) 
        {
            
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
    }
}
