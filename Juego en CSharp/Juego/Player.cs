using System;

namespace Juego
{
    class Player : Character
    {    
        private short points;
        private short lives;
        
        private const short initialLives = 5;

        private bool canAttack;

        private bool showAttackMeassege;

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

        public bool CanAttack
        {
            set
            {
                canAttack = value;
            }
            get
            {
                return canAttack;
            }
        }

        public bool ShowAttackMeassege 
        {
            set 
            {
                showAttackMeassege = value;
            }
            get 
            {
                return showAttackMeassege;
            }
        }

        public Player(short x, short y) : base(x, y) 
        {
            Points = 0;
            Lives = initialLives;
            CanAttack = false;
        }

        public void Input(ConsoleKey moveLeftKey, ConsoleKey moveRightKey, ConsoleKey moveDownKey, ConsoleKey moveUpKey, ref ConsoleKeyInfo cki) 
        {
            if (cki.Key == moveLeftKey && position.X - 1 > Game.worldMinX)
            {                
                position.X--;
            }

            if (cki.Key == moveRightKey && position.X + 1 < Game.worldMaxX)
            {
                position.X++;
            }

            if (cki.Key == moveDownKey && position.Y + 1 < Game.worldMaxY) 
            {
                position.Y++;
            }

            if (cki.Key == moveUpKey && position.Y > Game.worldMinY) 
            {
                position.Y--;
            }
        }

        public void AddPoint()
        {
            Points++;
        }
    }    
}
