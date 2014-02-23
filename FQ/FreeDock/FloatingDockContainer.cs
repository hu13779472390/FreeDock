using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security;

namespace FQ.FreeDock
{
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
                this.x8e9e04a70e31e166((object)this.LayoutSystem, EventArgs.Empty);
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
                if (this.Manager == null)
                    goto label_8;
                else
                    goto label_10;
                label_1:
                if (this.Manager == null)
                    return;
                if (this.Manager.OwnerForm == null)
                {
                    if (0 == 0)
                        return;
                    else
                        goto label_10;
                }
                else
                {
                    this.Manager.OwnerForm.AddOwnedForm((Form)this.form);
                    if (3 != 0)
                    {
                        this.Font = new Font(this.Manager.OwnerForm.Font, this.Manager.OwnerForm.Font.Style);
                        return;
                    }
                }
                label_6:
                if (this.Manager.OwnerForm == null)
                {
                    if (0 != 0)
                        goto label_1;
                }
                else
                    goto label_11;
                label_8:
                base.Manager = value;
                goto label_1;
                label_10:
                if (0 == 0)
                    goto label_6;
                label_11:
                this.Manager.OwnerForm.RemoveOwnedForm((Form)this.form);
                goto label_8;
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
                if ((0 == 0 || 0 != 0 || -1 == 0) && controlLayoutSystem == null)
                    throw new InvalidOperationException("A docking operation was started while the window hierarchy is in an invalid state.");
                else
                    return controlLayoutSystem.SelectedControl;
            }
        }

        public FloatingDockContainer(SandDockManager manager, Guid guid)
        {
            if (0 != 0)
            {
                if (1 != 0)
                    goto label_6;
                else
                    goto label_5;
            }
            else
                goto label_10;
            label_2:
            if (-1 != 0)
            {
                this.form.Controls.Add((Control)this);
                this.Dock = DockStyle.Fill;
                goto label_9;
            }
            else
                goto label_10;
            label_5:
            this.form.Deactivate += new EventHandler(((DockContainer)this).x19e788b09b195d4f);
            if (1 != 0)
            {
                this.form.Closing += new CancelEventHandler(this.x9218bee68262250e);
                this.form.DoubleClick += new EventHandler(this.xe1f5f125062dc4fb);
                this.LayoutSystem.LayoutSystemsChanged += new EventHandler(this.x8e9e04a70e31e166);
                this.x8e9e04a70e31e166((object)this.LayoutSystem, EventArgs.Empty);
                this.Manager = manager;
                this.guid = guid;
                goto label_2;
            }
            else
                goto label_9;
            label_6:
            throw new ArgumentNullException("manager");
            label_9:
            if (0 == 0)
                return;
            label_10:
            if (manager != null)
            {
                this.form = new xd936980ea1aac341(this);
                this.form.Activated += new EventHandler(((DockContainer)this).xa2414c47d888068e);
                if (int.MinValue != 0)
                {
                    if (int.MaxValue != 0)
                        goto label_5;
                    else
                        goto label_9;
                }
                else
                    goto label_2;
            }
            else
                goto label_6;
        }

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter, int x, int y, int cx, int cy, int flags);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.IsDisposed)
                {
                    goto label_3;
                }
                else
                    goto label_5;
                label_4:
                this.form.Deactivate -= new EventHandler(((DockContainer)this).x19e788b09b195d4f);
                this.form.Closing -= new CancelEventHandler(this.x9218bee68262250e);
                this.form.DoubleClick -= new EventHandler(this.xe1f5f125062dc4fb);
                LayoutUtilities.xa7513d57b4844d46((Control)this);
                this.form.Dispose();
                goto label_3;
                label_5:
                this.LayoutSystem.LayoutSystemsChanged -= new EventHandler(this.x8e9e04a70e31e166);
                this.form.Activated -= new EventHandler(((DockContainer)this).xa2414c47d888068e);
                goto label_4;
            }
            label_3:
            base.Dispose(disposing);
        }

        public void x35579b297303ed43()
        {
            ((Control)this.form).Show();
        }

        public void x5486e0b5e830d25c()
        {
            this.form.Hide();
        }

        [SecuritySafeCritical]
        public void x159713d3b60fae0c(Rectangle xda73fcb97c77d998, bool x789c645a15deb49b, bool x17cc8f73454a0462)
        {
            int flags = 0;
            if (0 != 0)
                ;
            label_12:
            if (x789c645a15deb49b)
                goto label_16;
            else
                goto label_13;
            label_10:
            IntPtr handle;


            if (!x17cc8f73454a0462)
                goto label_14;
            label_11:
            handle = IntPtr.Zero;
            goto label_15;
            label_14:
            flags |= SWP_NOACTIVATE;
 
            goto label_11;
            label_15:
            if ((uint)flags >= 0U)
            {
                if (0 != 0)
                    goto label_17;
            }
            else
                goto label_12;

            // FIXME:edit here
//            x410f3612b9a8f9de.SetWindowPos(new HandleRef(this, this.form.Handle), new HandleRef(this, handle), xda73fcb97c77d998.X, xda73fcb97c77d998.Y, xda73fcb97c77d998.Width, xda73fcb97c77d998.Height, flags);
            this.form.Bounds = xda73fcb97c77d998; 

            this.form.Visible = x789c645a15deb49b;
            if (!x789c645a15deb49b)
                return;
            IEnumerator enumerator = this.form.Controls.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                    ((Control)enumerator.Current).Visible = true;
                return;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (((x17cc8f73454a0462 ? 1 : 0) & 0) != 0 || disposable != null)
                    disposable.Dispose();
            }
            label_17:
            return;
            label_13:
            flags |= SWP_HIDEWINDOW;
            goto label_10;
            label_16:
            flags |= SWP_SHOWWINDOW;
            goto label_10;
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
            this.x8e9e04a70e31e166(null, (EventArgs)null);
        }

        // reviewd
        private void x8e9e04a70e31e166(object sender, EventArgs e)
        {
            if (this.layoutSystem != null)
            {
                this.layoutSystem.SelectedControlChanged -= new ControlLayoutSystem.SelectionChangedEventHandler(this.xe20c835979d60df8);
            }

            if (this.HasSingleControlLayoutSystem)
            {
                this.layoutSystem = (ControlLayoutSystem)this.LayoutSystem.LayoutSystems[0];
                this.layoutSystem.SelectedControlChanged += new ControlLayoutSystem.SelectionChangedEventHandler(this.xe20c835979d60df8);
                this.xe20c835979d60df8(null, this.layoutSystem.SelectedControl);          
            }
            this.form.Text = "";
            this.layoutSystem = null;
            return;
        }

        private void x9218bee68262250e(object sender, CancelEventArgs e)
        {
            if (!this.x50765ed4559630d6)
                return;
            int index1;
            int index2;
            do
            {
                DockControl[] x9476096be9672d38 = this.LayoutSystem.AllControls;
                DockControl[] dockControlArray1 = x9476096be9672d38;
                index2 = 0;
                if ((index2 | 4) != 0)
                    goto label_7;
                label_6:
                ++index2;
                label_7:
                if (index2 >= dockControlArray1.Length)
                {
                    DockControl[] dockControlArray2 = x9476096be9672d38;
                    index1 = 0;
                    while (true)
                    {
                        if (index1 < dockControlArray2.Length)
                        {
                            do
                            {
                                if (!dockControlArray2[index1].Close())
                                {
                                    if ((index1 | 4) != 0)
                                        goto label_16;
                                }
                                else
                                    goto label_2;
                            }
                            while ((uint)index1 + (uint)index2 < 0U);
                            break;
                            label_2:
                            ++index1;
                        }
                        else
                            goto label_15;
                    }
                    if ((uint)index2 + (uint)index1 > uint.MaxValue)
                        goto label_10;
                }
                DockControl dockControl = dockControlArray1[index2];


                if (dockControl.AllowClose)
                    goto label_6;
                else
                    goto label_5;
                             
                label_16:
                ;
            }
            while ((uint)index2 - (uint)index1 > uint.MaxValue);
            e.Cancel = true;
            return;
            label_15:
            return;
            label_5:
            e.Cancel = true;
            return;
            label_10:
            ;
        }

        private void xe1f5f125062dc4fb(object sender, EventArgs e)
        {
            Form activeForm = Form.ActiveForm;
            label_15:
            Form xd936980ea1aac341 = this.FloatingForm;
            DockControl[] x9476096be9672d38 = this.LayoutSystem.AllControls;
            DockControl xbe0b15fe97a1ee89 = this.SelectedControl;
            if (x9476096be9672d38[0].MetaData.LastFixedDockSituation == DockSituation.Docked && !this.LayoutSystem.xe302f2203dc14a18(xbe0b15fe97a1ee89.MetaData.LastFixedDockSide))
                return;
            label_10:
            while (x9476096be9672d38[0].MetaData.LastFixedDockSituation != DockSituation.Document || this.LayoutSystem.xe302f2203dc14a18(ContainerDockLocation.Center))
            {
                label_8:
                do
                {
                    SandDockManager manager = this.Manager;
                    if (0 == 0)
                        goto label_9;
                    label_3:
                    if (xbe0b15fe97a1ee89.MetaData.LastFixedDockSituation != DockSituation.Docked)
                        x9476096be9672d38[0].OpenDocument(WindowOpenMethod.OnScreenActivate);
                    else
                        goto label_4;
                    label_2:
                    DockControl[] controls = new DockControl[x9476096be9672d38.Length - 1];
                    Array.Copy((Array)x9476096be9672d38, 1, (Array)controls, 0, x9476096be9672d38.Length - 1);
                    x9476096be9672d38[0].LayoutSystem.Controls.AddRange(controls);
                    x9476096be9672d38[0].LayoutSystem.SelectedControl = xbe0b15fe97a1ee89;
                    continue;
                    label_4:
                    if (0 == 0)
                    {
                        if (int.MaxValue != 0)
                        {
                            x9476096be9672d38[0].OpenDocked(WindowOpenMethod.OnScreenActivate);
                            if (-2 != 0)
                            {
                                if (0 == 0)
                                    goto label_2;
                                else
                                    goto label_16;
                            }
                            else
                                goto label_7;
                        }
                        else
                            goto label_10;
                    }
                    else
                        goto label_15;
                    label_9:
                    this.LayoutSystem = new SplitLayoutSystem();
                    base.Dispose();
                    goto label_3;
                }
                while (0 != 0);
                break;
                label_7:
                if (2 == 0)
                    continue;
                else
                    goto label_8;
                label_16:
                break;
            }
        }

        internal void x5b7f6ddd07ded8cd()
        {
            this.form.Activate();
        }
    }
}
