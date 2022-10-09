using Engine.GameObjects.Enemies;
using Engine.GameObjects.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MapEditor
{
    public enum Types : int
    {
        Tile = 1,
        Object = 2
    }

    public enum ObjectsType : int
    {
        HealthBottle = 1,
        ManaBottle = 2,
        Enemy = 3,
        Block = 4,
        Exit = 5,
        PlayerStart = 6
    }
    public partial class EditorForm : Form
    {
        World Map;
        private Graphics graphics;
        private Graphics tile_graphics;
        TileEngine tileEngine;
        private Bitmap preview;
        private Rectangle selected_under_mouse_rect;
        private Bitmap temp;
        private Image selected_tile_rect;
        private Rectangle under_mouse_rect;
        private bool isPressed = false;
        private HealthBottle healthBottle;
        private Enemy enemy;
        Types type;
        ObjectsType objectsType;

        private ManaBottle manaBottle;

        public EditorForm()
        {
            InitializeComponent();
            Application.Idle += delegate { screen.Invalidate(); panel.Invalidate(); };
            screen.BackgroundImage = new Bitmap(Width, Height);
            graphics = Graphics.FromImage(screen.BackgroundImage);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            tile_graphics = Graphics.FromImage(panel.BackgroundImage);
            tile_graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            temp = new Bitmap(32, 32);

            Map = new World(screen)
            {
                Width = 1280,
                Height = 1024,
                FieldSize = 32
            };
            tileEngine = new TileEngine(panel)
            {
                Width = 257,
                Height = 672,
                FieldSize = 32
            };

        }
        void ShowTileSet()
        {
            TilesPointer tilesPointer = new TilesPointer();
            tilesPointer.Location = new Point(this.Location.X - 736, this.Location.Y);
            tilesPointer.Show();
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
        protected override void OnLoad(EventArgs e)
        {
            //ShowTileSet();
            base.OnLoad(e);
        }
        private void screen_Paint(object sender, PaintEventArgs e)
        {
            //Map.Draw();
            //Map.UpdateTiles();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            tileEngine.Draw();
            //DrawSelected(selected_under_mouse_rect);
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            //var under_mouse_rect = tileEngine.Field[e.X / 32, e.Y / 32];
            // tile_graphics.DrawRectangle(Pens.White, under_mouse_rect);

            preview_tile.BackgroundImage = null;
            preview = new Bitmap(32, 32);
            selected_under_mouse_rect = tileEngine.Field[e.X / 32, e.Y / 32];
            CopyRegionIntoImage((Bitmap)panel.BackgroundImage, selected_under_mouse_rect, ref preview, preview_tile.ClientRectangle);

            preview_tile.BackgroundImage = preview;
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                type = Types.Tile;
                tile.BackgroundImage = null;
                temp = new Bitmap(32, 32);
                selected_under_mouse_rect = tileEngine.Field[e.X / 32, e.Y / 32];
                CopyRegionIntoImage((Bitmap)panel.BackgroundImage, selected_under_mouse_rect, ref temp, tile.ClientRectangle);

                tile.BackgroundImage = temp;
            }
        }

        public void CopyRegionIntoImage(Bitmap srcBitmap, Rectangle srcRegion, ref Bitmap destBitmap, Rectangle destRegion)
        {
            using (Graphics grD = Graphics.FromImage(destBitmap))
            {
                grD.DrawImage(srcBitmap, destRegion, srcRegion, GraphicsUnit.Pixel);
            }
        }

        public void DrawSelected(Rectangle rect)
        {
            tile_graphics.DrawRectangle(Pens.Red, rect);
        }

        private void screen_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Map.ReDraw(e.X / 32, e.Y / 32, temp);
                    Map.UpdateTiles();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    var til = new Bitmap("Data/Textures/empty.png");

                    Map.ReDraw(e.X / 32, e.Y / 32, til);
                    Map.UpdateTiles();
                }
            }
        }

        private void screen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (type == Types.Tile)
                {
                    isPressed = true;
                    Map.ReDraw(e.X / 32, e.Y / 32, temp);
                    Map.UpdateTiles();
                }
                if (type == Types.Object)
                {
                    var rect = Map.Field[e.X / 32, e.Y / 32];
                    if (objectsType == ObjectsType.HealthBottle)
                    {
                        var healthBottle = new HealthBottle() { Width = 32, Height = 32, Location = new Point(rect.X, rect.Y), GivenHealth = 10 };
                        healthBottle.Location = rect.Location;
                        healthBottle.Draw(graphics);
                        Map.AddHealthBottle(new HealthBottle() { Width = 32, Height = 32, Location = new Point(rect.X, rect.Y), GivenHealth = 10, Bounds = new Rectangle(rect.X, rect.Y, 32, 32) });
                    }
                    if (objectsType == ObjectsType.ManaBottle)
                    {
                        var manaBottle = new ManaBottle() { Width = 32, Height = 32, Location = new Point(rect.X, rect.Y), GivenMana = 5, Bounds = new Rectangle(rect.X, rect.Y, 32, 32) };
                        manaBottle.Location = rect.Location;
                        manaBottle.Draw(graphics);
                        Map.AddManaBottle(new ManaBottle() { Width = 32, Height = 32, Location = new Point(rect.X, rect.Y), GivenMana = 5, Bounds = new Rectangle(rect.X, rect.Y, 32, 32) });
                    }
                    if (objectsType == ObjectsType.Enemy)
                    {
                        var enemy = new Enemy() { Width = 32, Height = 32, Location = new Point(rect.X, rect.Y), GivenExp = 10, Bounds = new Rectangle(rect.X, rect.Y, 32, 32) };
                        enemy.Location = rect.Location;
                        enemy.Draw(graphics);
                        Map.AddEnemy(new Enemy() { Width = 32, Height = 32, Location = new Point(rect.X, rect.Y), GivenExp = 10, Bounds = new Rectangle(rect.X, rect.Y, 32, 32) });
                    }
                    if (objectsType == ObjectsType.Block)
                    {
                        var block = new Block() { Width = 32, Height = 32, Location = new Point(rect.X, rect.Y), Bounds = new Rectangle(rect.X, rect.Y, 32, 32) };
                        block.Location = new Point(rect.X, rect.Y);
                        block.Draw(graphics);
                        Map.AddBlock(new Block() { Width = 32, Height = 32, Location = new Point(rect.X, rect.Y), Bounds = new Rectangle(rect.X, rect.Y, 32, 32) });
                    }
                    if (objectsType == ObjectsType.Exit)
                    {
                        var exit = new Exit() { Width = 32, Height = 32, Location = new Point(rect.X, rect.Y), Bounds = new Rectangle(rect.X, rect.Y, 32, 32) };
                        exit.Location = new Point(rect.X, rect.Y);
                        exit.Draw(graphics);
                        Map.AddExit(new Exit() { Width = 32, Height = 32, Location = new Point(rect.X, rect.Y), Bounds = new Rectangle(rect.X, rect.Y, 32, 32) });
                    }
                    if (objectsType == ObjectsType.PlayerStart)
                    {
                        var start = new PlayerStart() { Width = 32, Height = 32, Location = new Point(rect.X, rect.Y), Bounds = new Rectangle(rect.X, rect.Y, 32, 32) };
                        start.Location = new Point(rect.X, rect.Y);
                        start.Draw(graphics);
                        Map.AddStart(start);
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                isPressed = true;
                var til = new Bitmap("Data/Textures/empty.png");
                Map.ReDraw(e.X / 32, e.Y / 32, til);
                Map.UpdateTiles();
            }


        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            Map.Draw();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Title = "Сохранить карту";
                save.Filter = "RPG Game map file|*.gamemap";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    string path = save.FileName;
                    //CreateMiniMap(save);
                    IFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        formatter.Serialize(fs, Map.Tiles);
                        formatter.Serialize(fs, Map.HealthBottles);
                        formatter.Serialize(fs, Map.ManaBottles);
                        formatter.Serialize(fs, Map.Enemies);
                        formatter.Serialize(fs, Map.Blocks);
                        formatter.Serialize(fs, Map.Exits);
                        formatter.Serialize(fs, Map.PlayerStart);
                    }
                }
            }
        }

        private void load_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Title = "Загрузить карту";
                open.Filter = "RPG Game map file|*.gamemap";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string path = open.FileName;
                    IFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        Map.Tiles = (Image[,])new BinaryFormatter().Deserialize(fs);
                        Map.HealthBottles = (List<HealthBottle>)new BinaryFormatter().Deserialize(fs);
                        Map.ManaBottles = (List<ManaBottle>)new BinaryFormatter().Deserialize(fs);
                        Map.Enemies = (List<Enemy>)new BinaryFormatter().Deserialize(fs);
                        Map.Blocks = (List<Block>)new BinaryFormatter().Deserialize(fs);
                        Map.Exits = (List<Exit>)new BinaryFormatter().Deserialize(fs);
                        Map.PlayerStart = (PlayerStart)new BinaryFormatter().Deserialize(fs);
                    }
                }
            }
            //Map.UpdateTiles();
            Map.Update();
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            Map.Clear();
            Map.UpdateTiles();
            Map.Draw();
        }

        private void screen_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void addHealthBottle_Click(object sender, EventArgs e)
        {
            type = Types.Object;
            objectsType = ObjectsType.HealthBottle;
        }

        private void addManaBottle_Click(object sender, EventArgs e)
        {
            type = Types.Object;
            objectsType = ObjectsType.ManaBottle;
        }

        private void addEnemy_Click(object sender, EventArgs e)
        {
            type = Types.Object;
            objectsType = ObjectsType.Enemy;
        }

        private void addBlock_Click(object sender, EventArgs e)
        {
            type = Types.Object;
            objectsType = ObjectsType.Block;
        }

        private void addExit_Click(object sender, EventArgs e)
        {
            type = Types.Object;
            objectsType = ObjectsType.Exit;
        }

        private void addPlayerStart_Click(object sender, EventArgs e)
        {
            type = Types.Object;
            objectsType = ObjectsType.PlayerStart;
        }
    }
}
