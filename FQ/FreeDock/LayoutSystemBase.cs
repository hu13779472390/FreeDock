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
        private SizeF workingSize = new SizeF(DEFAULT_WORKINGSIZE_WIDTH, DEFAULT_WORKINGSIZE_HEIGHT);
        internal const int DEFAULT_WORKINGSIZE_WIDTH = 250;
        internal const int DEFAULT_WORKINGSIZE_HEIGHT = 400;
        internal SplitLayoutSystem parent;
        private DockContainer dockContainer;
        internal xedb4922162c60d3d x531514c39973cbc6;

        internal abstract bool ContainsPersistableDockControls { get; }

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
                return this.parent;
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

        internal abstract DockControl[] AllControls { get; }

        internal abstract bool AllowFloat { get; }

        internal abstract bool AllowTab { get; }

        internal LayoutSystemBase()
        {
        }
        // reviewed
        internal void xe9a159cd1e028df2(SandDockManager sandDockManager, DockContainer dockContainer, LayoutSystemBase layout, DockControl dockControl, int x9562cf1322eeedf1, Point x6afebf16b45c02e0, DockingHints hints, DockingManager dockingManager)
        {

            if (dockingManager == DockingManager.Whidbey && x890231ddf317379e.IsNT5())
                this.x531514c39973cbc6 = new x31248f32f85df1dd(sandDockManager, this.DockContainer, this, dockControl, x9562cf1322eeedf1, x6afebf16b45c02e0, hints);
            else
                this.x531514c39973cbc6 = new xedb4922162c60d3d(sandDockManager, this.DockContainer, this, dockControl, x9562cf1322eeedf1, x6afebf16b45c02e0, hints);

            this.x531514c39973cbc6.Committed += new xedb4922162c60d3d.DockingManagerFinishedEventHandler(this.x46ff430ed3944e0f);
            this.x531514c39973cbc6.Cancelled += new EventHandler(this.x0ae87c4881d90427);
            this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
        }

        private void xf6aefb7d0abb95ba()
        {
            this.x531514c39973cbc6.Committed -= new xedb4922162c60d3d.DockingManagerFinishedEventHandler(this.x46ff430ed3944e0f);
            this.x531514c39973cbc6.Cancelled -= new EventHandler(this.x0ae87c4881d90427);
            this.x531514c39973cbc6 = null;
        }

        internal virtual void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget dockTarget)
        {
            this.xf6aefb7d0abb95ba();
        }

        internal virtual void x0ae87c4881d90427(object sender, EventArgs e)
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
        // reviewed
        internal void x810df8ef88cf4bf2(SandDockManager sandDockManager, ContainerDockLocation location, ContainerDockEdge edge)
        {
            DockControl[] dockControls = this.AllControls;
            int num = dockControls.Length > 0 ? dockControls[0].MetaData.DockedContentSize : 0;

            Rectangle rectangle = xedb4922162c60d3d.x41c62f474d3fb367(sandDockManager.DockSystemContainer);
            if (location != ContainerDockLocation.Left && location != ContainerDockLocation.Right)
            {
                num = Math.Min(num, Convert.ToInt32((double)rectangle.Height * 0.9));
            }
            else
            {
                num = Math.Min(num, Convert.ToInt32((double)rectangle.Width * 0.9));
            }

            if (this is ControlLayoutSystem)
            {
                LayoutUtilities.x4487f2f8917e3fd0((ControlLayoutSystem)this);
            }
            else
            {
                if (this.Parent != null)
                    this.Parent.LayoutSystems.Remove(this);
            }

            DockContainer newDockContainer = sandDockManager.CreateNewDockContainer(location, edge, num);
            if (newDockContainer is DocumentContainer)
            {
                ControlLayoutSystem newLayout = newDockContainer.CreateNewLayoutSystem(this.WorkingSize);
                newDockContainer.LayoutSystem.LayoutSystems.Add(newLayout);
                if (this is SplitLayoutSystem)
                {
                    ((SplitLayoutSystem)this).MoveToLayoutSystem(newLayout);
                }
                else
                {
                    newLayout.Controls.AddRange(this.AllControls);
                }
            }
            else
            {
                newDockContainer.LayoutSystem.LayoutSystems.Add(this);
            }
        }

        private void x298b2fdefeb76ab8()
        {
            if (this.DockManager == null)
                throw new InvalidOperationException("No SandDockManager is associated with this ControlLayoutSystem.");
        }

        internal abstract bool AllowDock(ContainerDockLocation location);

        internal abstract void x84b6f3c22477dacb(RendererBase render, Graphics graphics, Font font);
    }
}
