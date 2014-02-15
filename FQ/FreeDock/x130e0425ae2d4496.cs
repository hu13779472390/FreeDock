using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    internal class x130e0425ae2d4496
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

        public static void xda2defffc25953e0(Control xd9927c905e42526c, Rectangle xa688a683bf2cfced, bool xc346f54d9968657b, int x189455fe88a3b711)
        {
            x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Y, xa688a683bf2cfced.Width, 4));
            if (!xc346f54d9968657b)
            {
                if (0 == 0)
                {


                    x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Y + 4, 4, xa688a683bf2cfced.Height - 8));
                    x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.Right - 4, xa688a683bf2cfced.Y + 4, 4, xa688a683bf2cfced.Height - 8));
                    x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Bottom - 4, xa688a683bf2cfced.Width, 4));
                    return;
                }
            }
            else
                goto label_7;
            label_3:
            x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X + 80, xa688a683bf2cfced.Bottom - x189455fe88a3b711, xa688a683bf2cfced.Width - 80, 4));
            label_4:
            x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X + 10, xa688a683bf2cfced.Bottom - 4, 70, 4));
            x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X + 10, xa688a683bf2cfced.Bottom - x189455fe88a3b711, 4, x189455fe88a3b711 - 4));
            x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X + 76, xa688a683bf2cfced.Bottom - x189455fe88a3b711, 4, x189455fe88a3b711 - 4));
            return;
            label_7:
            x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Y + 4, 4, xa688a683bf2cfced.Height - 4 - x189455fe88a3b711));
            x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.Right - 4, xa688a683bf2cfced.Y + 4, 4, xa688a683bf2cfced.Height - 4 - x189455fe88a3b711));
            x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Bottom - x189455fe88a3b711, 10, 4));


            if (0 == 0)
                goto label_3;


        }

        public static void xe5e0d1644c72aafd(Control xd9927c905e42526c, Rectangle xa688a683bf2cfced)
        {
            IntPtr num = IntPtr.Zero;
            while (!(xa688a683bf2cfced == Rectangle.Empty))
            {
                IntPtr handle1 = xd9927c905e42526c != null ? xd9927c905e42526c.Handle : IntPtr.Zero;
                IntPtr dc = x130e0425ae2d4496.GetDC(new HandleRef((object)xd9927c905e42526c, handle1));
                IntPtr handle2 = x130e0425ae2d4496.xf7ba50da2798338e();
                IntPtr handle3 = x130e0425ae2d4496.SelectObject(new HandleRef((object)xd9927c905e42526c, dc), new HandleRef((object)null, handle2));
                x130e0425ae2d4496.PatBlt(new HandleRef((object)xd9927c905e42526c, dc), xa688a683bf2cfced.X, xa688a683bf2cfced.Y, xa688a683bf2cfced.Width, xa688a683bf2cfced.Height, 5898313);
                x130e0425ae2d4496.SelectObject(new HandleRef((object)xd9927c905e42526c, dc), new HandleRef((object)null, handle3));
                if ((uint)handle1 > uint.MaxValue || (uint)handle3 - (uint)dc >= 0U)
                {
                    x130e0425ae2d4496.DeleteObject(new HandleRef((object)null, handle2));
                    x130e0425ae2d4496.ReleaseDC(new HandleRef((object)xd9927c905e42526c, handle1), new HandleRef((object)null, dc));
                    break;
                }
                else if (-2 == 0)
                    ;
            }
        }

        private static IntPtr xf7ba50da2798338e()
        {
            short[] lpvBits = new short[8];
            label_7:
            int index;
            for (index = 0; index < 8; ++index)
                lpvBits[index] = (short)(21845 << (index & 1));
            IntPtr bitmap = x130e0425ae2d4496.CreateBitmap(8, 8, 1, 1, lpvBits);
            x130e0425ae2d4496.x78c6fa48e5c2be9b lb = new x130e0425ae2d4496.x78c6fa48e5c2be9b();
            IntPtr brushIndirect;
            do
            {
                lb.x1e592a1c6402f4a1 = ColorTranslator.ToWin32(Color.Black);
                lb.x7cedc2a7cb7ec88d = 3;
                lb.x7d12b02569342309 = bitmap;
                brushIndirect = x130e0425ae2d4496.CreateBrushIndirect(lb);
                if ((uint)index + (uint)bitmap > uint.MaxValue)
                    ;
                if ((uint)bitmap + (uint)index <= uint.MaxValue)
                    x130e0425ae2d4496.DeleteObject(new HandleRef((object)null, bitmap));
                else
                    goto label_7;
            }
            while ((int)byte.MaxValue == 0);
            return brushIndirect;
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
