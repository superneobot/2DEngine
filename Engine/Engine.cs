using Engine;
using Engine.Core.AnimEngine;
using Engine.Core.PlayerEngine;
using Engine.GameObjects.Enemies;
using Engine.GameObjects.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Engine2D
{
    public class Engine
    {
        public World World { get; set; }
        public Player Player { get; set; }
        public Direction Direction { get; set; }
        public Animator PlayerAnimator;
        public Timer Timer { get; set; }
        public Graphics graphics { get; set; }

        string Inform = "";
        public Engine(Control control)
        {
            graphics = Graphics.FromImage(control.BackgroundImage);
            PlayerAnimator = new Animator("Player");
            Timer = new Timer();
            Timer.Interval = 100;
            Timer.Elapsed += Timer_Elapsed;
            Timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {


        }

        private DateTime lastUpdate = DateTime.MinValue;
        private Rectangle[] neibours;

        public void Update()
        {
            var now = DateTime.Now;
            var dt = (float)(now - lastUpdate).TotalMilliseconds / 300f;
            //
            if (lastUpdate != DateTime.MinValue)
            {
                Player.Update(dt);
            }
            //
            lastUpdate = now;
            if (Player.Position.X + Player.Width > World.Width)
            {
                Player.Velocity = new System.Drawing.PointF(Player.Velocity.X - Player.Speed * 2, Player.Velocity.Y);
            }
            if (Player.Position.X < 16.0F)
            {
                Player.Velocity = new System.Drawing.PointF(Player.Velocity.X + Player.Speed * 2, Player.Velocity.Y);
            }
            if (Player.Position.Y + Player.Bounds.Height < Player.Height)
            {
                Player.Velocity = new System.Drawing.PointF(Player.Velocity.X, Player.Velocity.Y + Player.Speed * 2);
            }
            if (Player.Position.Y + Player.Bounds.Height > World.Height)
            {
                Player.Velocity = new System.Drawing.PointF(Player.Velocity.X, Player.Velocity.Y - Player.Speed * 2);
            }

            neibours = new Rectangle[4];
            neibours[0] = new Rectangle((int)(Player.Bounds.X + 32), (int)Player.Bounds.Y, 32, 32);
            neibours[1] = new Rectangle((int)(Player.Bounds.X - 32), (int)Player.Bounds.Y, 32, 32);
            neibours[2] = new Rectangle((int)Player.Bounds.X, (int)(Player.Bounds.Y + 32), 32, 32);
            neibours[3] = new Rectangle((int)Player.Bounds.X, (int)(Player.Bounds.Y - 32), 32, 32);

            for (int i = 0; i < neibours.Length; i++)
            {
                graphics.FillRectangle(Brushes.Silver, neibours[i]);
            }
        }

        public string Info()
        {
            PointF[] neibours = new PointF[4];
            neibours[0] = new PointF(Player.Bounds.X + 32, Player.Bounds.Y);
            neibours[1] = new PointF(Player.Bounds.X - 32, Player.Bounds.Y);
            neibours[2] = new PointF(Player.Bounds.X, Player.Bounds.Y + 32);
            neibours[3] = new PointF(Player.Bounds.X + 32, Player.Bounds.Y - 32);

            return $"{Direction} | Blocks: {neibours[0]} - {neibours[1]} - {neibours[2]} - {neibours[3]} | Player: {Player.Position} | INFO: {Inform}";
        }

        public void Check()
        {


        }

        public void MoveRight()
        {
            Direction = Direction.Right;
            Player.Image = PlayerAnimator.Sprite;
            PlayerAnimator.LoadSprites("Player", Direction);
            PlayerAnimator.Run();
            Player.Image = PlayerAnimator.Sprite;
            //Движение вправо со скоростью Speed
            Player.Position = new PointF(Player.Position.X + Player.Speed, Player.Position.Y);
            if (Player.Position.X + Player.Width > World.Width)   //Если идем за границы карты
            {
                Player.Position = new PointF(Player.Position.X - Player.Speed, Player.Position.Y);
            }
            foreach (var item in World.Blocks)      //Поиск по списку блоков на карте
            {
                if (Player.Bounds.IntersectsWith(item.Bounds))  //Если Rectangle Player'a пересекается с одним из Block
                {
                    graphics.FillRectangle(Brushes.Red, neibours[0]);  //Соседняя справа клетка закрашивается для видимости взаимодействия
                    Player.Position = new PointF((float)(Player.Position.X - Player.Speed*2), Player.Position.Y); //Двигает Player'a в обратном направлении
                }
            }
        }
        public void MoveLeft()
        {
            Direction = Direction.Left;
            Player.Image = PlayerAnimator.Sprite;
            PlayerAnimator.LoadSprites("Player", Direction);
            PlayerAnimator.Run();
            Player.Image = PlayerAnimator.Sprite;

            Player.Position = new PointF(Player.Position.X - Player.Speed, Player.Position.Y);
            if (Player.Position.X < 16.0F)
            {
                Player.Position = new PointF(Player.Position.X + Player.Speed, Player.Position.Y);
            }
            foreach (var item in World.Blocks)
            {
                if (Player.Bounds.IntersectsWith(item.Bounds))
                {
                    graphics.FillRectangle(Brushes.Red, neibours[1]);
                    Player.Position = new PointF((float)(Player.Position.X + Player.Speed*2), Player.Position.Y);
                }
            }
        }
        public void MoveUp()
        {
            Direction = Direction.Up;
            Player.Image = PlayerAnimator.Sprite;
            PlayerAnimator.LoadSprites("Player", Direction);
            PlayerAnimator.Run();
            Player.Image = PlayerAnimator.Sprite;

            Player.Position = new PointF(Player.Position.X, Player.Position.Y - Player.Speed);
            if (Player.Position.Y + Player.Bounds.Height < Player.Height)
            {
                Player.Position = new System.Drawing.PointF(Player.Position.X, Player.Position.Y + Player.Speed * 2);
            }
            foreach (var item in World.Blocks)
            {
                if (Player.Bounds.IntersectsWith(item.Bounds))
                {
                    graphics.FillRectangle(Brushes.Red, neibours[3]);
                    Player.Position = new PointF((float)(Player.Position.X), Player.Position.Y+Player.Speed*2);
                }
            }
        }
        public void MoveDown()
        {
            Direction = Direction.Down;
            Player.Image = PlayerAnimator.Sprite;
            PlayerAnimator.LoadSprites("Player", Direction);
            PlayerAnimator.Run();
            Player.Image = PlayerAnimator.Sprite;

            Player.Position = new PointF(Player.Position.X, Player.Position.Y + Player.Speed);
            if (Player.Position.Y + Player.Bounds.Height > World.Height)
            {
                Player.Position = new System.Drawing.PointF(Player.Position.X, Player.Position.Y - Player.Speed);
            }
            foreach (var item in World.Blocks)
            {
                if (Player.Bounds.IntersectsWith(item.Bounds))
                {
                    graphics.FillRectangle(Brushes.Red, neibours[2]);
                    Player.Position = new PointF((float)(Player.Position.X), Player.Position.Y - Player.Speed * 2);
                }
            }
        }
        public void Stop()
        {
            Direction = Direction.Idle;
        }
        public void Fire()
        {
            //TO DO: Fire
        }

        public List<int> FindNeibours(Rectangle[,] field)
        {
            List<int> list = new List<int>();

            Point[] neibours = new Point[4];

            return list;
        }

        public void Render(Graphics graphics)
        {
            World.Draw();
            LoadMap("Data/Maps/level_0.gamemap");
            World.Update();
            Player.Draw();


        }

        public void LoadMap(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                World.Tiles = (Image[,])new BinaryFormatter().Deserialize(fs);
                World.HealthBottles = (List<HealthBottle>)new BinaryFormatter().Deserialize(fs);
                World.ManaBottles = (List<ManaBottle>)new BinaryFormatter().Deserialize(fs);
                World.Enemies = (List<Enemy>)new BinaryFormatter().Deserialize(fs);
                World.Blocks = (List<Block>)new BinaryFormatter().Deserialize(fs);
                World.Exits = (List<Exit>)new BinaryFormatter().Deserialize(fs);
                World.PlayerStart = (PlayerStart)new BinaryFormatter().Deserialize(fs);
            }
        }
    }

}
