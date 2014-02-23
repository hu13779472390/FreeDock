﻿using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using FQ.FreeDock;

namespace FQ.FreeDock.Rendering
{
    class x9c9262004128fe00 : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;
            else if (destinationType == typeof(InstanceDescriptor))
                return true;
            else
                return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string))
            {
                if (destinationType == typeof(InstanceDescriptor))
                    return new InstanceDescriptor((MemberInfo)value.GetType().GetConstructor(Type.EmptyTypes), (ICollection)new object[0], true);
                else
                    return base.ConvertTo(context, culture, value, destinationType);
            }
            else if (value is string)
                return value;
            else
                return value.ToString();
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!(value is string))
                return base.ConvertFrom(context, culture, value);

            string render = value as string;
            if (render == null)
                return null;

            switch (render)
            {
                case "Everett": 
                    return new EverettRenderer();
                case "Office 2003": 
                    return new Office2003Renderer();
                case "Whidbey":
                    return new WhidbeyRenderer();
                case "Milborne":
                    return new MilborneRenderer();
                case "Office 2007":
                    return new Office2007Renderer();
                default:
                    return null;
            }
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
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
            ArrayList list = new ArrayList();
            if (context.Instance is DockContainer)
            {
                list.Add("(default)");
            }
            list.Add("Everett");
            list.Add("Office 2003");
            list.Add("Whidbey");
            list.Add("Office 2007");
            return new TypeConverter.StandardValuesCollection(list);

        }
    }
}
