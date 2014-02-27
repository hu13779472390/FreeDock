using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml;
using System.Drawing;

namespace FQ.FreeDock
{
    class x245a5abec1c73d3a
    {
        internal static void x0a680eda7ec8bd81(SandDockManager manager, XmlNode x8a5ce9fbef4b9a09)
        {
            TypeConverter converter1 = TypeDescriptor.GetConverter(typeof(long));
            label_31:
            if (0 != 0)
                goto label_10;
            else
                goto label_32;
            label_5:
            if (x8a5ce9fbef4b9a09.Attributes["LastFloatingWindowGuid"] != null)
                goto label_9;
            label_6:
            DockControl control;
            TypeConverter converter2;
            if (x8a5ce9fbef4b9a09.Attributes["LastDockContainerCount"] != null)
                control.MetaData.xe62a3d24e0fde928.xd25c313925dc7d4e = (int)converter2.ConvertFromString(x8a5ce9fbef4b9a09.Attributes["LastDockContainerCount"].Value);
            if (x8a5ce9fbef4b9a09.Attributes["LastDockContainerIndex"] != null)
                goto label_3;
            label_1:
            x245a5abec1c73d3a.xac29055e1acf1a28(control, x8a5ce9fbef4b9a09, (x129cb2a2bdfd0ab2)control.MetaData.xe62a3d24e0fde928, "Docked");
            x245a5abec1c73d3a.xac29055e1acf1a28(control, x8a5ce9fbef4b9a09, control.MetaData.x25e1dbd0e63329bf, "Document");
            x245a5abec1c73d3a.xac29055e1acf1a28(control, x8a5ce9fbef4b9a09, control.MetaData.xba74b873ae2f845a, "Floating");
            if (0 == 0)
                return;
            else
                goto label_22;
            label_3:
            control.MetaData.xe62a3d24e0fde928.x71a5d248534c8557 = (int)converter2.ConvertFromString(x8a5ce9fbef4b9a09.Attributes["LastDockContainerIndex"].Value);
            goto label_1;
            label_9:
            control.MetaData.x87f4a9b62a380563(new Guid(x8a5ce9fbef4b9a09.Attributes["LastFloatingWindowGuid"].Value));
            goto label_6;
            label_10:
            ContainerDockLocation xbcea506a33cf9111;
            control.MetaData.SetLastFixedDockSide(xbcea506a33cf9111);
            goto label_5;
            label_20:
            TypeConverter converter3;
            control.FloatingLocation = (System.Drawing.Point)converter3.ConvertFromString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["FloatingLocation"].Value);
            TypeConverter converter4;
            control.FloatingSize = (System.Drawing.Size)converter4.ConvertFromString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["FloatingSize"].Value);
            if (x8a5ce9fbef4b9a09.Attributes["LastOpenDockSituation"] != null)
                goto label_21;
            label_15:
            if (x8a5ce9fbef4b9a09.Attributes["LastFixedDockSituation"] != null)
                goto label_14;
            else
                goto label_11;
            label_7:
            if (x8a5ce9fbef4b9a09.Attributes["LastFixedDockLocation"] == null)
            {
                if (0 != 0 || 1 == 0)
                    goto label_9;
                else
                    goto label_5;
            }
            else
                goto label_12;
            label_11:
            if (15 != 0)
                goto label_7;
            label_12:
            xbcea506a33cf9111 = (ContainerDockLocation)Enum.Parse(typeof(ContainerDockLocation), x8a5ce9fbef4b9a09.Attributes["LastFixedDockLocation"].Value);
            if (!Enum.IsDefined(typeof(ContainerDockLocation), (object)xbcea506a33cf9111))
            {
                xbcea506a33cf9111 = ContainerDockLocation.Right;
                goto label_10;
            }
            else if (2 == 0)
            {
                if (0 != 0)
                {
                    if (0 == 0)
                        goto label_20;
                    else
                        goto label_19;
                }
                else
                    goto label_7;
            }
            else
                goto label_10;
            label_14:
            control.MetaData.x0ba17c4cff658fcf((DockSituation)Enum.Parse(typeof(DockSituation), x8a5ce9fbef4b9a09.Attributes["LastFixedDockSituation"].Value));
            goto label_7;
            label_19:
            if (-2 == 0)
                goto label_32;
            else
                goto label_15;
            label_21:
            control.MetaData.xb0e0bc77d88737a8((DockSituation)Enum.Parse(typeof(DockSituation), x8a5ce9fbef4b9a09.Attributes["LastOpenDockSituation"].Value));
            goto label_19;
            label_22:
            if (x8a5ce9fbef4b9a09.Attributes["DockedSize"] != null)
                goto label_26;
            label_24:
            while (x8a5ce9fbef4b9a09.Attributes["PopupSize"] != null)
            {
                control.PopupSize = (int)converter2.ConvertFromString(x8a5ce9fbef4b9a09.Attributes["PopupSize"].Value);
                if (0 == 0)
                    break;
            }
            goto label_20;
            label_26:
            control.MetaData.x3ef4455ea4965093((int)converter2.ConvertFromString(x8a5ce9fbef4b9a09.Attributes["DockedSize"].Value));
            goto label_24;
            label_32:
            converter2 = TypeDescriptor.GetConverter(typeof(int));
            converter4 = TypeDescriptor.GetConverter(typeof(Size));
            converter3 = TypeDescriptor.GetConverter(typeof(Point));
            if (-1 != 0)
                goto label_30;
            label_25:
            if (x8a5ce9fbef4b9a09.Attributes["LastFocused"] != null)
            {
                control.MetaData.x15481da58c59597a(DateTime.FromFileTime((long)converter1.ConvertFromString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["LastFocused"].Value)));
                if (-2 != 0)
                {
                    if (0 == 0)
                        goto label_22;
                    else
                        goto label_31;
                }
                else
                    goto label_20;
            }
            else
                goto label_22;
            label_30:
            control = manager.FindControl(new Guid(x8a5ce9fbef4b9a09.Attributes["Guid"].Value));
            if (control != null)
                goto label_25;
        }

        private static void xac29055e1acf1a28(DockControl x76b3d9d2638e5ecd, XmlNode xeaa9dbf1fba9aca8, x129cb2a2bdfd0ab2 x592a8acce305e2d8, string x05bcae9c376a7a50)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
            label_11:
            do
            {
                if (xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "WorkingSize"] != null)
                    goto label_17;
                else
                    goto label_13;
                label_12:
                continue;
                label_13:
                if (0 != 0)
                    goto label_12;
                else
                    break;
                label_17:
                x592a8acce305e2d8.Sizes = SandDockManager.ConvertStringToSizeF(xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "WorkingSize"].Value);
                if ((int)byte.MaxValue != 0)
                    goto label_12;
            }
            while (0 != 0);
            while (xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "WindowGroupGuid"] == null)
            {
                if (3 != 0)
                    goto label_8;
            }
            goto label_10;
            label_8:
            if (xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "IndexInWindowGroup"] != null)
                x592a8acce305e2d8.x8c8f170696764fac = (int)converter.ConvertFromString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "IndexInWindowGroup"].Value);
            while (xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "SplitPath"] != null)
            {
                if (1 != 0)
                {
                    if (0 == 0)
                    {
                        if (2 != 0)
                        {
                            x592a8acce305e2d8.Indices = x245a5abec1c73d3a.xad77aeacfb4bb694(xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "SplitPath"].Value);
                            if (0 != 0)
                                goto label_8;
                        }
                        if (-1 != 0)
                            break;
                        else
                            goto label_11;
                    }
                    else
                        goto label_8;
                }
            }
            return;
            label_10:
            x592a8acce305e2d8.Guid = new Guid(xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "WindowGroupGuid"].Value);
            goto label_8;
        }

        private static int[] xad77aeacfb4bb694(string xc077f627453a9374)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
            if (int.MaxValue != 0)
                goto label_4;
            label_1:
            string[] strArray;
            int[] numArray = new int[strArray.Length];
            int index = 0;
            label_3:
            for (; index < strArray.Length; ++index)
                numArray[index] = (int)converter.ConvertFromString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, strArray[index]);
            return numArray;
            label_4:
            strArray = xc077f627453a9374.Split(new char[1]
            {
                '|'
            });
            int num;


                goto label_1;
        }

        internal static void x4229d31a884b2577(DockControl x76b3d9d2638e5ecd, XmlTextWriter xbdfb620b7167944b)
        {
            TypeConverter converter1 = TypeDescriptor.GetConverter(typeof(long));
            if (0 == 0)
                goto label_8;
            label_6:
            TypeConverter converter2;
            TypeConverter converter3;
            TypeConverter converter4;
            do
            {
                xbdfb620b7167944b.WriteAttributeString("FloatingLocation", converter4.ConvertToString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)x76b3d9d2638e5ecd.FloatingLocation));
                if (15 != 0)
                    goto label_4;
                label_3:
                xbdfb620b7167944b.WriteAttributeString("LastDockContainerIndex", converter2.ConvertToString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)x76b3d9d2638e5ecd.MetaData.xe62a3d24e0fde928.x71a5d248534c8557));
                x245a5abec1c73d3a.x47161f81513f1258(x76b3d9d2638e5ecd, xbdfb620b7167944b, (x129cb2a2bdfd0ab2)x76b3d9d2638e5ecd.MetaData.xe62a3d24e0fde928, "Docked");
                if (0 == 0)
                {
                    x245a5abec1c73d3a.x47161f81513f1258(x76b3d9d2638e5ecd, xbdfb620b7167944b, x76b3d9d2638e5ecd.MetaData.x25e1dbd0e63329bf, "Document");
                    x245a5abec1c73d3a.x47161f81513f1258(x76b3d9d2638e5ecd, xbdfb620b7167944b, x76b3d9d2638e5ecd.MetaData.xba74b873ae2f845a, "Floating");
                    xbdfb620b7167944b.WriteEndElement();
                    continue;
                }
                label_4:
                xbdfb620b7167944b.WriteAttributeString("FloatingSize", converter3.ConvertToString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)x76b3d9d2638e5ecd.FloatingSize));
                xbdfb620b7167944b.WriteAttributeString("LastOpenDockSituation", ((object)x76b3d9d2638e5ecd.MetaData.LastOpenDockSituation).ToString());
                xbdfb620b7167944b.WriteAttributeString("LastFixedDockSituation", ((object)x76b3d9d2638e5ecd.MetaData.LastFixedDockSituation).ToString());
                if (4 != 0)
                    goto label_5;
                label_2:
                xbdfb620b7167944b.WriteAttributeString("LastFloatingWindowGuid", x76b3d9d2638e5ecd.MetaData.LastFloatingWindowGuid.ToString());
                xbdfb620b7167944b.WriteAttributeString("LastDockContainerCount", converter2.ConvertToString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)x76b3d9d2638e5ecd.MetaData.xe62a3d24e0fde928.xd25c313925dc7d4e));
                goto label_3;
                label_5:
                xbdfb620b7167944b.WriteAttributeString("LastFixedDockLocation", ((object)x76b3d9d2638e5ecd.MetaData.LastFixedDockSide).ToString());
                goto label_2;
            }
            while (0 != 0);
            return;
            label_8:
            converter2 = TypeDescriptor.GetConverter(typeof(int));
            converter3 = TypeDescriptor.GetConverter(typeof(System.Drawing.Size));
            converter4 = TypeDescriptor.GetConverter(typeof(System.Drawing.Point));
            do
            {
                ((XmlWriter)xbdfb620b7167944b).WriteStartElement("Window");
                xbdfb620b7167944b.WriteAttributeString("Guid", x76b3d9d2638e5ecd.Guid.ToString());
                xbdfb620b7167944b.WriteAttributeString("LastFocused", converter1.ConvertToString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)x76b3d9d2638e5ecd.MetaData.LastFocused.ToFileTime()));
                xbdfb620b7167944b.WriteAttributeString("DockedSize", converter2.ConvertToString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)x76b3d9d2638e5ecd.MetaData.DockedContentSize));
                xbdfb620b7167944b.WriteAttributeString("PopupSize", converter2.ConvertToString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)x76b3d9d2638e5ecd.PopupSize));
            }
            while (0 != 0);
            goto label_6;
        }

        private static void x47161f81513f1258(DockControl x76b3d9d2638e5ecd, XmlTextWriter xbdfb620b7167944b, x129cb2a2bdfd0ab2 x592a8acce305e2d8, string x05bcae9c376a7a50)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
            xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "WorkingSize", SandDockManager.ConvertSizeFToString(x592a8acce305e2d8.Sizes));
            xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "WindowGroupGuid", x592a8acce305e2d8.Guid.ToString());
            xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "IndexInWindowGroup", converter.ConvertToString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)x592a8acce305e2d8.x8c8f170696764fac));
            xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "SplitPath", x245a5abec1c73d3a.x8c8bb4495a487cc5(x592a8acce305e2d8.Indices));
        }

        private static string x8c8bb4495a487cc5(int[] x6a80d3cc98596663)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
            string[] strArray = new string[x6a80d3cc98596663.Length];
            int index = 0;
            label_3:
            if (index >= x6a80d3cc98596663.Length)
                return string.Join("|", strArray);
            strArray[index] = converter.ConvertToString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)x6a80d3cc98596663[index]);
            do
            {
                ++index;
            }
            while ((uint)index < 0U);
            goto label_3;
        }
    }
}
