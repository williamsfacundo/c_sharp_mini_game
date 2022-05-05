using System;

namespace Juego
{
    class Enemy : Character
    {        
        public Enemy(short x, short y) : base(x, y) 
        {
            
        }

        public void Update() 
        {
            MoveCharacter();
        }

        private void MoveCharacter() 
        {
            int random = Program.generateRandom.Next(1, 4);

            switch (random) 
            {
                case 1:
                    
                    position.Y++;
                    break;
                case 2:

                    position.Y--;
                    break;
                case 3:

                    position.X++;
                    break;
                case 4:

                    position.X--;
                    break;
                default:

                    position.X++;
                    break;
            }
        }
    }
}
