using System.Drawing;
using System.Windows.Forms;

namespace MapEditor
{
    public class TileEngine
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle Bounds { get; set; }
        public Rectangle[,] Field { get; set; }
        public Image[,] Tiles { get; set; }
        public int FieldSize { get; set; }
        public Image Background;
        private Graphics graphics;
        private Control Control;

        public TileEngine(Control control)
        {
            Control = control;
        }

        public void Draw()
        {
            graphics = Graphics.FromImage(Control.BackgroundImage);
            Field = new Rectangle[Width / FieldSize, Height / FieldSize];
            Tiles = new Image[Width / FieldSize, Height / FieldSize];

            for (int x = 0; x < Width / FieldSize; x++)
            {
                for (int y = 0; y < Height / FieldSize; y++)
                {
                    Field[x, y] = new Rectangle(x * FieldSize, y * FieldSize, FieldSize, FieldSize);
                    //graphics.DrawRectangle(new Pen(Color.FromArgb(20, 20, 20)), Field[x, y]);

                }
            }
        }

    }
}
