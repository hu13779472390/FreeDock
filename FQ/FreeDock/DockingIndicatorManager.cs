using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FQ.FreeDock.Rendering;
using System.Security;

namespace FQ.FreeDock
{
    // G
    class DockingIndicatorManager : xedb4922162c60d3d
    {
        private ControlLayoutSystem x5d62a4c2b1aa6ba9;
        private DockingIndicatorForm xa0a376f49c1ad375;
        private bool x347de2b6e474668a;
        private bool x66992a14bbd05efe;
        private Rectangle x6f306c95372dd403;
        private Rectangle x8caac3836061e4ad;
        private ArrayList ownedForms;

        public DockingIndicatorManager(SandDockManager manager, DockContainer container, LayoutSystemBase sourceControlSystem, DockControl sourceControl, int dockedSize, System.Drawing.Point startPoint, DockingHints dockingHints)
            : base(manager, container, sourceControlSystem, sourceControl, dockedSize, startPoint, dockingHints)
        {
            this.ownedForms = new ArrayList();
            if (this.Manager == null || this.Manager.DockSystemContainer == null)
                return;
            this.xcaa196e697d8d7c5();
        }

        private void xcaa196e697d8d7c5()
        {
            this.x6f306c95372dd403 = xedb4922162c60d3d.xc68a4bb946c59a9e(this.Manager.DockSystemContainer.ClientRectangle, this.Manager.DockSystemContainer);
            this.x8caac3836061e4ad = xedb4922162c60d3d.xc68a4bb946c59a9e(xedb4922162c60d3d.x41c62f474d3fb367(this.Manager.DockSystemContainer), this.Manager.DockSystemContainer);
            if (this.AllowDock(ContainerDockLocation.Top))
                this.ownedForms.Add(new DockingIndicatorForm(this, this.x6f306c95372dd403, DockStyle.Top));
            if (this.AllowDock(ContainerDockLocation.Left))
                this.ownedForms.Add(new DockingIndicatorForm(this, this.x6f306c95372dd403, DockStyle.Left));
            if (this.AllowDock(ContainerDockLocation.Bottom))
                this.ownedForms.Add(new DockingIndicatorForm(this, this.x6f306c95372dd403, DockStyle.Bottom));
            if (this.AllowDock(ContainerDockLocation.Right))
                this.ownedForms.Add(new DockingIndicatorForm(this, this.x6f306c95372dd403, DockStyle.Right));
            if ((this.DockContainer.Dock != DockStyle.Fill || this.DockContainer.IsFloating) && (this.AllowDock(ContainerDockLocation.Center) || (this.AllowDock(ContainerDockLocation.Left) || this.AllowDock(ContainerDockLocation.Right) || this.AllowDock(ContainerDockLocation.Top) || this.AllowDock(ContainerDockLocation.Bottom))))
                this.ownedForms.Add(new DockingIndicatorForm(this, this.x8caac3836061e4ad, DockStyle.Fill));

            if (this.Manager == null || this.Manager.OwnerForm == null)
                return;
            foreach (Form form in this.ownedForms)
                this.Manager.OwnerForm.AddOwnedForm(form);
        }

        // reviewed with 2.4
        protected override xedb4922162c60d3d.DockTarget FindDockTarget(Point position)
        {
            xedb4922162c60d3d.DockTarget dockTarget = null;
            bool flag1 = this.x6f306c95372dd403.Contains(position);
            bool flag2 = this.x8caac3836061e4ad.Contains(position);
            if (flag1 != this.x347de2b6e474668a || flag2 != this.x66992a14bbd05efe)
            {
                foreach (DockingIndicatorForm form in this.ownedForms)
                {
                    if (form.DockStyle == DockStyle.Fill && flag2 != this.x66992a14bbd05efe)
                    {
                        if (!flag2)
                            form.x5486e0b5e830d25c();
                        else
                            form.x35579b297303ed43();
                    }
                    else if (form.DockStyle != DockStyle.Fill && flag1 != this.x347de2b6e474668a)
                    {
                        if (flag1)
                            form.x35579b297303ed43();
                        else
                            form.x5486e0b5e830d25c();
                    }
                }
                this.x347de2b6e474668a = flag1;
                this.x66992a14bbd05efe = flag2;
            }
            ControlLayoutSystem controlLayoutSystem = this.x674f2f3b17dc4197(position, out dockTarget);
            if (controlLayoutSystem == this.SourceLayoutSystem && this.SourceControl == null)
                controlLayoutSystem = null;
            if (controlLayoutSystem != this.x5d62a4c2b1aa6ba9)
            {
                if (this.xa0a376f49c1ad375 != null)
                {
                    this.xa0a376f49c1ad375.x8ffe90e7fbccfccd();
                    this.xa0a376f49c1ad375 = null;
                }
                this.x5d62a4c2b1aa6ba9 = controlLayoutSystem;
                if (this.x5d62a4c2b1aa6ba9 != null)
                {
                    this.xa0a376f49c1ad375 = new DockingIndicatorForm(this, this.x5d62a4c2b1aa6ba9);
                    this.xa0a376f49c1ad375.x35579b297303ed43();
                }
            }
            if (dockTarget != null && dockTarget.type == xedb4922162c60d3d.DockTargetType.Undefined)
                dockTarget = null;
            if (this.xa0a376f49c1ad375 != null && this.xa0a376f49c1ad375.Bounds.Contains(position) && dockTarget != null)
                dockTarget = this.xa0a376f49c1ad375.x22749e65b5253094(position);
            foreach (DockingIndicatorForm form in this.ownedForms)
            {
                if (dockTarget == null && form.Bounds.Contains(position))
                    dockTarget = form.x22749e65b5253094(position);
            }
            return dockTarget;
        }

        private ControlLayoutSystem x674f2f3b17dc4197(Point point, out xedb4922162c60d3d.DockTarget dockTarget)
        {
            dockTarget = null;
            for (int index = 1; index >= 0; --index)
            {
                bool flag = Convert.ToBoolean(index);
                foreach (ControlLayoutSystem layout in this.CheckableControlLayoutSystems)
                {
                    if (layout.DockContainer.IsFloating == flag && new Rectangle(layout.DockContainer.PointToScreen(layout.Bounds.Location), layout.Bounds.Size).Contains(point))
                    {
                        dockTarget = this.xede53ab1a4b2e20b(layout.DockContainer, layout, point, false);
                        if (dockTarget.type == xedb4922162c60d3d.DockTargetType.Undefined)
                            return layout;
                        else
                            return null;
                    }
                }
            }
            return null;
        }

        public override void Dispose()
        {
            if (this.xa0a376f49c1ad375 != null)
            {
                this.xa0a376f49c1ad375.x8ffe90e7fbccfccd();
                this.xa0a376f49c1ad375 = null;
            }
            foreach (DockingIndicatorForm form in this.ownedForms)
                form.x8ffe90e7fbccfccd();
            this.ownedForms.Clear();
            base.Dispose();
        }

        private class DockingIndicatorForm : LayeredFormBase
        {
            private const int BITMAP_WIDTH = 88;
            private const int BITMAP_HEIGHT = 88;
            private const int x6b0037d5c155e862 = 200;
            private const int x77bf04ec211c4a37 = 16;
            private const int x339acab5bf3e83ae = 64;

            private Rectangle bounds = Rectangle.Empty;
            private DockSide dockSide = DockSide.None;
            private DockingIndicatorManager manager;
            private ControlLayoutSystem layoutSystem;
            private bool x3321191c6256921e;
            private Bitmap bitmap;
            private bool x3b280f462145bf12;
            private Timer timer;
            private int x1a5b1715d3a0d7a6;
            private bool ShouldDispose;
            private DockStyle dockStyle;

            public DockStyle DockStyle
            {
                get
                {
                    return this.dockStyle;
                }
            }

            private Rectangle MiddlePath
            {
                get
                {
                    return new Rectangle(28, 28, 32, 32);
                }
            }

            private Rectangle TopPath
            {
                get
                {
                    return new Rectangle(29, 0, 29, 28);
                }
            }

            private Rectangle RightPath
            {
                get
                {
                    return new Rectangle(60, 29, 28, 29);
                }
            }

            private Rectangle BottomPath
            {
                get
                {
                    return new Rectangle(29, 60, 29, 28);
                }
            }

            private Rectangle LeftPath
            {
                get
                {
                    return new Rectangle(0, 29, 28, 29);
                }
            }

            public new Rectangle Bounds
            {
                get
                {
                    return this.bounds;
                }
            }

            private DockingIndicatorForm()
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.ShowInTaskbar = false;
                this.StartPosition = FormStartPosition.Manual;
                this.timer = new Timer();
                this.timer.Interval = 50;
                this.timer.Tick += new EventHandler(this.OnTimer);
                this.bitmap = new Bitmap(88, 88, PixelFormat.Format32bppArgb);
            }

            public DockingIndicatorForm(DockingIndicatorManager manager, Rectangle fc, DockStyle dockStyle) : this()
            {
                this.manager = manager;
                this.dockStyle = dockStyle;
                switch (dockStyle)
                {
                    case DockStyle.Top:
                        this.bounds = new Rectangle(fc.X + fc.Width / 2 - 44, fc.Y + 15, 88, 88);
                        break;
                    case DockStyle.Bottom:
                        this.bounds = new Rectangle(fc.X + fc.Width / 2 - 44, fc.Bottom - 88 - 15, 88, 88);
                        break;
                    case DockStyle.Left:
                        this.bounds = new Rectangle(fc.X + 15, fc.Y + fc.Height / 2 - 44, 88, 88);
                        break;
                    case DockStyle.Right:
                        this.bounds = new Rectangle(fc.Right - 88 - 15, fc.Y + fc.Height / 2 - 44, 88, 88);
                        break;
                    case DockStyle.Fill:
                        this.bounds = new Rectangle(fc.X + fc.Width / 2 - 44, fc.Y + fc.Height / 2 - 44, 88, 88);
                        break;
                }
                this.DrawIndicator();
            }

            public DockingIndicatorForm(DockingIndicatorManager manager, ControlLayoutSystem layoutSystem) : this()
            {
                this.manager = manager;
                this.layoutSystem = layoutSystem;
                this.bounds = new Rectangle(layoutSystem.DockContainer.PointToScreen(layoutSystem.Bounds.Location), layoutSystem.Bounds.Size);
                this.bounds = new Rectangle(this.bounds.X + this.bounds.Width / 2 - 44, this.bounds.Y + this.bounds.Height / 2 - 44, 88, 88);
                this.DrawIndicator();
            }

            [DllImport("user32.dll")]
            private static extern bool SetWindowPos(HandleRef hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int flags);

            private const int SWP_DRAWFRAME = 0x0010;
            private const int SWP_SHOWWINDOW = 0x0040;

            // reviewed with 2.4
            private void DrawIndicator()
            {
                using (Graphics g = Graphics.FromImage(this.bitmap))
                {
                    RenderHelper.ClearBackground(g, Color.Transparent);
                    if (this.dockStyle == DockStyle.None || this.dockStyle == DockStyle.Fill)
                    {
                        using (Image image = Image.FromStream(typeof(DockingIndicatorForm).Assembly.GetManifestResourceStream("FQ.FreeDock.Resources.dockinghintcenter.png")))
                            g.DrawImageUnscaled(image, 0, 0);
                    }
                    else if (this.dockStyle == DockStyle.Top)
                    {
                        using (Image image = Image.FromStream(typeof(DockingIndicatorForm).Assembly.GetManifestResourceStream("FQ.FreeDock.Resources.dockinghinttop.png")))
                            g.DrawImageUnscaled(image, 29, 0);
                    }
                    else if (this.dockStyle == DockStyle.Bottom)
                    {
                        using (Image image = Image.FromStream(typeof(DockingIndicatorForm).Assembly.GetManifestResourceStream("FQ.FreeDock.Resources.dockinghintbottom.png")))
                            g.DrawImageUnscaled(image, 29, 57);
                    }
                    else if (this.dockStyle == DockStyle.Left)
                    {
                        using (Image image = Image.FromStream(typeof(DockingIndicatorForm).Assembly.GetManifestResourceStream("FQ.FreeDock.Resources.dockinghintleft.png")))
                            g.DrawImageUnscaled(image, 0, 29);
                    }
                    else if (this.dockStyle == DockStyle.Right)
                    {
                        using (Image image = Image.FromStream(typeof(DockingIndicatorForm).Assembly.GetManifestResourceStream("FQ.FreeDock.Resources.dockinghintright.png")))
                            g.DrawImageUnscaled(image, 57, 29);
                    }
                    Color highlight = SystemColors.Highlight;
                    Color transparent = Color.Transparent;
                    if (this.dockStyle == DockStyle.None || this.dockStyle == DockStyle.Fill || this.dockStyle == DockStyle.Top)
                        this.xd349d1e0601e763e(g, !this.x3321191c6256921e || this.dockSide != DockSide.Top ? transparent : highlight);
                    if (this.dockStyle == DockStyle.None || this.dockStyle == DockStyle.Fill || this.dockStyle == DockStyle.Right)
                        this.xa1ff3514b97ff955(g, !this.x3321191c6256921e || this.dockSide != DockSide.Right ? transparent : highlight);
                    if (this.dockStyle == DockStyle.None || this.dockStyle == DockStyle.Fill || this.dockStyle == DockStyle.Bottom)
                        this.x9ceea7a4567f6a5f(g, !this.x3321191c6256921e || this.dockSide != DockSide.Bottom ? transparent : highlight);
                    if (this.dockStyle == DockStyle.None || this.dockStyle == DockStyle.Fill || this.dockStyle == DockStyle.Left)
                        this.x46d7024135bf7082(g, !this.x3321191c6256921e || this.dockSide != DockSide.Left ? transparent : highlight);
                    if (this.dockStyle == DockStyle.None)
                        this.x6e8df868b7130012(g, !this.x3321191c6256921e || this.dockSide != DockSide.None ? transparent : highlight);
                }
                this.x0ecee64b07d2d5b1(this.bitmap, byte.MaxValue);
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    this.bitmap.Dispose();
                    this.timer.Tick -= new EventHandler(this.OnTimer);
                    this.timer.Dispose();
                }
                base.Dispose(disposing);
            }

            // reviewed with 2.4
            private xedb4922162c60d3d.DockTarget xd9d182c023a01aa8(Point point)
            {
                xedb4922162c60d3d.DockTarget dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.SplitExistingSystem);
                dockTarget.layoutSystem = this.layoutSystem;
                dockTarget.dockContainer = this.layoutSystem.DockContainer;
                if (this.x2e982e5b420711bf(this.TopPath, point))
                    dockTarget.dockSide = DockSide.Top;
                else if (this.x2e982e5b420711bf(this.RightPath, point))
                    dockTarget.dockSide = DockSide.Right;
                else if (this.x2e982e5b420711bf(this.BottomPath, point))
                    dockTarget.dockSide = DockSide.Bottom;
                else if (this.x2e982e5b420711bf(this.LeftPath, point))
                    dockTarget.dockSide = DockSide.Left;
                else if (this.x2e982e5b420711bf(this.MiddlePath, point))
                {
                    dockTarget.type = xedb4922162c60d3d.DockTargetType.JoinExistingSystem;
                    dockTarget.dockSide = DockSide.None;
                }
                else
                    dockTarget.type = xedb4922162c60d3d.DockTargetType.Undefined;
                dockTarget.bounds = this.manager.x3102817291e84207(this.layoutSystem.DockContainer, this.layoutSystem, dockTarget.dockSide);
                return dockTarget;
            }

            private xedb4922162c60d3d.DockTarget x54f27420b41557c2(Point point)
            {
                xedb4922162c60d3d.DockTarget dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.SplitExistingSystem);
                dockTarget.layoutSystem = this.layoutSystem;
                dockTarget.dockContainer = this.layoutSystem != null ? this.layoutSystem.DockContainer : (DockContainer)null;
                if (this.x2e982e5b420711bf(this.TopPath, point) && this.manager.AllowDock(ContainerDockLocation.Top) && (this.dockStyle == DockStyle.Top || this.dockStyle == DockStyle.Fill))
                {
                    dockTarget.dockLocation = ContainerDockLocation.Top;
                    dockTarget.dockSide = DockSide.Top;
                }
                else if (this.x2e982e5b420711bf(this.RightPath, point) && this.manager.AllowDock(ContainerDockLocation.Right) && (this.dockStyle == DockStyle.Right || this.dockStyle == DockStyle.Fill))
                {
                    dockTarget.dockLocation = ContainerDockLocation.Right;
                    dockTarget.dockSide = DockSide.Right;
               
                }
                else if (this.x2e982e5b420711bf(this.BottomPath, point) && this.manager.AllowDock(ContainerDockLocation.Bottom) && (this.dockStyle == DockStyle.Bottom || this.dockStyle == DockStyle.Fill))
                {
                    dockTarget.dockLocation = ContainerDockLocation.Bottom;
                    dockTarget.dockSide = DockSide.Bottom;
                 
                }
                else if (this.x2e982e5b420711bf(this.LeftPath, point) && this.manager.AllowDock(ContainerDockLocation.Left) && (this.dockStyle == DockStyle.Left || this.dockStyle == DockStyle.Fill))
                {
                    dockTarget.dockLocation = ContainerDockLocation.Left;
                    dockTarget.dockSide = DockSide.Left;
                }
                else if (this.x2e982e5b420711bf(this.MiddlePath, point) && this.manager.AllowDock(ContainerDockLocation.Center) && this.dockStyle == DockStyle.Fill)
                {
                    dockTarget.dockLocation = ContainerDockLocation.Center;
                    dockTarget.dockSide = DockSide.None;
                }
                else
                    dockTarget.type = xedb4922162c60d3d.DockTargetType.Undefined;

                if (dockTarget.type != xedb4922162c60d3d.DockTargetType.Undefined)
                {
                    dockTarget.type = xedb4922162c60d3d.DockTargetType.CreateNewContainer;
                    dockTarget.middle = this.dockStyle == DockStyle.Fill;
                    dockTarget.bounds = xedb4922162c60d3d.xc68a4bb946c59a9e(this.manager.x257d5a0e25592705(dockTarget.dockLocation, this.manager.DockedSize, dockTarget.middle), this.manager.Manager.DockSystemContainer);
                }
                return dockTarget;
            }

            public xedb4922162c60d3d.DockTarget x22749e65b5253094(Point position)
            {
                Point x6b2bb9f943411698 = this.PointToClient(position);
                xedb4922162c60d3d.DockTarget dockTarget = this.layoutSystem == null ? this.x54f27420b41557c2(x6b2bb9f943411698) : this.xd9d182c023a01aa8(x6b2bb9f943411698);
                bool flag = dockTarget.type != xedb4922162c60d3d.DockTargetType.Undefined;
                DockSide dockSide = dockTarget.type == xedb4922162c60d3d.DockTargetType.Undefined ? this.dockSide : dockTarget.dockSide;
                if (flag != this.x3321191c6256921e || dockSide != this.dockSide)
                {
                    this.x3321191c6256921e = flag;
                    this.dockSide = dockSide;
                    this.DrawIndicator();
                }
                return dockTarget;
            }

            private bool x2e982e5b420711bf(Rectangle bounds, Point point)
            {
                return bounds.Contains(point);
            }

            private void x6e8df868b7130012(Graphics g, Color color)
            {
                using (Pen pen = new Pen(color))
                {
                    g.DrawLine(pen, 22, 29, 29, 22);
                    g.DrawLine(pen, 57, 22, 64, 29);
                    g.DrawLine(pen, 64, 57, 57, 64);
                    g.DrawLine(pen, 29, 64, 22, 57);
                }
            }

            private void x46d7024135bf7082(Graphics g, Color color)
            {
                using (Pen pen = new Pen(color))
                {
                    g.DrawLine(pen, 0, 29, 0, 57);
                    g.DrawLine(pen, 0, 57, 23, 57);
                    g.DrawLine(pen, 0, 29, 23, 29);
                }
            }

            private void x9ceea7a4567f6a5f(Graphics g, Color color)
            {
                using (Pen pen = new Pen(color))
                {
                    g.DrawLine(pen, 29, 87, 57, 87);
                    g.DrawLine(pen, 29, 87, 29, 64);
                    g.DrawLine(pen, 57, 87, 57, 64);
                }
            }

            private void xa1ff3514b97ff955(Graphics g, Color color)
            {
                using (Pen pen = new Pen(color))
                {
                    g.DrawLine(pen, 87, 29, 87, 57);
                    g.DrawLine(pen, 87, 29, 64, 29);
                    g.DrawLine(pen, 87, 57, 64, 57);
                }
            }

            private void xd349d1e0601e763e(Graphics g, Color color)
            {
                using (Pen pen = new Pen(color))
                {
                    g.DrawLine(pen, 29, 0, 57, 0);
                    g.DrawLine(pen, 57, 0, 57, 23);
                    g.DrawLine(pen, 29, 0, 29, 23);
                }
            }

            public void x8ffe90e7fbccfccd()
            {
                this.ShouldDispose = true;
                this.x5486e0b5e830d25c();
            }

            public void x5486e0b5e830d25c()
            {
                if (!this.Visible && (this.x3b280f462145bf12 || !this.timer.Enabled))
                    return;
                this.x1a5b1715d3a0d7a6 = Environment.TickCount;
                this.x3b280f462145bf12 = true;
                this.timer.Start();
            }

            public void x35579b297303ed43()
            {
                this.x0ecee64b07d2d5b1(this.bitmap, 0);
                this.x2c6f5ac62ee048e5();
                this.x1a5b1715d3a0d7a6 = Environment.TickCount;
                this.x3b280f462145bf12 = false;
                this.timer.Start();
            }
            // FIXME:edit here
            [SecuritySafeCritical]
            public void x2c6f5ac62ee048e5()
            {
//                x23d0185c2770c169.SetWindowPos(new HandleRef(this, this.Handle), -1, this.bounds.X, this.bounds.Y, this.bounds.Width, this.bounds.Height, SWP_DRAWFRAME | SWP_SHOWWINDOW/*80*/);
                this.Size = this.bounds.Size;
                this.Location = this.bounds.Location;
                this.Show();
            }

            private void OnTimer(object sender, EventArgs e)
            {
                int num1 = Environment.TickCount - this.x1a5b1715d3a0d7a6;
                if (num1 > 200)
                    num1 = 200;
                double num2 = (double)num1 / 200.0;
                double num3 = !this.x3b280f462145bf12 ? num2 * (double)byte.MaxValue : (1.0 - num2) * (double)byte.MaxValue;
                this.x0ecee64b07d2d5b1(this.bitmap, (byte)num3);
                if (num1 < 200)
                    return;
                this.timer.Stop();
                this.Visible = !this.x3b280f462145bf12;
 
                if (this.ShouldDispose)
                    base.Dispose();
            }

            public new void x0ecee64b07d2d5b1(Bitmap bitmap, byte alpha)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    g.DrawImage(this.bitmap, new PointF(0, 0));
                }
            }
        }
    }
}
