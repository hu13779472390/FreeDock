using System.Collections;
using System.ComponentModel;

namespace FQ.FreeDock.Rendering
{
    // ::A.a
    class NoDefaultRenderConverter : RenderConverter
    {
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new TypeConverter.StandardValuesCollection(new string[]
            {
                "Everett",
                "Office 2003",
                "Whidbey",
                "Milborne",
                "Office 2007"
            });
        }
    }
}
