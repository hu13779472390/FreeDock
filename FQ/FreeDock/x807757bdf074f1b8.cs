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
    internal class x807757bdf074f1b8 : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
                return true;
            else
                return base.CanConvertTo(context, destinationType);
        }

        private System.Type MakeArrayType(System.Type firstType)
        {
            return firstType.Assembly.GetType(firstType.FullName + "[]");
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType != null)
            {
                if (destinationType == typeof(InstanceDescriptor))
                {
                    if (0 != 0)
                        goto label_8;
                    label_3:
                    System.Type type;
                    if (value.GetType().Name == "SplitLayoutSystem")
                    {
                        type = value.GetType();
                        goto label_8;
                    }
                    label_7:
                    if (0 == 0)
                        goto label_11;
                    else
                        goto label_9;
                    label_8:
                    System.Type baseType = type.BaseType;
                    MemberInfo member = (MemberInfo)type.GetConstructor(new System.Type[3]
                    {
                        typeof(SizeF),
                        typeof(Orientation),
                        this.MakeArrayType(baseType)
                    });
                    ICollection collection = (ICollection)type.GetProperty("LayoutSystems", BindingFlags.Instance | BindingFlags.Public).GetValue(value, (object[])null);
                    object[] objArray = (object[])Activator.CreateInstance(this.MakeArrayType(baseType), new object[1]
                    {
                        (object)collection.Count
                    });
                    collection.CopyTo((Array)objArray, 0);
                    if (0 == 0)
                    {
                        if (15 != 0)
                        {
                            SizeF sizeF = (SizeF)type.GetProperty("WorkingSize", BindingFlags.Instance | BindingFlags.Public).GetValue(value, (object[])null);
                            Orientation orientation = (Orientation)type.GetProperty("SplitMode", BindingFlags.Instance | BindingFlags.Public).GetValue(value, (object[])null);
                            if (0 == 0)
                                return (object)new InstanceDescriptor(member, (ICollection)new object[3]
                                {
                                    (object)sizeF,
                                    (object)orientation,
                                    (object)objArray
                                });
                            else
                                goto label_7;
                        }
                        else
                            goto label_3;
                    }
                    else
                        goto label_9;
                }
                label_11:
                return base.ConvertTo(context, culture, value, destinationType);
            }
            label_9:
            throw new ArgumentNullException();
        }
    }
}
