using Engine.Core.PlayerEngine;
using System;
using System.Drawing;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace Engine.Core.AnimEngine
{
    public class Animator
    {
        public Image Sprite { get; set; }
        public Image[] Strip { get; set; }
        private Direction dir;
        private Timer Update;
        private int cadr = 0;

        public Animator(string type)
        {
            Strip = new Image[6];
            Update = new Timer();
            Update.Interval = 120;
            Update.Tick += Update_Elapsed;
            Sprite = FirstSprite(type, dir);
        }

        public Image FirstSprite(string type, Direction dir)
        {
            return Sprite = new Bitmap($"Data/Textures/{type}/Down/frame_1.gif");
        }

        private void Update_Elapsed(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Sprite = Strip[cadr];
                cadr++;
                if (cadr == Strip.Length) cadr = 0;
            }).Start();
        }

        public void LoadSprites(string type, Direction dir)
        {
            for (int i = 0; i < Strip.Length; i++)
            {
                Strip[i] = new Bitmap($"Data/Textures/{type}/{dir}/frame_" + i + ".gif", true);

            }
        }

        public void Run()
        {
            Update.Start();
        }
    }
}
