using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using FQ.FreeDock;

namespace FQ.FreeDock.Rendering
{
    /// <summary>
    /// A renderer that gives a sleek silvery look to tab controls.
    /// 
    /// </summary>
    [TypeConverter(typeof(NoDefaultRenderConverter))]
    public class MilborneRenderer : ITabControlRenderer
    {
        private Color xd9caa88fffee2844 = Color.FromArgb(124, 124, 148);
        private Color x62b1822fa10e8658 = SystemColors.ControlLight;
        private Color x68e7227781326461 = Color.FromArgb(117, 116, 147);
        private Color x31d8d8063d8f3c74 = Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
        private Color x6cefc7bb40cf5d76 = Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
        private Color x05d7ee48911d8dba = Color.FromArgb(252, 252, 254);
        private Color x51e4f0f96f7fc653 = Color.FromArgb(244, 243, 248);
        private Color xb9bbdee8e645fa7b = Color.FromArgb(216, 216, 228);
        private Color xd96ec9f38c2f034d = Color.FromArgb(243, 242, 247);
        private Color x1b76e612db274a07 = Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
        private double tabColorBlend = 0.05;
        private TextFormatFlags textFormatFlags;
        private double pageColorBlend;

        /// <summary>
        /// Indicates how much of the BackColor of each TabPage will show through on its background.
        /// 
        /// </summary>
        public double PageColorBlend
        {
            get
            {
                return this.pageColorBlend;
            }
            set
            {
                if (value < 0.0 || value > 1.0)
                    throw new ArgumentException("Value must lie between 0 and 1.");
                this.pageColorBlend = value;
            }
        }

        /// <summary>
        /// Indicates how much of the BackColor of each TabPage will show through on their tabs.
        /// 
        /// </summary>
        public double TabColorBlend
        {
            get
            {
                return this.tabColorBlend;
            }
            set
            {
                if (value < 0.0 || value > 1.0)
                    throw new ArgumentException("Value must lie between 0 and 1.");
                this.tabColorBlend = value;
            }
        }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        public virtual bool ShouldDrawControlBorder
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        public int TabControlTabStripHeight
        {
            get
            {
                return Control.DefaultFont.Height + 8;
            }
        }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        public int TabControlTabExtra
        {
            get
            {
                return this.TabControlTabStripHeight - 7;
            }
        }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        public virtual Size TabControlPadding
        {
            get
            {
                return new Size(4, 4);
            }
        }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        public int TabControlTabHeight
        {
            get
            {
                return this.TabControlTabStripHeight;
            }
        }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        public bool ShouldDrawTabControlBackground
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override string ToString()
        {
            return "Milborne";
        }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        public virtual void DrawFakeTabControlBackgroundExtension(Graphics graphics, Rectangle bounds, Color backColor)
        {
            using (SolidBrush brush = new SolidBrush(this.xb9bbdee8e645fa7b))
                graphics.FillRectangle(brush, bounds);
            using (Pen pen = new Pen(this.x68e7227781326461))
                graphics.DrawLine(pen, bounds.Right - 1, bounds.Y, bounds.Right - 1, bounds.Bottom - 1);
        }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        public void DrawTabControlButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state)
        {
            if ((state & DrawItemState.Selected) == DrawItemState.Selected)
                bounds.Offset(1, 1);
            SandDockButtonType sandDockButtonType = buttonType;
            switch (sandDockButtonType)
            {
                case SandDockButtonType.ScrollLeft:
                    ButtonDrawingHelper.DrawScrollLeft(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
                    break;
                case SandDockButtonType.ScrollRight:
                    ButtonDrawingHelper.DrawScrollRight(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
                    break;
            }
        }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        public Size MeasureTabControlTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
        {
            int width;
            using (new Font(font, FontStyle.Bold))
                width = TextRenderer.MeasureText(graphics, text, font, new Size(int.MaxValue, int.MaxValue), this.textFormatFlags).Width;
            width += 24;
            if (image != null)
                width += image.Width + 4;
            return new Size(width + this.TabControlTabExtra, 0);
        }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        public void FinishRenderSession()
        {
        }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        // reviewed with 2.4
        public void StartRenderSession(HotkeyPrefix tabHotKeys)
        {
            this.textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.NoPadding;
            if (tabHotKeys == HotkeyPrefix.None)
            {
                this.textFormatFlags |= TextFormatFlags.NoPrefix;
            }
            else
            {
                if (tabHotKeys != HotkeyPrefix.Hide)
                    return;
                this.textFormatFlags |= TextFormatFlags.HidePrefix;
            }
        }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        public void DrawTabControlTabStripBackground(Graphics graphics, Rectangle bounds, Color backColor)
        {
            if (backColor != Color.Transparent)
                RenderHelper.ClearBackground(graphics, backColor);
            using (Pen pen = new Pen(this.x68e7227781326461))
                graphics.DrawLine(pen, bounds.X, bounds.Bottom - 1, bounds.Right - 2, bounds.Bottom - 1);
        }
        // reviewed with 2.4
        private Point[] x23c99552401d90a0(Rectangle bounds, bool xb35f79a43e184314)
        {
            int num = Math.Min(bounds.Width, bounds.Height);
            if (xb35f79a43e184314)
                return new Point[]
                {
                    new Point(bounds.X + 2, bounds.Bottom - 2),
                    new Point(bounds.X + num - 3, bounds.Y + 3),
                    new Point(bounds.X + num + 1, bounds.Y + 1),
                    new Point(bounds.Right - 4, bounds.Y + 1),
                    new Point(bounds.Right - 2, bounds.Y + 3),
                    new Point(bounds.Right - 2, bounds.Bottom - 2)
                };
            else
                return new Point[]
                {
                    new Point(bounds.X, bounds.Bottom - 1),
                    new Point(bounds.X + num - 4, bounds.Y + 3),
                    new Point(bounds.X + num + 1, bounds.Y),
                    new Point(bounds.Right - 4, bounds.Y),
                    new Point(bounds.Right - 1, bounds.Y + 3),
                    new Point(bounds.Right - 1, bounds.Bottom - 1)
                };
        }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        // reviewed with 2.4
        public void DrawTabControlTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
        {
            bool flag = (state & DrawItemState.Selected) == DrawItemState.Selected;
            int height = bounds.Height;
            Color color4 = flag ? this.x6cefc7bb40cf5d76 : this.x51e4f0f96f7fc653;
            Color color1_1 = color4;
            Color color3 = flag ? this.x05d7ee48911d8dba : this.xb9bbdee8e645fa7b;
            if (this.TabColorBlend > 0.0)
            {
                color1_1 = RendererBase.InterpolateColors(color1_1, backColor, (float)this.TabColorBlend);
                color3 = RendererBase.InterpolateColors(color3, backColor, (float)this.TabColorBlend);
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(bounds, color1_1, color3, LinearGradientMode.Vertical))
                graphics.FillPolygon(brush, this.x23c99552401d90a0(bounds, false));
            SmoothingMode smoothingMode = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(flag ? this.xd9caa88fffee2844 : this.x68e7227781326461))
                graphics.DrawLines(pen, this.x23c99552401d90a0(bounds, false));
            using (Pen pen1 = new Pen(this.x31d8d8063d8f3c74))
            {
                graphics.DrawLines(pen1, this.x23c99552401d90a0(bounds, true));
                if (!flag)
                {
                    using (Pen pen2 = new Pen(RendererBase.InterpolateColors(this.x31d8d8063d8f3c74, this.x68e7227781326461, 0.5f)))
                    {
                        graphics.DrawLines(pen2, new Point[]
                        {
                            new Point(bounds.Right - 4, bounds.Y + 1),
                            new Point(bounds.Right - 2, bounds.Y + 3),
                            new Point(bounds.Right - 2, bounds.Bottom - 2)
                        });
                    }
                }
            }

            if (flag)
            {
                using (Pen pen = new Pen(color3))
                    graphics.DrawLine(pen, bounds.X + 1, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
            }
            graphics.SmoothingMode = smoothingMode;
            if ((state & DrawItemState.Checked) == DrawItemState.Checked)
            {
                Rectangle rectangle = bounds;
                rectangle.X += this.TabControlTabExtra;
                rectangle.Width -= this.TabControlTabExtra;
                rectangle.Inflate(-4, -3);
                ++rectangle.X;
                ++rectangle.Height;
                ControlPaint.DrawFocusRectangle(graphics, rectangle);
            }
            bounds.X += this.TabControlTabExtra + 6;
            bounds.Width -= this.TabControlTabExtra + 6;
            bounds.Inflate(-2, 0);
            if (image != null)
            {
                Rectangle destRect = new Rectangle(bounds.X, bounds.Y + bounds.Height / 2 - image.Height / 2, image.Width, image.Height);
                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
                bounds.X += image.Width + 4;
                bounds.Width -= image.Width + 4;
            }

            if (bounds.Width <= 4)
                return;
            if (flag)
            {
                using (Font font1 = new Font(font, FontStyle.Bold))
                    TextRenderer.DrawText((IDeviceContext)graphics, text, font1, bounds, foreColor, this.textFormatFlags);
            }
            else
                TextRenderer.DrawText((IDeviceContext)graphics, text, font, bounds, foreColor, this.textFormatFlags);
            return;
        }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        // reviewed with 2.4
        public void DrawTabControlBackground(Graphics graphics, Rectangle bounds, Color backColor, bool client)
        {
            if (bounds.Width <= 0 || bounds.Height <= 0)
                return;
            Color color1 = Color.FromArgb(252, 252, 254);
            Color color2 = Color.FromArgb(244, 243, 238);
            if (this.PageColorBlend > 0.0)
            {
                color1 = RendererBase.InterpolateColors(color1, backColor, (float)this.PageColorBlend);
                color2 = RendererBase.InterpolateColors(color2, backColor, (float)this.PageColorBlend);
            }

            if (client)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(bounds, color2, color1, LinearGradientMode.Vertical))
                    graphics.FillRectangle(brush, bounds);
            }
            else
            {
                Rectangle rect3 = bounds;
                rect3.Height = this.TabControlPadding.Height;

                using (SolidBrush solidBrush = new SolidBrush(color2))
                    graphics.FillRectangle((Brush)solidBrush, rect3);
                Rectangle rect1 = bounds;
                rect1.Y += this.TabControlPadding.Height;
                rect1.Height -= this.TabControlPadding.Height * 2;
                if (rect1.Width > 0 && rect1.Height > 0)
                {
                    using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect1, color2, color1, LinearGradientMode.Vertical))
                        graphics.FillRectangle((Brush)linearGradientBrush, rect1);

                }

                Rectangle rect2 = bounds;
                rect2.Y = rect2.Bottom - this.TabControlPadding.Height;
                rect2.Height = this.TabControlPadding.Height;
        
                using (SolidBrush solidBrush = new SolidBrush(color1))
                    graphics.FillRectangle(solidBrush, rect2);
                using (Pen pen = new Pen(this.x68e7227781326461))
                {
                    graphics.DrawLine(pen, bounds.X, bounds.Y, bounds.X, bounds.Bottom - 2);
                    graphics.DrawLine(pen, bounds.X, bounds.Bottom - 2, bounds.Right - 2, bounds.Bottom - 2);
                    graphics.DrawLine(pen, bounds.Right - 2, bounds.Bottom - 2, bounds.Right - 2, bounds.Y);
                }
                using (Pen pen = new Pen(RendererBase.InterpolateColors(this.x68e7227781326461, SystemColors.Control, 0.8f)))
                {
                    graphics.DrawLine(pen, bounds.X, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
                    graphics.DrawLine(pen, bounds.Right - 1, bounds.Bottom - 1, bounds.Right - 1, bounds.Y);
                }
            }
        }
    }
}
