using System;
using System.Threading;

namespace Juego
{
    class Game
    {
        public const short worldMinX = 1;
        public const short worldMaxX = 30;
        public const short worldMinY = 3;
        public const short worldMaxY = 15;

        private const short initialPlayerOneXPosition = 2;
        private const short initialPlayerOneYPosition = 3;       
        
        private const short maxEnemies = 5;

        private const short playerOneScoreXPosition = 1;
        private const short playerOneScoreYPosition = 1;

        private const short playerTwoScoreXPosition = 1;
        private const short playerTwoScoreYPosition = 30;

        private const short playerOneLivesXPosition = 10;
        private const short playerOneLivesYPosition = 1;

        private const short playerTwoLivesXPosition = 10;
        private const short playerTwoLivesYPosition = 30;

        private const short showPlayerOneAttackMeassegeXPosition = 20;
        private const short showPlayerOneAttackMeassegeYPosition = 30;

        private const short showPlayerTwoAttackMeassegeXPosition = 20;
        private const short showPlayerTwoAttackMeassegeYPosition = 30;

        private static short enemyCollisionIndex = 0;

        private const int characterMinXSpawnPosition = 5;
        private const int characterMaxXSpawnPosition = worldMaxX - 1;
        private const int characterMinYSpawnPosition = 5;
        private const int characterMaxYSpawnPosition = worldMaxY - 1;

        private const char playerChar = '☻';
        private const char enemiesChar = '☺';
        private const char powerUpChar = '♦';

        private static bool runGame;        

        private static Player[] players;

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

            SetEnemies();

            SetPlayers();

            powerUp = new PowerUp();

            RandomPowerUp();

            enemyCollisionIndex = 0;
        }

        private static void RandomPowerUp()
        {
            powerUp.position.X = (short)Program.generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition);
            powerUp.position.Y = (short)Program.generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition);            
        }

        private static void SetPlayers() 
        {
            players = new Player[2];

            for (short i = 0; i < players.Length; i++)
            {
                players[i] = new Player((short)(initialPlayerOneXPosition + (i * 2)), initialPlayerOneYPosition);
            }
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

            cki = Console.ReadKey(true);

            PlayerInput();

            CloseApplicationInput();
        }   

        private static void PlayerInput() 
        {
            players[0].Input(ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.DownArrow, ConsoleKey.UpArrow, ref cki);
            players[1].Input(ConsoleKey.A, ConsoleKey.D, ConsoleKey.S, ConsoleKey.W, ref cki);
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

            PlayerEnemieCollision(players[0]);
            PlayerEnemieCollision(players[1]);

            PlayerCollisionWithPowerUp(players[0]);
            PlayerCollisionWithPowerUp(players[1]);
        }

        private static void Draw()
        {
            ShowPlayersScore();
            ShowPlayerLives();
            ShowPlayersStatus();
            DrawEnemies();
            DrawPowerUp();
            DrawPlayers();
        }

        private static void DrawPlayers() 
        {
            players[0].Draw(playerChar);
            players[1].Draw(playerChar);
        }

        private static void DrawPowerUp() 
        {
            if (!players[0].CanAttack || !players[1].CanAttack)
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

        private static void ShowPlayersScore()
        {            
            Console.SetCursorPosition(playerOneScoreXPosition, playerOneScoreYPosition);
            Console.Write("Score 1-" + players[0].Points);

            Console.SetCursorPosition(playerTwoScoreXPosition, playerTwoScoreYPosition);
            Console.Write("Score 2-" + players[1].Points);
        }

        private static void ShowPlayerLives()
        {
            Console.SetCursorPosition(playerOneLivesXPosition, playerOneLivesYPosition);
            Console.Write("Lives 1-" + players[0].Lives);

            Console.SetCursorPosition(playerTwoLivesXPosition, playerTwoLivesYPosition);
            Console.Write("Lives 2-" + players[1].Lives);
        }

        private static void ShowPlayersStatus() 
        {
            Console.SetCursorPosition(showPlayerOneAttackMeassegeXPosition, showPlayerOneAttackMeassegeYPosition);

            if (players[0].ShowAttackMeassege) 
            {                
                Console.Write("ATTACK");
            }
            else 
            {
                Console.Write("VULNERABLE");
            }

            Console.SetCursorPosition(showPlayerTwoAttackMeassegeXPosition, showPlayerTwoAttackMeassegeYPosition);

            if (players[1].ShowAttackMeassege)
            {
                Console.Write("ATTACK");
            }
            else
            {
                Console.Write("VULNERABLE");
            }
        }

        private static bool IsPlayerCollidingWithEnemies(Player player, ref short index)
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

        private static void PlayerEnemieCollision(Player player)
        {
            if (IsPlayerCollidingWithEnemies(player, ref enemyCollisionIndex)) 
            {
                if (player.CanAttack) 
                {
                    enemies[enemyCollisionIndex].position.X = (short)Program.generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition);
                    enemies[enemyCollisionIndex].position.Y = (short)Program.generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition);

                    RandomPowerUp();

                    player.AddPoint();

                    player.CanAttack = false;
                    player.ShowAttackMeassege = false;
                }
                else 
                {
                    player.Lives -= 1;
                    player.position.X = (short)Program.generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition);
                    player.position.Y = (short)Program.generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition);
                }                
            }
        }

        private static void PlayerCollisionWithPowerUp(Player player) 
        {
            if (powerUp.PoweupPickedUp(player.position.X, player.position.Y) && !player.CanAttack)
            {
                player.ShowAttackMeassege = true;

                player.CanAttack = true;               
            }            
        }
    }
}
