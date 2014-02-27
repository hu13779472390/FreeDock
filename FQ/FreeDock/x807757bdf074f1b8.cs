using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    class x807757bdf074f1b8 : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(InstanceDescriptor) ? true : base.CanConvertTo(context, destinationType);
        }

        private Type MakeArrayType(Type firstType)
        {
            return firstType.Assembly.GetType(firstType.FullName + "[]");
        }

        // reviewed with 2.4
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType == null)
                throw new ArgumentNullException();
 
            if (destinationType != typeof(InstanceDescriptor) || !(value.GetType().Name == "SplitLayoutSystem"))
                return base.ConvertTo(context, culture, value, destinationType);

            Type type = value.GetType();
            Type baseType = type.BaseType;
            MemberInfo member = (MemberInfo)type.GetConstructor(new Type[]
            {
                typeof(SizeF),
                typeof(Orientation),
                this.MakeArrayType(baseType)
            });
            ICollection collection = (ICollection)type.GetProperty("LayoutSystems", BindingFlags.Instance | BindingFlags.Public).GetValue(value, null);
            object[] objArray = (object[])Activator.CreateInstance(this.MakeArrayType(baseType), new object[]
            {
                collection.Count
            });
            collection.CopyTo((Array)objArray, 0);
            SizeF sizeF = (SizeF)type.GetProperty("WorkingSize", BindingFlags.Instance | BindingFlags.Public).GetValue(value, null);
            Orientation orientation = (Orientation)type.GetProperty("SplitMode", BindingFlags.Instance | BindingFlags.Public).GetValue(value, null);
            return new InstanceDescriptor(member, new object[]
            {
                sizeF,
                orientation,
                objArray
            });
        }
    }
}
