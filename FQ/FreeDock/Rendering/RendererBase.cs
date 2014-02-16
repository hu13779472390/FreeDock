using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using FQ.FreeDock;

namespace FQ.FreeDock.Rendering
{
    /// <summary>
    /// Provides a base class for renders to drive from.
    /// 
    /// </summary>
    [TypeConverter(typeof(x9c9262004128fe00))]
    public abstract class RendererBase : ITabControlRenderer, IDisposable
    {
        private System.Drawing.Size imageSize = new System.Drawing.Size(16, 16);
        private bool customColors;

        /// <summary>
        /// Indicates whether custom colours have been configured on this renderer.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// To go back to system default colours, set this property to false.
        /// </para>
        /// 
        /// </remarks>
        public bool CustomColors
        {
            get
            {
                return this.customColors;
            }
            set
            {
                this.customColors = value;
                if (this.customColors)
                {
                    return;
                }
                this.GetColorsFromSystem();
             }
        }

        /// <summary>
        /// Gets the metrics of a tabstrip.
        /// 
        /// </summary>
        protected internal abstract BoxModel TabStripMetrics { get; }

        /// <summary>
        /// Gets the metrics of a tab.
        /// 
        /// </summary>
        protected internal abstract BoxModel TabMetrics { get; }

        /// <summary>
        /// Gets the metrics of a title bar.
        /// 
        /// </summary>
        protected internal abstract BoxModel TitleBarMetrics { get; }

        /// <summary>
        /// Gets the size of images used inside tabs.
        /// 
        /// </summary>
        public virtual System.Drawing.Size ImageSize
        {
            get
            {
                return this.imageSize;
            }
            set
            {
                this.imageSize = value;
                this.OnMetricsChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Determines what type of text to display on collapsed tabs.
        /// 
        /// </summary>
        protected internal abstract TabTextDisplayMode TabTextDisplay { get; }

        /// <summary>
        /// Gets the extra padding to insert before a document tab.
        /// 
        /// </summary>
        protected internal abstract int DocumentTabExtra { get; }

        /// <summary>
        /// Gets the height of a document tab.
        /// 
        /// </summary>
        protected internal abstract int DocumentTabSize { get; }

        /// <summary>
        /// Gets the height of a document tab strip.
        /// 
        /// </summary>
        protected internal abstract int DocumentTabStripSize { get; }

        /// <summary>
        /// See the ITabControlRenderer interface documentation for description.
        /// 
        /// </summary>
        public virtual bool ShouldDrawControlBorder
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
        public virtual bool ShouldDrawTabControlBackground
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public abstract System.Drawing.Size TabControlPadding { get; }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public virtual int TabControlTabExtra
        {
            get
            {
                return this.DocumentTabExtra;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public virtual int TabControlTabStripHeight
        {
            get
            {
                return this.DocumentTabStripSize;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public virtual int TabControlTabHeight
        {
            get
            {
                return this.DocumentTabSize;
            }
        }

        /// <summary>
        /// Raised when measurement metrics have changed.
        /// 
        /// </summary>
        public event EventHandler MetricsChanged;

        /// <summary>
        /// Initializes a new instance of the RendererBase class.
        /// 
        /// </summary>
        public RendererBase()
        {
            SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(this.x985016783c040310);
            this.GetColorsFromSystem();
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public void Dispose()
        {
            SystemEvents.UserPreferenceChanged -= new UserPreferenceChangedEventHandler(this.x985016783c040310);
        }

        /// <summary>
        /// Raises the MetricsChanged event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected virtual void OnMetricsChanged(EventArgs e)
        {
            if (this.MetricsChanged != null)
                this.MetricsChanged(this, e);
        }

        /// <summary>
        /// Gives the renderer a chance to alter the default colors of a window before it is drawn.
        /// 
        /// </summary>
        /// <param name="window">The window in question.</param><param name="backColor">The background color of the window.</param><param name="borderColor">The border color of the window.</param>
        public virtual void ModifyDefaultWindowColors(DockControl window, ref System.Drawing.Color backColor, ref System.Drawing.Color borderColor)
        {
        }

        private void x985016783c040310(object xe0292b9ed559da7d, UserPreferenceChangedEventArgs xfbf34718e704c6bc)
        {
            if (xfbf34718e704c6bc.Category != UserPreferenceCategory.Color || this.customColors)
                return;
            this.GetColorsFromSystem();
        }

        /// <summary>
        /// Mixes two colours together to form a new colour.
        /// 
        /// </summary>
        /// <param name="color1">The first source colour.</param><param name="color2">The second source colour.</param><param name="percentage">A value that lies between 0 and 1, 0 being the first colour and 1 being the second.</param>
        /// <returns>
        /// The new colour produced after mixing.
        /// </returns>
        protected internal static System.Drawing.Color InterpolateColors(System.Drawing.Color c1, System.Drawing.Color c2, float percentage)
        {
            int A = (int)((float)c1.A + (float)(c2.A - c1.A) * percentage);
            int R = (int)((float)c1.R + (float)(c2.R - c1.R) * percentage);
            int G = (int)((float)c1.G + (float)(c2.G - c1.G) * percentage);
            int B = (int)((float)c1.B + (float)(c2.B - c1.B) * percentage);
            return System.Drawing.Color.FromArgb(A, R, G, B);

        }

        /// <summary>
        /// Calculates the base colours used by the renderer, based on the current Windows colour scheme or visual style.
        /// 
        /// </summary>
        protected virtual void GetColorsFromSystem()
        {
            this.customColors = false;
        }

        /// <summary>
        /// Requests that the renderer perform any adjustments to the client rectangle of a DockControl before it is applied.
        /// 
        /// </summary>
        /// <param name="layoutSystem">The layout system to which the control belongs.</param><param name="control">The control that will be laid out in the calculated area.</param><param name="clientBounds">The suggested client rectangle for the control.</param>
        /// <returns>
        /// The adjusted bounds of the control.
        /// </returns>
        protected internal virtual Rectangle AdjustDockControlClientBounds(ControlLayoutSystem layoutSystem, DockControl control, Rectangle clientBounds)
        {
            return clientBounds;
        }

        /// <summary>
        /// Measures a document strip tab in order to find the minimum required size.
        /// 
        /// </summary>
        /// <param name="graphics">The Graphics object to measure with.</param><param name="image">The image of the document tab.</param><param name="text">The text of the document tab.</param><param name="font">The font to render text with.</param><param name="state">The state of the document tab.</param>
        /// <returns>
        /// The minimum size of the document tab.
        /// </returns>
        protected internal abstract System.Drawing.Size MeasureDocumentStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state);

        /// <summary>
        /// Measures a tabstrip tab in order to find the minimum required size.
        /// 
        /// </summary>
        /// <param name="graphics">The Graphics object to measure with.</param><param name="image">The image of the document tab.</param><param name="text">The text of the document tab.</param><param name="font">The font to render text with.</param><param name="state">The state of the document tab.</param>
        /// <returns>
        /// The minimum size of the document tab.
        /// </returns>
        protected internal abstract System.Drawing.Size MeasureTabStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state);

        /// <summary>
        /// Draws the background of a document strip.
        /// 
        /// </summary>
        /// <param name="graphics">The Graphics object to draw with.</param><param name="bounds">The bounds to draw within.</param>
        protected internal abstract void DrawDocumentStripBackground(Graphics graphics, Rectangle bounds);

        /// <summary>
        /// Draws the background of the client area of a control.
        /// 
        /// </summary>
        /// <param name="graphics">The Graphics object to draw with.</param><param name="bounds">The bounds to draw within.</param><param name="backColor">The background colour of the selected control.</param>
        protected internal abstract void DrawControlClientBackground(Graphics graphics, Rectangle bounds, System.Drawing.Color backColor);

        /// <summary>
        /// Draws the background of the client area of a document.
        /// 
        /// </summary>
        /// <param name="graphics">The Graphics object to draw with.</param><param name="bounds">The bounds to draw within.</param><param name="backColor">The background colour of the selected document.</param>
        protected internal abstract void DrawDocumentClientBackground(Graphics graphics, Rectangle bounds, System.Drawing.Color backColor);

        /// <summary>
        /// Draws a tab in a document strip.
        /// 
        /// </summary>
        /// <param name="graphics">The Graphics object to draw with.</param><param name="bounds">The bounds occupied by the tab.</param><param name="contentBounds">The bounds around the content of the tab (without any buttons).</param><param name="image">The image associated with the tab.</param><param name="text">The text associated with the tab.</param><param name="font">The font to draw text with.</param><param name="backColor">The background colour of the tab.</param><param name="foreColor">The foreground colour of the tab.</param><param name="state">The state of the tab.</param><param name="drawSeparator">Whether to draw a separator after the tab.</param>
        protected internal abstract void DrawDocumentStripTab(Graphics graphics, Rectangle bounds, Rectangle contentBounds, Image image, string text, Font font, System.Drawing.Color backColor, System.Drawing.Color foreColor, DrawItemState state, bool drawSeparator);

        /// <summary>
        /// Draws the background of a <see cref="T:TD.SandDock.DockContainer"/>.
        /// 
        /// </summary>
        /// <param name="graphics">The Graphics object to draw with.</param><param name="container">The DockContainer whose background will be drawn.</param><param name="bounds">The bounds occupied by the control.</param>
        /// <remarks>
        /// 
        /// <para>
        /// Implementors should ensure that all the region given is painted within this method. It is safe to use the Graphics.Clear method.
        /// </para>
        /// 
        /// </remarks>
        protected internal abstract void DrawDockContainerBackground(Graphics graphics, DockContainer container, Rectangle bounds);

        /// <summary>
        /// Draws a button on a document strip.
        /// 
        /// </summary>
        /// <param name="graphics">The Graphics object to draw with.</param><param name="bounds">The region occupied by the button.</param><param name="buttonType">The type of button to draw.</param><param name="state">The state of the button.</param>
        protected internal abstract void DrawDocumentStripButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state);

        /// <summary>
        /// Initializes any drawing objects used during the render process.
        /// 
        /// </summary>
        /// <param name="hotKeys">Determines how the renderer should handle keyboard mnemonics in text.</param>
        public abstract void StartRenderSession(HotkeyPrefix hotKeys);

        /// <summary>
        /// Draws the background of a tabstrip within a control layout system.
        /// 
        /// </summary>
        /// <param name="container">The container control that contains the control to draw on. This parameter can be a null reference.</param><param name="control">The control whose surface will be drawn on.</param><param name="graphics">The Graphics object to draw with.</param><param name="bounds">The bounds to draw within.</param><param name="selectedTabOffset">The offset, in pixels, of the selected tab within this tabstrip along the x axis.</param>
        protected internal abstract void DrawTabStripBackground(Control container, Control control, Graphics graphics, Rectangle bounds, int selectedTabOffset);

        /// <summary>
        /// Draws a splitter.
        /// 
        /// </summary>
        /// <param name="container">The container control that contains the control to draw on. This parameter can be a null reference.</param><param name="control">The control whose surface will be drawn on.</param><param name="graphics">The Graphics object to draw with.</param><param name="bounds">The region occupied by the splitter.</param><param name="orientation">The orientation of the splitter.</param>
        /// <remarks>
        /// 
        /// <para>
        /// Since the background of the DockContainer will already have been drawn, this method can safely do nothing.
        /// </para>
        /// 
        /// </remarks>
        protected internal abstract void DrawSplitter(Control container, Control control, Graphics graphics, Rectangle bounds, Orientation orientation);

        /// <summary>
        /// Draws a tab in a tabstrip within a control layout system.
        /// 
        /// </summary>
        /// <param name="graphics">The Graphics object to draw with.</param><param name="bounds">The bounds to draw within.</param><param name="image">The image associated with this tab.</param><param name="text">The text associated with this tab.</param><param name="font">The font to draw the text with.</param><param name="backColor">The background colour of the tab.</param><param name="foreColor">The foreground colour of the tab.</param><param name="state">The state of the tab. This is equal to DrawItemState.Default by default.</param><param name="drawSeparator">Whether to draw a separator at the right of this tab.</param>
        protected internal abstract void DrawTabStripTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, System.Drawing.Color backColor, System.Drawing.Color foreColor, DrawItemState state, bool drawSeparator);

        /// <summary>
        /// Draws the background of the area occupied by collapsed control layout systems.
        /// 
        /// </summary>
        /// <param name="container">The container control that contains the control to draw on.</param><param name="control">The control whose surface will be drawn on.</param><param name="graphics">The Graphics object to draw with.</param><param name="bounds">The bounds to draw within.</param>
        protected internal abstract void DrawAutoHideBarBackground(Control container, Control control, Graphics graphics, Rectangle bounds);

        /// <summary>
        /// Draws a tab within the area occupied by collapsed control layout systems.
        /// 
        /// </summary>
        /// <param name="graphics">The Graphics object to draw with.</param><param name="bounds">The bounds to draw within.</param><param name="dockSide">The orientation of this tab. This will never be DockSide.None.</param><param name="image">The image associated with this tab.</param><param name="text">The text associated with this tab. This will be a zero-length string unless the tab is selected.</param><param name="font">The font to draw the text with.</param><param name="backColor">The background colour of the tab.</param><param name="foreColor">The foreground colour of the tab.</param><param name="state">The state of the tab. This is equal to DrawItemState.Default by default.</param><param name="vertical">Whether this tab is drawn vertically.</param>
        protected internal abstract void DrawCollapsedTab(Graphics graphics, Rectangle bounds, DockSide dockSide, Image image, string text, Font font, System.Drawing.Color backColor, System.Drawing.Color foreColor, DrawItemState state, bool vertical);

        /// <summary>
        /// Draws the background of a titlebar within a control layout system.
        /// 
        /// </summary>
        /// <param name="graphics">The Graphics object to draw with.</param><param name="bounds">The bounds to draw within.</param><param name="focused">Whether the titlebar is drawn in an active state.</param>
        protected internal abstract void DrawTitleBarBackground(Graphics graphics, Rectangle bounds, bool focused);

        /// <summary>
        /// Draws the text in the titlebar within a control layout system.
        /// 
        /// </summary>
        /// <param name="graphics">The Graphics object to draw with.</param><param name="bounds">The bounds to draw within.</param><param name="focused">Whether the titlebar is drawn in an active state.</param><param name="text">The text associated with this titlebar.</param><param name="font">The font to draw the text with.</param>
        protected internal abstract void DrawTitleBarText(Graphics graphics, Rectangle bounds, bool focused, string text, Font font);

        /// <summary>
        /// Draws a button in the titlebar within a control layout system.
        /// 
        /// </summary>
        /// <param name="graphics">The Graphics object to draw with.</param><param name="bounds">The bounds to draw within.</param><param name="buttonType">The type of button to draw.</param><param name="state">The state of the button. This is equal to DrawItemState.Default by default.</param><param name="focused">Whether the titlebar is drawn in an active state.</param><param name="toggled">Whether the button is toggled.</param>
        protected internal abstract void DrawTitleBarButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state, bool focused, bool toggled);

        /// <summary>
        /// Cleans up any drawing objects used during the render process.
        /// 
        /// </summary>
        public abstract void FinishRenderSession();

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public virtual void DrawFakeTabControlBackgroundExtension(Graphics graphics, Rectangle bounds, System.Drawing.Color backColor)
        {
            using (SolidBrush solidBrush = new SolidBrush(backColor))
            {
                graphics.FillRectangle(solidBrush, bounds);
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public virtual void DrawTabControlButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state)
        {
            this.DrawDocumentStripButton(graphics, bounds, buttonType, state);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public virtual void DrawTabControlBackground(Graphics graphics, Rectangle bounds, System.Drawing.Color backColor, bool client)
        {
            using (SolidBrush solidBrush = new SolidBrush(backColor))
            {
                graphics.FillRectangle(solidBrush, bounds);
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public virtual System.Drawing.Size MeasureTabControlTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
        {
            return this.MeasureDocumentStripTab(graphics, image, text, font, state);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public virtual void DrawTabControlTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, System.Drawing.Color backColor, System.Drawing.Color foreColor, DrawItemState state, bool drawSeparator)
        {
            this.DrawDocumentStripTab(graphics, bounds, bounds, image, text, font, backColor, foreColor, state, drawSeparator);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public virtual void DrawTabControlTabStripBackground(Graphics graphics, Rectangle bounds, System.Drawing.Color backColor)
        {
            this.DrawDocumentStripBackground(graphics, bounds);
        }
    }
}
