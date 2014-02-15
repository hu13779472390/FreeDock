using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace FQ.FreeDock
{
    internal class x60f3af502af1d663
    {
        public static bool x2e20a402b77c44dc
        {
            get
            {
                return Path.GetFileName(x60f3af502af1d663.x43a4294aa97fcbd9).ToLower() == "luna.msstyles";
            }
        }

        public static string x43a4294aa97fcbd9
        {
            get
            {
                StringBuilder pszThemeFileName = new StringBuilder(512);
                x60f3af502af1d663.GetCurrentThemeName(pszThemeFileName, pszThemeFileName.Capacity, (StringBuilder)null, 0, (StringBuilder)null, 0);
                return ((object)pszThemeFileName).ToString();
            }
        }

        public static string x4f15c2ab6fab0941
        {
            get
            {
                StringBuilder pszColorBuff = new StringBuilder(512);
                x60f3af502af1d663.GetCurrentThemeName((StringBuilder)null, 0, pszColorBuff, pszColorBuff.Capacity, (StringBuilder)null, 0);
                return ((object)pszColorBuff).ToString();
            }
        }

        private x60f3af502af1d663()
        {
        }

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        private static extern int  GetCurrentThemeName(StringBuilder pszThemeFileName, int dwMaxNameChars, StringBuilder pszColorBuff, int dwMaxColorChars, StringBuilder pszSizeBuff, int cchMaxSizeChars);
    }
}
