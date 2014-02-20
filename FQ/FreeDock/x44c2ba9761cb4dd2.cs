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
            if (destinationType == typeof(InstanceDescriptor))
                return true;
            else
                return base.CanConvertTo(context, destinationType);
        }

        private Type MakeArrayType(Type firstType)
        {
            return firstType.Assembly.GetType(firstType.FullName + "[]");
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != null)
            {
                label_9:
                if (destinationType == typeof(InstanceDescriptor))
                    goto label_6;
                else
                    goto label_10;
                label_1:
                if (4 == 0)
                    goto label_7;
                label_3:
                if (!(value.GetType().Name == "DocumentLayoutSystem"))
                {
                    if (int.MaxValue == 0)
                    {
                        if (0 == 0)
                            goto label_8;
                        else
                            goto label_7;
                    }
                    else if (0 == 0)
                        goto label_24;
                    else
                        goto label_19;
                }
                else
                    goto label_18;
                label_6:
                if (value.GetType().Name == "ControlLayoutSystem")
                    goto label_18;
                else
                    goto label_1;
                label_7:
                if (-1 != 0)
                {
                    if (0 != 0)
                        goto label_1;
                    else
                        goto label_3;
                }
                else
                    goto label_6;
                label_8:
                ConstructorInfo constructor;
                SizeF sizeF;
                object[] objArray;
                object obj;
                return (object)new InstanceDescriptor((MemberInfo)constructor, (ICollection)new object[3]
                {
                    (object)sizeF,
                    (object)objArray,
                    obj
                });
                label_10:
                if (4 == 0)
                    goto label_1;
                else
                    goto label_24;
                label_18:
                Type type1;
                Type type2;
                do
                {
                    type1 = value.GetType();
                    type1.Assembly.GetType("TD.SandDock.LayoutSystemBase");
                    type2 = type1.Assembly.GetType("TD.SandDock.DockControl");
                    if (-1 == 0)
                    {
                        if (4 == 0)
                        {
                            if (-2 == 0)
                                goto label_7;
                        }
                        else
                            goto label_9;
                    }
                    else
                        goto label_16;
                }
                while (0 != 0);
                goto label_6;
                label_16:
                PropertyInfo property1;
                do
                {
                    PropertyInfo property2;
                    do
                    {
                        if (0 == 0)
                            goto label_17;
                        label_15:
                        ICollection collection;
                        objArray = (object[])Activator.CreateInstance(this.MakeArrayType(type2), new object[1]
                        {
                            (object)collection.Count
                        });
                        collection.CopyTo((Array)objArray, 0);
                        property2 = type1.GetProperty("WorkingSize", BindingFlags.Instance | BindingFlags.Public);
                        continue;
                        label_17:
                        constructor = type1.GetConstructor(new Type[3]
                        {
                            typeof(SizeF),
                            this.MakeArrayType(type2),
                            type2
                        });
                        collection = (ICollection)type1.GetProperty("Controls", BindingFlags.Instance | BindingFlags.Public).GetValue(value, (object[])null);
                        goto label_15;
                    }
                    while ((int)byte.MaxValue == 0);
                    if (0 == 0)
                    {
                        sizeF = (SizeF)property2.GetValue(value, (object[])null);
                        property1 = type1.GetProperty("SelectedControl", BindingFlags.Instance | BindingFlags.Public);
                        if (int.MaxValue != 0)
                            goto label_11;
                    }
                    else
                        goto label_11;
                }
                while (15 == 0);
                goto label_19;
                label_11:
                obj = property1.GetValue(value, (object[])null);
                goto label_8;
                label_24:
                return base.ConvertTo(context, culture, value, destinationType);
            }
            label_19:
            throw new ArgumentNullException();
        }
    }
}
