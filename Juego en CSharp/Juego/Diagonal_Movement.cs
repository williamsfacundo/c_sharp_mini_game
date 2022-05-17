namespace Juego
{
    class Diagonal_Movement : Movement
    {
        private const short maxMovementDirections = 4;

        public override void Move(ref struct_position_data position) 
        {
            switch (Game.GenerateRandom.Next(1, maxMovementDirections))
            {
                case 1:

                    if (position.Y + 1 < Game.worldMaxY && position.X + 1 < Game.worldMaxX)
                    {
                        position.Y++;
                        position.X++;
                    }

                    break;
                case 2:

                    if (position.Y + 1 < Game.worldMaxY && position.X - 1 > Game.worldMinX)
                    {
                        position.Y++;
                        position.X--;
                    }

                    break;
                case 3:

                    if (position.Y - 1 > Game.worldMinY && position.X + 1 < Game.worldMaxX)
                    {
                        position.Y--;
                        position.X++;
                    }

                    break;
                case 4:

                    if (position.Y - 1 > Game.worldMinY && position.X - 1 > Game.worldMinX)
                    {
                        position.Y--;
                        position.X--;
                    }

                    break;
                default:

                    if (position.Y + 1 < Game.worldMaxY && position.X + 1 < Game.worldMaxX)
                    {
                        position.Y++;
                        position.X++;
                    }

                    break;
            }
        }
    }
}
