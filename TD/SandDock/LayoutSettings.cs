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
                return (string)this["LayoutXml"];
            }
            set
            {
                this["LayoutXml"] = (object)value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("true")]
        public bool IsDefault
        {
            get
            {
                return (bool)this["IsDefault"];
            }
            set
            {
                this["IsDefault"] = (object)(bool)(value ? 1 : 0);
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
