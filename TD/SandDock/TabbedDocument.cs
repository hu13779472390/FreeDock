// Type: TD.SandDock.TabbedDocument
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System.ComponentModel;
using System.Windows.Forms;

namespace FQ.FreeDock
{
  /// <summary>
  /// An extended DockControl that will open docked in the center of your container.
  /// 
  /// </summary>
  public class TabbedDocument : DockControl
  {
    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected override System.Drawing.Size DefaultSize
    {
      get
      {
        return new System.Drawing.Size(550, 400);
      }
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    [DefaultValue(typeof (DockControlCloseAction), "Dispose")]
    public override DockControlCloseAction CloseAction
    {
      get
      {
        return base.CloseAction;
      }
      set
      {
        base.CloseAction = value;
      }
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    [DefaultValue(false)]
    public override bool PersistState
    {
      get
      {
        return base.PersistState;
      }
      set
      {
        base.PersistState = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the TabbedDocument class.
    /// 
    /// </summary>
    public TabbedDocument()
    {
      this.x84eb05aa1ce8e247();
    }

    /// <summary>
    /// Initializes a new instance of the TabbedDocument class, containing the specified control and with the specified text.
    /// 
    /// </summary>
    /// <param name="manager">The SandDockManager responsible for layout of the control.</param><param name="control">The control to host within the DockControl.</param><param name="text">The text of the DockControl.</param>
    public TabbedDocument(SandDockManager manager, Control control, string text)
      : base(manager, control, text)
    {
      this.x84eb05aa1ce8e247();
    }

    private void x84eb05aa1ce8e247()
    {
      if (this.Text.Length == 0)
        this.Text = "Tabbed Document";
      this.CloseAction = DockControlCloseAction.Dispose;
      this.PersistState = false;
      this.SetPositionMetaData(DockSituation.Document);
    }

    /// <summary>
    /// Overridden. Consult the documentation on the base virtual member for more information.
    /// 
    /// </summary>
    protected override DockingRules CreateDockingRules()
    {
      return new DockingRules(false, true, false);
    }

    /// <summary>
    /// Opens the document at its last known location, causing it to be the active document in its container if applicable.
    /// 
    /// </summary>
    public override void Open()
    {
      base.Open(WindowOpenMethod.OnScreenActivate);
    }
  }
}
