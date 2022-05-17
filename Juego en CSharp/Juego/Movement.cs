using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    abstract class Movement
    {
        public abstract void Move(ref struct_position_data position);
    }
}
