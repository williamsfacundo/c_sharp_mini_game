using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Heart : Character
    {
        public Heart(short x, short y) : base(x, y) 
        {

        }

        public bool PickedUp(Player player) 
        { 
            return this.position == player.position && player.Lives + 1 <= player.MaxLives;
        }
    }
}
