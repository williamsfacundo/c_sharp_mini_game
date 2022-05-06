using System;
using System.Threading;

namespace Juego
{
    class Game
    {
        private const short initialPlayerXPosition = 2;
        private const short initialPlayerYPosition = 3;
        private const short xMaxLimit = 30;
        private const short xMinLimit = 1;
        private const short yMaxLimit = 15;
        private const short yMinLimit = 3;
        private const short maxEnemies = 5;
        private const short scoreXPosition = 1;
        private const short scoreYPosition = 1;
        private const short playerLivesXPosition = 10;
        private const short playerLivesYPosition = 1;
        
        private static short enemyCollisionIndex = 0;

        private const int characterMinXSpawnPosition = 5;
        private const int characterMaxXSpawnPosition = xMaxLimit - 1;
        private const int characterMinYSpawnPosition = 5;
        private const int characterMaxYSpawnPosition = yMaxLimit - 1;

        private const char playerChar = '☻';
        private const char enemiesChar = '☺';
        private const char powerUpChar = '♦';

        private static bool runGame;

        private static Player player;
        
        private static Enemy[] enemies;

        private static PoweUp powerUp; 

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
            runGame = true;
            player = new Player(initialPlayerXPosition, initialPlayerYPosition);
            SetEnemies();
            powerUp = new PoweUp((short)Program.generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition),
                (short)Program.generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition));
            enemyCollisionIndex = 0;
        }

        private static void SetEnemies()
        {
            enemies = new Enemy[maxEnemies];

            short xPos = (short)Program.generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition);
            short yPos = (short)Program.generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition);

            for (short i = 0; i < maxEnemies; i++)
            {
                xPos = (short)Program.generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition);
                yPos = (short)Program.generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition);

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

            PlayerEnemieCollision();

            if (powerUp.PoweupPickedUp(player.position.X, player.position.Y)) 
            {
                //
            }
        }

        private static void Draw()
        {
            ShowPlayerScore(scoreXPosition, scoreYPosition);
            ShowPlayerLives(playerLivesXPosition, playerLivesYPosition);
            player.Draw(playerChar);
            DrawEnemies();
            powerUp.Draw(powerUpChar);
        }

        private static void DrawEnemies()
        {
            for (short i = 0; i < maxEnemies; i++)
            {
                enemies[i].Draw(enemiesChar);
            }
        }

        private static void ShowPlayerScore(short xPos, short yPos)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("Score-" + player.Points);
        }

        private static void ShowPlayerLives(short xPos, short yPos)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("Lives-" + player.Lives);
        }

        private static bool IsPlayerCollidingWithEnemies(ref short index)
        {
            for (short i = 0; i < maxEnemies; i++)
            {
                if (enemies[i].position.X == player.position.X & enemies[i].position.Y == player.position.Y)
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }

        private static void PlayerEnemieCollision()
        {
            if (IsPlayerCollidingWithEnemies(ref enemyCollisionIndex)) 
            {
                if (player.CanAttack) 
                {
                    enemies[enemyCollisionIndex].position.X = (short)Program.generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition);
                    enemies[enemyCollisionIndex].position.Y = (short)Program.generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition);
                }
                else 
                {
                    player.Lives -= 1;
                    player.position.X = (short)Program.generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition);
                    player.position.Y = (short)Program.generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition);
                }                
            }
        }
    }
}
