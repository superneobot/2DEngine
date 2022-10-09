using System;
using System.Drawing;

namespace Engine.GameObjects.Enemies
{
    [Serializable]
    public class Enemy : GameObjects.Items.GameObject
    {
        public int Health { get; set; }
        public int GivenExp { get; set; }
        public Image Sprite { get; set; }
        public Enemy()
        {
            Sprite = new Bitmap("Data/Textures/enemy.gif");
        }

        public void Draw(Graphics graphics)
        {
            Bounds = new Rectangle(Location.X, Location.Y, Width, Height);
            if (Sprite == null)
            {
                graphics.DrawString("Enemy", new Font("Motiva Sans", 8.0F), Brushes.Gold, Location.X - 2, Location.Y - 16);
                graphics.FillRectangle(new SolidBrush(Color.Gold), Bounds);
            }
            else
            {
                graphics.DrawImage(Sprite, Bounds);
            }
        }
    }
}
