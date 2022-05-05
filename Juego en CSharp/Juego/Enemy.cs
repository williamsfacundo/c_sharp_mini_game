using System;

namespace Juego
{
    class Enemy : Character
    {
        private static Random generateRandom;
        
        public Enemy(short x, short y) : base(x, y) 
        {
            generateRandom = new Random();
        }

        public static void Update() 
        {
            MoveCharacter();
        }

        private static void MoveCharacter() 
        {
            int random = generateRandom.Next(1, 4);

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
