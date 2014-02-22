using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using FQ.Util;

namespace FQ.FreeDock
{
    class x87cf4de36131799d : Control
    {
        private AutoHideBar autoHideBar;
        private ControlLayoutSystem x6e150040c8d97700;
        private x7fc004d490c8a431 x372569d2ea29984e;
        private Rectangle x21ed2ecc088ef4e4;
        private Rectangle x59f159fe47159543;
        private Tooltips xac1c850120b1f254;

        public int PopupSize
        {
            get
            {
                if (this.autoHideBar.Dock == DockStyle.Left || this.autoHideBar.Dock == DockStyle.Right)
                    return this.x21ed2ecc088ef4e4.Width;
                else
                    return this.x21ed2ecc088ef4e4.Height;
            }
            set
            {
                Rectangle bounds = this.Bounds;
                if ((uint)value >= 0U)
                    goto label_14;
                label_1:
                int num;


                this.Bounds = bounds;


                this.LayoutSystem.PopupSize = value;
                return;
                label_14:
                do
                {
                    num = value;
                    do
                    {
                        if (!this.Resizable)
                        {
                            while ((uint)value <= uint.MaxValue && (value | -2) != 0)
                            {
                                if (0 != 0)
                                {
                                    if ((num | 4) != 0)
                                        goto label_5;
                                }
                                else
                                    goto label_9;
                            }
                        }
                        else
                            goto label_15;
                        label_12:
                        continue;
                        label_15:
                        num += 4;
                        goto label_12;
                    }
                    while (0 != 0);
                    label_9:
                    switch (this.autoHideBar.Dock)
                    {
                        case DockStyle.Top:
                            goto label_5;
                        case DockStyle.Bottom:
                            goto label_3;
                        case DockStyle.Left:
                            goto label_7;
                        case DockStyle.Right:
                            bounds.X = bounds.Right - num;
                            bounds.Width = num;
                            continue;
                        default:
                            goto label_1;
                    }
                }
                while ((uint)value - (uint)num < 0U);
                goto label_16;
                label_3:
                bounds.Y = bounds.Bottom - num;
                bounds.Height = num;
                goto label_1;
                label_5:
                bounds.Height = num;
                goto label_1;
                label_7:
                bounds.Width = num;
                goto label_1;
                label_16:
                if ((uint)num - (uint)num >= 0U)
                    goto label_1;
            }
        }

        public bool IsSplitting
        {
            get
            {
                return this.x372569d2ea29984e != null;
            }
        }

        public ControlLayoutSystem LayoutSystem
        {
            get
            {
                return this.x6e150040c8d97700;
            }
            set
            {
                this.x6e150040c8d97700 = value;
                this.PerformLayout();
            }
        }

        private bool Resizable
        {
            get
            {
                return this.autoHideBar.Manager.AllowDockContainerResize;
            }
        }
        // reviewed with 2.4
        public x87cf4de36131799d(AutoHideBar bar)
        {
            this.autoHideBar = bar;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.xac1c850120b1f254 = new Tooltips(this);
            this.xac1c850120b1f254.DropShadow = false;
            this.xac1c850120b1f254.GetTooltipText += new Tooltips.x58986a4a0b75e5b5(this.xa3a7472ac4e61f76);
            this.BackColor = SystemColors.Control;
        }

        private void x81dc33c66d5e1e33(System.Drawing.Point xcb09bd0cee4909a3)
        {
            this.x372569d2ea29984e = new x7fc004d490c8a431(this.autoHideBar, this, xcb09bd0cee4909a3);
            this.x372569d2ea29984e.Cancelled += new EventHandler(this.xfae511fd7c4fb447);
            this.x372569d2ea29984e.Committed += new x7fc004d490c8a431.ResizingManagerFinishedEventHandler(this.xc555e814c1720baf);
        }

        private void xd5979b8834306b81()
        {
            this.x372569d2ea29984e.Cancelled -= new EventHandler(this.xfae511fd7c4fb447);
            this.x372569d2ea29984e.Committed -= new x7fc004d490c8a431.ResizingManagerFinishedEventHandler(this.xc555e814c1720baf);
            this.x372569d2ea29984e = null;
        }

        private void xfae511fd7c4fb447(object sender, EventArgs e)
        {
            this.xd5979b8834306b81();
        }

        private void xc555e814c1720baf(int x0d4b3b88c5b24565)
        {
            this.xd5979b8834306b81();
            this.PopupSize = x0d4b3b88c5b24565;
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            if (this.x6e150040c8d97700 == null)
                return;
            this.x21ed2ecc088ef4e4 = this.ClientRectangle;
            if (0 == 0 && !this.Resizable)
                this.x59f159fe47159543 = Rectangle.Empty;
            else
                goto label_10;
            label_3:
            this.x6e150040c8d97700.LayoutCollapsed(this.autoHideBar.Manager.Renderer, this.x21ed2ecc088ef4e4);
            if ((int)byte.MaxValue == 0)
                return;
            this.Invalidate();
            return;
            label_10:
            switch (this.autoHideBar.Dock)
            {
                case DockStyle.Top:
                    this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.X, this.x21ed2ecc088ef4e4.Bottom - 4, this.x21ed2ecc088ef4e4.Width, 4);
                    this.x21ed2ecc088ef4e4.Height -= 4;
                    if (4 == 0 || 0 != 0)
                        goto case DockStyle.Right;
                    else
                        goto label_3;
                case DockStyle.Bottom:
                    this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.X, this.x21ed2ecc088ef4e4.Y, this.x21ed2ecc088ef4e4.Width, 4);
                    if (0 == 0)
                    {
                        this.x21ed2ecc088ef4e4.Y += 4;
                        this.x21ed2ecc088ef4e4.Height -= 4;
                        goto label_3;
                    }
                    else
                        break;
                case DockStyle.Left:
                    this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Right - 4, this.x21ed2ecc088ef4e4.Y, 4, this.x21ed2ecc088ef4e4.Height);
                    this.x21ed2ecc088ef4e4.Width -= 4;
                    if (0 != 0)
                        goto label_3;
                    else
                        goto label_3;
                case DockStyle.Right:
                    this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.X, this.x21ed2ecc088ef4e4.Y, 4, this.x21ed2ecc088ef4e4.Height);
                    this.x21ed2ecc088ef4e4.X += 4;
                    this.x21ed2ecc088ef4e4.Width -= 4;
                    goto label_3;
            }
            this.x59f159fe47159543 = Rectangle.Empty;
            goto label_3;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                goto label_22;
            label_4:
            base.Dispose(disposing);
            return;
            label_22:
            while (!this.IsDisposed)
            {
                label_16:
                if (1 != 0)
                    goto label_14;
                else
                    goto label_15;
                label_2:
                if (this.x372569d2ea29984e != null)
                {
                    this.xd5979b8834306b81();
                    break;
                }
                else if ((int)byte.MaxValue == 0)
                    goto label_8;
                else
                    break;
                label_6:
                this.xac1c850120b1f254 = null;
                goto label_2;
                label_8:
                if (int.MaxValue != 0)
                {
                    if (0 != 0)
                        goto label_6;
                }
                else
                    goto label_14;
                label_10:
                this.autoHideBar.xcdb145600c1b7224(true);
                this.autoHideBar = (AutoHideBar)null;
                label_11:
                this.LayoutSystem = (ControlLayoutSystem)null;
                if (this.xac1c850120b1f254 != null)
                {
                    this.xac1c850120b1f254.Dispose();
                    goto label_6;
                }
                else if (4 != 0)
                {
                    if (0 != 0)
                    {
//                        if ((uint)disposing - (uint)disposing >= 0U)
                        continue;
//                        else
//                            goto label_16;
                    }
                    else
                        goto label_2;
                }
                else
                    goto label_8;
                label_14:
                if (!this.ContainsFocus)
                    goto label_10;
                label_15:
                if (this.autoHideBar.Manager.OwnerForm != null && this.autoHideBar.Manager.OwnerForm.IsMdiContainer)
                {
                    if (0 == 0)
                    {
                        if (this.autoHideBar.Manager.OwnerForm.ActiveMdiChild != null)
                        {
                            this.autoHideBar.Manager.OwnerForm.ActiveControl = (Control)this.autoHideBar.Manager.OwnerForm.ActiveMdiChild;
//                            if ((uint)disposing - (uint)disposing < 0U)
//                            {
//                                if (((disposing ? 1 : 0) & 0) != 0)
//                                {
//                                    if (0 == 0)
//                                    {
//                                        if ((uint)disposing <= uint.MaxValue)
//                                            goto label_8;
//                                        else
//                                            goto label_2;
//                                    }
//                                }
//                                else
//                                    goto label_14;
//                            }
//                            else
                            goto label_8;
                        }
                        else
                            goto label_10;
                    }
                    else
                        goto label_11;
                }
                else
                    goto label_10;
            }
            goto label_4;
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (this.x6e150040c8d97700 == null)
                return;
            this.x6e150040c8d97700.xd541e2fc281b554b();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (this.x6e150040c8d97700 == null)
                return;
            this.x6e150040c8d97700.xd541e2fc281b554b();
        }

        private string xa3a7472ac4e61f76(System.Drawing.Point xb9c2cfae130d9256)
        {
            if (this.x21ed2ecc088ef4e4.Contains(xb9c2cfae130d9256) && this.x6e150040c8d97700 != null)
                return this.x6e150040c8d97700.xe0e7b93bedab6c05(xb9c2cfae130d9256);
            else
                return "";
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (int.MinValue != 0)
                goto label_17;
            else
                goto label_15;
            label_8:
            while (this.Capture)
            {
                if (0 != 0)
                {
                    if (-2 != 0)
                    {
                        if (0 != 0)
                        {
                            if (0 == 0)
                                goto label_15;
                            else
                                break;
                        }
                        else if (0 != 0)
                            return;
                        else
                            goto label_7;
                    }
                }
                else
                    goto label_3;
            }
            label_1:
            if (this.x21ed2ecc088ef4e4.Contains(e.X, e.Y))
            {
                if (this.x6e150040c8d97700 == null)
                    return;
                this.x6e150040c8d97700.OnMouseMove(e);
                if ((int)byte.MaxValue != 0)
                    return;
            }
            if (2 != 0)
                return;
            else
                goto label_7;
            label_3:
            if (this.x372569d2ea29984e != null)
            {
                this.x372569d2ea29984e.OnMouseMove(new System.Drawing.Point(e.X, e.Y));
                if (int.MaxValue != 0)
                    return;
                else
                    goto label_15;
            }
            else
                goto label_1;
            label_7:
            if (0 != 0)
                goto label_3;
            else
                goto label_3;
            label_15:
            if (this.x372569d2ea29984e == null)
            {
                Cursor.Current = Cursors.Default;
                goto label_8;
            }
            else
                goto label_25;
            label_17:
            if (!this.x59f159fe47159543.Contains(e.X, e.Y))
            {
                if (1 != 0)
                    goto label_15;
            }
            else
                goto label_25;
            label_19:
            Cursor.Current = Cursors.VSplit;
            goto label_8;
            label_25:
            if (this.autoHideBar.Dock != DockStyle.Left && this.autoHideBar.Dock != DockStyle.Right)
            {
                if (0 == 0)
                {
                    Cursor.Current = Cursors.HSplit;
                    goto label_8;
                }
                else
                    goto label_15;
            }
            else
                goto label_19;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (this.x6e150040c8d97700 == null)
                return;
            this.x6e150040c8d97700.OnMouseLeave();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            label_16:
            do
            {
                if (0 == 0)
                    goto label_6;
                label_3:
                if (this.x6e150040c8d97700 == null)
                    continue;
                else
                    goto label_2;
                label_6:
                if (this.x59f159fe47159543.Contains(e.X, e.Y))
                {
                    if (e.Button != MouseButtons.Left)
                    {
                        if (0 == 0)
                            goto label_10;
                    }
                    else
                        goto label_17;
                }
                else
                    goto label_10;
                label_9:
                if (-2 == 0)
                    goto label_6;
                label_10:
                do
                {
                    if (this.x21ed2ecc088ef4e4.Contains(e.X, e.Y))
                    {
                        if (0 == 0)
                        {
                            if (-1 != 0)
                            {
                                if (2 == 0)
                                    goto label_5;
                            }
                            else
                                goto label_16;
                        }
                        else
                            goto label_12;
                    }
                    else
                        goto label_13;
                }
                while (0 != 0);
                goto label_3;
                label_12:
                if (8 == 0)
                    goto label_9;
                else
                    goto label_9;
            }
            while (3 == 0);
            goto label_14;
            label_2:
            this.x6e150040c8d97700.OnMouseDown(e);
            return;
            label_14:
            return;
            label_13:
            return;
            label_17:
            this.x81dc33c66d5e1e33(new System.Drawing.Point(e.X, e.Y));
            return;
            label_5:
            ;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            while (this.x372569d2ea29984e == null || e.Button != MouseButtons.Left)
            {
                label_7:
                while (this.x21ed2ecc088ef4e4.Contains(e.X, e.Y))
                {
                    if (this.x6e150040c8d97700 == null)
                        return;
                    this.x6e150040c8d97700.OnMouseUp(e);
                    if (0 == 0)
                    {
                        if (3 != 0)
                            goto label_2;
                    }
                    else
                        break;
                }
                goto label_3;
                label_2:
                if (1 == 0)
                    goto label_7;
                else
                    goto label_4;
                label_3:
                if (0 == 0)
                {
                    if (int.MinValue != 0)
                    {
                        if (-1 != 0)
                            return;
                        else
                            continue;
                    }
                }
                else
                    goto label_2;
                label_4:
                if (0 == 0)
                    return;
                else
                    goto label_3;
            }
            this.x372569d2ea29984e.Commit();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.autoHideBar.Manager.Renderer.StartRenderSession(HotkeyPrefix.None);
            if (0 == 0)
                goto label_8;
            label_1:
            if (0 != 0)
                return;
            label_2:
            if (this.Resizable)
                goto label_7;
            label_3:
            this.autoHideBar.Manager.Renderer.FinishRenderSession();
            if (0 == 0)
                return;
            else
                goto label_8;
            label_7:
            this.autoHideBar.Manager.Renderer.DrawSplitter((Control)null, (Control)this, e.Graphics, this.x59f159fe47159543, this.autoHideBar.Dock == DockStyle.Top || this.autoHideBar.Dock == DockStyle.Bottom ? Orientation.Horizontal : Orientation.Vertical);
            goto label_3;
            label_8:
            if (-2 != 0)
                goto label_5;
            else
                goto label_9;
            label_4:
            this.x6e150040c8d97700.x84b6f3c22477dacb(this.autoHideBar.Manager.Renderer, e.Graphics, this.Font);
            goto label_2;
            label_5:
            if (this.x6e150040c8d97700 != null)
                goto label_4;
            else
                goto label_2;
            label_9:
            if (0 == 0)
                goto label_4;
            else
                goto label_1;
        }
    }
}
