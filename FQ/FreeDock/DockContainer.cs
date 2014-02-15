//using Divelements.Util.Registration;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using FQ.FreeDock.Design;
using FQ.FreeDock.Rendering;
using TD.Util;

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
        private int xd987e7deb2afdfde = 100;
        private const int xdb2b8faf7aefe99a = 32;
        private SandDockManager x91f347c6e97f1846;
        private SplitLayoutSystem x35c76d526f88c3c8;
        internal ArrayList x83627743ea4ce5a2;
        private RendererBase xa2c39ea75c543fc7;
        private xf8f9565783602018 xac1c850120b1f254;
        private int xa03963cfd21be862;
        private static bool x1f080f764b4036b1;
//        private xbd7c5470fc89975b x266365ea27fa7af8;
        private x09c1c18390e52ebf x754f1c6f433be75d;
        private bool x841598f8fd19209c;
        internal LayoutSystemBase x3df31cf55a47bc37;

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
                label_11:
                if (this.Dock != DockStyle.Top)
                    goto label_3;
                else
                    goto label_8;
                label_1:
                if (15 == 0)
                    ;
                label_2:
                if (this.x35c76d526f88c3c8.SplitMode == orientation)
                    return;
                this.x35c76d526f88c3c8.SplitMode = orientation;
                if (0 == 0)
                    return;
                if (0 != 0)
                {
                    if (0 != 0)
                        return;
                    else
                        goto label_7;
                }
                else
                    goto label_1;
                label_3:
                if (this.Dock != DockStyle.Bottom)
                    goto label_2;
                label_7:
                if (15 == 0)
                    goto label_11;
                label_8:
                orientation = Orientation.Vertical;
                if (-2 == 0)
                {
                    if (0 == 0)
                        goto label_3;
                    else
                        goto label_1;
                }
                else
                    goto label_2;
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
                if (this.LayoutSystem.LayoutSystems.Count == 1)
                    return this.LayoutSystem.LayoutSystems[0] is ControlLayoutSystem;
                else
                    return false;
            }
        }

        internal virtual RendererBase x631afe05fcecf1f4
        {
            get
            {
                if (this.x91f347c6e97f1846 != null)
                    goto label_3;
                label_1:
                if (this.xa2c39ea75c543fc7 != null)
                {
                    if (0 != 0)
                        goto label_3;
                }
                else
                    this.xa2c39ea75c543fc7 = (RendererBase)new WhidbeyRenderer();
                return this.xa2c39ea75c543fc7;
                label_3:
                if (0 != 0 || this.x91f347c6e97f1846.Renderer != null)
                    return this.x91f347c6e97f1846.Renderer;
                else
                    goto label_1;
            }
        }

        /// <summary>
        /// The size of the content within the container.
        /// 
        /// </summary>
        public int ContentSize
        {
            get
            {
                return this.xd987e7deb2afdfde;
            }
            set
            {
                value = Math.Max(value, 32);
                while (value == this.xd987e7deb2afdfde)
                {
                    if ((uint)value - (uint)value >= 0U)
                        return;
                }
                this.x841598f8fd19209c = true;
                if (-2 == 0)
                    ;
                this.xd987e7deb2afdfde = value;
                this.x333d8ec4f70a6d86();
            }
        }

        internal int x555227b0d2a372bd
        {
            get
            {
                if (this.x61c108cc44ef385a)
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
                if (this.Manager == null)
                    return true;
                else
                    return this.Manager.AllowDockContainerResize;
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

        internal bool x972331c8ecf83413
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
        public virtual SandDockManager Manager
        {
            get
            {
                return this.x91f347c6e97f1846;
            }
            set
            {
                if (this.x91f347c6e97f1846 != null)
                    goto label_11;
                label_9:
                if (value != null)
                    goto label_6;
                else
                    goto label_10;
                label_5:
                do
                {
                    do
                    {
                        this.x91f347c6e97f1846 = value;
                    }
                    while ((int)byte.MaxValue == 0);
                    if (0 != 0)
                        goto label_7;
                }
                while (8 == 0);
                if (this.x91f347c6e97f1846 == null)
                    return;
                this.x91f347c6e97f1846.RegisterDockContainer(this);
                this.LayoutSystem.x56e964269d48cfcc(this);
                return;
                label_6:
                if (value.DockSystemContainer == null)
                    goto label_5;
                label_7:
                if (!this.IsFloating && this.Parent != null && this.Parent != value.DockSystemContainer)
                    throw new ArgumentException("This DockContainer cannot use the specified manager as the manager's DockSystemContainer differs from the DockContainer's Parent.");
                else
                    goto label_5;
                label_10:
                if (0 == 0)
                    goto label_5;
                label_11:
                this.x91f347c6e97f1846.UnregisterDockContainer(this);
                goto label_9;
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
                return new System.Drawing.Size(0, 0);
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

        internal bool x61c108cc44ef385a
        {
            get
            {
                if (this.Dock != DockStyle.Left)
                    return this.Dock == DockStyle.Right;
                else
                    return true;
            }
        }

        /// <summary>
        /// The root layout system within this container. This is always a split layout system.
        /// 
        /// </summary>
        [Browsable(false)]
        public virtual SplitLayoutSystem LayoutSystem
        {
            get
            {
                return this.x35c76d526f88c3c8;
            }
            set
            {
                if (value == this.x35c76d526f88c3c8)
                    return;
                if (-2 == 0 || value == null)
                    throw new ArgumentNullException("value");
                DockContainer.x1f080f764b4036b1 = true;
                try
                {
                    if (this.x35c76d526f88c3c8 != null)
                        goto label_12;
                    label_7:
                    if (!this.x841598f8fd19209c)
                        goto label_8;
                    label_5:
                    this.x35c76d526f88c3c8 = value;
                    if (0 == 0)
                    {
                        this.x35c76d526f88c3c8.x56e964269d48cfcc(this);
                        this.x7e9646eed248ed11();
                        return;
                    }
                    else
                        goto label_10;
                    label_8:
                    if (this.x61c108cc44ef385a)
                    {
                        this.xd987e7deb2afdfde = Convert.ToInt32(value.WorkingSize.Width);
                        goto label_11;
                    }
                    label_10:
                    this.xd987e7deb2afdfde = Convert.ToInt32(value.WorkingSize.Height);
                    label_11:
                    this.x841598f8fd19209c = true;
                    goto label_5;
                    label_12:
                    this.x35c76d526f88c3c8.x56e964269d48cfcc((DockContainer)null);
                    goto label_7;
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
        internal virtual bool x0c2484ccd29b8358
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
            if (0 == 0)
                goto label_6;
            label_1:
            this.xac1c850120b1f254.x9b21ee8e7ceaada3 += new xf8f9565783602018.x58986a4a0b75e5b5(this.xa3a7472ac4e61f76);
            this.BackColor = SystemColors.Control;
            return;
            label_6:
//            this.x266365ea27fa7af8 = LicenseManager.Validate(typeof(DockContainer), (object)this) as xbd7c5470fc89975b;
            this.x35c76d526f88c3c8 = new SplitLayoutSystem();
            while ((int)byte.MaxValue != 0)
            {
                this.x35c76d526f88c3c8.x56e964269d48cfcc(this);
                this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
                this.SetStyle(ControlStyles.Selectable, false);
                if (int.MinValue != 0)
                {
                    this.x83627743ea4ce5a2 = new ArrayList();
                    this.xac1c850120b1f254 = new xf8f9565783602018((Control)this);
                    this.xac1c850120b1f254.xa6e4f463e64a5987 = false;
                    if (-2 != 0)
                        goto label_1;
                }
                else
                    goto label_1;
            }
        }

        internal virtual void x5fc4eceec879ff0f()
        {
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            while (this.Manager == null)
            {
                if (-1 != 0)
                    return;
                if (0 == 0)
                    break;
            }
            if (this.Parent == null && (0 != 0 || 0 == 0) || this.Parent is xd936980ea1aac341)
                return;
            this.Manager.DockSystemContainer = this.Parent;
        }

        internal void x8ba6fce4f4601549(ShowControlContextMenuEventArgs xfbf34718e704c6bc)
        {
            if (this.Manager == null)
                return;
            this.Manager.OnShowControlContextMenu(xfbf34718e704c6bc);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                goto label_3;
            label_2:
            base.Dispose(disposing);
            return;
            label_3:
            if (this.xa2c39ea75c543fc7 != null)
                goto label_4;
            else
                goto label_6;
            label_1:
            this.Manager = null;
            this.xac1c850120b1f254.x9b21ee8e7ceaada3 -= new xf8f9565783602018.x58986a4a0b75e5b5(this.xa3a7472ac4e61f76);
            this.xac1c850120b1f254.Dispose();
            goto label_2;
            label_4:
            this.xa2c39ea75c543fc7.Dispose();
            label_5:
            this.xa2c39ea75c543fc7 = null;
            goto label_1;
            label_6:
            goto label_1;
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
            return this.CreateNewLayoutSystem(new DockControl[1]
            {
                control
            }, size);
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
            {
                if (3 != 0)
                    throw new ArgumentNullException("controls");
                else
                    goto label_3;
            }
            else
                goto label_5;
            label_2:
            if (controls == null || controls.Length == 0)
                goto label_6;
            label_3:
            ControlLayoutSystem controlLayoutSystem;
            controlLayoutSystem.Controls.AddRange(controls);
            if (-1 == 0 || 0 != 0 && 0 != 0)
                goto label_2;
            else
                goto label_6;
            label_5:
            controlLayoutSystem = this.xd6284ffe96aec512();
            controlLayoutSystem.WorkingSize = size;
            goto label_2;
            label_6:
            return controlLayoutSystem;
        }

        internal virtual ControlLayoutSystem xd6284ffe96aec512()
        {
            return new ControlLayoutSystem();
        }

        internal object x7159e85e85b84817(System.Type x96168bd31f23b747)
        {
            return this.GetService(x96168bd31f23b747);
        }

        internal void x272ed7848e373c56()
        {
            ++this.xa03963cfd21be862;
            this.x35c76d526f88c3c8.x56e964269d48cfcc((DockContainer)null);
            IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
            try
            {
                while (true)
                {
                    LayoutSystemBase layoutSystemBase;
                    do
                    {
                        if (!enumerator.MoveNext())
                        {
                            if ((int)byte.MaxValue != 0)
                                goto label_9;
                        }
                        layoutSystemBase = (LayoutSystemBase)enumerator.Current;
                    }
                    while (0 == 0 && !(layoutSystemBase is ControlLayoutSystem));
                    ((ControlLayoutSystem)layoutSystemBase).Controls.Clear();
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if ((int)byte.MaxValue == 0 || disposable != null)
                    disposable.Dispose();
            }
            label_9:
            this.x35c76d526f88c3c8 = new SplitLayoutSystem();
        }

        internal void xfe00f14c7d278916()
        {
            if (this.xa03963cfd21be862 > 0)
                --this.xa03963cfd21be862;
            if (this.xa03963cfd21be862 != 0)
                return;
            this.x7e9646eed248ed11();
        }

        internal void x4481febbc2e58301()
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
        public DockControl GetWindowAt(System.Drawing.Point position)
        {
            ControlLayoutSystem controlLayoutSystem = this.GetLayoutSystemAt(position) as ControlLayoutSystem;
            if (controlLayoutSystem != null)
                return controlLayoutSystem.GetControlAt(position);
            else
                return (DockControl)null;
        }

        /// <summary>
        /// Retrieves the layout system at the specified location.
        /// 
        /// </summary>
        /// <param name="position">The location, in client coordinates, to search.</param>
        /// <returns>
        /// The layout system found. If no layout system was found, a null reference is returned.
        /// </returns>
        public LayoutSystemBase GetLayoutSystemAt(System.Drawing.Point position)
        {
            LayoutSystemBase layoutSystemBase1 = (LayoutSystemBase)null;
            IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
            try
            {
                label_3:
                do
                {
                    do
                    {
                        if (!enumerator.MoveNext())
                        {
                            if (0 == 0)
                                break;
                        }
                        else
                            goto label_22;
                        label_5:
                        if (0 == 0)
                            goto label_7;
                        label_6:
                        Rectangle bounds;
                        if (bounds.Contains(position))
                            goto label_17;
                        label_7:
                        if ((int)byte.MaxValue == 0)
                            goto label_19;
                        else
                            continue;
                        label_8:
                        if (8 == 0 || -1 == 0)
                            goto label_5;
                        else
                            goto label_2;
                        label_12:
                        if (15 == 0)
                            goto label_19;
                        label_13:
                        LayoutSystemBase layoutSystemBase2;
                        if (!((ControlLayoutSystem)layoutSystemBase2).Collapsed)
                            goto label_20;
                        label_14:
                        if (4 != 0)
                        {
                            if (2 == 0)
                            {
                                if (0 == 0)
                                    goto label_20;
                                else
                                    goto label_6;
                            }
                            else
                                goto label_8;
                        }
                        else
                            goto label_20;
                        label_17:
                        if (layoutSystemBase2 is ControlLayoutSystem)
                        {
                            if (8 != 0)
                                goto label_12;
                        }
                        else
                            goto label_20;
                        label_19:
                        while (0 == 0)
                        {
                            if (8 != 0)
                            {
                                if (3 == 0)
                                {
                                    if (4 != 0)
                                    {
                                        if (0 == 0)
                                            goto label_12;
                                    }
                                    else
                                        goto label_14;
                                }
                                else
                                    goto label_13;
                            }
                            else
                                goto label_8;
                        }
                        goto label_17;
                        label_20:
                        layoutSystemBase1 = layoutSystemBase2;
                        continue;
                        label_22:
                        layoutSystemBase2 = (LayoutSystemBase)enumerator.Current;
                        bounds = layoutSystemBase2.Bounds;
                        goto label_6;
                    }
                    while (!(layoutSystemBase1 is ControlLayoutSystem));
                    goto label_26;
                    label_2:
                    ;
                }
                while (-2 == 0);
                goto label_3;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            label_26:
            return layoutSystemBase1;
        }

        internal virtual void x7e9646eed248ed11()
        {
            this.x7e9646eed248ed11(false);
        }

        private void x7e9646eed248ed11(bool xaa70223940104cbe)
        {
            this.x83627743ea4ce5a2.Clear();
            this.x3df31cf55a47bc37 = (LayoutSystemBase)null;
            if (0 != 0)
                return;
            this.x5b6d1177ca7f3461((LayoutSystemBase)this.x35c76d526f88c3c8);
            if (xaa70223940104cbe || this.xa03963cfd21be862 != 0)
                return;
            this.x333d8ec4f70a6d86();

            Application.Idle += new EventHandler(this.x4130a50ad5956bc2);
        }

        private void x4130a50ad5956bc2(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            Application.Idle -= new EventHandler(this.x4130a50ad5956bc2);
            bool flag1;

            goto label_7;
            label_1:
            if (4 != 0)
                return;
            label_3:
            this.x7e9646eed248ed11(true);
            bool flag2;
            bool flag3;
            goto label_1;
            label_7:
            flag1 = false;
            flag2 = false;
            while (true)
            {
                flag3 = this.LayoutSystem.Optimize();
                if (flag3)
                    flag2 = true;
                else
                    break;
            }
            if (flag2)
                goto label_3;
        }

        private void x5b6d1177ca7f3461(LayoutSystemBase x6e150040c8d97700)
        {
            this.x83627743ea4ce5a2.Add((object)x6e150040c8d97700);
            if (!(x6e150040c8d97700 is SplitLayoutSystem))
                return;
            IEnumerator enumerator = ((SplitLayoutSystem)x6e150040c8d97700).LayoutSystems.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                    this.x5b6d1177ca7f3461((LayoutSystemBase)enumerator.Current);
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (0 != 0 || disposable != null)
                    disposable.Dispose();
            }
        }

        internal bool x61d88745bde7a5ec()
        {
            IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
            bool flag;
            try
            {
                do
                {
                    if (!enumerator.MoveNext())
                        goto label_15;
                }
                while (!((LayoutSystemBase)enumerator.Current is ControlLayoutSystem));
                flag = false;
                if (int.MaxValue != 0)
                    goto label_16;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;

                goto label_10;
                label_6:
                if (true)
                {
                        goto label_14;
                }
                else
                    goto label_13;
                label_8:



                    goto label_14;


                label_10:
                if (3 != 0)
                {

                    goto label_13;
                }
                else
                    goto label_6;
                label_12:
                disposable.Dispose();
                goto label_6;
                label_13:
                if (disposable != null)
                    goto label_12;
                else
                    goto label_8;
                label_14:
                ;
            }
            label_15:
            return true;
            label_16:
            return flag;
        }

        internal void x333d8ec4f70a6d86()
        {
            if (!this.x0c2484ccd29b8358)
                goto label_4;
            else
                goto label_19;
            label_1:
            if (0 != 0)
                goto label_8;
            label_2:
            this.CalculateAllMetricsAndLayout();
            return;
            label_4:
            this.CalculateAllMetricsAndLayout();
            bool flag1;
            int num1;

            return;


            label_8:
            int num2;
            bool flag2;
            if (!this.x61c108cc44ef385a)
            {
                if (this.Height == num2)
                {
                    if (int.MinValue == 0)
                    {


                    }
                    else
                        goto label_2;
                }
                this.Height = num2;
                return;
            }
            else
                goto label_2;
            label_19:
            flag2 = true;
            IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
            try
            {
                label_23:
                ControlLayoutSystem controlLayoutSystem;
                do
                {
                    if (!enumerator.MoveNext())
                    {

                        goto label_36;
                    }
                    LayoutSystemBase layoutSystemBase = (LayoutSystemBase)enumerator.Current;
                    do
                    {


                            if (!(layoutSystemBase is ControlLayoutSystem))
                                goto label_23;


                        label_24:
                        controlLayoutSystem = (ControlLayoutSystem)layoutSystemBase;
                        continue;
                        label_30:
                        if (0 == 0)
                        {
                            if (int.MaxValue != 0)
                                goto label_24;
                            else
                                goto label_36;
                        }
                        else
                            break;
                    }
                    while (false);
                }
                while (controlLayoutSystem.Collapsed);
                flag2 = false;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            label_36:
            num2 = 0;
            if (15 == 0)
                ;
            if (!flag2)
                goto label_18;
            label_14:
            while (!this.x61c108cc44ef385a)
            {
                if (0 != 0)
                {
                    if (0 == 0)
                        break;
                }
                else
                    goto label_8;
            }
            if (this.Width == num2)
            {
                if ((num2 | (int)byte.MaxValue) == 0)
                    return;
                else
                    goto label_8;
            }
            else
            {
                this.Width = num2;


                    return;
            }
            label_18:
            num2 += this.ContentSize + (this.AllowResize ? 4 : 0);
            goto label_14;
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

        internal void xec9697acef66c1bc(LayoutSystemBase x6e150040c8d97700, Rectangle xda73fcb97c77d998)
        {
            if (!this.IsHandleCreated)
                return;
            using (Graphics graphics = this.CreateGraphics())
            {
                RendererBase x631afe05fcecf1f4 = this.x631afe05fcecf1f4;
                x631afe05fcecf1f4.StartRenderSession(HotkeyPrefix.None);
                if (0 != 0)
                    goto label_5;
                else
                    goto label_9;
                label_4:
                if (x6e150040c8d97700 == this.x35c76d526f88c3c8)
                {
                    x6e150040c8d97700.Layout(x631afe05fcecf1f4, graphics, xda73fcb97c77d998, this.IsFloating);
                    goto label_6;
                }
                label_5:
                x6e150040c8d97700.Layout(x631afe05fcecf1f4, graphics, xda73fcb97c77d998, false);
                label_6:
                x631afe05fcecf1f4.FinishRenderSession();
                if (3 != 0)
                    return;
                else
                    goto label_4;
                label_9:
                if (0 == 0)
                    goto label_4;
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
        public void CalculateAllMetricsAndLayout()
        {
            if (!this.IsHandleCreated)
                return;
            if (this.Capture && !this.IsFloating)
                this.Capture = false;
            do
            {
                this.x21ed2ecc088ef4e4 = this.DisplayRectangle;
                if (0 != 0)
                    goto label_18;
                label_2:
                if (!this.AllowResize)
                    continue;
                label_18:
                switch (this.Dock)
                {
                    case DockStyle.Top:
                        goto label_10;
                    case DockStyle.Bottom:
                        goto label_11;
                    case DockStyle.Left:
                        this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Right - 4, this.x21ed2ecc088ef4e4.Top, 4, this.x21ed2ecc088ef4e4.Height);
                        if (0 == 0)
                            this.x21ed2ecc088ef4e4.Width -= 4;
                        if (0 != 0 || -1 != 0)
                            goto label_1;
                        else
                            goto label_2;
                    case DockStyle.Right:
                        goto label_12;
                    default:
                        goto label_6;
                }
            }
            while ((int)byte.MaxValue == 0);
            goto label_4;
            label_1:
            this.xec9697acef66c1bc((LayoutSystemBase)this.x35c76d526f88c3c8, this.x21ed2ecc088ef4e4);
            this.Invalidate();
            return;
            label_4:
            if (1 != 0)
            {
                this.x59f159fe47159543 = Rectangle.Empty;
                if (int.MaxValue == 0)
                    return;
                else
                    goto label_1;
            }
            else
                goto label_13;
            label_6:
            this.x59f159fe47159543 = Rectangle.Empty;
            goto label_1;
            label_10:
            this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Left, this.x21ed2ecc088ef4e4.Bottom - 4, this.x21ed2ecc088ef4e4.Width, 4);
            this.x21ed2ecc088ef4e4.Height -= 4;
            goto label_1;
            label_11:
            this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Left, this.x21ed2ecc088ef4e4.Top, this.x21ed2ecc088ef4e4.Width, 4);
            if (0 == 0)
            {
                if (0 == 0)
                    this.x21ed2ecc088ef4e4.Offset(0, 4);
                this.x21ed2ecc088ef4e4.Height -= 4;
                goto label_1;
            }
            else
                goto label_1;
            label_12:
            this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Left, this.x21ed2ecc088ef4e4.Top, 4, this.x21ed2ecc088ef4e4.Height);
            this.x21ed2ecc088ef4e4.Offset(4, 0);
            label_13:
            this.x21ed2ecc088ef4e4.Width -= 4;
            goto label_1;
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
            if (-1 != 0)
                ;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (this.x3df31cf55a47bc37 == null)
                return;
            this.x3df31cf55a47bc37.OnMouseLeave();
            this.x3df31cf55a47bc37 = (LayoutSystemBase)null;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (0 == 0)
                goto label_8;
            label_3:
            if (0 == 0)
                return;
            label_5:
            while (this.x3df31cf55a47bc37 != null)
            {
                this.x3df31cf55a47bc37.OnMouseDoubleClick();
                if (int.MaxValue != 0)
                {
                    if (0 != 0)
                        return;
                    else
                        goto label_3;
                }
            }
            if (0 == 0)
            {
                while (0 != 0)
                {
                    if (3 != 0)
                        goto label_3;
                }
                if (-2 == 0)
                    goto label_3;
            }
            if (2 != 0)
                return;
            label_8:
//            if (!this.x266365ea27fa7af8.Locked)
            goto label_5;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (1 == 0)
            {
                if (int.MaxValue != 0)
                    goto label_14;
                else
                    goto label_8;
            }
            else
                goto label_13;
            label_4:
            this.x754f1c6f433be75d.x868a32060451dd2e += new EventHandler(this.x30c28c62b1a6040e);
            this.x754f1c6f433be75d.x67ecc0d0e7c9a202 += new x09c1c18390e52ebf.ResizingManagerFinishedEventHandler(this.xa7afb2334769edc5);
            return;
            label_8:
            while (8 == 0 || this.Manager != null)
            {
                if (e.Button == MouseButtons.Left)
                    goto label_6;
                else
                    goto label_5;
                label_3:
                this.x754f1c6f433be75d = new x09c1c18390e52ebf(this.Manager, this, new System.Drawing.Point(e.X, e.Y));
                goto label_4;
                label_5:
                if (0 == 0)
                {
                    if (int.MinValue != 0)
                    {
                        if (0 == 0)
                            break;
                        else
                            goto label_14;
                    }
                    else
                        continue;
                }
                else
                    goto label_3;
                label_6:
                if (this.x754f1c6f433be75d != null)
                {
                    do
                    {
                        this.x754f1c6f433be75d.Dispose();
                    }
                    while (0 != 0);
                    goto label_3;
                }
                else
                    goto label_3;
            }
            return;
            label_13:
//            if (this.x266365ea27fa7af8.Locked)
//                return;
            label_14:
            if (this.x3df31cf55a47bc37 == null)
            {
                if (this.x59f159fe47159543.Contains(e.X, e.Y))
                    goto label_8;
            }
            else if (2 != 0)
                this.x3df31cf55a47bc37.OnMouseDown(e);
            else
                goto label_4;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
//            if (!this.x266365ea27fa7af8.Locked)
            if (true) 
            {
                if (this.x3df31cf55a47bc37 == null)
                {
                    if (this.x754f1c6f433be75d == null)
                        return;
                }
                else
                    goto label_6;
                label_3:
                this.x754f1c6f433be75d.Commit();
                return;
                label_6:
                this.x3df31cf55a47bc37.OnMouseUp(e);
                if (0 != 0)
                    goto label_3;
            }
            else if (0 != 0)
                ;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);
            LayoutSystemBase layoutSystemAt;
            do
            {
                layoutSystemAt = this.GetLayoutSystemAt(this.PointToClient(new System.Drawing.Point(drgevent.X, drgevent.Y)));
                if (0 == 0)
                    goto label_2;
            }
            while (0 != 0);
            label_1:
            layoutSystemAt.OnDragOver(drgevent);
            return;
            label_2:
            if (layoutSystemAt != null)
                goto label_1;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            while (0 == 0)
            {
                if (!this.Capture)
                {
                    if (0 == 0)
                        goto label_13;
                    else
                        goto label_9;
                }
                else if (this.x3df31cf55a47bc37 == null)
                {
                    if (0 == 0)
                        goto label_19;
                }
                else
                {
                    this.x3df31cf55a47bc37.OnMouseMove(e);
                    return;
                }
            }
            goto label_17;
            label_9:
            LayoutSystemBase layoutSystemAt;
            layoutSystemAt.OnMouseMove(e);
            if (0 == 0)
            {
                this.x3df31cf55a47bc37 = layoutSystemAt;
                return;
            }
            else
                goto label_13;
            label_12:
            while (this.x3df31cf55a47bc37 != layoutSystemAt)
            {
                this.x3df31cf55a47bc37.OnMouseLeave();
                if (0 == 0)
                    goto label_9;
            }
            if (0 == 0)
                goto label_9;
            else
                goto label_19;
            label_13:
            layoutSystemAt = this.GetLayoutSystemAt(new System.Drawing.Point(e.X, e.Y));
            if (layoutSystemAt == null)
            {
                if (this.x3df31cf55a47bc37 != null)
                    goto label_8;
                label_4:
                if (!this.x59f159fe47159543.Contains(e.X, e.Y))
                {
                    Cursor.Current = Cursors.Default;
                    return;
                }
                else if (!this.x61c108cc44ef385a)
                {
                    Cursor.Current = Cursors.HSplit;
                    return;
                }
                else
                {
                    Cursor.Current = Cursors.VSplit;
                    return;
                }
                label_8:
                this.x3df31cf55a47bc37.OnMouseLeave();
                this.x3df31cf55a47bc37 = (LayoutSystemBase)null;
                goto label_4;
            }
            else if (this.x3df31cf55a47bc37 == null)
                goto label_9;
            else
                goto label_12;
            label_16:
            if (this.x754f1c6f433be75d == null)
                return;
            else
                goto label_21;
            label_17:
            if (1 == 0)
                goto label_19;
            label_18:
            if (2 != 0)
                return;
            else
                goto label_16;
            label_19:
            if (0 != 0)
            {
                if (int.MinValue == 0)
                    goto label_12;
            }
            else
                goto label_16;
            label_21:
            this.x754f1c6f433be75d.OnMouseMove(new System.Drawing.Point(e.X, e.Y));
            goto label_18;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            this.x631afe05fcecf1f4.DrawDockContainerBackground(pevent.Graphics, this, this.DisplayRectangle);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (DockContainer.x1f080f764b4036b1)
                return;
            if (this.Manager != null)
                goto label_17;
            label_15:
            Control control;
            if (0 == 0)
            {
                control = (Control)null;
                goto label_18;
            }
            else
                goto label_19;
            label_17:
            control = this.Manager.DockSystemContainer;
            label_18:
            Control container = control;
            label_19:
            this.x631afe05fcecf1f4.StartRenderSession(HotkeyPrefix.None);
            this.LayoutSystem.x84b6f3c22477dacb(this.x631afe05fcecf1f4, e.Graphics, this.Font);
            if (2 == 0 || this.AllowResize)
                this.x631afe05fcecf1f4.DrawSplitter(container, (Control)this, e.Graphics, this.x59f159fe47159543, this.Dock == DockStyle.Top || this.Dock == DockStyle.Bottom ? Orientation.Horizontal : Orientation.Vertical);
            do
            {
                this.x631afe05fcecf1f4.FinishRenderSession();
//                if (this.x266365ea27fa7af8.Evaluation)
//                {
//                    if (1 == 0)
//                        goto label_14;
//                }
//                else
                    goto label_20;
            }
            while (4 == 0);
            using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(50, Color.White)))
            {
                using (Font font = new Font(this.Font.FontFamily.Name, 14f, FontStyle.Bold))
                {
                    e.Graphics.DrawString("evaluation", font, (Brush)solidBrush, (float)(this.x21ed2ecc088ef4e4.Left + 4), (float)(this.x21ed2ecc088ef4e4.Top - 4), StringFormat.GenericTypographic);
                    return;
                }
            }
            label_20:
            return;
            label_14:
            if (0 != 0)
                goto label_15;
        }

        internal void xa2414c47d888068e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            foreach (LayoutSystemBase layoutSystemBase in this.x83627743ea4ce5a2)
            {
                if (layoutSystemBase is ControlLayoutSystem && ((ControlLayoutSystem)layoutSystemBase).x61ce2417e4ef76f9())
                    break;
            }
        }

        internal void x19e788b09b195d4f(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    LayoutSystemBase layoutSystemBase = (LayoutSystemBase)enumerator.Current;
                    if (layoutSystemBase is ControlLayoutSystem)
                        ((ControlLayoutSystem)layoutSystemBase).x82dd941e2755ffd2();
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (8 == 0 || disposable != null)
                    disposable.Dispose();
            }
        }

        private void x1b91eb6f6bb77abc()
        {
            this.x754f1c6f433be75d.x868a32060451dd2e -= new EventHandler(this.x30c28c62b1a6040e);
            this.x754f1c6f433be75d.x67ecc0d0e7c9a202 -= new x09c1c18390e52ebf.ResizingManagerFinishedEventHandler(this.xa7afb2334769edc5);
            this.x754f1c6f433be75d = (x09c1c18390e52ebf)null;
        }

        private void x30c28c62b1a6040e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
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
        protected internal virtual void OnDockingStarted(EventArgs e)
        {
            if (this.DockingStarted != null)
            {
                this.DockingStarted((object)this, e);
                if (0 != 0)
                {
                    if (0 != 0)
                        return;
                }
                else
                    goto label_4;
            }
            else
                goto label_4;
            label_3:
            this.Manager.OnDockingStarted(e);
            return;
            label_4:
            if (this.Manager != null)
                goto label_3;
        }

        /// <summary>
        /// Raises the DockingFinished event.
        /// 
        /// </summary>
        /// <param name="e">The data for the event.</param>
        protected internal virtual void OnDockingFinished(EventArgs e)
        {
            if (this.DockingFinished != null)
                this.DockingFinished((object)this, e);
            if (this.Manager == null)
                return;
            this.Manager.OnDockingFinished(e);
        }

        private string xa3a7472ac4e61f76(System.Drawing.Point xb9c2cfae130d9256)
        {
            LayoutSystemBase layoutSystemAt = this.GetLayoutSystemAt(xb9c2cfae130d9256);
            if (layoutSystemAt is ControlLayoutSystem)
                return ((ControlLayoutSystem)layoutSystemAt).xe0e7b93bedab6c05(xb9c2cfae130d9256);
            else
                return "";
        }
    }
}
