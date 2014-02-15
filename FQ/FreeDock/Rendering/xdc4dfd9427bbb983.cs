using System.Collections;
using System.ComponentModel;

namespace FQ.FreeDock.Rendering
{
    internal class xdc4dfd9427bbb983 : x9c9262004128fe00
    {
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add((object)"Everett");
            arrayList.Add((object)"Office 2003");
            arrayList.Add((object)"Whidbey");
            arrayList.Add((object)"Milborne");
            do
            {
                arrayList.Add((object)"Office 2007");
            }
            while (0 != 0);
            return new TypeConverter.StandardValuesCollection((ICollection)arrayList);
        }
    }
}
