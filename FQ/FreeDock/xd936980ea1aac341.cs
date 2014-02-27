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
        private FloatingDockContainer dockContainer;
        private Point startPoint;

        public xd936980ea1aac341(FloatingDockContainer container)
        {
            this.dockContainer = container;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (this.dockContainer.ActiveControl != null)
                return;
            ControlLayoutSystem layout = LayoutUtilities.FindControlLayoutSystem(this.dockContainer);
            if (layout == null || layout.SelectedControl == null)
                return;
            this.dockContainer.ActiveControl = layout.SelectedControl;
        }
        // reviewd!
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.dockContainer != null)
            {
                foreach (DockControl dockControl in this.dockContainer.LayoutSystem.AllControls)
                {
                    dockControl.FloatingSize = this.Size;
                }
            }
        }
        // reviewd!
        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            if (this.dockContainer != null)
            {
                foreach (DockControl dockControl in  this.dockContainer.LayoutSystem.AllControls)
                {
                    dockControl.FloatingLocation = this.Location;
                }
            }
        }
        // reviewd!
        private bool x8956f13386ebab05()
        {
            if (this.dockContainer.HasSingleControlLayoutSystem)
            {
                ControlLayoutSystem controlLayout = (ControlLayoutSystem)this.dockContainer.LayoutSystem.LayoutSystems[0];
                if (controlLayout.SelectedControl != null)
                {
                    // EmitShowControlContextMenu
                    this.dockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(controlLayout.SelectedControl, controlLayout.SelectedControl.PointToClient(Cursor.Position), ContextMenuContext.RightClick));
                    return true;
                }
            }
            return false;
        }
        // reviewd!
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.startPoint = Point.Empty;
        }
        // reviewd!
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left && this.startPoint != Point.Empty)
            {
                Rectangle rectangle = new Rectangle(this.startPoint, SystemInformation.DragSize);
                rectangle.Offset(-SystemInformation.DragSize.Width / 2, -SystemInformation.DragSize.Height / 2);
                if (!rectangle.Contains(e.X, e.Y))
                {
                    this.startPoint.Y += SystemInformation.ToolWindowCaptionHeight + SystemInformation.FrameBorderSize.Height;
                    this.dockContainer.LayoutSystem.xe9a159cd1e028df2(this.dockContainer.Manager, this.dockContainer, this.dockContainer.LayoutSystem, null, this.dockContainer.SelectedControl.MetaData.DockedContentSize, this.startPoint, this.dockContainer.Manager.DockingHints, this.dockContainer.Manager.DockingManager);
                    this.dockContainer.layout = this.dockContainer.LayoutSystem;
                    this.Capture = false;
                    this.dockContainer.Capture = true;
                    this.startPoint = Point.Empty;
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
                        this.startPoint = this.PointToClient(Cursor.Position);
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
