// Type: TD.SandDock.Rendering.xdc4dfd9427bbb983
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System.Collections;
using System.ComponentModel;

namespace FQ.FreeDock.Rendering
{
  internal class xdc4dfd9427bbb983 : x9c9262004128fe00
  {
    public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.Add((object) "Everett");
      arrayList.Add((object) "Office 2003");
      arrayList.Add((object) "Whidbey");
      arrayList.Add((object) "Milborne");
      do
      {
        arrayList.Add((object) "Office 2007");
      }
      while (0 != 0);
      return new TypeConverter.StandardValuesCollection((ICollection) arrayList);
    }
  }
}
