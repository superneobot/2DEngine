using System.Drawing;
using System.Windows.Forms;

namespace Engine.Core.PlayerEngine
{
    public class Player : Body
    {
        public Direction Direction { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float Speed { get; set; }
        public PointF Target;
        public float RotateSpeed = 0.1f;
        public Image Image { get; set; }
        private Graphics graphics;
        private Control Control;
        public int Health { get; set; }
        public int Mana { get; set; }
        public Player(Control control)
        {
            Control = control;
            graphics = Graphics.FromImage(control.BackgroundImage);
            Health = 100;
            Mana = 100;
        }

        public void Draw()
        {
            Bounds = new RectangleF(Position.X, Position.Y, Width, Height);
            if (Image != null)
            {
                graphics.DrawRectangle(Pens.AliceBlue, Bounds.Location.X, Bounds.Location.Y, Width, Height);
                graphics.DrawImage(Image, Bounds);
            }
            else
            {
                graphics.FillRectangle(Brushes.Red, Bounds);
            }
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }
    }
}
