using System.Drawing;

namespace FQ.FreeDock
{
    class x9b2777bb8e78938b
    {
        private x9b2777bb8e78938b()
        {
        }

        public static void xeac2e7eb44dff86e(Graphics graphics, Rectangle rect, Pen pen)
        {
            int num1 = rect.Width / 4;
            int num2 = 1;
            int x1;
            do
            {
                if (num2 > num1)
                {
                    return;
                }
                int num3 = (num1 - num2) * 2;
                x1 = rect.Left + rect.Width / 2 - (num1 - num2);
                int num4 = rect.Top + rect.Height / 2 + (num2 - 1);
                graphics.DrawLine(pen, x1, num4, x1 + num3 + 1, num4);

                ++num2;
            }
            while (true);

//            for (int i = 1; i < rect.Width / 4; i++)
//            {
//
//            }
        }

        public static void xd70a4c1a2378c84e(Graphics graphics, Rectangle rect, Color color, bool fill)
        {
            int num1 = rect.Left + rect.Width / 2;
            int num2 = rect.Top + rect.Height / 2;
            Point[] points = new Point[]
            {
                new Point(num1 + 2, num2 - 5),
                new Point(num1 - 2, num2 - 1),
                new Point(num1 + 2, num2 + 3)
            };

            x9b2777bb8e78938b.x31bdb6d312240ef9(graphics, points, color, fill);

        }

        public static void x793dc1a7cf4113f9(Graphics graphics, Rectangle rect, Color color, bool fill)
        {
            int num1 = rect.Left + rect.Width / 2;
            int num2 = rect.Top + rect.Height / 2;
            Point[] points = new Point[]
            {
                new Point(num1 - 2, num2 - 5),
                new Point(num1 + 2, num2 - 1),
                new Point(num1 - 2, num2 + 3)
            };

            x9b2777bb8e78938b.x31bdb6d312240ef9(graphics, points, color, fill);
        }

        private static void x31bdb6d312240ef9(Graphics graphics, Point[] points, Color color, bool fill)
        {
            if (fill)
            {
                using (SolidBrush brush = new SolidBrush(color))
                {
                    graphics.FillPolygon(brush, points);
                }
            }
            else
            {
                using (Pen pen = new Pen(color))
                {
                    graphics.DrawPolygon(pen, points);
                }
            }
        }

        // TODO: need reviews
        public static void x1477b5a75c8a8132(Graphics graphics, Rectangle rect, Pen pen, bool x533813ae5953a526)
        {
            int num1 = rect.Left + rect.Width / 2;
            int num2 = rect.Top + rect.Height / 2;

            if (x533813ae5953a526)
            {
                graphics.DrawLine(pen, num1 - 5, num2, num1 - 2, num2);
                graphics.DrawLine(pen, num1 - 2, num2 - 3, num1 - 2, num2 + 3);
                graphics.DrawLine(pen, num1 - 2, num2 - 2, num1 + 4, num2 - 2);
                graphics.DrawLine(pen, num1 - 2, num2 + 1, num1 + 4, num2 + 1);

                if ((uint)(x533813ae5953a526 ? 1 : 0) - (uint)num2 >= 0U)
                {
                    graphics.DrawLine(pen, num1 - 2, num2 + 2, num1 + 4, num2 + 2);
                    graphics.DrawLine(pen, num1 + 4, num2 - 2, num1 + 4, num2 + 2);
                }
            }

            graphics.DrawLine(pen, num1 - 3, num2 + 2, num1 + 3, num2 + 2);
            graphics.DrawLine(pen, num1 - 2, num2 - 3, num1 - 2, num2 + 2);
            graphics.DrawLine(pen, num1 - 2, num2 - 3, num1 + 2, num2 - 3);
            graphics.DrawLine(pen, num1 + 1, num2 - 3, num1 + 1, num2 + 2);
            graphics.DrawLine(pen, num1 + 2, num2 - 3, num1 + 2, num2 + 2);
            graphics.DrawLine(pen, num1, num2 + 2, num1, num2 + 5);
        }

        public static void xb176aa01ddab9f3e(Graphics graphics, Rectangle rect, Pen pen)
        {
            int num1 = rect.Left + rect.Width / 2 - 1;
            int num2 = rect.Top + rect.Height / 2;
            graphics.DrawLine(pen, num1 - 3, num2 - 4, num1 + 3, num2 + 2);
            graphics.DrawLine(pen, num1 - 2, num2 - 4, num1 + 4, num2 + 2);
            graphics.DrawLine(pen, num1 - 3, num2 + 2, num1 + 3, num2 - 4);
            graphics.DrawLine(pen, num1 - 2, num2 + 2, num1 + 4, num2 - 4);
        }

        public static void x26f0f0028ef01fa5(Graphics graphics, Rectangle rect, Pen pen)
        {
            int num1 = rect.Left + rect.Width / 2 - 1;
            int num2 = rect.Top + rect.Height / 2;
            graphics.DrawLine(pen, num1 - 3, num2 - 3, num1 + 4, num2 + 4);
            graphics.DrawLine(pen, num1 - 2, num2 - 3, num1 + 4, num2 + 3);
            graphics.DrawLine(pen, num1 - 3, num2 - 2, num1 + 3, num2 + 4);
            graphics.DrawLine(pen, num1 + 4, num2 - 3, num1 - 3, num2 + 4);
            graphics.DrawLine(pen, num1 + 3, num2 - 3, num1 - 3, num2 + 3);
            graphics.DrawLine(pen, num1 + 4, num2 - 2, num1 - 2, num2 + 4);
        }
    }
}
