using System.Drawing;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class TilesPointer : Form
    {
        public TilesPointer()
        {
            InitializeComponent();
            this.Width = 736;
            this.Height = 672;
        }

        private void screen_Paint(object sender, PaintEventArgs e)
        {
            screen.BackgroundImage = new Bitmap("Data/Textures/tile_set.png");
        }
    }
}
