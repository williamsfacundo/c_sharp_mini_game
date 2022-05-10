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
            int random = Game.GenerateRandom.Next(1, 8);

            switch (random) 
            {
                case 1:

                    if (position.Y + 1 < Game.worldMaxY) 
                    {
                        position.Y++;
                    }  
                    
                    break;
                case 2:

                    if (position.Y > Game.worldMinY) 
                    {
                        position.Y--;
                    }

                    break;
                case 3:

                    if (position.X + 1 < Game.worldMaxX)
                    {
                        position.X++;
                    } 
                    
                    break;
                case 4:

                    if (position.X - 1 > Game.worldMinX)
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
