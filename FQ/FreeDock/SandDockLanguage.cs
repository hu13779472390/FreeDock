using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    /// <summary>
    /// Contains global text strings used by SandDock in rendering.
    /// 
    /// </summary>
    public sealed class SandDockLanguage
    {
        private static string activeFilesText;
        private static string x39981e4ce91f2127;
        private static string x0c2979d11a5a497d;
        private static string x72913f986fffe0b3;

        /// <summary>
        /// The text displayed in the tooltip for the active files list.
        /// 
        /// </summary>
        [Localizable(true)]
        public static string ActiveFilesText
        {
            get
            {
                return SandDockLanguage.activeFilesText;
            }
            set
            {
                SandDockLanguage.activeFilesText = value ?? string.Empty;
            }
        }

        /// <summary>
        /// The text displayed in the tooltip for window position buttons.
        /// 
        /// </summary>
        [Localizable(true)]
        public static string WindowPositionText { get; set; }

        /// <summary>
        /// The text displayed in the tooltip for scroll right buttons.
        /// 
        /// </summary>
        [Localizable(true)]
        public static string ScrollRightText { get; set; }

        /// <summary>
        /// The text displayed in the tooltip for scroll left buttons.
        /// 
        /// </summary>
        [Localizable(true)]
        public static string ScrollLeftText { get; set; }

        /// <summary>
        /// The text displayed in the tooltip for close buttons.
        /// 
        /// </summary>
        [Localizable(true)]
        public static string CloseText { get; set; }

        /// <summary>
        /// The text displayed in the tooltip for autohide buttons.
        /// 
        /// </summary>
        [Localizable(true)]
        public static string AutoHideText { get; set; }

        static SandDockLanguage()
        {
            SandDockLanguage.x0c2979d11a5a497d = "The component in question should be installed in only one location, by default within the \"Program Files\\Divelements\" folder. Please close Visual Studio, remove the errant assembly and try loading your designer again.";
            SandDockLanguage.x72913f986fffe0b3 = "Ensure that you do not attempt to save any designer that opens with errors, as this can result in loss of work. Note that you may receive this message multiple times, once for each component instance in your designer.";
            SandDockLanguage.x39981e4ce91f2127 = "Visual Studio is attempting to load designers from a different assembly than the one your components are being created with. This will result in failure to load your designed component. This message is being displayed because SandDock has detected this condition and will give you more information that will help you to correct the problem.";

            SandDockLanguage.CloseText = "Close";
            SandDockLanguage.AutoHideText = "Auto Hide";
            SandDockLanguage.ScrollLeftText = "Scroll Left";
            SandDockLanguage.ScrollRightText = "Scroll Right";
            SandDockLanguage.WindowPositionText = "Window  Position";
            SandDockLanguage.ActiveFilesText = "Active Files";
        }

        private SandDockLanguage()
        {
        }

        /// <summary>
        /// This method is used by internal SandDock designers and is not intended to be used by other code.
        /// 
        /// </summary>
        public static void ShowCachedAssemblyError(Assembly componentAssembly, Assembly designerAssembly)
        {
            string text = SandDockLanguage.x39981e4ce91f2127 + Environment.NewLine + Environment.NewLine;
            do
            {
                string str1 = text;
                goto label_12;
                label_1:
                string[] strArray1;

                strArray1[3] = Environment.NewLine;
                strArray1[4] = SandDockLanguage.x72913f986fffe0b3;
                text = string.Concat(strArray1);
                MessageBox.Show(text, "Visual Studio Error Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                goto label_9;


                label_3:
                string[] strArray2;
                string str2 = string.Concat(strArray2);
                strArray1 = new string[5];

                label_4:
                strArray1[0] = str2;
                strArray1[1] = SandDockLanguage.x0c2979d11a5a497d;
                strArray1[2] = Environment.NewLine;
                goto label_1;
                label_6:
                strArray2[3] = designerAssembly.Location;
                strArray2[4] = Environment.NewLine;
                strArray2[5] = Environment.NewLine;
                goto label_3;
                label_9:
                continue;
                label_12:
                text = str1 + "Component Assembly:" + Environment.NewLine + componentAssembly.Location + Environment.NewLine + Environment.NewLine;
                string str3 = text;
                strArray2 = new string[6];

                strArray2[0] = str3;
                strArray2[1] = "Designer Assembly:";

                strArray2[2] = Environment.NewLine;

                goto label_6;

            }
            while (0 != 0);
            goto label_10;

            label_10:
            ;
        }
    }
}
