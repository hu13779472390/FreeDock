using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;

namespace FQ.FreeDock
{
    class x443cc432acaadb1d
    {
        private const int COLOR_GRADIENTACTIVECAPTION = 27;
        public const int xe8adba66ee59f491 = -1;
        public const int xeaa67d27b4965bbd = 33;

        public const int SM_REMOTESESSION = 0x1000;

        public static Color x75cc9d2f9fd85f82
        {
            get
            {
                return SystemColors.GradientActiveCaption;
//                return ColorTranslator.FromWin32(x443cc432acaadb1d.GetSysColor(COLOR_GRADIENTACTIVECAPTION));
            }
        }

       
        public static bool x641f26d1017e3571
        {
            [SecuritySafeCritical]
            get
            {
                // true if App is not in Terminal Services console session
                return x443cc432acaadb1d.GetSystemMetrics(SM_REMOTESESSION) != 0;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetSysColor(int nIndex);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int smIndex);
    }
}
