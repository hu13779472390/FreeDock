using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    class x130e0425ae2d4496
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateBitmap(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, short[] lpvBits);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateBrushIndirect(x130e0425ae2d4496.x78c6fa48e5c2be9b lb);

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
        public static void xda2defffc25953e0(Control control, Rectangle rect, bool xc346f54d9968657b, int x189455fe88a3b711)
        {
            x130e0425ae2d4496.xe5e0d1644c72aafd(control, new Rectangle(rect.X, rect.Y, rect.Width, 4));
            if (!xc346f54d9968657b)
            {
                x130e0425ae2d4496.xe5e0d1644c72aafd(control, new Rectangle(rect.X, rect.Y + 4, 4, rect.Height - 8));
                x130e0425ae2d4496.xe5e0d1644c72aafd(control, new Rectangle(rect.Right - 4, rect.Y + 4, 4, rect.Height - 8));
                x130e0425ae2d4496.xe5e0d1644c72aafd(control, new Rectangle(rect.X, rect.Bottom - 4, rect.Width, 4));
            }
            else
            {
                x130e0425ae2d4496.xe5e0d1644c72aafd(control, new Rectangle(rect.X, rect.Y + 4, 4, rect.Height - 4 - x189455fe88a3b711));
                x130e0425ae2d4496.xe5e0d1644c72aafd(control, new Rectangle(rect.Right - 4, rect.Y + 4, 4, rect.Height - 4 - x189455fe88a3b711));
                x130e0425ae2d4496.xe5e0d1644c72aafd(control, new Rectangle(rect.X, rect.Bottom - x189455fe88a3b711, 10, 4));
                x130e0425ae2d4496.xe5e0d1644c72aafd(control, new Rectangle(rect.X + 80, rect.Bottom - x189455fe88a3b711, rect.Width - 80, 4));
                x130e0425ae2d4496.xe5e0d1644c72aafd(control, new Rectangle(rect.X + 10, rect.Bottom - 4, 70, 4));
                x130e0425ae2d4496.xe5e0d1644c72aafd(control, new Rectangle(rect.X + 10, rect.Bottom - x189455fe88a3b711, 4, x189455fe88a3b711 - 4));
                x130e0425ae2d4496.xe5e0d1644c72aafd(control, new Rectangle(rect.X + 76, rect.Bottom - x189455fe88a3b711, 4, x189455fe88a3b711 - 4));
            }
        }

        public static void xe5e0d1644c72aafd(Control control, Rectangle rect)
        {
            if (rect != Rectangle.Empty)
            {
                IntPtr handle1 = control != null ? control.Handle : IntPtr.Zero;
                IntPtr dc = x130e0425ae2d4496.GetDC(new HandleRef(control, handle1));
                IntPtr handle2 = x130e0425ae2d4496.xf7ba50da2798338e();
                IntPtr handle3 = x130e0425ae2d4496.SelectObject(new HandleRef(control, dc), new HandleRef(null, handle2));
                x130e0425ae2d4496.PatBlt(new HandleRef(control, dc), rect.X, rect.Y, rect.Width, rect.Height, 5898313);
                x130e0425ae2d4496.SelectObject(new HandleRef(control, dc), new HandleRef(null, handle3));
                if (false || (uint)handle3 - (uint)dc >= 0U)
                {
                    x130e0425ae2d4496.DeleteObject(new HandleRef(null, handle2));
                    x130e0425ae2d4496.ReleaseDC(new HandleRef(control, handle1), new HandleRef(null, dc));
                }
            }
        }

        private static IntPtr xf7ba50da2798338e()
        {
            short[] lpvBits = new short[8];
            for (int i = 0; i < 8; ++i)
                lpvBits[i] = (short)(21845 << (i & 1)); 
            IntPtr bitmap = x130e0425ae2d4496.CreateBitmap(8, 8, 1, 1, lpvBits);
            x130e0425ae2d4496.x78c6fa48e5c2be9b lb = new x130e0425ae2d4496.x78c6fa48e5c2be9b();
            IntPtr brushIndirect;
            lb.x1e592a1c6402f4a1 = ColorTranslator.ToWin32(Color.Black);
            lb.x7cedc2a7cb7ec88d = 3;
            lb.x7d12b02569342309 = bitmap;
            brushIndirect = x130e0425ae2d4496.CreateBrushIndirect(lb);
            x130e0425ae2d4496.DeleteObject(new HandleRef(null, bitmap));
            return brushIndirect;

//            Image image = Image.FromFile("bitmap file path");
//            TextureBrush textureBrush = new TextureBrush(image);
//            return new TextureBrush(image);
//            return IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        private class x78c6fa48e5c2be9b
        {
            public int x7cedc2a7cb7ec88d;
            public int x1e592a1c6402f4a1;
            public IntPtr x7d12b02569342309;
        }
    }
}
