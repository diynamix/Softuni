namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';

        public Wall(int leftX, int topY) : base(leftX, topY)
        {
            InitializeBoarders();
        }

        public bool IsPointOfWall(Point snakeElement) => snakeElement.LeftX == 0 || snakeElement.LeftX == LeftX - 1 || snakeElement.TopY == 0 || snakeElement.TopY == TopY;

        public void InitializeBoarders()
        //private void InitializeBoarders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(TopY);
            SetVerticalLine(0);
            SetVerticalLine(LeftX - 1);
        }

        // Drawing Horizontal Boarder of the Field
        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }

        // Drawing Vertical Boarder of the Field
        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }
    }
}
