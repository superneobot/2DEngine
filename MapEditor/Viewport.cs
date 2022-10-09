using System.Windows.Forms;

namespace Game
{
    public class Viewport : Panel
    {
        public Viewport()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }

}
