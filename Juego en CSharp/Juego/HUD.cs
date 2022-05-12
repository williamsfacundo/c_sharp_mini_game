using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class HUD
    {
        public static void ShowPlayerScore(short xPos, short yPos, string meassege, Player player, ConsoleColor textColor)
        {
            Console.SetCursorPosition(xPos, yPos);
            
            Console.Write(meassege);

            Console.ForegroundColor = textColor;
            Console.Write(player.Points);

            Console.ForegroundColor = Game.BackgroundColor;
        }

        public static void ShowPlayerLives(short xPos, short yPos, Player player, string meassege, ConsoleColor textColor)
        {
            Console.SetCursorPosition(xPos, yPos);
                        
            Console.Write(meassege);

            Console.ForegroundColor = textColor;
            Console.Write(player.Lives);

            Console.ForegroundColor = Game.BackgroundColor;
        }

        public static void ShowPlayerStatus(short xPos, short yPos, Player player, ConsoleColor textColor)
        {
            Console.SetCursorPosition(xPos, yPos);

            Console.ForegroundColor = textColor;

            if (player.ShowAttackMeassege)
            {
                Console.Write("ATTACK");
            }
            else
            {
                Console.Write("VULNERABLE");
            }

            Console.ForegroundColor = Game.BackgroundColor;
        }
    }
}
