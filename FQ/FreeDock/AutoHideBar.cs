using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using FQ.FreeDock.Rendering;

namespace FQ.FreeDock
{
    // A
    class AutoHideBar : Control
    {
        private SandDockManager manager;
        private AutoHideBar.ControlLayoutCollection layoutSystems;
        private Timer x537a4001020fd4c7;
        private Timer x2076b5c9f1eb82ef;
        private Point xa639e9f791585165;
        private ControlLayoutSystem xdf67155884991aa8;
        private PopupContainer x5fea292ffeb2c28c;
        private Rectangle x792c0fd4639cad90;
        private bool x297f71a96c16086c;

        public AutoHideBar.ControlLayoutCollection LayoutSystems
        {
            get
            {
                return this.layoutSystems;
            }
        }

        public SandDockManager Manager
        {
            get
            {
                return this.manager;
            }
            set
            {
                if (this.manager != null)
                    this.manager.UnregisterAutoHideBar(this);

                this.manager = value;
                if (this.manager != null)
                {
                    this.manager.RegisterAutoHideBar(this);
                    this.CalculateAllMetricsAndLayout();
                }
            }
        }

        private int AutoHideSize
        {
            get
            {
                return Math.Max(Control.DefaultFont.Height, 16) + 6;
            }
        }

        public Control PopupContainer
        {
            get
            {
                return this.x5fea292ffeb2c28c;
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(this.AutoHideSize, this.AutoHideSize);
            }
        }

        internal bool Vertical
        {
            get
            {
                if (this.Dock != DockStyle.Left)
                    return this.Dock == DockStyle.Right;
                else
                    return true;
            }
        }

        public ControlLayoutSystem ShowingLayoutSystem
        {
            get
            {
                return this.xdf67155884991aa8;
            }
        }

        public int PopupSize
        {
            get
            {
                return this.x5fea292ffeb2c28c.PopupSize;
            }
            set
            {
                if (value == this.x5fea292ffeb2c28c.PopupSize)
                    return;
                this.x5fea292ffeb2c28c.PopupSize = value;
            }
        }

        public AutoHideBar()
        {
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.layoutSystems = new AutoHideBar.ControlLayoutCollection(this);
            this.x537a4001020fd4c7 = new Timer();
            this.x537a4001020fd4c7.Interval = SystemInformation.DoubleClickTime;
            this.x537a4001020fd4c7.Tick += new EventHandler(this.x79a58a5d2c65c5a4);
            this.x2076b5c9f1eb82ef = new Timer();
            this.x2076b5c9f1eb82ef.Interval = 800;
            this.x2076b5c9f1eb82ef.Tick += new EventHandler(this.xeccc53b32ba6b859);
            this.Visible = false;
        }

        internal void x200394302d96eb9b(ControlLayoutSystem x6e150040c8d97700)
        {
            this.CalculateAllMetricsAndLayout();
            if (this.ShowingLayoutSystem != x6e150040c8d97700)
                return;
            this.x5fea292ffeb2c28c.PerformLayout();
        }

        internal void PropagateNewRenderer()
        {
            this.CalculateAllMetricsAndLayout();
        }
        // reviewed with 2.4
        private void CalculateAllMetricsAndLayout()
        {
            int num1 = 0;
            if (this.ShowingLayoutSystem != null && !this.LayoutSystems.Contains(this.ShowingLayoutSystem))
                this.xcdb145600c1b7224(true);
            if (this.Manager == null)
                return;
            RendererBase renderer = this.Manager.Renderer;
            int num2;
            int num3;
            using (Graphics graphics = this.CreateGraphics())
            {
                foreach (ControlLayoutSystem controlLayoutSystem in this.LayoutSystems)
                {
                    int num4 = num1 + 3;
                    num2 = 0;
                    if (renderer.TabTextDisplay == TabTextDisplayMode.SelectedTab)
                    {
                        foreach (DockControl dockControl in controlLayoutSystem.Controls)
                        {
                            if (this.Vertical)
                            {
                                SizeF sizeF = graphics.MeasureString(dockControl.TabText, this.Font, int.MaxValue, EverettRenderer.StandardVerticalStringFormat);
                                num3 = (int)Math.Ceiling((double)sizeF.Height);
                            }
                            else
                                num3 = (int)Math.Ceiling((double)graphics.MeasureString(dockControl.TabText, this.Font, int.MaxValue, EverettRenderer.StandardStringFormat).Width);
                            if (num3 > num2)
                                num2 = num3;
                        }
                    }
                    int num5;
                    foreach (DockControl dockControl in (CollectionBase) controlLayoutSystem.Controls)
                    {
                        Rectangle rectangle = new Rectangle(-1, -1, this.AutoHideSize - 2, this.AutoHideSize - 2);
                        switch (this.Dock)
                        {
                            case DockStyle.Bottom:
                                rectangle.Offset(0, 3);
                                break;
                            case DockStyle.Right:
                                rectangle.Offset(3, 0);
                                break;
                        }

                        num5 = 7;
                        num5 += 16;
                        if (renderer.TabTextDisplay != TabTextDisplayMode.AllTabs)
                        {
                            if (controlLayoutSystem.SelectedControl == dockControl)
                                num5 += num2 + 16;
                        }
                        else if (!this.Vertical)
                        {
                            num5 += (int)Math.Ceiling((double)graphics.MeasureString(dockControl.TabText, this.Font, int.MaxValue, EverettRenderer.StandardStringFormat).Width);
                            num5 += 3;
                        }
                        else
                        {
                            num5 += (int)Math.Ceiling((double)graphics.MeasureString(dockControl.TabText, this.Font, int.MaxValue, EverettRenderer.StandardVerticalStringFormat).Height);
                            num5 += 3;
                        }

                        if (!this.Vertical)
                        {
                            rectangle.Offset(num4, 0);
                            rectangle.Width = num5;
                            num4 += num5;
                        }
                        else
                        {
                            rectangle.Offset(0, num4);
                            rectangle.Height = num5;
                            num4 += num5;
                        }
                        dockControl.x700c42042910e68b = rectangle;
                    }
                    num1 = num4 + 10;
                }
            }
            this.Visible = this.LayoutSystems.Count != 0;
            this.Invalidate();
        }

        private DockControl x37c93a224e23ba95(Point point)
        {
            foreach (ControlLayoutSystem controlLayoutSystem in this.LayoutSystems)
            {
                foreach (DockControl dockControl in controlLayoutSystem.Controls)
                {
                    if (dockControl.x700c42042910e68b.Contains(point))
                        return dockControl;
                }
            }
            return null;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (this.Manager == null || this.Manager.DockSystemContainer == null)
                base.OnPaintBackground(pevent);
            else
                this.Manager.Renderer.DrawAutoHideBarBackground(this.Manager.DockSystemContainer, (Control)this, pevent.Graphics, this.ClientRectangle);
        }
        // reviewed with 2.4
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Manager == null)
            {
                base.OnPaint(e);
                return;
            }

            DockSide dockSide = DockSide.Right;
            switch (this.Dock)
            {
                case DockStyle.Top:
                    dockSide = DockSide.Top;
                    break;
                case DockStyle.Bottom:
                    dockSide = DockSide.Bottom;
                    break;
                case DockStyle.Left:
                    dockSide = DockSide.Left;
                    break;            
            }
            this.Manager.Renderer.StartRenderSession(HotkeyPrefix.None);
            foreach (ControlLayoutSystem controlLayoutSystem in this.LayoutSystems)
            {
                foreach (DockControl dockControl in controlLayoutSystem.Controls)
                {
                    DrawItemState state = DrawItemState.Default;
                    if (dockControl == controlLayoutSystem.SelectedControl)
                        state |= DrawItemState.Selected;
                    string text = dockControl.TabText;
                    if (this.Manager.Renderer.TabTextDisplay == TabTextDisplayMode.SelectedTab && dockControl != controlLayoutSystem.SelectedControl)
                        text = "";
                    this.Manager.Renderer.DrawCollapsedTab(e.Graphics, dockControl.x700c42042910e68b, dockSide, dockControl.WorkingTabImage, text, this.Font, dockControl.BackColor, dockControl.ForeColor, state, this.Vertical);

                }
            }
            this.Manager.Renderer.FinishRenderSession();
        }

        private void x53cde82d34a241f8(PopupContainer container, Rectangle bounds, Rectangle x0cd0c84a144ffcbc)
        {
            this.x297f71a96c16086c = true;
            try
            {
                float num1 = (float)(x0cd0c84a144ffcbc.X - bounds.X);
                float num3 = (float)(x0cd0c84a144ffcbc.Y - bounds.Y);
                float num4 = (float)(x0cd0c84a144ffcbc.Width - bounds.Width);
                float num5 = (float)(x0cd0c84a144ffcbc.Height - bounds.Height);
                int tickCount = Environment.TickCount;
                while (Environment.TickCount < tickCount + 100)
                {
                    float num2 = (float)(Environment.TickCount - tickCount) / 100f;
                    Rectangle rectangle = new Rectangle((int)((float)bounds.X + num1 * num5), (int)((float)bounds.Y + num2 * num5), (int)((float)bounds.Width + num3 * num5), (int)((float)bounds.Height + num4 * num5));
                    container.SetBounds(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, BoundsSpecified.All);
                    Application.DoEvents();
                    if (container == null)
                        break;
                }
            }
            finally
            {
                this.x297f71a96c16086c = false;
            }
        }

        private bool x6991238ec3e25129()
        {
            return !x443cc432acaadb1d.x641f26d1017e3571;
        }
        // reviewed with 2.4
        internal void xcdb145600c1b7224(bool x0b9c38731edfc369)
        {
            if (this.xdf67155884991aa8 == null)
                return;
            PopupContainer xd70b090e3181abff = this.x5fea292ffeb2c28c;
            this.x2076b5c9f1eb82ef.Enabled = false;
            if (!x0b9c38731edfc369)
            {
                Rectangle xd2acd28268ef2513;
                this.x8012502b8eced8ff(this.xdf67155884991aa8.PopupSize, out xd2acd28268ef2513);
                xd70b090e3181abff.SuspendLayout();
                this.x53cde82d34a241f8(xd70b090e3181abff, xd70b090e3181abff.Bounds, xd2acd28268ef2513);
                xd70b090e3181abff.ResumeLayout();
            }
            ControlLayoutSystem controlLayoutSystem = this.xdf67155884991aa8;
            this.xdf67155884991aa8 = null;
            Control[] controlArray1 = new Control[xd70b090e3181abff.Controls.Count];
            xd70b090e3181abff.Controls.CopyTo(controlArray1, 0);
            foreach (Control control in controlArray1)
                LayoutUtilities.xa7513d57b4844d46(control);
            xd70b090e3181abff.Dispose();
            if (controlLayoutSystem != null && controlLayoutSystem.SelectedControl != null)
                controlLayoutSystem.SelectedControl.OnAutoHidePopupClosed(EventArgs.Empty);
        }

        // reviewed with 2.4
        internal void xe6ff614263a59ef9(DockControl dockControl, bool x0b9c38731edfc369, bool x17cc8f73454a0462)
        {
            if (this.xdf67155884991aa8 == dockControl.LayoutSystem && dockControl.LayoutSystem.SelectedControl == dockControl)
            {
                if (!x17cc8f73454a0462)
                    return;
                dockControl.Activate();
            }
            else
            {
                dockControl.LayoutSystem.SelectedControl = dockControl;
                try
                {
                    if (this.xdf67155884991aa8 == dockControl.LayoutSystem)
                        return;
                    this.xcdb145600c1b7224(true);
                    Rectangle rectangle;
                    this.x792c0fd4639cad90 = this.x8012502b8eced8ff(dockControl.LayoutSystem.PopupSize, out rectangle);
                    PopupContainer xd70b090e3181abff = new PopupContainer(this);
                    foreach (DockControl dc in dockControl.LayoutSystem.Controls)
                    {
                        if (dc.Parent != null)
                            LayoutUtilities.xa7513d57b4844d46(dc);
                        dc.Parent = xd70b090e3181abff;
                    }
                    xd70b090e3181abff.LayoutSystem = dockControl.LayoutSystem;
                    xd70b090e3181abff.Visible = false;
                    this.Parent.Controls.Add(xd70b090e3181abff);
                    xd70b090e3181abff.Bounds = this.x792c0fd4639cad90;
                    xd70b090e3181abff.SuspendLayout();
                    xd70b090e3181abff.Bounds = rectangle;
                    xd70b090e3181abff.Visible = true;
                    xd70b090e3181abff.BringToFront();
                    if (!x0b9c38731edfc369)
                        this.x53cde82d34a241f8(xd70b090e3181abff, rectangle, this.x792c0fd4639cad90);
                    xd70b090e3181abff.Bounds = this.x792c0fd4639cad90;
                    xd70b090e3181abff.ResumeLayout();
                    if (xd70b090e3181abff.IsDisposed || xd70b090e3181abff.Parent == null)
                        return;
                    this.x5fea292ffeb2c28c = xd70b090e3181abff;
                    this.xdf67155884991aa8 = dockControl.LayoutSystem;
                    this.x2076b5c9f1eb82ef.Enabled = true;
                    dockControl.OnAutoHidePopupOpened(EventArgs.Empty);
                }
                finally
                {
                    if (x17cc8f73454a0462 && this.ShowingLayoutSystem == dockControl.LayoutSystem)
                        dockControl.Activate();
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.xdf67155884991aa8 == null)
                return;
            this.BeginInvoke((Delegate)new AutoHideBar.x23dc61b48e59b2f1(this.xcdb145600c1b7224), new object[] { true });
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            if (this.xdf67155884991aa8 == null)
                return;
            this.BeginInvoke((Delegate)new AutoHideBar.x23dc61b48e59b2f1(this.xcdb145600c1b7224), new object[] { true });
        }

        private Rectangle x8012502b8eced8ff(int x5614e4ef0596c91d, out Rectangle xd2acd28268ef2513)
        {
            Rectangle rectangle = this.Bounds;
            int num1;
            switch (this.Dock)
            {
                case DockStyle.Top:
                    rectangle = new Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, 0);
                    break;
                case DockStyle.Bottom:
                    rectangle = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, 0);
                    break;
                case DockStyle.Left:
                    rectangle = new Rectangle(rectangle.Right, rectangle.Top, 0, rectangle.Height);
                    break;
                case DockStyle.Right:
                    rectangle = new Rectangle(rectangle.Left, rectangle.Top, 0, rectangle.Height);
                    break;
            }
            xd2acd28268ef2513 = rectangle;
            bool flag = true;
            num1 = x5614e4ef0596c91d;
            if (flag)
                num1 += 4;
            switch (this.Dock)
            {
                case DockStyle.Top:
                    rectangle.Height = num1;
                    break;
                case DockStyle.Bottom:
                    rectangle.Offset(0, -num1);
                    rectangle.Height = num1;
                    break;
                case DockStyle.Left:
                    rectangle.Width = num1;
                    break;
                case DockStyle.Right:
                    rectangle.Offset(-num1, 0);
                    rectangle.Width = num1;
                    break;
            }
            return rectangle;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.x297f71a96c16086c)
                return;
            Point point = new Point(e.X, e.Y);
            if (!(point != this.xa639e9f791585165))
                return;
            this.xa639e9f791585165 = point;
            this.x537a4001020fd4c7.Enabled = false;
            this.x537a4001020fd4c7.Enabled = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.x297f71a96c16086c)
                return;
            DockControl dockControl = this.x37c93a224e23ba95(new Point(e.X, e.Y));
            if (dockControl != null)
                this.xe6ff614263a59ef9(dockControl, false, true);
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);
            DockControl dockControl = this.x37c93a224e23ba95(this.PointToClient(new System.Drawing.Point(drgevent.X, drgevent.Y)));
            if (dockControl == null)
                return;
            this.xe6ff614263a59ef9(dockControl, true, true);
        }

        private void x79a58a5d2c65c5a4(object sender, EventArgs e)
        {
            this.x537a4001020fd4c7.Enabled = false;
            if (this.x297f71a96c16086c)
                return;
            DockControl dockControl = this.x37c93a224e23ba95(this.PointToClient(Cursor.Position));
            if (dockControl != null)
                this.xe6ff614263a59ef9(dockControl, false, false);
        }
        // reivewed with 2.4
        private void xeccc53b32ba6b859(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            if (this.x5fea292ffeb2c28c.ClientRectangle.Contains(this.x5fea292ffeb2c28c.PointToClient(Cursor.Position)) || this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)) || (this.x5fea292ffeb2c28c.IsSplitting || this.x5fea292ffeb2c28c.ContainsFocus))
                return;
            this.xcdb145600c1b7224(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.xcdb145600c1b7224(true);
                this.x537a4001020fd4c7.Tick -= new EventHandler(this.x79a58a5d2c65c5a4);
                this.x537a4001020fd4c7.Dispose();
                this.x537a4001020fd4c7 = null;
                this.x2076b5c9f1eb82ef.Tick -= new EventHandler(this.xeccc53b32ba6b859);
                this.x2076b5c9f1eb82ef.Dispose();
                this.x2076b5c9f1eb82ef = null;
                if (this.x5fea292ffeb2c28c != null)
                {
                    this.x5fea292ffeb2c28c.Dispose();
                    this.x5fea292ffeb2c28c = null;
                }
                this.LayoutSystems.Clear();
            }
            base.Dispose(disposing);
        }

        public void xbb5f70c792fb9034(Rectangle bounds)
        {
            this.x5fea292ffeb2c28c.Invalidate(bounds);
        }

        public class ControlLayoutCollection : CollectionBase
        {
            private AutoHideBar parent;

            public ControlLayoutCollection(AutoHideBar parent)
            {
                this.parent = parent;
            }

            public bool Contains(ControlLayoutSystem layout)
            {
                return this.List.Contains(layout);
            }

            protected override void OnInsertComplete(int index, object value)
            {
                ((ControlLayoutSystem)value).xa85d8c17921cc878(this.parent);
                this.parent.CalculateAllMetricsAndLayout();
            }

            protected override void OnRemoveComplete(int index, object value)
            {
                ((ControlLayoutSystem)value).xa85d8c17921cc878(null);
                this.parent.CalculateAllMetricsAndLayout();
            }

            protected override void OnClearComplete()
            {
                this.parent.CalculateAllMetricsAndLayout();
            }

            protected override void OnClear()
            {
                foreach (ControlLayoutSystem Layout in this)
                    Layout.xa85d8c17921cc878(null);
            }

            public int Add(ControlLayoutSystem layout)
            {
                return this.List.Add(layout);
            }

            public void Remove(ControlLayoutSystem layout)
            {
                this.List.Remove(layout);
            }

            public ControlLayoutSystem this [int index]
            {
                get
                {
                    return (ControlLayoutSystem)this.List[index];
                }
            }
        }

        private delegate void x23dc61b48e59b2f1(bool quick);
    }
}
