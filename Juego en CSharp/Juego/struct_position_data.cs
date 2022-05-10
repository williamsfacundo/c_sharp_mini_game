namespace Juego
{
    public struct struct_position_data
    {
        private short _x;
        private short _y;

        public struct_position_data(short x, short y) 
        {
            this._x = x;
            this._y = y;
        }
        
        public short X
        {
            set
            {
                _x = value;
            }

            get
            {
                return _x;
            }
        }

        public short Y
        {
            set
            {
                _y = value;
            }

            get
            {
                return _y;
            }
        }

        public static bool operator ==(struct_position_data left, struct_position_data right) 
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(struct_position_data left, struct_position_data right)
        {
            return left.X != right.X && left.Y != right.Y;
        }
    }
}
