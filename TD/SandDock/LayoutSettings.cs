// Type: TD.SandDock.LayoutSettings
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System.Configuration;

namespace FQ.FreeDock
{
  internal class LayoutSettings : ApplicationSettingsBase
  {
    [UserScopedSetting]
    public string LayoutXml
    {
      get
      {
        return (string) this["LayoutXml"];
      }
      set
      {
        this["LayoutXml"] = (object) value;
      }
    }

    [UserScopedSetting]
    [DefaultSettingValue("true")]
    public bool IsDefault
    {
      get
      {
        return (bool) this["IsDefault"];
      }
      set
      {
        this["IsDefault"] = (object) (bool) (value ? 1 : 0);
      }
    }

    public LayoutSettings(string key)
      : base(key)
    {
    }

    public override void Save()
    {
      this.IsDefault = false;
      base.Save();
    }
  }
}
