namespace Juego
{
    public struct struct_position_data
    {
        private short x;
        private short y;


        public short X
        {
            set
            {
                x = value;
            }

            get
            {
                return x;
            }
        }

        public short Y
        {
            set
            {
                y = value;
            }

            get
            {
                return y;
            }
        }
    }
}
