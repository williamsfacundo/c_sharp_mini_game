using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class HUD
    {
        public static void ShowPlayerScore(short xPos, short yPos, string meassege, Player player)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(meassege + player.Points);
        }

        public static void ShowPlayerLives(short xPos, short yPos, Player player, string meassege)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(meassege + player.Lives);
        }

        public static void ShowPlayerStatus(short xPos, short yPos, Player player)
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
    }
}
