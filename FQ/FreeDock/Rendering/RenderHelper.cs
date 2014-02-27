using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FQ.FreeDock;

namespace FQ.FreeDock.Rendering
{
    class RenderHelper
    {
        internal static void ClearBackground(Graphics graphics, Color color)
        {
            graphics.Clear(color);
        }
        // reveiwed with 2.4
        public static void xf8aac789a7846004(Graphics graphics, Rectangle bounds, Rectangle x0bd0d09521a6c8ef, Image image, Size size, string text, Font font, Color x477e9d1180ece053, Color x3421b2dea6733873, Brush brush, Color xa1359fb73f86c7a4, Color xfca0e3085d5a7f42, Color x228f9881a1be0e5d, bool x9f93ebd2ca5601a2, int x6843d1739e949b3a, int xbd5e294caed74c4d, TextFormatFlags textFormat, bool xb0f87b71823b1d4e)
        {
            if (bounds.Width <= 0 || bounds.Height <= 0)
                return;

            using (Pen pen = new Pen(xa1359fb73f86c7a4))
            {
                graphics.DrawLine(pen, bounds.Left, bounds.Bottom - 2, bounds.Left + 1, bounds.Bottom - 2);
                graphics.DrawLine(pen, bounds.Left + 1, bounds.Bottom - 2, bounds.Left + x6843d1739e949b3a - 3, bounds.Top + 2);
                graphics.DrawLine(pen, bounds.Left + x6843d1739e949b3a - 3, bounds.Top + 2, bounds.Left + x6843d1739e949b3a - 2, bounds.Top + 2);
                graphics.DrawLine(pen, bounds.Left + x6843d1739e949b3a - 1, bounds.Top + 1, bounds.Left + x6843d1739e949b3a, bounds.Top + 1);
                graphics.DrawLine(pen, bounds.Left + x6843d1739e949b3a + 1, bounds.Top, bounds.Right - 3, bounds.Top);
                graphics.DrawLine(pen, bounds.Right - 3, bounds.Top, bounds.Right - 1, bounds.Top + 2);
            }

            using (Pen pen = new Pen(xfca0e3085d5a7f42))
            {
                graphics.DrawLine(pen, bounds.Left + 2, bounds.Bottom - 2, bounds.Left + x6843d1739e949b3a - 3, bounds.Top + 3);
                graphics.DrawLine(pen, bounds.Left + x6843d1739e949b3a - 3, bounds.Top + 3, bounds.Left + x6843d1739e949b3a - 2, bounds.Top + 3);
                graphics.DrawLine(pen, bounds.Left + x6843d1739e949b3a - 1, bounds.Top + 2, bounds.Left + x6843d1739e949b3a, bounds.Top + 2);
                graphics.DrawLine(pen, bounds.Left + x6843d1739e949b3a + 1, bounds.Top + 1, bounds.Right - 4, bounds.Top + 1);
            }

            using (Pen pen = new Pen(x228f9881a1be0e5d))
            {
                graphics.DrawLine(pen, bounds.Right - 3, bounds.Top + 1, bounds.Right - 2, bounds.Top + 2);
                graphics.DrawLine(pen, bounds.Right - 2, bounds.Top + 2, bounds.Right - 2, bounds.Bottom - 2);
            }

            Point[] points = new Point[]
            {
                new Point(bounds.Left + 2, bounds.Bottom - 1),
                new Point(bounds.Left + x6843d1739e949b3a - 3, bounds.Top + 4),
                new Point(bounds.Left + x6843d1739e949b3a + 1, bounds.Top + 2),
                new Point(bounds.Right - 2, bounds.Top + 2),
                new Point(bounds.Right - 2, bounds.Bottom - 1)
            };

            using (LinearGradientBrush brush1 = new LinearGradientBrush(bounds, x477e9d1180ece053, x3421b2dea6733873, LinearGradientMode.Vertical))
                graphics.FillPolygon(brush1, points);

            if (x9f93ebd2ca5601a2)
            {
                using (Pen pen = new Pen(x3421b2dea6733873))
                    graphics.DrawLine(pen, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
            }

            bounds = x0bd0d09521a6c8ef;
            bounds.X += xbd5e294caed74c4d;
            bounds.Width -= xbd5e294caed74c4d;
            if (image != null)
            {
                graphics.DrawImage(image, bounds.X + 4, bounds.Y + 2, size.Width, size.Height);
                bounds.X += size.Width + 4;
                bounds.Width -= size.Width + 4;
            }
  
            if (bounds.Width > 8)
            {
                textFormat |= TextFormatFlags.HorizontalCenter;
                textFormat &= ~TextFormatFlags.Default;
                TextRenderer.DrawText((IDeviceContext)graphics, text, font, bounds, SystemColors.ControlText, textFormat);
            }
                     
            if (!xb0f87b71823b1d4e)
                return;
              
            Rectangle rectangle = bounds;
            rectangle.Inflate(-2, -2);
            rectangle.Height += 2;
            ++rectangle.X;
            --rectangle.Width;
            ControlPaint.DrawFocusRectangle(graphics, rectangle);
        }

        public static Size xcdfce0e0f2641503(Graphics graphics, Image image, Size size, string text, Font font, TextFormatFlags xae3b2752a89e7464)
        {
            TextFormatFlags flags = xae3b2752a89e7464;
            return new Size(TextRenderer.MeasureText(graphics, text, font, new Size(int.MaxValue, int.MaxValue), flags).Width + 3 + 6 + (size.Width + 4), size.Height);
        }

        public static void x272eca3f5ebfa9fc(Graphics g, Rectangle bounds, Image image, Size size, string text, Font font, Color x477e9d1180ece053, Color x3421b2dea6733873, Color x93532ca0ace0c1ae, Color xa1359fb73f86c7a4, DrawItemState state, TextFormatFlags xae3b2752a89e7464)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(bounds, x477e9d1180ece053, x3421b2dea6733873, LinearGradientMode.Vertical))
                x272eca3f5ebfa9fc(g, bounds, image, size, text, font, brush, x93532ca0ace0c1ae, xa1359fb73f86c7a4, state, xae3b2752a89e7464);
        }
        // reviewed with 2.4
        public static void x272eca3f5ebfa9fc(Graphics g, Rectangle bounds, Image image, Size x95dac044246123ac, string text, Font font, Brush brush, Color x93532ca0ace0c1ae, Color xa1359fb73f86c7a4, DrawItemState state, TextFormatFlags textFormat)
        {
            if ((state & DrawItemState.Selected) == DrawItemState.Selected)
            {
                Rectangle rect = bounds;
                rect.Inflate(-1, 0);
                --rect.Height;
                g.FillRectangle(brush, rect);
                Point[] points = new Point[]
                {
                    new  Point(bounds.Left, bounds.Top),
                    new  Point(bounds.Left, bounds.Bottom - 3),
                    new  Point(bounds.Left + 2, bounds.Bottom - 1),
                    new  Point(bounds.Right - 3, bounds.Bottom - 1),
                    new  Point(bounds.Right - 1, bounds.Bottom - 3),
                    new  Point(bounds.Right - 1, bounds.Top)               
                };
                using (Pen pen = new Pen(xa1359fb73f86c7a4))
                    g.DrawLines(pen, points);
            }

            bounds.Inflate(-3, 0);
            if (bounds.Width >= x95dac044246123ac.Width + 4)
            {
                g.DrawImage(image, new Rectangle(bounds.X + 1, bounds.Y + 2, x95dac044246123ac.Width, x95dac044246123ac.Height));
                bounds.X += x95dac044246123ac.Width + 4;
                bounds.Width -= x95dac044246123ac.Width + 4;
            }
            if (bounds.Width < 8)
                return;
            --bounds.Y;
            textFormat &= ~TextFormatFlags.HorizontalCenter;
            TextRenderer.DrawText(g, text, font, bounds, x93532ca0ace0c1ae, textFormat);
        }

        public static void x36c79cea8e98cf3c(Graphics g, Rectangle bounds, DockSide dockSide, Image image, string text, Font font, Brush x4fe4e32776bbc2b0, Color color, bool x96c7dce50f0f3286)
        {
            x36c79cea8e98cf3c(g, bounds, dockSide, image, text, font, null, x4fe4e32776bbc2b0, color, x96c7dce50f0f3286);
        }

        // reviewed with 2.4
        public static void x36c79cea8e98cf3c(Graphics g, Rectangle bounds, DockSide dockSide, Image image, string text, Font font, Brush x6f967439eb9e4ffb, Brush x4fe4e32776bbc2b0, Color color, bool x96c7dce50f0f3286)
        {
            bool flag = false;
            Point[] points = new Point[6];
            switch (dockSide)
            {
                case DockSide.Top:
                    points[0] = new Point(bounds.Left, bounds.Top);
                    points[1] = new Point(bounds.Right, bounds.Top);
                    points[2] = new Point(bounds.Right, bounds.Bottom - 2);
                    points[3] = new Point(bounds.Right - 2, bounds.Bottom);
                    points[4] = new Point(bounds.Left + 2, bounds.Bottom);
                    points[5] = new Point(bounds.Left, bounds.Bottom - 2);
                    break;
                case DockSide.Bottom:
                    points[0] = new Point(bounds.Left + 2, bounds.Top);
                    points[1] = new Point(bounds.Right - 2, bounds.Top);
                    points[2] = new Point(bounds.Right, bounds.Top + 2);
                    points[3] = new Point(bounds.Right, bounds.Bottom);
                    points[4] = new Point(bounds.Left, bounds.Bottom);
                    points[5] = new Point(bounds.Left, bounds.Top + 2);
                    break;
                case DockSide.Left:
                    points[0] = new Point(bounds.Left, bounds.Top);
                    points[1] = new Point(bounds.Right - 2, bounds.Top);
                    points[2] = new Point(bounds.Right, bounds.Top + 2);
                    points[3] = new Point(bounds.Right, bounds.Bottom - 2);
                    points[4] = new Point(bounds.Right - 2, bounds.Bottom);
                    points[5] = new Point(bounds.Left, bounds.Bottom);
                    flag = true;
                    break;
                case DockSide.Right:
                    points[0] = new Point(bounds.Left + 2, bounds.Top);
                    points[1] = new Point(bounds.Right, bounds.Top);
                    points[2] = new Point(bounds.Right, bounds.Bottom);
                    points[3] = new Point(bounds.Left + 2, bounds.Bottom);
                    points[4] = new Point(bounds.Left, bounds.Bottom - 2);
                    points[5] = new Point(bounds.Left, bounds.Top + 2);
                    flag = true;
                    break;
            }

            if (x6f967439eb9e4ffb != null)
                g.FillPolygon(x6f967439eb9e4ffb, points);
            using (Pen pen = new Pen(color))
                g.DrawPolygon(pen, points);
            bounds.Inflate(-2, -2);
            if (!flag)
                bounds.Offset(1, 0);
            else
                bounds.Offset(0, 1);
            g.DrawImage(image, new Rectangle(bounds.Left, bounds.Top, image.Width, image.Height));
            if (text.Length == 0)
                return;
            int num2 = x96c7dce50f0f3286 ? 21 : 23;
            if (flag)
            {
                bounds.Offset(0, num2);
                g.DrawString(text, font, x4fe4e32776bbc2b0, (RectangleF)bounds, EverettRenderer.StandardVerticalStringFormat);
            }
            else
            {
                bounds.Offset(num2, 0);
                g.DrawString(text, font, x4fe4e32776bbc2b0, (RectangleF)bounds, EverettRenderer.StandardStringFormat);
            }
        }
    }
}
