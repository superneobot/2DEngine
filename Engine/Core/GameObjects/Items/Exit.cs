using System;
using System.Drawing;

namespace Engine.GameObjects.Items
{
    [Serializable]
    public class Exit : GameObject
    {
        public Exit()
        {

        }

        public void Draw(Graphics graphics)
        {
            Bounds = new Rectangle(Location.X, Location.Y, Width, Height);

            graphics.DrawRectangle(new Pen(Color.Red, 2), Bounds);
            graphics.DrawString("Exit", new Font("Motiva Sans", 8.0F), Brushes.Red, Location.X + 5, Location.Y + 10);
        }
    }
}
