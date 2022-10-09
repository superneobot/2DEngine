using System;
using System.Drawing;

namespace Engine.GameObjects.Items
{
    [Serializable]
    public class Block : GameObject
    {
        public Block()
        {

        }

        public void Draw(Graphics graphics)
        {
            Bounds = new Rectangle(Location.X, Location.Y, Width, Height);

            graphics.DrawRectangle(new Pen(Color.Black, 4), Bounds);
            graphics.DrawLine(
                   new Pen(Color.Black),
                   new Point(Bounds.Location.X, Bounds.Location.Y),
                   new Point(Bounds.Location.X + Bounds.Width, Bounds.Location.Y + Bounds.Height)
                   );
            graphics.DrawLine(
                new Pen(Color.Black),
                new Point(Bounds.Location.X, Bounds.Location.Y + Bounds.Height),
                new Point(Bounds.Location.X + Bounds.Width, Bounds.Location.Y)
                );
        }
    }
}
