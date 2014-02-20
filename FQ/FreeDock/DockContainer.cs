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
        private SplitLayoutSystem x35c76d526f88c3c8;
        internal ArrayList x83627743ea4ce5a2;
        private RendererBase render;
        private Tooltips tooltips;
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
        // reviewed
        internal virtual RendererBase x631afe05fcecf1f4
        {
            get
            {
                if (this.sandDockManager != null && this.sandDockManager.Renderer != null)
                {
                    return this.sandDockManager.Renderer;
                }

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

                if (value != null)
                {
                    if (value.DockSystemContainer != null)
                    {
                        if (!this.IsFloating && this.Parent != null && this.Parent != value.DockSystemContainer)
                            throw new ArgumentException("This DockContainer cannot use the specified manager as the manager's DockSystemContainer differs from the DockContainer's Parent.");
                    }
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

        internal bool x61c108cc44ef385a
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
                return this.x35c76d526f88c3c8;
            }
            set
            {
                if (value == this.x35c76d526f88c3c8)
                    return;
                if (value == null)
                    throw new ArgumentNullException("value");

                DockContainer.x1f080f764b4036b1 = true;
                try
                {
                    if (this.x35c76d526f88c3c8 != null)
                    {
                        this.x35c76d526f88c3c8.x56e964269d48cfcc(null);
                    }

                    if (!this.x841598f8fd19209c)
                    {
                        if (this.x61c108cc44ef385a)
                        {
                            this.contentSize = Convert.ToInt32(value.WorkingSize.Width);
                        }
                        else
                        {
                            this.contentSize = Convert.ToInt32(value.WorkingSize.Height);
                        }
                        this.x841598f8fd19209c = true;

                    }
                    this.x35c76d526f88c3c8 = value;
                    this.x35c76d526f88c3c8.x56e964269d48cfcc(this);
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
        // FIXME: polish
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
//            this.x266365ea27fa7af8 = LicenseManager.Validate(typeof(DockContainer), (object)this) as xbd7c5470fc89975b;
            this.x35c76d526f88c3c8 = new SplitLayoutSystem();
            this.x35c76d526f88c3c8.x56e964269d48cfcc(this);
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.x83627743ea4ce5a2 = new ArrayList();
            this.tooltips = new Tooltips(this);
            this.tooltips.xa6e4f463e64a5987 = false;
            this.tooltips.x9b21ee8e7ceaada3 += new Tooltips.x58986a4a0b75e5b5(this.xa3a7472ac4e61f76);
            this.BackColor = SystemColors.Control;
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
            if (this.Manager == null)
                return;
            if (this.Parent == null || this.Parent is xd936980ea1aac341)
                return;
            this.Manager.DockSystemContainer = this.Parent;
        }

        internal void x8ba6fce4f4601549(ShowControlContextMenuEventArgs xfbf34718e704c6bc)
        {
            if (this.Manager != null)
                this.Manager.OnShowControlContextMenu(xfbf34718e704c6bc);
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
                this.tooltips.x9b21ee8e7ceaada3 -= new Tooltips.x58986a4a0b75e5b5(this.xa3a7472ac4e61f76);
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

            ControlLayoutSystem layout = this.xd6284ffe96aec512();
            layout.WorkingSize = size;
            if (controls.Length != 0)
                layout.Controls.AddRange(controls);

            return layout;
        }

        internal virtual ControlLayoutSystem xd6284ffe96aec512()
        {
            return new ControlLayoutSystem();
        }

        internal object x7159e85e85b84817(System.Type x96168bd31f23b747)
        {
            return this.GetService(x96168bd31f23b747);
        }
        // reviewed
        internal void x272ed7848e373c56()
        {
            ++this.xa03963cfd21be862;
            this.x35c76d526f88c3c8.x56e964269d48cfcc(null);
            IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    LayoutSystemBase layoutSystemBase = (LayoutSystemBase)enumerator.Current;
                    if (layoutSystemBase is ControlLayoutSystem)
                    {
                        ((ControlLayoutSystem)layoutSystemBase).Controls.Clear();
                    }
                }
                this.x35c76d526f88c3c8 = new SplitLayoutSystem();
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
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
        public DockControl GetWindowAt(Point position)
        {
            ControlLayoutSystem controlLayoutSystem = this.GetLayoutSystemAt(position) as ControlLayoutSystem;
            if (controlLayoutSystem != null)
                return controlLayoutSystem.GetControlAt(position);
            else
                return null;
        }

        /// <summary>
        /// Retrieves the layout system at the specified location.
        /// 
        /// </summary>
        /// <param name="position">The location, in client coordinates, to search.</param>
        /// <returns>
        /// The layout system found. If no layout system was found, a null reference is returned.
        /// </returns>
        // reviewed
        public LayoutSystemBase GetLayoutSystemAt(Point location)
        {
            foreach (LayoutSystemBase layout in this.x83627743ea4ce5a2)
            {
                if (layout.Bounds.Contains(location) && layout is ControlLayoutSystem && !((ControlLayoutSystem)layout).Collapsed)
                {
                    return layout;
                }
            }
            return null;

//            IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
//            try
//            {
//                while (enumerator.MoveNext())
//                {
//                    LayoutSystemBase layout = (LayoutSystemBase)enumerator.Current;
//                    Rectangle bounds = layout.Bounds;
//                    if (bounds.Contains(position))
//                    {
//                        if (layout is ControlLayoutSystem && !((ControlLayoutSystem)layout).Collapsed)
//                        {
//                            return layout;
//                        }
//                    }
//                }
//                return null;
//            }
//            finally
//            {
//                IDisposable disposable = enumerator as IDisposable;
//                if (disposable != null)
//                    disposable.Dispose();
//            }
        }
        //        public LayoutSystemBase GetLayoutSystemAt(System.Drawing.Point position)
        //        {
        //            LayoutSystemBase layoutSystemBase1 = (LayoutSystemBase)null;
        //            IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
        //            try
        //            {
        //                label_3:
        //                do
        //                {
        //                    do
        //                    {
        //                        LayoutSystemBase layoutSystemBase2;
        //                        Rectangle bounds;
        //                        if (!enumerator.MoveNext())
        //                        {
        //                            break;
        //                        }
        //                        else
        //                        {
        //                            layoutSystemBase2 = (LayoutSystemBase)enumerator.Current;
        //                            bounds = layoutSystemBase2.Bounds;
        //                            if (bounds.Contains(position))
        //                            {
        //                                if (layoutSystemBase2 is ControlLayoutSystem && ((ControlLayoutSystem)layoutSystemBase2).Collapsed)
        //                                {
        //                                    goto label_2;
        //                                }
        //                                layoutSystemBase1 = layoutSystemBase2;
        //                            }
        //                        }
        //                    }
        //                    while (!(layoutSystemBase1 is ControlLayoutSystem));
        //
        //                    goto label_26;
        //                    label_2:
        //                    ;
        //                }
        //                while (false);
        //                goto label_3;
        //            }
        //            finally
        //            {
        //                IDisposable disposable = enumerator as IDisposable;
        //                if (disposable != null)
        //                    disposable.Dispose();
        //            }
        //            label_26:
        //            return layoutSystemBase1;
        //        }
        internal virtual void x7e9646eed248ed11()
        {
            this.x7e9646eed248ed11(false);
        }

        private void x7e9646eed248ed11(bool xaa70223940104cbe)
        {
            this.x83627743ea4ce5a2.Clear();
            this.x3df31cf55a47bc37 = null;

            this.x5b6d1177ca7f3461(this.x35c76d526f88c3c8);
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
            this.x83627743ea4ce5a2.Add(x6e150040c8d97700);
            if (x6e150040c8d97700 is SplitLayoutSystem)
            {
                foreach (LayoutSystemBase layout in ((SplitLayoutSystem)x6e150040c8d97700).LayoutSystems)
                {
                    this.x5b6d1177ca7f3461(layout);
                }
            }
//            IEnumerator enumerator = ((SplitLayoutSystem)x6e150040c8d97700).LayoutSystems.GetEnumerator();
//            try
//            {
//                while (enumerator.MoveNext())
//                    this.x5b6d1177ca7f3461((LayoutSystemBase)enumerator.Current);
//            }
//            finally
//            {
//                IDisposable disposable = enumerator as IDisposable;
//                if (0 != 0 || disposable != null)
//                    disposable.Dispose();
//            }
        }

        internal bool x61d88745bde7a5ec()
        {
            foreach (LayoutSystemBase layout in this.x83627743ea4ce5a2)
            {
                if (layout is ControlLayoutSystem)
                    return false;
            }
            return true;
//            IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
//            bool flag;
//            try
//            {
//                do
//                {
//                    if (!enumerator.MoveNext())
//                        goto label_15;
//                }
//                while (!((LayoutSystemBase)enumerator.Current is ControlLayoutSystem));
//                flag = false;
//                if (int.MaxValue != 0)
//                    goto label_16;
//            }
//            finally
//            {
//                IDisposable disposable = enumerator as IDisposable;
//
//                goto label_10;
//                label_6:
//                if (true)
//                {
//                    goto label_14;
//                }
//                else
//                    goto label_13;
//                label_8:
//
//
//
//                goto label_14;
//
//
//                label_10:
//                if (3 != 0)
//                {
//
//                    goto label_13;
//                }
//                else
//                    goto label_6;
//                label_12:
//                disposable.Dispose();
//                goto label_6;
//                label_13:
//                if (disposable != null)
//                    goto label_12;
//                else
//                    goto label_8;
//                label_14:
//                ;
//            }
//            label_15:
//            return true;
//            label_16:
//            return flag;
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
                    LayoutSystemBase layoutSystemBase = (LayoutSystemBase) enumerator.Current;
                    do
                    {

                            if (!(layoutSystemBase is ControlLayoutSystem))
                                goto label_23;

                        label_24:
                        controlLayoutSystem = (ControlLayoutSystem) layoutSystemBase;
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
                    while (((flag2 ? 1 : 0) & 0) != 0);
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
                if ((num2 | (int) byte.MaxValue) == 0)
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
        // reviewed
        internal void xec9697acef66c1bc(LayoutSystemBase layoutSystem, Rectangle bounds)
        {
            if (!this.IsHandleCreated)
                return;
            using (Graphics g = this.CreateGraphics())
            {
                RendererBase render = this.x631afe05fcecf1f4;
                render.StartRenderSession(HotkeyPrefix.None);
                if (layoutSystem == this.x35c76d526f88c3c8)
                {
                    layoutSystem.Layout(render, g, bounds, this.IsFloating);
                }
                else
                {
                    layoutSystem.Layout(render, g, bounds, false);
                }
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
        // reviewed
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
            this.xec9697acef66c1bc((LayoutSystemBase)this.x35c76d526f88c3c8, this.x21ed2ecc088ef4e4);
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
            if (this.x3df31cf55a47bc37 == null)
                return;
            this.x3df31cf55a47bc37.OnMouseLeave();
            this.x3df31cf55a47bc37 = null;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (true)
            {
                if (this.x3df31cf55a47bc37 != null)
                {
                    this.x3df31cf55a47bc37.OnMouseDoubleClick();
                }
            }
            return;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // NOTE:LOCK!
//            if (false)
//                return;

            if (this.x3df31cf55a47bc37 != null)
            {
                this.x3df31cf55a47bc37.OnMouseDown(e);
            }

            if (this.Manager != null && this.x59f159fe47159543.Contains(e.X, e.Y) && e.Button == MouseButtons.Left)
            {
                if (this.x754f1c6f433be75d != null)
                    this.x754f1c6f433be75d.Dispose();

                this.x754f1c6f433be75d = new x09c1c18390e52ebf(this.Manager, this, new System.Drawing.Point(e.X, e.Y));
                this.x754f1c6f433be75d.x868a32060451dd2e += new EventHandler(this.x30c28c62b1a6040e);
                this.x754f1c6f433be75d.x67ecc0d0e7c9a202 += new x09c1c18390e52ebf.ResizingManagerFinishedEventHandler(this.xa7afb2334769edc5);
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            // NOTE:LOCK!
            if (true)
            {
                if (this.x3df31cf55a47bc37 != null)
                    this.x3df31cf55a47bc37.OnMouseUp(e);

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
            LayoutSystemBase layoutSystemAt = this.GetLayoutSystemAt(this.PointToClient(new System.Drawing.Point(drgevent.X, drgevent.Y)));
            if (layoutSystemAt != null)
                layoutSystemAt.OnDragOver(drgevent);
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
                this.x3df31cf55a47bc37 = (LayoutSystemBase) null;
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
        // reviewed
        protected override void OnPaint(PaintEventArgs e)
        {
            if (DockContainer.x1f080f764b4036b1)
                return;

            Control control = null;
            if (this.Manager != null)
            {
                control = this.Manager.DockSystemContainer;
            }

            Control container = control;
            this.x631afe05fcecf1f4.StartRenderSession(HotkeyPrefix.None);
            this.LayoutSystem.x84b6f3c22477dacb(this.x631afe05fcecf1f4, e.Graphics, this.Font);
            if (this.AllowResize)
            {
                this.x631afe05fcecf1f4.DrawSplitter(container, this, e.Graphics, this.x59f159fe47159543, this.Dock == DockStyle.Top || this.Dock == DockStyle.Bottom ? Orientation.Horizontal : Orientation.Vertical);
            }
            this.x631afe05fcecf1f4.FinishRenderSession();
            using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(50, Color.White)))
            {
                using (Font font = new Font(this.Font.FontFamily.Name, 14f, FontStyle.Bold))
                {
                    e.Graphics.DrawString("evaluation", font, (Brush)solidBrush, (float)(this.x21ed2ecc088ef4e4.Left + 4), (float)(this.x21ed2ecc088ef4e4.Top - 4), StringFormat.GenericTypographic);
                }
            }
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
                if (disposable != null)
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
        // reviewed
        protected internal virtual void OnDockingStarted(EventArgs e)
        {
            if (this.DockingStarted != null)
                this.DockingStarted((object)this, e);
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

        private string xa3a7472ac4e61f76(Point location)
        {
            LayoutSystemBase layoutSystemAt = this.GetLayoutSystemAt(location);
            if (layoutSystemAt is ControlLayoutSystem)
                return ((ControlLayoutSystem)layoutSystemAt).xe0e7b93bedab6c05(location);
            else
                return "";
        }
    }
}
