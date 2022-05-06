using System;

namespace Juego
{
    class Enemy : Character
    {        
        public Enemy(short x, short y) : base(x, y) 
        {
            
        }

        public void Update(short worldMinX, short worldMaxX, short worldMinY, short worldMaxY) 
        {
            MoveCharacter(worldMinX, worldMaxX, worldMinY, worldMaxY);
        }

        private void MoveCharacter(short worldMinX, short worldMaxX, short worldMinY, short worldMaxY) 
        {
            int random = Program.generateRandom.Next(1, 8);

            switch (random) 
            {
                case 1:

                    if (position.Y + 1 < worldMaxY) 
                    {
                        position.Y++;
                    }                    
                    break;
                case 2:

                    if (position.Y > worldMinY) 
                    {
                        position.Y--;
                    }
                    break;
                case 3:

                    if (position.X + 1 < worldMaxX)
                    {
                        position.X++;
                    }                    
                    break;
                case 4:

                    if (position.X - 1 > worldMinX)
                    {
                        position.X--;
                    }                    
                    break;
                default:
                                      
                    break;
            }
        }
    }
}
