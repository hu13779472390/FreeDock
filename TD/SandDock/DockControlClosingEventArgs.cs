// Type: TD.SandDock.DockControlClosingEventArgs
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

namespace FQ.FreeDock
{
  /// <summary>
  /// Provides event data describing a window that is about to be closed.
  /// 
  /// </summary>
  public class DockControlClosingEventArgs : DockControlEventArgs
  {
    private bool x57602a0a0d178a2e;

    /// <summary>
    /// Indicates whether the action that would normally follow the event should be cancelled.
    /// 
    /// </summary>
    public bool Cancel
    {
      get
      {
        return this.x57602a0a0d178a2e;
      }
      set
      {
        this.x57602a0a0d178a2e = value;
      }
    }

    internal DockControlClosingEventArgs(DockControl dockControl, bool cancel)
      : base(dockControl)
    {
      this.x57602a0a0d178a2e = cancel;
    }
  }
}
