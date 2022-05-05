using System;
using System.Threading;

namespace Juego
{
    class Game
    {
        const short initialPlayerXPosition = 2;
        const short initialPlayerYPosition = 2;

        private static bool runGame;

        private static Player player;        

        private static ConsoleKeyInfo cki;       
                
        public static void GameLoop()
        {
            Init();

            Draw();
            
            while (runGame)
            {
                cki = Console.ReadKey();

                Input();

                Console.Clear();

                Draw();

                Thread.Sleep(200);
            }
        }

        private static void Init()
        {
            player = new Player(initialPlayerXPosition, initialPlayerYPosition);
            runGame = true;
        }

        private static void Input()
        {
            player.Input(1, 50, 1, 50, ref cki);
            CloseApplicationInput();
        }

        private static void CloseApplicationInput() 
        {
            if (cki.Key == ConsoleKey.Escape) 
            {
                runGame = !runGame;
            }
        }

        private static void Draw()
        {
            player.Draw('☻');
        }
    }
}
