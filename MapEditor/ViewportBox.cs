using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditor
{
    /// <summary>
    /// Displays a hierarchical collection of labeled items, each represented by a System.Windows.Forms.TreeNode.
    /// </summary>
    [
    //Use the same attibutes as TreeView
    DesignerAttribute("System.Windows.Forms.Design.TreeViewDesigner, System.Design, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"),
    DefaultPropertyAttribute("Nodes"),
    DefaultEventAttribute("AfterSelect")
    ]
    public class ViewportBox : UserControl
    {
        Bitmap internalBitmap = null;
        Graphics internalGraphics = null;

        private void DisposeInternal()
        {
            if (internalGraphics != null)
                internalGraphics.Dispose();
            if (internalBitmap != null)
                internalBitmap.Dispose();

        }
        /// <summary>Releases resources.</summary>
        /// <param name="disposing">true = Both managed and unmanaged, false = Unmanaged only.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                DisposeInternal();
            base.Dispose(disposing);
        }
        /// 
        public ViewportBox()
        {
            this.BackColor = Color.Red;
        }
        /// <summary>Occurs when window is resized.</summary>
        /// <param name="e">A System.EventArgs.Empty.</param>
        /// <remarks>Recreates internal Graphics object. </remarks>
        protected override void OnResize(System.EventArgs e)
        {
            if (internalBitmap == null ||
                internalBitmap.Width != Width || internalBitmap.Height != Height)
            {

                if (Width != 0 && Height != 0)
                {
                    DisposeInternal();
                    internalBitmap = new Bitmap(Width, Height);
                    internalGraphics = Graphics.FromImage(internalBitmap);
                }
            }
        }

        /// <summary>Occurs when a Windows message is dispatched.</summary>
        /// <param name="message">Message to process.</param>
        /// <remarks>Overrides WM_PAINT, WM_ERASEBKGND.</remarks>
        protected override void WndProc(ref Message message)
        {
            const int WM_PAINT = 0x000F;
            const int WM_PRINTCLIENT = 0x0318;
            const int WM_ERASEBKGND = 0x0014;

            switch (message.Msg)
            {

                case WM_ERASEBKGND:
                    //removes flicker
                    return;

                case WM_PAINT:
                    // The designer host does not call OnResize()                    
                    if (internalGraphics == null)
                        OnResize(EventArgs.Empty);

                    //Set up 
                    Win32.RECT updateRect = new Win32.RECT();
                    if (Win32.GetUpdateRect(message.HWnd, ref updateRect, false) == 0)
                        break;

                    Win32.PAINTSTRUCT paintStruct = new Win32.PAINTSTRUCT();
                    IntPtr screenHdc = Win32.BeginPaint(message.HWnd, ref paintStruct);
                    using (Graphics screenGraphics = Graphics.FromHdc(screenHdc))
                    {

                        //Draw Internal Graphics
                        IntPtr hdc = internalGraphics.GetHdc();
                        Message printClientMessage = Message.Create(Handle, WM_PRINTCLIENT, hdc, IntPtr.Zero);
                        DefWndProc(ref printClientMessage);
                        internalGraphics.ReleaseHdc(hdc);

                        //Add the missing OnPaint() call
                        OnPaint(new PaintEventArgs(internalGraphics, Rectangle.FromLTRB(
                            updateRect.left,
                            updateRect.top,
                            updateRect.right,
                            updateRect.bottom)));

                        //Draw Screen Graphics
                        screenGraphics.DrawImage(internalBitmap, 0, 0);
                    }

                    //Tear down
                    Win32.EndPaint(message.HWnd, ref paintStruct);
                    return;
            }
            base.WndProc(ref message);
        }

        /// <summary>Occurs when the control is redrawn.</summary>
        /// <remarks>Re enable browsing attributes for the Paint Event.</remarks>
        [
        EditorBrowsableAttribute(EditorBrowsableState.Always),
        BrowsableAttribute(true)
        ]
        public new event PaintEventHandler Paint
        {
            add { base.Paint += value; }
            remove { base.Paint -= value; }
        }
    }
}
