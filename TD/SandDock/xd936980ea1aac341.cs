using System;
using System.Drawing;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    internal class xd936980ea1aac341 : Form
    {
        private const int x7260e2e8b818e128 = 2;
        private const int xcc781840d1708149 = 165;
        private const int x07ac164555740e80 = 164;
        private const int x5898cfc7c31e0ba4 = 161;
        private const int xad2c4838c7f4b06e = 163;
        private x410f3612b9a8f9de xd3311d815ca25f02;
        private System.Drawing.Point x6afebf16b45c02e0;

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
            if (4 != 0 && this.xd3311d815ca25f02.ActiveControl != null)
            {
                if (2 == 0 || 0 == 0)
                    return;
            }
            else
                goto label_8;
            label_2:
            ControlLayoutSystem controlLayoutSystem;
            if (controlLayoutSystem == null)
                return;
            label_4:
            if (controlLayoutSystem.SelectedControl == null)
                return;
            this.xd3311d815ca25f02.ActiveControl = (Control)controlLayoutSystem.SelectedControl;
            return;
            label_8:
            controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem((DockContainer)this.xd3311d815ca25f02);
            if (4 != 0)
                goto label_2;
            else
                goto label_4;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (2 != 0)
                goto label_7;
            label_1:
            int index;
            ++index;
            label_2:
            DockControl[] x9476096be9672d38;
            if (index >= x9476096be9672d38.Length)
                return;
            DockControl dockControl = x9476096be9672d38[index];
            if ((index & 0) == 0)
            {
                if ((index & 0) != 0)
                    ;
                dockControl.FloatingSize = this.Size;
            }
            if (-2 == 0)
                return;
            else
                goto label_1;
            label_7:
            if (0 == 0 && this.xd3311d815ca25f02 == null)
                return;
            x9476096be9672d38 = this.xd3311d815ca25f02.LayoutSystem.x9476096be9672d38;
            index = 0;
            goto label_2;
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            if (2 == 0)
                ;
            while (this.xd3311d815ca25f02 != null)
            {
                DockControl[] x9476096be9672d38 = this.xd3311d815ca25f02.LayoutSystem.x9476096be9672d38;
                int index;
                for (index = 0; index < x9476096be9672d38.Length; ++index)
                    x9476096be9672d38[index].FloatingLocation = this.Location;
                if ((uint)index - (uint)index <= uint.MaxValue)
                    break;
            }
        }

        private bool x8956f13386ebab05()
        {
            if (this.xd3311d815ca25f02.HasSingleControlLayoutSystem)
            {
                ControlLayoutSystem controlLayoutSystem;
                do
                {
                    controlLayoutSystem = (ControlLayoutSystem)this.xd3311d815ca25f02.LayoutSystem.LayoutSystems[0];
                    if (controlLayoutSystem.SelectedControl != null)
                        goto label_3;
                }
                while (int.MaxValue == 0);
                goto label_4;
                label_3:
                this.xd3311d815ca25f02.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(controlLayoutSystem.SelectedControl, controlLayoutSystem.SelectedControl.PointToClient(Cursor.Position), ContextMenuContext.RightClick));
                return true;
            }
            label_4:
            return false;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.x6afebf16b45c02e0 = System.Drawing.Point.Empty;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            while (e.Button == MouseButtons.Left && this.x6afebf16b45c02e0 != System.Drawing.Point.Empty)
            {
                Rectangle rectangle = new Rectangle(this.x6afebf16b45c02e0, SystemInformation.DragSize);
                rectangle.Offset(-SystemInformation.DragSize.Width / 2, -SystemInformation.DragSize.Height / 2);
                if (rectangle.Contains(e.X, e.Y))
                    break;
                this.x6afebf16b45c02e0.Y += SystemInformation.ToolWindowCaptionHeight + SystemInformation.FrameBorderSize.Height;
                if (0 != 0)
                    ;
                this.xd3311d815ca25f02.LayoutSystem.xe9a159cd1e028df2(this.xd3311d815ca25f02.Manager, (DockContainer)this.xd3311d815ca25f02, (LayoutSystemBase)this.xd3311d815ca25f02.LayoutSystem, (DockControl)null, this.xd3311d815ca25f02.xbe0b15fe97a1ee89.MetaData.DockedContentSize, this.x6afebf16b45c02e0, this.xd3311d815ca25f02.Manager.DockingHints, this.xd3311d815ca25f02.Manager.DockingManager);
                this.xd3311d815ca25f02.x3df31cf55a47bc37 = (LayoutSystemBase)this.xd3311d815ca25f02.LayoutSystem;
                this.Capture = false;
                this.xd3311d815ca25f02.Capture = true;
                if (0 == 0)
                {
                    this.x6afebf16b45c02e0 = System.Drawing.Point.Empty;
                    if (0 == 0)
                        break;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            IntPtr num1;
            IntPtr num2;
            IntPtr wparam1;
            if (m.Msg == 161)
            {
                if ((uint)num1 - (uint)num2 <= uint.MaxValue)
                {
                    wparam1 = m.WParam;
                    if ((uint)wparam1 - (uint)num2 > uint.MaxValue)
                    {
                        if (2 != 0)
                            goto label_13;
                    }
                    else
                        goto label_5;
                }
                else
                    goto label_3;
            }
            else
                goto label_10;
            label_2:
            IntPtr wparam2;
            if (wparam2.ToInt32() == 2)
            {
                this.OnDoubleClick(EventArgs.Empty);
                m.Result = IntPtr.Zero;
                return;
            }
            else
                goto label_4;
            label_3:
            if ((uint)wparam1 + (uint)wparam1 < 0U)
                goto label_2;
            label_4:
            base.WndProc(ref m);
            return;
            label_5:
            if (wparam1.ToInt32() == 2)
                goto label_13;
            else
                goto label_3;
            label_10:
            if (m.Msg != 163)
            {
                if (m.Msg == 164)
                {
                    this.Capture = false;
                    if (this.x8956f13386ebab05())
                    {
                        m.Result = IntPtr.Zero;
                        return;
                    }
                    else
                        goto label_4;
                }
                else
                    goto label_4;
            }
            else if ((uint)num2 + (uint)num1 <= uint.MaxValue)
            {
                wparam2 = m.WParam;
                if ((uint)wparam2 - (uint)num1 >= 0U)
                    goto label_2;
            }
            else
                goto label_5;
            label_13:
            x443cc432acaadb1d.ReleaseCapture();
            this.Activate();
            this.x6afebf16b45c02e0 = this.PointToClient(Cursor.Position);
            this.Capture = true;
            m.Result = IntPtr.Zero;
        }
    }
}
