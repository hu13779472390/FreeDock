using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security;

namespace FQ.FreeDock
{
    // B
    class FloatingDockContainer : DockContainer
    {
        private bool x50765ed4559630d6 = true;
        private const int x339acab5bf3e83ae = 64;
        private const int x77bf04ec211c4a37 = 16;
        private const int xdbb7427772b219d6 = 128;
        private const int x4c4ed64783077b76 = 4;
        private xd936980ea1aac341 form;
        private ControlLayoutSystem layoutSystem;
        private Guid guid;
        private const int SWP_HIDEWINDOW = 0x0080;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int SWP_NOACTIVATE = 0x0010;

        public Guid Guid
        {
            get
            {
                return this.guid;
            }
        }

        internal override bool CanShowCollapsed
        {
            get
            {
                return false;
            }
        }

        public override SplitLayoutSystem LayoutSystem
        {
            get
            {
                return base.LayoutSystem;
            }
            set
            {
                this.LayoutSystem.LayoutSystemsChanged -= new EventHandler(this.x8e9e04a70e31e166);
                base.LayoutSystem = value;
                this.LayoutSystem.LayoutSystemsChanged += new EventHandler(this.x8e9e04a70e31e166);
                this.x8e9e04a70e31e166(this.LayoutSystem, EventArgs.Empty);
            }
        }

        public override SandDockManager Manager
        {
            get
            {
                return base.Manager;
            }
            set
            {
                if (this.Manager != null && this.Manager.OwnerForm != null)
                    this.Manager.OwnerForm.RemoveOwnedForm(this.form);
                base.Manager = value;
                if (this.Manager == null || this.Manager.OwnerForm == null)
                    return;
                this.Manager.OwnerForm.AddOwnedForm(this.form);
                this.Font = new Font(this.Manager.OwnerForm.Font, this.Manager.OwnerForm.Font.Style);
            }
        }

        public Form FloatingForm
        {
            get
            {
                return this.form;
            }
        }

        public Rectangle FloatingBounds
        {
            get
            {
                return this.form.Bounds;
            }
        }

        public Size FloatingSize
        {
            get
            {
                return this.form.Size;
            }
            set
            {
                this.form.Size = value;
            }
        }

        public Point FloatingLocation
        {
            get
            {
                return this.form.Location;
            }
            set
            {
                this.form.Location = value;
            }
        }

        public override bool IsFloating
        {
            get
            {
                return true;
            }
        }

        public DockControl SelectedControl
        {
            get
            {
                ControlLayoutSystem controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem((DockContainer)this);
                if (controlLayoutSystem == null)
                    throw new InvalidOperationException("A docking operation was started while the window hierarchy is in an invalid state.");
                else
                    return controlLayoutSystem.SelectedControl;
            }
        }

        public FloatingDockContainer(SandDockManager manager, Guid guid)
        {
            if (manager == null)
                throw new ArgumentNullException("manager");
            this.form = new xd936980ea1aac341(this);
            this.form.Activated += new EventHandler(((DockContainer)this).xa2414c47d888068e);
            this.form.Deactivate += new EventHandler(((DockContainer)this).x19e788b09b195d4f);
            this.form.Closing += new CancelEventHandler(this.x9218bee68262250e);
            this.form.DoubleClick += new EventHandler(this.xe1f5f125062dc4fb);
            this.LayoutSystem.LayoutSystemsChanged += new EventHandler(this.x8e9e04a70e31e166);
            this.x8e9e04a70e31e166(this.LayoutSystem, EventArgs.Empty);
            this.Manager = manager;
            this.guid = guid;
            this.form.Controls.Add(this);
            this.Dock = DockStyle.Fill;
        }

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter, int x, int y, int cx, int cy, int flags);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.IsDisposed)
            {
                this.LayoutSystem.LayoutSystemsChanged -= new EventHandler(this.x8e9e04a70e31e166);
                this.form.Activated -= new EventHandler(((DockContainer)this).xa2414c47d888068e);
                this.form.Deactivate -= new EventHandler(((DockContainer)this).x19e788b09b195d4f);
                this.form.Closing -= new CancelEventHandler(this.x9218bee68262250e);
                this.form.DoubleClick -= new EventHandler(this.xe1f5f125062dc4fb);
                LayoutUtilities.xa7513d57b4844d46((Control)this);
                this.form.Dispose();
            }
            base.Dispose(disposing);
        }

        public void x35579b297303ed43()
        {
            this.form.Show();
        }

        public void x5486e0b5e830d25c()
        {
            this.form.Hide();
        }

        [SecuritySafeCritical]
        public void x159713d3b60fae0c(Rectangle bounds, bool visible, bool active)
        {
            int flags = 0;
            flags |= visible ? SWP_SHOWWINDOW : SWP_HIDEWINDOW;
            if (!active)
                flags |= SWP_NOACTIVATE;
            IntPtr handle = IntPtr.Zero;
            // FIXME:edit here
//            x410f3612b9a8f9de.SetWindowPos(new HandleRef(this, this.form.Handle), new HandleRef(this, handle), xda73fcb97c77d998.X, xda73fcb97c77d998.Y, xda73fcb97c77d998.Width, xda73fcb97c77d998.Height, flags);
            this.form.Bounds = bounds; 
            this.form.Visible = visible;
            if (!visible)
                return;
            foreach (Control control in this.form.Controls)
                control.Visible = true;
        }

        private void xe20c835979d60df8(DockControl x321bff1c322e5433, DockControl x31b34ee91c89cf69)
        {
            if (x31b34ee91c89cf69 != null)
                this.form.Text = x31b34ee91c89cf69.Text;
            else
                this.form.Text = "";
        }

        public void xd1bdd0ee5924b59e()
        {
            this.x8e9e04a70e31e166(null, null);
        }
        // reviewd
        private void x8e9e04a70e31e166(object sender, EventArgs e)
        {
            if (this.layoutSystem != null)
                this.layoutSystem.SelectedControlChanged -= new ControlLayoutSystem.SelectionChangedEventHandler(this.xe20c835979d60df8);
            if (this.HasSingleControlLayoutSystem)
            {
                this.layoutSystem = (ControlLayoutSystem)this.LayoutSystem.LayoutSystems[0];
                this.layoutSystem.SelectedControlChanged += new ControlLayoutSystem.SelectionChangedEventHandler(this.xe20c835979d60df8);
                this.xe20c835979d60df8(null, this.layoutSystem.SelectedControl);          
            }
            else
            {
                this.form.Text = "";
                this.layoutSystem = null;
            }
        }

        private void x9218bee68262250e(object sender, CancelEventArgs e)
        {
            if (!this.x50765ed4559630d6)
                return;

            DockControl[] allControls = this.LayoutSystem.AllControls;
            foreach (DockControl dockControl in allControls)
            {
                if (!dockControl.AllowClose)
                {
                    e.Cancel = true;
                    return;
                }
            }
            foreach (DockControl dockControl in allControls)
            {
                if (!dockControl.Close())
                {
                    e.Cancel = true;
                    break;
                }
            }
        }
        // reviewed
        private void xe1f5f125062dc4fb(object sender, EventArgs e)
        {
            Form activeForm = Form.ActiveForm;
            Form xd936980ea1aac341 = this.FloatingForm;
            DockControl[] x9476096be9672d38 = this.LayoutSystem.AllControls;
            DockControl xbe0b15fe97a1ee89 = this.SelectedControl;
            if (x9476096be9672d38[0].MetaData.LastFixedDockSituation == DockSituation.Docked && !this.LayoutSystem.AllowDock(xbe0b15fe97a1ee89.MetaData.LastFixedDockSide))
                return;
            if (x9476096be9672d38[0].MetaData.LastFixedDockSituation != DockSituation.Document || this.LayoutSystem.AllowDock(ContainerDockLocation.Center))
            {
                SandDockManager manager = this.Manager;
                this.LayoutSystem = new SplitLayoutSystem();
                base.Dispose();
                if (xbe0b15fe97a1ee89.MetaData.LastFixedDockSituation != DockSituation.Docked)
                    x9476096be9672d38[0].OpenDocument(WindowOpenMethod.OnScreenActivate);
                else
                    x9476096be9672d38[0].OpenDocked(WindowOpenMethod.OnScreenActivate);
                DockControl[] controls = new DockControl[x9476096be9672d38.Length - 1];
                Array.Copy((Array)x9476096be9672d38, 1, (Array)controls, 0, x9476096be9672d38.Length - 1);
                x9476096be9672d38[0].LayoutSystem.Controls.AddRange(controls);
                x9476096be9672d38[0].LayoutSystem.SelectedControl = xbe0b15fe97a1ee89;
            }
        }

        internal void x5b7f6ddd07ded8cd()
        {
            this.form.Activate();
        }
    }
}
