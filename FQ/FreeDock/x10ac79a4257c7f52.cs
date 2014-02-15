using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using FQ.FreeDock.Rendering;

namespace FQ.FreeDock
{
    internal class x10ac79a4257c7f52 : Control
    {
        private SandDockManager x91f347c6e97f1846;
        private x10ac79a4257c7f52.x01c0afa1afffb431 x820c504c9c557c92;
        private Timer x537a4001020fd4c7;
        private Timer x2076b5c9f1eb82ef;
        private System.Drawing.Point xa639e9f791585165;
        private ControlLayoutSystem xdf67155884991aa8;
        private x87cf4de36131799d x5fea292ffeb2c28c;
        private Rectangle x792c0fd4639cad90;
        private bool x297f71a96c16086c;

        public x10ac79a4257c7f52.x01c0afa1afffb431 x7fdaeb05cb5e84f3
        {
            get
            {
                return this.x820c504c9c557c92;
            }
        }

        public SandDockManager x460ab163f44a604d
        {
            get
            {
                return this.x91f347c6e97f1846;
            }
            set
            {
                if (this.x91f347c6e97f1846 != null)
                    this.x91f347c6e97f1846.UnregisterAutoHideBar(this);
                do
                {
                    this.x91f347c6e97f1846 = value;
                    if (this.x91f347c6e97f1846 != null)
                        this.x91f347c6e97f1846.RegisterAutoHideBar(this);
                    else
                        goto label_1;
                }
                while (4 == 0);
                goto label_3;
                label_1:
                return;
                label_3:
                this.x7e9646eed248ed11();
            }
        }

        private int xf03a14e5f0010fc9
        {
            get
            {
                return Math.Max(Control.DefaultFont.Height, 16) + 6;
            }
        }

        public Control x87cf4de36131799d
        {
            get
            {
                return (Control)this.x5fea292ffeb2c28c;
            }
        }

        protected override System.Drawing.Size DefaultSize
        {
            get
            {
                return new System.Drawing.Size(this.xf03a14e5f0010fc9, this.xf03a14e5f0010fc9);
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

        public ControlLayoutSystem x23498f53d87354d4
        {
            get
            {
                return this.xdf67155884991aa8;
            }
        }

        public int xca843b3e9a1c605f
        {
            get
            {
                return this.x5fea292ffeb2c28c.xca843b3e9a1c605f;
            }
            set
            {
                if (value == this.x5fea292ffeb2c28c.xca843b3e9a1c605f)
                    return;
                this.x5fea292ffeb2c28c.xca843b3e9a1c605f = value;
            }
        }

        public x10ac79a4257c7f52()
        {
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            if (2 == 0)
                ;
            this.SetStyle(ControlStyles.Selectable, false);
            this.x820c504c9c557c92 = new x10ac79a4257c7f52.x01c0afa1afffb431(this);
            if (int.MaxValue != 0)
                goto label_2;
            label_1:
            this.Visible = false;
            return;
            label_2:
            this.x537a4001020fd4c7 = new Timer();
            this.x537a4001020fd4c7.Interval = SystemInformation.DoubleClickTime;
            this.x537a4001020fd4c7.Tick += new EventHandler(this.x79a58a5d2c65c5a4);
            this.x2076b5c9f1eb82ef = new Timer();
            this.x2076b5c9f1eb82ef.Interval = 800;
            this.x2076b5c9f1eb82ef.Tick += new EventHandler(this.xeccc53b32ba6b859);
            goto label_1;
        }

        internal void x200394302d96eb9b(ControlLayoutSystem x6e150040c8d97700)
        {
            this.x7e9646eed248ed11();
            if (this.x23498f53d87354d4 != x6e150040c8d97700)
                return;
            this.x5fea292ffeb2c28c.PerformLayout();
        }

        internal void x4481febbc2e58301()
        {
            this.x7e9646eed248ed11();
        }

        private void x7e9646eed248ed11()
        {
            int num1 = 0;
            if (this.x23498f53d87354d4 != null && !this.x7fdaeb05cb5e84f3.x263d579af1d0d43f(this.x23498f53d87354d4))
                goto label_59;
            label_2:
            if (this.x460ab163f44a604d == null)
                return;
            RendererBase renderer = this.x460ab163f44a604d.Renderer;
            int num2;
            int num3;
            using (Graphics graphics = this.CreateGraphics())
            {
                foreach (ControlLayoutSystem controlLayoutSystem in (CollectionBase) this.x7fdaeb05cb5e84f3)
                {
                    int num4 = num1 + 3;
                    if (0 == 0)
                        num2 = 0;
                    if (renderer.TabTextDisplay == TabTextDisplayMode.SelectedTab)
                        goto label_36;
                    label_6:
                    int num5;
                    foreach (DockControl dockControl in (CollectionBase) controlLayoutSystem.Controls)
                    {
                        Rectangle rectangle = new Rectangle(-1, -1, this.xf03a14e5f0010fc9 - 2, this.xf03a14e5f0010fc9 - 2);
                        if (false)
                            goto label_16;
                        else
                            goto label_26;
                        label_14:
                        if (!this.x61c108cc44ef385a)
                            goto label_10;
                        else
                            goto label_11;
                        label_8:
                        dockControl.x700c42042910e68b = rectangle;
                        continue;
                        label_10:
                        rectangle.Offset(num4, 0);
                        rectangle.Width = num5;
                        num4 += num5;
                        goto label_8;
                        label_11:
                        if ((num2 | int.MinValue) != 0)
                            rectangle.Offset(0, num4);
                        rectangle.Height = num5;
                        num4 += num5;
                        goto label_8;
                        label_16:
                        num5 += num2 + 16;
                        goto label_14;
                        label_26:
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
                        if ((uint)num4 > uint.MaxValue)
                            goto label_20;
                        else
                            goto label_18;
                        label_17:
                        num5 += 3;
                        goto label_14;
                        label_18:
                        if (renderer.TabTextDisplay != TabTextDisplayMode.AllTabs)
                        {
                            if (controlLayoutSystem.SelectedControl == dockControl)
                                goto label_16;
                            else
                                goto label_14;
                        }
                        else if (!this.x61c108cc44ef385a)
                        {
                            if ((uint)num2 - (uint)num2 >= 0U)
                            {
                                num5 += (int)Math.Ceiling((double)graphics.MeasureString(dockControl.TabText, this.Font, int.MaxValue, EverettRenderer.x27e1c82c97265861).Width);
                                goto label_17;
                            }
                            else
                                goto label_17;
                        }
                        label_20:
                        num5 += (int)Math.Ceiling((double)graphics.MeasureString(dockControl.TabText, this.Font, int.MaxValue, EverettRenderer.xc351c68a86733972).Height);
                        goto label_17;
                    }
                    num1 = num4 + 10;
                    continue;
                    label_36:
                    IEnumerator enumerator = controlLayoutSystem.Controls.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            do
                            {
                                if (enumerator.MoveNext())
                                    goto label_46;
                                else
                                    goto label_43;
                                label_38:
                                continue;
                                label_41:
                                DockControl dockControl;
                                num3 = (int)Math.Ceiling((double)graphics.MeasureString(dockControl.TabText, this.Font, int.MaxValue, EverettRenderer.x27e1c82c97265861).Width);
                                goto label_38;
                                label_42:
                                if (this.x61c108cc44ef385a)
                                    goto label_44;
                                else
                                    goto label_41;
                                label_43:
                                if (true)
                                    goto label_6;
                                label_44:
                                SizeF sizeF = graphics.MeasureString(dockControl.TabText, this.Font, int.MaxValue, EverettRenderer.xc351c68a86733972);
                                if ((int)byte.MaxValue != 0)
                                {
                                    num3 = (int)Math.Ceiling((double)sizeF.Height);
                                    if ((uint)num2 < 0U)
                                        goto label_41;
                                    else
                                        goto label_38;
                                }
                                else
                                    goto label_42;
                                label_46:
                                dockControl = (DockControl)enumerator.Current;
                                goto label_42;
                            }
                            while (num3 <= num2);
                            num2 = num3;
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        if (disposable != null)
                            disposable.Dispose();
                    }
                }
            }
            this.Visible = this.x7fdaeb05cb5e84f3.Count != 0;
            if (false)
                return;
            this.Invalidate();
            return;
            label_59:
            this.xcdb145600c1b7224(true);
            goto label_2;
        }

        private DockControl x37c93a224e23ba95(System.Drawing.Point x13d4cb8d1bd20347)
        {
            IEnumerator enumerator1 = this.x7fdaeb05cb5e84f3.GetEnumerator();
            try
            {
                label_11:
                if (enumerator1.MoveNext())
                {
                    IEnumerator enumerator2 = ((ControlLayoutSystem)enumerator1.Current).Controls.GetEnumerator();
                    try
                    {
                        DockControl dockControl;
                        do
                        {
                            if (!enumerator2.MoveNext())
                            {
                                if (0 == 0)
                                    goto label_11;
                            }
                            dockControl = (DockControl)enumerator2.Current;
                        }
                        while ((int)byte.MaxValue != 0 && !dockControl.x700c42042910e68b.Contains(x13d4cb8d1bd20347));
                        return dockControl;
                    }
                    finally
                    {
                        IDisposable disposable = enumerator2 as IDisposable;
                        if (disposable != null)
                            disposable.Dispose();
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator1 as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            return (DockControl)null;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (this.x460ab163f44a604d == null || this.x460ab163f44a604d.DockSystemContainer == null)
                base.OnPaintBackground(pevent);
            else
                this.x460ab163f44a604d.Renderer.DrawAutoHideBarBackground(this.x460ab163f44a604d.DockSystemContainer, (Control)this, pevent.Graphics, this.ClientRectangle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.x460ab163f44a604d != null)
                goto label_34;
            label_33:
            base.OnPaint(e);
            return;
            label_34:
            DockSide dockSide = DockSide.Right;
            if (0 != 0)
                return;
            switch (this.Dock)
            {
                case DockStyle.Top:
                    dockSide = DockSide.Top;
                    if (0 == 0)
                        goto default;
                    else
                        break;
                case DockStyle.Bottom:
                    dockSide = DockSide.Bottom;
                    goto default;
                case DockStyle.Left:
                    dockSide = DockSide.Left;
                    goto default;
                default:
                    this.x460ab163f44a604d.Renderer.StartRenderSession(HotkeyPrefix.None);
                    break;
            }
            IEnumerator enumerator1 = this.x7fdaeb05cb5e84f3.GetEnumerator();
            try
            {
                label_23:
                while (enumerator1.MoveNext())
                {
                    ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)enumerator1.Current;
                    IEnumerator enumerator2 = controlLayoutSystem.Controls.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            if (!enumerator2.MoveNext())
                            {
                                if (0 == 0)
                                    goto label_23;
                            }
                            DockControl dockControl = (DockControl)enumerator2.Current;
                            DrawItemState state;
                            do
                            {
                                state = DrawItemState.Default;
                                if (0 == 0)
                                {
                                    if (15 != 0)
                                    {
                                        if (-2 == 0)
                                        {
                                            if (8 != 0)
                                                goto label_11;
                                        }
                                        else
                                            goto label_12;
                                    }
                                    else
                                        goto label_9;
                                }
                                else
                                    goto label_12;
                            }
                            while (2 != 0 && 0 != 0);
                            label_5:
                            string text;
                            if (dockControl != controlLayoutSystem.SelectedControl)
                            {
                                text = "";
                                if (-2 == 0)
                                    goto label_9;
                            }
                            label_6:
                            this.x460ab163f44a604d.Renderer.DrawCollapsedTab(e.Graphics, dockControl.x700c42042910e68b, dockSide, dockControl.x1999b243e321e38a, text, this.Font, dockControl.BackColor, dockControl.ForeColor, state, this.x61c108cc44ef385a);
                            continue;
                            label_9:
                            if (this.x460ab163f44a604d.Renderer.TabTextDisplay != TabTextDisplayMode.SelectedTab)
                                goto label_6;
                            else
                                goto label_5;
                            label_11:
                            state |= DrawItemState.Selected;
                            goto label_13;
                            label_12:
                            if (dockControl == controlLayoutSystem.SelectedControl)
                                goto label_11;
                            label_13:
                            text = dockControl.TabText;
                            goto label_9;
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator2 as IDisposable;
                        if (disposable != null)
                            disposable.Dispose();
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator1 as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            this.x460ab163f44a604d.Renderer.FinishRenderSession();
            if (0 != 0)
                goto label_33;
        }

        private void x53cde82d34a241f8(x87cf4de36131799d xd70b090e3181abff, Rectangle x0ac6c3cc02709091, Rectangle x0cd0c84a144ffcbc)
        {
            this.x297f71a96c16086c = true;
            try
            {
                float num1 = (float)(x0cd0c84a144ffcbc.X - x0ac6c3cc02709091.X);
                label_9:
                float num2;
                do
                {
                    float num3 = (float)(x0cd0c84a144ffcbc.Y - x0ac6c3cc02709091.Y);
                    float num4 = (float)(x0cd0c84a144ffcbc.Width - x0ac6c3cc02709091.Width);
                    label_7:
                    float num5 = (float)(x0cd0c84a144ffcbc.Height - x0ac6c3cc02709091.Height);
                    int tickCount = Environment.TickCount;
                    do
                    {
                        if (Environment.TickCount >= tickCount + 100)
                        {
                            if ((uint)tickCount + (uint)num4 <= uint.MaxValue)
                                goto label_10;
                        }
                        else
                            goto label_8;
                        label_5:
                        float num6 = 0;
                        float num7 = 0;
                        float num8 = 0;
                        float num9 = 0;
                        if (((int)(uint)num3 | 8) != 0)
                        {
                            Rectangle rectangle = new Rectangle((int)num6, (int)num7, (int)num8, (int)num9);
                            xd70b090e3181abff.SetBounds(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, BoundsSpecified.All);
                            Application.DoEvents();
                            continue;
                        }
                        else
                            goto label_9;
                        label_8:
                        num2 = (float)(Environment.TickCount - tickCount) / 100f;
                        num6 = (float)x0ac6c3cc02709091.X + num1 * num2;
                        num7 = (float)x0ac6c3cc02709091.Y + num3 * num2;
                        num8 = (float)x0ac6c3cc02709091.Width + num4 * num2;
                        num9 = (float)x0ac6c3cc02709091.Height + num5 * num2;
                        if ((uint)num5 <= uint.MaxValue)
                            goto label_5;
                        else
                            goto label_7;
                    }
                    while (xd70b090e3181abff != null);
                }
                while (false);
                return;
                label_10:
                ;
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

        internal void xcdb145600c1b7224(bool x0b9c38731edfc369)
        {
            if (this.xdf67155884991aa8 != null)
                goto label_22;
            label_21:
            if (true)
                return;
            else
                return;
            label_22:
            x87cf4de36131799d xd70b090e3181abff = this.x5fea292ffeb2c28c;
            if (!x0b9c38731edfc369)
                goto label_23;
            label_15:
            int num1 = 1;
            label_16:
            x0b9c38731edfc369 = num1 != 0;
            this.x2076b5c9f1eb82ef.Enabled = false;
            int num2;
            if (!x0b9c38731edfc369)
                goto label_18;
            else
                goto label_12;
            label_11:
            xd70b090e3181abff.ResumeLayout();
            label_12:
            ControlLayoutSystem controlLayoutSystem = this.xdf67155884991aa8;
            this.xdf67155884991aa8 = (ControlLayoutSystem)null;
            label_10:
            Control[] controlArray1 = new Control[xd70b090e3181abff.Controls.Count];
            xd70b090e3181abff.Controls.CopyTo((Array)controlArray1, 0);
            Control[] controlArray2 = controlArray1;
            int index = 0;
            do
            {
                while (index < controlArray2.Length)
                {
                    LayoutUtilities.xa7513d57b4844d46(controlArray2[index]);
                    ++index;
                    if (false)
                        goto label_11;
                }
                xd70b090e3181abff.Dispose();
                if ((uint)index <= uint.MaxValue)
                {
                    if (2 != 0)
                    {
                        while (controlLayoutSystem != null)
                        {
                            if (controlLayoutSystem.SelectedControl != null)
                            {
                                controlLayoutSystem.SelectedControl.OnAutoHidePopupClosed(EventArgs.Empty);
                                return;
                            }
                            else if ((index | 1) != 0)
                            {
                                if ((uint)index >= 0U)
                                    return;
                                else
                                    goto label_21;
                            }
                        }
                    }
                    else
                        goto label_17;
                }
                else
                    goto label_10;
            }
            while (8 == 0);
            return;
            label_17:
            return;
            label_18:
            Rectangle xd2acd28268ef2513;
            this.x8012502b8eced8ff(this.xdf67155884991aa8.xca843b3e9a1c605f, out xd2acd28268ef2513);
            xd70b090e3181abff.SuspendLayout();
            this.x53cde82d34a241f8(xd70b090e3181abff, xd70b090e3181abff.Bounds, xd2acd28268ef2513);
            if (3 != 0)
                goto label_11;
            else
                goto label_15;
            label_23:
            num1 = !this.x6991238ec3e25129() ? 1 : 0;
            goto label_16;
        }

        internal void xe6ff614263a59ef9(DockControl x43bec302f92080b9, bool x0b9c38731edfc369, bool x17cc8f73454a0462)
        {
            if (this.xdf67155884991aa8 == x43bec302f92080b9.LayoutSystem)
            {
                if (true)
                    goto label_40;
                label_37:
                if (!x17cc8f73454a0462)
                    return;
                x43bec302f92080b9.Activate();
                return;
                label_40:
                if (0 == 0)
                {
                    if (x43bec302f92080b9.LayoutSystem.SelectedControl == x43bec302f92080b9)
                        goto label_37;
                    else
                        goto label_33;
                }
            }
            else
                goto label_33;
            label_2:
            if (x43bec302f92080b9.LayoutSystem.SelectedControl != x43bec302f92080b9)
                return;
            try
            {
                if (this.xdf67155884991aa8 != x43bec302f92080b9.LayoutSystem)
                    goto label_10;
                else
                    goto label_27;
                label_6:
                x87cf4de36131799d xd70b090e3181abff;
                do
                {
                    do
                    {
                        xd70b090e3181abff.Bounds = this.x792c0fd4639cad90;
                        xd70b090e3181abff.ResumeLayout();
                        if (!xd70b090e3181abff.IsDisposed && xd70b090e3181abff.Parent != null)
                        {
                            this.x5fea292ffeb2c28c = xd70b090e3181abff;
                            this.xdf67155884991aa8 = x43bec302f92080b9.LayoutSystem;
                        }
                        else
                            goto label_39;
                    }
                    while (((x0b9c38731edfc369 ? 1 : 0) | 3) == 0);
                    this.x2076b5c9f1eb82ef.Enabled = true;
                    x43bec302f92080b9.OnAutoHidePopupOpened(EventArgs.Empty);
                }
                while (false);
                return;
                label_39:
                return;
                label_9:
                do
                {
                    xd70b090e3181abff.Visible = false;
                    this.Parent.Controls.Add((Control)xd70b090e3181abff);
                }
                while (((x0b9c38731edfc369 ? 1 : 0) & 0) != 0);
                xd70b090e3181abff.Bounds = this.x792c0fd4639cad90;
                xd70b090e3181abff.SuspendLayout();
                Rectangle xd2acd28268ef2513;
                xd70b090e3181abff.Bounds = xd2acd28268ef2513;
                xd70b090e3181abff.Visible = true;
                xd70b090e3181abff.BringToFront();
                if ((!x0b9c38731edfc369))
                {
                    this.x53cde82d34a241f8(xd70b090e3181abff, xd2acd28268ef2513, this.x792c0fd4639cad90);
                    goto label_6;
                }
                else
                    goto label_6;
                label_10:
                this.xcdb145600c1b7224(true);
                this.x792c0fd4639cad90 = this.x8012502b8eced8ff(x43bec302f92080b9.LayoutSystem.xca843b3e9a1c605f, out xd2acd28268ef2513);
                xd70b090e3181abff = new x87cf4de36131799d(this);
                IEnumerator enumerator = x43bec302f92080b9.LayoutSystem.Controls.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        DockControl dockControl = (DockControl)enumerator.Current;
                        if (dockControl.Parent == null)
                            goto label_14;
                        label_13:
                        LayoutUtilities.xa7513d57b4844d46((Control)dockControl);
                        label_14:
                        dockControl.Parent = (Control)xd70b090e3181abff;
                        if (0 != 0)
                            goto label_13;
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    label_21:
                    while (disposable != null)
                    {
                        disposable.Dispose();
                        if (2 != 0)
                            goto label_22;
                    }
                    label_19:
                    while (true)
                    {
                        if (0 == 0)
                        {
                            if (true)
                                goto label_25;
                            else
                                goto label_25;
                        }
                    }
                    label_22:
                    if (true)
                    {
                        if (0 != 0)
                            goto label_19;
                    }
                    else
                        goto label_21;
                    label_25:
                    ;
                }
                xd70b090e3181abff.x5a9cbf8ad0ee9896 = x43bec302f92080b9.LayoutSystem;
                if (true)
                {
                    if (true)
                        goto label_9;
                    else
                        goto label_6;
                }
                label_27:
                if (0 == 0)
                    return;
                else
                    goto label_9;
            }
            finally
            {
                if (x17cc8f73454a0462 && this.x23498f53d87354d4 == x43bec302f92080b9.LayoutSystem)
                    x43bec302f92080b9.Activate();
            }
            label_33:
            x0b9c38731edfc369 = x0b9c38731edfc369 || !this.x6991238ec3e25129();
            x43bec302f92080b9.LayoutSystem.SelectedControl = x43bec302f92080b9;
            if (true)
                goto label_2;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.xdf67155884991aa8 == null)
                return;
            this.BeginInvoke((Delegate)new x10ac79a4257c7f52.x23dc61b48e59b2f1(this.xcdb145600c1b7224), new object[1]
            {
                (object)true
            });
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            if (this.xdf67155884991aa8 == null)
                return;
            this.BeginInvoke((Delegate)new x10ac79a4257c7f52.x23dc61b48e59b2f1(this.xcdb145600c1b7224), new object[1]
            {
                (object)true
            });
        }

        private Rectangle x8012502b8eced8ff(int x5614e4ef0596c91d, out Rectangle xd2acd28268ef2513)
        {
            Rectangle rectangle = this.Bounds;
            int num1;
            switch (this.Dock)
            {
                case DockStyle.Top:
                    rectangle = new Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, 0);
                    int num2;
                    if (false)
                        goto label_8;
                    else
                        goto default;
                case DockStyle.Bottom:
                    rectangle = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, 0);
                    goto default;
                case DockStyle.Left:
                    rectangle = new Rectangle(rectangle.Right, rectangle.Top, 0, rectangle.Height);
                    goto default;
                case DockStyle.Right:
                    rectangle = new Rectangle(rectangle.Left, rectangle.Top, 0, rectangle.Height);
                    goto default;
                default:
                    xd2acd28268ef2513 = rectangle;
                    bool flag = true;
                    num1 = x5614e4ef0596c91d;
                    if (!flag)
                    {
                        if ((num1 & 0) == 0)
                        {
                            if ((uint)x5614e4ef0596c91d - (uint)num1 <= uint.MaxValue)
                            {
                                if (false)
                                    break;
                                else
                                    goto label_7;
                            }
                            else
                                goto case DockStyle.Left;
                        }
                        else
                            break;
                    }
                    else
                        goto label_8;
            }
            label_3:
            rectangle.Width = num1;
            goto label_15;
            label_7:
            switch (this.Dock)
            {
                case DockStyle.Top:
                    rectangle.Height = num1;
                    goto label_15;
                case DockStyle.Bottom:
                    rectangle.Offset(0, -num1);
                    rectangle.Height = num1;
                    if ((uint)x5614e4ef0596c91d < 0U)
                        goto label_3;
                    else
                        goto label_15;
                case DockStyle.Left:
                    goto label_3;
                case DockStyle.Right:
                    rectangle.Offset(-num1, 0);
                    rectangle.Width = num1;
                    goto label_15;
                default:
                    goto label_15;
            }
            label_8:
            num1 += 4;
            goto label_7;
            label_15:
            return rectangle;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            while (!this.x297f71a96c16086c && 0 == 0)
            {
                if (8 != 0)
                {
                    System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);
                    if (!(point != this.xa639e9f791585165))
                        break;
                    this.xa639e9f791585165 = point;
                    this.x537a4001020fd4c7.Enabled = false;
                    this.x537a4001020fd4c7.Enabled = true;
                    break;
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.x297f71a96c16086c)
                return;
            DockControl x43bec302f92080b9 = this.x37c93a224e23ba95(new System.Drawing.Point(e.X, e.Y));
            do
            {
                if (x43bec302f92080b9 == null)
                {
                    if (0 == 0 || 3 == 0)
                        goto label_6;
                }
                else
                    goto label_8;
                label_2:
                continue;
                label_8:
                this.xe6ff614263a59ef9(x43bec302f92080b9, false, true);
                goto label_2;
            }
            while (0 != 0);
            goto label_3;
            label_6:
            return;
            label_3:
            ;
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);
            DockControl x43bec302f92080b9 = this.x37c93a224e23ba95(this.PointToClient(new System.Drawing.Point(drgevent.X, drgevent.Y)));
            if (x43bec302f92080b9 == null)
                return;
            this.xe6ff614263a59ef9(x43bec302f92080b9, true, true);
        }

        private void x79a58a5d2c65c5a4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            this.x537a4001020fd4c7.Enabled = false;
            if (8 != 0)
                goto label_10;
            else
                goto label_8;
            label_1:
            DockControl x43bec302f92080b9;
            if (x43bec302f92080b9 != null)
                goto label_5;
            label_2:
            if (0 == 0)
                return;
            label_3:
            if (0 == 0)
                return;
            else
                goto label_1;
            label_5:
            this.xe6ff614263a59ef9(x43bec302f92080b9, false, false);
            if (2 == 0)
                goto label_3;
            else
                goto label_3;
            label_8:
            if (4 != 0)
                return;
            else
                goto label_2;
            label_10:
            if (this.x297f71a96c16086c)
                return;
            x43bec302f92080b9 = this.x37c93a224e23ba95(this.PointToClient(Cursor.Position));
            if (0 == 0)
                goto label_1;
            else
                goto label_5;
        }

        private void xeccc53b32ba6b859(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            Rectangle clientRectangle = this.x5fea292ffeb2c28c.ClientRectangle;
            label_12:
            bool flag1 = clientRectangle.Contains(this.x5fea292ffeb2c28c.PointToClient(Cursor.Position));
            bool flag2 = this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));
            if (flag1)
            {
                if (((flag2 ? 1 : 0) | -2) != 0)
                    ;
            }
            else
            {
                if (flag2)
                    return;
                if (true)
                    goto label_4;
                label_1:
                if (this.x5fea292ffeb2c28c.ContainsFocus)
                {
                    if ((uint)(flag2 ? 1 : 0) - (uint)(flag1 ? 1 : 0) >= 0U)
                        return;
                    if (true)
                        goto label_12;
                }
                else
                {
                    this.xcdb145600c1b7224(false);
                    return;
                }
                label_4:
                if (this.x5fea292ffeb2c28c.x1c3de22188ea5bb2)
                    return;
                if (true)
                    goto label_1;
                else
                    goto label_12;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                goto label_6;
            label_2:
            base.Dispose(disposing);
            return;
            label_6:
            do
            {
                this.xcdb145600c1b7224(true);
                this.x537a4001020fd4c7.Tick -= new EventHandler(this.x79a58a5d2c65c5a4);
                this.x537a4001020fd4c7.Dispose();
            }
            while (false);
            this.x537a4001020fd4c7 = (Timer)null;
            this.x2076b5c9f1eb82ef.Tick -= new EventHandler(this.xeccc53b32ba6b859);
            if (true)
                goto label_5;
            label_3:
            this.x2076b5c9f1eb82ef = (Timer)null;
            if (this.x5fea292ffeb2c28c != null)
                goto label_4;
            label_1:
            this.x7fdaeb05cb5e84f3.Clear();
            goto label_2;
            label_4:
            this.x5fea292ffeb2c28c.Dispose();
            this.x5fea292ffeb2c28c = (x87cf4de36131799d)null;
            goto label_1;
            label_5:
            this.x2076b5c9f1eb82ef.Dispose();
            goto label_3;
        }

        public void xbb5f70c792fb9034(Rectangle xda73fcb97c77d998)
        {
            this.x5fea292ffeb2c28c.Invalidate(xda73fcb97c77d998);
        }

        internal class x01c0afa1afffb431 : CollectionBase
        {
            private x10ac79a4257c7f52 xb6a159a84cb992d6;

            public x01c0afa1afffb431(x10ac79a4257c7f52 parent)
            {
                this.xb6a159a84cb992d6 = parent;
            }

            public bool x263d579af1d0d43f(ControlLayoutSystem x6e150040c8d97700)
            {
                return this.List.Contains((object)x6e150040c8d97700);
            }

            protected override void OnInsertComplete(int index, object value)
            {
                ((ControlLayoutSystem)value).xa85d8c17921cc878(this.xb6a159a84cb992d6);
                this.xb6a159a84cb992d6.x7e9646eed248ed11();
            }

            protected override void OnRemoveComplete(int index, object value)
            {
                ((ControlLayoutSystem)value).xa85d8c17921cc878((x10ac79a4257c7f52)null);
                this.xb6a159a84cb992d6.x7e9646eed248ed11();
            }

            protected override void OnClearComplete()
            {
                this.xb6a159a84cb992d6.x7e9646eed248ed11();
            }

            protected override void OnClear()
            {
                foreach (ControlLayoutSystem controlLayoutSystem in (CollectionBase) this)
                    controlLayoutSystem.xa85d8c17921cc878((x10ac79a4257c7f52)null);
            }

            public int xd6b6ed77479ef68c(ControlLayoutSystem x6e150040c8d97700)
            {
                return this.List.Add((object)x6e150040c8d97700);
            }

            public void x52b190e626f65140(ControlLayoutSystem x6e150040c8d97700)
            {
                this.List.Remove((object)x6e150040c8d97700);
            }

            public ControlLayoutSystem get_xe6d4b1b411ed94b5(int xc0c4c459c6ccbd00)
            {
                return (ControlLayoutSystem)this.List[xc0c4c459c6ccbd00];
            }
        }

        private delegate void x23dc61b48e59b2f1(bool quick);
    }
}
