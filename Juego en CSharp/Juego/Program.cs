using System;

namespace Juego
{
    class Program
    {
        public static Random generateRandom;

        static void Main(string[] args)
        {
            generateRandom = new Random();

            Console.CursorVisible = false;

            Game.GameLoop();
        }        
    }
}
