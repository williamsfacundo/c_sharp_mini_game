using System;
using System.Threading;

namespace Juego
{
    class Game
    {
        private const short initialPlayerXPosition = 2;
        private const short initialPlayerYPosition = 2;
        private const short maxEnemies = 5;

        private const int enemiesMinXSpawnPosition = 5;
        private const int enemiesMaxXSpawnPosition = 49;
        private const int enemiesMinYSpawnPosition = 5;
        private const int enemiesMaxYSpawnPosition = 49;

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
                cki = Console.ReadKey();

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

        private static void Update() 
        {
            for (short i = 0; i < maxEnemies; i++) 
            {
                enemies[i].Update();                
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
