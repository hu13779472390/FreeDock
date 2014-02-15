// Type: TD.SandDock.DockControlEventArgs
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System;

namespace FQ.FreeDock
{
  /// <summary>
  /// Provides event data describing a DockControl.
  /// 
  /// </summary>
  public class DockControlEventArgs : EventArgs
  {
    private DockControl xdeac46e41e0fbcf5;

    /// <summary>
    /// The DockControl associated with this event.
    /// 
    /// </summary>
    public DockControl DockControl
    {
      get
      {
        return this.xdeac46e41e0fbcf5;
      }
    }

    internal DockControlEventArgs(DockControl dockControl)
    {
      this.xdeac46e41e0fbcf5 = dockControl;
    }
  }
}
