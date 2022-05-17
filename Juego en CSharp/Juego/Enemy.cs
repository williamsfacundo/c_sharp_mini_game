namespace Juego
{
    class Enemy : Character
    {
        private const short maxMovementPatterns = 3;        

        private Movement movePattern;

        public Movement MovePattern 
        {
            set 
            {
                movePattern = value;
            }
            get 
            {
                return movePattern;
            }
        }
     
        public Enemy(short x, short y) : base(x, y) 
        {
            MovePattern = GetRandomMovePatern();            
        }

        private Movement GetRandomMovePatern() 
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

        public Movement GetRandomMovePatern(Movement movePattern) 
        {
            Movement newDiffetentMovePattern;

            do
            {
                newDiffetentMovePattern = GetRandomMovePatern();                

            } while (newDiffetentMovePattern is Normal_Movement && movePattern is Normal_Movement ||
                    newDiffetentMovePattern is Diagonal_Movement && movePattern is Diagonal_Movement ||
                    newDiffetentMovePattern is Row_Movement && movePattern is Row_Movement);

            return newDiffetentMovePattern;
        }

        public void Update() 
        {
            MoveCharacter();
        }

        private void MoveCharacter() 
        {
            MovePattern.Move(ref position);           
        }       
    }
}
