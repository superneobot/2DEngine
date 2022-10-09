using System;
using System.Drawing;

namespace Engine.GameObjects.Items
{
    [Serializable]
    public class PlayerStart : GameObject
    {
        public PlayerStart()
        {

        }

        public void Draw(Graphics graphics)
        {
            Bounds = new Rectangle(Location.X, Location.Y, Width, Height);

            graphics.DrawRectangle(new Pen(Color.Green, 2), Bounds);
            graphics.DrawString("Start", new Font("Motiva Sans", 8.0F), Brushes.Green, Location.X + 5, Location.Y + 10);
        }
    }
}
