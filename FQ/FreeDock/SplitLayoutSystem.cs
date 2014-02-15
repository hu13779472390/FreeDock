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
        private SplitLayoutSystem.LayoutSystemBaseCollection x820c504c9c557c92;
        private Orientation xe36f4efbf268b3f1;
        private ArrayList x366d4cf7098f9c63;
        private x8e80e1c8bce8caf7 x372569d2ea29984e;

        internal override bool x56005f23d6948487
        {
            get
            {
                foreach (LayoutSystemBase layoutSystemBase in (CollectionBase) this.LayoutSystems)
                {
                    if (layoutSystemBase.x56005f23d6948487)
                        return true;
                }
                return false;
            }
        }

        internal override DockControl[] x9476096be9672d38
        {
            get
            {
                ArrayList x8da10969b0e2a75e = new ArrayList();
                this.xd78391e378ab076b(this, x8da10969b0e2a75e);
                return (DockControl[])x8da10969b0e2a75e.ToArray(typeof(DockControl));
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
                return this.xe36f4efbf268b3f1;
            }
            set
            {
                this.xe36f4efbf268b3f1 = value;
                this.x3e0280cae730d1f2();
            }
        }

        internal override bool x74e31f9641656e0b
        {
            get
            {
                IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
                bool flag1;
                try
                {
                    while (enumerator.MoveNext())
                    {
                        LayoutSystemBase layoutSystemBase = (LayoutSystemBase)enumerator.Current;
                        if (3 != 0)
                        {
                            if (layoutSystemBase.x74e31f9641656e0b)
                                continue;
                        }
                        else
                        {
                            bool flag2;
                            if (false)
                                ;
                        }
                        flag1 = false;
                        return flag1;
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    do
                    {
                        if (disposable != null)
                        {
                            disposable.Dispose();
                            if (int.MaxValue != 0)
                                goto label_11;
                        }
                        if (true)
                            break;
                        label_11:
                        ;
                    }
                    while (int.MinValue == 0 || (int)byte.MaxValue == 0);
                }
                return true;
            }
        }

        internal override bool x2f61709eaa5ebf76
        {
            get
            {
                IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
                try
                {
                    LayoutSystemBase layoutSystemBase;
                    do
                    {
                        if (enumerator.MoveNext())
                            goto label_5;
                        else
                            goto label_4;
                        label_2:
                        continue;
                        label_4:
                        if (0 != 0)
                            goto label_2;
                        else
                            goto label_10;
                        label_5:
                        layoutSystemBase = (LayoutSystemBase)enumerator.Current;
                        bool flag;
                        if (true)
                            goto label_2;
                        else
                            break;
                    }
                    while (layoutSystemBase.x2f61709eaa5ebf76);
                    return false;
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                        disposable.Dispose();
                }
                label_10:
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
                return this.x820c504c9c557c92;
            }
        }

        internal event EventHandler x7e9646eed248ed11;

        /// <summary>
        /// Initializes a new instance of the SplitLayoutSystem class.
        /// 
        /// </summary>
        public SplitLayoutSystem()
        {
            this.x820c504c9c557c92 = new SplitLayoutSystem.LayoutSystemBaseCollection(this);
            this.x366d4cf7098f9c63 = new ArrayList();
        }

        /// <summary>
        /// Initializes a new instance of the ControlLayoutSystem class, with the specified initial dimensions.
        /// 
        /// </summary>
        /// <param name="desiredWidth">The desired width of this layout system, in pixels.</param><param name="desiredHeight">The desired height of this layout system, in pixels.</param>
        public SplitLayoutSystem(int desiredWidth, int desiredHeight)
      : this()
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
        public SplitLayoutSystem(int desiredWidth, int desiredHeight, Orientation splitMode, LayoutSystemBase[] layoutSystems)
      : this(desiredWidth, desiredHeight)
        {
            this.xe36f4efbf268b3f1 = splitMode;
            this.x820c504c9c557c92.AddRange(layoutSystems);
        }

        /// <summary>
        /// Initializes a new instance of the SplitLayoutSystem class, with the specified initial dimensions, the specified split orientation and the specified
        ///             child layout systems.
        /// 
        /// </summary>
        /// <param name="workingSize">The working size of the layout system.</param><param name="splitMode">The orientation of splitters within this layout system.</param><param name="layoutSystems">An array of layout systems to populate this layout system with.</param>
        public SplitLayoutSystem(SizeF workingSize, Orientation splitMode, LayoutSystemBase[] layoutSystems)
      : this()
        {
            this.WorkingSize = workingSize;
            this.xe36f4efbf268b3f1 = splitMode;
            this.x820c504c9c557c92.AddRange(layoutSystems);
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
                x410f3612b9a8f9de x410f3612b9a8f9de = (x410f3612b9a8f9de)this.DockContainer;
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
                    DockControl[] x9476096be9672d38 = this.x9476096be9672d38;
                    DockControl xbe0b15fe97a1ee89 = x410f3612b9a8f9de.xbe0b15fe97a1ee89;
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
        public void MoveToLayoutSystem(ControlLayoutSystem layoutSystem)
        {
            this.MoveToLayoutSystem(layoutSystem, 0);
        }

        /// <summary>
        /// Moves this layout system in to a control layout system, at the specified offset.
        /// 
        /// </summary>
        /// <param name="layoutSystem">The control layout system to move in to.</param><param name="index">The offset of the new tabs in the existing layout system.</param>
        public void MoveToLayoutSystem(ControlLayoutSystem layoutSystem, int index)
        {
            DockControl dockControl = (DockControl)null;
            int num;
            while (this.LayoutSystems.Count == 1)
            {
                if (this.LayoutSystems[0] is ControlLayoutSystem)
                    goto label_15;
                label_9:
                if (0 == 0)
                {
                    if (15 == 0 || (uint)index - (uint)index <= uint.MaxValue)
                    {
                        if (0 == 0)
                            goto label_5;
                    }
                    else if (false)
                        goto label_1;
                }
                else
                    goto label_13;
                label_12:
                if (false)
                    goto label_9;
                else
                    goto label_5;
                label_13:
                if (false)
                    continue;
                else
                    goto label_12;
                label_15:
                dockControl = ((ControlLayoutSystem)this.LayoutSystems[0]).SelectedControl;
                goto label_13;
            }
            goto label_17;
            label_1:
            int index1 = 0;
            DockControl[] x9476096be9672d38 = null;
            while (true)
            {
                DockControl control = null;
                if (index1 < 0)
                {
                    if ((uint)index - (uint)index1 >= 0U)
                        break;
                }
                else
                    control = x9476096be9672d38[index1];
                layoutSystem.Controls.Insert(index, control);
                --index1;
            }
            if (dockControl == null)
                return;
            label_4:
            layoutSystem.SelectedControl = dockControl;
            return;
            label_5:
            x9476096be9672d38 = this.x9476096be9672d38;
            index1 = x9476096be9672d38.Length - 1;
            goto label_1;
            label_17:
            if (false)
                goto label_4;
            else
                goto label_5;
        }

        private void xd78391e378ab076b(SplitLayoutSystem xb25822984a90695b, ArrayList x8da10969b0e2a75e)
        {
            IEnumerator enumerator1 = xb25822984a90695b.x820c504c9c557c92.GetEnumerator();
            try
            {
                label_2:
                LayoutSystemBase layoutSystemBase;
                while (true)
                {
                    if (!enumerator1.MoveNext())
                    {
                        if (0 == 0)
                            goto label_19;
                        else
                            goto label_6;
                    }
                    else
                        goto label_24;
                    label_4:
                    if (!(layoutSystemBase is ControlLayoutSystem))
                    {
                        if (0 != 0)
                            goto label_17;
                        else
                            continue;
                    }
                    else
                        break;
                    label_6:
                    if (3 == 0)
                        goto label_20;
                    else
                        goto label_4;
                    label_16:
                    if (8 != 0)
                    {
                        if (0 == 0)
                        {
                            if (3 == 0)
                                goto label_4;
                            else
                                goto label_4;
                        }
                    }
                    else
                        goto label_21;
                    label_17:
                    if (0 == 0)
                    {
                        if (0 == 0)
                            goto label_6;
                    }
                    else
                        goto label_16;
                    label_19:
                    if (0 == 0)
                        goto label_23;
                    else
                        goto label_21;
                    label_20:
                    this.xd78391e378ab076b((SplitLayoutSystem)layoutSystemBase, x8da10969b0e2a75e);
                    continue;
                    label_21:
                    if (!(layoutSystemBase is SplitLayoutSystem))
                    {
                        if (0 == 0)
                            goto label_17;
                        else
                            goto label_16;
                    }
                    else
                        goto label_20;
                    label_24:
                    layoutSystemBase = (LayoutSystemBase)enumerator1.Current;
                    if (int.MinValue != 0)
                        goto label_21;
                    else
                        goto label_25;
                }
                IEnumerator enumerator2 = ((ControlLayoutSystem)layoutSystemBase).Controls.GetEnumerator();
                try
                {
                    while (enumerator2.MoveNext())
                    {
                        DockControl dockControl = (DockControl)enumerator2.Current;
                        x8da10969b0e2a75e.Add((object)dockControl);
                    }
                    goto label_2;
                }
                finally
                {
                    IDisposable disposable = enumerator2 as IDisposable;
                    if (disposable != null)
                        disposable.Dispose();
                }
                label_23:
                return;
                label_25:
                ;
            }
            finally
            {
                IDisposable disposable = enumerator1 as IDisposable;
                if (int.MaxValue == 0 || disposable != null)
                    disposable.Dispose();
            }
        }

        internal void x5a3264f7eba0fe4f(System.Drawing.Point x13d4cb8d1bd20347, out LayoutSystemBase xc13a8191724b6d55, out LayoutSystemBase x5aa50bbadb0a1e6c)
        {
            int index1 = 0;
            IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
            int num;
            try
            {
                label_13:
                while (enumerator.MoveNext())
                {
                    LayoutSystemBase layoutSystem = (LayoutSystemBase)enumerator.Current;
                    if (!(layoutSystem is ControlLayoutSystem))
                        goto label_22;
                    else
                        goto label_27;
                    label_14:
                    if (x13d4cb8d1bd20347.X <= layoutSystem.Bounds.Right + 4)
                    {
                        if (0 != 0)
                            goto label_20;
                        else
                            goto label_19;
                    }
                    else
                        continue;
                    label_15:
                    do
                    {
                        if (x13d4cb8d1bd20347.X < layoutSystem.Bounds.Right)
                            goto label_13;
                    }
                    while (false);
                    goto label_14;
                    label_17:
                    if (this.SplitMode == Orientation.Vertical)
                    {
                        if (true)
                            goto label_15;
                    }
                    else
                        continue;
                    label_19:
                    index1 = this.LayoutSystems.IndexOf(layoutSystem);
                    break;
                    label_20:
                    if (x13d4cb8d1bd20347.Y > layoutSystem.Bounds.Bottom + 4)
                        goto label_17;
                    else
                        goto label_19;
                    label_22:
                    if (this.SplitMode != Orientation.Horizontal)
                        goto label_17;
                    label_23:
                    if (x13d4cb8d1bd20347.Y < layoutSystem.Bounds.Bottom)
                    {
                        if (0 == 0)
                            goto label_17;
                        else
                            goto label_15;
                    }
                    else
                        goto label_20;
                    label_27:
                    if (!((ControlLayoutSystem)layoutSystem).Collapsed)
                    {
                        if (true)
                        {
                            if (0 == 0)
                                goto label_22;
                            else
                                goto label_23;
                        }
                        else
                            goto label_14;
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                while (disposable != null)
                {
                    disposable.Dispose();
                    if (true)
                        break;
                }
            }
            xc13a8191724b6d55 = this.LayoutSystems[index1];
            x5aa50bbadb0a1e6c = xc13a8191724b6d55;
            int index2 = index1 + 1;
            label_3:
            while (index2 < this.x820c504c9c557c92.Count)
            {
                label_6:
                if (!(this.x820c504c9c557c92[index2] is ControlLayoutSystem))
                    goto label_11;
                else
                    goto label_7;
                label_4:
                if (2 == 0)
                {
                    if ((uint)index2 - (uint)index2 <= uint.MaxValue)
                        goto label_6;
                }
                else
                    goto label_10;
                label_7:
                while (((ControlLayoutSystem)this.x820c504c9c557c92[index2]).Collapsed)
                {
                    label_2:
                    do
                    {
                        ++index2;
                        if ((index1 | 4) == 0)
                        {
                            if ((uint)index1 > uint.MaxValue || 0 != 0)
                                goto label_7;
                        }
                        else
                            goto label_3;
                    }
                    while ((uint)index2 + (uint)index2 > uint.MaxValue);
                    goto label_2;
                }
                goto label_4;
                label_10:
                x5aa50bbadb0a1e6c = this.LayoutSystems[index2];
                break;
                label_11:
                if ((index2 | 4) != 0)
                    goto label_10;
                else
                    goto label_4;
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
                if (0 != 0)
                    goto label_10;
                label_2:
                if (!rectangle.Contains(e.X, e.Y))
                    continue;
                label_10:
                LayoutSystemBase xc13a8191724b6d55;
                LayoutSystemBase x5aa50bbadb0a1e6c;
                this.x5a3264f7eba0fe4f(new System.Drawing.Point(e.X, e.Y), out xc13a8191724b6d55, out x5aa50bbadb0a1e6c);
                if (2 == 0)
                    break;
                if (this.x372569d2ea29984e == null)
                    goto label_8;
                else
                    goto label_7;
                label_5:
                this.x372569d2ea29984e.x67ecc0d0e7c9a202 += new x8e80e1c8bce8caf7.SplittingManagerFinishedEventHandler(this.xc555e814c1720baf);
                break;
                label_7:
                this.x372569d2ea29984e.Dispose();
                if (0 != 0)
                    goto label_5;
                label_8:
                DockingHints dockingHints = this.DockContainer.Manager != null ? this.DockContainer.Manager.DockingHints : DockingHints.TranslucentFill;
                this.x372569d2ea29984e = new x8e80e1c8bce8caf7(this.DockContainer, this, xc13a8191724b6d55, x5aa50bbadb0a1e6c, new System.Drawing.Point(e.X, e.Y), dockingHints);
                if (0 == 0)
                {
                    this.x372569d2ea29984e.x868a32060451dd2e += new EventHandler(this.xfae511fd7c4fb447);
                    goto label_5;
                }
                else
                    goto label_2;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            while (this.x531514c39973cbc6 == null)
            {
                if (0 == 0 || 15 != 0)
                {
                    if (this.x372569d2ea29984e == null)
                        return;
                    this.x372569d2ea29984e.Commit();
                    return;
                }
            }
            this.x531514c39973cbc6.Commit();
        }

        internal bool x090b65ef9b096e0b(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
        {
            IEnumerator enumerator = this.x366d4cf7098f9c63.GetEnumerator();
            bool flag;
            try
            {
                label_3:
                if (enumerator.MoveNext())
                {
                    Rectangle rectangle = (Rectangle)enumerator.Current;
                    do
                    {
                        if (rectangle.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
                            flag = true;
                        else
                            goto label_3;
                    }
                    while (false);
                    if ((x1e218ceaee1bb583 | 4) != 0)
                        goto label_11;
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            return false;
            label_11:
            return flag;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void OnMouseMove(MouseEventArgs e)
        {
            bool flag = false;
            label_17:
            if (-2 != 0)
                goto label_15;
            label_2:
            base.OnMouseMove(e);
            if (((flag ? 1 : 0) | 3) != 0)
                return;
            if (-1 == 0)
            {
                if (true)
                    goto label_9;
            }
            else
                goto label_17;
            label_6:
            if (false)
                goto label_10;
            label_7:
            flag = this.x090b65ef9b096e0b(e.X, e.Y);
            if (!flag)
            {
                if (0 == 0)
                {
                    Cursor.Current = Cursors.Default;
                    goto label_2;
                }
                else
                    goto label_6;
            }
            else
            {
                Cursor.Current = this.xe36f4efbf268b3f1 != Orientation.Horizontal ? Cursors.VSplit : Cursors.HSplit;
                goto label_2;
            }
            label_9:
            this.x372569d2ea29984e.OnMouseMove(new System.Drawing.Point(e.X, e.Y));
            return;
            label_10:
            if (this.x372569d2ea29984e != null)
                goto label_9;
            else
                goto label_7;
            label_15:
            if (false)
                return;
            if (-2 != 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (this.x531514c39973cbc6 != null)
                        this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
                    else
                        goto label_10;
                }
                else
                    goto label_7;
            }
            else if (4 != 0)
                goto label_9;
            else
                goto label_2;
        }

        internal override bool xe302f2203dc14a18(ContainerDockLocation xb9c2cfae130d9256)
        {
            IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    if (!((LayoutSystemBase)enumerator.Current).xe302f2203dc14a18(xb9c2cfae130d9256))
                        return false;
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (3 == 0 || disposable != null)
                    disposable.Dispose();
            }
            return true;
        }

        internal void x8e9e04a70e31e166()
        {
            if (this.DockContainer != null)
                this.DockContainer.x7e9646eed248ed11();
            if (this.x7e9646eed248ed11 == null)
                return;
            this.x7e9646eed248ed11((object)this, EventArgs.Empty);
        }

        internal void x3e0280cae730d1f2()
        {
            if (this.DockContainer != null)
            {
                if (int.MinValue == 0)
                    ;
                this.DockContainer.xec9697acef66c1bc((LayoutSystemBase)this, this.Bounds);
            }
            if (this.DockContainer == null)
                return;
            this.DockContainer.Invalidate(this.Bounds);
        }

        internal override void x56e964269d48cfcc(DockContainer x0467b00af7810f0c)
        {
            base.x56e964269d48cfcc(x0467b00af7810f0c);
            foreach (LayoutSystemBase layoutSystemBase in (CollectionBase) this.LayoutSystems)
                layoutSystemBase.x56e964269d48cfcc(x0467b00af7810f0c);
        }

        private LayoutSystemBase[] x10878bfc002a3aaf(out int x10f4d88af727adbc)
        {
            x10f4d88af727adbc = 0;
            LayoutSystemBase[] layoutSystemBaseArray1 = new LayoutSystemBase[this.LayoutSystems.Count];
            IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
            try
            {
                label_2:
                while (enumerator.MoveNext())
                {
                    label_18:
                    LayoutSystemBase layoutSystemBase1 = (LayoutSystemBase)enumerator.Current;
                    if (layoutSystemBase1 is ControlLayoutSystem)
                        goto label_16;
                    else
                        goto label_13;
                    label_8:
                    int num1;
                    int num2;
                    while (!(layoutSystemBase1 is SplitLayoutSystem))
                    {
                        if (true)
                        {
                            if (false)
                            {
                                if ((uint)num2 - (uint)num1 < 0U && (num2 | -1) == 0)
                                    goto label_9;
                            }
                            else
                                goto label_2;
                        }
                        else
                            goto label_3;
                    }
                    goto label_11;
                    label_3:
                    SplitLayoutSystem splitLayoutSystem;
                    if (splitLayoutSystem.x7ca4fdcb31f9824a())
                    {
                        LayoutSystemBase[] layoutSystemBaseArray2 = layoutSystemBaseArray1;
                        num1 = x10f4d88af727adbc++;
                        int index = num1;
                        LayoutSystemBase layoutSystemBase2 = layoutSystemBase1;
                        layoutSystemBaseArray2[index] = layoutSystemBase2;
                        continue;
                    }
                    else
                        continue;
                    label_11:
                    splitLayoutSystem = (SplitLayoutSystem)layoutSystemBase1;
                    goto label_3;
                    label_9:
                    ControlLayoutSystem controlLayoutSystem;
                    if (!controlLayoutSystem.Collapsed)
                        goto label_14;
                    label_10:
                    if (!this.IsInContainer)
                    {
                        if (0 != 0)
                            goto label_8;
                        else
                            continue;
                    }
                    else if (this.DockContainer.x0c2484ccd29b8358)
                        continue;
                    label_14:
                    LayoutSystemBase[] layoutSystemBaseArray3 = layoutSystemBaseArray1;
                    num2 = x10f4d88af727adbc++;
                    int index1 = num2;
                    LayoutSystemBase layoutSystemBase3 = layoutSystemBase1;
                    layoutSystemBaseArray3[index1] = layoutSystemBase3;
                    if ((uint)num2 > uint.MaxValue)
                    {
                        if ((uint)num2 + (uint)num2 > uint.MaxValue)
                            goto label_10;
                        else
                            goto label_18;
                    }
                    else if (0 == 0)
                        continue;
                    else
                        goto label_8;
                    label_13:
                    if (false)
                        goto label_8;
                    else
                        goto label_8;
                    label_16:
                    controlLayoutSystem = (ControlLayoutSystem)layoutSystemBase1;
                    goto label_9;
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            return layoutSystemBaseArray1;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void Layout(RendererBase renderer, Graphics graphics, Rectangle bounds, bool floating)
        {

            base.Layout(renderer, graphics, bounds, floating);
            float num8 = 0;
            float num9 = 0;
            int index6 = 0;
            int index3 = 0;
            int num1;
            if (true)
                goto label_63;
            label_55:
            float num2 = 0.0f;
            int index1 = 0;
            float num3 = 0;
            if ((uint)num3 - (uint)(floating ? 1 : 0) >= 0U)
                goto label_54;
            label_49:
            int x10f4d88af727adbc = 0;
            LayoutSystemBase[] layoutSystemBaseArray;
            int index2 = 0;
            SizeF[] sizeFArray = { };
            for (; index2 < x10f4d88af727adbc; ++index2)
                sizeFArray[index2] = layoutSystemBaseArray[index2].WorkingSize;
            int num4;
            if ((double)num4 == (double)num2)
                goto label_21;
            else
                goto label_47;
            label_8:
            index3 = 0;
            int num5 = 0;
            int num6;
            layoutSystemBaseArray[index3].Layout(renderer, graphics, new Rectangle(num5, bounds.Y, num6, bounds.Height), floating);
            label_9:
            num5 += num6 + 4;
            ++index3;
            label_10:
            int index4 = 0;
            while (index3 < x10f4d88af727adbc)
            {
                num6 = Math.Max(this.xe36f4efbf268b3f1 != Orientation.Horizontal ? Convert.ToInt32(sizeFArray[index3].Width) : Convert.ToInt32(sizeFArray[index3].Height), 4);
                if (this.xe36f4efbf268b3f1 != Orientation.Horizontal)
                {
                    if (index3 == x10f4d88af727adbc - 1)
                    {
                        num6 = bounds.Right - num5;
                        goto label_8;
                    }
                    else
                        goto label_8;
                }
                else if (true)
                {
                    if (true)
                    {
                        if ((uint)index2 - (uint)index4 >= 0U)
                        {
                            if (index3 == x10f4d88af727adbc - 1)
                                goto label_19;
                            label_12:
                            layoutSystemBaseArray[index3].Layout(renderer, graphics, new Rectangle(bounds.X, num5, bounds.Width, num6), floating);
                            if ((uint)index2 + (uint)num6 < 0U)
                                goto label_44;
                            else
                                goto label_9;
                            label_19:
                            if ((uint)index4 <= uint.MaxValue)
                            {
                                num6 = bounds.Bottom - num5;
                                goto label_12;
                            }
                            else
                                break;
                        }
                    }
                    else
                        goto label_24;
                }
                else
                    goto label_1;
            }
            goto label_7;
            label_1:
            this.x366d4cf7098f9c63.Add((object)bounds);
            int index5;
            ++index5;
            label_2:
            if (index5 >= x10f4d88af727adbc - 1)
                return;
            bounds = layoutSystemBaseArray[index5].Bounds;
            if (this.xe36f4efbf268b3f1 != Orientation.Horizontal)
            {
                bounds.Offset(bounds.Width, 0);
                bounds.Width = 4;
                goto label_1;
            }
            else
            {
                bounds.Offset(0, bounds.Height);
                bounds.Height = 4;
                goto label_1;
            }
            label_7:
            index5 = 0;
            goto label_2;
            label_21:
            int num7;
            if (this.xe36f4efbf268b3f1 == Orientation.Horizontal)
                num7 = bounds.Y;
            else
                goto label_24;
            label_23:
            num5 = num7;
            index3 = 0;
            goto label_10;
            label_24:
            num7 = bounds.X;
            goto label_23;
            label_32:
            index6 = 0;
            num8 = 0;
            while (index6 < x10f4d88af727adbc)
            {
                num2 += this.xe36f4efbf268b3f1 == Orientation.Horizontal ? sizeFArray[index6].Height : sizeFArray[index6].Width;
                ++index6;
                if (true)
                {
                    if ((uint)index6 - (uint)index3 >= 0U)
                    {
                        if ((uint)num8 - (uint)index4 < 0U)
                            goto label_27;
                    }
                    else
                        goto label_56;
                }
                else
                    goto label_8;
            }
            goto label_31;
            label_27:
            sizeFArray[0].Width += num8;
            goto label_21;
            label_31:
            num8 = (float)num4 - num2;
            label_56:
            if ((uint)index4 + (uint)index2 <= uint.MaxValue)
            {
                if ((x10f4d88af727adbc & 0) == 0)
                {
                    if (0 != 0 || this.xe36f4efbf268b3f1 == Orientation.Horizontal)
                    {
                        sizeFArray[0].Height += num8;
                        goto label_21;
                    }
                    else
                        goto label_27;
                }
                else
                    goto label_31;
            }
            else
                goto label_21;
            label_35:
            num9 = 0;
            if (index4 >= x10f4d88af727adbc)
            {
                num2 = 0.0f;
                if (true)
                    goto label_32;
            }
            else
            {
                num9 = this.xe36f4efbf268b3f1 != Orientation.Horizontal ? sizeFArray[index4].Width : sizeFArray[index4].Height;
                goto label_44;
            }
            label_40:
            if (this.xe36f4efbf268b3f1 == Orientation.Horizontal)
                goto label_39;
            else
                goto label_41;
            label_38:
            ++index4;
            goto label_42;
            label_39:
            sizeFArray[index4].Height = num9;
            goto label_38;
            label_41:
            if ((uint)num4 >= 0U)
            {
                sizeFArray[index4].Width = num9;
                goto label_38;
            }
            label_42:
            if (true)
            {
                if ((uint)index3 - (uint)index6 < 0U)
                    return;
                else
                    goto label_35;
            }
            else
                goto label_32;
            label_44:
            num9 += num8 * (num9 / num2);
            goto label_40;
            label_47:
            num8 = (float)num4 - num2;
            index4 = 0;
            goto label_35;
            label_54:
            while (index1 < x10f4d88af727adbc)
            {
                num2 += this.xe36f4efbf268b3f1 == Orientation.Horizontal ? layoutSystemBaseArray[index1].WorkingSize.Height : layoutSystemBaseArray[index1].WorkingSize.Width;
                if (true)
                    ++index1;
            }
            this.x366d4cf7098f9c63.Clear();
            if ((uint)num2 <= uint.MaxValue && num4 <= 0)
            {
                if ((uint)num3 <= uint.MaxValue)
                    return;
                else
                    return;
            }
            else
            {
                sizeFArray = new SizeF[x10f4d88af727adbc];
                index2 = 0;
                goto label_49;
            }
            label_63:
            layoutSystemBaseArray = this.x10878bfc002a3aaf(out x10f4d88af727adbc);
            if (x10f4d88af727adbc == 0)
                return;
            int num10;
            do
            {
                if (x10f4d88af727adbc > 1)
                    goto label_61;
                label_58:
                num4 = this.xe36f4efbf268b3f1 == Orientation.Horizontal ? bounds.Height - (x10f4d88af727adbc - 1) * 4 : bounds.Width - (x10f4d88af727adbc - 1) * 4;
                continue;
                label_61:
                floating = false;
                goto label_58;
            }
            while (false);
            goto label_55;
        }

        internal override void x84b6f3c22477dacb(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Font x26094932cf7a9139)
        {
            if (this.DockContainer == null)
                return;
            Control control;
            if (this.DockContainer.Manager == null)
            {
                if (-1 == 0)
                    return;
                control = (Control)null;
            }
            else
                control = this.DockContainer.Manager.DockSystemContainer;
            Control container = control;
            IEnumerator enumerator1 = this.x366d4cf7098f9c63.GetEnumerator();
            try
            {
                while (enumerator1.MoveNext())
                {
                    Rectangle bounds = (Rectangle)enumerator1.Current;
                    x38870620fd380a6b.DrawSplitter(container, (Control)this.DockContainer, x41347a961b838962, bounds, this.xe36f4efbf268b3f1);
                }
            }
            finally
            {
                IDisposable disposable = enumerator1 as IDisposable;
                if (15 == 0 || disposable != null)
                    disposable.Dispose();
            }
            IEnumerator enumerator2 = this.LayoutSystems.GetEnumerator();
            try
            {
                label_19:
                if (enumerator2.MoveNext())
                    goto label_26;
                else
                    goto label_20;
                label_17:
                LayoutSystemBase layoutSystemBase;
                if (!((ControlLayoutSystem)layoutSystemBase).Collapsed)
                    goto label_24;
                label_18:
                if (!this.DockContainer.x0c2484ccd29b8358)
                    goto label_24;
                else
                    goto label_19;
                label_20:
                if (15 != 0)
                {
                    if (8 != 0 && 0 == 0)
                    {
                        if (0 != 0)
                            goto label_17;
                    }
                    else
                        goto label_18;
                }
                if (0 == 0)
                {
                    if (1 != 0)
                        return;
                    else
                        goto label_24;
                }
                label_23:
                x41347a961b838962.SetClip(layoutSystemBase.Bounds);
                layoutSystemBase.x84b6f3c22477dacb(x38870620fd380a6b, x41347a961b838962, x26094932cf7a9139);
                Region clip;
                x41347a961b838962.Clip = clip;
                if (4 == 0 || 0 != 0)
                {
                    if (4 != 0)
                        goto label_18;
                    else
                        goto label_17;
                }
                else
                    goto label_19;
                label_24:
                clip = x41347a961b838962.Clip;
                goto label_23;
                label_26:
                layoutSystemBase = (LayoutSystemBase)enumerator2.Current;
                if (-2 == 0 || layoutSystemBase is ControlLayoutSystem && (int)byte.MaxValue != 0)
                    goto label_17;
                else
                    goto label_24;
            }
            finally
            {
                IDisposable disposable = enumerator2 as IDisposable;
                if (0 != 0 || disposable != null)
                    disposable.Dispose();
            }
        }

        private void x367ada130c39f434()
        {
            this.x372569d2ea29984e.x868a32060451dd2e -= new EventHandler(this.xfae511fd7c4fb447);
            this.x372569d2ea29984e.x67ecc0d0e7c9a202 -= new x8e80e1c8bce8caf7.SplittingManagerFinishedEventHandler(this.xc555e814c1720baf);
            this.x372569d2ea29984e = (x8e80e1c8bce8caf7)null;
        }

        private void xfae511fd7c4fb447(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
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

        internal bool x7ca4fdcb31f9824a()
        {
            IEnumerator enumerator = this.x820c504c9c557c92.GetEnumerator();
            bool flag;
            try
            {
                label_4:
                do
                {
                    if (enumerator.MoveNext())
                    {
                        label_12:
                        LayoutSystemBase layoutSystemBase = (LayoutSystemBase)enumerator.Current;
                        if (layoutSystemBase is ControlLayoutSystem)
                            goto label_11;
                        else
                            goto label_6;
                        label_5:
                        if (true)
                        {
                            if (true)
                                continue;
                        }
                        else
                            goto label_12;
                        label_6:
                        if (((SplitLayoutSystem)layoutSystemBase).x7ca4fdcb31f9824a())
                        {
                            flag = true;
                            if (-1 != 0)
                                goto label_17;
                            else
                                goto label_5;
                        }
                        else
                            continue;
                        label_11:
                        ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)layoutSystemBase;
                        if (controlLayoutSystem.Collapsed)
                        {
                            if (this.IsInContainer)
                                goto label_10;
                            else
                                goto label_5;
                        }
                        else
                            goto label_9;
                    }
                    else
                        goto label_16;
                }
                while (false);
                goto label_4;
                label_9:
                flag = true;
                goto label_17;
                label_10:
                if (this.DockContainer.x0c2484ccd29b8358)
                    goto label_4;
                else
                    goto label_9;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            label_16:
            return false;
            label_17:
            return flag;
        }

        /// <summary>
        /// A collection of layout systems belonging to a split layout system.
        /// 
        /// </summary>
        public class LayoutSystemBaseCollection : CollectionBase
        {
            private SplitLayoutSystem xb6a159a84cb992d6;
            internal bool xd7a3953bce504b63;

            /// <summary>
            /// Returns the layout system at the specified index in the collection.
            /// 
            /// </summary>
            public LayoutSystemBase this [int index]
            {
                get
                {
                    return (LayoutSystemBase)this.List[index];
                }
            }

            internal LayoutSystemBaseCollection(SplitLayoutSystem parent)
            {
                this.xb6a159a84cb992d6 = parent;
            }

            private void x8e9e04a70e31e166()
            {
                this.xb6a159a84cb992d6.x8e9e04a70e31e166();
            }

            /// <summary>
            /// Overridden.
            /// 
            /// </summary>
            protected override void OnClear()
            {
                base.OnClear();
                IEnumerator enumerator = this.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        LayoutSystemBase layoutSystemBase = (LayoutSystemBase)enumerator.Current;
                        layoutSystemBase.xb6a159a84cb992d6 = (SplitLayoutSystem)null;
                        layoutSystemBase.x56e964269d48cfcc((DockContainer)null);
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (2 == 0 || disposable != null)
                        disposable.Dispose();
                }
            }

            /// <summary>
            /// Overridden.
            /// 
            /// </summary>
            protected override void OnClearComplete()
            {
                base.OnClearComplete();
                if (0 == 0 || -2 == 0)
                    goto label_4;
                label_1:
                if (int.MinValue != 0)
                    return;
                label_4:
                if (this.xd7a3953bce504b63)
                    return;
                this.x8e9e04a70e31e166();
                goto label_1;
            }

            /// <summary>
            /// Overridden.
            /// 
            /// </summary>
            protected override void OnInsertComplete(int index, object value)
            {
                base.OnInsertComplete(index, value);
                if ((int)byte.MaxValue == 0)
                    return;
                LayoutSystemBase layoutSystemBase = (LayoutSystemBase)value;
                layoutSystemBase.xb6a159a84cb992d6 = this.xb6a159a84cb992d6;
                layoutSystemBase.x56e964269d48cfcc(this.xb6a159a84cb992d6.DockContainer);
                if (this.xd7a3953bce504b63)
                    return;
                this.x8e9e04a70e31e166();
            }

            /// <summary>
            /// Overridden.
            /// 
            /// </summary>
            protected override void OnRemoveComplete(int index, object value)
            {
                base.OnRemoveComplete(index, value);
                ((LayoutSystemBase)value).xb6a159a84cb992d6 = (SplitLayoutSystem)null;
                ((LayoutSystemBase)value).x56e964269d48cfcc((DockContainer)null);
                int num = 0;
                if (this.xd7a3953bce504b63)
                    return;
                if (this.Count <= 1)
                {
                    while (this.xb6a159a84cb992d6.xb6a159a84cb992d6 != null)
                    {
                        SplitLayoutSystem splitLayoutSystem = this.xb6a159a84cb992d6.xb6a159a84cb992d6;
                        if (this.Count != 1)
                        {
                            if ((uint)num - (uint)index >= 0U)
                            {
                                if ((index & 0) == 0)
                                {
                                    if (this.Count != 0)
                                        return;
                                }
                                else
                                    goto label_9;
                                label_4:
                                splitLayoutSystem.LayoutSystems.Remove((LayoutSystemBase)this.xb6a159a84cb992d6);
                                return;
                                label_9:
                                if ((uint)index + (uint)num < 0U)
                                {
                                    if (15 != 0)
                                        continue;
                                }
                                else
                                    goto label_4;
                            }
                            else
                                continue;
                        }
                        else
                            goto label_13;
                        label_11:
                        LayoutSystemBase layoutSystem;
                        this.Remove(layoutSystem);
                        this.xd7a3953bce504b63 = false;
                        splitLayoutSystem.LayoutSystems.xd7a3953bce504b63 = true;
                        int index1 = splitLayoutSystem.LayoutSystems.IndexOf((LayoutSystemBase)this.xb6a159a84cb992d6);
                        splitLayoutSystem.LayoutSystems.Remove((LayoutSystemBase)this.xb6a159a84cb992d6);
                        splitLayoutSystem.LayoutSystems.Insert(index1, layoutSystem);
                        splitLayoutSystem.LayoutSystems.xd7a3953bce504b63 = false;
                        splitLayoutSystem.x8e9e04a70e31e166();
                        return;
                        label_13:
                        layoutSystem = this[0];
                        this.xd7a3953bce504b63 = true;
                        goto label_11;
                    }
                }
                else
                    goto label_6;
                label_3:
                this.x8e9e04a70e31e166();
                return;
                label_6:
                if (0 == 0)
                    goto label_3;
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
                foreach (LayoutSystemBase layoutSystem in layoutSystems)
                    this.Add(layoutSystem);
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
            public int Add(LayoutSystemBase layoutSystem)
            {
                int count = this.Count;
                this.Insert(count, layoutSystem);
                return count;
            }

            /// <summary>
            /// Inserts a layout system in to the collection at a given offset.
            /// 
            /// </summary>
            /// <param name="index">The position to insert the layout system at.</param><param name="layoutSystem">The layout system to insert.</param>
            public void Insert(int index, LayoutSystemBase layoutSystem)
            {
                if (layoutSystem.xb6a159a84cb992d6 != null)
                    throw new ArgumentException("Layout system already has a parent. You must first remove it from its parent.");
                this.List.Insert(index, (object)layoutSystem);
            }

            /// <summary>
            /// Removes the specified layout system from the collection.
            /// 
            /// </summary>
            /// <param name="layoutSystem">The layout system to remove.</param>
            public void Remove(LayoutSystemBase layoutSystem)
            {
                this.List.Remove((object)layoutSystem);
            }

            /// <summary>
            /// Examines the collection to see if it contains the specified layout system.
            /// 
            /// </summary>
            /// <param name="layoutSystem">The layout system to look for.</param>
            /// <returns>
            /// A value indicating whether the layout system was found.
            /// </returns>
            public bool Contains(LayoutSystemBase layoutSystem)
            {
                return this.List.Contains((object)layoutSystem);
            }

            /// <summary>
            /// Returns the index of a layout system in the collection.
            /// 
            /// </summary>
            /// <param name="layoutSystem">The layout system to look for.</param>
            /// <returns>
            /// The index of the layout system if found; otherwise -1.
            /// </returns>
            public int IndexOf(LayoutSystemBase layoutSystem)
            {
                return this.List.IndexOf((object)layoutSystem);
            }

            /// <summary>
            /// Copies the contents of the collection in to the given array, starting at the specified offset.
            /// 
            /// </summary>
            /// <param name="array">The array to be copied in to.</param><param name="index">The index to start at.</param>
            public void CopyTo(LayoutSystemBase[] array, int index)
            {
                this.List.CopyTo((Array)array, index);
            }
        }
    }
}
