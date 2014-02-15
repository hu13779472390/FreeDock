// Type: TD.SandDock.WindowMetaData
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System;

namespace FQ.FreeDock
{
  /// <summary>
  /// Provides memory for a dockable window and its situation.
  /// 
  /// </summary>
  public class WindowMetaData
  {
    private DateTime x36addad21d4cd225 = DateTime.FromFileTime(0L);
    private int x0c34bafa1bebd8d8 = -1;
    private ContainerDockLocation xdcf3623df6a7e235 = ContainerDockLocation.Right;
    private DockSituation x2097366c1b6e436a;
    private DockSituation x86d57ad3fc8ec08d;
    private x129cb2a2bdfd0ab2 xa93c1ee3649251c3;
    private x129cb2a2bdfd0ab2 xd322344ef33dfd34;
    private xd0aa9d0e7d3446c0 x02053c1a8559b85f;
    private Guid xa637547ad85d295d;

    /// <summary>
    /// The time that the window last received keyboard focus.
    /// 
    /// </summary>
    public DateTime LastFocused
    {
      get
      {
        return this.x36addad21d4cd225;
      }
    }

    /// <summary>
    /// The location at which the window was last docked.
    /// 
    /// </summary>
    public ContainerDockLocation LastFixedDockSide
    {
      get
      {
        return this.xdcf3623df6a7e235;
      }
    }

    /// <summary>
    /// The content size a container should adopt to host the window.
    /// 
    /// </summary>
    public int DockedContentSize
    {
      get
      {
        if (this.x0c34bafa1bebd8d8 == -1)
          return 200;
        else
          return this.x0c34bafa1bebd8d8;
      }
    }

    internal bool x057495d927e64b9e
    {
      get
      {
        return this.x0c34bafa1bebd8d8 != -1;
      }
    }

    /// <summary>
    /// The dock situation of the window when it was last open.
    /// 
    /// </summary>
    public DockSituation LastOpenDockSituation
    {
      get
      {
        return this.x2097366c1b6e436a;
      }
    }

    /// <summary>
    /// The dock situation of the window when it was last open in a non-floating state.
    /// 
    /// </summary>
    public DockSituation LastFixedDockSituation
    {
      get
      {
        return this.x86d57ad3fc8ec08d;
      }
    }

    internal xd0aa9d0e7d3446c0 xe62a3d24e0fde928
    {
      get
      {
        return this.x02053c1a8559b85f;
      }
    }

    internal x129cb2a2bdfd0ab2 x25e1dbd0e63329bf
    {
      get
      {
        return this.xa93c1ee3649251c3;
      }
    }

    internal x129cb2a2bdfd0ab2 xba74b873ae2f845a
    {
      get
      {
        return this.xd322344ef33dfd34;
      }
    }

    public Guid LastFloatingWindowGuid
    {
      get
      {
        return this.xa637547ad85d295d;
      }
    }

    internal WindowMetaData()
    {
      this.x02053c1a8559b85f = new xd0aa9d0e7d3446c0();
      this.xa93c1ee3649251c3 = new x129cb2a2bdfd0ab2();
      this.xd322344ef33dfd34 = new x129cb2a2bdfd0ab2();
    }

    internal void x15481da58c59597a(DateTime xbcea506a33cf9111)
    {
      this.x36addad21d4cd225 = xbcea506a33cf9111;
    }

    internal void xfca44c52f41f0e26(ContainerDockLocation xbcea506a33cf9111)
    {
      this.xdcf3623df6a7e235 = xbcea506a33cf9111;
    }

    internal void x3ef4455ea4965093(int xbcea506a33cf9111)
    {
      this.x0c34bafa1bebd8d8 = xbcea506a33cf9111;
    }

    internal void xb0e0bc77d88737a8(DockSituation xbcea506a33cf9111)
    {
      this.x2097366c1b6e436a = xbcea506a33cf9111;
    }

    internal void x0ba17c4cff658fcf(DockSituation xbcea506a33cf9111)
    {
      this.x86d57ad3fc8ec08d = xbcea506a33cf9111;
    }

    internal void x87f4a9b62a380563(Guid xbcea506a33cf9111)
    {
      this.xa637547ad85d295d = xbcea506a33cf9111;
    }
  }
}
