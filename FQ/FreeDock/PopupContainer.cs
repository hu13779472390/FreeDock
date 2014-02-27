using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using FQ.Util;

namespace FQ.FreeDock
{
    // b
    class PopupContainer : Control
    {
        private AutoHideBar autoHideBar;
        private ControlLayoutSystem layoutSystem;
        private ResizingManager x372569d2ea29984e;
        private Rectangle x21ed2ecc088ef4e4;
        private Rectangle x59f159fe47159543;
        private Tooltips tooltips;
        // reviewed with 2.4
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
                int num = value;
                if (this.Resizable)
                    num += 4;
                switch (this.autoHideBar.Dock)
                {
                    case DockStyle.Top:
                        bounds.Height = num;
                        break;
                    case DockStyle.Bottom:
                        bounds.Y = bounds.Bottom - num;
                        bounds.Height = num;
                        break;
                    case DockStyle.Left:
                        bounds.Width = num;
                        break;
                    case DockStyle.Right:
                        bounds.X = bounds.Right - num;
                        bounds.Width = num;
                        break;
                }
                this.Bounds = bounds;
                this.LayoutSystem.PopupSize = value;
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
                return this.layoutSystem;
            }
            set
            {
                this.layoutSystem = value;
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
        public PopupContainer(AutoHideBar bar)
        {
            this.autoHideBar = bar;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.tooltips = new Tooltips(this);
            this.tooltips.DropShadow = false;
            this.tooltips.GetTooltipText += new Tooltips.x58986a4a0b75e5b5(this.xa3a7472ac4e61f76);
            this.BackColor = SystemColors.Control;
        }

        private void x81dc33c66d5e1e33(Point position)
        {
            this.x372569d2ea29984e = new ResizingManager(this.autoHideBar, this, position);
            this.x372569d2ea29984e.Cancelled += new EventHandler(this.xfae511fd7c4fb447);
            this.x372569d2ea29984e.Committed += new ResizingManager.ResizingManagerFinishedEventHandler(this.xc555e814c1720baf);
        }

        private void xd5979b8834306b81()
        {
            this.x372569d2ea29984e.Cancelled -= new EventHandler(this.xfae511fd7c4fb447);
            this.x372569d2ea29984e.Committed -= new ResizingManager.ResizingManagerFinishedEventHandler(this.xc555e814c1720baf);
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
            if (this.layoutSystem == null)
                return;
            this.x21ed2ecc088ef4e4 = this.ClientRectangle;
            if (!Resizable)
            {
                this.x59f159fe47159543 = Rectangle.Empty;
            }
            else
            {
                switch (this.autoHideBar.Dock)
                {
                    case DockStyle.Top:
                        this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.X, this.x21ed2ecc088ef4e4.Bottom - 4, this.x21ed2ecc088ef4e4.Width, 4);
                        this.x21ed2ecc088ef4e4.Height -= 4;
                        break;
                    case DockStyle.Bottom:
                        this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.X, this.x21ed2ecc088ef4e4.Y, this.x21ed2ecc088ef4e4.Width, 4);
                        this.x21ed2ecc088ef4e4.Y += 4;
                        this.x21ed2ecc088ef4e4.Height -= 4;
                        break;
                    case DockStyle.Left:
                        this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Right - 4, this.x21ed2ecc088ef4e4.Y, 4, this.x21ed2ecc088ef4e4.Height);
                        this.x21ed2ecc088ef4e4.Width -= 4;
                        break;
                    case DockStyle.Right:
                        this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.X, this.x21ed2ecc088ef4e4.Y, 4, this.x21ed2ecc088ef4e4.Height);
                        this.x21ed2ecc088ef4e4.X += 4;
                        this.x21ed2ecc088ef4e4.Width -= 4;
                        break;
                    case DockStyle.None:
                        this.x59f159fe47159543 = Rectangle.Empty;
                        break;
                }
            }
            this.layoutSystem.LayoutCollapsed(this.autoHideBar.Manager.Renderer, this.x21ed2ecc088ef4e4);
            this.Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && !this.IsDisposed)
            {
                if (this.ContainsFocus && this.autoHideBar.Manager.OwnerForm != null && this.autoHideBar.Manager.OwnerForm.IsMdiContainer && this.autoHideBar.Manager.OwnerForm.ActiveMdiChild != null)
                    this.autoHideBar.Manager.OwnerForm.ActiveControl = this.autoHideBar.Manager.OwnerForm.ActiveMdiChild;
                this.autoHideBar.xcdb145600c1b7224(true);
                this.autoHideBar = null;
                this.LayoutSystem = null;
                if (this.tooltips != null)
                {
                    this.tooltips.Dispose();
                    this.tooltips = null;
                }
                if (this.x372569d2ea29984e != null)
                    this.xd5979b8834306b81();
            }
            base.Dispose(disposing);
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (this.layoutSystem == null)
                return;
            this.layoutSystem.xd541e2fc281b554b();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (this.layoutSystem == null)
                return;
            this.layoutSystem.xd541e2fc281b554b();
        }

        private string xa3a7472ac4e61f76(Point position)
        {
            if (this.x21ed2ecc088ef4e4.Contains(position) && this.layoutSystem != null)
                return this.layoutSystem.xe0e7b93bedab6c05(position);
            else
                return "";
        }
        // reviewed with 2.4
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Cursor.Current = this.x59f159fe47159543.Contains(e.X, e.Y) || this.x372569d2ea29984e == null ? (this.autoHideBar.Dock == DockStyle.Left || this.autoHideBar.Dock == DockStyle.Right ? Cursors.VSplit : Cursors.HSplit) : Cursors.Default;
            if (this.Capture && this.x372569d2ea29984e != null)
                this.x372569d2ea29984e.OnMouseMove(new Point(e.X, e.Y));
            else
            {
                if (!this.x21ed2ecc088ef4e4.Contains(e.X, e.Y) || this.layoutSystem == null)
                    return;
                this.layoutSystem.OnMouseMove(e);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (this.layoutSystem != null)
                this.layoutSystem.OnMouseLeave();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.x59f159fe47159543.Contains(e.X, e.Y) && e.Button == MouseButtons.Left)
                this.x81dc33c66d5e1e33(new Point(e.X, e.Y));
            else
            {
                if (!this.x21ed2ecc088ef4e4.Contains(e.X, e.Y) || this.layoutSystem == null)
                    return;
                this.layoutSystem.OnMouseDown(e);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (this.x372569d2ea29984e != null && e.Button == MouseButtons.Left)
                this.x372569d2ea29984e.Commit();
            else
            {
                if (!this.x21ed2ecc088ef4e4.Contains(e.X, e.Y) || this.layoutSystem == null)
                    return;
                this.layoutSystem.OnMouseUp(e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.autoHideBar.Manager.Renderer.StartRenderSession(HotkeyPrefix.None);
            if (this.layoutSystem != null)
                this.layoutSystem.x84b6f3c22477dacb(this.autoHideBar.Manager.Renderer, e.Graphics, this.Font);
            if (this.Resizable)
                this.autoHideBar.Manager.Renderer.DrawSplitter(null, this, e.Graphics, this.x59f159fe47159543, this.autoHideBar.Dock == DockStyle.Top || this.autoHideBar.Dock == DockStyle.Bottom ? Orientation.Horizontal : Orientation.Vertical);
            this.autoHideBar.Manager.Renderer.FinishRenderSession();
        }
    }
}
