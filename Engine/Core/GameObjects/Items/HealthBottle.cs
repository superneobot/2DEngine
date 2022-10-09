using System;
using System.Drawing;

namespace Engine.GameObjects.Items
{
    [Serializable]
    public class HealthBottle : GameObject
    {
        public int GivenHealth { get; set; }
        public Image Sprite { get; set; }
        public HealthBottle()
        {
            Sprite = new Bitmap("Data/Textures/health.png");
        }

        public void Draw(Graphics graphics)
        {
            Bounds = new Rectangle(Location.X, Location.Y, Width, Height);
            if (Sprite == null)
            {
                graphics.DrawString("Health", new Font("Motiva Sans", 8.0F), Brushes.Red, Location.X - 2, Location.Y - 16);
                graphics.FillRectangle(new SolidBrush(Color.Red), Bounds);
            }
            else
            {
                graphics.DrawImage(Sprite, Bounds);
            }
        }
    }
}
