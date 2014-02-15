// Type: TD.SandDock.Rendering.x9c9262004128fe00
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using FQ.FreeDock;

namespace FQ.FreeDock.Rendering
{
  internal class x9c9262004128fe00 : TypeConverter
  {
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof (string))
      {
        if (2 == 0)
          ;
        return true;
      }
      else if (destinationType == typeof (InstanceDescriptor))
        return true;
      else
        return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType != typeof (string))
      {
        if (destinationType == typeof (InstanceDescriptor))
          return (object) new InstanceDescriptor((MemberInfo) value.GetType().GetConstructor(Type.EmptyTypes), (ICollection) new object[0], true);
        else
          return base.ConvertTo(context, culture, value, destinationType);
      }
      else if (value is string)
        return value;
      else
        return (object) value.ToString();
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (!(value is string))
        return base.ConvertFrom(context, culture, value);
      string str;
      if ((str = (string) value) != null)
        goto label_13;
label_3:
      return (object) null;
label_13:
      while (!(str == "Everett"))
      {
label_10:
        if (str == "Office 2003")
          return (object) new Office2003Renderer();
        if (str == "Whidbey")
          return (object) new WhidbeyRenderer();
        if (0 == 0)
        {
          if (str == "Milborne")
            return (object) new MilborneRenderer();
          if (str == "Office 2007")
            return (object) new Office2007Renderer();
          else
            goto label_3;
        }
        else if (0 == 0)
          goto label_10;
      }
      return (object) new EverettRenderer();
    }

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof (string))
        return true;
      else
        return base.CanConvertFrom(context, sourceType);
    }

    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
    {
      return true;
    }

    public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
    {
      return true;
    }

    public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
      ArrayList arrayList = new ArrayList();
label_9:
      if (context != null)
        goto label_10;
label_3:
      arrayList.Add((object) "Everett");
      arrayList.Add((object) "Office 2003");
      goto label_8;
label_4:
      if (context.Instance is DockContainer)
        goto label_12;
label_5:
      if (0 == 0 && 0 == 0)
      {
        if (0 == 0)
          goto label_3;
        else
          goto label_8;
      }
label_6:
      if (int.MaxValue == 0)
        goto label_4;
      else
        goto label_3;
label_8:
      if (0 == 0)
      {
        if (0 == 0)
        {
          arrayList.Add((object) "Whidbey");
          arrayList.Add((object) "Office 2007");
          return new TypeConverter.StandardValuesCollection((ICollection) arrayList);
        }
        else
          goto label_11;
      }
      else
        goto label_9;
label_10:
      if (int.MinValue == 0)
        goto label_5;
label_11:
      if (0 == 0)
        goto label_4;
label_12:
      arrayList.Add((object) "(default)");
      goto label_6;
    }
  }
}
