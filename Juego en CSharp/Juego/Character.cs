using System;

namespace Juego
{
    class Character
    {
        public struct_position_data position;       

        public Character(short x, short y) 
        {
            position.X = x;
            position.Y = y;
        }

        public void Draw(char characterDrawChar) 
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(characterDrawChar);
        }       
    }
}
