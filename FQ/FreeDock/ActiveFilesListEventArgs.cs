// Type: TD.SandDock.ActiveFilesListEventArgs
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System;
using System.Windows.Forms;

namespace FQ.FreeDock
{
  /// <summary>
  /// Arguments describing an event dealing with a list of active files.
  /// 
  /// </summary>
  public class ActiveFilesListEventArgs : EventArgs
  {
    private DockControl[] x8fb2a5bf0df0416f;
    private Control x43bec302f92080b9;
    private System.Drawing.Point x13d4cb8d1bd20347;

    /// <summary>
    /// The list of windows to choose from.
    /// 
    /// </summary>
    public DockControl[] Windows
    {
      get
      {
        return this.x8fb2a5bf0df0416f;
      }
    }

    /// <summary>
    /// The control on which to show a menu.
    /// 
    /// </summary>
    public Control Control
    {
      get
      {
        return this.x43bec302f92080b9;
      }
    }

    /// <summary>
    /// The position, in control coordinates, at which to show a menu.
    /// 
    /// </summary>
    public System.Drawing.Point Position
    {
      get
      {
        return this.x13d4cb8d1bd20347;
      }
    }

    internal ActiveFilesListEventArgs(DockControl[] windows, Control control, System.Drawing.Point position)
    {
      this.x8fb2a5bf0df0416f = windows;
      this.x43bec302f92080b9 = control;
      this.x13d4cb8d1bd20347 = position;
    }
  }
}
