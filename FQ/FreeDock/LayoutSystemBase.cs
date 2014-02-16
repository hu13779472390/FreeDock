using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FQ.FreeDock.Rendering;

namespace FQ.FreeDock
{
    /// <summary>
    /// The base class for SandDock layout systems.
    /// 
    /// </summary>
    public abstract class LayoutSystemBase
    {
        private Rectangle bounds = Rectangle.Empty;
        private SizeF workingSize = new SizeF(250f, 400f);
        internal const int x35828a68467e5465 = 250;
        internal const int x87970cf44a2c6ba8 = 400;
        internal SplitLayoutSystem xb6a159a84cb992d6;
        private DockContainer dockContainer;
        internal xedb4922162c60d3d x531514c39973cbc6;

        internal abstract bool x56005f23d6948487 { get; }

        /// <summary>
        /// Gets or sets the working size of this layout system.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This is an advanced property for controlling the individual sizes of layout systems. Setting the property has no immediate effect - you should set the
        ///             sizes of all layout systems required (taking account of splitter space between them) then call the CalculateAllMetricsAndLayout method on your DockContainer.
        /// </para>
        /// 
        /// <para>
        /// When layout is calculated the working size is adjusted so that all layout systems are inflated or deflated to proportionally occupy all available
        ///             space in the DockContainer. Therefore you can safely pass zero for the dimension that will be ignored - for example the width in layout systems within a
        ///             horizontally-split layout system.
        /// </para>
        /// 
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public SizeF WorkingSize
        {
            get
            {
                return this.workingSize;
            }
            set
            {
                if (value.Width <= 0.0 || value.Height <= 0.0)
                    throw new ArgumentException("value");
                this.workingSize = value;
            }
        }

        /// <summary>
        /// The dock container at the top of the layout system hierarchy.
        /// 
        /// </summary>
        public DockContainer DockContainer
        {
            get
            {
                return this.dockContainer;
            }
        }

        /// <summary>
        /// Indicates whether the layout system is in a DockContainer.
        /// 
        /// </summary>
        public bool IsInContainer
        {
            get
            {
                return this.dockContainer != null;
            }
        }

        /// <summary>
        /// The layout system above this one in the heirarchy.
        /// 
        /// </summary>
        public SplitLayoutSystem Parent
        {
            get
            {
                return this.xb6a159a84cb992d6;
            }
        }

        private SandDockManager DockManager
        {
            get
            {
                return this.DockContainer != null ? this.DockContainer.Manager : null;
            }
        }

        /// <summary>
        /// Retrieves the boundaries of this layout system within the container.
        /// 
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return this.bounds;
            }
        }

        internal abstract DockControl[] x9476096be9672d38 { get; }

        internal abstract bool x74e31f9641656e0b { get; }

        internal abstract bool x2f61709eaa5ebf76 { get; }

        internal LayoutSystemBase()
        {
        }

        internal void xe9a159cd1e028df2(SandDockManager x91f347c6e97f1846, DockContainer xd3311d815ca25f02, LayoutSystemBase x6e150040c8d97700, DockControl x43bec302f92080b9, int x9562cf1322eeedf1, Point x6afebf16b45c02e0, DockingHints x48cee1d69929b4fe, DockingManager xab4835b6b3620991)
        {
            if (xab4835b6b3620991 == DockingManager.Whidbey)
                goto label_4;
            label_1:
            this.x531514c39973cbc6 = new xedb4922162c60d3d(x91f347c6e97f1846, this.DockContainer, this, x43bec302f92080b9, x9562cf1322eeedf1, x6afebf16b45c02e0, x48cee1d69929b4fe);
            label_2:
            this.x531514c39973cbc6.x67ecc0d0e7c9a202 += new xedb4922162c60d3d.DockingManagerFinishedEventHandler(this.x46ff430ed3944e0f);
            this.x531514c39973cbc6.x868a32060451dd2e += new EventHandler(this.x0ae87c4881d90427);
            label_3:
            this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
            return;

            label_4:
            if (x890231ddf317379e.xca8cda6e489f8dd8())
            {
                this.x531514c39973cbc6 = (xedb4922162c60d3d)new x31248f32f85df1dd(x91f347c6e97f1846, this.DockContainer, this, x43bec302f92080b9, x9562cf1322eeedf1, x6afebf16b45c02e0, x48cee1d69929b4fe);
                goto label_2;
            }
            else
                goto label_1;
        }

        private void xf6aefb7d0abb95ba()
        {
            this.x531514c39973cbc6.x67ecc0d0e7c9a202 -= new xedb4922162c60d3d.DockingManagerFinishedEventHandler(this.x46ff430ed3944e0f);
            this.x531514c39973cbc6.x868a32060451dd2e -= new EventHandler(this.x0ae87c4881d90427);
            this.x531514c39973cbc6 = null;
        }

        internal virtual void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
        {
            this.xf6aefb7d0abb95ba();
        }

        internal virtual void x0ae87c4881d90427(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            this.xf6aefb7d0abb95ba();
        }

        internal virtual void x56e964269d48cfcc(DockContainer x0467b00af7810f0c)
        {
            this.dockContainer = x0467b00af7810f0c;
        }

        /// <summary>
        /// Occurs when an object is dragged over the layout system's bounds.
        /// 
        /// </summary>
        /// <param name="drgevent">A DragEventArgs that contains the event data.</param>
        protected internal virtual void OnDragOver(DragEventArgs drgevent)
        {
        }

        /// <summary>
        /// Occurs when the mouse is moved within the bounds of this layout system.
        /// 
        /// </summary>
        /// <param name="e">A MouseEventArgs representing the current state of the mouse cursor.</param>
        protected internal virtual void OnMouseMove(MouseEventArgs e)
        {
        }

        /// <summary>
        /// Occurs when the mouse is moved out of the bounds of this layout system.
        /// 
        /// </summary>
        protected internal virtual void OnMouseLeave()
        {
        }

        /// <summary>
        /// Occurs when the primary mouse button is double clicked within the bounds of the layout system.
        /// 
        /// </summary>
        protected internal virtual void OnMouseDoubleClick()
        {
        }

        /// <summary>
        /// Occurs when a mouse button is pressed within the bounds of this layout system.
        /// 
        /// </summary>
        /// <param name="e">A MouseEventArgs representing the current state of the mouse cursor.</param>
        protected internal virtual void OnMouseDown(MouseEventArgs e)
        {
        }

        /// <summary>
        /// Occurs when a mouse button is released within the bounds of this layout system.
        /// 
        /// </summary>
        /// <param name="e">A MouseEventArgs representing the current state of the mouse cursor.</param>
        protected internal virtual void OnMouseUp(MouseEventArgs e)
        {
        }

        /// <summary>
        /// Instructs the layout system to lay out its children.
        /// 
        /// </summary>
        /// <param name="renderer">The renderer currently in use in the container.</param><param name="graphics">A Graphics object to perform measurement calculations with.</param><param name="bounds">The boundaries of this layout system within the container.</param><param name="floating">Indicates whether titlebars should be omitted. This is usually false.</param>
        protected internal virtual void Layout(RendererBase renderer, Graphics graphics, Rectangle bounds, bool floating)
        {
            this.bounds = bounds;
        }

        internal void x810df8ef88cf4bf2(SandDockManager x91f347c6e97f1846, ContainerDockLocation x9c911703d455884e, ContainerDockEdge x3e4dcab61996c9ea)
        {
            DockControl[] x9476096be9672d38 = this.x9476096be9672d38;
            label_21:
            int num = 0;
            label_19:
            if (x9476096be9672d38.Length > 0)
                goto label_18;
            else
                goto label_20;
            label_8:
            if (this is ControlLayoutSystem)
                goto label_11;
            else
                goto label_10;
            label_5:
            DockContainer newDockContainer;
            ControlLayoutSystem newLayoutSystem;
            do
            {
                newDockContainer = x91f347c6e97f1846.CreateNewDockContainer(x9c911703d455884e, x3e4dcab61996c9ea, num);
                if (0 != 0 || newDockContainer is DocumentContainer)
                {
                    newLayoutSystem = newDockContainer.CreateNewLayoutSystem(this.WorkingSize);
                    newDockContainer.LayoutSystem.LayoutSystems.Add((LayoutSystemBase)newLayoutSystem);
                    if (!(this is SplitLayoutSystem))
                    {
                        newLayoutSystem.Controls.AddRange(this.x9476096be9672d38);
                        if (0 == 0)
                        {
                            if ((uint)num + (uint)num > uint.MaxValue)
                                goto label_19;
                        }
                        else
                            goto label_21;
                    }
                    else
                        goto label_7;
                }
                else
                    goto label_3;
            }
            while ((uint)num < 0U);
            return;
            label_3:
            newDockContainer.LayoutSystem.LayoutSystems.Add(this);
            return;
            label_7:
            ((SplitLayoutSystem)this).MoveToLayoutSystem(newLayoutSystem);
            return;
            label_10:
            if (this.Parent != null)
            {
                this.Parent.LayoutSystems.Remove(this);
                goto label_5;
            }
            else
                goto label_5;
            label_11:
            LayoutUtilities.x4487f2f8917e3fd0((ControlLayoutSystem)this);
            goto label_5;
            label_12:
            Rectangle rectangle = Rectangle.Empty;
            num = Math.Min(num, Convert.ToInt32((double)rectangle.Height * 0.9));
            goto label_8;
            label_14:
            rectangle = xedb4922162c60d3d.x41c62f474d3fb367(x91f347c6e97f1846.DockSystemContainer);
            if (x9c911703d455884e != ContainerDockLocation.Left)
            {
                if (x9c911703d455884e != ContainerDockLocation.Right)
                {
                    if (x9c911703d455884e == ContainerDockLocation.Top || x9c911703d455884e == ContainerDockLocation.Bottom)
                        goto label_12;
                    else
                        goto label_8;
                }
                else if (3 == 0)
                    ;
            }
            num = Math.Min(num, Convert.ToInt32((double)rectangle.Width * 0.9));
            if ((int)byte.MaxValue != 0)
                goto label_8;
            else
                goto label_12;
            label_18:
            num = x9476096be9672d38[0].MetaData.DockedContentSize;
            goto label_14;
            label_20:
            if ((uint)num >= 0U)
                goto label_14;
            else
                goto label_12;
        }

        private void x298b2fdefeb76ab8()
        {
            if (this.DockManager == null)
                throw new InvalidOperationException("No SandDockManager is associated with this ControlLayoutSystem.");
        }

        internal abstract bool xe302f2203dc14a18(ContainerDockLocation xb9c2cfae130d9256);

        internal abstract void x84b6f3c22477dacb(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Font x26094932cf7a9139);
    }
}
