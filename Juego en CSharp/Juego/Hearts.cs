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

        public void PickedUp(Player player) 
        {
            if (this.position == player.position) 
            {
                if (player.Lives + 1 <= player.MaxLives) 
                {
                    player.Lives += 1;
                }                
            }
        }
    }
}
