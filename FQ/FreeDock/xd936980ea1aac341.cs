using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security;

namespace FQ.FreeDock
{
    class xd936980ea1aac341 : Form
    {
        private const int HTCAPTION = 2;
        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int WM_NCLBUTTONDBLCLK = 0x00A3;
        private const int WM_NCRBUTTONDOWN = 0x00A4;
        private const int WM_NCRBUTTONUP = 0x00A5;
        private const int x7260e2e8b818e128 = 2;
        private const int xcc781840d1708149 = 165;
        private const int x07ac164555740e80 = 164;
        private const int x5898cfc7c31e0ba4 = 161;
        private const int xad2c4838c7f4b06e = 163;
        private x410f3612b9a8f9de xd3311d815ca25f02;
        private Point x6afebf16b45c02e0;

        public xd936980ea1aac341(x410f3612b9a8f9de container)
        {
            this.xd3311d815ca25f02 = container;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (this.xd3311d815ca25f02.ActiveControl != null)
                return;
            ControlLayoutSystem controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem((DockContainer)this.xd3311d815ca25f02);
            if (controlLayoutSystem == null)
                return;

            if (controlLayoutSystem.SelectedControl == null)
                return;
            this.xd3311d815ca25f02.ActiveControl = controlLayoutSystem.SelectedControl;
        }
        // reviewd!
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.xd3311d815ca25f02 != null)
            {
                DockControl[] dockControls = this.xd3311d815ca25f02.LayoutSystem.x9476096be9672d38;
                foreach (DockControl dockControl in dockControls)
                {
                    dockControl.FloatingSize = this.Size;
                }
            }
        }
        // reviewd!
        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            if (this.xd3311d815ca25f02 != null)
            {
                DockControl[] dockControls = this.xd3311d815ca25f02.LayoutSystem.x9476096be9672d38;
                foreach (DockControl dockControl in dockControls)
                {
                    dockControl.FloatingLocation = this.Location;
                }
            }
        }
        // reviewd!
        private bool x8956f13386ebab05()
        {
            if (this.xd3311d815ca25f02.HasSingleControlLayoutSystem)
            {
               ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)this.xd3311d815ca25f02.LayoutSystem.LayoutSystems[0];
                if (controlLayoutSystem.SelectedControl != null)
                {
                    // EmitShowControlContextMenu
                    this.xd3311d815ca25f02.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(controlLayoutSystem.SelectedControl, controlLayoutSystem.SelectedControl.PointToClient(Cursor.Position), ContextMenuContext.RightClick));
                    return true;
                }
            }
            return false;
        }
        // reviewd!
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.x6afebf16b45c02e0 = Point.Empty;
        }

        // reviewd!
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left && this.x6afebf16b45c02e0 != Point.Empty)
            {
                Rectangle rectangle = new Rectangle(this.x6afebf16b45c02e0, SystemInformation.DragSize);
                rectangle.Offset(-SystemInformation.DragSize.Width / 2, -SystemInformation.DragSize.Height / 2);
                if (!rectangle.Contains(e.X, e.Y))
                {
                    this.x6afebf16b45c02e0.Y += SystemInformation.ToolWindowCaptionHeight + SystemInformation.FrameBorderSize.Height;
                    this.xd3311d815ca25f02.LayoutSystem.xe9a159cd1e028df2(this.xd3311d815ca25f02.Manager, (DockContainer)this.xd3311d815ca25f02, (LayoutSystemBase)this.xd3311d815ca25f02.LayoutSystem, (DockControl)null, this.xd3311d815ca25f02.xbe0b15fe97a1ee89.MetaData.DockedContentSize, this.x6afebf16b45c02e0, this.xd3311d815ca25f02.Manager.DockingHints, this.xd3311d815ca25f02.Manager.DockingManager);
                    this.xd3311d815ca25f02.x3df31cf55a47bc37 = (LayoutSystemBase)this.xd3311d815ca25f02.LayoutSystem;
                    this.Capture = false;
                    this.xd3311d815ca25f02.Capture = true;
                    this.x6afebf16b45c02e0 = Point.Empty;
                }
            }
        }

        // reviewed!
        [SecuritySafeCritical]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCLBUTTONDOWN:
                    if (m.WParam.ToInt32() == HTCAPTION)
                    {
                        x443cc432acaadb1d.ReleaseCapture();
                        this.Activate();
                        this.x6afebf16b45c02e0 = this.PointToClient(Cursor.Position);
                        this.Capture = true;
                        m.Result = IntPtr.Zero;
                        return;
                    }
                    break;
                case WM_NCLBUTTONDBLCLK:
                    if (m.WParam.ToInt32() == HTCAPTION)
                    {
                        this.OnDoubleClick(EventArgs.Empty);
                        m.Result = IntPtr.Zero;
                        return;
                    }
                    break;
                case WM_NCRBUTTONDOWN:
                    this.Capture = false;
                    if (this.x8956f13386ebab05())
                    {
                        m.Result = IntPtr.Zero;
                        return;
                    }
                    break;
            }

            base.WndProc(ref m);
            return;
        }
    }
}
