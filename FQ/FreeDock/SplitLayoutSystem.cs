using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FQ.FreeDock.Rendering;

namespace FQ.FreeDock
{
    /// <summary>
    /// A layout system for grouping other layout systems together.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// A SandDock hierarchy consists of many dock controls grouped in to many control layout systems. These layout systems are then organised
    ///             by SplitLayoutSystems, with splitters in between for resizing them.
    /// </para>
    /// 
    /// </remarks>
    [TypeConverter(typeof(x807757bdf074f1b8))]
    public class SplitLayoutSystem : LayoutSystemBase
    {
        internal const int x51b0f429bd564626 = 4;
        private SplitLayoutSystem.LayoutSystemBaseCollection layoutSystems;
        private Orientation splitMode;
        private ArrayList x366d4cf7098f9c63;
        private x8e80e1c8bce8caf7 x372569d2ea29984e;

        internal override bool ContainsPersistableDockControls
        {
            get
            {
                foreach (LayoutSystemBase layout in this.LayoutSystems)
                {
                    if (layout.ContainsPersistableDockControls)
                        return true;
                }
                return false;
            }
        }

        internal override DockControl[] AllControls
        {
            get
            {
                ArrayList list = new ArrayList();
                this.xd78391e378ab076b(this, list);
                return (DockControl[])list.ToArray(typeof(DockControl));
            }
        }

        /// <summary>
        /// The orientation of the splitters within this layout system.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// Splitters can be horizontal (default) or vertical. With horizontal splitters, child layout systems are laid out vertically one by one down the
        ///             parent layout system. With vertical splitters they are laid out horizontally.
        /// </para>
        /// 
        /// </remarks>
        [Category("Layout")]
        [Description("Indicates whether this layout is split horizontally or vertically.")]
        [DefaultValue(typeof(Orientation), "Horizontal")]
        public Orientation SplitMode
        {
            get
            {
                return this.splitMode;
            }
            set
            {
                this.splitMode = value;
                this.x3e0280cae730d1f2();
            }
        }

        internal override bool AllowFloat
        {
            get
            {
                foreach (LayoutSystemBase layout in this.LayoutSystems)
                {
                    if (!layout.AllowFloat)
                        return false;
                }
                return true;
            }
        }

        internal override bool AllowTab
        {
            get
            {
                foreach (LayoutSystemBase layout in (CollectionBase) this.LayoutSystems)
                {
                    if (!layout.AllowFloat)
                        return false;
                }
                return true;
            }
        }

        /// <summary>
        /// The child layout systems belonging to this layout system.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// Child layout systems are laid out according to the SplitMode property, with splitters between them.
        /// </para>
        /// 
        /// </remarks>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SplitLayoutSystem.LayoutSystemBaseCollection LayoutSystems
        {
            get
            {
                return this.layoutSystems;
            }
        }

        internal event EventHandler LayoutSystemsChanged;

        /// <summary>
        /// Initializes a new instance of the SplitLayoutSystem class.
        /// 
        /// </summary>
        public SplitLayoutSystem()
        {
            this.layoutSystems = new SplitLayoutSystem.LayoutSystemBaseCollection(this);
            this.x366d4cf7098f9c63 = new ArrayList();
        }

        /// <summary>
        /// Initializes a new instance of the ControlLayoutSystem class, with the specified initial dimensions.
        /// 
        /// </summary>
        /// <param name="desiredWidth">The desired width of this layout system, in pixels.</param><param name="desiredHeight">The desired height of this layout system, in pixels.</param>
        public SplitLayoutSystem(int desiredWidth, int desiredHeight) : this()
        {
            this.WorkingSize = new SizeF((float)desiredWidth, (float)desiredHeight);
        }

        /// <summary>
        /// Initializes a new instance of the ControlLayoutSystem class, with the specified initial dimensions, the specified split orientation and the specified
        ///             child layout systems.
        /// 
        /// </summary>
        /// <param name="desiredWidth">The desired width of this layout system, in pixels.</param><param name="desiredHeight">The desired height of this layout system, in pixels.</param><param name="splitMode">The orientation of splitters within this layout system.</param><param name="layoutSystems">An array of layout systems to populate this layout system with.</param>
        [Obsolete("Use the constructor taking a SizeF instead.")]
        public SplitLayoutSystem(int desiredWidth, int desiredHeight, Orientation splitMode, LayoutSystemBase[] layoutSystems) : this(desiredWidth, desiredHeight)
        {
            this.splitMode = splitMode;
            this.layoutSystems.AddRange(layoutSystems);
        }

        /// <summary>
        /// Initializes a new instance of the SplitLayoutSystem class, with the specified initial dimensions, the specified split orientation and the specified
        ///             child layout systems.
        /// 
        /// </summary>
        /// <param name="workingSize">The working size of the layout system.</param><param name="splitMode">The orientation of splitters within this layout system.</param><param name="layoutSystems">An array of layout systems to populate this layout system with.</param>
        public SplitLayoutSystem(SizeF workingSize, Orientation splitMode, LayoutSystemBase[] layoutSystems) : this()
        {
            this.WorkingSize = workingSize;
            this.splitMode = splitMode;
            this.layoutSystems.AddRange(layoutSystems);
        }

        /// <summary>
        /// Optimizes the layout system and all its children by removing unneeded layout systems.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// A boolean value indicating whether any changes were made to the layout hierarchy.
        /// </returns>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// When repeatedly changing a complex layout hierarchy it is easy to eventually end up with layout systems that are not needed. An example of this
        ///             is a SplitLayoutSystem that contains other SplitLayoutSystems with the same split orientation. This method analyses the layout hierarchy and makes
        ///             changes to it to prune layout systems such as the above example.
        /// </para>
        /// 
        /// <para>
        /// This method is called internally from time to time to ensure that your layout system is as clean as possible.
        /// </para>
        /// 
        /// </remarks>
        public bool Optimize()
        {
            if (this.LayoutSystems.Count == 1)
            {
                bool flag1 = false;
                int num1;
                if (true)
                    goto label_9;
                else
                    goto label_33;
                label_2:
                bool flag2;
                if (false)
                    goto label_5;
                else
                    goto label_3;
                label_4:
                SplitLayoutSystem splitLayoutSystem1;
                if (!(splitLayoutSystem1.LayoutSystems[0] is SplitLayoutSystem))
                    goto label_2;
                else
                    goto label_6;
                label_5:
                if (0 != 0)
                    goto label_4;
                label_6:
                LayoutSystemBase[] layoutSystemBaseArray;
                if (((SplitLayoutSystem)splitLayoutSystem1.LayoutSystems[0]).SplitMode == this.SplitMode)
                {
                    SplitLayoutSystem splitLayoutSystem2 = (SplitLayoutSystem)splitLayoutSystem1.LayoutSystems[0];
                    layoutSystemBaseArray = new LayoutSystemBase[splitLayoutSystem2.LayoutSystems.Count];
                    splitLayoutSystem2.LayoutSystems.CopyTo(layoutSystemBaseArray, 0);
                    splitLayoutSystem2.LayoutSystems.xd7a3953bce504b63 = true;
                    splitLayoutSystem2.LayoutSystems.Clear();
                    this.LayoutSystems.xd7a3953bce504b63 = true;
                    goto label_31;
                }
                else
                    goto label_3;
                label_9:
                if (this.LayoutSystems[0] is SplitLayoutSystem)
                {
                    splitLayoutSystem1 = (SplitLayoutSystem)this.LayoutSystems[0];
                    if (splitLayoutSystem1.LayoutSystems.Count == 1)
                    {
                        if (true)
                        {
                            if (true)
                                goto label_4;
                            else
                                goto label_2;
                        }
                    }
                    else
                        goto label_3;
                }
                else
                    goto label_10;
                label_30:
                this.LayoutSystems.xd7a3953bce504b63 = false;
                return true;
                label_31:
                this.LayoutSystems.Clear();
                this.LayoutSystems.AddRange(layoutSystemBaseArray);
                if (false)
                    goto label_30;
                else
                    goto label_30;
                label_33:
                if (true)
                {
                    if (false)
                    {
                        int num2;
                        if ((num2 | 4) != 0)
                            goto label_6;
                        else
                            goto label_31;
                    }
                    else
                        goto label_4;
                }
                else
                    goto label_5;
            }
            else
                goto label_10;
            label_3:
            return false;
            label_10:
            IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
            int index1;
            bool flag3 = false;
            bool flag4;
            int index2 = 0;
            try
            {
                label_13:
                if (enumerator.MoveNext())
                    goto label_26;
                label_12:
                index2 = 0;
                if (false)
                    goto label_21;
                else
                    goto label_3;
                label_14:
                LayoutSystemBase layoutSystemBase;
                SplitLayoutSystem splitLayoutSystem;
                LayoutSystemBase[] array;
                if (layoutSystemBase is SplitLayoutSystem)
                {
                    splitLayoutSystem = (SplitLayoutSystem)layoutSystemBase;
                    if (splitLayoutSystem.SplitMode != this.SplitMode)
                    {
                        flag3 = splitLayoutSystem.Optimize();
                        if (flag3)
                        {
                            flag4 = true;
                            goto label_37;

                        }
                        else
                            goto label_13;
                    }
                    else
                    {
                        array = new LayoutSystemBase[splitLayoutSystem.LayoutSystems.Count];
                        splitLayoutSystem.LayoutSystems.CopyTo(array, 0);

                        splitLayoutSystem.LayoutSystems.xd7a3953bce504b63 = true;
                        if ((uint)index2 - (uint)(flag3 ? 1 : 0) >= 0U)
                            goto label_21;

                    }
                }
                else
                    goto label_13;
                label_17:
                flag4 = true;
                goto label_37;
                label_21:
                do
                {
                    splitLayoutSystem.LayoutSystems.Clear();
                    if (true)
                    {
                        index1 = this.LayoutSystems.IndexOf((LayoutSystemBase)splitLayoutSystem);
                        this.LayoutSystems.xd7a3953bce504b63 = true;
                        this.LayoutSystems.Remove((LayoutSystemBase)splitLayoutSystem);
                        index2 = array.Length - 1;
                        if (true)
                        {
                            for (; index2 >= 0; --index2)
                                this.LayoutSystems.Insert(index1, array[index2]);
                            this.LayoutSystems.xd7a3953bce504b63 = false;
                        }
                        else
                            goto label_14;
                    }
                    else
                        goto label_26;
                }
                while (false);
                goto label_17;
                label_26:
                layoutSystemBase = (LayoutSystemBase)enumerator.Current;
                goto label_14;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            label_37:
            return flag4;
        }

        internal override void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
        {
            base.x46ff430ed3944e0f(x11d58b056c032b03);
            while ((int)byte.MaxValue != 0)
            {
                if (0 == 0)
                    goto label_37;
                label_33:
                SandDockManager manager = this.DockContainer.Manager;
                if (0 != 0)
                {
                    if (0 == 0)
                        continue;
                }
                else
                    goto label_44;
                label_37:
                if (x11d58b056c032b03 == null)
                    goto label_35;
                label_31:
                if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.None || -1 == 0 || x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.AlreadyActioned)
                    break;
                FloatingDockContainer x410f3612b9a8f9de = (FloatingDockContainer)this.DockContainer;
                goto label_33;
                label_35:
                if (0 == 0 || 0 != 0)
                    break;
                if (int.MaxValue != 0)
                    goto label_31;
                label_44:
                if (int.MaxValue == 0)
                    break;
                if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.Float)
                {
                    DockControl[] x9476096be9672d38 = this.AllControls;
                    DockControl xbe0b15fe97a1ee89 = x410f3612b9a8f9de.SelectedControl;
                    x410f3612b9a8f9de.LayoutSystem = new SplitLayoutSystem();
                    x410f3612b9a8f9de.Dispose();
                    try
                    {
                        if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.CreateNewContainer)
                        {
                            if (0 == 0)
                                goto label_25;
                            label_13:
                            this.x810df8ef88cf4bf2(manager, x11d58b056c032b03.dockLocation, x11d58b056c032b03.middle ? ContainerDockEdge.Inside : ContainerDockEdge.Outside);
                            break;
                            label_25:
                            DockContainer dockContainer = manager.FindDockContainer(x11d58b056c032b03.dockLocation);
                            while (0 == 0)
                            {
                                if (x11d58b056c032b03.dockLocation == ContainerDockLocation.Center)
                                {
                                    if (1 == 0 || dockContainer == null)
                                    {
                                        if (3 != 0)
                                        {
                                            if (-2 == 0)
                                                return;
                                            else
                                                goto label_13;
                                        }
                                    }
                                    else
                                        break;
                                }
                                else
                                    goto label_13;
                            }
                            this.MoveToLayoutSystem(LayoutUtilities.FindControlLayoutSystem(dockContainer));
                            break;
                        }
                        else
                        {
                            if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.JoinExistingSystem)
                                goto label_12;
                            label_6:
                            while (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.SplitExistingSystem)
                            {
                                if (!(x11d58b056c032b03.dockContainer is DocumentContainer))
                                {
                                    if (this.LayoutSystems.Count != 1 || !(this.LayoutSystems[0] is ControlLayoutSystem))
                                    {
                                        x11d58b056c032b03.layoutSystem.SplitForLayoutSystem((LayoutSystemBase)this, x11d58b056c032b03.dockSide);
                                        if (2 != 0)
                                            break;
                                    }
                                    else
                                    {
                                        ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)this.LayoutSystems[0];
                                        this.LayoutSystems.Remove((LayoutSystemBase)controlLayoutSystem);
                                        x11d58b056c032b03.layoutSystem.SplitForLayoutSystem((LayoutSystemBase)controlLayoutSystem, x11d58b056c032b03.dockSide);
                                        break;
                                    }
                                }
                                else
                                {
                                    ControlLayoutSystem newLayoutSystem = x11d58b056c032b03.dockContainer.CreateNewLayoutSystem(this.WorkingSize);
                                    newLayoutSystem.Controls.AddRange(x9476096be9672d38);
                                    x11d58b056c032b03.layoutSystem.SplitForLayoutSystem((LayoutSystemBase)newLayoutSystem, x11d58b056c032b03.dockSide);
                                    if (15 == 0)
                                        break;
                                    else
                                        break;
                                }
                            }
                            break;
                            label_12:
                            this.MoveToLayoutSystem(x11d58b056c032b03.layoutSystem, x11d58b056c032b03.index);
                            if (0 != 0 || 0 != 0 || 0 == 0)
                                break;
                            else
                                goto label_6;
                        }
                    }
                    finally
                    {
                        xbe0b15fe97a1ee89.Activate();
                    }
                }
                else
                {
                    x410f3612b9a8f9de.x159713d3b60fae0c(x11d58b056c032b03.bounds, true, true);
                    if (-2 == 0)
                        break;
                    else
                        break;
                }
            }
        }

        /// <summary>
        /// Moves this layout system in to a control layout system.
        /// 
        /// </summary>
        /// <param name="layoutSystem">The control layout system to move in to.</param>
        /// <remarks>
        /// 
        /// <para>
        /// Any split layout systems below the heirarchy are removed and their control layout systems flattened prior to being added to the control
        ///             layout system.
        /// </para>
        /// 
        /// </remarks>
        public void MoveToLayoutSystem(ControlLayoutSystem controlLayout)
        {
            this.MoveToLayoutSystem(controlLayout, 0);
        }

        /// <summary>
        /// Moves this layout system in to a control layout system, at the specified offset.
        /// 
        /// </summary>
        /// <param name="layoutSystem">The control layout system to move in to.</param><param name="index">The offset of the new tabs in the existing layout system.</param>
        // reviewed with 2.4
        public void MoveToLayoutSystem(ControlLayoutSystem controlLayout, int index)
        {
            DockControl dockControl = null;
            if (this.LayoutSystems.Count == 1 && this.LayoutSystems[0] is ControlLayoutSystem)
                dockControl = ((ControlLayoutSystem)this.LayoutSystems[0]).SelectedControl;

            DockControl[] allControls = this.AllControls;
            for (int i = allControls.Length - 1; i >= 0; --i)
                controlLayout.Controls.Insert(i, allControls[i]);

            if (dockControl != null)
                controlLayout.SelectedControl = dockControl;
        }
        // reviewed with 2.4
        private void xd78391e378ab076b(SplitLayoutSystem splitLayout, ArrayList x8da10969b0e2a75e)
        {
            foreach (LayoutSystemBase layout in splitLayout.layoutSystems)
            {
                if (layout is SplitLayoutSystem)
                    this.xd78391e378ab076b((SplitLayoutSystem)layout, x8da10969b0e2a75e);
                else if (layout is ControlLayoutSystem)
                {
                    foreach (DockControl dockControl in ((ControlLayoutSystem)layout).Controls)
                        x8da10969b0e2a75e.Add(dockControl);
                }
            }
        }
        // stolen from 2.4
        internal void x5a3264f7eba0fe4f(Point point, out LayoutSystemBase layout1, out LayoutSystemBase layout2)
        {
            int index1 = 0;
            foreach (LayoutSystemBase layout in this.LayoutSystems)
            {
                if ((!(layout is ControlLayoutSystem) || !((ControlLayoutSystem)layout).Collapsed) && (this.SplitMode == Orientation.Horizontal && point.Y >= layout.Bounds.Bottom && point.Y <= layout.Bounds.Bottom + 4 || this.SplitMode == Orientation.Vertical && point.X >= layout.Bounds.Right && point.X <= layout.Bounds.Right + 4))
                {
                    index1 = this.LayoutSystems.IndexOf(layout);
                    break;
                }
            }
            layout1 = this.LayoutSystems[index1];
            layout2 = layout1;
            for (int index2 = index1 + 1; index2 < this.layoutSystems.Count; ++index2)
            {
                if (!(this.layoutSystems[index2] is ControlLayoutSystem) || !((ControlLayoutSystem)this.layoutSystems[index2]).Collapsed)
                {
                    layout2 = this.LayoutSystems[index2];
                    break;
                }
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            foreach (Rectangle rectangle in this.x366d4cf7098f9c63)
            {
                if (rectangle.Contains(e.X, e.Y))
                {
                    LayoutSystemBase aboveLayout;
                    LayoutSystemBase belowLayout;
                    this.x5a3264f7eba0fe4f(new Point(e.X, e.Y), out aboveLayout, out belowLayout);
                    if (this.x372569d2ea29984e != null)
                        this.x372569d2ea29984e.Dispose();
                    DockingHints dockingHints = this.DockContainer.Manager != null ? this.DockContainer.Manager.DockingHints : DockingHints.TranslucentFill;
                    this.x372569d2ea29984e = new x8e80e1c8bce8caf7(this.DockContainer, this, aboveLayout, belowLayout, new Point(e.X, e.Y), dockingHints);
                    this.x372569d2ea29984e.Cancelled += new EventHandler(this.xfae511fd7c4fb447);
                    this.x372569d2ea29984e.Committed += new x8e80e1c8bce8caf7.SplittingManagerFinishedEventHandler(this.xc555e814c1720baf);
                    break;
                }
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed with 2.4
        protected internal override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (this.x531514c39973cbc6 != null)
                this.x531514c39973cbc6.Commit();
            else
            {
                if (this.x372569d2ea29984e != null)
                    this.x372569d2ea29984e.Commit();
            }
        }
        // reviewed with 2.4
        internal bool x090b65ef9b096e0b(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
        {
            foreach (Rectangle rectangle in this.x366d4cf7098f9c63)
            {
                if (rectangle.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed with 2.4
        protected internal override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.x531514c39973cbc6 != null)
                {
                    this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
                    return;
                }

                if (this.x372569d2ea29984e != null)
                {
                    this.x372569d2ea29984e.OnMouseMove(new Point(e.X, e.Y));
                    return;
                }
            }

            Cursor.Current = !this.x090b65ef9b096e0b(e.X, e.Y) ? Cursors.Default : this.splitMode != Orientation.Horizontal ? Cursors.VSplit : Cursors.HSplit;
            base.OnMouseMove(e);
        }

        internal override bool xe302f2203dc14a18(ContainerDockLocation location)
        {
            foreach (LayoutSystemBase layout in this.LayoutSystems)
            {
                if (!layout.xe302f2203dc14a18(location))
                    return false;
            }
            return true;
        }

        internal void x8e9e04a70e31e166()
        {
            if (this.DockContainer != null)
                this.DockContainer.x7e9646eed248ed11();
            if (this.LayoutSystemsChanged != null)
                this.LayoutSystemsChanged(this, EventArgs.Empty);
        }

        internal void x3e0280cae730d1f2()
        {
            if (this.DockContainer != null)
                this.DockContainer.xec9697acef66c1bc(this, this.Bounds);
            if (this.DockContainer != null)
                this.DockContainer.Invalidate(this.Bounds);
        }

        internal override void x56e964269d48cfcc(DockContainer container)
        {
            base.x56e964269d48cfcc(container);
            foreach (LayoutSystemBase layout in this.LayoutSystems)
                layout.x56e964269d48cfcc(container);
        }
        // reviewed with 2.4
        private LayoutSystemBase[] x10878bfc002a3aaf(out int count)
        {
            count = 0;
            LayoutSystemBase[] layouts = new LayoutSystemBase[this.LayoutSystems.Count];
            foreach (LayoutSystemBase layout in this.LayoutSystems)
            {
                if (layout is ControlLayoutSystem)
                {
                    if (!((ControlLayoutSystem)layout).Collapsed || this.IsInContainer && !this.DockContainer.CanShowCollapsed)
                        layouts[count++] = layout;
                }
                else if (layout is SplitLayoutSystem && ((SplitLayoutSystem)layout).x7ca4fdcb31f9824a())
                {
                    layouts[count++] = layout;
                }
            }
            return layouts;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed with 2.4
        protected internal override void Layout(RendererBase renderer, Graphics graphics, Rectangle bounds, bool floating)
        {
            base.Layout(renderer, graphics, bounds, floating);
            int num1;
            LayoutSystemBase[] layoutSystemBaseArray = this.x10878bfc002a3aaf(out num1);
            SizeF[] sizeFArray = new SizeF[num1];
            for (int i = 0; i < num1; ++i)
                 sizeFArray[i] = layoutSystemBaseArray[i].WorkingSize;

            if (num1 == 0)
                return;
            if (num1 > 1)
                floating = false;
            for (int index = 0; index < num1; ++index)
            {
                if (this.SplitMode == Orientation.Horizontal)
                {
                    if ((double) sizeFArray[index].Height <= 0.0)
                        sizeFArray[index].Height = 400f;
                    sizeFArray[index].Width = (float) bounds.Width;
                }
                if (this.SplitMode == Orientation.Vertical)
                {
                    if ((double) sizeFArray[index].Width <= 0.0)
                        sizeFArray[index].Width = 250f;
                    sizeFArray[index].Height = (float) bounds.Height;
                }
            }
            int num2 = this.SplitMode == Orientation.Horizontal ? bounds.Height - (num1 - 1) * 4 : bounds.Width - (num1 - 1) * 4;
            float num3 = 0.0f;
            for (int index = 0; index < num1; ++index)
                num3 += this.SplitMode == Orientation.Horizontal ? layoutSystemBaseArray[index].WorkingSize.Height : layoutSystemBaseArray[index].WorkingSize.Width;
            this.x366d4cf7098f9c63.Clear();
            if (num2 <= 0)
                return;
            if ((double) num2 != (double) num3)
            {
                float num4 = (float) num2 - num3;
                for (int index = 0; index < num1; ++index)
                {
                    float num5 = this.SplitMode == Orientation.Horizontal ? layoutSystemBaseArray[index].WorkingSize.Height : layoutSystemBaseArray[index].WorkingSize.Width;
                    float num6 = num5 + num4 * (num5 / num3);
                    if (this.SplitMode == Orientation.Horizontal)
                        sizeFArray[index].Height = num6;
                    else
                        sizeFArray[index].Width = num6;
                }
                float num7 = 0.0f;
                for (int index = 0; index < num1; ++index)
                    num7 += this.SplitMode == Orientation.Horizontal ? layoutSystemBaseArray[index].WorkingSize.Height : layoutSystemBaseArray[index].WorkingSize.Width;
                float num8 = (float) num2 - num7;
                if (this.SplitMode == Orientation.Horizontal)
                    sizeFArray[0].Height += num8;
                else
                    sizeFArray[0].Width += num8;
            }
            int num9 = this.SplitMode == Orientation.Horizontal ? bounds.Y : bounds.X;
            for (int index = 0; index < num1; ++index)
            {
                int num4 = Math.Max(this.SplitMode == Orientation.Horizontal ? (int) Math.Round((double) layoutSystemBaseArray[index].WorkingSize.Height, 0) : (int) Math.Round((double) layoutSystemBaseArray[index].WorkingSize.Width, 0), 4);
                if (this.SplitMode == Orientation.Horizontal)
                {
                    if (index == num1 - 1)
                        num4 = bounds.Bottom - num9;
                    layoutSystemBaseArray[index].Layout(renderer, graphics, new Rectangle(bounds.X, num9, bounds.Width, num4), floating);
                }
                else
                {
                    if (index == num1 - 1)
                        num4 = bounds.Right - num9;
                    layoutSystemBaseArray[index].Layout(renderer, graphics, new Rectangle(num9, bounds.Y, num4, bounds.Height), floating);
                }
                num9 += num4 + 4;
            }
            for (int index = 0; index < num1 - 1; ++index)
            {
                bounds = layoutSystemBaseArray[index].Bounds;
                if (this.SplitMode == Orientation.Horizontal)
                {
                    bounds.Offset(0, bounds.Height);
                    bounds.Height = 4;
                }
                else
                {
                    bounds.Offset(bounds.Width, 0);
                    bounds.Width = 4;
                }
                this.x366d4cf7098f9c63.Add(bounds);
            }
        }

        internal override void x84b6f3c22477dacb(RendererBase render, Graphics graphics, Font font)
        {
            if (this.DockContainer == null)
                return;
            Control container = this.DockContainer.Manager != null ? this.DockContainer.Manager.DockSystemContainer : null;

            foreach (Rectangle bounds in this.x366d4cf7098f9c63)
                render.DrawSplitter(container, this.DockContainer, graphics, bounds, this.splitMode);

            foreach (LayoutSystemBase layout in this.LayoutSystems)
            {
                if (!(layout is ControlLayoutSystem) || !((ControlLayoutSystem)layout).Collapsed || !this.DockContainer.CanShowCollapsed)
                {
                    Region clip = graphics.Clip;
                    graphics.SetClip(layout.Bounds);
                    layout.x84b6f3c22477dacb(render, graphics, font);
                    graphics.Clip = clip;
                }
            }
        }

        private void x367ada130c39f434()
        {
            this.x372569d2ea29984e.Cancelled -= new EventHandler(this.xfae511fd7c4fb447);
            this.x372569d2ea29984e.Committed -= new x8e80e1c8bce8caf7.SplittingManagerFinishedEventHandler(this.xc555e814c1720baf);
            this.x372569d2ea29984e = null;
        }

        private void xfae511fd7c4fb447(object sender, EventArgs e)
        {
            this.x367ada130c39f434();
        }

        private void xc555e814c1720baf(LayoutSystemBase xc13a8191724b6d55, LayoutSystemBase x5aa50bbadb0a1e6c, float x5c2440c931f8d932, float x4afa341b2323a009)
        {
            this.x367ada130c39f434();
            if (int.MaxValue != 0)
                goto label_14;
            else
                goto label_9;
            label_5:
            SizeF workingSize1;
            workingSize1.Width = x4afa341b2323a009;
            if ((uint)x4afa341b2323a009 - (uint)x5c2440c931f8d932 < 0U)
                goto label_9;
            label_6:
            SizeF workingSize2;
            xc13a8191724b6d55.WorkingSize = workingSize2;
            if ((uint)x4afa341b2323a009 + (uint)x5c2440c931f8d932 >= 0U)
            {
                if ((uint)x5c2440c931f8d932 >= 0U)
                {
                    x5aa50bbadb0a1e6c.WorkingSize = workingSize1;
                    this.x3e0280cae730d1f2();
                    return;
                }
                else
                    goto label_13;
            }
            label_9:
            if ((uint)x4afa341b2323a009 - (uint)x5c2440c931f8d932 > uint.MaxValue)
                goto label_5;
            label_10:
            workingSize2 = xc13a8191724b6d55.WorkingSize;
            workingSize1 = x5aa50bbadb0a1e6c.WorkingSize;
            if (((int)(uint)x4afa341b2323a009 | -2) == 0)
                return;
            if (this.SplitMode != Orientation.Horizontal)
            {
                workingSize2.Width = x5c2440c931f8d932;
                goto label_5;
            }
            else
            {
                workingSize2.Height = x5c2440c931f8d932;
                workingSize1.Height = x4afa341b2323a009;
                goto label_6;
            }
            label_13:
            if ((uint)x5c2440c931f8d932 + (uint)x5c2440c931f8d932 <= uint.MaxValue)
                return;
            label_14:
            if ((double)x5c2440c931f8d932 <= 0.0)
                return;
            if ((double)x4afa341b2323a009 > 0.0)
                goto label_10;
            else
                goto label_13;
        }
        // reviewed with 2.4
        internal bool x7ca4fdcb31f9824a()
        {
            foreach (LayoutSystemBase layout in this.layoutSystems)
            {
                if (layout is ControlLayoutSystem)
                {
                    if (!((ControlLayoutSystem)layout).Collapsed || this.IsInContainer && !this.DockContainer.CanShowCollapsed)
                        return true;
                }
                else if (((SplitLayoutSystem)layout).x7ca4fdcb31f9824a())
                    return true;
            }
            return false;
        }

        /// <summary>
        /// A collection of layout systems belonging to a split layout system.
        /// 
        /// </summary>
        public class LayoutSystemBaseCollection : CollectionBase
        {
            private SplitLayoutSystem parent;
            internal bool xd7a3953bce504b63;

            /// <summary>
            /// Returns the layout system at the specified index in the collection.
            /// 
            /// </summary>
            public LayoutSystemBase this[int index]
            {
                get
                {
                    return (LayoutSystemBase)this.List[index];
                }
            }

            internal LayoutSystemBaseCollection(SplitLayoutSystem parent)
            {
                this.parent = parent;
            }

            private void x8e9e04a70e31e166()
            {
                this.parent.x8e9e04a70e31e166();
            }

            /// <summary>
            /// Overridden.
            /// 
            /// </summary>
            protected override void OnClear()
            {
                base.OnClear();
                foreach (LayoutSystemBase layout in this)
                {
                    layout.parent = null;
                    layout.x56e964269d48cfcc(null);
                }
            }

            /// <summary>
            /// Overridden.
            /// 
            /// </summary>
            protected override void OnClearComplete()
            {
                base.OnClearComplete();
                if (!this.xd7a3953bce504b63)
                    this.x8e9e04a70e31e166();
            }

            /// <summary>
            /// Overridden.
            /// 
            /// </summary>
            protected override void OnInsertComplete(int index, object value)
            {
                base.OnInsertComplete(index, value);
                LayoutSystemBase layout = (LayoutSystemBase)value;
                layout.parent = this.parent;
                layout.x56e964269d48cfcc(this.parent.DockContainer);
                if (!this.xd7a3953bce504b63)
                    this.x8e9e04a70e31e166();
            }

            /// <summary>
            /// Overridden.
            /// 
            /// </summary>
            protected override void OnRemoveComplete(int index, object value)
            {
                base.OnRemoveComplete(index, value);
                ((LayoutSystemBase)value).parent = null;
                ((LayoutSystemBase)value).x56e964269d48cfcc(null);
                if (this.xd7a3953bce504b63)
                    return;

                if (this.Count <= 1 && this.parent.parent != null)
                {
                    SplitLayoutSystem splitLayout = this.parent.parent;
                    if (this.Count == 1)
                    {
                        LayoutSystemBase layout = this[0];
                        this.xd7a3953bce504b63 = true;
                        this.Remove(layout);
                        this.xd7a3953bce504b63 = false;
                        splitLayout.LayoutSystems.xd7a3953bce504b63 = true;
                        int index1 = splitLayout.LayoutSystems.IndexOf(this.parent);
                        splitLayout.LayoutSystems.Remove(this.parent);
                        splitLayout.LayoutSystems.Insert(index1, layout);
                        splitLayout.LayoutSystems.xd7a3953bce504b63 = false;
                        splitLayout.x8e9e04a70e31e166();
                        return;
                    }
                    else if (this.Count == 0)
                    {
                        splitLayout.LayoutSystems.Remove((LayoutSystemBase)this.parent);
                    }
                }
                else
                    this.x8e9e04a70e31e166();
            }

            /// <summary>
            /// Adds an array of layout systems in to the collection.
            /// 
            /// </summary>
            /// <param name="layoutSystems">The array of layout systems to add.</param>
            /// <remarks>
            /// 
            /// <para>
            /// When adding more than one layout system at a time to the collection you should use this method, as layout logic is postponed until
            ///             after the whole batch has been added.
            /// </para>
            /// 
            /// </remarks>
            public void AddRange(LayoutSystemBase[] layoutSystems)
            {
                this.xd7a3953bce504b63 = true;
                foreach (LayoutSystemBase layout in layoutSystems)
                    this.Add(layout);
                this.xd7a3953bce504b63 = false;
                this.x8e9e04a70e31e166();
            }

            /// <summary>
            /// Adds a layout system to the collection.
            /// 
            /// </summary>
            /// <param name="layoutSystem">The layout system to add.</param>
            /// <returns>
            /// The new index of the layout system in the collection.
            /// </returns>
            public int Add(LayoutSystemBase layout)
            {
                int count = this.Count;
                this.Insert(count, layout);
                return count;
            }

            /// <summary>
            /// Inserts a layout system in to the collection at a given offset.
            /// 
            /// </summary>
            /// <param name="index">The position to insert the layout system at.</param><param name="layoutSystem">The layout system to insert.</param>
            public void Insert(int index, LayoutSystemBase layout)
            {
                if (layout.parent != null)
                    throw new ArgumentException("Layout system already has a parent. You must first remove it from its parent.");
                this.List.Insert(index, layout);
            }

            /// <summary>
            /// Removes the specified layout system from the collection.
            /// 
            /// </summary>
            /// <param name="layoutSystem">The layout system to remove.</param>
            public void Remove(LayoutSystemBase layout)
            {
                this.List.Remove(layout);
            }

            /// <summary>
            /// Examines the collection to see if it contains the specified layout system.
            /// 
            /// </summary>
            /// <param name="layoutSystem">The layout system to look for.</param>
            /// <returns>
            /// A value indicating whether the layout system was found.
            /// </returns>
            public bool Contains(LayoutSystemBase layout)
            {
                return this.List.Contains(layout);
            }

            /// <summary>
            /// Returns the index of a layout system in the collection.
            /// 
            /// </summary>
            /// <param name="layoutSystem">The layout system to look for.</param>
            /// <returns>
            /// The index of the layout system if found; otherwise -1.
            /// </returns>
            public int IndexOf(LayoutSystemBase layout)
            {
                return this.List.IndexOf(layout);
            }

            /// <summary>
            /// Copies the contents of the collection in to the given array, starting at the specified offset.
            /// 
            /// </summary>
            /// <param name="array">The array to be copied in to.</param><param name="index">The index to start at.</param>
            public void CopyTo(LayoutSystemBase[] array, int index)
            {
                this.List.CopyTo(array, index);
            }
        }
    }
}
