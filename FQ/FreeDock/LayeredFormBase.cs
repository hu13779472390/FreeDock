using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security;

namespace FQ.FreeDock
{
    class LayeredFormBase : Form
    {
        private const int WS_EX_LAYERED = 0x00080000;
        private const int ULW_ALPHA = 0x00000002;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_LAYERED;
                return createParams;
            }
        }

        public LayeredFormBase()
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        [SecuritySafeCritical]
        public void x0ecee64b07d2d5b1(Bitmap bitmap, byte alpha)
        {
            IntPtr dc = WinApi.GetDC(IntPtr.Zero);
            IntPtr compatibleDc = WinApi.CreateCompatibleDC(dc);
            IntPtr hObject1 = IntPtr.Zero;
            IntPtr hObject2 = IntPtr.Zero;
            try
            {
                hObject1 = bitmap.GetHbitmap(Color.FromArgb(0));
                hObject2 = WinApi.SelectObject(compatibleDc, hObject1);
                WinApi.BLENDFUNCTION pblend;
                WinApi.POINT pptDst;
                WinApi.SIZE psize;
                WinApi.POINT pprSrc;
                psize = new WinApi.SIZE(bitmap.Width, bitmap.Height);
                pprSrc = new WinApi.POINT(0, 0);
                pptDst = new WinApi.POINT(this.Left, this.Top);
                pblend = new WinApi.BLENDFUNCTION();
                pblend.BlendOp = 0;
                pblend.BlendFlags = 0;
                pblend.SourceConstantAlpha = alpha;
                pblend.AlphaFormat = 1;
                WinApi.UpdateLayeredWindow(this.Handle, dc, ref pptDst, ref psize, compatibleDc, ref pprSrc, 0, ref pblend, ULW_ALPHA);
            }
            finally
            {
                if (hObject1 != IntPtr.Zero)
                {
                    WinApi.SelectObject(compatibleDc, hObject2);
                    WinApi.DeleteObject(hObject1);
                }
                WinApi.ReleaseDC(IntPtr.Zero, dc);
                WinApi.DeleteDC(compatibleDc);
            }
        }

        private class WinApi
        {
            public const int x5369785684a974f4 = 1;
            public const int x93b283a033d1b54a = 2;
            public const int x11a0985503a2d2df = 4;
            public const byte xdd6043f42253ee15 = 0;
            public const byte xa34cc3e091661d7f = 1;

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref WinApi.POINT pptDst, ref WinApi.SIZE psize, IntPtr hdcSrc, ref WinApi.POINT pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr GetDC(IntPtr hWnd);

            [DllImport("user32.dll")]
            public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

            [DllImport("gdi32.dll", SetLastError = true)]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

            [DllImport("gdi32.dll", SetLastError = true)]
            public static extern bool DeleteDC(IntPtr hdc);

            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

            [DllImport("gdi32.dll", SetLastError = true)]
            public static extern bool DeleteObject(IntPtr hObject);

            public struct SIZE
            {
                public int cx;
                public int cy;

                public SIZE(int cx, int cy)
                {
                    this.cx = cx;
                    this.cy = cy;
                }
            }

            public struct POINT
            {
                public int x;
                public int y;

                public POINT(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct BLENDFUNCTION
            {
                public byte BlendOp;
                public byte BlendFlags;
                public byte SourceConstantAlpha;
                public byte AlphaFormat;
            }
        }
    }
}
