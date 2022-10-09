using System;
using System.Drawing;

namespace Engine.GameObjects.Items
{
    [Serializable]
    public class GameObject
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle Bounds { get; set; }
        public Point Location { get; set; }
        public GameObject()
        {

        }
    }
}
