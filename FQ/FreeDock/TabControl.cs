//using Divelements.Util.Registration;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using FQ.FreeDock.Rendering;

namespace FQ.FreeDock
{
    /// <summary>
    /// An extended DockContainer suitable for use as a simple tab control.
    /// 
    /// </summary>
    //	[LicenseProvider(typeof(x294bd621a33dc533))]
    [Designer("TD.SandDock.Design.TabControlDesigner, SandDock.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
    [DefaultEvent("SelectedPageChanged")]
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(TabControl))]
    [DefaultProperty("TabLayout")]
    public class TabControl : Control
    {
        private FQ.FreeDock.Rendering.BorderStyle borderStyle = FQ.FreeDock.Rendering.BorderStyle.Flat;
        private const int x1e9b7c427b6c44fa = 14;
        private const int x26539fe4604823df = 15;
        private ITabControlRenderer render;
        private static bool xc700d1f31b5ce30a;
        private TabControl.TabPageCollection tabPages;
        private TabPage selectedPage;
        //		private xbd7c5470fc89975b x266365ea27fa7af8;
        private TabLayout tabLayout;
        private Rectangle tabStripBounds;
        private Rectangle x21ed2ecc088ef4e4;
        private Rectangle x38c1fce82bb0e828;
        private int x200b7f5a9d983ba4;
        private int x4f8ccd50477a481e;
        private Timer timer;
        private SandDockButton scrollLeftButton;
        private SandDockButton scrollRightButton;
        private SandDockButton highlightedButton;
        private bool selected;

        internal SandDockButton HighlightedButton
        {
            get
            {
                return this.highlightedButton;
            }
            set
            {
                if (value == this.highlightedButton)
                    return;
                if (this.highlightedButton != null)
                    this.Invalidate(this.tabStripBounds);
                this.highlightedButton = value;
                if (this.highlightedButton == null)
                    return;
                this.Invalidate(this.tabStripBounds);
            }
        }

        /// <summary>
        /// How the tabs of child controls are laid out.
        /// 
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(TabLayout), "SingleLineScrollable")]
        [Description("How the tabs of child controls are laid out.")]
        public TabLayout TabLayout
        {
            get
            {
                return this.tabLayout;
            }
            set
            {
                this.tabLayout = value;
                this.CalculateAllMetricsAndLayout();
                this.PerformLayout();
            }
        }

        /// <summary>
        /// The renderer used to calculate object metrics and draw contents.
        /// 
        /// </summary>
        // reviewed
        [TypeConverter(typeof(NoDefaultRenderConverter))]
        [RefreshProperties(RefreshProperties.All)]
        [Category("Appearance")]
        [Description("The renderer used to calculate object metrics and draw contents.")]
        public ITabControlRenderer Renderer
        {
            get
            {
                return this.render;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (this.render is IDisposable)
                    ((IDisposable)this.render).Dispose();
                if (this.render is RendererBase)
                    ((RendererBase)this.render).MetricsChanged -= new EventHandler(this.OnMetricsChanged);
                this.render = value;
                if (value.ShouldDrawControlBorder && this.BorderStyle == FQ.FreeDock.Rendering.BorderStyle.None)
                    this.BorderStyle = FQ.FreeDock.Rendering.BorderStyle.Flat;
                else if (!value.ShouldDrawControlBorder && this.BorderStyle != FQ.FreeDock.Rendering.BorderStyle.None)
                    this.BorderStyle = FQ.FreeDock.Rendering.BorderStyle.None;
                if (this.render is RendererBase)
                    ((RendererBase)this.render).MetricsChanged += new EventHandler(this.OnMetricsChanged);
                this.CalculateAllMetricsAndLayout();
                this.PerformLayout();
            }
        }

        /// <summary>
        /// Indicates whether the user will be able to scroll when the tabs exceed the width of the control.
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [Obsolete("Use the TabLayout property instead.")]
        public bool AllowScrolling
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed
        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle displayRectangle = base.DisplayRectangle;
                switch (this.borderStyle)
                {
                    case FQ.FreeDock.Rendering.BorderStyle.Flat:
                    case FQ.FreeDock.Rendering.BorderStyle.RaisedThin:
                    case FQ.FreeDock.Rendering.BorderStyle.SunkenThin:
                        displayRectangle.Inflate(-1, -1);
                        break;
                    case FQ.FreeDock.Rendering.BorderStyle.RaisedThick:
                    case FQ.FreeDock.Rendering.BorderStyle.SunkenThick:
                        displayRectangle.Inflate(-2, -2);
                        break;
                }
                return displayRectangle;
            }
        }

        /// <summary>
        /// The type of border to be drawn around the control.
        /// 
        /// </summary>
        [Category("Appearance")]
        [Description("The type of border to be drawn around the control.")]
        [DefaultValue(typeof(FQ.FreeDock.Rendering.BorderStyle), "Flat")]
        public FQ.FreeDock.Rendering.BorderStyle BorderStyle
        {
            get
            {
                return this.borderStyle;
            }
            set
            {
                this.borderStyle = value;
                this.CalculateAllMetricsAndLayout();
                this.PerformLayout();
            }
        }

        /// <summary>
        /// A collection of TabPage controls belonging to this control.
        /// 
        /// </summary>
        [Description("A collection of TabPage controls belonging to this control.")]
        [Category("Behavior")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TabControl.TabPageCollection TabPages
        {
            get
            {
                return this.tabPages;  
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(300, 200);
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        /// <summary>
        /// Indicates the numeric index of the currently selected page within the control.
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int SelectedIndex
        {
            get
            {
                return this.TabPages.IndexOf(this.SelectedPage);
            }
            set
            {
                this.SelectedPage = this.TabPages[value];
            }
        }

        /// <summary>
        /// Indicates the page that is currently selected within the control.
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        // reviewd!!
        public TabPage SelectedPage
        {
            get
            {
                return this.selectedPage;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (!this.Controls.Contains(value))
                    throw new ArgumentException("Specified TabPage does not belong to this TabControl.");

                this.selectedPage = value;
                this.CalculateAllMetricsAndLayout();
                this.SuspendLayout();
                foreach (TabPage tabPage in this.TabPages)
                    tabPage.Visible = tabPage == this.selectedPage;
                this.ResumeLayout();
                this.OnSelectedPageChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// This property is obsolete and provided for backward compatibility reasons only.
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete]
        public SplitLayoutSystem LayoutSystem
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>
        /// The area of the control occupied by the tabstrip.
        /// 
        /// </summary>
        [Browsable(false)]
        public Rectangle TabStripBounds
        {
            get
            {
                return this.tabStripBounds;
            }
        }

        /// <summary>
        /// Raised when the SelectedPage property changes.
        /// 
        /// </summary>
        public event EventHandler SelectedPageChanged;

        static TabControl()
        {
        }

        /// <summary>
        /// Initializes a new instance of the TabControl class.
        /// 
        /// </summary>
        // reviewd!
        public TabControl()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.render = new MilborneRenderer();
            this.tabPages = new TabControl.TabPageCollection(this);
            this.scrollLeftButton = new SandDockButton();
            this.scrollRightButton = new SandDockButton();
            this.timer = new Timer();
            this.timer.Interval = 20;
            this.timer.Tick += new EventHandler(this.OnTimerTick);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new TabPageControlCollection(this);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.render is IDisposable)
                    ((IDisposable)this.render).Dispose();
                this.timer.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            this.Renderer.StartRenderSession(this.ShowKeyboardCues ? HotkeyPrefix.Show : HotkeyPrefix.Hide);
            DockControl.DoPaint(this, e.Graphics, this.borderStyle);
            this.render.DrawTabControlTabStripBackground(e.Graphics, this.tabStripBounds, this.BackColor);
            Region region = null;
            if (this.TabLayout == TabLayout.SingleLineScrollable)
            {
                region = e.Graphics.Clip;
                Rectangle rect = this.tabStripBounds;
                rect.Width -= this.tabStripBounds.Right - this.scrollLeftButton.Bounds.Left;
                e.Graphics.SetClip(rect);
            }
            if (this.TabLayout == TabLayout.MultipleLine)
                this.xe03691727ff38b10(e.Graphics);
            else
            {
                for (int i = this.Controls.Count - 1; i >= 0; --i)
                    this.xc33f5f7a18a754cb(e.Graphics, (TabPage)this.Controls[i]);
            }
            if (this.SelectedPage != null)
                this.xc33f5f7a18a754cb(e.Graphics, this.SelectedPage);
            if (this.TabLayout == TabLayout.SingleLineScrollable)
                e.Graphics.Clip = region;
            if (this.SelectedPage != null)
                this.render.DrawTabControlBackground(e.Graphics, this.x21ed2ecc088ef4e4, this.SelectedPage.BackColor, false);
            if (this.TabLayout == TabLayout.SingleLineScrollable)
            {
                this.xb30ec7cfdf3e5c19(e.Graphics, this.render, this.scrollRightButton, SandDockButtonType.ScrollRight, this.scrollRightButton.x2fef7d841879a711);
                this.xb30ec7cfdf3e5c19(e.Graphics, this.render, this.scrollLeftButton, SandDockButtonType.ScrollLeft, this.scrollLeftButton.x2fef7d841879a711);
            }
            this.Renderer.FinishRenderSession();

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(30, Color.Black)))
            {
                using (Font font = new Font(this.Font.FontFamily.Name, 14f, FontStyle.Bold))
                    e.Graphics.DrawString("evaluationtab", font, brush, (this.tabStripBounds.Left + 4), (this.tabStripBounds.Top - 4), StringFormat.GenericTypographic);
            }
        }

        private void xb30ec7cfdf3e5c19(Graphics g, ITabControlRenderer render, SandDockButton button, SandDockButtonType buttonType, bool enabled)
        {
            if (!button.Enabled)
                return;
            DrawItemState state = DrawItemState.Default;
            if (this.HighlightedButton == button)
            {
                state |= DrawItemState.HotLight;
                if (this.selected)
                    state |= DrawItemState.Selected;
            }
            if (!enabled)
                state |= DrawItemState.Disabled;
            render.DrawTabControlButton(g, button.Bounds, buttonType, state);
        }
        // reviewd with 2.4
        private void xe03691727ff38b10(Graphics graphics)
        {
            ArrayList arrayList = new ArrayList();
            foreach (TabPage tabPage in this.Controls)
            {
                if (!arrayList.Contains(tabPage.xa806b754814b9ae0))
                    arrayList.Add(tabPage.xa806b754814b9ae0);
            }

            int[] array = (int[])arrayList.ToArray(typeof(int));
            Array.Sort<int>(array);
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = this.Controls.Count - 1; j >= 0; --j)
                {
                    TabPage tabPage = (TabPage)this.Controls[j];
                    if (tabPage.xa806b754814b9ae0 == array[i])
                    {
                        this.xc33f5f7a18a754cb(graphics, tabPage);
                        if (i < array.Length - 1)
                        {
                            Rectangle bounds = tabPage.tabBounds;
                            bounds.X = this.tabStripBounds.X;
                            bounds.Width = this.tabStripBounds.Width;
                            bounds.Y = bounds.Bottom - 1;
                            bounds.Height = this.x21ed2ecc088ef4e4.Y - bounds.Y - 2;
                            this.render.DrawFakeTabControlBackgroundExtension(graphics, bounds, tabPage.BackColor);
                        }
                    }
                }
            }
        }
        // reviewed with 2.4
        private void xc33f5f7a18a754cb(Graphics g, TabPage tabPage)
        {
            DrawItemState state = DrawItemState.Default;
            if (tabPage == this.SelectedPage)
            {
                state |= DrawItemState.Selected;
                if (this.Focused && this.ShowFocusCues)
                    state |= DrawItemState.Checked;
            }
            this.Renderer.DrawTabControlTab(g, tabPage.tabBounds, tabPage.TabImage, tabPage.Text, this.Font, tabPage.BackColor, tabPage.ForeColor, state, true);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewd with 2.4
        protected override void OnLayout(LayoutEventArgs levent)
        {
            if (this.x38c1fce82bb0e828.Width > 0 && this.x38c1fce82bb0e828.Height > 0)
            {
                foreach (Control control in this.Controls)
                    control.Bounds = this.x38c1fce82bb0e828;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            this.CalculateAllMetricsAndLayout();
            base.OnResize(e);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            this.CalculateAllMetricsAndLayout();
            this.PerformLayout();
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed with 2.4
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            if (this.SelectedPage == e.Control)
            {
                if (this.TabPages.Count != 0)
                    this.SelectedPage = this.TabPages[0];
                else
                {
                    this.selectedPage = null;
                    this.OnSelectedPageChanged(EventArgs.Empty);
                }
            }

            this.CalculateAllMetricsAndLayout();
            this.PerformLayout();
        }
        // reviewed with 2.4
        internal void CalculateAllMetricsAndLayout()
        {
            if (!this.IsHandleCreated)
                return;
            ITabControlRenderer renderer = this.Renderer;
            using (Graphics graphics = this.CreateGraphics())
            {
                renderer.StartRenderSession(HotkeyPrefix.Hide);
                foreach (TabPage tabPage in  this.Controls)
                {
                    tabPage.xcfac6723d8a41375 = false;
                    DrawItemState state = tabPage != this.SelectedPage ? DrawItemState.Default : DrawItemState.Selected;
                    tabPage.workingTabWidth = (double)renderer.MeasureTabControlTab(graphics, tabPage.TabImage, tabPage.Text, this.Font, state).Width;
                    if (tabPage.MaximumTabWidth > 0 && tabPage.workingTabWidth > tabPage.MaximumTabWidth)
                    {
                        tabPage.workingTabWidth = tabPage.MaximumTabWidth;
                        tabPage.xcfac6723d8a41375 = true;
                    }
                }
                renderer.FinishRenderSession();
            }

            TabLayout tabLayout = this.TabLayout;
            Rectangle displayRectangle;
           
            int width;
            if (tabLayout == TabLayout.MultipleLine)
            {
                displayRectangle = this.DisplayRectangle;
                width = displayRectangle.Width;

                int num1 = 1;
                int num2 = 0;

                foreach (TabPage tabPage in this.Controls)
                {
                    num2 += (int)tabPage.workingTabWidth;
                    if (num2 > width && num2 != (int)tabPage.workingTabWidth)
                    {
                        ++num1;
                        num2 = (int)tabPage.workingTabWidth;
                    }
                    num2 -= renderer.TabControlTabExtra;
                }

                int num4 = (renderer.TabControlTabHeight - 2) * num1 + (renderer.TabControlTabStripHeight - renderer.TabControlTabHeight) + 2;
                this.tabStripBounds = this.DisplayRectangle;
                this.tabStripBounds.Height = num4;
            }
            else
            {
                this.tabStripBounds = this.DisplayRectangle;
                this.tabStripBounds.Height = renderer.TabControlTabStripHeight;
            }

            this.x21ed2ecc088ef4e4 = this.DisplayRectangle;
            this.x21ed2ecc088ef4e4.Offset(0, this.tabStripBounds.Height);
            this.x21ed2ecc088ef4e4.Height -= this.tabStripBounds.Height;
            this.x38c1fce82bb0e828 = this.x21ed2ecc088ef4e4;
            this.x38c1fce82bb0e828.Inflate(-renderer.TabControlPadding.Width, -renderer.TabControlPadding.Height);

            switch (this.TabLayout)
            {
                case TabLayout.SingleLineScrollable:
                    this.xac46da8e3ebf1367();
                    break;
                case TabLayout.SingleLineFixed:
                    this.x9ad45a8b0cdc25f7();
                    break;
                case TabLayout.MultipleLine:
                    this.xad3ea5eacdd3e808();
                    break;
            }
            this.Invalidate(renderer.ShouldDrawTabControlBackground);
        }

        private void xad3ea5eacdd3e808()
        {
            ArrayList arrayList1 = new ArrayList();
            Rectangle displayRectangle = this.DisplayRectangle;

            int width2 = displayRectangle.Width;
            ArrayList arrayList2 = null;
            ArrayList arrayList4 = new ArrayList();
            int left1 = this.tabStripBounds.Left;
            bool flag1 = false;
            foreach (TabPage tabPage in this.Controls)
            {
                if (arrayList4.Count == 0 && !flag1 || (double)left1 + tabPage.workingTabWidth <= (double)this.tabStripBounds.Right)
                {
                    arrayList4.Add(tabPage);
                    if (this.SelectedPage == tabPage)
                        arrayList2 = arrayList4;
                }
                else
                {
                    arrayList1.Add(arrayList4);
                    arrayList4 = new ArrayList();
                    left1 = this.tabStripBounds.Left;
                    arrayList4.Add(tabPage);
                    if (this.SelectedPage == tabPage)
                        arrayList2 = arrayList4;
                }
                left1 += (int)tabPage.workingTabWidth - this.render.TabControlTabExtra;
            }
            if (arrayList4.Count != 0)
                arrayList1.Add(arrayList4);
            if (arrayList2 != null)
            {
                arrayList1.Remove((object)arrayList2);
                arrayList1.Add(arrayList2);
            }
            int y = this.tabStripBounds.Top + (this.render.TabControlTabStripHeight - this.render.TabControlTabHeight);
            foreach (ArrayList arrayList3 in arrayList1)
            {
                int num2 = arrayList1.IndexOf((object)arrayList3);
                if (arrayList1.Count > 1)
                    this.xd022f7303b745a62((IList)arrayList3, true);
                int left = this.tabStripBounds.Left;
                foreach (TabPage tabPage in arrayList3)
                {
                    tabPage.xa806b754814b9ae0 = num2;
                    int width1 = (int)Math.Round(tabPage.workingTabWidth, 0);
                    tabPage.tabBounds = new Rectangle(left, y, width1, this.render.TabControlTabHeight);
                    left += width1 - this.render.TabControlTabExtra;
                }
                y += this.render.TabControlTabHeight - 2;
            }
        }

        private void xac46da8e3ebf1367()
        {
            int y = this.tabStripBounds.Top + this.tabStripBounds.Height / 2 - 7;
            int num1;
            int left;
            int num2;
            num1 = this.tabStripBounds.Right - 2;
            this.scrollRightButton.Enabled = true;
            this.scrollRightButton.Bounds = new Rectangle(num1 - 14, y, 14, 15);
            num2 = num1 - 15;
            this.scrollLeftButton.Enabled = true;
            this.scrollLeftButton.Bounds = new Rectangle(num2 - 14, y, 14, 15);
            num1 = num2 - 15;
            left = this.tabStripBounds.Left;
            foreach (TabPage tabPage in this.Controls)
            {
                int width = (int)Math.Round(tabPage.workingTabWidth, 0);
                tabPage.tabBounds = new Rectangle(left, this.tabStripBounds.Bottom - this.render.TabControlTabHeight, width, this.render.TabControlTabHeight);
                left += width - this.render.TabControlTabExtra;
            }
            if (this.Controls.Count != 0)
                left += this.render.TabControlTabExtra;
            int num4 = this.scrollLeftButton.Bounds.Left - this.tabStripBounds.Left;
            this.x4f8ccd50477a481e = left - num4;
            if (this.x4f8ccd50477a481e < 0)
                this.x4f8ccd50477a481e = 0;
            if (this.x200b7f5a9d983ba4 > this.x4f8ccd50477a481e)
                this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
            this.scrollLeftButton.x2fef7d841879a711 = this.x200b7f5a9d983ba4 > 0;
            this.scrollRightButton.x2fef7d841879a711 = this.x200b7f5a9d983ba4 < this.x4f8ccd50477a481e;
            foreach (TabPage tabPage in this.Controls)
            {
                Rectangle rectangle = tabPage.tabBounds;
                rectangle.Offset(-this.x200b7f5a9d983ba4, 0);
                tabPage.tabBounds = rectangle;
            }
        }
        // reviewed with 2.4
        private void x9ad45a8b0cdc25f7()
        {
            this.xd022f7303b745a62(this.Controls, false);
            int left = this.tabStripBounds.Left;
            foreach (TabPage tabPage in this.Controls)
            {
                int width = (int)Math.Round(tabPage.workingTabWidth, 0);
                tabPage.tabBounds = new Rectangle(left, this.tabStripBounds.Bottom - this.render.TabControlTabHeight, width, this.render.TabControlTabHeight);
                left += width - this.render.TabControlTabExtra;
            }
        }

        private void xd022f7303b745a62(IList tabPages, bool x12583168cc11d7a7)
        {
            int width = this.tabStripBounds.Width;
            double num1 = 0.0;
            foreach (TabPage tabPage in tabPages)
                num1 += tabPage.workingTabWidth;
            if (tabPages.Count >= 1)
                num1 -= (double)((tabPages.Count - 1) * this.render.TabControlTabExtra);
            if (num1 > (double)width)
            {
                double num7 = num1 - (double)width;
                for (int i = 0; i < tabPages.Count; ++i)
                {
                    TabPage tabPage = (TabPage)tabPages[i];
                    double num4 = i != 0 ? tabPage.workingTabWidth - (double)this.render.TabControlTabExtra : tabPage.workingTabWidth;
                    double num5 = num4 / num1;
                    double num6 = num4 - num7 * num5;
                    tabPage.xcfac6723d8a41375 = true;
                    tabPage.workingTabWidth = i == 0 ? num6 : num6 + (double)this.render.TabControlTabExtra;
                }
            }
            else
            {
                if (!x12583168cc11d7a7 || num1 >= (double)width)
                    return;
                double num2 = (double)width - num1;
                for (int i = 0; i < tabPages.Count; ++i)
                {
                    TabPage tabPage = (TabPage)tabPages[i];
                    double num5 = i != 0 ? tabPage.workingTabWidth - (double)this.render.TabControlTabExtra : tabPage.workingTabWidth;
                    double num3 = num5 / num1;
                    double num6 = num5 + num2 * num3;
                    tabPage.workingTabWidth = i == 0 ? num6 : num6 + (double)this.render.TabControlTabExtra;
                }
            }
        }
        // reviewd with 2.4
        private void xd11b6d3bf98020cb()
        {
            this.timer.Enabled = false;
            this.HighlightedButton = null;
            this.selected = false;
            this.Invalidate(this.tabStripBounds);
        }
        // reviewd with 2.4
        private void xcf8b319f2bffca87()
        {
            this.timer.Enabled = true;
            this.OnTimerTick(this.timer, EventArgs.Empty);
        }
        // reviewd with 2.4
        private void x523c1f22a806032d(int xa00f04d8b3a6664c)
        {
            this.x200b7f5a9d983ba4 += xa00f04d8b3a6664c;
            if (this.x200b7f5a9d983ba4 > this.x4f8ccd50477a481e)
            {
                this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
                this.xd11b6d3bf98020cb();
            }
 
            if (this.x200b7f5a9d983ba4 < 0)
            {
                this.x200b7f5a9d983ba4 = 0;
                this.xd11b6d3bf98020cb();
            }
            this.CalculateAllMetricsAndLayout();
  
        }
        // reviewd with 2.4
        private void OnTimerTick(object sender, EventArgs e)
        {
            if (this.HighlightedButton == this.scrollLeftButton)
                this.x523c1f22a806032d(-15);
            if (this.HighlightedButton == this.scrollRightButton)
                this.x523c1f22a806032d(15);
            else
                this.xd11b6d3bf98020cb();
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.CalculateAllMetricsAndLayout();
            this.PerformLayout();
        }

        /// <summary>
        /// Finds the TabPage whose tab contains the specified coordinates.
        /// 
        /// </summary>
        /// <param name="position">The coordinates at which to look.</param>
        /// <returns>
        /// The TagPage found, if any.
        /// </returns>
        // reviewed with 2.4
        public TabPage GetTabPageAt(Point position)
        {
            foreach (TabPage tabPage in this.Controls)
            {
                if (tabPage.TabBounds.Contains(position))
                    return tabPage;
            }
            return null;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnMouseLeave(EventArgs e)
        {
            this.HighlightedButton = null;
            this.selected = false;
            base.OnMouseLeave(e);
        }
        // reviewd with 2.4
        private SandDockButton x07083a4bfd59263d(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
        {
            if (this.scrollLeftButton.Enabled && this.scrollLeftButton.x2fef7d841879a711 && this.scrollLeftButton.Bounds.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
                return this.scrollLeftButton;
            if (this.scrollRightButton.Enabled && this.scrollRightButton.x2fef7d841879a711 && this.scrollRightButton.Bounds.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
                return this.scrollRightButton;
            return null;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewd with 2.4
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.TabLayout == TabLayout.SingleLineScrollable)
                this.HighlightedButton = this.x07083a4bfd59263d(e.X, e.Y);
        }
        // reviewd with 2.4
        private void x11e90588eb0baaf1(SandDockButton x128517d7ded59312)
        {
            if (x128517d7ded59312 != this.scrollLeftButton && x128517d7ded59312 != this.scrollRightButton)
                return;
            this.xcf8b319f2bffca87();
        }
        // reviewd with 2.4
        private void xa82f7b310984e03e(SandDockButton x128517d7ded59312)
        {
            if (x128517d7ded59312 != this.scrollLeftButton && x128517d7ded59312 != this.scrollRightButton)
                return;
            this.xd11b6d3bf98020cb();
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewd with 2.4
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && this.HighlightedButton != null)
            {
                this.xa82f7b310984e03e(this.HighlightedButton);
                this.selected = false;
                this.Invalidate(this.tabStripBounds);
            }
            base.OnMouseUp(e);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed with 2.4
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.HighlightedButton != null)
                {
                    this.selected = true;
                    this.Invalidate(this.tabStripBounds);
                    this.x11e90588eb0baaf1(this.HighlightedButton);
                    return;
                }

                TabPage tabPageAt = this.GetTabPageAt(new Point(e.X, e.Y));
                if (tabPageAt != null)
                {
                    if (this.SelectedPage != tabPageAt)
                        this.xf8af240c2d768134(tabPageAt, true);
                    else
                        this.Focus();

                    return;
                }
            }
            base.OnMouseDown(e);
        }
        // reviewed with 2.4
        private void xf8af240c2d768134(TabPage tabPage, bool x17cc8f73454a0462)
        {
            this.SelectedPage = tabPage;
            if (x17cc8f73454a0462)
                this.SelectedPage.SelectNextControl((Control)null, true, true, true, true);
            if (this.TabLayout != TabLayout.SingleLineScrollable)
                return;
            Rectangle rectangle = this.tabStripBounds;
            rectangle.Width -= this.tabStripBounds.Right - this.scrollLeftButton.Bounds.Left;
            Rectangle rect = tabPage.tabBounds;
            if (rectangle.Contains(rect))
                return;
            int xa00f04d8b3a6664c = 0;
            if (rect.Right > rectangle.Right)
                xa00f04d8b3a6664c = rect.Right - rectangle.Right + 20;
            else if (rect.Left < rectangle.Left)
                xa00f04d8b3a6664c = rect.Left - rectangle.Left - 20;
            if (xa00f04d8b3a6664c != 0)
                this.x523c1f22a806032d(xa00f04d8b3a6664c);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate(this.TabStripBounds);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.Invalidate(this.TabStripBounds);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override bool ProcessMnemonic(char charCode)
        {
            foreach (TabPage tabPage in this.Controls)
            {
                if (Control.IsMnemonic(charCode, tabPage.Text))
                {
                    this.xf8af240c2d768134(tabPage, true);
                    return true;
                }
            }
            return base.ProcessMnemonic(charCode);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed with 2.4
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    this.xa3038751b16f6cc8(-1, false, false);
                    break;
                case Keys.Right:
                    this.xa3038751b16f6cc8(1, false, false);
                    break;
                case Keys.Up:
                    if (this.TabLayout == TabLayout.MultipleLine)
                        this.x35cf6ce73d51ebeb(-1, false);
                    break;
                case Keys.Down:
                    break;
                default:
                    base.OnKeyDown(e);
                    break;
            }
        }
        // reviewed with 2.4
        private void x35cf6ce73d51ebeb(int x23e85093ba3a7d1d, bool x17cc8f73454a0462)
        {
            if (this.SelectedPage == null)
                return;
   
            Rectangle rectangle = this.SelectedPage.tabBounds;
            int num2 = rectangle.X + rectangle.Width / 2;
            int num3 = this.SelectedPage.xa806b754814b9ae0 + x23e85093ba3a7d1d;
 
            foreach (TabPage tabPage in this.Controls)
            {
                rectangle = tabPage.tabBounds;
                if (tabPage.xa806b754814b9ae0 == num3 && (rectangle.X <= num2 && rectangle.Right >= num2))
                {
                    this.xf8af240c2d768134(tabPage, x17cc8f73454a0462);
                    break;
                }
            }
        }

        private void xa3038751b16f6cc8(int x23e85093ba3a7d1d, bool x17cc8f73454a0462, bool x878956783d1decb2)
        {
            if (this.SelectedPage == null)
                return;
            int index = this.Controls.IndexOf(this.SelectedPage) + x23e85093ba3a7d1d;
            if (index > this.Controls.Count - 1)
                index = x878956783d1decb2 ? 0 : this.Controls.Count - 1;
            if (index < 0)
                index = x878956783d1decb2 ? this.Controls.Count - 1 : 0;
            this.xf8af240c2d768134((TabPage)this.Controls[index], x17cc8f73454a0462);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>

        // reviewed with 2.4
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys keys = keyData;
            switch (keys)
            {
                case Keys.Prior | Keys.Control:
                case Keys.Tab | Keys.Shift | Keys.Control:
                    this.xa3038751b16f6cc8(-1, true, true);
                    return true;
                case Keys.Next | Keys.Control:
                case Keys.Tab | Keys.Control:
                    this.xa3038751b16f6cc8(1, true, true);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed with 2.4
        protected override void OnFontChanged(EventArgs e)
        {
            this.CalculateAllMetricsAndLayout();
            this.PerformLayout();
            base.OnFontChanged(e);
        }

        /// <summary>
        /// Raises the SelectedPageChanged event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        // reviewed with 2.4
        protected virtual void OnSelectedPageChanged(EventArgs e)
        {
            if (this.SelectedPageChanged != null)
                this.SelectedPageChanged(this, e);
        }

        private void OnMetricsChanged(object sender, EventArgs e)
        {
            this.CalculateAllMetricsAndLayout();
            this.PerformLayout();
        }

        /// <summary>
        /// A collection of TabPage objects.
        /// 
        /// </summary>
        public class TabPageCollection : IList
        {
            private TabControl tabControl;

            bool IList.IsFixedSize
            {
                get
                {
                    return false;
                }
            }

            bool IList.IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            bool ICollection.IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// Gets the number of tab pages in the collection.
            /// 
            /// </summary>
            public int Count
            {
                get
                {
                    return this.tabControl.Controls.Count;
                }
            }

            object ICollection.SyncRoot
            {
                get
                {
                    return this;
                }
            }

            /// <summary>
            /// Gets a TabPage in the collection.
            /// 
            /// </summary>
            public TabPage this [int index]
            {
                get
                {
                    return (TabPage)this.tabControl.Controls[index];
                }
            }

            internal TabPageCollection(TabControl parent)
            {
                this.tabControl = parent;
            }

            object IList.this [int index]
            {
                get
                {
                    return this[index];
                }
                set
                {
                }
            }

            /// <summary>
            /// Sets the index of the specified TabPage to the specified value.
            /// 
            /// </summary>
            /// <param name="tabPage">The TabPage whose index will be changed.</param><param name="index">The new index for the TabPage.</param>
            /// <remarks>
            /// 
            /// <para>
            /// This method can be used to change the order of the TabPages in a TabControl.
            /// </para>
            /// 
            /// </remarks>
            public void SetChildIndex(TabPage tabPage, int index)
            {
                this.tabControl.Controls.SetChildIndex(tabPage, index);
            }

            /// <summary>
            /// Removes the tab page at the specified index from the collection.
            /// 
            /// </summary>
            /// <param name="index">The 0-based index of the TabPage to remove.</param>
            public void RemoveAt(int index)
            {
                this.tabControl.Controls.RemoveAt(index);
            }

            void IList.Insert(int index, object obj)
            {
                throw new NotSupportedException();
            }

            void IList.Remove(object obj)
            {
                if (obj is TabPage)
                    this.Remove((TabPage)obj);
            }

            bool IList.Contains(object obj)
            {
                return obj is TabPage ? this.Contains((TabPage)obj) : false;
            }

            /// <summary>
            /// Removes all the tab pages from the collection.
            /// 
            /// </summary>
            public void Clear()
            {
                this.tabControl.Controls.Clear();
            }

            int IList.IndexOf(object obj)
            {
                return obj is TabPage ? this.IndexOf((TabPage)obj) : -1;
            }

            int IList.Add(object obj)
            {
                if (!(obj is TabPage))
                    throw new NotSupportedException();
                this.tabControl.Controls.Add((Control)obj);
                return this.IndexOf((TabPage)obj);
            }

            void ICollection.CopyTo(Array array, int index)
            {
                if (array is TabPage[])
                    this.CopyTo((TabPage[])array, index);
            }

            /// <summary>
            /// Returns an enumeration of all the tab pages in the collection.
            /// 
            /// </summary>
            /// 
            /// <returns>
            /// An IEnumerator for the TabControl.TabPageCollection.
            /// </returns>
            public IEnumerator GetEnumerator()
            {
                TabPage[] array = new TabPage[this.Count];
                this.CopyTo(array, 0);
                return array.GetEnumerator();
            }

            /// <summary>
            /// Copies the child controls stored in the TabPageCollection object to a System.Array object, beginning at the specified index location in the Array.
            /// 
            /// </summary>
            /// <param name="array">The Array to copy the child controls to.</param><param name="index">The zero-based relative index in array where copying begins.</param>
            public void CopyTo(TabPage[] array, int index)
            {
                this.tabControl.Controls.CopyTo(array, index);
            }

            /// <summary>
            /// Determines whether a specified tab page is in the collection.
            /// 
            /// </summary>
            /// <param name="tabPage">The TabPage to locate in the collection.</param>
            /// <returns>
            /// True if the specified TabPage is in the collection; otherwise, false
            /// </returns>
            public bool Contains(TabPage tabPage)
            {
                return this.tabControl.Controls.Contains(tabPage);
            }

            /// <summary>
            /// Adds a set of tab pages to the collection.
            /// 
            /// </summary>
            /// <param name="tabPages">An array of type TabPage that contains the tab pages to add.</param>
            public void AddRange(TabPage[] tabPages)
            {
                this.tabControl.Controls.AddRange(tabPages);
            }

            /// <summary>
            /// Removes a TabPage from the collection.
            /// 
            /// </summary>
            /// <param name="tabPage">The TabPage to remove.</param>
            public void Remove(TabPage tabPage)
            {
                this.tabControl.Controls.Remove(tabPage);
            }

            /// <summary>
            /// Returns the index of the specified tab page in the collection.
            /// 
            /// </summary>
            /// <param name="tabPage">The TabPage to locate in the collection.</param>
            /// <returns>
            /// The 0-based index of the tab page; -1 if it cannot be found.
            /// </returns>
            public int IndexOf(TabPage tabPage)
            {
                return this.tabControl.Controls.IndexOf(tabPage);
            }

            /// <summary>
            /// Adds a TabPage to the collection.
            /// 
            /// </summary>
            /// <param name="tabPage">The TabPage to add.</param>
            public void Add(TabPage tabPage)
            {
                this.tabControl.Controls.Add(tabPage);
            }
        }

        class TabPageControlCollection : Control.ControlCollection
        {
            private TabControl tabControl;

            public TabPageControlCollection(TabControl owner) : base(owner)
            {
                this.tabControl = owner;
            }

            public override void Add(Control value)
            {
                if (!(value is TabPage))
                    throw new ArgumentException("Only TabPage controls can be added to a TabControl control.");
                value.Visible = false;
                base.Add(value);
                if (this.Count == 1)
                    this.tabControl.SelectedPage = (TabPage)value;
            }
        }
    }
}
