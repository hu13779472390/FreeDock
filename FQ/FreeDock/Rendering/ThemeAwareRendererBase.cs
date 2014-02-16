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
        private WindowsColorScheme colorScheme;
        private Color layoutBackgroundColor1;
        private Color layoutBackgroundColor2;
        private int sessions;
        private TextFormatFlags textFormat;

        /// <summary>
        /// A standard TextFormatFlags value that can be used during measuring and rendering.
        /// 
        /// </summary>
        protected TextFormatFlags TextFormat
        {
            get
            {
                return this.textFormat;
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
                return this.layoutBackgroundColor1;
            }
            set
            {
                this.layoutBackgroundColor1 = value;
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
                return this.layoutBackgroundColor2;
            }
            set
            {
                this.layoutBackgroundColor2 = value;
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
                return this.colorScheme;
            }
            set
            {
                this.colorScheme = value;
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
            this.textFormat = TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.NoPadding;
            if (hotKeys == HotkeyPrefix.None)
                this.textFormat |= TextFormatFlags.NoPrefix;
            else if (hotKeys == HotkeyPrefix.Hide)
                this.textFormat |= TextFormatFlags.HidePrefix;
            ++this.sessions;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override void FinishRenderSession()
        {
            this.sessions = Math.Max(this.sessions - 1, 0);
        }

        private void drawContent(Control container, Control control, Graphics graphics, Rectangle bounds)
        {
            Rectangle clientRectangle = container.ClientRectangle;

            if (clientRectangle.Width > 0 && clientRectangle.Height > 0 && bounds.Width > 0 && bounds.Height > 0)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(control.PointToClient(container.PointToScreen(new Point(0, 0))), control.PointToClient(container.PointToScreen(new Point(clientRectangle.Right, 0))), this.LayoutBackgroundColor1, this.LayoutBackgroundColor2))
                {
                    graphics.FillRectangle(brush, bounds);
                }
            }
        }

        /// <summary>
        /// Overridden. Draws the background of an AutoHide bar, adhering to the gradient being drawn across the whole layout.
        /// 
        /// </summary>
        protected internal override void DrawAutoHideBarBackground(Control container, Control autoHideBar, Graphics graphics, Rectangle bounds)
        {
            this.drawContent(container, autoHideBar, graphics, bounds);
        }

        /// <summary>
        /// Overridden. Draws a splitter that adheres to the gradient being drawn across the whole layout.
        /// 
        /// </summary>
        protected internal override void DrawSplitter(Control container, Control control, Graphics graphics, Rectangle bounds, Orientation orientation)
        {
            if (container != null)
                this.drawContent(container, control, graphics, bounds);
        }

        /// <summary>
        /// Overridden. Draws the background of a tabstrip, adhering to the gradient being drawn across the whole layout.
        /// 
        /// </summary>
        protected internal override void DrawTabStripBackground(Control container, Control control, Graphics graphics, Rectangle bounds, int selectedTabOffset)
        {
            this.drawContent(container, control, graphics, bounds);
        }

        /// <summary>
        /// Overridden. Calls one of the Apply methods depending on the current Windows color scheme.
        /// 
        /// </summary>
        protected override void GetColorsFromSystem()
        {
            WindowsColorScheme scheme = this.colorScheme;
            switch (scheme)
            {
                case WindowsColorScheme.LunaBlue:
                    this.ApplyLunaBlueColors();
                    break;
                case WindowsColorScheme.LunaOlive:
                    this.ApplyLunaOliveColors();
                    break;
                case WindowsColorScheme.LunaSilver:
                    this.ApplyLunaSilverColors();
                    break;
                case WindowsColorScheme.Standard:
                case WindowsColorScheme.Automatic:
                default:
                    this.ApplyStandardColors();
                    break;
            }
            base.GetColorsFromSystem();

//            string str1;
//            do
//            {
//                string str2;
//                switch (scheme)
//                {
//                    case WindowsColorScheme.Automatic:
//                        if (!WhidbeyRenderer.x7fb2e1ce54a27086() || !x60f3af502af1d663.x2e20a402b77c44dc)
//                        {
//                            str2 = "none";
//                            goto label_14;
//                        }
//                        else
//                            goto label_13;
//                    case WindowsColorScheme.Standard:
//                        this.ApplyStandardColors();
//                        goto label_16;
//                    case WindowsColorScheme.LunaBlue:
//                        goto label_4;
//                    case WindowsColorScheme.LunaOlive:
//                        goto label_3;
//                    case WindowsColorScheme.LunaSilver:
//                        goto label_1;
//                    default:
//                        goto label_2;
//                }
//                label_11:
//                if (!(str1 == "NormalColor"))
//                {
//                     continue;
//                }
//                else
//                    goto label_10;
//                label_13:
//                str2 = x60f3af502af1d663.x4f15c2ab6fab0941;
//                label_14:
//                string str3 = str2;
//                if ((str1 = str3) == null)
//                    goto label_5;
//                else
//                    goto label_11;
//            }
//            while (2 == 0);
//            goto label_8;
//            label_1:
//            this.ApplyLunaSilverColors();
//            label_2:
//            base.GetColorsFromSystem();
//            return;
//            label_3:
//            this.ApplyLunaOliveColors();
//            goto label_2;
//            label_4:
//            this.ApplyLunaBlueColors();
//            goto label_2;
//            label_5:
//            this.ApplyStandardColors();
//            if (2 != 0)
//                goto label_2;
//            label_6:
//            if (str1 == "Metallic")
//            {
//                this.ApplyLunaSilverColors();
//                goto label_2;
//            }
//            else
//                goto label_5;
//            label_8:
//            if (str1 == "HomeStead")
//            {
//                this.ApplyLunaOliveColors();
//                goto label_2;
//            }
//            else
//                goto label_6;
//            label_10:
//            this.ApplyLunaBlueColors();
//            goto label_2;
//            label_16:
//            goto label_2;
        }
    }
}
