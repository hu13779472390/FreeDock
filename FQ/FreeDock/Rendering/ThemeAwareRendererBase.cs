using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using FQ.FreeDock;

namespace FQ.FreeDock.Rendering
{
    /// <summary>
    /// Provides a base for renderers that are aware of the current Windows visual style and color scheme.
    /// 
    /// </summary>
    public abstract class ThemeAwareRendererBase : RendererBase
    {
        private WindowsColorScheme x62a65b2c0f145432;
        private Color x433ae1e8829e8c68;
        private Color x15920bc36c82e681;
        private int x03bb1ee2adad51ea;
        private TextFormatFlags xae3b2752a89e7464;

        /// <summary>
        /// A standard TextFormatFlags value that can be used during measuring and rendering.
        /// 
        /// </summary>
        protected TextFormatFlags TextFormat
        {
            get
            {
                return this.xae3b2752a89e7464;
            }
        }

        /// <summary>
        /// The colour used to draw the start of the gradient in the background of a DockContainer.
        /// 
        /// </summary>
        public Color LayoutBackgroundColor1
        {
            get
            {
                return this.x433ae1e8829e8c68;
            }
            set
            {
                this.x433ae1e8829e8c68 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the end of the gradient in the background of a DockContainer.
        /// 
        /// </summary>
        public Color LayoutBackgroundColor2
        {
            get
            {
                return this.x15920bc36c82e681;
            }
            set
            {
                this.x15920bc36c82e681 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The color scheme used to render graphical elements.
        /// 
        /// </summary>
        public WindowsColorScheme ColorScheme
        {
            get
            {
                return this.x62a65b2c0f145432;
            }
            set
            {
                this.x62a65b2c0f145432 = value;
                this.GetColorsFromSystem();
            }
        }

        /// <summary>
        /// Applies colors obtained from the normal system colors. This method should check for SystemInformation.HighContrast.
        /// 
        /// </summary>
        protected abstract void ApplyStandardColors();

        /// <summary>
        /// Applies colors appropriate for the Windows XP Luna Blue color scheme.
        /// 
        /// </summary>
        protected abstract void ApplyLunaBlueColors();

        /// <summary>
        /// Applies colors appropriate for the Windows XP Luna Olive color scheme.
        /// 
        /// </summary>
        protected abstract void ApplyLunaOliveColors();

        /// <summary>
        /// Applies colors appropriate for the Windows XP Luna Silver color scheme.
        /// 
        /// </summary>
        protected abstract void ApplyLunaSilverColors();

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override void StartRenderSession(HotkeyPrefix hotKeys)
        {
            this.xae3b2752a89e7464 = TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.NoPadding;
            if (0 == 0)
                goto label_5;
            else
                goto label_2;
            label_1:
            if (hotKeys == HotkeyPrefix.Hide)
                this.xae3b2752a89e7464 |= TextFormatFlags.HidePrefix;
            label_2:
            ++this.x03bb1ee2adad51ea;
            if (0 == 0)
                return;
            else
                goto label_1;
            label_5:
            if (0 != 0 || hotKeys == HotkeyPrefix.None)
            {
                this.xae3b2752a89e7464 |= TextFormatFlags.NoPrefix;
                goto label_2;
            }
            else
                goto label_1;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override void FinishRenderSession()
        {
            this.x03bb1ee2adad51ea = Math.Max(this.x03bb1ee2adad51ea - 1, 0);
        }

        private void xbff62e1edc3f3404(Control xd3311d815ca25f02, Control x43bec302f92080b9, Graphics x41347a961b838962, Rectangle xda73fcb97c77d998)
        {
            if (0 != 0 || xd3311d815ca25f02.ClientRectangle.Width > 0)
            {
                Rectangle clientRectangle = xd3311d815ca25f02.ClientRectangle;
                if (-2 != 0)
                    goto label_14;
                label_9:
                while (xda73fcb97c77d998.Width > 0)
                {
                    while (xda73fcb97c77d998.Height > 0)
                    {
                        label_8:
                        Color backgroundColor1 = this.LayoutBackgroundColor1;
                        Color backgroundColor2 = this.LayoutBackgroundColor2;
                        if (int.MinValue != 0)
                        {
                            if (0 == 0)
                            {
                                if (0 == 0)
                                {
                                    using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(x43bec302f92080b9.PointToClient(xd3311d815ca25f02.PointToScreen(new System.Drawing.Point(0, 0))), x43bec302f92080b9.PointToClient(xd3311d815ca25f02.PointToScreen(new System.Drawing.Point(xd3311d815ca25f02.ClientRectangle.Right, 0))), backgroundColor1, backgroundColor2))
                                    {
                                        x41347a961b838962.FillRectangle((Brush)linearGradientBrush, xda73fcb97c77d998);
                                        break;
                                    }
                                }
                                else
                                    goto label_9;
                            }
                            else if (2 != 0 && 1 != 0)
                                goto label_8;
                        }
                        else
                            goto label_9;
                    }
                    break;
                }
                return;
                label_14:
                if (clientRectangle.Height <= 0)
                {
                    while (3 == 0)
                    {
                        if (8 != 0 || 0 == 0)
                        {
                            if (0 == 0)
                            {
                                if (0 == 0)
                                    break;
                            }
                            else
                                goto label_14;
                        }
                    }
                }
                else if (0 == 0)
                    goto label_9;
                if (0 != 0)
                    goto label_9;
            }
            else if (0 != 0)
                ;
        }

        /// <summary>
        /// Overridden. Draws the background of an AutoHide bar, adhering to the gradient being drawn across the whole layout.
        /// 
        /// </summary>
        protected internal override void DrawAutoHideBarBackground(Control container, Control autoHideBar, Graphics graphics, Rectangle bounds)
        {
            this.xbff62e1edc3f3404(container, autoHideBar, graphics, bounds);
        }

        /// <summary>
        /// Overridden. Draws a splitter that adheres to the gradient being drawn across the whole layout.
        /// 
        /// </summary>
        protected internal override void DrawSplitter(Control container, Control control, Graphics graphics, Rectangle bounds, Orientation orientation)
        {
            if (container == null)
                return;
            this.xbff62e1edc3f3404(container, control, graphics, bounds);
        }

        /// <summary>
        /// Overridden. Draws the background of a tabstrip, adhering to the gradient being drawn across the whole layout.
        /// 
        /// </summary>
        protected internal override void DrawTabStripBackground(Control container, Control control, Graphics graphics, Rectangle bounds, int selectedTabOffset)
        {
            this.xbff62e1edc3f3404(container, control, graphics, bounds);
        }

        /// <summary>
        /// Overridden. Calls one of the Apply methods depending on the current Windows color scheme.
        /// 
        /// </summary>
        protected override void GetColorsFromSystem()
        {
            WindowsColorScheme windowsColorScheme = this.x62a65b2c0f145432;
            string str1;
            do
            {
                string str2;
                switch (windowsColorScheme)
                {
                    case WindowsColorScheme.Automatic:
                        if (!WhidbeyRenderer.x7fb2e1ce54a27086() || 0 != 0 || !x60f3af502af1d663.x2e20a402b77c44dc)
                        {
                            str2 = "none";
                            goto label_14;
                        }
                        else
                            goto label_13;
                    case WindowsColorScheme.Standard:
                        this.ApplyStandardColors();
                        if (0 != 0)
                            break;
                        else
                            goto label_16;
                    case WindowsColorScheme.LunaBlue:
                        goto label_4;
                    case WindowsColorScheme.LunaOlive:
                        goto label_3;
                    case WindowsColorScheme.LunaSilver:
                        goto label_1;
                    default:
                        goto label_2;
                }
                label_11:
                if (!(str1 == "NormalColor"))
                {
                    if (0 == 0)
                        continue;
                }
                else
                    goto label_10;
                label_13:
                str2 = x60f3af502af1d663.x4f15c2ab6fab0941;
                label_14:
                string str3 = str2;
                if (int.MaxValue == 0 || (str1 = str3) == null)
                    goto label_5;
                else
                    goto label_11;
            }
            while (2 == 0);
            goto label_8;
            label_1:
            this.ApplyLunaSilverColors();
            label_2:
            base.GetColorsFromSystem();
            return;
            label_3:
            this.ApplyLunaOliveColors();
            goto label_2;
            label_4:
            this.ApplyLunaBlueColors();
            goto label_2;
            label_5:
            this.ApplyStandardColors();
            if (2 != 0)
                goto label_2;
            label_6:
            if (str1 == "Metallic")
            {
                this.ApplyLunaSilverColors();
                goto label_2;
            }
            else
                goto label_5;
            label_8:
            if (str1 == "HomeStead")
            {
                this.ApplyLunaOliveColors();
                goto label_2;
            }
            else
                goto label_6;
            label_10:
            this.ApplyLunaBlueColors();
            goto label_2;
            label_16:
            if (3 == 0)
                goto label_5;
            else
                goto label_2;
        }
    }
}
