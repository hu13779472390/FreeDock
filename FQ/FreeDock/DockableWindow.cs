// Type: TD.SandDock.DockableWindow
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System.Windows.Forms;

namespace FQ.FreeDock
{
  /// <summary>
  /// An extended DockControl that will open docked to one of the sides of your container.
  /// 
  /// </summary>
  public class DockableWindow : DockControl
  {
    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected override System.Drawing.Size DefaultSize
    {
      get
      {
        return new System.Drawing.Size(250, 400);
      }
    }

    /// <summary>
    /// Initializes a new instance of the DockableWindow class.
    /// 
    /// </summary>
    public DockableWindow()
    {
      this.x84eb05aa1ce8e247();
    }

    /// <summary>
    /// Initializes a new instance of the DockableWindow class, containing the specified control and with the specified text.
    /// 
    /// </summary>
    /// <param name="manager">The SandDockManager responsible for layout of the control.</param><param name="control">The control to host within the DockControl.</param><param name="text">The text of the DockControl.</param>
    public DockableWindow(SandDockManager manager, Control control, string text)
      : base(manager, control, text)
    {
      this.x84eb05aa1ce8e247();
    }

    /// <summary>
    /// Overridden. Consult the documentation on the base virtual member for more information.
    /// 
    /// </summary>
    protected override DockingRules CreateDockingRules()
    {
      return new DockingRules(true, false, true);
    }

    /// <summary>
    /// Opens the window at its last known location, ensuring it is the selected window in its tab group.
    /// 
    /// </summary>
    public override void Open()
    {
      base.Open(WindowOpenMethod.OnScreenSelect);
    }

    private void x84eb05aa1ce8e247()
    {
      if (this.Text.Length == 0)
        this.Text = "Dockable Window";
      this.SetPositionMetaData(DockSituation.Docked, ContainerDockLocation.Right);
    }
  }
}
