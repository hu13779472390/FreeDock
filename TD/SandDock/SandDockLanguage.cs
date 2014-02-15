// Type: TD.SandDock.SandDockLanguage
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

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
    private static string x44b5349697df48ef = "Close";
    private static string xa411173168232f87;
    private static string xd1710f20a2c171cd;
    private static string x9e94b420934211d6;
    private static string x9956f53fadd73b87;
    private static string x5e3773048fa89dc1;
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
        return SandDockLanguage.x5e3773048fa89dc1;
      }
      set
      {
        if (value == null)
          value = string.Empty;
        SandDockLanguage.x5e3773048fa89dc1 = value;
      }
    }

    /// <summary>
    /// The text displayed in the tooltip for window position buttons.
    /// 
    /// </summary>
    [Localizable(true)]
    public static string WindowPositionText
    {
      get
      {
        return SandDockLanguage.x9956f53fadd73b87;
      }
      set
      {
        SandDockLanguage.x9956f53fadd73b87 = value;
      }
    }

    /// <summary>
    /// The text displayed in the tooltip for scroll right buttons.
    /// 
    /// </summary>
    [Localizable(true)]
    public static string ScrollRightText
    {
      get
      {
        return SandDockLanguage.x9e94b420934211d6;
      }
      set
      {
        SandDockLanguage.x9e94b420934211d6 = value;
      }
    }

    /// <summary>
    /// The text displayed in the tooltip for scroll left buttons.
    /// 
    /// </summary>
    [Localizable(true)]
    public static string ScrollLeftText
    {
      get
      {
        return SandDockLanguage.xd1710f20a2c171cd;
      }
      set
      {
        SandDockLanguage.xd1710f20a2c171cd = value;
      }
    }

    /// <summary>
    /// The text displayed in the tooltip for close buttons.
    /// 
    /// </summary>
    [Localizable(true)]
    public static string CloseText
    {
      get
      {
        return SandDockLanguage.x44b5349697df48ef;
      }
      set
      {
        SandDockLanguage.x44b5349697df48ef = value;
      }
    }

    /// <summary>
    /// The text displayed in the tooltip for autohide buttons.
    /// 
    /// </summary>
    [Localizable(true)]
    public static string AutoHideText
    {
      get
      {
        return SandDockLanguage.xa411173168232f87;
      }
      set
      {
        SandDockLanguage.xa411173168232f87 = value;
      }
    }

    static SandDockLanguage()
    {
      if (0 == 0)
        goto label_4;
label_1:
      SandDockLanguage.x0c2979d11a5a497d = "The component in question should be installed in only one location, by default within the \"Program Files\\Divelements\" folder. Please close Visual Studio, remove the errant assembly and try loading your designer again.";
      SandDockLanguage.x72913f986fffe0b3 = "Ensure that you do not attempt to save any designer that opens with errors, as this can result in loss of work. Note that you may receive this message multiple times, once for each component instance in your designer.";
      return;
label_4:
      SandDockLanguage.xa411173168232f87 = "Auto Hide";
      if (0 == 0)
      {
        SandDockLanguage.xd1710f20a2c171cd = "Scroll Left";
        SandDockLanguage.x9e94b420934211d6 = "Scroll Right";
      }
      SandDockLanguage.x9956f53fadd73b87 = "Window  Position";
      SandDockLanguage.x5e3773048fa89dc1 = "Active Files";
      SandDockLanguage.x39981e4ce91f2127 = "Visual Studio is attempting to load designers from a different assembly than the one your components are being created with. This will result in failure to load your designed component. This message is being displayed because SandDock has detected this condition and will give you more information that will help you to correct the problem.";
      if (-1 != 0)
        goto label_1;
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
        if (0 == 0)
          goto label_12;
label_1:
        string[] strArray1;
        if (0 == 0)
        {
          strArray1[3] = Environment.NewLine;
          strArray1[4] = SandDockLanguage.x72913f986fffe0b3;
          text = string.Concat(strArray1);
          int num = (int) MessageBox.Show(text, "Visual Studio Error Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          if (0 == 0)
          {
            if (0 == 0)
              goto label_9;
            else
              goto label_6;
          }
        }
        else
          goto label_4;
label_3:
        string[] strArray2;
        string str2 = string.Concat(strArray2);
        strArray1 = new string[5];
        if (0 != 0)
          goto label_13;
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
        do
        {
          strArray2[0] = str3;
          strArray2[1] = "Designer Assembly:";
        }
        while (0 != 0);
        strArray2[2] = Environment.NewLine;
        if (8 != 0)
          goto label_6;
        else
          goto label_9;
      }
      while (0 != 0);
      goto label_10;
label_13:
      return;
label_10:;
    }
  }
}
