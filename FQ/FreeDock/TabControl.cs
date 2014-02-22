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
        private ControlButton x49dae83181e41d72;
        private ControlButton xa8ae81960654bc0b;
        private ControlButton highlightedButton;
        private bool xfa5e20eb950b9ee1;

        internal ControlButton HighlightedButton
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
                this.x436f6f3ee14607e0();
                this.PerformLayout();
            }
        }

        /// <summary>
        /// The renderer used to calculate object metrics and draw contents.
        /// 
        /// </summary>
        // reviewed
        [TypeConverter(typeof(xdc4dfd9427bbb983))]
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
                {
                    ((RendererBase)this.render).MetricsChanged -= new EventHandler(this.xadaf245f129714e2);
                }

                this.render = value;
                if (!value.ShouldDrawControlBorder)
                {
                    this.BorderStyle = FQ.FreeDock.Rendering.BorderStyle.None;
                }
                else
                {
                    if (this.BorderStyle == FQ.FreeDock.Rendering.BorderStyle.None)
                    {
                        this.BorderStyle = FQ.FreeDock.Rendering.BorderStyle.Flat;
                    }
                }

                if (this.render is RendererBase)
                {
                    ((RendererBase)this.render).MetricsChanged += new EventHandler(this.xadaf245f129714e2);
                }

                this.x436f6f3ee14607e0();
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
                this.x436f6f3ee14607e0();
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
        protected override System.Drawing.Size DefaultSize
        {
            get
            {
                return new System.Drawing.Size(300, 200);
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

                if (!this.Controls.Contains((Control)value))
                    throw new ArgumentException("Specified TabPage does not belong to this TabControl.");

                this.selectedPage = value;
                this.x436f6f3ee14607e0();
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
            this.render = (ITabControlRenderer)new MilborneRenderer();
            this.tabPages = new TabControl.TabPageCollection(this);
            this.x49dae83181e41d72 = new ControlButton();
            this.xa8ae81960654bc0b = new ControlButton();
            this.timer = new Timer();
            this.timer.Interval = 20;
            this.timer.Tick += new EventHandler(this.xcaf19fd9570f4eb4);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override Control.ControlCollection CreateControlsInstance()
        {
            return (Control.ControlCollection)new TabControl.x9e8d5fa1ed8fe66b(this);
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
            DockControl.xe1da469e4d960f02((Control)this, e.Graphics, this.borderStyle);
            this.render.DrawTabControlTabStripBackground(e.Graphics, this.tabStripBounds, this.BackColor);
            Region region = (Region)null;
            label_36:
            if (this.TabLayout != TabLayout.SingleLineScrollable)
                goto label_32;
            else
                goto label_37;
            label_1:
//			if (!this.x266365ea27fa7af8.Evaluation)
//			{
            if (8 != 0)
                return;
            else
                goto label_14;
//			}
            label_4:
            using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(30, Color.Black)))
            {
                using (Font font = new Font(this.Font.FontFamily.Name, 14f, FontStyle.Bold))
                {
                    e.Graphics.DrawString("evaluation", font, (Brush)solidBrush, (float)(this.tabStripBounds.Left + 4), (float)(this.tabStripBounds.Top - 4), StringFormat.GenericTypographic);
                    return;
                }
            }
            label_14:
            int index;
            if ((uint)index < 0U)
                goto label_27;
            label_15:
            if (this.SelectedPage != null)
                goto label_20;
            else
                goto label_16;
            label_2:
            if (this.TabLayout == TabLayout.SingleLineScrollable)
                goto label_17;
            label_3:
            this.Renderer.FinishRenderSession();
            goto label_1;
            label_16:
            if (2 != 0)
                goto label_2;
            label_17:
            this.xb30ec7cfdf3e5c19(e.Graphics, this.render, this.xa8ae81960654bc0b, SandDockButtonType.ScrollRight, this.xa8ae81960654bc0b.x2fef7d841879a711);
            this.xb30ec7cfdf3e5c19(e.Graphics, this.render, this.x49dae83181e41d72, SandDockButtonType.ScrollLeft, this.x49dae83181e41d72.x2fef7d841879a711);
            goto label_3;
            label_20:
            this.render.DrawTabControlBackground(e.Graphics, this.x21ed2ecc088ef4e4, this.SelectedPage.BackColor, false);
            goto label_2;
            label_27:
            if (this.SelectedPage == null)
                goto label_23;
            else
                goto label_28;
            label_18:
            if (true)
            {
                if (false)
                {
                    if ((index & 0) == 0)
                        goto label_33;
                    else
                        goto label_32;
                }
                else
                    goto label_15;
            }
            label_23:
            if (this.TabLayout != TabLayout.SingleLineScrollable)
            {
                if (0 == 0)
                {
                    if (0 == 0)
                    {
                        if (0 == 0)
                            goto label_15;
                        else
                            goto label_14;
                    }
                    else
                        goto label_18;
                }
                else
                    goto label_36;
            }
            else
            {
                e.Graphics.Clip = region;
                goto label_18;
            }
            label_28:
            this.xc33f5f7a18a754cb(e.Graphics, this.SelectedPage);
            if (true)
                goto label_23;
            else
                goto label_18;
            label_32:
            if (this.TabLayout == TabLayout.MultipleLine)
                goto label_35;
            label_33:
            for (index = this.Controls.Count - 1; index >= 0; --index)
            {
                this.xc33f5f7a18a754cb(e.Graphics, (TabPage)this.Controls[index]);
                if ((uint)index > uint.MaxValue)
                    goto label_1;
            }
            goto label_27;
            label_35:
            this.xe03691727ff38b10(e.Graphics);
            goto label_27;
            label_37:
            region = e.Graphics.Clip;
            Rectangle rect = this.tabStripBounds;
            if (true)
            {
                rect.Width -= this.tabStripBounds.Right - this.x49dae83181e41d72.Bounds.Left;
                e.Graphics.SetClip(rect);
                if (3 != 0)
                    goto label_32;
                else
                    goto label_35;
            }
            else
                goto label_4;
        }

        private void xb30ec7cfdf3e5c19(Graphics x41347a961b838962, ITabControlRenderer x38870620fd380a6b, ControlButton x128517d7ded59312, SandDockButtonType x271bd5d42b3ea793, bool x2fef7d841879a711)
        {
            if (!x128517d7ded59312.Enabled)
                return;
            DrawItemState state = DrawItemState.Default;
            if (this.HighlightedButton != x128517d7ded59312)
                goto label_2;
            else
                goto label_11;
            label_1:
            x38870620fd380a6b.DrawTabControlButton(x41347a961b838962, x128517d7ded59312.Bounds, x271bd5d42b3ea793, state);
            return;
            label_2:
            if (x2fef7d841879a711)
            {
                if (true)
                    goto label_1;
                else
                    goto label_5;
            }
            label_4:
            state |= DrawItemState.Disabled;
            if (true)
                goto label_1;
            else
                goto label_2;
            label_5:
            if (true)
            {
                if (false)
                    goto label_4;
                else
                    goto label_2;
            }
            label_7:
            if (!this.xfa5e20eb950b9ee1)
            {
                if (0 == 0)
                    goto label_2;
                else
                    goto label_4;
            }
            else
                goto label_12;
            label_11:
            state |= DrawItemState.HotLight;
            if (true)
                goto label_7;
            label_12:
            state |= DrawItemState.Selected;
            goto label_5;
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
        private void xc33f5f7a18a754cb(Graphics graphics, TabPage tabPage)
        {
            DrawItemState state = DrawItemState.Default;
            if (tabPage == this.SelectedPage)
            {
                state |= DrawItemState.Selected;
                if (this.Focused && this.ShowFocusCues)
                    state |= DrawItemState.Checked;
            }
            this.Renderer.DrawTabControlTab(graphics, tabPage.tabBounds, tabPage.TabImage, tabPage.Text, this.Font, tabPage.BackColor, tabPage.ForeColor, state, true);
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
            this.x436f6f3ee14607e0();
            base.OnResize(e);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            this.x436f6f3ee14607e0();
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
                {
                    this.SelectedPage = this.TabPages[0];
                }
                else
                {
                    this.selectedPage = null;
                    this.OnSelectedPageChanged(EventArgs.Empty);
                }
            }

            this.x436f6f3ee14607e0();
            this.PerformLayout();
        }
        // reviewed with 2.4
        internal void x436f6f3ee14607e0()
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
                    tabPage.x9b0739496f8b5475 = (double)renderer.MeasureTabControlTab(graphics, tabPage.TabImage, tabPage.Text, this.Font, state).Width;
                    if (tabPage.MaximumTabWidth > 0 && tabPage.x9b0739496f8b5475 > tabPage.MaximumTabWidth)
                    {
                        tabPage.x9b0739496f8b5475 = tabPage.MaximumTabWidth;
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
                    num2 += (int)tabPage.x9b0739496f8b5475;
                    if (num2 > width && num2 != (int)tabPage.x9b0739496f8b5475)
                    {
                        ++num1;
                        num2 = (int)tabPage.x9b0739496f8b5475;
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
            int num1 = 0;
            if (false)
                goto label_24;
            else
                goto label_51;
            label_22:
            ArrayList arrayList2;
            if (arrayList2 != null)
                goto label_23;
            label_2:
            int y = this.tabStripBounds.Top + (this.render.TabControlTabStripHeight - this.render.TabControlTabHeight);
            IEnumerator enumerator1 = arrayList1.GetEnumerator();
            int width1 = 0;
            int num2;
            bool flag1;
            try
            {
                while (enumerator1.MoveNext())
                {
                    ArrayList arrayList3 = (ArrayList)enumerator1.Current;
                    num2 = arrayList1.IndexOf((object)arrayList3);
                    if (arrayList1.Count > 1)
                        goto label_17;
                    label_4:
                    int left = this.tabStripBounds.Left;
                    IEnumerator enumerator2 = arrayList3.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            TabPage tabPage = (TabPage)enumerator2.Current;
                            tabPage.xa806b754814b9ae0 = num2;
                            if ((uint)num2 + (uint)y <= uint.MaxValue)
                                width1 = (int)Math.Round(tabPage.x9b0739496f8b5475, 0);
                            tabPage.tabBounds = new Rectangle(left, y, width1, this.render.TabControlTabHeight);
                            left += width1 - this.render.TabControlTabExtra;
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator2 as IDisposable;
                        while (disposable != null)
                        {
                            disposable.Dispose();
                            if (true)
                                break;
                        }
                    }
                    y += this.render.TabControlTabHeight - 2;
                    continue;
                    label_17:
                    this.xd022f7303b745a62((IList)arrayList3, true);
                    goto label_4;
                }
                return;
            }
            finally
            {
                IDisposable disposable = enumerator1 as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            label_23:
            arrayList1.Remove((object)arrayList2);
            int left1;
            if (false)
                return;
            arrayList1.Add((object)arrayList2);
            goto label_2;
            label_24:
            ArrayList arrayList4;
            arrayList1.Add((object)arrayList4);
            goto label_22;
            label_51:
            Rectangle displayRectangle = this.DisplayRectangle;
            bool flag2;
            bool flag3;
            if (true)
            {
                int width2 = displayRectangle.Width;
                arrayList2 = (ArrayList)null;
                arrayList4 = new ArrayList();
                left1 = this.tabStripBounds.Left;
                flag1 = false;
                foreach (TabPage tabPage in (ArrangedElementCollection) this.Controls)
                {
                    int num3;
                    bool flag4;
                    do
                    {
                        if (arrayList4.Count == 0)
                            goto label_45;
                        label_40:
                        int num4 = (double)left1 + tabPage.x9b0739496f8b5475 <= (double)this.tabStripBounds.Right ? 1 : 0;
                        label_42:
                        flag4 = num4 != 0;
                        int num5;
                        if (flag4)
                        {
                            arrayList4.Add((object)tabPage);
                            continue;
                        }
                        else
                            goto label_35;
                        label_45:
                        if ((uint)num1 - (uint)left1 >= 0U)
                        {
                            if (!flag1)
                            {
                                num4 = 1;
                                goto label_42;
                            }
                            else
                                goto label_40;
                        }
                        else
                            break;
                    }
                    while (false);
                    label_26:
                    if (this.SelectedPage == tabPage)
                    {
                        arrayList2 = arrayList4;
                        goto label_29;
                    }
                    label_27:
                    if (false)
                        goto label_35;
                    label_29:
                    left1 += (int)tabPage.x9b0739496f8b5475 - this.render.TabControlTabExtra;
                    continue;
                    label_35:
                    arrayList1.Add((object)arrayList4);
                    do
                    {
                        arrayList4 = new ArrayList();
                    }
                    while (false);
                    left1 = this.tabStripBounds.Left;
                    arrayList4.Add((object)tabPage);
                    if (true)
                    {
                        if (this.SelectedPage == tabPage)
                        {
                            arrayList2 = arrayList4;
                            if (true)
                            {
                                if (2 == 0)
                                    goto label_26;
                                else
                                    goto label_29;
                            }
                            else if (true)
                            {
                                if ((uint)left1 + (uint)left1 <= uint.MaxValue)
                                    goto label_26;
                                else
                                    break;
                            }
                            else
                                goto label_27;
                        }
                        else
                            goto label_29;
                    }
                    else
                        goto label_26;
                }
                if (arrayList4.Count != 0)
                    goto label_24;
                else
                    goto label_22;
            }
            else
                goto label_22;
        }

        private void xac46da8e3ebf1367()
        {
            int y = this.tabStripBounds.Top + this.tabStripBounds.Height / 2 - 7;
            int num1;
            int left;
            int num2;

            num1 = this.tabStripBounds.Right - 2;
            this.xa8ae81960654bc0b.Enabled = true;
            this.xa8ae81960654bc0b.Bounds = new Rectangle(num1 - 14, y, 14, 15);
            num2 = num1 - 15;
            this.x49dae83181e41d72.Enabled = true;
            this.x49dae83181e41d72.Bounds = new Rectangle(num2 - 14, y, 14, 15);
            num1 = num2 - 15;
            left = this.tabStripBounds.Left;

            goto label_22;
            label_12:
            this.x4f8ccd50477a481e = 0;
            label_14:
            if (this.x200b7f5a9d983ba4 > this.x4f8ccd50477a481e)
                goto label_13;
            else
                goto label_18;
            label_10:
            this.x49dae83181e41d72.x2fef7d841879a711 = this.x200b7f5a9d983ba4 > 0;
            this.xa8ae81960654bc0b.x2fef7d841879a711 = this.x200b7f5a9d983ba4 < this.x4f8ccd50477a481e;
            int width;

            goto label_19;
            label_13:
            this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
            goto label_10;
            label_18:
            int num4;
            if (true)
                goto label_10;
            label_19:
            if (false)
                return;
            IEnumerator enumerator1 = this.Controls.GetEnumerator();
            try
            {
                while (enumerator1.MoveNext())
                {
                    TabPage tabPage = (TabPage)enumerator1.Current;
                    Rectangle rectangle = tabPage.tabBounds;
                    do
                    {
                        rectangle.Offset(-this.x200b7f5a9d983ba4, 0);
                    }
                    while ((uint)num1 < 0U);
                    tabPage.tabBounds = rectangle;
                }
                return;
            }
            finally
            {
                IDisposable disposable = enumerator1 as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            label_15:
            this.x4f8ccd50477a481e = left - num4;
            if (this.x4f8ccd50477a481e >= 0)
                goto label_14;
            else
                goto label_12;
            label_17:
            num4 = this.x49dae83181e41d72.Bounds.Left - this.tabStripBounds.Left;
            goto label_15;
            label_22:
            IEnumerator enumerator2 = this.Controls.GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    TabPage tabPage = (TabPage)enumerator2.Current;
                    width = (int)Math.Round(tabPage.x9b0739496f8b5475, 0);
                    tabPage.tabBounds = new Rectangle(left, this.tabStripBounds.Bottom - this.render.TabControlTabHeight, width, this.render.TabControlTabHeight);
                    if ((uint)num1 - (uint)width > uint.MaxValue)
                        ;
                    left += width - this.render.TabControlTabExtra;
                }
            }
            finally
            {
                IDisposable disposable = enumerator2 as IDisposable;
                if ((uint)left > uint.MaxValue || disposable != null)
                    disposable.Dispose();
            }
            if (this.Controls.Count != 0)
            {
                left += this.render.TabControlTabExtra;
//                int num2;
                if (false)
                    return;
                else
                    goto label_17;
            }
            else
                goto label_17;
            label_36:
            ;
        }
        // reviewed with 2.4
        private void x9ad45a8b0cdc25f7()
        {
            this.xd022f7303b745a62(this.Controls, false);
            int left = this.tabStripBounds.Left;

            foreach (TabPage tabPage in this.Controls)
            {
                int width = (int)Math.Round(tabPage.x9b0739496f8b5475, 0);
                tabPage.tabBounds = new Rectangle(left, this.tabStripBounds.Bottom - this.render.TabControlTabHeight, width, this.render.TabControlTabHeight);
                left += width - this.render.TabControlTabExtra;
            }
        }

        private void xd022f7303b745a62(IList xc06f388a56e1a8e4, bool x12583168cc11d7a7)
        {
            int width = this.tabStripBounds.Width;
            double num1 = 0.0;
            foreach (TabPage tabPage in (IEnumerable) xc06f388a56e1a8e4)
                num1 += tabPage.x9b0739496f8b5475;
            if (xc06f388a56e1a8e4.Count >= 1)
                goto label_26;
            label_17:
            if (num1 > (double)width)
                goto label_18;
            label_1:
            if (!x12583168cc11d7a7)
                return;
            double num2 = 0;
            if (num1 >= (double)width)
            {
                if ((uint)num2 - (uint)width <= uint.MaxValue)
                    return;
                else
                    goto label_14;
            }
            else
                goto label_9;
            label_5:
            int index1;
            double num3;
            double num4;
            for (; index1 < xc06f388a56e1a8e4.Count; ++index1)
            {
                TabPage tabPage = (TabPage)xc06f388a56e1a8e4[index1];
                double num5 = index1 != 0 ? tabPage.x9b0739496f8b5475 - (double)this.render.TabControlTabExtra : tabPage.x9b0739496f8b5475;
                if ((uint)num1 >= 0U)
                {
                    num3 = num5 / num1;
                    double num6 = num5 + num2 * num3;
                    tabPage.x9b0739496f8b5475 = index1 == 0 ? num6 : num6 + (double)this.render.TabControlTabExtra;
                    if (true)
                    {
                        if (0 != 0)
                            return;
                    }
                    else
                        goto label_17;
                }
                else
                    goto label_9;
            }
            if (true)
                return;
            else
                goto label_1;
            label_9:
            num2 = (double)width - num1;
            index1 = 0;
            goto label_5;
            label_14:
            double num7 = 0;
            for (int index2 = 0; index2 < xc06f388a56e1a8e4.Count; ++index2)
            {
                TabPage tabPage = (TabPage)xc06f388a56e1a8e4[index2];
                num4 = 0 != 0 || index2 != 0 ? tabPage.x9b0739496f8b5475 - (double)this.render.TabControlTabExtra : tabPage.x9b0739496f8b5475;
                if (true)
                {
                    double num5 = num4 / num1;
                    double num6 = num4 - num7 * num5;
                    tabPage.xcfac6723d8a41375 = true;
                    tabPage.x9b0739496f8b5475 = index2 == 0 ? num6 : num6 + (double)this.render.TabControlTabExtra;
                }
                else
                    goto label_5;
            }
            return;
            label_18:
            num7 = num1 - (double)width;
            goto label_14;
            label_26:
            num1 -= (double)((xc06f388a56e1a8e4.Count - 1) * this.render.TabControlTabExtra);
            goto label_17;
        }
        // reviewd with 2.4
        private void xd11b6d3bf98020cb()
        {
            this.timer.Enabled = false;
            this.HighlightedButton = null;
            this.xfa5e20eb950b9ee1 = false;
            this.Invalidate(this.tabStripBounds);
        }
        // reviewd with 2.4
        private void xcf8b319f2bffca87()
        {
            this.timer.Enabled = true;
            this.xcaf19fd9570f4eb4(this.timer, EventArgs.Empty);
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
            this.x436f6f3ee14607e0();
  
        }
        // reviewd with 2.4
        private void xcaf19fd9570f4eb4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            if (this.HighlightedButton == this.x49dae83181e41d72)
                this.x523c1f22a806032d(-15);
            if (this.HighlightedButton == this.xa8ae81960654bc0b)
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
            this.x436f6f3ee14607e0();
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
                if (tabPage.tabBounds.Contains(position))
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
            this.xfa5e20eb950b9ee1 = false;
            base.OnMouseLeave(e);
        }
        // reviewd with 2.4
        private ControlButton x07083a4bfd59263d(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
        {
            if (this.x49dae83181e41d72.Enabled && this.x49dae83181e41d72.x2fef7d841879a711 && this.x49dae83181e41d72.Bounds.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
                return this.x49dae83181e41d72;
            if (this.xa8ae81960654bc0b.Enabled && this.xa8ae81960654bc0b.x2fef7d841879a711 && this.xa8ae81960654bc0b.Bounds.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
                return this.xa8ae81960654bc0b;
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
        private void x11e90588eb0baaf1(ControlButton x128517d7ded59312)
        {
            if (x128517d7ded59312 != this.x49dae83181e41d72 && x128517d7ded59312 != this.xa8ae81960654bc0b)
                return;
            this.xcf8b319f2bffca87();
        }
        // reviewd with 2.4
        private void xa82f7b310984e03e(ControlButton x128517d7ded59312)
        {
            if (x128517d7ded59312 != this.x49dae83181e41d72 && x128517d7ded59312 != this.xa8ae81960654bc0b)
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
                this.xfa5e20eb950b9ee1 = false;
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
                    this.xfa5e20eb950b9ee1 = true;
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

        private void xf8af240c2d768134(TabPage xbbe2f7d7c86e0379, bool x17cc8f73454a0462)
        {
            this.SelectedPage = xbbe2f7d7c86e0379;
            int num;
            Rectangle rectangle;
            do
            {
                if (x17cc8f73454a0462)
                    goto label_19;
                label_16:
                if (this.TabLayout == TabLayout.SingleLineScrollable)
                {
                    rectangle = this.tabStripBounds;
                    rectangle.Width -= this.tabStripBounds.Right - this.x49dae83181e41d72.Bounds.Left;
                    continue;
                }
                else
                    goto label_20;
                label_19:
                this.SelectedPage.SelectNextControl((Control)null, true, true, true, true);
                if (true)
                    goto label_16;
                else
                    break;
            }
            while (false);
            Rectangle rect = xbbe2f7d7c86e0379.tabBounds;
            int xa00f04d8b3a6664c;
            if (true)
            {
                while (rectangle.Contains(rect))
                {
                    if (8 != 0 || (int)byte.MaxValue == 0)
                    {
                        if (0 == 0)
                        {
                            if (true)
                                return;
                        }
                        else
                            goto label_6;
                    }
                    else if (2 == 0)
                        goto label_11;
                    else
                        goto label_6;
                }
                xa00f04d8b3a6664c = 0;
                label_11:
                if (rect.Right <= rectangle.Right)
                {
                    if (rect.Left < rectangle.Left)
                    {
                        xa00f04d8b3a6664c = rect.Left - rectangle.Left - 20;
                        if ((xa00f04d8b3a6664c & 0) != 0)
                            goto label_7;
                    }
                }
                else
                    xa00f04d8b3a6664c = rect.Right - rectangle.Right + 20;
            }
            label_6:
            if (xa00f04d8b3a6664c == 0)
                return;
            label_7:
            this.x523c1f22a806032d(xa00f04d8b3a6664c);
            return;
            label_20:
            ;
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
            int index = this.Controls.IndexOf((Control)this.SelectedPage) + x23e85093ba3a7d1d;
            if (index > this.Controls.Count - 1)
                goto label_11;
            label_1:
            if (index < 0)
                goto label_8;
            label_2:
            this.xf8af240c2d768134((TabPage)this.Controls[index], x17cc8f73454a0462);
            if (true)
            {
                if ((uint)x23e85093ba3a7d1d >= 0U)
                    return;
            }
            else
                goto label_5;
            label_4:
            if (((x878956783d1decb2 ? 1 : 0) | int.MaxValue) != 0 && 0 == 0)
                goto label_6;
            label_5:
            if ((uint)x23e85093ba3a7d1d > uint.MaxValue)
                goto label_8;
            label_6:
            int num = this.Controls.Count - 1;
            label_7:
            index = num;
            goto label_2;
            label_8:
            if (!x878956783d1decb2)
            {
                num = 0;
                goto label_7;
            }
            else
                goto label_4;
            label_11:
            index = x878956783d1decb2 ? 0 : this.Controls.Count - 1;
            goto label_1;
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
            this.x436f6f3ee14607e0();
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

        private void xadaf245f129714e2(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            this.x436f6f3ee14607e0();
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
            public TabPage this[int index]
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

            object IList.this[int index]
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

        class x9e8d5fa1ed8fe66b : Control.ControlCollection
        {
            private TabControl tabControl;

            public x9e8d5fa1ed8fe66b(TabControl owner) : base(owner)
            {
                this.tabControl = owner;
            }

            public override void Add(Control value)
            {
                if (value is TabPage)
                {
                    value.Visible = false;
                    base.Add(value);
                    if (this.Count == 1)
                    {
                        this.tabControl.SelectedPage = (TabPage)value;
                    }
                    return;
                }

                throw new ArgumentException("Only TabPage controls can be added to a TabControl control.");
            }
        }
    }
}
