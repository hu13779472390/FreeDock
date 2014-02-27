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
        private Color activeDocumentBorderColor;
        private Color inactiveDocumentBorderColor;
        private Color activeDocumentHighlightColor;
        private Color inactiveDocumentHighlightColor;
        private Color activeDocumentShadowColor;
        private Color inactiveDocumentShadowColor;
        private Color documentStripBackgroundColor1;
        private Color documentStripBackgroundColor2;
        private Color inactiveTitleBarBackgroundColor;
        private Color inactiveTitleBarForegroundColor;
        private Color activeTitleBarBackgroundColor1;
        private Color activeTitleBarBackgroundColor2;
        private Color activeTitleBarForegroundColor;
        private Color inactiveButtonBackgroundColor;
        private Color inactiveButtonBorderColor;
        private Color activeButtonBackgroundColor;
        private Color activeButtonBorderColor;
        private Color activeHotButtonBackgroundColor;
        private Color activeHotButtonBorderColor;
        private BoxModel tabStripMetrics;
        private BoxModel tabMetrics;
        private BoxModel titleBarMetrics;

        /// <summary>
        /// The colour used to draw the border around an active document tab.
        /// 
        /// </summary>
        public Color ActiveDocumentBorderColor
        {
            get
            {
                return this.activeDocumentBorderColor;
            }
            set
            {
                this.activeDocumentBorderColor = value;
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
                return this.inactiveDocumentBorderColor;
            }
            set
            {
                this.inactiveDocumentBorderColor = value;
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
                return this.documentStripBackgroundColor1;
            }
            set
            {
                this.documentStripBackgroundColor1 = value;
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
                return this.documentStripBackgroundColor2;
            }
            set
            {
                this.documentStripBackgroundColor2 = value;
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
                return this.activeHotButtonBorderColor;
            }
            set
            {
                this.activeHotButtonBorderColor = value;
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
                return this.activeHotButtonBackgroundColor;
            }
            set
            {
                this.activeHotButtonBackgroundColor = value;
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
                return this.activeButtonBorderColor;
            }
            set
            {
                this.activeButtonBorderColor = value;
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
                return this.activeButtonBackgroundColor;
            }
            set
            {
                this.activeButtonBackgroundColor = value;
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
                return this.inactiveButtonBorderColor;
            }
            set
            {
                this.inactiveButtonBorderColor = value;
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
                return this.inactiveButtonBackgroundColor;
            }
            set
            {
                this.inactiveButtonBackgroundColor = value;
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
                return this.activeTitleBarForegroundColor;
            }
            set
            {
                this.activeTitleBarForegroundColor = value;
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
                return this.activeTitleBarBackgroundColor2;
            }
            set
            {
                this.activeTitleBarBackgroundColor2 = value;
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
                return this.activeTitleBarBackgroundColor1;
            }
            set
            {
                this.activeTitleBarBackgroundColor1 = value;
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
                return this.inactiveTitleBarForegroundColor;
            }
            set
            {
                this.inactiveTitleBarForegroundColor = value;
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
                return this.inactiveTitleBarBackgroundColor;
            }
            set
            {
                this.inactiveTitleBarBackgroundColor = value;
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
                return this.activeDocumentShadowColor;
            }
            set
            {
                this.activeDocumentShadowColor = value;
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
                return this.inactiveDocumentShadowColor;
            }
            set
            {
                this.inactiveDocumentShadowColor = value;
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
                return this.inactiveDocumentHighlightColor;
            }
            set
            {
                this.inactiveDocumentHighlightColor = value;
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
                return this.activeDocumentHighlightColor;
            }
            set
            {
                this.activeDocumentHighlightColor = value;
                this.CustomColors = true;
            }
        }

        /// <summary>
        /// The size of image to draw in window tabs.
        /// 
        /// </summary>
        public override Size ImageSize
        {
            get
            {
                return base.ImageSize;
            }
            set
            {
                this.ClearBoxModels();
                base.ImageSize = value;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override Size TabControlPadding
        {
            get
            {
                return new Size(3, 3);
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
                if (this.titleBarMetrics == null)
                    this.titleBarMetrics = new BoxModel(0, SystemInformation.ToolWindowCaptionHeight, 0, 0, 0, 0, 0, 0, 0, 0);
                return this.titleBarMetrics;
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
                if (this.tabMetrics == null)
                    this.tabMetrics = new BoxModel(0, 0, 0, 0, 0, 0, 0, 0, -1, 0);
                return this.tabMetrics;
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
                if (this.tabStripMetrics == null)
                    this.tabStripMetrics = new BoxModel(0, Math.Max(Control.DefaultFont.Height, this.ImageSize.Height) + 8, 0, 0, 0, 1, 0, 0, 0, 0);
                return this.tabStripMetrics;
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
                this.activeDocumentHighlightColor = SystemColors.ControlLightLight;
                this.inactiveDocumentHighlightColor = SystemColors.ControlLightLight;
                this.activeDocumentShadowColor = SystemColors.ControlLightLight;
                this.inactiveDocumentShadowColor = SystemColors.Control;
            }
            else
            {
                this.activeDocumentHighlightColor = SystemColors.Control;
                this.inactiveDocumentHighlightColor = SystemColors.Control;
                this.activeDocumentShadowColor = SystemColors.Control;
                this.inactiveDocumentShadowColor = SystemColors.Control;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void ApplyStandardColors()
        {
            if (!SystemInformation.HighContrast)
            {
                this.LayoutBackgroundColor1 = SystemColors.Control;
                this.LayoutBackgroundColor2 = RendererBase.InterpolateColors(SystemColors.Control, SystemColors.Window, 0.8f);
                this.ActiveDocumentBorderColor = SystemColors.AppWorkspace;
                this.InactiveDocumentBorderColor = SystemColors.ControlDark;
            }
            else
            {
                this.LayoutBackgroundColor1 = SystemColors.Control;
                this.LayoutBackgroundColor2 = SystemColors.Control;
                this.ActiveDocumentBorderColor = SystemColors.ActiveCaption;
                this.InactiveDocumentBorderColor = SystemColors.ControlDark;
            }
            this.documentStripBackgroundColor1 = SystemColors.Control;
            this.documentStripBackgroundColor2 = this.documentStripBackgroundColor1;
            this.activeTitleBarBackgroundColor1 = SystemColors.ActiveCaption;
            this.activeTitleBarBackgroundColor2 = SystemColors.ActiveCaption;
            this.activeTitleBarForegroundColor = SystemColors.ActiveCaptionText;
            this.inactiveTitleBarBackgroundColor = SystemColors.InactiveCaption;
            this.inactiveTitleBarForegroundColor = SystemColors.InactiveCaptionText;
            this.inactiveButtonBackgroundColor = Color.Transparent;
            this.inactiveButtonBorderColor = SystemColors.ControlLightLight;
            this.activeButtonBackgroundColor = Color.Transparent;
            this.activeButtonBorderColor = SystemColors.ControlLightLight;
            this.activeHotButtonBackgroundColor = SystemInformation.HighContrast ? Color.Transparent : Color.FromArgb(100, SystemColors.Control);
            this.activeHotButtonBorderColor = SystemColors.ControlLightLight;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void ApplyLunaBlueColors()
        {
            this.LayoutBackgroundColor1 = Color.FromArgb(229, 229, 215);
            this.LayoutBackgroundColor2 = Color.FromArgb(243, 242, 231);
            this.documentStripBackgroundColor1 = Color.FromArgb(228, 226, 213);
            this.documentStripBackgroundColor2 = this.documentStripBackgroundColor1;
            this.ActiveDocumentBorderColor = Color.FromArgb((int)sbyte.MaxValue, 157, 185);
            this.InactiveDocumentBorderColor = SystemColors.ControlDark;
            this.activeTitleBarBackgroundColor1 = Color.FromArgb(59, 128, 237);
            this.activeTitleBarBackgroundColor2 = Color.FromArgb(49, 106, 197);
            this.activeTitleBarForegroundColor = Color.White;
            this.inactiveTitleBarBackgroundColor = Color.FromArgb(204, 199, 186);
            this.inactiveTitleBarForegroundColor = Color.Black;
            this.inactiveButtonBackgroundColor = SystemColors.Control;
            this.inactiveButtonBorderColor = Color.FromArgb(140, 134, 123);
            this.activeButtonBackgroundColor = Color.FromArgb(156, 182, 231);
            this.activeButtonBorderColor = Color.FromArgb(60, 90, 170);
            this.activeHotButtonBackgroundColor = Color.FromArgb(120, 150, 210);
            this.activeHotButtonBorderColor = Color.FromArgb(60, 90, 170);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void ApplyLunaOliveColors()
        {
            this.LayoutBackgroundColor1 = Color.FromArgb(229, 229, 215);
            this.LayoutBackgroundColor2 = Color.FromArgb(243, 242, 231);
            this.documentStripBackgroundColor1 = Color.FromArgb(228, 226, 213);
            this.documentStripBackgroundColor2 = this.documentStripBackgroundColor1;
            this.ActiveDocumentBorderColor = Color.FromArgb((int)sbyte.MaxValue, 157, 185);
            this.InactiveDocumentBorderColor = SystemColors.ControlDark;
            this.activeTitleBarBackgroundColor1 = Color.FromArgb(182, 195, 146);
            this.activeTitleBarBackgroundColor2 = Color.FromArgb(145, 160, 117);
            this.activeTitleBarForegroundColor = Color.White;
            this.inactiveTitleBarBackgroundColor = Color.FromArgb(204, 199, 186);
            this.inactiveTitleBarForegroundColor = Color.Black;
            this.inactiveButtonBackgroundColor = SystemColors.Control;
            this.inactiveButtonBorderColor = Color.FromArgb(140, 134, 123);
            this.activeButtonBackgroundColor = Color.FromArgb(181, 199, 140);
            this.activeButtonBorderColor = Color.FromArgb(118, 128, 95);
            this.activeHotButtonBackgroundColor = Color.FromArgb(148, 162, 115);
            this.activeHotButtonBorderColor = Color.FromArgb(118, 128, 95);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void ApplyLunaSilverColors()
        {
            this.LayoutBackgroundColor1 = Color.FromArgb(215, 215, 229);
            this.LayoutBackgroundColor2 = Color.FromArgb(243, 243, 247);
            this.documentStripBackgroundColor1 = Color.FromArgb(238, 238, 238);
            this.documentStripBackgroundColor2 = this.documentStripBackgroundColor1;
            this.ActiveDocumentBorderColor = Color.FromArgb((int)sbyte.MaxValue, 157, 185);
            this.InactiveDocumentBorderColor = SystemColors.ControlDark;
            this.activeTitleBarBackgroundColor1 = Color.FromArgb(211, 212, 221);
            this.activeTitleBarBackgroundColor2 = Color.FromArgb(166, 165, 191);
            this.activeTitleBarForegroundColor = Color.Black;
            this.inactiveTitleBarBackgroundColor = Color.FromArgb(240, 240, 245);
            this.inactiveTitleBarForegroundColor = Color.Black;
            this.inactiveButtonBackgroundColor = Color.FromArgb(214, 215, 222);
            this.inactiveButtonBorderColor = Color.FromArgb(123, 125, 148);
            this.activeButtonBackgroundColor = Color.FromArgb((int)byte.MaxValue, 227, 173);
            this.activeButtonBorderColor = Color.FromArgb(74, 73, 107);
            this.activeHotButtonBackgroundColor = Color.FromArgb((int)byte.MaxValue, 182, 115);
            this.activeHotButtonBorderColor = Color.FromArgb(74, 73, 107);
        }

        private void ClearBoxModels()
        {
            this.tabStripMetrics = null;
            this.tabMetrics = null;
            this.titleBarMetrics = null;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawDocumentStripBackground(Graphics graphics, Rectangle bounds)
        {
            if (bounds.Width <= 0 || (int)byte.MaxValue == 0 || bounds.Height <= 0)
                return;
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(bounds.X, bounds.Y - 1), new Point(bounds.X, bounds.Bottom), this.documentStripBackgroundColor1, this.documentStripBackgroundColor2))
                graphics.FillRectangle(brush, bounds);
            using (Pen pen = new Pen(this.activeDocumentBorderColor))
                graphics.DrawLine(pen, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
        }

        internal virtual void DrawTitleBarButtonBorder(Graphics g, Rectangle bounds, DrawItemState state, bool xb0f87b71823b1d4e)
        {
            if ((state & DrawItemState.HotLight) != DrawItemState.HotLight)
                return;
            Color color1;
            Color color2;
            Color color3;
            if (xb0f87b71823b1d4e)
            {
                if ((state & DrawItemState.Selected) != DrawItemState.Selected)
                {
                    color1 = this.activeButtonBorderColor;
                    color2 = this.activeButtonBorderColor;
                    color3 = this.activeButtonBackgroundColor;
                }
                else
                {
                    color1 = this.activeHotButtonBorderColor;
                    color2 = this.activeHotButtonBorderColor;
                    color3 = this.activeHotButtonBackgroundColor;
                }
            }
            else
            {
                color1 = this.inactiveButtonBorderColor;
                color2 = this.inactiveButtonBorderColor;
                color3 = this.inactiveButtonBackgroundColor;
            }
            using (SolidBrush solidBrush = new SolidBrush(color3))
                g.FillRectangle((Brush)solidBrush, bounds);

            using (Pen pen = new Pen(color1))
            {
                g.DrawLine(pen, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
                g.DrawLine(pen, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
            }
            using (Pen pen = new Pen(color2))
            {
                g.DrawLine(pen, bounds.Right - 1, bounds.Bottom - 1, bounds.Right - 1, bounds.Top);
                g.DrawLine(pen, bounds.Right - 1, bounds.Bottom - 1, bounds.Left, bounds.Bottom - 1);
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
            using (SolidBrush brush = new SolidBrush(backColor))
                graphics.FillRectangle(brush, bounds);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawDocumentStripButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state)
        {
            this.DrawTitleBarButtonBorder(graphics, bounds, state, true);
            switch (buttonType)
            {
                case SandDockButtonType.Close:
                case SandDockButtonType.Pin:
                    ButtonDrawingHelper.DrawCloseButton(graphics, bounds, SystemPens.ControlText);
                    break;
                case SandDockButtonType.ScrollLeft:
                    ButtonDrawingHelper.DrawScrollLeft(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
                    break;
                case SandDockButtonType.ScrollRight:
                    ButtonDrawingHelper.DrawScrollRight(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
                    break;
                case SandDockButtonType.WindowPosition:
                    break;
                case SandDockButtonType.ActiveFiles:
                    bounds.Inflate(1, 1);
                    --bounds.X;
                    ButtonDrawingHelper.DrawActiveFiles(graphics, bounds, SystemPens.ControlText);
                    break;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override Size MeasureTabStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
        {
            return RenderHelper.xcdfce0e0f2641503(graphics, image, this.ImageSize, text, font, this.TextFormat);
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
                width = TextRenderer.MeasureText(graphics, text, font1, new Size(int.MaxValue, int.MaxValue), flags).Width;
            int num = width + 14;
            if (image != null)
                num += 20;
            return new System.Drawing.Size(num + this.DocumentTabExtra, 0);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawDockContainerBackground(Graphics graphics, DockContainer container, Rectangle bounds)
        {
            RenderHelper.ClearBackground(graphics, container.BackColor);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawDocumentStripTab(Graphics graphics, Rectangle bounds, Rectangle contentBounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
        {
            bool flag = (state & DrawItemState.Checked) == DrawItemState.Checked;
            if ((state & DrawItemState.Selected) != DrawItemState.Selected)
                RenderHelper.xf8aac789a7846004(graphics, bounds, contentBounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemInformation.HighContrast ? SystemColors.Control : backColor, SystemBrushes.ControlText, this.InactiveDocumentBorderColor, this.inactiveDocumentHighlightColor, this.inactiveDocumentShadowColor, false, this.DocumentTabSize, this.DocumentTabExtra, this.TextFormat, flag);
            else
                RenderHelper.xf8aac789a7846004(graphics, bounds, contentBounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemBrushes.ControlText, this.ActiveDocumentBorderColor, this.activeDocumentHighlightColor, this.activeDocumentShadowColor, true, this.DocumentTabSize, this.DocumentTabExtra, this.TextFormat, flag);
        }

        internal static bool x7fb2e1ce54a27086()
        {
            bool flag = false;
//            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
//                flag = Environment.OSVersion.Version >= new Version(5, 1, 0, 0);
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
            bounds.Height -= 2;
            if ((state & DrawItemState.Selected) == DrawItemState.Selected)
                RenderHelper.x272eca3f5ebfa9fc(graphics, bounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemColors.ControlText, SystemColors.ControlDark, state, this.TextFormat);
            else
                RenderHelper.x272eca3f5ebfa9fc(graphics, bounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : backColor, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemColors.ControlDarkDark, SystemColors.ControlDark, state, this.TextFormat);
            if ((state & DrawItemState.Selected) == DrawItemState.Selected || !drawSeparator)
                return;
            graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 2, bounds.Top + 3, bounds.Right - 2, bounds.Bottom - 4);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawCollapsedTab(Graphics graphics, Rectangle bounds, DockSide dockSide, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool vertical)
        {
            if (dockSide == DockSide.Left || dockSide == DockSide.Right)
            {
                using (Image img = new Bitmap(image))
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    RenderHelper.x36c79cea8e98cf3c(graphics, bounds, dockSide, img, text, font, SystemBrushes.ControlDarkDark, SystemColors.ControlDark, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
                }
            }
            else
                RenderHelper.x36c79cea8e98cf3c(graphics, bounds, dockSide, image, text, font, SystemBrushes.ControlDarkDark, SystemColors.ControlDark, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void DrawTitleBarButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state, bool focused, bool toggled)
        {
            this.DrawTitleBarButtonBorder(graphics, bounds, state, focused);
            using (Pen pen = !focused ? new Pen(this.inactiveTitleBarForegroundColor) : new Pen(this.activeTitleBarForegroundColor))
            {
                switch (buttonType)
                {
                    case SandDockButtonType.Close:
                        ButtonDrawingHelper.DrawCloseButton(graphics, bounds, pen);
                        break;
                    case SandDockButtonType.Pin:
                        ButtonDrawingHelper.DrawPinButton(graphics, bounds, pen, toggled);
                        break;
                    case SandDockButtonType.WindowPosition:
                        ButtonDrawingHelper.DrawActiveFiles(graphics, bounds, pen);
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
            if (focused)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(new System.Drawing.Point(bounds.X, bounds.Y - 1), new System.Drawing.Point(bounds.X, bounds.Bottom), this.activeTitleBarBackgroundColor1, this.activeTitleBarBackgroundColor2))
                    graphics.FillRectangle(brush, bounds);
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(this.inactiveTitleBarBackgroundColor))
                    graphics.FillRectangle(brush, bounds);
            }
            graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
            graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
            graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 1, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
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
            TextRenderer.DrawText((IDeviceContext)graphics, text, font, bounds, focused ? this.activeTitleBarForegroundColor : this.inactiveTitleBarForegroundColor, flags);
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
