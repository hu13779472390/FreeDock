using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace FQ.FreeDock
{
    // j
    class ThemeHelper
    {
        public static bool OriginalTheme
        {
            get
            {
                return Path.GetFileName(ThemeFilename).ToLower() == "luna.msstyles";
            }
        }

        public static string ThemeFilename
        {
            get
            {
                StringBuilder pszThemeFileName = new StringBuilder(512);
                GetCurrentThemeName(pszThemeFileName, pszThemeFileName.Capacity, null, 0, null, 0);
                return pszThemeFileName.ToString();
//                return "noluna";
            }
        }

        public static string ColorScheme
        {
            get
            {
                StringBuilder pszColorBuff = new StringBuilder(512);
                GetCurrentThemeName(null, 0, pszColorBuff, pszColorBuff.Capacity, null, 0);
                return ((object)pszColorBuff).ToString();
//                return "noluna";
            }
        }

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        private static extern int  GetCurrentThemeName(StringBuilder pszThemeFileName, int dwMaxNameChars, StringBuilder pszColorBuff, int dwMaxColorChars, StringBuilder pszSizeBuff, int cchMaxSizeChars);
    }
}
