using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    // f
    class xedb4922162c60d3d : x890231ddf317379e
    {
        private Size xca874006c41dfe29 = Size.Empty;
        private Point x2a2e0ce22e62c94e = Point.Empty;
        private const int x92d9c1851cace8e0 = 30;
        private SandDockManager manager;
        private DockContainer dockContainer;
        private LayoutSystemBase sourceLayoutSystem;
        private DockControl sourceControl;
        private int dockedSize;
        private DockTarget target;
        private Cursor splittingCursor;
        private Cursor nosplittingCursor;
        private ControlLayoutSystem[] controlLayoutSystems;

        protected ControlLayoutSystem[] CheckableControlLayoutSystems
        {
            get
            {
                return this.controlLayoutSystems;
            }
        }

        public SandDockManager Manager
        {
            get
            {
                return this.manager;
            }
        }

        public int DockedSize
        {
            get
            {
                return this.dockedSize;
            }
        }

        public DockContainer DockContainer
        {
            get
            {
                return this.dockContainer;
            }
        }

        public LayoutSystemBase SourceLayoutSystem
        {
            get
            {
                return this.sourceLayoutSystem;
            }
        }

        public DockControl SourceControl
        {
            get
            {
                return this.sourceControl;
            }
        }

        private Point DragPoint
        {
            get
            {
                return new Point(Cursor.Position.X - this.x2a2e0ce22e62c94e.X, Cursor.Position.Y - this.x2a2e0ce22e62c94e.Y);
            }
        }

        public bool DesignMode
        {
            get
            {
                return this.dockContainer.FriendDesignMode;
            }
        }

        public bool AllowFloat
        {
            get
            {
                if (this.DesignMode)
                    return false;
                if (this.SourceControl != null)
                    return this.SourceControl.DockingRules.AllowFloat;
                else
                    return this.SourceLayoutSystem.AllowFloat;
            }
        }

        public DockTarget Target
        {
            get
            {
                return this.target;
            }
        }

        public event DockingManagerFinishedEventHandler Committed;

        public xedb4922162c60d3d(SandDockManager manager, DockContainer container, LayoutSystemBase sourceControlSystem, DockControl sourceControl, int dockedSize, Point startPoint, DockingHints dockingHints) : base(container, dockingHints, true, container.WorkingRender.TabStripMetrics.Height)
        {
            this.manager = manager;
            this.dockContainer = container;
            this.sourceLayoutSystem = sourceControlSystem;
            this.sourceControl = sourceControl;
            this.dockedSize = dockedSize;
            if (container is DocumentContainer)
            {
                this.splittingCursor = new Cursor(this.GetType().Assembly.GetManifestResourceStream("FQ.FreeDock.Resources.splitting.cur"));
                this.nosplittingCursor = new Cursor(this.GetType().Assembly.GetManifestResourceStream("FQ.FreeDock.Resources.splittingno.cur"));
            }
            if (!(sourceControlSystem is SplitLayoutSystem))
            {
                if (sourceControl == null)
                {
                    if (sourceControlSystem is ControlLayoutSystem && ((ControlLayoutSystem)sourceControlSystem).SelectedControl != null)
                    {
                        this.xca874006c41dfe29 = ((ControlLayoutSystem)sourceControlSystem).SelectedControl.FloatingSize;
                    }
                    else
                    {
                        this.xca874006c41dfe29 = sourceControlSystem.Bounds.Size;
                    }
                }
                else
                {
                    this.xca874006c41dfe29 = sourceControl.FloatingSize;
                }
            }
            else
                this.xca874006c41dfe29 = ((FloatingDockContainer)container).FloatingSize;
  

            Rectangle bounds = sourceControlSystem.Bounds;
            if (bounds.Width > 0)
            {
                startPoint.X -= bounds.Left;
                startPoint.X = Convert.ToInt32((float)startPoint.X / (float)bounds.Width * (float)this.xca874006c41dfe29.Width);
            }
            else
            {
                startPoint.X = this.xca874006c41dfe29.Width / 2;
            }
       
            if (sourceControl != null)
                this.x2a2e0ce22e62c94e = new Point(startPoint.X, this.xca874006c41dfe29.Height - (bounds.Bottom - startPoint.Y));
            else
                this.x2a2e0ce22e62c94e = new Point(startPoint.X, startPoint.Y - bounds.Top);

            this.x2a2e0ce22e62c94e.Y = Math.Max(this.x2a2e0ce22e62c94e.Y, 0);
            this.x2a2e0ce22e62c94e.Y = Math.Min(this.x2a2e0ce22e62c94e.Y, this.xca874006c41dfe29.Height);
            this.controlLayoutSystems = this.x0ce9d68830aba643();
            this.dockContainer.OnDockingStarted(EventArgs.Empty);
        }
        // reviewed with 2.4
        public bool AllowDock(ContainerDockLocation dockLocation)
        {
            if (this.SourceControl != null)
                return this.SourceControl.AllowDock(dockLocation);
            else
                return this.SourceLayoutSystem.AllowDock(dockLocation);
        }

        // not found in 2.4
        public override void OnMouseMove(Point position)
        {
            DockTarget dockTarget = null;
            if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
                goto label_39;
            label_37:
            if (dockTarget != null)
                goto label_40;
            else
                goto label_36;
            label_34:
            if (dockTarget.type == DockTargetType.Undefined)
                dockTarget.type = DockTargetType.None;
            if (dockTarget.type != DockTargetType.Float)
                goto label_28;
            else
                goto label_32;
            label_3:
            if (this.dockContainer is DocumentContainer)
            {
                if (dockTarget.type != DockTargetType.AlreadyActioned)
                {
                    if (dockTarget.type != DockTargetType.None)
                        Cursor.Current = this.splittingCursor;
                    else
                        goto label_5;
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    goto label_20;
                }
            }
            label_4:
            this.target = dockTarget;
            return;
            label_5:
            Cursor.Current = this.nosplittingCursor;

            goto label_4;
            label_8:
            if (dockTarget.type != DockTargetType.None)
            {
                this.xe5e4149f382149cc(dockTarget.bounds, dockTarget.type == DockTargetType.JoinExistingSystem);
     
                goto label_3;

            }
            else
            {
                this.x11972e8742c570b8();
                goto label_3;
            }
            label_13:
            goto label_8;
            label_17:
            ControlLayoutSystem controlLayoutSystem;
            if (dockTarget.dockSide == DockSide.None)
            {
                this.x11972e8742c570b8();
                controlLayoutSystem = (ControlLayoutSystem)this.sourceLayoutSystem;
                if (dockTarget.index == controlLayoutSystem.Controls.IndexOf(this.sourceControl))
                    goto label_24;
                else
                    goto label_23;
            }
            label_18:

            goto label_8;
     
        
            label_20:
            goto label_4;
            label_22:
            dockTarget.type = DockTargetType.AlreadyActioned;
            goto label_3;
            label_23:
            if (dockTarget.index != controlLayoutSystem.Controls.IndexOf(this.sourceControl) + 1)
            {
                controlLayoutSystem.Controls.SetChildIndex(this.sourceControl, dockTarget.index);
                goto label_22;
            }
            else
                goto label_22;
            label_24:
 
            label_25:

  
            goto label_22;


            label_28:
            if (dockTarget.layoutSystem == this.sourceLayoutSystem)
            {

                if (this.sourceControl != null)
                    goto label_17;
                else
                    goto label_13;

   
            }
            else
                goto label_8;
            label_32:
            dockTarget.bounds = new Rectangle(this.DragPoint, this.xca874006c41dfe29);
            dockTarget.bounds = this.x90c590fcd758eaee(dockTarget.bounds);
   
            goto label_28;

            label_36:
            dockTarget = this.manager == null || !this.AllowFloat ? new DockTarget(xedb4922162c60d3d.DockTargetType.None) : new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.Float);
            goto label_34;
            label_40:
            if (dockTarget.type != DockTargetType.Undefined)
                goto label_34;
            label_41:
            if (this.manager == null || 2 != 0 && !this.AllowFloat)
                goto label_34;
            else
                goto label_36;
            label_39:
            dockTarget = this.FindDockTarget(position);
            goto label_37;
        }

        private Rectangle x90c590fcd758eaee(Rectangle bounds)
        {
            if (bounds.X >= Screen.PrimaryScreen.Bounds.X && bounds.Right <= Screen.PrimaryScreen.Bounds.Right && bounds.Y > Screen.PrimaryScreen.WorkingArea.Bottom)
                bounds.Y = Screen.PrimaryScreen.WorkingArea.Bottom - bounds.Height;
            Screen screen = Screen.FromRectangle(bounds);
            if (screen != null && bounds.Y < screen.WorkingArea.Y)
                bounds.Y = screen.WorkingArea.Y;
            return bounds;
        }
        // reviewed with 2.4
        protected Rectangle x8a1b221df357d098(ContainerDockLocation location, bool x24c3791e61dc49c9)
        {
            if (x24c3791e61dc49c9)
                return this.x257d5a0e25592705(location, 30, true);
            Control dockSystemContainer = this.Manager.DockSystemContainer;
            int x = 0;
            int width = dockSystemContainer.ClientRectangle.Width;
            int y = 0;
            int height = dockSystemContainer.ClientRectangle.Height;
            switch (location)
            {
                case ContainerDockLocation.Left:
                    return new Rectangle(x - 30, y, 30, height - y);
                case ContainerDockLocation.Right:
                    return new Rectangle(width, y, 30, height - y);
                case ContainerDockLocation.Top:
                    return new Rectangle(x, y - 30, width - x, 30);
                case ContainerDockLocation.Bottom:
                    return new Rectangle(x, height, width - x, 30);
                default:
                    return Rectangle.Empty;
            }
        }

        public static Rectangle x41c62f474d3fb367(Control xd3311d815ca25f02)
        {
            int x = 0;
            int num1 = xd3311d815ca25f02.ClientRectangle.Width;
            int y = 0;
            int num2 = xd3311d815ca25f02.ClientRectangle.Height;
            foreach (Control control in  xd3311d815ca25f02.Controls)
            {
                if (control.Visible)
                {
                    switch (control.Dock)
                    {
                        case DockStyle.Top:
                            if (control.Bounds.Bottom > y)
                                y = control.Bounds.Bottom;
                            continue;
                        case DockStyle.Bottom:
                            if (control.Bounds.Top < num2)
                                num2 = control.Bounds.Top;
                            continue;
                        case DockStyle.Left:
                            if (control.Bounds.Right > x)
                                x = control.Bounds.Right;
                            continue;
                        case DockStyle.Right:
                            if (control.Bounds.Left < num1)
                                num1 = control.Bounds.Left;
                            continue;
                        default:
                            continue;
                    }
                }
            }
            return new Rectangle(x, y, num1 - x, num2 - y);
        }

        protected Rectangle x257d5a0e25592705(ContainerDockLocation location, int x73f61fa085749e85, bool x24c3791e61dc49c9)
        {
            Rectangle rectangle = !x24c3791e61dc49c9 ? this.Manager.DockSystemContainer.ClientRectangle : x41c62f474d3fb367(this.Manager.DockSystemContainer);
            int num = x73f61fa085749e85 + 4;
            switch (location)
            {
                case ContainerDockLocation.Left:
                    return new Rectangle(rectangle.Left, rectangle.Top, num, rectangle.Height);
                case ContainerDockLocation.Right:
                    return new Rectangle(rectangle.Right - num, rectangle.Top, num, rectangle.Height);
                case ContainerDockLocation.Top:
                    return new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, num);
                case ContainerDockLocation.Bottom:
                    return new Rectangle(rectangle.Left, rectangle.Bottom - num, rectangle.Width, num);
                default:
                    return rectangle;
            }
        }

        protected bool xecd95d3d6bb4afc3()
        {
            return this.Manager.FindDockedContainer(DockStyle.Fill) is DocumentContainer;
        }
        // stolen from 2.4
        private ControlLayoutSystem[] x0ce9d68830aba643()
        {
            ArrayList array = new ArrayList();
            DockContainer[] containers = this.manager == null ? new DockContainer[] { this.DockContainer } : this.manager.GetDockContainers();
            foreach (DockContainer container in containers)
            {
                bool isFloating = container.IsFloating;
                bool flag1 = container.Dock == DockStyle.Fill && !container.IsFloating;
                bool flag2 = this.DockContainer.Dock == DockStyle.Fill && !this.DockContainer.IsFloating;
                if ((!isFloating || this.SourceLayoutSystem.DockContainer != container || !(this.SourceLayoutSystem is SplitLayoutSystem)) && ((isFloating || this.AllowDock(LayoutUtilities.Convert(container.Dock))) && (!flag1 || flag2)) && (!flag2 || this.DockContainer == container))
                    this.x53faf379dc10cd0f(container, array);
            }
            ControlLayoutSystem[] layouts = new ControlLayoutSystem[array.Count];
            array.CopyTo(layouts, 0);
            return layouts;
        }

        private void x53faf379dc10cd0f(DockContainer container, ArrayList array)
        {
            if (container.Width <= 0 && container.Height <= 0 || !container.Enabled || !container.Visible)
                return;
            this.xabdf625bc93be733(container, container.LayoutSystem, array);
        }

        private void xabdf625bc93be733(DockContainer container, SplitLayoutSystem splitLayout, ArrayList array)
        {
            foreach (LayoutSystemBase layout in splitLayout.LayoutSystems)
            {
                if (layout is SplitLayoutSystem)
                    this.xabdf625bc93be733(container, (SplitLayoutSystem)layout, array);
                else if (layout is ControlLayoutSystem && ((this.sourceControl == null || (layout != this.sourceLayoutSystem || this.sourceControl.LayoutSystem.Controls.Count != 1)) && !((ControlLayoutSystem)layout).Collapsed))
                    array.Add(layout);
            }
        }

        protected virtual DockTarget FindDockTarget(Point position)
        {
        
            if (this.manager != null && AllowFloat)
            {
                foreach (DockContainer dockContainer in this.manager.dockContainers)
                {
                    if (dockContainer.IsFloating && ((FloatingDockContainer)dockContainer).FloatingForm.Visible && (dockContainer.HasSingleControlLayoutSystem && dockContainer.LayoutSystem != this.sourceLayoutSystem))
                    {
                        Rectangle rectangle = ((FloatingDockContainer)dockContainer).FloatingBounds;
                        if (rectangle.Contains(position))
                        {
                            rectangle = new Rectangle(dockContainer.PointToScreen(dockContainer.LayoutSystem.LayoutSystems[0].Bounds.Location), dockContainer.LayoutSystem.LayoutSystems[0].Bounds.Size);
                            if (!rectangle.Contains(position))
                            {
                                return new DockTarget(DockTargetType.JoinExistingSystem)
                                {
                                    dockContainer = dockContainer,
                                    layoutSystem = (ControlLayoutSystem)dockContainer.LayoutSystem.LayoutSystems[0],
                                    bounds = ((FloatingDockContainer)dockContainer).FloatingBounds
                                };
                            }
                        }
                    }
                }
            }

            foreach (ControlLayoutSystem layout in  this.controlLayoutSystems)
            {
                Rectangle rectangle = new Rectangle(DockContainer.PointToScreen(layout.Bounds.Location), layout.Bounds.Size);
                if (rectangle.Contains(position))
                {
                    DockTarget target = this.xede53ab1a4b2e20b(layout.DockContainer, layout, position, true);
                    if (target != null)
                        return target;
                }
            }

            if (this.Manager != null)
            {
                for (int index = 1; index <= 4; ++index)
                {
                    ContainerDockLocation containerDockLocation = (ContainerDockLocation)index;
                    if (xc68a4bb946c59a9e(this.x8a1b221df357d098(containerDockLocation, true), this.Manager.DockSystemContainer).Contains(position))
                        return   new DockTarget(DockTargetType.CreateNewContainer)
                        {
                            dockLocation = containerDockLocation,
                            bounds = xc68a4bb946c59a9e(this.x257d5a0e25592705(containerDockLocation, this.dockedSize, true), this.Manager.DockSystemContainer),
                            middle = true
                        };
                    else if (xc68a4bb946c59a9e(this.x8a1b221df357d098(containerDockLocation, false), this.Manager.DockSystemContainer).Contains(position))
                        return   new DockTarget(DockTargetType.CreateNewContainer)
                        {
                            dockLocation = containerDockLocation,
                            bounds = xc68a4bb946c59a9e(this.x257d5a0e25592705(containerDockLocation, this.dockedSize, false), this.Manager.DockSystemContainer)
                        };
                }
            }
            return  null;
        }

        public static Rectangle xc68a4bb946c59a9e(Rectangle bounds, Control control)
        {
            return new Rectangle(control.PointToScreen(bounds.Location), bounds.Size);
        }

        protected DockTarget xede53ab1a4b2e20b(DockContainer container, ControlLayoutSystem layout, Point point, bool xcef4185c23f358e0)
        {
            DockTarget dockTarget = new DockTarget(DockTargetType.Undefined);
            Point pt = container.PointToClient(point);

            if (this.sourceControl == null && layout == this.sourceLayoutSystem)
            {
                if (layout.JoinCatchmentBounds.Contains(pt))
                    return new DockTarget(DockTargetType.None);
                else
                    return new DockTarget(DockTargetType.Undefined);
            }
            else
            {
                if (layout.JoinCatchmentBounds.Contains(pt) || layout.tabstripBounds.Contains(pt))
                {
                    dockTarget = new DockTarget(DockTargetType.JoinExistingSystem);
                    dockTarget.dockContainer = container;
                    dockTarget.layoutSystem = layout;
                    dockTarget.dockSide = DockSide.None;
                    dockTarget.bounds = new Rectangle(container.PointToScreen(layout.Bounds.Location), layout.Bounds.Size);
                    dockTarget.index = !layout.tabstripBounds.Contains(pt) ? layout.Controls.Count : layout.x17fd454c85fad336(pt);
                }
                if (dockTarget.type == DockTargetType.Undefined && xcef4185c23f358e0)
                    dockTarget = this.xc366f13a00f0a38d(container, layout, point);
                return dockTarget;
            }
        }

        private DockTarget xc366f13a00f0a38d(DockContainer container, ControlLayoutSystem layout, Point point)
        {
            DockTarget dockTarget = null;
            Point pt = container.PointToClient(point);
            Rectangle bounds = layout.clientBounds;
            //1
            if (new Rectangle(bounds.Left, bounds.Top, bounds.Width, 30).Contains(pt))
            {
                dockTarget = this.x7aa9d6b148df47c3(container, layout);
                if (pt.X < bounds.Left + 30)
                    this.x2a1e65376d30fca5(container, layout, dockTarget, bounds, pt);
                else if (pt.X > bounds.Right - 30)
                    this.x142a59be2748bb95(container, layout, dockTarget, bounds, pt);
                else
                    this.xa86a93682c30b8c6(container, layout, dockTarget, DockSide.Top);
            }
            //2
            else if (new Rectangle(bounds.Left, bounds.Top, 30, bounds.Height).Contains(pt))
            {
                dockTarget = this.x7aa9d6b148df47c3(container, layout);
                if (pt.Y < bounds.Top + 30)
                    this.x2a1e65376d30fca5(container, layout, dockTarget, bounds, pt);
                else if (pt.Y > bounds.Bottom - 30)
                    this.x6ff0606cba620904(container, layout, dockTarget, bounds, pt);
                else
                    this.xa86a93682c30b8c6(container, layout, dockTarget, DockSide.Left);
            }
            //3
            else if (new Rectangle(bounds.Right - 30, bounds.Top, 30, bounds.Height).Contains(pt))
            {
                dockTarget = this.x7aa9d6b148df47c3(container, layout);
                if (pt.Y < bounds.Top + 30)
                    this.x142a59be2748bb95(container, layout, dockTarget, bounds, pt);
                else if (pt.Y > bounds.Bottom - 30)
                    this.x4ea01976b3079611(container, layout, dockTarget, bounds, pt);
                else
                    this.xa86a93682c30b8c6(container, layout, dockTarget, DockSide.Left);
            }
            //4
            else if (new Rectangle(bounds.Left, bounds.Bottom - 30, bounds.Width, 30).Contains(pt))
            {
                dockTarget = this.x7aa9d6b148df47c3(container, layout);
                if (pt.Y < bounds.Left + 30)
                    this.x6ff0606cba620904(container, layout, dockTarget, bounds, pt);
                else if (pt.Y > bounds.Right - 30)
                    this.x4ea01976b3079611(container, layout, dockTarget, bounds, pt);
                else
                    this.xa86a93682c30b8c6(container, layout, dockTarget, DockSide.Left);
            }
            return dockTarget;
        }

        private void x4ea01976b3079611(DockContainer container, ControlLayoutSystem layout, DockTarget dockTarget, Rectangle bounds, Point point)
        {
            bounds.X = bounds.Right - 30;
            bounds.Y = bounds.Bottom - 30;
            point.X -= bounds.Left;
            point.Y -= bounds.Top;
            bounds = new Rectangle(0, 0, 30, 30);
            if (point.Y > bounds.Top + (int)((double)bounds.Height * ((double)point.X / (double)bounds.Width)))
                this.xa86a93682c30b8c6(container, layout, dockTarget, DockSide.Bottom);
            else
                this.xa86a93682c30b8c6(container, layout, dockTarget, DockSide.Right);
        }

        private void x6ff0606cba620904(DockContainer container, ControlLayoutSystem layout, DockTarget dockTarget, Rectangle bounds, Point point)
        {
            bounds.Y = bounds.Bottom - 30;
            point.X -= bounds.Left;
            point.Y -= bounds.Top;
            bounds = new Rectangle(0, 0, 30, 30);
            if (point.Y <= bounds.Bottom - (int)((double)bounds.Height * ((double)point.X / (double)bounds.Width)))
                this.xa86a93682c30b8c6(container, layout, dockTarget, DockSide.Left);
            else
                this.xa86a93682c30b8c6(container, layout, dockTarget, DockSide.Bottom);
        }

        private void x142a59be2748bb95(DockContainer container, ControlLayoutSystem layout, DockTarget dockTarget, Rectangle bounds, Point point)
        {
            bounds.X = bounds.Right - 30;
            point.X -= bounds.Left;
            point.Y -= bounds.Top;
            bounds = new Rectangle(0, 0, 30, 30);
            if (point.Y <= bounds.Top + (int)((double)bounds.Height * ((double)(bounds.Right - point.X) / (double)bounds.Width)))
                this.xa86a93682c30b8c6(container, layout, dockTarget, DockSide.Top);
            else
                this.xa86a93682c30b8c6(container, layout, dockTarget, DockSide.Right);
        }

        private void x2a1e65376d30fca5(DockContainer container, ControlLayoutSystem layout, DockTarget dockTarget, Rectangle bounds, Point point)
        {
            point.X -= bounds.Left;
            point.Y -= bounds.Top;
            bounds = new Rectangle(0, 0, 30, 30);
            if (point.Y <= bounds.Top + (int)((double)bounds.Height * ((double)point.X / (double)bounds.Width)))
                this.xa86a93682c30b8c6(container, layout, dockTarget, DockSide.Top);
            else
                this.xa86a93682c30b8c6(container, layout, dockTarget, DockSide.Left);
        }

        private void xa86a93682c30b8c6(DockContainer container, ControlLayoutSystem layout, DockTarget dockTarget, DockSide dockSide)
        {
            dockTarget.bounds = this.x3102817291e84207(container, layout, dockSide);
            dockTarget.dockSide = dockSide;
        }

        internal Rectangle x3102817291e84207(DockContainer container, ControlLayoutSystem layout, DockSide dockSide)
        {
            Rectangle rectangle = new Rectangle(container.PointToScreen(layout.Bounds.Location), layout.Bounds.Size);
            switch (dockSide)
            {
                case DockSide.Top:
                    rectangle.Height /= 2;
                    break;
                case DockSide.Bottom:
                    rectangle.Offset(0, rectangle.Height / 2);
                    rectangle.Height /= 2;
                    break;
                case DockSide.Left:
                    rectangle.Width /= 2;
                    break;
                case DockSide.Right:
                    rectangle.Offset(rectangle.Width / 2, 0);
                    rectangle.Width /= 2;
                    break;
                default:
                    break;
            }
            return rectangle;
        }

        private DockTarget x7aa9d6b148df47c3(DockContainer container, ControlLayoutSystem layout)
        {
            return new DockTarget(DockTargetType.SplitExistingSystem)
            {
                dockContainer = container,
                layoutSystem = layout
            };
        }

        public override void Commit()
        {
            base.Commit();
            LayoutUtilities.StartLayoutSession();
            try
            {
                if (this.Committed == null)
                    return;
                this.Committed(this.target);
            }
            finally
            {
                LayoutUtilities.FinishLayoutSession();
            }
        }

        public override void Dispose()
        {
            this.dockContainer.OnDockingFinished(EventArgs.Empty);
            if (this.splittingCursor != null)
                this.splittingCursor.Dispose();
            if (this.nosplittingCursor != null)
                this.nosplittingCursor.Dispose();
            base.Dispose();
        }

        public delegate void DockingManagerFinishedEventHandler(DockTarget target);

        public class DockTarget
        {
            public DockSide dockSide = DockSide.None;
            public Rectangle bounds = Rectangle.Empty;
            public ContainerDockLocation dockLocation = ContainerDockLocation.Center;
            public DockTargetType type;
            public DockContainer dockContainer;
            public ControlLayoutSystem layoutSystem;
            public int index;
            public bool middle;

            public DockTarget(DockTargetType type)
            {
                this.type = type;
            }
        }

        public enum DockTargetType
        {
            Undefined,
            None,
            Float,
            SplitExistingSystem,
            JoinExistingSystem,
            CreateNewContainer,
            AlreadyActioned,
        }
    }
}
