namespace Juego
{
    class PoweUp : Character
    {
        public PoweUp(short x, short y) : base(x, y)
        {

        }

        public bool PoweupPickedUp(short xPos, short yPos)
        {
            return position.X == xPos && position.Y == yPos;
        }        
    }
}
