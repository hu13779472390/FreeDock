using System.Drawing;

namespace FQ.FreeDock
{
    internal class x9b2777bb8e78938b
    {
        private x9b2777bb8e78938b()
        {
        }

        public static void xeac2e7eb44dff86e(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Pen x90279591611601bc)
        {
            int num1 = xda73fcb97c77d998.Width / 4;
            int num2 = 1;
            int x1;
            do
            {
                if (num2 > num1)
                {
                    if (-1 != 0)
                    {
                        if ((uint)num1 <= uint.MaxValue)
                            goto label_6;
                    }
                    else
                        goto label_5;
                }
                int num3 = (num1 - num2) * 2;
                x1 = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2 - (num1 - num2);
                int num4 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2 + (num2 - 1);
                x41347a961b838962.DrawLine(x90279591611601bc, x1, num4, x1 + num3 + 1, num4);
                label_5:
                ++num2;
            }
            while ((x1 | 1) != 0);
            goto label_7;
            label_6:
            return;
            label_7:
            ;
        }

        public static void xd70a4c1a2378c84e(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Color x6c50a99faab7d741, bool x2fef7d841879a711)
        {
            int num1 = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2;
            int num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
            System.Drawing.Point[] x6fa2570084b2ad39 = new System.Drawing.Point[3]
            {
                new System.Drawing.Point(num1 + 2, num2 - 5),
                new System.Drawing.Point(num1 - 2, num2 - 1),
                new System.Drawing.Point(num1 + 2, num2 + 3)
            };
            do
            {
                x9b2777bb8e78938b.x31bdb6d312240ef9(x41347a961b838962, x6fa2570084b2ad39, x6c50a99faab7d741, x2fef7d841879a711);
            }
            while ((uint)num2 > uint.MaxValue);
        }

        public static void x793dc1a7cf4113f9(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Color x6c50a99faab7d741, bool x2fef7d841879a711)
        {
            int num1 = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2;
            int num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
            System.Drawing.Point[] x6fa2570084b2ad39 = new System.Drawing.Point[3];
            if ((uint)x2fef7d841879a711 <= uint.MaxValue)
                x6fa2570084b2ad39[0] = new System.Drawing.Point(num1 - 2, num2 - 5);
            x6fa2570084b2ad39[1] = new System.Drawing.Point(num1 + 2, num2 - 1);
            x6fa2570084b2ad39[2] = new System.Drawing.Point(num1 - 2, num2 + 3);
            x9b2777bb8e78938b.x31bdb6d312240ef9(x41347a961b838962, x6fa2570084b2ad39, x6c50a99faab7d741, x2fef7d841879a711);
        }

        private static void x31bdb6d312240ef9(Graphics x41347a961b838962, System.Drawing.Point[] x6fa2570084b2ad39, Color x6c50a99faab7d741, bool x2fef7d841879a711)
        {
            if (x2fef7d841879a711)
            {
                using (SolidBrush solidBrush = new SolidBrush(x6c50a99faab7d741))
                    x41347a961b838962.FillPolygon((Brush)solidBrush, x6fa2570084b2ad39);
            }
            else
            {
                using (Pen pen = new Pen(x6c50a99faab7d741))
                    x41347a961b838962.DrawPolygon(pen, x6fa2570084b2ad39);
            }
        }

        public static void x1477b5a75c8a8132(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Pen x90279591611601bc, bool x533813ae5953a526)
        {
            int num1 = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2;
            int num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
            if (x533813ae5953a526)
                goto label_5;
            label_2:
            x41347a961b838962.DrawLine(x90279591611601bc, num1 - 3, num2 + 2, num1 + 3, num2 + 2);
            x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 - 3, num1 - 2, num2 + 2);
            x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 - 3, num1 + 2, num2 - 3);
            x41347a961b838962.DrawLine(x90279591611601bc, num1 + 1, num2 - 3, num1 + 1, num2 + 2);
            if (((x533813ae5953a526 ? 1 : 0) | 3) == 0)
                return;
            x41347a961b838962.DrawLine(x90279591611601bc, num1 + 2, num2 - 3, num1 + 2, num2 + 2);
            x41347a961b838962.DrawLine(x90279591611601bc, num1, num2 + 2, num1, num2 + 5);
            return;
            label_5:
            x41347a961b838962.DrawLine(x90279591611601bc, num1 - 5, num2, num1 - 2, num2);
            x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 - 3, num1 - 2, num2 + 3);
            x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 - 2, num1 + 4, num2 - 2);
            x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 + 1, num1 + 4, num2 + 1);
            if ((uint)x533813ae5953a526 - (uint)num2 >= 0U)
            {
                x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 + 2, num1 + 4, num2 + 2);
                if ((uint)x533813ae5953a526 >= 0U)
                    x41347a961b838962.DrawLine(x90279591611601bc, num1 + 4, num2 - 2, num1 + 4, num2 + 2);
                else
                    goto label_2;
            }
            else
                goto label_2;
        }

        public static void xb176aa01ddab9f3e(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Pen x90279591611601bc)
        {
            int num1 = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2 - 1;
            int num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
            x41347a961b838962.DrawLine(x90279591611601bc, num1 - 3, num2 - 4, num1 + 3, num2 + 2);
            x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 - 4, num1 + 4, num2 + 2);
            x41347a961b838962.DrawLine(x90279591611601bc, num1 - 3, num2 + 2, num1 + 3, num2 - 4);
            if ((uint)num1 - (uint)num1 > uint.MaxValue)
                return;
            x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 + 2, num1 + 4, num2 - 4);
        }

        public static void x26f0f0028ef01fa5(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Pen x90279591611601bc)
        {
            int num1 = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2 - 1;
            int num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
            if (8 != 0)
            {
                x41347a961b838962.DrawLine(x90279591611601bc, num1 - 3, num2 - 3, num1 + 4, num2 + 4);
                x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 - 3, num1 + 4, num2 + 3);
                x41347a961b838962.DrawLine(x90279591611601bc, num1 - 3, num2 - 2, num1 + 3, num2 + 4);
            }
            x41347a961b838962.DrawLine(x90279591611601bc, num1 + 4, num2 - 3, num1 - 3, num2 + 4);
            x41347a961b838962.DrawLine(x90279591611601bc, num1 + 3, num2 - 3, num1 - 3, num2 + 3);
            x41347a961b838962.DrawLine(x90279591611601bc, num1 + 4, num2 - 2, num1 - 2, num2 + 4);
        }
    }
}
