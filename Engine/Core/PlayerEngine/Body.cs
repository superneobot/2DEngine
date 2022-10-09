using System.Drawing;

namespace Engine.Core.PlayerEngine
{
    public class Body
    {
        /// <summary>
        /// Координаты
        /// </summary>
        public PointF Position { get; set; }
        /// <summary>
        /// Скорость
        /// </summary>
        public PointF Velocity { get; set; }
        /// <summary>
        /// Тело
        /// </summary>
        public RectangleF Bounds { get; set; }
        public Body()
        {

        }

        public virtual void Update(float dt)
        {
            //скорость
            Velocity = new PointF(Velocity.X, Velocity.Y);
            //координаты
            Position = new PointF(Position.X, Position.Y);
        }
    }
}
