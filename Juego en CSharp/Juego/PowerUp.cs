namespace Juego
{
    class PowerUp : Character
    {
        public PowerUp() : base(0, 0) 
        {

        }

        public PowerUp(short x, short y) : base(x, y)
        {

        }

        public bool PoweupPickedUp(short xPos, short yPos)
        {
            return position.X == xPos && position.Y == yPos;
        }        
    }
}
