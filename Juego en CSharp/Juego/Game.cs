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
        private const short showAttackMeassegeXPosition = 20;
        private const short showAttackMeassegeYPosition = 1;

        private static short enemyCollisionIndex = 0;

        private const int characterMinXSpawnPosition = 5;
        private const int characterMaxXSpawnPosition = xMaxLimit - 1;
        private const int characterMinYSpawnPosition = 5;
        private const int characterMaxYSpawnPosition = yMaxLimit - 1;

        private const char playerChar = '☻';
        private const char enemiesChar = '☺';
        private const char powerUpChar = '♦';

        private static bool runGame;
        private static bool showAttackMeassege;

        private static Player player;

        private static Enemy[] enemies;

        private static PowerUp powerUp;

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
            powerUp = new PowerUp();
            RandomPowerUp();
            enemyCollisionIndex = 0;
        }

        private static void RandomPowerUp()
        {
            powerUp.position.X = (short)Program.generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition);
            powerUp.position.Y = (short)Program.generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition);            
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

            PlayerCollisionWithPowerUp();
        }

        private static void Draw()
        {
            ShowPlayerScore();
            ShowPlayerLives();
            ShowPlayerStatus();
            DrawEnemies();
            DrawPowerUp();
            player.Draw(playerChar);                        
        }

        private static void DrawPowerUp() 
        {
            if (!player.CanAttack)
            {
                powerUp.Draw(powerUpChar);
            }
        }

        private static void DrawEnemies()
        {
            for (short i = 0; i < maxEnemies; i++)
            {
                enemies[i].Draw(enemiesChar);
            }
        }

        private static void ShowPlayerScore()
        {            
            Console.SetCursorPosition(scoreXPosition, scoreYPosition);
            Console.Write("Score-" + player.Points);
        }

        private static void ShowPlayerLives()
        {
            Console.SetCursorPosition(playerLivesXPosition, playerLivesYPosition);
            Console.Write("Lives-" + player.Lives);
        }

        private static void ShowPlayerStatus() 
        {
            Console.SetCursorPosition(showAttackMeassegeXPosition, showAttackMeassegeYPosition);

            if (showAttackMeassege) 
            {                
                Console.Write("ATTACK");
            }
            else 
            {
                Console.Write("VULNERABLE");
            }
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

                    RandomPowerUp();

                    player.AddPoint();

                    player.CanAttack = false;
                    showAttackMeassege = false;
                }
                else 
                {
                    player.Lives -= 1;
                    player.position.X = (short)Program.generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition);
                    player.position.Y = (short)Program.generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition);
                }                
            }
        }

        private static void PlayerCollisionWithPowerUp() 
        {
            if (powerUp.PoweupPickedUp(player.position.X, player.position.Y) && !player.CanAttack)
            {
                showAttackMeassege = true;

                player.CanAttack = true;               
            }            
        }
    }
}
