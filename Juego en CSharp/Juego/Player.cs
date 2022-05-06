using System;

namespace Juego
{
    class Player : Character
    {    
        private short points;
        private short lives;

        private const short pointsGained = 5;
        private const short initialLives = 5;

        public short Points 
        {
            set 
            {
                points = value;
            }
            get 
            {
                return points;
            }
        }

        public short Lives
        {
            set
            {
                lives = value;
            }
            get
            {
                return lives;
            }
        }

        public Player(short x, short y) : base(x, y) 
        {
            Points = 0;
            Lives = initialLives;
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
