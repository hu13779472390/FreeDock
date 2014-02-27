using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security;

namespace FQ.FreeDock
{
    class x7a797590a9beb775 : Form
    {
        private const int x25e1af1de31299a2 = 0x00000002;
        private const int WS_EX_LAYERED = 0x00080000;
        private const int SWP_NOACTIVATE = 0x00000010;
        private const int SWP_SHOWWINDOW = 0x00000040;
        private const int LWA_ALPHA = 0x00000002;
        private const int LWA_COLORKEY = 0x00000001;
        private const long WS_POPUP = 0x80000000L;
        private bool hollow;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.Style = int.MinValue;
                createParams.ExStyle |= WS_EX_LAYERED;
                return createParams;
            }
        }

        public x7a797590a9beb775(bool hollow)
        {
            this.hollow = hollow;
            this.BackColor = SystemColors.Highlight;
            this.ShowInTaskbar = false;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter, int x, int y, int cx, int cy, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, int crKey, byte bAlpha, int dwFlags);

        [SecuritySafeCritical]
        public void xf00ba4096f8180b1(Rectangle bounds, bool x067d6ddeefb41622)
        {
            SetWindowPos(new HandleRef(this, this.Handle), new HandleRef(this, IntPtr.Zero), bounds.X, bounds.Y, bounds.Width, bounds.Height, 80);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.hollow)
            {
                Rectangle clientRectangle = this.ClientRectangle;
                --clientRectangle.Width;
                --clientRectangle.Height;
                e.Graphics.DrawRectangle(SystemPens.ControlDark, clientRectangle);
                clientRectangle.Inflate(-1, -1);
                e.Graphics.DrawRectangle(SystemPens.ControlDark, clientRectangle);
            }
        }

        [SecuritySafeCritical]
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
//            x7a797590a9beb775.SetLayeredWindowAttributes(this.Handle, 0, (byte)sbyte.MinValue, 2);
            x7a797590a9beb775.SetLayeredWindowAttributes(this.Handle, 0, 127, LWA_ALPHA);
        }
    }
}
