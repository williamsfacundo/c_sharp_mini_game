using System;
using System.Threading;

namespace Juego
{
    class Game
    {
        private const short initialPlayerXPosition = 2;
        private const short initialPlayerYPosition = 2;
        private const short xMaxLimit = 30;
        private const short xMinLimit = 1;
        private const short yMaxLimit = 15;
        private const short yMinLimit = 1;
        private const short maxEnemies = 5;

        private const int enemiesMinXSpawnPosition = 5;
        private const int enemiesMaxXSpawnPosition = xMaxLimit - 1;
        private const int enemiesMinYSpawnPosition = 5;
        private const int enemiesMaxYSpawnPosition = yMaxLimit - 1;

        private const char playerChar = '☻';
        private const char enemiesChar = '☺';

        private static bool runGame;

        private static Player player;        

        private static Enemy[] enemies;// 

        private static ConsoleKeyInfo cki;       
                
        public static void GameLoop()
        {
            Init();

            Draw();
            
            while (runGame)
            {
                Input();
                Update();

                Console.Clear();

                Draw();

                Thread.Sleep(200);
            }
        }

        private static void Init()
        {
            player = new Player(initialPlayerXPosition, initialPlayerYPosition);
            SetEnemies();
            runGame = true;
        }

        private static void SetEnemies() 
        {
            enemies = new Enemy[maxEnemies];

            short xPos = (short)Program.generateRandom.Next(enemiesMinXSpawnPosition, enemiesMaxXSpawnPosition);
            short yPos = (short)Program.generateRandom.Next(enemiesMinYSpawnPosition, enemiesMaxYSpawnPosition);

            for (short i = 0; i < maxEnemies; i++)
            {
                xPos = (short)Program.generateRandom.Next(enemiesMinXSpawnPosition, enemiesMaxXSpawnPosition);
                yPos = (short)Program.generateRandom.Next(enemiesMinYSpawnPosition, enemiesMaxYSpawnPosition);

                enemies[i] = new Enemy(xPos, yPos);
            }
        }

        private static void Input()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false); // true = hide input
            }

            cki = Console.ReadKey();

            player.Input(xMinLimit, xMaxLimit, yMinLimit, yMaxLimit, ref cki);
            CloseApplicationInput();
        }

        private static void CloseApplicationInput() 
        {
            if (cki.Key == ConsoleKey.Escape) 
            {
                runGame = !runGame;
            }
        }

        private static void Update() 
        {
            for (short i = 0; i < maxEnemies; i++) 
            {
                enemies[i].Update(xMinLimit, xMaxLimit, yMinLimit, yMaxLimit);                
            }
        }

        private static void Draw()
        {
            player.Draw(playerChar);
            DrawEnemies();
        }

        private static void DrawEnemies() 
        {
            for (short i = 0; i < maxEnemies; i++) 
            {
                enemies[i].Draw(enemiesChar);
            }
        }
    }
}
