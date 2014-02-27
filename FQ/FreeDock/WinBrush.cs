using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    class WinBrush
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateBitmap(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, short[] lpvBits);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateBrushIndirect(LogBrush lb);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(HandleRef hObject);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(HandleRef hWnd, HandleRef hDC);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(HandleRef hDC, HandleRef hObject);

        [DllImport("gdi32.dll")]
        private static extern bool PatBlt(HandleRef hdc, int left, int top, int width, int height, int rop);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetDC(HandleRef hWnd);
        // reviewd!
        public static void xda2defffc25953e0(Control control, Rectangle bounds, bool xc346f54d9968657b, int x189455fe88a3b711)
        {
            xe5e0d1644c72aafd(control, new Rectangle(bounds.X, bounds.Y, bounds.Width, 4));
            if (xc346f54d9968657b)
            {
                xe5e0d1644c72aafd(control, new Rectangle(bounds.X, bounds.Y + 4, 4, bounds.Height - 4 - x189455fe88a3b711));
                xe5e0d1644c72aafd(control, new Rectangle(bounds.Right - 4, bounds.Y + 4, 4, bounds.Height - 4 - x189455fe88a3b711));
                xe5e0d1644c72aafd(control, new Rectangle(bounds.X, bounds.Bottom - x189455fe88a3b711, 10, 4));
                xe5e0d1644c72aafd(control, new Rectangle(bounds.X + 80, bounds.Bottom - x189455fe88a3b711, bounds.Width - 80, 4));
                xe5e0d1644c72aafd(control, new Rectangle(bounds.X + 10, bounds.Bottom - 4, 70, 4));
                xe5e0d1644c72aafd(control, new Rectangle(bounds.X + 10, bounds.Bottom - x189455fe88a3b711, 4, x189455fe88a3b711 - 4));
                xe5e0d1644c72aafd(control, new Rectangle(bounds.X + 76, bounds.Bottom - x189455fe88a3b711, 4, x189455fe88a3b711 - 4));
            }
            else
            {
                xe5e0d1644c72aafd(control, new Rectangle(bounds.X, bounds.Y + 4, 4, bounds.Height - 8));
                xe5e0d1644c72aafd(control, new Rectangle(bounds.Right - 4, bounds.Y + 4, 4, bounds.Height - 8));
                xe5e0d1644c72aafd(control, new Rectangle(bounds.X, bounds.Bottom - 4, bounds.Width, 4));
            }
        }
        // reviewed with 2.4
        public static void xe5e0d1644c72aafd(Control control, Rectangle bounds)
        {
            if (bounds == Rectangle.Empty)
                return;

            IntPtr handle1 = control != null ? control.Handle : IntPtr.Zero;
            IntPtr dc = GetDC(new HandleRef(control, handle1));
            IntPtr handle2 = xf7ba50da2798338e();
            IntPtr handle3 = SelectObject(new HandleRef(control, dc), new HandleRef(null, handle2));
            PatBlt(new HandleRef(control, dc), bounds.X, bounds.Y, bounds.Width, bounds.Height, 0x5A0049);
            SelectObject(new HandleRef(control, dc), new HandleRef(null, handle3));
            DeleteObject(new HandleRef(null, handle2));
            ReleaseDC(new HandleRef(control, handle1), new HandleRef(null, dc));
        }

        private static IntPtr xf7ba50da2798338e()
        {
            short[] lpvBits = new short[8];
            for (int i = 0; i < 8; ++i)
                lpvBits[i] = (short)(0x5555 << (i & 1)); 
            IntPtr bitmap = CreateBitmap(8, 8, 1, 1, lpvBits);
            LogBrush lb = new LogBrush();
            lb.color = ColorTranslator.ToWin32(Color.Black);
            lb.style = 3;
            lb.hatch = bitmap;
            IntPtr brushIndirect = CreateBrushIndirect(lb);
            DeleteObject(new HandleRef(null, bitmap));
            return brushIndirect;

//            Image image = Image.FromFile("bitmap file path");
//            TextureBrush textureBrush = new TextureBrush(image);
//            return new TextureBrush(image);
//            return IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        private class LogBrush
        {
            public int style;
            public int color;
            public IntPtr hatch;
        }
    }
}
