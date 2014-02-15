// Type: TD.SandDock.UserTabbedDocument
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System.ComponentModel;
using System.ComponentModel.Design;

namespace FQ.FreeDock
{
  /// <summary>
  /// An extended DockControl that allows standalone editing within the designer.
  /// 
  /// </summary>
  [Designer("TD.SandDock.Design.UserDockControlDesigner, SandDock.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3", typeof (IDesigner))]
  [Designer("TD.SandDock.Design.UserDockControlDocumentDesigner, SandDock.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3", typeof (IRootDesigner))]
  public class UserTabbedDocument : TabbedDocument
  {
  }
}
