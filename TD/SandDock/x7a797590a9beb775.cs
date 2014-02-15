using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    internal class x7a797590a9beb775 : Form
    {
        private const int x25e1af1de31299a2 = 2;
        private const int xb615ddf284afbdf6 = 524288;
        private const int x77bf04ec211c4a37 = 16;
        private const int x339acab5bf3e83ae = 64;
        private const int xb644deafcaa222c4 = 2;
        private const int xb8a822e576f3bf60 = 1;
        private bool x21480c2e0df4efcd;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.Style = int.MinValue;
                createParams.ExStyle |= 524288;
                return createParams;
            }
        }

        public x7a797590a9beb775(bool hollow)
        {
            this.x21480c2e0df4efcd = hollow;
            this.BackColor = SystemColors.Highlight;
            this.ShowInTaskbar = false;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter, int x, int y, int cx, int cy, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, int crKey, byte bAlpha, int dwFlags);

        public void xf00ba4096f8180b1(Rectangle xda73fcb97c77d998, bool x067d6ddeefb41622)
        {
            x7a797590a9beb775.SetWindowPos(new HandleRef((object)this, this.Handle), new HandleRef((object)this, IntPtr.Zero), xda73fcb97c77d998.X, xda73fcb97c77d998.Y, xda73fcb97c77d998.Width, xda73fcb97c77d998.Height, 80);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            do
            {
                if (0 == 0)
                    goto label_4;
                label_2:
                Rectangle clientRectangle;
                clientRectangle.Inflate(-1, -1);
                e.Graphics.DrawRectangle(SystemPens.ControlDark, clientRectangle);
                continue;
                label_4:
                if (this.x21480c2e0df4efcd)
                {
                    clientRectangle = this.ClientRectangle;
                    --clientRectangle.Width;
                    if (-2 != 0)
                    {
                        --clientRectangle.Height;
                        e.Graphics.DrawRectangle(SystemPens.ControlDark, clientRectangle);
                        goto label_2;
                    }
                    else
                        goto label_8;
                }
                else
                    goto label_7;
            }
            while (2 == 0);
            return;
            label_7:
            return;
            label_8:
            ;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            x7a797590a9beb775.SetLayeredWindowAttributes(this.Handle, 0, (byte)sbyte.MinValue, 2);
        }
    }
}
