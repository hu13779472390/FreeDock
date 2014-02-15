// Type: TD.SandDock.x443cc432acaadb1d
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System.Drawing;
using System.Runtime.InteropServices;

namespace FQ.FreeDock
{
  internal class x443cc432acaadb1d
  {
    public const int xe8adba66ee59f491 = -1;
    public const int x152a3652057f019c = 4096;
    public const int xeaa67d27b4965bbd = 33;

    public static Color x75cc9d2f9fd85f82
    {
      get
      {
        return ColorTranslator.FromWin32(x443cc432acaadb1d.GetSysColor(27));
      }
    }

    public static bool x641f26d1017e3571
    {
      get
      {
        return x443cc432acaadb1d.GetSystemMetrics(4096) != 0;
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
