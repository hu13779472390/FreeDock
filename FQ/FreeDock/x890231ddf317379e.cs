using System;
using System.Drawing;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    // c
    abstract class x890231ddf317379e : IDisposable, IMessageFilter
    {
        private DockingHints dockingHints = DockingHints.TranslucentFill;
        private Rectangle bounds = Rectangle.Empty;
        private int tabStripSize = 21;
        private const int x3ab50d2ad9712e32 = 256;
        private const int xacaf912f8e96627a = 257;
        private const int x9e72e1fc89a4d09f = 260;
        private const int x0099d1a3582c25df = 261;
        private const int xcd390c5181df4669 = 15;
        private const int WM_KEYDOWN = 0x0100;
        // 256
        private const int WM_KEYUP = 0x0101;
        // 257
        private const int WM_SYSKEYDOWN = 0x0104;
        // 260
        private const int WM_SYSKEYUP = 0x0105;
        // 261
        private const int WM_KEYLAST = 0x0108;
        // 264
        private const int WM_PAINT = 0x000F;
        // 15
        private const int VK_SHIFT = 0x0010;
        // 16
        private const int VK_CONTROL = 0x0010;
        // 17
        private const int VK_MENU = 0x0011;
        // 18
        private Form form;
        private Control control;
        private bool xd0c8332c4cbc4175;
        private bool hollow;
        private DockingHintForm dockingHintForm;

        public event EventHandler Cancelled;

        public x890231ddf317379e(Control control, DockingHints dockingHints, bool hollow, int tabStripSize) : this(control, dockingHints, hollow)
        {
            this.tabStripSize = tabStripSize;
        }

        public x890231ddf317379e(Control control, DockingHints dockingHints, bool hollow)
        {
            this.control = control;
            this.hollow = hollow;
            bool flag = OSFeature.Feature.IsPresent(OSFeature.LayeredWindows);
            if (dockingHints == DockingHints.TranslucentFill && !flag)
                dockingHints = DockingHints.RubberBand;
            this.dockingHints = dockingHints;
            this.form = control.FindForm();
            if (this.form != null)
                this.form.Deactivate += new EventHandler(this.OnDeactivate);
            control.MouseCaptureChanged += new EventHandler(this.OnMouseCaptureChanged);
            Application.AddMessageFilter(this);
            if (dockingHints != DockingHints.TranslucentFill)
                return;
            this.dockingHintForm = new DockingHintForm(hollow);
        }

        private void OnMouseCaptureChanged(object sender, EventArgs e)
        {
            this.Cancel();
        }

        internal static bool IsNT5()
        {
            bool flag = false;
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                flag = Environment.OSVersion.Version >= new Version(5, 0, 0, 0);
            return flag;
        }

        protected void xe5e4149f382149cc(Rectangle bounds, bool x067d6ddeefb41622)
        {
            if (this.bounds == bounds)
                return;
//            if (this.dockingHints == DockingHints.RubberBand)
//                this.x45e11bb29ea5a4f9();
//            if (this.dockingHints == DockingHints.RubberBand)
//            {
//                if (this.hollow)
//                    WinBrush.xda2defffc25953e0(null, bounds, x067d6ddeefb41622, this.tabStripSize);
//                else
//                    WinBrush.xe5e0d1644c72aafd(null, bounds);
//                this.bounds = bounds;
//                this.xd0c8332c4cbc4175 = x067d6ddeefb41622;
//                return;
//            }
//            else
                this.dockingHintForm.xf00ba4096f8180b1(bounds, x067d6ddeefb41622);
        }

        protected void x11972e8742c570b8()
        {
            if (this.dockingHints == DockingHints.RubberBand)
                this.x45e11bb29ea5a4f9();
            else
                this.dockingHintForm.Hide();
        }

        private void x45e11bb29ea5a4f9()
        {
            if (this.bounds != Rectangle.Empty)
            {
                if (this.hollow)
                    WinBrush.xda2defffc25953e0(null, this.bounds, this.xd0c8332c4cbc4175, this.tabStripSize);
                else
                    WinBrush.xe5e0d1644c72aafd(null, this.bounds);
            }
            this.bounds = Rectangle.Empty;
        }

        public virtual void Commit()
        {
            this.Dispose();
        }

        public virtual void Cancel()
        {
            this.Dispose();
            if (this.Cancelled != null)
                this.Cancelled(this, EventArgs.Empty);
        }
        // reviewed
        public virtual void Dispose()
        {
            if (this.control != null)
                this.control.MouseCaptureChanged -= new EventHandler(this.OnMouseCaptureChanged);

            this.x11972e8742c570b8();
            if (this.dockingHints == DockingHints.TranslucentFill)
            {
                this.dockingHintForm.Dispose();
                this.dockingHintForm = null;
            }

            if (this.form != null)
                this.form.Deactivate -= new EventHandler(this.OnDeactivate);
            Application.RemoveMessageFilter(this);
            this.form = null;
            this.control = null;
        }

        private void OnDeactivate(object sender, EventArgs e)
        {
            this.Cancel();
        }

        private void x7ec1a570ae92aafb()
        {
            if (this.dockingHints == DockingHints.RubberBand)
                this.x45e11bb29ea5a4f9();
        }

        public abstract void OnMouseMove(Point position);

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_PAINT)
                this.x7ec1a570ae92aafb();
//            if (m.Msg == 533)
//                Debugger.Break();
            if ((m.Msg == WM_KEYDOWN || m.Msg == WM_KEYUP) && m.WParam.ToInt32() == VK_CONTROL)
            {
                this.OnMouseMove(Cursor.Position);
                return false;
            }
            else
            {
                if (m.Msg < WM_KEYDOWN || m.Msg > WM_KEYLAST)
                    return false;
                this.Cancel();
                return true;
            }
        }
    }
}
