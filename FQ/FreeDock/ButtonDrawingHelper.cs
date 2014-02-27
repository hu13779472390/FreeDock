using System.Drawing;

namespace FQ.FreeDock
{
    // J
    class ButtonDrawingHelper
    {
        // reviewed with 2.4
        public static void DrawActiveFiles(Graphics graphics, Rectangle rect, Pen pen)
        {
            int num1 = rect.Width / 4;
            for (int i = 1; i <= num1; ++i)
            {
                int num2 = (num1 - i) * 2;
                int x1 = rect.Left + rect.Width / 2 - (num1 - i);
                int num3 = rect.Top + rect.Height / 2 + (i - 1);
                graphics.DrawLine(pen, x1, num3, x1 + num2 + 1, num3);
            }
        }
        // reviewed with 2.4
        public static void DrawScrollLeft(Graphics graphics, Rectangle rect, Color color, bool fill)
        {
            int num1 = rect.Left + rect.Width / 2;
            int num2 = rect.Top + rect.Height / 2;
            Point[] points = new Point[]
            {
                new Point(num1 + 2, num2 - 5),
                new Point(num1 - 2, num2 - 1),
                new Point(num1 + 2, num2 + 3)
            };
            ButtonDrawingHelper.DrawPolyline(graphics, points, color, fill);

        }
        // reviewed with 2.4
        public static void DrawScrollRight(Graphics graphics, Rectangle rect, Color color, bool fill)
        {
            int num1 = rect.Left + rect.Width / 2;
            int num2 = rect.Top + rect.Height / 2;
            Point[] points = new Point[]
            {
                new Point(num1 - 2, num2 - 5),
                new Point(num1 + 2, num2 - 1),
                new Point(num1 - 2, num2 + 3)
            };
            ButtonDrawingHelper.DrawPolyline(graphics, points, color, fill);
        }
        // reviewed with 2.4
        private static void DrawPolyline(Graphics graphics, Point[] points, Color color, bool fill)
        {
            if (fill)
            {
                using (SolidBrush brush = new SolidBrush(color))
                    graphics.FillPolygon(brush, points);
            }
            else
            {
                using (Pen pen = new Pen(color))
                    graphics.DrawPolygon(pen, points);
            }
        }
        // reviewed with 2.4
        public static void DrawPinButton(Graphics graphics, Rectangle rect, Pen pen, bool x533813ae5953a526)
        {
            int num1 = rect.Left + rect.Width / 2;
            int num2 = rect.Top + rect.Height / 2;
            if (x533813ae5953a526)
            {
                graphics.DrawLine(pen, num1 - 5, num2, num1 - 2, num2);
                graphics.DrawLine(pen, num1 - 2, num2 - 3, num1 - 2, num2 + 3);
                graphics.DrawLine(pen, num1 - 2, num2 - 2, num1 + 4, num2 - 2);
                graphics.DrawLine(pen, num1 - 2, num2 + 1, num1 + 4, num2 + 1);
                graphics.DrawLine(pen, num1 - 2, num2 + 2, num1 + 4, num2 + 2);
                graphics.DrawLine(pen, num1 + 4, num2 - 2, num1 + 4, num2 + 2);
            }
            else
            {
                graphics.DrawLine(pen, num1 - 3, num2 + 2, num1 + 3, num2 + 2);
                graphics.DrawLine(pen, num1 - 2, num2 - 3, num1 - 2, num2 + 2);
                graphics.DrawLine(pen, num1 - 2, num2 - 3, num1 + 2, num2 - 3);
                graphics.DrawLine(pen, num1 + 1, num2 - 3, num1 + 1, num2 + 2);
                graphics.DrawLine(pen, num1 + 2, num2 - 3, num1 + 2, num2 + 2);
                graphics.DrawLine(pen, num1, num2 + 2, num1, num2 + 5);
            }
        }

        // reviewed with 2.4
        public static void DrawPositionButton(Graphics g, Rectangle bounds, Pen pen)
        {
            int num1 = bounds.Left + bounds.Width / 2 - 1;
            int num2 = bounds.Top + bounds.Height / 2;
            g.DrawLine(pen, num1 - 3, num2 - 4, num1 + 3, num2 + 2);
            g.DrawLine(pen, num1 - 2, num2 - 4, num1 + 4, num2 + 2);
            g.DrawLine(pen, num1 - 3, num2 + 2, num1 + 3, num2 - 4);
            g.DrawLine(pen, num1 - 2, num2 + 2, num1 + 4, num2 - 4);
        }

        // reviewed with 2.4
        public static void DrawCloseButton(Graphics g, Rectangle bounds, Pen pen)
        {
            int num1 = bounds.Left + bounds.Width / 2 - 1;
            int num2 = bounds.Top + bounds.Height / 2;
            g.DrawLine(pen, num1 - 3, num2 - 3, num1 + 4, num2 + 4);
            g.DrawLine(pen, num1 - 2, num2 - 3, num1 + 4, num2 + 3);
            g.DrawLine(pen, num1 - 3, num2 - 2, num1 + 3, num2 + 4);
            g.DrawLine(pen, num1 + 4, num2 - 3, num1 - 3, num2 + 4);
            g.DrawLine(pen, num1 + 3, num2 - 3, num1 - 3, num2 + 3);
            g.DrawLine(pen, num1 + 4, num2 - 2, num1 - 2, num2 + 4);
        }
    }
}
