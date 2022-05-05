using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Character
    {
        private static struct_position_data position;

        public struct_position_data Position 
        {
            set 
            {
                position = value;
            }
            get 
            {
                return position;
            }
        }

        public Character(short x, short y) 
        {
            position.X = x;
            position.Y = y;
        }

        public static void Draw(char characterDrawChar) 
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(characterDrawChar);
        } //☻
    }
}
