using System;
using System.Threading;

namespace Juego
{
    class Game
    {
        private static Random generateRandom;

        public static Random GenerateRandom 
        {
            set 
            {
                generateRandom = value;
            }
            get 
            {
                return generateRandom;
            }
        }

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

        private const short playerOneLivesXPosition = 13;
        private const short playerOneLivesYPosition = 1;

        private const short playerTwoLivesXPosition = 13;
        private const short playerTwoLivesYPosition = 30;

        private const short showPlayerOneAttackMeassegeXPosition = 25;
        private const short showPlayerOneAttackMeassegeYPosition = 1;

        private const short showPlayerTwoAttackMeassegeXPosition = 25;
        private const short showPlayerTwoAttackMeassegeYPosition = 30;

        private static short enemyCollisionIndexForP1 = 0;
        private static short enemyCollisionIndexForP2 = 0;

        private const int characterMinXSpawnPosition = 5;
        private const int characterMaxXSpawnPosition = worldMaxX - 1;

        private const int characterMinYSpawnPosition = 5;
        private const int characterMaxYSpawnPosition = worldMaxY - 1;

        private const char playerOneChar = '1';
        private const char playerTwoChar = '2';
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
            Console.CursorVisible = false;

            generateRandom = new Random();

            runGame = true;           

            SetEnemies();

            SetPlayers();

            powerUp = new PowerUp();

            RandomPowerUpPosition();

            enemyCollisionIndexForP1 = 0;
        }

        private static void RandomPowerUpPosition()
        {
            powerUp.position.X = (short)generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition);
            powerUp.position.Y = (short)generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition);            
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

            short xPos = (short)generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition);
            short yPos = (short)generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition);

            for (short i = 0; i < maxEnemies; i++)
            {
                xPos = (short)generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition);
                yPos = (short)generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition);

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

            PlayerEnemieCollision(players[0], ref enemyCollisionIndexForP1);
            PlayerEnemieCollision(players[1], ref enemyCollisionIndexForP2);

            PlayerPickUpPowerUp(players[0]);
            PlayerPickUpPowerUp(players[1]);
        }

        private static void Draw()
        {
            ShowPlayerScore(playerOneScoreXPosition, playerOneScoreYPosition, "Score p1-", players[0]);
            ShowPlayerScore(playerTwoScoreXPosition, playerTwoScoreYPosition, "Score p2-", players[1]);
            
            ShowPlayerLives(playerOneLivesXPosition, playerOneLivesYPosition, players[0], "Lives p1-");
            ShowPlayerLives(playerTwoLivesXPosition, playerTwoLivesYPosition, players[1], "Lives p2-");
            
            ShowPlayerStatus(showPlayerOneAttackMeassegeXPosition, showPlayerOneAttackMeassegeYPosition, players[0]);
            ShowPlayerStatus(showPlayerTwoAttackMeassegeXPosition, showPlayerTwoAttackMeassegeYPosition, players[1]);

            DrawEnemies();

            DrawPowerUp();

            DrawPlayer(players[0], playerOneChar);
            DrawPlayer(players[1], playerTwoChar);
        }

        private static void DrawPlayer(Player player, char playerChar) 
        {
            player.Draw(playerChar);            
        }

        private static void DrawPowerUp() 
        {
            if (!players[0].CanAttack && !players[1].CanAttack)
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

        private static void ShowPlayerScore(short xPos, short yPos, string meassege, Player player)
        {            
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(meassege + player.Points);            
        }

        private static void ShowPlayerLives(short xPos, short yPos, Player player, string meassege)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(meassege + player.Lives);
        }

        private static void ShowPlayerStatus(short xPos, short yPos, Player player) 
        {
            Console.SetCursorPosition(xPos, yPos);

            if (player.ShowAttackMeassege) 
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

        private static void PlayerEnemieCollision(Player player, ref short enemyCollisionIndex)
        {
            if (IsPlayerCollidingWithEnemies(player, ref enemyCollisionIndex)) 
            {
                if (player.CanAttack) 
                {
                    enemies[enemyCollisionIndexForP1].position.X = (short)generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition);
                    enemies[enemyCollisionIndexForP1].position.Y = (short)generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition);

                    RandomPowerUpPosition();

                    player.AddPoint();

                    player.CanAttack = false;
                    player.ShowAttackMeassege = false;
                }
                else 
                {
                    player.Lives -= 1;
                    player.position.X = (short)generateRandom.Next(characterMinXSpawnPosition, characterMaxXSpawnPosition);
                    player.position.Y = (short)generateRandom.Next(characterMinYSpawnPosition, characterMaxYSpawnPosition);
                }                
            }
        }

        private static void PlayerPickUpPowerUp(Player player) 
        {
            if (powerUp.PoweupPickedUp(player.position.X, player.position.Y) && !player.CanAttack)
            {
                player.ShowAttackMeassege = true;

                player.CanAttack = true;               
            }            
        }
    }
}
