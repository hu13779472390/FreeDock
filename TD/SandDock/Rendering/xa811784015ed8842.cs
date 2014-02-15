using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FQ.FreeDock;

namespace FQ.FreeDock.Rendering
{
    internal class xa811784015ed8842
    {
        internal static void x91433b5e99eb7cac(Graphics x41347a961b838962, Color x6c50a99faab7d741)
        {
            try
            {
                x41347a961b838962.Clear(x6c50a99faab7d741);
            }
            catch
            {
            }
        }

        public static void xf8aac789a7846004(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Rectangle x0bd0d09521a6c8ef, Image xe058541ca798c059, System.Drawing.Size x95dac044246123ac, string xb41faee6912a2313, Font x26094932cf7a9139, Color x477e9d1180ece053, Color x3421b2dea6733873, Brush x4fe4e32776bbc2b0, Color xa1359fb73f86c7a4, Color xfca0e3085d5a7f42, Color x228f9881a1be0e5d, bool x9f93ebd2ca5601a2, int x6843d1739e949b3a, int xbd5e294caed74c4d, TextFormatFlags xae3b2752a89e7464, bool xb0f87b71823b1d4e)
        {
            if (xda73fcb97c77d998.Width <= 0 || xda73fcb97c77d998.Height <= 0)
                return;
            Rectangle rectangle;
            do
            {
                using (Pen pen = new Pen(xa1359fb73f86c7a4))
                {
                    x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 2, xda73fcb97c77d998.Left + 1, xda73fcb97c77d998.Bottom - 2);
                    x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + 1, xda73fcb97c77d998.Bottom - 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 2);
                    x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 2, xda73fcb97c77d998.Top + 2);
                    if ((uint)xbd5e294caed74c4d >= 0U)
                    {
                        x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a - 1, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Left + x6843d1739e949b3a, xda73fcb97c77d998.Top + 1);
                        do
                        {
                            x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top);
                            x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top + 2);
                            x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 2);
                        }
                        while (((xb0f87b71823b1d4e ? 1 : 0) & 0) != 0);
                    }
                }
                using (Pen pen = new Pen(xfca0e3085d5a7f42))
                {
                    x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom - 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 3);
                    x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 3, xda73fcb97c77d998.Left + x6843d1739e949b3a - 2, xda73fcb97c77d998.Top + 3);
                    x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a - 1, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Left + x6843d1739e949b3a, xda73fcb97c77d998.Top + 2);
                    x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Right - 4, xda73fcb97c77d998.Top + 1);
                }
                using (Pen pen = new Pen(x228f9881a1be0e5d))
                {
                    x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2);
                    x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom - 2);
                }
                System.Drawing.Point[] points = new System.Drawing.Point[5];
                points[0] = new System.Drawing.Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom - 1);
                points[1] = new System.Drawing.Point(xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 4);
                if (0 != 0)
                    goto label_8;
                else
                    goto label_29;
                label_1:
                if (xb0f87b71823b1d4e)
                {
                    rectangle = xda73fcb97c77d998;
                    rectangle.Inflate(-2, -2);
                    rectangle.Height += 2;
                    if ((uint)xb0f87b71823b1d4e + (uint)x6843d1739e949b3a >= 0U)
                        continue;
                    else if ((uint)xbd5e294caed74c4d >= 0U)
                        goto label_1;
                }
                else
                    goto label_40;
                label_7:
                xae3b2752a89e7464 |= TextFormatFlags.HorizontalCenter;
                xae3b2752a89e7464 &= ~TextFormatFlags.Default;
                label_8:
                TextRenderer.DrawText((IDeviceContext)x41347a961b838962, xb41faee6912a2313, x26094932cf7a9139, xda73fcb97c77d998, SystemColors.ControlText, xae3b2752a89e7464);
                goto label_1;
                label_29:
                points[2] = new System.Drawing.Point(xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top + 2);
                do
                {
                    points[3] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2);
                    points[4] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom - 1);
                    using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(xda73fcb97c77d998, x477e9d1180ece053, x3421b2dea6733873, LinearGradientMode.Vertical))
                        x41347a961b838962.FillPolygon((Brush)linearGradientBrush, points);
                    if (x9f93ebd2ca5601a2)
                        goto label_23;
                    label_16:
                    xda73fcb97c77d998 = x0bd0d09521a6c8ef;
                    if ((uint)x6843d1739e949b3a + (uint)x9f93ebd2ca5601a2 >= 0U)
                    {
                        xda73fcb97c77d998.X += xbd5e294caed74c4d;
                        xda73fcb97c77d998.Width -= xbd5e294caed74c4d;
                        continue;
                    }
                    else
                        break;
                    label_23:
                    if ((uint)x9f93ebd2ca5601a2 + (uint)xb0f87b71823b1d4e <= uint.MaxValue)
                    {
                        using (Pen pen = new Pen(x3421b2dea6733873))
                        {
                            x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1);
                            goto label_16;
                        }
                    }
                    else
                        goto label_4;
                }
                while (15 == 0);
                do
                {
                    if (xe058541ca798c059 != null)
                        goto label_11;
                    else
                        goto label_13;
                    label_9:
                    if (xda73fcb97c77d998.Width > 8)
                        continue;
                    else
                        goto label_1;
                    label_11:
                    x41347a961b838962.DrawImage(xe058541ca798c059, xda73fcb97c77d998.X + 4, xda73fcb97c77d998.Y + 2, x95dac044246123ac.Width, x95dac044246123ac.Height);
                    xda73fcb97c77d998.X += x95dac044246123ac.Width + 4;
                    xda73fcb97c77d998.Width -= x95dac044246123ac.Width + 4;
                    goto label_9;
                    label_13:
                    if ((uint)x6843d1739e949b3a - (uint)xbd5e294caed74c4d >= 0U)
                        goto label_9;
                    else
                        break;
                }
                while ((uint)xb0f87b71823b1d4e > uint.MaxValue);
                if (-2 != 0)
                    goto label_7;
                else
                    goto label_49;
            }
            while ((uint)xbd5e294caed74c4d > uint.MaxValue);
            goto label_3;
            label_40:
            return;
            label_3:
            ++rectangle.X;
            --rectangle.Width;
            label_4:
            ControlPaint.DrawFocusRectangle(x41347a961b838962, rectangle);
            return;
            label_49:
            ;
        }

        public static System.Drawing.Size xcdfce0e0f2641503(Graphics x41347a961b838962, Image xe058541ca798c059, System.Drawing.Size x95dac044246123ac, string xb41faee6912a2313, Font x26094932cf7a9139, TextFormatFlags xae3b2752a89e7464)
        {
            TextFormatFlags flags = xae3b2752a89e7464;
            return new System.Drawing.Size(TextRenderer.MeasureText((IDeviceContext)x41347a961b838962, xb41faee6912a2313, x26094932cf7a9139, new System.Drawing.Size(int.MaxValue, int.MaxValue), flags).Width + 3 + 6 + (x95dac044246123ac.Width + 4), x95dac044246123ac.Height);
        }

        public static void x272eca3f5ebfa9fc(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Image xe058541ca798c059, System.Drawing.Size x95dac044246123ac, string xb41faee6912a2313, Font x26094932cf7a9139, Color x477e9d1180ece053, Color x3421b2dea6733873, Color x93532ca0ace0c1ae, Color xa1359fb73f86c7a4, DrawItemState x01b557925841ae51, TextFormatFlags xae3b2752a89e7464)
        {
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(xda73fcb97c77d998, x477e9d1180ece053, x3421b2dea6733873, LinearGradientMode.Vertical))
                xa811784015ed8842.x272eca3f5ebfa9fc(x41347a961b838962, xda73fcb97c77d998, xe058541ca798c059, x95dac044246123ac, xb41faee6912a2313, x26094932cf7a9139, (Brush)linearGradientBrush, x93532ca0ace0c1ae, xa1359fb73f86c7a4, x01b557925841ae51, xae3b2752a89e7464);
        }

        public static void x272eca3f5ebfa9fc(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Image xe058541ca798c059, System.Drawing.Size x95dac044246123ac, string xb41faee6912a2313, Font x26094932cf7a9139, Brush x6f967439eb9e4ffb, Color x93532ca0ace0c1ae, Color xa1359fb73f86c7a4, DrawItemState x01b557925841ae51, TextFormatFlags xae3b2752a89e7464)
        {
            if ((x01b557925841ae51 & DrawItemState.Selected) == DrawItemState.Selected)
                goto label_19;
            label_11:
            xda73fcb97c77d998.Inflate(-3, 0);
            if (1 == 0 || xda73fcb97c77d998.Width >= x95dac044246123ac.Width + 4)
                goto label_12;
            label_3:
            if (xda73fcb97c77d998.Width < 8)
            {
                if (0 == 0)
                    return;
                if (0 != 0)
                    goto label_13;
            }
            --xda73fcb97c77d998.Y;
            if (4 != 0)
            {
                xae3b2752a89e7464 = xae3b2752a89e7464;
                xae3b2752a89e7464 &= ~TextFormatFlags.HorizontalCenter;
            }
            TextRenderer.DrawText((IDeviceContext)x41347a961b838962, xb41faee6912a2313, x26094932cf7a9139, xda73fcb97c77d998, x93532ca0ace0c1ae, xae3b2752a89e7464);
            if (int.MinValue != 0)
                return;
            else
                goto label_14;
            label_12:
            x41347a961b838962.DrawImage(xe058541ca798c059, new Rectangle(xda73fcb97c77d998.X + 1, xda73fcb97c77d998.Y + 2, x95dac044246123ac.Width, x95dac044246123ac.Height));
            xda73fcb97c77d998.X += x95dac044246123ac.Width + 4;
            xda73fcb97c77d998.Width -= x95dac044246123ac.Width + 4;
            goto label_3;
            label_13:
            System.Drawing.Point[] points;
            points[3] = new System.Drawing.Point(xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Bottom - 1);
            points[4] = new System.Drawing.Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 3);
            points[5] = new System.Drawing.Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
            using (Pen pen = new Pen(xa1359fb73f86c7a4))
            {
                x41347a961b838962.DrawLines(pen, points);
                goto label_11;
            }
            label_14:
            points[2] = new System.Drawing.Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom - 1);
            if (4 != 0)
                goto label_13;
            label_15:
            Rectangle rect;
            if (1 != 0)
                rect.Inflate(-1, 0);
            --rect.Height;
            x41347a961b838962.FillRectangle(x6f967439eb9e4ffb, rect);
            points = new System.Drawing.Point[6];
            points[0] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top);
            points[1] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 3);
            goto label_14;
            label_19:
            rect = xda73fcb97c77d998;
            goto label_15;
        }

        public static void x36c79cea8e98cf3c(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DockSide xf33779c598cac695, Image xe058541ca798c059, string xb41faee6912a2313, Font x26094932cf7a9139, Brush x4fe4e32776bbc2b0, Color xa1359fb73f86c7a4, bool x96c7dce50f0f3286)
        {
            xa811784015ed8842.x36c79cea8e98cf3c(x41347a961b838962, xda73fcb97c77d998, xf33779c598cac695, xe058541ca798c059, xb41faee6912a2313, x26094932cf7a9139, (Brush)null, x4fe4e32776bbc2b0, xa1359fb73f86c7a4, x96c7dce50f0f3286);
        }

        public static void x36c79cea8e98cf3c(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DockSide xf33779c598cac695, Image xe058541ca798c059, string xb41faee6912a2313, Font x26094932cf7a9139, Brush x6f967439eb9e4ffb, Brush x4fe4e32776bbc2b0, Color xa1359fb73f86c7a4, bool x96c7dce50f0f3286)
        {
            bool flag = false;
            label_46:
            System.Drawing.Point[] points = new System.Drawing.Point[6];
            DockSide dockSide = xf33779c598cac695;
            int num1;
            if ((uint)flag + (uint)num1 > uint.MaxValue)
                goto label_28;
            else
                goto label_45;
            label_18:
            do
            {
                if (x6f967439eb9e4ffb != null)
                    x41347a961b838962.FillPolygon(x6f967439eb9e4ffb, points);
                using (Pen pen = new Pen(xa1359fb73f86c7a4))
                    x41347a961b838962.DrawPolygon(pen, points);
                xda73fcb97c77d998.Inflate(-2, -2);
                if ((uint)num1 <= uint.MaxValue)
                    goto label_16;
            }
            while ((uint)num1 - (uint)x96c7dce50f0f3286 < 0U);
            goto label_26;
            label_16:
            do
            {
                if (!flag)
                    goto label_13;
                else
                    goto label_12;
                label_11:
                x41347a961b838962.DrawImage(xe058541ca798c059, new Rectangle(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xe058541ca798c059.Width, xe058541ca798c059.Height));
                if (0 == 0)
                {
                    if (xb41faee6912a2313.Length != 0)
                        goto label_8;
                    else
                        goto label_47;
                }
                else if ((num1 & 0) == 0)
                    goto label_8;
                label_7:
                int num2 = 23;
                goto label_10;
                label_8:
                if (x96c7dce50f0f3286)
                    num2 = 21;
                else
                    goto label_7;
                label_10:
                num1 = num2;
                if (flag)
                {
                    if (((x96c7dce50f0f3286 ? 1 : 0) | int.MinValue) != 0)
                    {
                        if ((uint)num1 - (uint)num1 <= uint.MaxValue)
                        {
                            if ((uint)num1 + (uint)num1 <= uint.MaxValue)
                            {
                                xda73fcb97c77d998.Offset(0, num1);
                                x41347a961b838962.DrawString(xb41faee6912a2313, x26094932cf7a9139, x4fe4e32776bbc2b0, (RectangleF)xda73fcb97c77d998, EverettRenderer.xc351c68a86733972);
                            }
                            else
                                goto label_42;
                        }
                        else
                            goto label_36;
                    }
                    continue;
                }
                else
                    goto label_1;
                label_12:
                xda73fcb97c77d998.Offset(0, 1);
                goto label_11;
                label_13:
                xda73fcb97c77d998.Offset(1, 0);
                goto label_11;
            }
            while ((uint)num1 > uint.MaxValue);
            goto label_48;
            label_1:
            xda73fcb97c77d998.Offset(num1, 0);
            x41347a961b838962.DrawString(xb41faee6912a2313, x26094932cf7a9139, x4fe4e32776bbc2b0, (RectangleF)xda73fcb97c77d998, EverettRenderer.x27e1c82c97265861);
            return;
            label_47:
            return;
            label_48:
            return;
            label_26:
            points[3] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Bottom);
            if ((num1 & 0) != 0)
                return;
            points[4] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom);
            points[5] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top + 2);
            label_28:
            if ((uint)x96c7dce50f0f3286 + (uint)x96c7dce50f0f3286 <= uint.MaxValue)
            {
                if ((uint)flag <= uint.MaxValue)
                    goto label_18;
            }
            else
                goto label_35;
            label_33:
            points[2] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Bottom - 2);
            points[3] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom);
            if ((uint)num1 + (uint)flag <= uint.MaxValue)
            {
                points[4] = new System.Drawing.Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom);
                points[5] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 2);
                goto label_18;
            }
            else
                goto label_18;
            label_35:
            points[4] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 2);
            label_36:
            points[5] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top + 2);
            flag = true;
            if ((uint)x96c7dce50f0f3286 + (uint)x96c7dce50f0f3286 >= 0U)
                goto label_39;
            label_37:
            points[5] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom);
            flag = true;
            goto label_18;
            label_39:
            if (((flag ? 1 : 0) & 0) == 0)
                goto label_18;
            else
                goto label_46;
            label_42:
            if (0 == 0)
                points[2] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Top + 2);
            points[3] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Bottom - 2);
            if (2 != 0)
            {
                points[4] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom);
                goto label_37;
            }
            label_45:
            switch (dockSide)
            {
                case DockSide.Top:
                    points[0] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top);
                    points[1] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Top);
                    goto label_33;
                case DockSide.Bottom:
                    points[0] = new System.Drawing.Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Top);
                    points[1] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top);
                    points[2] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Top + 2);
                    goto label_26;
                case DockSide.Left:
                    points[0] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top);
                    points[1] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top);
                    goto label_42;
                case DockSide.Right:
                    points[0] = new System.Drawing.Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Top);
                    points[1] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Top);
                    if ((uint)flag + (uint)num1 >= 0U)
                    {
                        points[2] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Bottom);
                        points[3] = new System.Drawing.Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom);
                        goto label_35;
                    }
                    else
                        goto label_39;
                default:
                    goto label_18;
            }
        }
    }
}
