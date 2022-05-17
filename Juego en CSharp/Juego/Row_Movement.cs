namespace Juego
{
    class Row_Movement : Movement
    {
        private const short maxMovementDirections = 2;

        private bool direction;

        public Row_Movement() 
        {
            switch(Game.GenerateRandom.Next(1, maxMovementDirections + 1)) 
            {
                case 1:

                    direction = true;
                    break;
                case 2:

                    direction = false;
                    break;

                default:

                    direction = true;
                    break;
            }                        
        }

        public override void Move(ref struct_position_data position) 
        {
            switch (direction)
            {
                case true:

                    if (position.X + 1 < Game.worldMaxX)
                    {
                        position.X++;
                    }
                    else
                    {
                        direction = !direction;
                    }

                    break;
                case false:

                    if (position.X - 1 > Game.worldMinX)
                    {
                        position.X--;
                    }
                    else
                    {
                        direction = !direction;
                    }

                    break;
            }
        }
    }
}
