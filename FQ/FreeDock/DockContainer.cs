//using Divelements.Util.Registration;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using FQ.FreeDock.Design;
using FQ.FreeDock.Rendering;
using FQ.Util;

namespace FQ.FreeDock
{
    /// <summary>
    /// The top level object in a SandDock layout system.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// There are typically four of these in a standard layout system to begin with, with more create at runtime when floating containers are needed. More
    ///             DockContainers can be registered using the methods on SandDockManager. Once a DockContainer has been registered it is available as a target in
    ///             docking operations.
    /// </para>
    /// 
    /// <para>
    /// DockContainers are responsible for managing DockControls that have been "unpinned". This layout logic is only available when the DockContainer's
    ///             Dock property is set to Top, Bottom, Left or Right.
    /// </para>
    /// 
    /// </remarks>
    [Designer(typeof(DockContainerDesigner))]
//    [LicenseProvider(typeof(x294bd621a33dc533))]
    [ToolboxItem(false)]
    public class DockContainer : ContainerControl
    {
        private Rectangle x59f159fe47159543 = Rectangle.Empty;
        private Rectangle x21ed2ecc088ef4e4 = Rectangle.Empty;
        private int contentSize = 100;
        private const int MIN_CONTENTSIZE = 32;
        private SandDockManager sandDockManager;
        private SplitLayoutSystem splitLayout;
        internal ArrayList layouts;
        private RendererBase render;
        private Tooltips tooltips;
        private int xa03963cfd21be862;
        private static bool x1f080f764b4036b1;
        //        private xbd7c5470fc89975b x266365ea27fa7af8;
        private x09c1c18390e52ebf x754f1c6f433be75d;
        private bool x841598f8fd19209c;
        internal LayoutSystemBase layout;

        internal Rectangle x0c42f19be578ccee
        {
            get
            {
                return this.x59f159fe47159543;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [Browsable(false)]
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                if (value == DockStyle.None)
                    throw new ArgumentException("The value None is not supported for DockContainers.");
                base.Dock = value;
                Orientation orientation = Orientation.Horizontal;
                if (this.Dock == DockStyle.Top || this.Dock == DockStyle.Bottom)
                    orientation = Orientation.Vertical;
                if (this.splitLayout.SplitMode == orientation)
                    return;
                this.splitLayout.SplitMode = orientation;
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
        /// Overridden.
        /// 
        /// </summary>
        [Browsable(false)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [DefaultValue(typeof(Color), "Control")]
        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        /// <summary>
        /// Returns true if there is a single layout system occupying the DockContainer, and that layout system is a ControlLayoutSystem.
        /// 
        /// </summary>
        [Browsable(false)]
        public bool HasSingleControlLayoutSystem
        {
            get
            {
                return this.LayoutSystem.LayoutSystems.Count == 1 ? this.LayoutSystem.LayoutSystems[0] is ControlLayoutSystem : false;
            }
        }
        // reviewed
        internal virtual RendererBase WorkingRender
        {
            get
            {
                if (this.sandDockManager != null && this.sandDockManager.Renderer != null)
                    return this.sandDockManager.Renderer;

                if (this.render == null)
                    this.render = new WhidbeyRenderer();

                return this.render;
            }
        }

        /// <summary>
        /// The size of the content within the container.
        /// 
        /// </summary>
        // reviewed
        public int ContentSize
        {
            get
            {
                return this.contentSize;
            }
            set
            {
                value = Math.Max(value, MIN_CONTENTSIZE);
                if (value == this.contentSize)
                    return;

                this.x841598f8fd19209c = true;
                this.contentSize = value;
                this.x333d8ec4f70a6d86();
            }
        }

        internal int CurrentSize
        {
            get
            {
                if (this.Vertical)
                    return this.x21ed2ecc088ef4e4.Width;
                else
                    return this.x21ed2ecc088ef4e4.Height;
            }
        }

        /// <summary>
        /// Indicates whether this container will allow the user to resize it.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// The value of this property is obtained from the manager if available.
        /// 
        /// </remarks>
        [Browsable(false)]
        protected internal virtual bool AllowResize
        {
            get
            {
                return this.Manager != null ? this.Manager.AllowDockContainerResize : true;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [Browsable(false)]
        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }
            set
            {
                base.AllowDrop = value;
            }
        }

        internal bool FriendDesignMode
        {
            get
            {
                return this.DesignMode;
            }
        }

        /// <summary>
        /// The SandDockManager instance that is associated with this DockContainer.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// DockContainers need to be associated with a SandDockManager to ensure correct behaviour and interaction with other DockContainers. This property
        ///             should be set immediately after creating a DockContainer.
        /// 
        /// </remarks>
        [Browsable(false)]
        // reviewed
        public virtual SandDockManager Manager
        {
            get
            {
                return this.sandDockManager;
            }
            set
            {
                if (this.sandDockManager != null)
                    this.sandDockManager.UnregisterDockContainer(this);

                if (value != null && value.DockSystemContainer != null)
                {
                    if (!this.IsFloating && this.Parent != null && this.Parent != value.DockSystemContainer)
                        throw new ArgumentException("This DockContainer cannot use the specified manager as the manager's DockSystemContainer differs from the DockContainer's Parent.");
                }

                this.sandDockManager = value;
                if (this.sandDockManager != null)
                {
                    this.sandDockManager.RegisterDockContainer(this);
                    this.LayoutSystem.x56e964269d48cfcc(this);
                }
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
                return new Size(0, 0);
            }
        }

        /// <summary>
        /// Indicates whether this container is floating.
        /// 
        /// </summary>
        [Browsable(false)]
        public virtual bool IsFloating
        {
            get
            {
                return false;
            }
        }

        internal bool Vertical
        {
            get
            {
                return this.Dock == DockStyle.Left || this.Dock == DockStyle.Right;

            }
        }

        /// <summary>
        /// The root layout system within this container. This is always a split layout system.
        /// 
        /// </summary>
        [Browsable(false)]
        // reviewed
        public virtual SplitLayoutSystem LayoutSystem
        {
            get
            {
                return this.splitLayout;
            }
            set
            {
                if (value == this.splitLayout)
                    return;
                if (value == null)
                    throw new ArgumentNullException("value");

                DockContainer.x1f080f764b4036b1 = true;
                try
                {
                    if (this.splitLayout != null)
                        this.splitLayout.x56e964269d48cfcc(null);

                    if (!this.x841598f8fd19209c)
                    {
                        this.contentSize = this.Vertical ? Convert.ToInt32(value.WorkingSize.Width) : Convert.ToInt32(value.WorkingSize.Height);
                        this.x841598f8fd19209c = true;

                    }
                    this.splitLayout = value;
                    this.splitLayout.x56e964269d48cfcc(this);
                    this.x7e9646eed248ed11();
                }
                finally
                {
                    DockContainer.x1f080f764b4036b1 = false;
                }
            }
        }

        internal bool x5b1f9c5a8906ff95
        {
            get
            {
                return this.xa03963cfd21be862 > 0;
            }
        }

        [Browsable(false)]
        internal virtual bool CanShowCollapsed
        {
            get
            {
                if (this.Dock != DockStyle.Fill)
                    return this.Dock != DockStyle.None;
                else
                    return false;
            }
        }

        /// <summary>
        /// Raised when the user starts dragging a control or layout system.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// This event can be used to present the user (via a statusbar or similar) with some helpful text describing how to manipulate controls in a redocking
        ///             operation.
        /// 
        /// </remarks>
        public event EventHandler DockingStarted;
        /// <summary>
        /// Raised when a docking or dragging operation has been completed.
        /// 
        /// </summary>
        public event EventHandler DockingFinished;

        /// <summary>
        /// Initializes a new instance of the DockContainer class.
        /// 
        /// </summary>
        public DockContainer()
        {
//            this.x266365ea27fa7af8 = LicenseManager.Validate(typeof(DockContainer), (object)this) as xbd7c5470fc89975b;
            this.splitLayout = new SplitLayoutSystem();
            this.splitLayout.x56e964269d48cfcc(this);
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.layouts = new ArrayList();
            this.tooltips = new Tooltips(this);
            this.tooltips.DropShadow = false;
            this.tooltips.GetTooltipText += new Tooltips.x58986a4a0b75e5b5(this.xa3a7472ac4e61f76);
            this.BackColor = SystemColors.Control;
        }

        internal virtual void x5fc4eceec879ff0f()
        {
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed with 2.4
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (this.Manager == null || this.Parent == null || this.Parent is xd936980ea1aac341)
                return;
            this.Manager.DockSystemContainer = this.Parent;
        }

        internal void x8ba6fce4f4601549(ShowControlContextMenuEventArgs e)
        {
            if (this.Manager != null)
                this.Manager.OnShowControlContextMenu(e);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.render != null)
                {   
                    this.render.Dispose();
                    this.render = null;
                }
                this.Manager = null;
                this.tooltips.GetTooltipText -= new Tooltips.x58986a4a0b75e5b5(this.xa3a7472ac4e61f76);
                this.tooltips.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Creates a new layout system suitable for use in the DockContainer.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// A new layout system.
        /// </returns>
        /// <param name="size">The size of the new layout system.</param>
        public ControlLayoutSystem CreateNewLayoutSystem(SizeF size)
        {
            return this.CreateNewLayoutSystem(new DockControl[0], size);
        }

        /// <summary>
        /// Creates a new layout system suitable for use in the DockContainer, containing the specified DockControl.
        /// 
        /// </summary>
        /// <param name="control">The DockControl to initially include in the layout system.</param><param name="size">The size of the new layout system.</param>
        /// <returns>
        /// A new layout system
        /// </returns>
        public ControlLayoutSystem CreateNewLayoutSystem(DockControl control, SizeF size)
        {
            return this.CreateNewLayoutSystem(new DockControl[] { control }, size);
        }

        /// <summary>
        /// Creates a new layout system suitable for use in the DockContainer, containing the specified DockControls.
        /// 
        /// </summary>
        /// <param name="controls">The DockControls to initially include in the layout system.</param><param name="size">The size of the new layout system.</param>
        /// <returns>
        /// A new layout system
        /// </returns>
        public ControlLayoutSystem CreateNewLayoutSystem(DockControl[] controls, SizeF size)
        {
            if (controls == null)
                throw new ArgumentNullException("controls");

            ControlLayoutSystem controlLayout = this.xd6284ffe96aec512();
            controlLayout.WorkingSize = size;
            if (controls.Length != 0)
                controlLayout.Controls.AddRange(controls);

            return controlLayout;
        }

        internal virtual ControlLayoutSystem xd6284ffe96aec512()
        {
            return new ControlLayoutSystem();
        }

        internal object x7159e85e85b84817(Type type)
        {
            return this.GetService(type);
        }
        // reviewed with 2.4
        internal void x272ed7848e373c56()
        {
            ++this.xa03963cfd21be862;
            this.splitLayout.x56e964269d48cfcc(null);

            foreach (LayoutSystemBase layout in this.layouts)
            {
                if (layout is ControlLayoutSystem)
                    ((ControlLayoutSystem)layout).Controls.Clear();
            }

            this.splitLayout = new SplitLayoutSystem();
        }
        // reviewed with 2.4
        internal void xfe00f14c7d278916()
        {
            if (this.xa03963cfd21be862 > 0)
                --this.xa03963cfd21be862;
            if (this.xa03963cfd21be862 != 0)
                return;
            this.x7e9646eed248ed11();
        }

        internal void PropagateNewRenderer()
        {
            this.CalculateAllMetricsAndLayout();
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.CalculateAllMetricsAndLayout();
        }

        /// <summary>
        /// Retrieves the window whose tab is at the specified location.
        /// 
        /// </summary>
        /// <param name="position">The location, in client coordinates, to search.</param>
        /// <returns>
        /// The window found.
        /// </returns>
        public DockControl GetWindowAt(Point position)
        {
            ControlLayoutSystem controlLayout = this.GetLayoutSystemAt(position) as ControlLayoutSystem;
            return controlLayout != null ? controlLayout.GetControlAt(position) : null;
        }

        /// <summary>
        /// Retrieves the layout system at the specified location.
        /// 
        /// </summary>
        /// <param name="position">The location, in client coordinates, to search.</param>
        /// <returns>
        /// The layout system found. If no layout system was found, a null reference is returned.
        /// </returns>
        // reviewed with 2.4
        public LayoutSystemBase GetLayoutSystemAt(Point position)
        {
            LayoutSystemBase layout = null;
            foreach (LayoutSystemBase layout1 in this.layouts)
            {
                if (layout1.Bounds.Contains(position) && (!(layout1 is ControlLayoutSystem) || !((ControlLayoutSystem)layout1).Collapsed))
                {
                    layout = layout1;
                    if (layout is ControlLayoutSystem)
                        break;
                }
            }
            return layout;
        }

        internal virtual void x7e9646eed248ed11()
        {
            this.x7e9646eed248ed11(false);
        }

        private void x7e9646eed248ed11(bool xaa70223940104cbe)
        {
            this.layouts.Clear();
            this.layout = null;

            this.x5b6d1177ca7f3461(this.splitLayout);
            if (xaa70223940104cbe || this.xa03963cfd21be862 != 0)
                return;
            this.x333d8ec4f70a6d86();
            Application.Idle += new EventHandler(this.x4130a50ad5956bc2);
        }
        // reviewed with 2.4
        private void x4130a50ad5956bc2(object sender, EventArgs e)
        {
            Application.Idle -= new EventHandler(this.x4130a50ad5956bc2);
            bool flag = false;

            while (this.LayoutSystem.Optimize())
                flag = true;

            if (flag)
                this.x7e9646eed248ed11(true);
        }
        // reviewed with 2.4
        private void x5b6d1177ca7f3461(LayoutSystemBase x6e150040c8d97700)
        {
            this.layouts.Add(x6e150040c8d97700);
            if (x6e150040c8d97700 is SplitLayoutSystem)
            {
                foreach (LayoutSystemBase layout in ((SplitLayoutSystem)x6e150040c8d97700).LayoutSystems)
                {
                    this.x5b6d1177ca7f3461(layout);
                }
            }
        }
        // reviewed with 2.4
        internal bool x61d88745bde7a5ec()
        {
            foreach (LayoutSystemBase layout in this.layouts)
            {
                if (layout is ControlLayoutSystem)
                    return false;
            }
            return true;
        }

        // reviewed with 2.4
        internal void x333d8ec4f70a6d86()
        {
            if (this.CanShowCollapsed)
            {
                bool flag2 = true;
                foreach (LayoutSystemBase layoutSystemBase in this.layouts)
                {
                    if (layoutSystemBase is ControlLayoutSystem && !((ControlLayoutSystem)layoutSystemBase).Collapsed)
                    {
                        flag2 = false;
                        break;
                    }
                }
                int num2 = 0;

                if (!flag2)
                    num2 += this.ContentSize + (this.AllowResize ? 4 : 0);
                if (this.Vertical && this.Width != num2)
                    this.Width = num2;
                else if (!this.Vertical && this.Height != num2)
                    this.Height = num2;
                else
                    this.CalculateAllMetricsAndLayout();
            }
            else
                this.CalculateAllMetricsAndLayout();
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.CalculateAllMetricsAndLayout();
        }
        // reviewed with 2.4
        internal void xec9697acef66c1bc(LayoutSystemBase layout, Rectangle bounds)
        {
            if (!this.IsHandleCreated)
                return;
            using (Graphics g = this.CreateGraphics())
            {
                RendererBase render = this.WorkingRender;
                render.StartRenderSession(HotkeyPrefix.None);
                if (layout == this.splitLayout)
                    layout.Layout(render, g, bounds, this.IsFloating);
                else
                    layout.Layout(render, g, bounds, false);
                render.FinishRenderSession();
            }
        }

        /// <summary>
        /// Calculates the layout of the layout system hierarchy and triggers a redraw.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This is an advanced method that should be used after calling SetWorkingSize on layout systems.
        /// </para>
        /// 
        /// </remarks>
        // reviewed with 2.4
        public void CalculateAllMetricsAndLayout()
        {
            if (!this.IsHandleCreated)
                return;
            if (this.Capture && !this.IsFloating)
                this.Capture = false;

            this.x21ed2ecc088ef4e4 = this.DisplayRectangle;

            if (!this.AllowResize)
            {
                this.x59f159fe47159543 = Rectangle.Empty;
            }
            else
            {
                switch (this.Dock)
                {
                    case DockStyle.Top:
                        this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Left, this.x21ed2ecc088ef4e4.Bottom - 4, this.x21ed2ecc088ef4e4.Width, 4);
                        this.x21ed2ecc088ef4e4.Height -= 4;
                        break;
                    case DockStyle.Bottom:
                        this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Left, this.x21ed2ecc088ef4e4.Top, this.x21ed2ecc088ef4e4.Width, 4);
                        this.x21ed2ecc088ef4e4.Offset(0, 4);
                        this.x21ed2ecc088ef4e4.Height -= 4;
                        break;
                    case DockStyle.Left:
                        this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Right - 4, this.x21ed2ecc088ef4e4.Top, 4, this.x21ed2ecc088ef4e4.Height);
                        this.x21ed2ecc088ef4e4.Width -= 4;
                        break;
                    case DockStyle.Right:
                        this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Left, this.x21ed2ecc088ef4e4.Top, 4, this.x21ed2ecc088ef4e4.Height);
                        this.x21ed2ecc088ef4e4.Offset(4, 0);
                        this.x21ed2ecc088ef4e4.Width -= 4;
                        break;
                    default:
                        this.x59f159fe47159543 = Rectangle.Empty;
                        break;
                }
            }

//            if (this.Vertical && this.x21ed2ecc088ef4e4.Width > 0)
//                this.ContentSize = this.x21ed2ecc088ef4e4.Width;
//            else if (!this.Vertical && this.x21ed2ecc088ef4e4.Height > 0)
//                this.ContentSize = this.x21ed2ecc088ef4e4.Height;
//            this.x59f159fe47159543.WorkingSize = this.x21ed2ecc088ef4e4.Size;

            this.xec9697acef66c1bc(this.splitLayout, this.x21ed2ecc088ef4e4);
            this.Invalidate();
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Form form = this.FindForm();
            if (form != null && form.WindowState == FormWindowState.Minimized)
                return;
            this.CalculateAllMetricsAndLayout();
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (this.layout == null)
                return;
            this.layout.OnMouseLeave();
            this.layout = null;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (this.layout != null)
                this.layout.OnMouseDoubleClick();
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed with 2.4
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.layout != null)
                this.layout.OnMouseDown(e);

            if (this.Manager != null && this.x59f159fe47159543.Contains(e.X, e.Y) && e.Button == MouseButtons.Left)
            {
                if (this.x754f1c6f433be75d != null)
                    this.x754f1c6f433be75d.Dispose();
                this.x754f1c6f433be75d = new x09c1c18390e52ebf(this.Manager, this, new System.Drawing.Point(e.X, e.Y));
                this.x754f1c6f433be75d.Cancelled += new EventHandler(this.x30c28c62b1a6040e);
                this.x754f1c6f433be75d.Committed += new x09c1c18390e52ebf.ResizingManagerFinishedEventHandler(this.xa7afb2334769edc5);
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed with 2.4
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.layout != null)
                this.layout.OnMouseUp(e);
            else
            {
                if (this.x754f1c6f433be75d != null)
                    this.x754f1c6f433be75d.Commit();
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);
            LayoutSystemBase layoutAt = this.GetLayoutSystemAt(this.PointToClient(new System.Drawing.Point(drgevent.X, drgevent.Y)));
            if (layoutAt != null)
                layoutAt.OnDragOver(drgevent);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed with 2.4
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.Capture)
            {
                if (this.layout != null)
                    this.layout.OnMouseMove(e);
                else
                {
                    if (this.x754f1c6f433be75d == null)
                        return;
                    this.x754f1c6f433be75d.OnMouseMove(new Point(e.X, e.Y));
                }
            }
            else
            {
                LayoutSystemBase layoutSystemAt = this.GetLayoutSystemAt(new Point(e.X, e.Y));
                if (layoutSystemAt != null)
                {
                    if (this.layout != null && this.layout != layoutSystemAt)
                        this.layout.OnMouseLeave();
                    layoutSystemAt.OnMouseMove(e);
                    this.layout = layoutSystemAt;
                }
                else
                {
                    if (this.layout != null)
                    {
                        this.layout.OnMouseLeave();
                        this.layout = null;
                    }
                    if (this.x59f159fe47159543.Contains(e.X, e.Y))
                    {
                        if (this.Vertical)
                            Cursor.Current = Cursors.VSplit;
                        else
                            Cursor.Current = Cursors.HSplit;
                    }
                    else
                        Cursor.Current = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            this.WorkingRender.DrawDockContainerBackground(pevent.Graphics, this, this.DisplayRectangle);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed
        protected override void OnPaint(PaintEventArgs e)
        {
            if (DockContainer.x1f080f764b4036b1)
                return;

            Control container = this.Manager != null ? this.Manager.DockSystemContainer : null;
            this.WorkingRender.StartRenderSession(HotkeyPrefix.None);
            this.LayoutSystem.x84b6f3c22477dacb(this.WorkingRender, e.Graphics, this.Font);
            if (this.AllowResize)
                this.WorkingRender.DrawSplitter(container, this, e.Graphics, this.x59f159fe47159543, this.Dock == DockStyle.Top || this.Dock == DockStyle.Bottom ? Orientation.Horizontal : Orientation.Vertical);
            this.WorkingRender.FinishRenderSession();

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, Color.White)))
            {
                using (Font font = new Font(this.Font.FontFamily.Name, 14f, FontStyle.Bold))
                    e.Graphics.DrawString("evaluationcontainer", font, brush, (float)(this.x21ed2ecc088ef4e4.Left + 4), (float)(this.x21ed2ecc088ef4e4.Top - 4), StringFormat.GenericTypographic);
            }
        }
        // reviewed with 2.4
        internal void xa2414c47d888068e(object sender, EventArgs e)
        {
            foreach (LayoutSystemBase layout in this.layouts)
            {
                if (layout is ControlLayoutSystem && ((ControlLayoutSystem)layout).x61ce2417e4ef76f9())
                    break;
            }
        }

        internal void x19e788b09b195d4f(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            foreach (LayoutSystemBase layout in this.layouts)
            {
                if (layout is ControlLayoutSystem)
                    ((ControlLayoutSystem)layout).x82dd941e2755ffd2();
            }
        }

        private void x1b91eb6f6bb77abc()
        {
            this.x754f1c6f433be75d.Cancelled -= new EventHandler(this.x30c28c62b1a6040e);
            this.x754f1c6f433be75d.Committed -= new x09c1c18390e52ebf.ResizingManagerFinishedEventHandler(this.xa7afb2334769edc5);
            this.x754f1c6f433be75d = null;
        }

        private void x30c28c62b1a6040e(object sender, EventArgs e)
        {
            this.x1b91eb6f6bb77abc();
        }

        private void xa7afb2334769edc5(int x0d4b3b88c5b24565)
        {
            this.x1b91eb6f6bb77abc();
            this.ContentSize = x0d4b3b88c5b24565;
        }

        /// <summary>
        /// Raises the DockingStarted event.
        /// 
        /// </summary>
        /// <param name="e">The data for the event.</param>
        // reviewed
        protected internal virtual void OnDockingStarted(EventArgs e)
        {
            if (this.DockingStarted != null)
                this.DockingStarted(this, e);
            if (this.Manager != null)
                this.Manager.OnDockingStarted(e);
        }

        /// <summary>
        /// Raises the DockingFinished event.
        /// 
        /// </summary>
        /// <param name="e">The data for the event.</param>
        // reviewed
        protected internal virtual void OnDockingFinished(EventArgs e)
        {
            if (this.DockingFinished != null)
                this.DockingFinished(this, e);
            if (this.Manager != null)
                this.Manager.OnDockingFinished(e);
        }

        private string xa3a7472ac4e61f76(Point position)
        {
            LayoutSystemBase layoutAt = this.GetLayoutSystemAt(position);
            if (layoutAt is ControlLayoutSystem)
                return ((ControlLayoutSystem)layoutAt).xe0e7b93bedab6c05(position);
            else
                return "";
        }
    }
}
