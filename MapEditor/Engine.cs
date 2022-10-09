using Engine.GameObjects.Enemies;
using Engine.GameObjects.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditor
{
    [Serializable]
    public class World
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

        public List<HealthBottle> HealthBottles { get; set; }
        public List<ManaBottle> ManaBottles { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Block> Blocks { get; set; }
        public List<Exit> Exits { get; set; }
        public PlayerStart PlayerStart { get; set; }

        public World(Control control)
        {
            Control = control;
            Background = new Bitmap("Data/Textures/grass.gif");
        }
        public void Draw()
        {
            graphics = Graphics.FromImage(Control.BackgroundImage);
            //graphics.Clear(Color.Black);
            Bounds = new Rectangle(0, 0, Width, Height);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //
            Tiles = new Image[Width / FieldSize, Height / FieldSize];
            Field = new Rectangle[Width / FieldSize, Height / FieldSize];
            HealthBottles = new List<HealthBottle>();
            ManaBottles = new List<ManaBottle>();
            Enemies = new List<Enemy>();
            Blocks = new List<Block>();
            Exits = new List<Exit>();
            PlayerStart = new PlayerStart();
            //
            for (int x = 0; x < Width / FieldSize; x++)
            {
                for (int y = 0; y < Height / FieldSize; y++)
                {
                    Field[x, y] = new Rectangle(x * FieldSize, y * FieldSize, FieldSize, FieldSize);
                    //graphics.DrawImage(Background, Field[x, y]);
                    graphics.DrawRectangle(new Pen(Color.FromArgb(20, 20, 20)), Field[x, y]);

                }
            }
            graphics.DrawRectangle(new Pen(Color.FromArgb(10, 10, 10), 2), Bounds);
        }

        public void AddHealthBottle(HealthBottle item)
        {
            HealthBottles.Add(item);
        }

        public void AddManaBottle(ManaBottle item)
        {
            ManaBottles.Add(item);
        }

        public void AddEnemy(Enemy item)
        {
            Enemies.Add(item);
        }

        public void AddBlock(Block item)
        {
            Blocks.Add(item);
        }
        public void AddExit(Exit item)
        {
            Exits.Add(item);
        }

        public void AddStart(PlayerStart item)
        {
            PlayerStart = item;
        }

        public void Update()
        {
            for (int x = 0; x < Width / FieldSize; x++)
            {
                for (int y = 0; y < Height / FieldSize; y++)
                {
                    if (Tiles[x, y] != null)
                        graphics.DrawImage(Tiles[x, y], Field[x, y]);
                }
            }

            foreach (HealthBottle item in HealthBottles)
            {
                graphics.DrawImage(item.Sprite, item.Location.X, item.Location.Y, 32, 32);
            }

            foreach (ManaBottle item in ManaBottles)
            {
                graphics.DrawImage(item.Sprite, item.Location.X, item.Location.Y, 32, 32);
            }
            foreach (Enemy item in Enemies)
            {
                graphics.DrawImage(item.Sprite, item.Location.X, item.Location.Y, 32, 32);
            }
            foreach (Block item in Blocks)
            {
                graphics.DrawRectangle(new Pen(Color.Black, 4), item.Bounds);
                graphics.DrawLine(
                    new Pen(Color.Black),
                    new Point(item.Location.X, item.Location.Y),
                    new Point(item.Location.X + item.Width, item.Location.Y + item.Height)
                    );
                graphics.DrawLine(
                    new Pen(Color.Black),
                    new Point(item.Location.X, item.Location.Y + item.Height),
                    new Point(item.Location.X + item.Width, item.Location.Y)
                    );
            }
            foreach (Exit item in Exits)
            {
                graphics.DrawRectangle(new Pen(Color.Red, 4), item.Bounds);
                graphics.DrawString("Exit", new Font("Motiva Sans", 8.0F), Brushes.Red, item.Location.X + 5, item.Location.Y + 10);
            }
            graphics.DrawRectangle(new Pen(Color.Green, 2), PlayerStart.Bounds);
            graphics.DrawString("Start", new Font("Motiva Sans", 8.0F), Brushes.Green, PlayerStart.Location.X + 5, PlayerStart.Location.Y + 10);
        }

        public void UpdateTiles()
        {
            for (int x = 0; x < Width / FieldSize; x++)
            {
                for (int y = 0; y < Height / FieldSize; y++)
                {
                    if (Tiles[x, y] != null)
                        graphics.DrawImage(Tiles[x, y], Field[x, y]);
                }
            }
        }
        public void ReDraw(int m_x, int m_y, Image img)
        {
            try
            {
                Tiles[m_x, m_y] = img;
                for (int x = 0; x < Width / 32; x++)
                {
                    for (int y = 0; y < Height / 32; y++)
                    {
                        if (Tiles[x, y] != null)
                            graphics.DrawImage(Tiles[x, y], Field[x, y]);
                    }
                }
            }
            catch { }
        }

        public void Clear()
        {
            var empty = new Bitmap("Data/Textures/empty.png");
            for (int x = 0; x < Width / FieldSize; x++)
            {
                for (int y = 0; y < Height / FieldSize; y++)
                {
                    Tiles[x, y] = empty;
                }
            }
            for (int x = 0; x < Width / FieldSize; x++)
            {
                for (int y = 0; y < Height / FieldSize; y++)
                {
                    if (Tiles[x, y] != null)
                        graphics.DrawImage(Tiles[x, y], Field[x, y]);
                }
            }
        }
    }
}
