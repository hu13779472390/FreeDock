using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace FQ.FreeDock
{
    class x44c2ba9761cb4dd2 : TypeConverter
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
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
                throw new ArgumentNullException();

            if (destinationType != typeof(InstanceDescriptor) || !(value.GetType().Name == "ControlLayoutSystem") && !(value.GetType().Name == "DocumentLayoutSystem"))
                return base.ConvertTo(context, culture, value, destinationType);
            Type type1 = value.GetType();
            type1.Assembly.GetType("FQ.FreeDock.LayoutSystemBase");
            Type type2 = type1.Assembly.GetType("FQ.FreeDock.DockControl");
            ConstructorInfo constructor = type1.GetConstructor(new Type[]
            {
                typeof(SizeF),
                this.MakeArrayType(type2),
                type2
            });
            ICollection collection = (ICollection)type1.GetProperty("Controls", BindingFlags.Instance | BindingFlags.Public).GetValue(value, null);
            object[] objArray = (object[])Activator.CreateInstance(this.MakeArrayType(type2), new object[]
            {
                (object)collection.Count
            });
            collection.CopyTo(objArray, 0);
            PropertyInfo property2 = type1.GetProperty("WorkingSize", BindingFlags.Instance | BindingFlags.Public);
            SizeF sizeF = (SizeF)property2.GetValue(value, null);
            PropertyInfo property1;
            property1 = type1.GetProperty("SelectedControl", BindingFlags.Instance | BindingFlags.Public);
            object obj = property1.GetValue(value, null);
            return new InstanceDescriptor((MemberInfo)constructor, new object[]
            {
                sizeF,
                objArray,
                obj
            });
        }
    }
}
