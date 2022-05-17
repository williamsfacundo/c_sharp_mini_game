namespace Juego
{
    class Enemy : Character
    {
        private const short maxMovementPatterns = 3;
        //private const short maxNormalMovementRandomValues = 8;

        //private int random;

        //private Enemies_type.Enum_Enemy_Types movementPattern;

        //private bool rowMovementDirection;

        Movement movePatern;
     
        public Enemy(short x, short y) : base(x, y) 
        {
            //movementPattern = GetRandomMovementPattern();
            movePatern = GetRandomMovePatern();
            //rowMovementDirection = GetRandomRowMovement();
        }

        Movement GetRandomMovePatern() 
        {
            switch (Game.GenerateRandom.Next(1, maxMovementPatterns)) 
            {
                case 1:

                    return new Normal_Movement();                    
                case 2:

                    return new Diagonal_Movement();
                case 3:

                    return new Row_Movement();
                default:

                    return new Normal_Movement();                    
            }            
        }

        public void Update() 
        {
            MoveCharacter();
        }

        private void MoveCharacter() 
        {
            movePatern.Move(ref position);            
            /*switch (movementPattern)
            {
                case Enemies_type.Enum_Enemy_Types.NORMAL_MOVEMENT:

                    NormalMovemnt();

                    break;
                case Enemies_type.Enum_Enemy_Types.DIAGONAL_MOVEMENT:

                    DiagonalMovement();
                    
                    break;
                case Enemies_type.Enum_Enemy_Types.ROW_MOVEMENT:

                    RowMovement();
                    
                    break;
            }*/
        }

        /*private void NormalMovemnt() 
        {
            random = Game.GenerateRandom.Next(1, maxNormalMovementRandomValues);

            switch (random)
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

                    break;
            }
        }*/

        /*private void DiagonalMovement() 
        {
            random = Game.GenerateRandom.Next(1, maxNormalMovementRandomValues);

            switch (random)
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

                    break;
            }
        }*/

        /*private void RowMovement() 
        {
            switch (rowMovementDirection)
            {
                case true:

                    if (position.X + 1 < Game.worldMaxX)
                    {
                        position.X++;
                    }
                    else
                    {
                        rowMovementDirection = !rowMovementDirection;
                    }

                    break;
                case false:

                    if (position.X - 1 > Game.worldMinX)
                    {
                        position.X--;
                    }
                    else
                    {
                        rowMovementDirection = !rowMovementDirection;
                    }

                    break;
            }
        }*/

        /*Enemies_type.Enum_Enemy_Types GetRandomMovementPattern() 
        {
            random = Game.GenerateRandom.Next(1, maxMovementPatterns);

            switch (random) 
            {
                case 1:
                    return Enemies_type.Enum_Enemy_Types.NORMAL_MOVEMENT;                    
                case 2:
                    return Enemies_type.Enum_Enemy_Types.DIAGONAL_MOVEMENT;                    
                case 3:
                    return Enemies_type.Enum_Enemy_Types.ROW_MOVEMENT;
                default:
                    return Enemies_type.Enum_Enemy_Types.NORMAL_MOVEMENT;
            }
        }*/

        /*bool GetRandomRowMovement() 
        {
            random = Game.GenerateRandom.Next(1, 2);

            return random % 2 == 0;
        }*/
    }
}
