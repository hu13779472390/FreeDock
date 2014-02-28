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
            string text = string.Concat(new string[]
            {
                SandDockLanguage.x39981e4ce91f2127,
                Environment.NewLine,
                Environment.NewLine,
                "Component Assembly:",
                Environment.NewLine, 
                componentAssembly.Location,
                Environment.NewLine,
                Environment.NewLine,
                "Designer Assembly:",
                Environment.NewLine,
                designerAssembly.Location,
                Environment.NewLine,
                Environment.NewLine,
                SandDockLanguage.x0c2979d11a5a497d,
                Environment.NewLine,
                Environment.NewLine,
                SandDockLanguage.x72913f986fffe0b3
            });
            MessageBox.Show(text, "Visual Studio Error Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
