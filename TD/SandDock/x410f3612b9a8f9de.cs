// Type: TD.SandDock.x410f3612b9a8f9de
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FQ.FreeDock
{
  internal class x410f3612b9a8f9de : DockContainer
  {
    private bool x50765ed4559630d6 = true;
    private const int x339acab5bf3e83ae = 64;
    private const int x77bf04ec211c4a37 = 16;
    private const int xdbb7427772b219d6 = 128;
    private const int x4c4ed64783077b76 = 4;
    private xd936980ea1aac341 xa6607dfd4b3038ad;
    private ControlLayoutSystem x6fd7c9ad69859c3e;
    private Guid xb51cd75f17ace1ec;

    public Guid x0217cda8370c1f17
    {
      get
      {
        return this.xb51cd75f17ace1ec;
      }
    }

    internal override bool x0c2484ccd29b8358
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
        this.LayoutSystem.x7e9646eed248ed11 -= new EventHandler(this.x8e9e04a70e31e166);
        base.LayoutSystem = value;
        this.LayoutSystem.x7e9646eed248ed11 += new EventHandler(this.x8e9e04a70e31e166);
        this.x8e9e04a70e31e166((object) this.LayoutSystem, EventArgs.Empty);
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
          this.Manager.OwnerForm.AddOwnedForm((Form) this.xa6607dfd4b3038ad);
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
        this.Manager.OwnerForm.RemoveOwnedForm((Form) this.xa6607dfd4b3038ad);
        goto label_8;
      }
    }

    public Form xd936980ea1aac341
    {
      get
      {
        return (Form) this.xa6607dfd4b3038ad;
      }
    }

    public Rectangle x5de6fa99acd93adb
    {
      get
      {
        return this.xa6607dfd4b3038ad.Bounds;
      }
    }

    public System.Drawing.Size xb1090c5821a633b5
    {
      get
      {
        return this.xa6607dfd4b3038ad.Size;
      }
      set
      {
        this.xa6607dfd4b3038ad.Size = value;
      }
    }

    public System.Drawing.Point x12992900724b93dc
    {
      get
      {
        return this.xa6607dfd4b3038ad.Location;
      }
      set
      {
        this.xa6607dfd4b3038ad.Location = value;
      }
    }

    public override bool IsFloating
    {
      get
      {
        return true;
      }
    }

    public DockControl xbe0b15fe97a1ee89
    {
      get
      {
        ControlLayoutSystem controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem((DockContainer) this);
        if ((0 == 0 || 0 != 0 || -1 == 0) && controlLayoutSystem == null)
          throw new InvalidOperationException("A docking operation was started while the window hierarchy is in an invalid state.");
        else
          return controlLayoutSystem.SelectedControl;
      }
    }

    public x410f3612b9a8f9de(SandDockManager manager, Guid guid)
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
        this.xa6607dfd4b3038ad.Controls.Add((Control) this);
        this.Dock = DockStyle.Fill;
        goto label_9;
      }
      else
        goto label_10;
label_5:
      this.xa6607dfd4b3038ad.Deactivate += new EventHandler(((DockContainer) this).x19e788b09b195d4f);
      if (1 != 0)
      {
        this.xa6607dfd4b3038ad.Closing += new CancelEventHandler(this.x9218bee68262250e);
        this.xa6607dfd4b3038ad.DoubleClick += new EventHandler(this.xe1f5f125062dc4fb);
        this.LayoutSystem.x7e9646eed248ed11 += new EventHandler(this.x8e9e04a70e31e166);
        this.x8e9e04a70e31e166((object) this.LayoutSystem, EventArgs.Empty);
        this.Manager = manager;
        this.xb51cd75f17ace1ec = guid;
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
        this.xa6607dfd4b3038ad = new xd936980ea1aac341(this);
        this.xa6607dfd4b3038ad.Activated += new EventHandler(((DockContainer) this).xa2414c47d888068e);
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
          if ((uint) disposing >= 0U)
            goto label_3;
        }
        else
          goto label_5;
label_4:
        this.xa6607dfd4b3038ad.Deactivate -= new EventHandler(((DockContainer) this).x19e788b09b195d4f);
        this.xa6607dfd4b3038ad.Closing -= new CancelEventHandler(this.x9218bee68262250e);
        this.xa6607dfd4b3038ad.DoubleClick -= new EventHandler(this.xe1f5f125062dc4fb);
        LayoutUtilities.xa7513d57b4844d46((Control) this);
        this.xa6607dfd4b3038ad.Dispose();
        goto label_3;
label_5:
        this.LayoutSystem.x7e9646eed248ed11 -= new EventHandler(this.x8e9e04a70e31e166);
        this.xa6607dfd4b3038ad.Activated -= new EventHandler(((DockContainer) this).xa2414c47d888068e);
        goto label_4;
      }
label_3:
      base.Dispose(disposing);
    }

    public void x35579b297303ed43()
    {
      ((Control) this.xa6607dfd4b3038ad).Show();
    }

    public void x5486e0b5e830d25c()
    {
      this.xa6607dfd4b3038ad.Hide();
    }

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
      do
      {
        if (!x17cc8f73454a0462)
          goto label_14;
label_11:
        handle = IntPtr.Zero;
        goto label_15;
label_14:
        flags |= 16;
        if ((uint) x17cc8f73454a0462 - (uint) x17cc8f73454a0462 <= uint.MaxValue)
          goto label_11;
label_15:
        if ((uint) flags >= 0U)
        {
          if (0 != 0)
            goto label_17;
        }
        else
          goto label_12;
      }
      while ((uint) x17cc8f73454a0462 < 0U);
      x410f3612b9a8f9de.SetWindowPos(new HandleRef((object) this, this.xa6607dfd4b3038ad.Handle), new HandleRef((object) this, handle), xda73fcb97c77d998.X, xda73fcb97c77d998.Y, xda73fcb97c77d998.Width, xda73fcb97c77d998.Height, flags);
      this.xa6607dfd4b3038ad.Visible = x789c645a15deb49b;
      if (!x789c645a15deb49b)
        return;
      IEnumerator enumerator = this.xa6607dfd4b3038ad.Controls.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
          ((Control) enumerator.Current).Visible = true;
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
      flags |= 128;
      goto label_10;
label_16:
      flags |= 64;
      goto label_10;
    }

    private void xe20c835979d60df8(DockControl x321bff1c322e5433, DockControl x31b34ee91c89cf69)
    {
      if (x31b34ee91c89cf69 != null)
        this.xa6607dfd4b3038ad.Text = x31b34ee91c89cf69.Text;
      else
        this.xa6607dfd4b3038ad.Text = "";
    }

    public void xd1bdd0ee5924b59e()
    {
      this.x8e9e04a70e31e166((object) null, (EventArgs) null);
    }

    private void x8e9e04a70e31e166(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      if (this.x6fd7c9ad69859c3e != null)
      {
        if (0 == 0)
        {
          if (0 != 0)
            return;
          this.x6fd7c9ad69859c3e.xcc55983eb55360ac -= new ControlLayoutSystem.xf09a9df3c262275d(this.xe20c835979d60df8);
          if (-1 != 0)
            goto label_4;
          else
            goto label_6;
        }
      }
      else
        goto label_4;
label_2:
      do
      {
        this.xa6607dfd4b3038ad.Text = "";
      }
      while (15 == 0);
      this.x6fd7c9ad69859c3e = (ControlLayoutSystem) null;
      return;
label_4:
      if (!this.HasSingleControlLayoutSystem)
        goto label_2;
label_6:
      this.x6fd7c9ad69859c3e = (ControlLayoutSystem) this.LayoutSystem.LayoutSystems[0];
      this.x6fd7c9ad69859c3e.xcc55983eb55360ac += new ControlLayoutSystem.xf09a9df3c262275d(this.xe20c835979d60df8);
      this.xe20c835979d60df8((DockControl) null, this.x6fd7c9ad69859c3e.SelectedControl);
    }

    private void x9218bee68262250e(object xe0292b9ed559da7d, CancelEventArgs xfbf34718e704c6bc)
    {
      if (!this.x50765ed4559630d6)
        return;
      int index1;
      int index2;
      do
      {
        DockControl[] x9476096be9672d38 = this.LayoutSystem.x9476096be9672d38;
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
              while ((uint) index1 + (uint) index2 < 0U);
              break;
label_2:
              ++index1;
            }
            else
              goto label_15;
          }
          if ((uint) index2 + (uint) index1 > uint.MaxValue)
            goto label_10;
        }
        DockControl dockControl = dockControlArray1[index2];
        if ((index1 & 0) == 0)
        {
          if (dockControl.AllowClose)
            goto label_6;
          else
            goto label_5;
        }
label_16:;
      }
      while ((uint) index2 - (uint) index1 > uint.MaxValue);
      xfbf34718e704c6bc.Cancel = true;
      return;
label_15:
      return;
label_5:
      xfbf34718e704c6bc.Cancel = true;
      return;
label_10:;
    }

    private void xe1f5f125062dc4fb(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      Form activeForm = Form.ActiveForm;
label_15:
      Form xd936980ea1aac341 = this.xd936980ea1aac341;
      DockControl[] x9476096be9672d38 = this.LayoutSystem.x9476096be9672d38;
      DockControl xbe0b15fe97a1ee89 = this.xbe0b15fe97a1ee89;
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
          Array.Copy((Array) x9476096be9672d38, 1, (Array) controls, 0, x9476096be9672d38.Length - 1);
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
      this.xa6607dfd4b3038ad.Activate();
    }
  }
}
