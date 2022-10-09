using Engine;
using Engine.Core.PlayerEngine;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class RenderForm : Form
    {
        public Engine2D.Engine Engine;
        private Rectangle select;
        private Graphics graphics;

        public Point pos { get; private set; }

        public RenderForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            Application.Idle += delegate { screen.Invalidate(); };
            //
            this.Width = 1300;
            this.Height = 1064;
            screen.BackgroundImage = new Bitmap(Width, Height);
            graphics = Graphics.FromImage(screen.BackgroundImage);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Engine = new Engine2D.Engine(screen)
            {
                World = new World(screen)
                {
                    Width = 1280,
                    Height = 1024,
                    FieldSize = 32,
                    TileSize = 32
                },
                Player = new Player(screen)
                {
                    Width = 32,
                    Height = 32,
                    Position = new System.Drawing.PointF(64.0F, 512.0F),
                    Speed = 5f,
                    Image = new Bitmap("Data/Textures/Player/Down/frame_1.gif")
                }
            };


        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                Engine.MoveRight();
            }
            if (e.KeyCode == Keys.A)
            {
                Engine.MoveLeft();
            }
            if (e.KeyCode == Keys.W)
            {
                Engine.MoveUp();
            }
            if (e.KeyCode == Keys.S)
            {
                Engine.MoveDown();
            }
            if (e.KeyCode == Keys.Space)
            {
                Engine.Fire();
            }

            if (e.KeyCode == Keys.D1)
            {

            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
                Engine.Stop();
            if (e.KeyCode == Keys.A)
                Engine.Stop();
            if (e.KeyCode == Keys.W)
                Engine.Stop();
            if (e.KeyCode == Keys.S)
                Engine.Stop();
            base.OnKeyUp(e);
        }

        private void screen_Paint(object sender, PaintEventArgs e)
        {
            Engine.Update();

            Engine.Render(e.Graphics);
            if (Engine.World.isLoaded)
            {
                Engine.Player.Position = Engine.World.PlayerStart.Location;
            }
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            Text = $"{Engine.Info()}";

        }

        private void screen_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X / Engine.World.FieldSize;
            int y = e.Y / Engine.World.FieldSize;

            select = Engine.World.Field[x, y];
        }



        private void RenderForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
