namespace Juego
{
    class Normal_Movement : Movement
    {
        private const short maxMovementDirections = 4;

        public override void Move(ref struct_position_data position) 
        {
            switch (Game.GenerateRandom.Next(1, maxMovementDirections + 1))
            {
                case 1:

                    if (position.Y + 1 < Game.worldMaxY)
                    {
                        position.Y++;
                    }

                    break;
                case 2:

                    if (position.Y - 1 > Game.worldMinY)
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

                    if (position.Y + 1 < Game.worldMaxY)
                    {
                        position.Y++;
                    }
                    break;
            }
        }
    }
}
