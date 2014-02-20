using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using FQ.FreeDock;

namespace FQ.FreeDock.Rendering
{
    /// <summary>
    /// Provides a renderer that mimics the appearance of Microsoft Visual Studio.NET 2005.
    /// 
    /// </summary>
    public class WhidbeyRenderer : ThemeAwareRendererBase
    {
        private Color x994b52371e1ca7a9;
        private Color xcee7f670c3cc8729;
        private Color x80caa5727f6ffe52;
        private Color x0b2889b8ff5ec580;
        private Color x9196c174a89a4ce4;
        private Color x0e8b6412ec502dbf;
        private Color xd1edc46cbe592968;
        private Color x43b04232fee73e15;
        private Color x8e2e7f87608d5b3b;
        private Color x9a7470f809ffee0d;
        private Color x2d5bde28a1e8ae90;
        private Color xebb7eaf00d600976;
        private Color x6b97fa649c9b3a44;
        private Color x693536a88ebe8191;
        private Color x503b1fd8602da9a9;
        private Color xb2b9c364e92661dd;
        private Color x4056384aa48da1d1;
        private Color x2e1ef9b84f7ac14b;
        private Color x4dea88af4363a77b;
        private BoxModel _x066f993679e36022;
        private BoxModel _x3a1fa93b40743331;
        private BoxModel _x6defba3d5d846e0d;

        /// <summary>
        /// The colour used to draw the border around an active document tab.
        /// 
        /// </summary>
        public Color ActiveDocumentBorderColor
        {
            get
            {
                return this.x994b52371e1ca7a9;
            }
            set
            {
                this.x994b52371e1ca7a9 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the border around an inactive document tab.
        /// 
        /// </summary>
        public Color InactiveDocumentBorderColor
        {
            get
            {
                return this.xcee7f670c3cc8729;
            }
            set
            {
                this.xcee7f670c3cc8729 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the top of the gradient on the background of a document strip.
        /// 
        /// </summary>
        public Color DocumentStripBackgroundColor1
        {
            get
            {
                return this.xd1edc46cbe592968;
            }
            set
            {
                this.xd1edc46cbe592968 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the bottom of the gradient on the background of a document strip.
        /// 
        /// </summary>
        public Color DocumentStripBackgroundColor2
        {
            get
            {
                return this.x43b04232fee73e15;
            }
            set
            {
                this.x43b04232fee73e15 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the border of a hot button on an active dockable window titlebar.
        /// 
        /// </summary>
        public Color ActiveHotButtonBorderColor
        {
            get
            {
                return this.x4dea88af4363a77b;
            }
            set
            {
                this.x4dea88af4363a77b = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the background of a hot button on an active dockable window titlebar.
        /// 
        /// </summary>
        public Color ActiveHotButtonBackgroundColor
        {
            get
            {
                return this.x2e1ef9b84f7ac14b;
            }
            set
            {
                this.x2e1ef9b84f7ac14b = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the border of a button on an active dockable window titlebar.
        /// 
        /// </summary>
        public Color ActiveButtonBorderColor
        {
            get
            {
                return this.x4056384aa48da1d1;
            }
            set
            {
                this.x4056384aa48da1d1 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the background of a button on an active dockable window titlebar.
        /// 
        /// </summary>
        public Color ActiveButtonBackgroundColor
        {
            get
            {
                return this.xb2b9c364e92661dd;
            }
            set
            {
                this.xb2b9c364e92661dd = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the border of a button on an inactive dockable window titlebar.
        /// 
        /// </summary>
        public Color InactiveButtonBorderColor
        {
            get
            {
                return this.x503b1fd8602da9a9;
            }
            set
            {
                this.x503b1fd8602da9a9 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the background of a button on an inactive dockable window titlebar.
        /// 
        /// </summary>
        public Color InactiveButtonBackgroundColor
        {
            get
            {
                return this.x693536a88ebe8191;
            }
            set
            {
                this.x693536a88ebe8191 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the foreground of an active dockable window titlebar.
        /// 
        /// </summary>
        public Color ActiveTitleBarForegroundColor
        {
            get
            {
                return this.x6b97fa649c9b3a44;
            }
            set
            {
                this.x6b97fa649c9b3a44 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the background of an active dockable window titlebar.
        /// 
        /// </summary>
        public Color ActiveTitleBarBackgroundColor2
        {
            get
            {
                return this.xebb7eaf00d600976;
            }
            set
            {
                this.xebb7eaf00d600976 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the background of an active dockable window titlebar.
        /// 
        /// </summary>
        public Color ActiveTitleBarBackgroundColor1
        {
            get
            {
                return this.x2d5bde28a1e8ae90;
            }
            set
            {
                this.x2d5bde28a1e8ae90 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the foreground of an inactive dockable window titlebar.
        /// 
        /// </summary>
        public Color InactiveTitleBarForegroundColor
        {
            get
            {
                return this.x9a7470f809ffee0d;
            }
            set
            {
                this.x9a7470f809ffee0d = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the background of an inactive dockable window titlebar.
        /// 
        /// </summary>
        public Color InactiveTitleBarBackgroundColor
        {
            get
            {
                return this.x8e2e7f87608d5b3b;
            }
            set
            {
                this.x8e2e7f87608d5b3b = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the shadow of an active document.
        /// 
        /// </summary>
        public Color ActiveDocumentShadowColor
        {
            get
            {
                return this.x9196c174a89a4ce4;
            }
            set
            {
                this.x9196c174a89a4ce4 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the shadow of an inactive document.
        /// 
        /// </summary>
        public Color InactiveDocumentShadowColor
        {
            get
            {
                return this.x0e8b6412ec502dbf;
            }
            set
            {
                this.x0e8b6412ec502dbf = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the highlight of an inactive document.
        /// 
        /// </summary>
        public Color InactiveDocumentHighlightColor
        {
            get
            {
                return this.x0b2889b8ff5ec580;
            }
            set
            {
                this.x0b2889b8ff5ec580 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The colour used to draw the highlight of an active document.
        /// 
        /// </summary>
        public Color ActiveDocumentHighlightColor
        {
            get
            {
                return this.x80caa5727f6ffe52;
            }
            set
            {
                this.x80caa5727f6ffe52 = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The size of image to draw in window tabs.
        /// 
        /// </summary>
        public override System.Drawing.Size ImageSize
        {
            get
            {
                return base.ImageSize;
            }
            set
            {
                this.x50aa48875b838a15();
                base.ImageSize = value;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override System.Drawing.Size TabControlPadding
        {
            get
            {
                return new System.Drawing.Size(3, 3);
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override int DocumentTabSize
        {
            get
            {
                return Math.Max(Control.DefaultFont.Height, this.ImageSize.Height) + 4;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override int DocumentTabStripSize
        {
            get
            {
                return Math.Max(Control.DefaultFont.Height, this.ImageSize.Height) + 5;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override int DocumentTabExtra
        {
            get
            {
                return this.ImageSize.Width - 4;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override BoxModel TitleBarMetrics
        {
            get
            {
                if (this._x6defba3d5d846e0d == null)
                    this._x6defba3d5d846e0d = new BoxModel(0, SystemInformation.ToolWindowCaptionHeight, 0, 0, 0, 0, 0, 0, 0, 0);
                return this._x6defba3d5d846e0d;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override BoxModel TabMetrics
        {
            get
            {
                if (this._x3a1fa93b40743331 == null)
                    this._x3a1fa93b40743331 = new BoxModel(0, 0, 0, 0, 0, 0, 0, 0, -1, 0);
                return this._x3a1fa93b40743331;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override BoxModel TabStripMetrics
        {
            get
            {
                if (this._x066f993679e36022 == null)
                    this._x066f993679e36022 = new BoxModel(0, Math.Max(Control.DefaultFont.Height, this.ImageSize.Height) + 8, 0, 0, 0, 1, 0, 0, 0, 0);
                return this._x066f993679e36022;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override TabTextDisplayMode TabTextDisplay
        {
            get
            {
                return TabTextDisplayMode.AllTabs;
            }
        }

        /// <summary>
        /// Initializes a new instance of the WhidbeyRenderer class.
        /// 
        /// </summary>
        public WhidbeyRenderer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the WhidbeyRenderer class.
        /// 
        /// </summary>
        /// <param name="colorScheme">The initial value of the ColorScheme property.</param>
        public WhidbeyRenderer(WindowsColorScheme colorScheme)
        {
            this.ColorScheme = colorScheme;
        }

        /// <summary>
        /// Calculates secondary colours based on combinations of and alterations to the base colours.
        /// 
        /// </summary>
        protected override void GetColorsFromSystem()
        {
            base.GetColorsFromSystem();
            if (!SystemInformation.HighContrast)
            {
                this.x80caa5727f6ffe52 = SystemColors.ControlLightLight;
                this.x0b2889b8ff5ec580 = SystemColors.ControlLightLight;
                this.x9196c174a89a4ce4 = SystemColors.ControlLightLight;
                this.x0e8b6412ec502dbf = SystemColors.Control;
            }
            else
            {
                this.x80caa5727f6ffe52 = SystemColors.Control;
                this.x0b2889b8ff5ec580 = SystemColors.Control;
                this.x9196c174a89a4ce4 = SystemColors.Control;
                this.x0e8b6412ec502dbf = SystemColors.Control;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void ApplyStandardColors()
        {
            if (!SystemInformation.HighContrast)
                goto label_8;
            else
                goto label_12;
            label_1:
            this.xb2b9c364e92661dd = Color.Transparent;
            this.x4056384aa48da1d1 = SystemColors.ControlLightLight;
            this.x2e1ef9b84f7ac14b = SystemInformation.HighContrast ? Color.Transparent : Color.FromArgb(100, SystemColors.Control);
            this.x4dea88af4363a77b = SystemColors.ControlLightLight;
            if (2 != 0)
                return;
            else
                goto label_13;
            label_6:
            this.xd1edc46cbe592968 = SystemColors.Control;
            this.x43b04232fee73e15 = this.xd1edc46cbe592968;
            this.x2d5bde28a1e8ae90 = SystemColors.ActiveCaption;
            label_7:
            this.xebb7eaf00d600976 = SystemColors.ActiveCaption;
            this.x6b97fa649c9b3a44 = SystemColors.ActiveCaptionText;
            if (0 == 0)
            {
                this.x8e2e7f87608d5b3b = SystemColors.InactiveCaption;
                this.x9a7470f809ffee0d = SystemColors.InactiveCaptionText;
                if (-1 == 0)
                {
                    if (0 != 0)
                    {
                        if (0 == 0)
                            goto label_6;
                        else
                            goto label_6;
                    }
                    else
                        goto label_9;
                }
            }
            if (0 == 0)
            {
                this.x693536a88ebe8191 = Color.Transparent;
                this.x503b1fd8602da9a9 = SystemColors.ControlLightLight;
                goto label_1;
            }
            else
                goto label_12;
            label_8:
            this.LayoutBackgroundColor1 = SystemColors.Control;
            this.LayoutBackgroundColor2 = RendererBase.InterpolateColors(SystemColors.Control, SystemColors.Window, 0.8f);
            this.ActiveDocumentBorderColor = SystemColors.AppWorkspace;
            this.InactiveDocumentBorderColor = SystemColors.ControlDark;
            if (0 != 0)
                goto label_1;
            else
                goto label_6;
            label_9:
            this.ActiveDocumentBorderColor = SystemColors.ActiveCaption;
            if (0 == 0)
            {
                this.InactiveDocumentBorderColor = SystemColors.ControlDark;
                goto label_6;
            }
            else
                goto label_7;
            label_12:
            this.LayoutBackgroundColor1 = SystemColors.Control;
            label_13:
            this.LayoutBackgroundColor2 = SystemColors.Control;
            goto label_9;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void ApplyLunaBlueColors()
        {
            this.LayoutBackgroundColor1 = Color.FromArgb(229, 229, 215);
            this.LayoutBackgroundColor2 = Color.FromArgb(243, 242, 231);
            this.xd1edc46cbe592968 = Color.FromArgb(228, 226, 213);
            this.x43b04232fee73e15 = this.xd1edc46cbe592968;
            if (0 != 0)
                return;
            this.ActiveDocumentBorderColor = Color.FromArgb((int)sbyte.MaxValue, 157, 185);
            this.InactiveDocumentBorderColor = SystemColors.ControlDark;
            this.x2d5bde28a1e8ae90 = Color.FromArgb(59, 128, 237);
            this.xebb7eaf00d600976 = Color.FromArgb(49, 106, 197);
            this.x6b97fa649c9b3a44 = Color.White;
            this.x8e2e7f87608d5b3b = Color.FromArgb(204, 199, 186);
            if (0 == 0)
                goto label_3;
            label_1:
            this.x693536a88ebe8191 = SystemColors.Control;
            this.x503b1fd8602da9a9 = Color.FromArgb(140, 134, 123);
            this.xb2b9c364e92661dd = Color.FromArgb(156, 182, 231);
            label_2:
            this.x4056384aa48da1d1 = Color.FromArgb(60, 90, 170);
            this.x2e1ef9b84f7ac14b = Color.FromArgb(120, 150, 210);
            this.x4dea88af4363a77b = Color.FromArgb(60, 90, 170);
            return;
            label_3:
            this.x9a7470f809ffee0d = Color.Black;
            if (1 == 0)
                goto label_2;
            else
                goto label_1;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void ApplyLunaOliveColors()
        {
            this.LayoutBackgroundColor1 = Color.FromArgb(229, 229, 215);
            if (-2 != 0)
                goto label_4;
            label_1:
            this.x693536a88ebe8191 = SystemColors.Control;
            this.x503b1fd8602da9a9 = Color.FromArgb(140, 134, 123);
            this.xb2b9c364e92661dd = Color.FromArgb(181, 199, 140);
            this.x4056384aa48da1d1 = Color.FromArgb(118, 128, 95);
            this.x2e1ef9b84f7ac14b = Color.FromArgb(148, 162, 115);
            this.x4dea88af4363a77b = Color.FromArgb(118, 128, 95);
            if (4 != 0)
                return;
            label_4:
            this.LayoutBackgroundColor2 = Color.FromArgb(243, 242, 231);
            this.xd1edc46cbe592968 = Color.FromArgb(228, 226, 213);
            this.x43b04232fee73e15 = this.xd1edc46cbe592968;
            do
            {
                this.ActiveDocumentBorderColor = Color.FromArgb((int)sbyte.MaxValue, 157, 185);
                this.InactiveDocumentBorderColor = SystemColors.ControlDark;
                if (0 == 0)
                {
                    if (0 == 0)
                    {
                        this.x2d5bde28a1e8ae90 = Color.FromArgb(182, 195, 146);
                        this.xebb7eaf00d600976 = Color.FromArgb(145, 160, 117);
                        this.x6b97fa649c9b3a44 = Color.White;
                    }
                    else
                        goto label_1;
                }
                else
                    break;
            }
            while (0 != 0);
            this.x8e2e7f87608d5b3b = Color.FromArgb(204, 199, 186);
            this.x9a7470f809ffee0d = Color.Black;
            goto label_1;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void ApplyLunaSilverColors()
        {
            this.LayoutBackgroundColor1 = Color.FromArgb(215, 215, 229);
            this.LayoutBackgroundColor2 = Color.FromArgb(243, 243, 247);
            this.xd1edc46cbe592968 = Color.FromArgb(238, 238, 238);
            if (-2 == 0)
                return;
            this.x43b04232fee73e15 = this.xd1edc46cbe592968;
            this.ActiveDocumentBorderColor = Color.FromArgb((int)sbyte.MaxValue, 157, 185);
            this.InactiveDocumentBorderColor = SystemColors.ControlDark;
            this.x2d5bde28a1e8ae90 = Color.FromArgb(211, 212, 221);
            this.xebb7eaf00d600976 = Color.FromArgb(166, 165, 191);
            this.x6b97fa649c9b3a44 = Color.Black;
            this.x8e2e7f87608d5b3b = Color.FromArgb(240, 240, 245);
            if ((int)byte.MaxValue != 0)
                goto label_3;
            label_1:
            if (1 != 0)
            {
                this.xb2b9c364e92661dd = Color.FromArgb((int)byte.MaxValue, 227, 173);
                this.x4056384aa48da1d1 = Color.FromArgb(74, 73, 107);
                this.x2e1ef9b84f7ac14b = Color.FromArgb((int)byte.MaxValue, 182, 115);
                this.x4dea88af4363a77b = Color.FromArgb(74, 73, 107);
                return;
            }
            label_3:
            this.x9a7470f809ffee0d = Color.Black;
            this.x693536a88ebe8191 = Color.FromArgb(214, 215, 222);
            this.x503b1fd8602da9a9 = Color.FromArgb(123, 125, 148);
            goto label_1;
        }

        private void x50aa48875b838a15()
        {
            this._x066f993679e36022 = (BoxModel)null;
            this._x3a1fa93b40743331 = (BoxModel)null;
            this._x6defba3d5d846e0d = (BoxModel)null;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawDocumentStripBackground(Graphics graphics, Rectangle bounds)
        {
            if (bounds.Width <= 0 || (int)byte.MaxValue == 0 || bounds.Height <= 0)
                return;
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new System.Drawing.Point(bounds.X, bounds.Y - 1), new System.Drawing.Point(bounds.X, bounds.Bottom), this.xd1edc46cbe592968, this.x43b04232fee73e15))
                graphics.FillRectangle((Brush)linearGradientBrush, bounds);
            using (Pen pen = new Pen(this.x994b52371e1ca7a9))
                graphics.DrawLine(pen, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
        }

        internal virtual void x9271fbf5eef553db(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DrawItemState x01b557925841ae51, bool xb0f87b71823b1d4e)
        {
            if ((x01b557925841ae51 & DrawItemState.HotLight) != DrawItemState.HotLight)
                return;
            if (xb0f87b71823b1d4e || ((xb0f87b71823b1d4e ? 1 : 0) & 0) != 0)
                goto label_20;
            label_11:
            Color color1 = this.x503b1fd8602da9a9;
            Color color2 = this.x503b1fd8602da9a9;
            Color color3;
            if (-2 != 0)
                color3 = this.x693536a88ebe8191;
            else
                goto label_20;
            label_13:
            using (SolidBrush solidBrush = new SolidBrush(color3))
                x41347a961b838962.FillRectangle((Brush)solidBrush, xda73fcb97c77d998);
            using (Pen pen = new Pen(color1))
            {
                x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
                x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1);
            }
            using (Pen pen = new Pen(color2))
            {
                x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
                x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1);
                return;
            }
            label_20:
            if ((x01b557925841ae51 & DrawItemState.Selected) != DrawItemState.Selected)
            {
                do
                {
                    color1 = this.x4056384aa48da1d1;
                }
                while (8 == 0);
                color2 = this.x4056384aa48da1d1;
                color3 = this.xb2b9c364e92661dd;
                goto label_13;
            }
            else
            {
                color1 = this.x4dea88af4363a77b;
                color2 = this.x4dea88af4363a77b;
                color3 = this.x2e1ef9b84f7ac14b;
                if (1 != 0)
                    goto label_13;
                else
                    goto label_11;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawControlClientBackground(Graphics graphics, Rectangle bounds, Color backColor)
        {
            graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
            graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 1, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
            graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawDocumentClientBackground(Graphics graphics, Rectangle bounds, Color backColor)
        {
            using (SolidBrush solidBrush = new SolidBrush(backColor))
                graphics.FillRectangle((Brush)solidBrush, bounds);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawDocumentStripButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state)
        {
            this.x9271fbf5eef553db(graphics, bounds, state, true);
            do
            {
                switch (buttonType)
                {
                    case SandDockButtonType.Close:
                        goto label_4;
                    case SandDockButtonType.Pin:
                        goto label_14;
                    case SandDockButtonType.ScrollLeft:
                        goto label_10;
                    case SandDockButtonType.ScrollRight:
                        goto label_11;
                    case SandDockButtonType.WindowPosition:
                        goto label_15;
                    case SandDockButtonType.ActiveFiles:
                        bounds.Inflate(1, 1);
                        --bounds.X;
                        if (0 == 0)
                        {
                            if (0 != 0)
                                ;
                            x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, SystemPens.ControlText);
                            if (0 != 0)
                                goto label_12;
                        }
                        continue;
                    default:
                        goto label_5;
                }
            }
            while (0 != 0);
            goto label_13;
            label_12:
            return;
            label_4:
            x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, SystemPens.ControlText);
            if (3 != 0)
                return;
            else
                return;
            label_13:
            return;
            label_14:
            return;
            label_15:
            return;
            label_5:
            return;
            label_10:
            x9b2777bb8e78938b.xd70a4c1a2378c84e(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
            return;
            label_11:
            x9b2777bb8e78938b.x793dc1a7cf4113f9(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override Size MeasureTabStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
        {
            return xa811784015ed8842.xcdfce0e0f2641503(graphics, image, this.ImageSize, text, font, this.TextFormat);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override Size MeasureDocumentStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
        {
            TextFormatFlags flags = this.TextFormat & ~TextFormatFlags.NoPrefix;
            int width;
            using (Font font1 = new Font(font, FontStyle.Bold))
                width = TextRenderer.MeasureText((IDeviceContext)graphics, text, font1, new Size(int.MaxValue, int.MaxValue), flags).Width;
            int num = width + 14;
            if ((num | 4) == 0 || image != null)
                goto label_3;
            label_1:
            return new System.Drawing.Size(num + this.DocumentTabExtra, 0);
            label_3:
            num += 20;
            goto label_1;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawDockContainerBackground(Graphics graphics, DockContainer container, Rectangle bounds)
        {
            xa811784015ed8842.x91433b5e99eb7cac(graphics, container.BackColor);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawDocumentStripTab(Graphics graphics, Rectangle bounds, Rectangle contentBounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
        {
            bool xb0f87b71823b1d4e = (state & DrawItemState.Checked) == DrawItemState.Checked;
            if (0 != 0 || (state & DrawItemState.Selected) != DrawItemState.Selected)
                xa811784015ed8842.xf8aac789a7846004(graphics, bounds, contentBounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemInformation.HighContrast ? SystemColors.Control : backColor, SystemBrushes.ControlText, this.InactiveDocumentBorderColor, this.x0b2889b8ff5ec580, this.x0e8b6412ec502dbf, false, this.DocumentTabSize, this.DocumentTabExtra, this.TextFormat, xb0f87b71823b1d4e);
            else
                xa811784015ed8842.xf8aac789a7846004(graphics, bounds, contentBounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemBrushes.ControlText, this.ActiveDocumentBorderColor, this.x80caa5727f6ffe52, this.x9196c174a89a4ce4, true, this.DocumentTabSize, this.DocumentTabExtra, this.TextFormat, xb0f87b71823b1d4e);
        }

        internal static bool x7fb2e1ce54a27086()
        {
            bool flag = false;
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                flag = Environment.OSVersion.Version >= new Version(5, 1, 0, 0);
            return flag;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override void StartRenderSession(HotkeyPrefix hotKeys)
        {
            base.StartRenderSession(hotKeys);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawTabStripBackground(Control container, Control control, Graphics graphics, Rectangle bounds, int selectedTabOffset)
        {
            base.DrawTabStripBackground(container, control, graphics, bounds, selectedTabOffset);
            graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Top + 2, bounds.Right - 1, bounds.Top + 2);
            if (SystemInformation.HighContrast)
                return;
            using (Pen pen = new Pen(SystemColors.ControlLightLight))
            {
                graphics.DrawLine(pen, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
                graphics.DrawLine(pen, bounds.Left, bounds.Top + 1, bounds.Right - 1, bounds.Top + 1);
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawTabStripTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
        {
            bounds.Y += 2;
            if (-1 != 0)
                goto label_6;
            label_1:
            graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 2, bounds.Top + 3, bounds.Right - 2, bounds.Bottom - 4);
            if (((drawSeparator ? 1 : 0) | 15) != 0)
                return;
            label_2:
            if (!drawSeparator)
                return;
            else
                goto label_1;
            label_6:
            if (false)
                ;
            bounds.Height -= 2;
            if ((state & DrawItemState.Selected) != DrawItemState.Selected)
                goto label_9;
            else
                goto label_8;
            label_4:
            if ((state & DrawItemState.Selected) == DrawItemState.Selected)
                return;
            else
                goto label_2;
            label_8:
            xa811784015ed8842.x272eca3f5ebfa9fc(graphics, bounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemColors.ControlText, SystemColors.ControlDark, state, this.TextFormat);
            goto label_4;
            label_9:
            xa811784015ed8842.x272eca3f5ebfa9fc(graphics, bounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : backColor, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemColors.ControlDarkDark, SystemColors.ControlDark, state, this.TextFormat);
            goto label_4;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawCollapsedTab(Graphics graphics, Rectangle bounds, DockSide dockSide, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool vertical)
        {
            if (dockSide != DockSide.Left)
            {
                while (0 == 0 && dockSide != DockSide.Right)
                {
                    xa811784015ed8842.x36c79cea8e98cf3c(graphics, bounds, dockSide, image, text, font, SystemBrushes.ControlDarkDark, SystemColors.ControlDark, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
                    if (true)
                        return;
                }
            }
            using (Image xe058541ca798c059 = (Image)new Bitmap(image))
            {
                xe058541ca798c059.RotateFlip(RotateFlipType.Rotate90FlipNone);
                xa811784015ed8842.x36c79cea8e98cf3c(graphics, bounds, dockSide, xe058541ca798c059, text, font, SystemBrushes.ControlDarkDark, SystemColors.ControlDark, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawTitleBarButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state, bool focused, bool toggled)
        {
            this.x9271fbf5eef553db(graphics, bounds, state, focused);
            using (Pen x90279591611601bc = !focused ? new Pen(this.x9a7470f809ffee0d) : new Pen(this.x6b97fa649c9b3a44))
            {
                switch (buttonType)
                {
                    case SandDockButtonType.Close:
                        x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, x90279591611601bc);
                        break;
                    case SandDockButtonType.Pin:
                        x9b2777bb8e78938b.x1477b5a75c8a8132(graphics, bounds, x90279591611601bc, toggled);
                        break;
                    case SandDockButtonType.WindowPosition:
                        x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, x90279591611601bc);
                        break;
                }
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawTitleBarBackground(Graphics graphics, Rectangle bounds, bool focused)
        {
            if (!focused)
                goto label_6;
            label_1:
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new System.Drawing.Point(bounds.X, bounds.Y - 1), new System.Drawing.Point(bounds.X, bounds.Bottom), this.x2d5bde28a1e8ae90, this.xebb7eaf00d600976))
            {
                graphics.FillRectangle((Brush)linearGradientBrush, bounds);
                goto label_11;
            }
            label_6:
            using (SolidBrush solidBrush = new SolidBrush(this.x8e2e7f87608d5b3b))
                graphics.FillRectangle((Brush)solidBrush, bounds);
            label_11:
            graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
            if (true)
            {
                graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
                graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 1, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
            }
            else
                goto label_1;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawTitleBarText(Graphics graphics, Rectangle bounds, bool focused, string text, Font font)
        {
            bounds.Inflate(-3, 0);
            TextFormatFlags flags = this.TextFormat | TextFormatFlags.NoPrefix;
            bounds.X += 3;
            TextRenderer.DrawText((IDeviceContext)graphics, text, font, bounds, focused ? this.x6b97fa649c9b3a44 : this.x9a7470f809ffee0d, flags);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override string ToString()
        {
            return "Whidbey";
        }
    }
}
