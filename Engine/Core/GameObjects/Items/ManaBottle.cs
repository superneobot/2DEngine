using System;
using System.Drawing;

namespace Engine.GameObjects.Items
{
    [Serializable]
    public class ManaBottle : GameObject
    {
        public int GivenMana { get; set; }
        public Image Sprite { get; set; }
        public ManaBottle()
        {
            Sprite = new Bitmap("Data/Textures/mana.png");
        }

        public void Draw(Graphics graphics)
        {
            Bounds = new Rectangle(Location.X, Location.Y, Width, Height);
            if (Sprite == null)
            {
                graphics.DrawString("Mana", new Font("Motiva Sans", 8.0F), Brushes.Blue, Location.X - 2, Location.Y - 16);
                graphics.FillRectangle(new SolidBrush(Color.Blue), Bounds);
            }
            else
            {
                graphics.DrawImage(Sprite, Bounds);
            }
        }
    }
}
