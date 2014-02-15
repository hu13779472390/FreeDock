// Type: Divelements.Util.Registration.xbd7c5470fc89975b
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System.ComponentModel;

namespace Divelements.Util.Registration
{
  internal class xbd7c5470fc89975b : License
  {
    public virtual bool Evaluation
    {
      get
      {
        return false;
      }
    }

    public virtual bool Locked
    {
      get
      {
        return false;
      }
    }

    public override string LicenseKey
    {
      get
      {
        return "This is a licensed component.";
      }
    }

    internal xbd7c5470fc89975b()
    {
    }

    public override void Dispose()
    {
    }
  }
}
