// Type: Divelements.Util.Registration.x294bd621a33dc533
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Divelements.Util.Registration
{
  internal class x294bd621a33dc533 : LicenseProvider
  {
    private const string xed11756391d61907 = "Software\\\\Divelements Limited\\\\Registration";
    private static bool x4528b3b385025289;
    private static bool x0b277e20f7c1b92c;
    private static bool xba4ce277d393a202;
    private static bool x9fb6f00276c83908;

    public static bool StaticallyActivated
    {
      get
      {
        return x294bd621a33dc533.x0b277e20f7c1b92c;
      }
    }

    private static bool IsDebug
    {
      get
      {
        if (!x294bd621a33dc533.xba4ce277d393a202)
        {
          try
          {
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\\\Divelements Limited\\\\Registration", false))
            {
              if (registryKey != null)
              {
                object obj = registryKey.GetValue("Debug");
                if (obj is int)
                  x294bd621a33dc533.x9fb6f00276c83908 = Convert.ToBoolean((int) obj);
              }
            }
          }
          catch
          {
          }
          x294bd621a33dc533.xba4ce277d393a202 = true;
        }
        return x294bd621a33dc533.x9fb6f00276c83908;
      }
    }

    public static void ActivateProduct(string licenseKey)
    {
      if (licenseKey == null)
        throw new ArgumentNullException("licenseKey");
      int customerID;
      do
      {
        licenseKey = licenseKey.Trim();
        string[] strArray = x294bd621a33dc533.SplitLicenseString(licenseKey);
        customerID = int.Parse(strArray[0], (IFormatProvider) CultureInfo.InvariantCulture);
        Assembly assembly = typeof (x294bd621a33dc533).Assembly;
        string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(assembly);
        Version versionFromAssembly = x294bd621a33dc533.GetVersionFromAssembly(assembly);
        string str = x294bd621a33dc533.GenerateLicenseKeyForCustomer(assemblyProductName, "buildmachine", versionFromAssembly.Major, versionFromAssembly.Minor, versionFromAssembly.Build, customerID);
        if ((uint) customerID <= uint.MaxValue)
        {
          if (strArray[1] == str)
            goto label_1;
        }
        else
          break;
      }
      while ((uint) customerID - (uint) customerID > uint.MaxValue);
      goto label_6;
label_1:
      x294bd621a33dc533.x0b277e20f7c1b92c = true;
      return;
label_6:
      throw new ArgumentException("The supplied license key is not valid. Check you are using the correct license key for the version of the software installed.", "licenseKey");
    }

    private static Version GetVersionFromAssembly(Assembly assembly)
    {
      return assembly.GetName().Version;
    }

    public static string[] SplitLicenseString(string s)
    {
      return new string[2]
      {
        s.Substring(0, s.IndexOf('|')),
        s.Substring(s.IndexOf('|') + 1)
      };
    }

    public static string GetAssemblyProductName(Assembly assembly)
    {
      string str = (string) null;
      do
      {
        AssemblyProductAttribute[] productAttributeArray = (AssemblyProductAttribute[]) assembly.GetCustomAttributes(typeof (AssemblyProductAttribute), false);
        if (productAttributeArray.Length != 0)
        {
          str = productAttributeArray[0].Product;
          break;
        }
      }
      while (3 == 0);
      return str;
    }

    private string GetSavedLicenseKey(LicenseContext context, System.Type type)
    {
      string savedLicenseKey1 = context.GetSavedLicenseKey(type, (Assembly) null);
      if (int.MaxValue != 0)
      {
label_8:
        if (savedLicenseKey1 == null)
        {
          Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
          int index = 0;
          while (index < assemblies.Length)
          {
            string savedLicenseKey2;
            do
            {
              Assembly resourceAssembly = assemblies[index];
              if (!(resourceAssembly is AssemblyBuilder))
                goto label_6;
label_3:
              ++index;
              continue;
label_6:
              savedLicenseKey2 = context.GetSavedLicenseKey(type, resourceAssembly);
              if (savedLicenseKey2 != null)
                goto label_7;
              else
                goto label_3;
            }
            while ((index | -1) == 0);
            if (0 == 0)
            {
              if ((uint) index - (uint) index >= 0U)
                goto label_11;
              else
                goto label_8;
            }
            else
              goto label_13;
label_7:
            string str = savedLicenseKey2;
            if ((uint) index + (uint) index <= uint.MaxValue)
              goto label_13;
label_11:
            if (0 == 0)
              continue;
label_13:
            return str;
          }
          return (string) null;
        }
      }
      return savedLicenseKey1;
    }

    public override License GetLicense(LicenseContext context, System.Type type, object instance, bool allowExceptions)
    {
      if (!x294bd621a33dc533.x0b277e20f7c1b92c)
        goto label_13;
      else
        goto label_39;
label_2:
      int customerID;
      while (x294bd621a33dc533.IsDebug)
      {
        this.WriteDebugMessage("eval");
        if ((uint) customerID - (uint) customerID > uint.MaxValue)
        {
          if (0 != 0)
            goto label_5;
        }
        else
          break;
      }
      x1d91faf71382de33 x1d91faf71382de33 = new x1d91faf71382de33();
      if ((uint) customerID - (uint) customerID >= 0U)
        goto label_41;
      else
        goto label_39;
label_5:
      if ((uint) customerID <= uint.MaxValue)
        goto label_2;
label_7:
      if (!this.DoesValidDevelopmentLicenseExist(type.Assembly, (IServiceProvider) context, out customerID))
      {
        if (int.MinValue != 0)
        {
          if ((uint) customerID >= 0U)
            goto label_2;
          else
            goto label_5;
        }
        else
          goto label_41;
      }
      else
      {
        string key = customerID.ToString((IFormatProvider) CultureInfo.InvariantCulture) + "|" + this.GenerateLicenseKeyForType(type, customerID);
        context.SetSavedLicenseKey(type, key);
        if ((customerID | 3) == 0 || x294bd621a33dc533.IsDebug)
        {
          this.WriteDebugMessage("valid");
          goto label_15;
        }
        else
          goto label_15;
      }
label_13:
      if (context != null)
        goto label_37;
      else
        goto label_14;
label_4:
      if (context.UsageMode == LicenseUsageMode.Designtime)
        goto label_7;
      else
        goto label_5;
label_14:
      int num;
      if (0 == 0)
      {
        if (15 != 0)
        {
          if ((uint) allowExceptions <= uint.MaxValue)
          {
            if ((uint) num < 0U)
            {
              if ((uint) allowExceptions >= 0U)
                goto label_24;
              else
                goto label_21;
            }
          }
          else
            goto label_15;
        }
        if (0 == 0)
          goto label_2;
        else
          goto label_5;
      }
      else
        goto label_21;
label_19:
      string assemblyProductName;
      if (this.DoesValidDevelopmentLicenseExist(type.Assembly, (IServiceProvider) context, out customerID))
      {
        if (x294bd621a33dc533.IsDebug)
          goto label_31;
label_27:
        assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(type.Assembly);
        goto label_28;
label_31:
        this.WriteDebugMessage("devok,notembedded");
        goto label_27;
      }
      else
        goto label_4;
label_21:
      string str;
      x294bd621a33dc533.ShowMessage(str + Environment.NewLine + Environment.NewLine + "Press OK to read more.", assemblyProductName);
      Process.Start("http://www.divelements.co.uk/net/support/kb/licensing.aspx");
      x294bd621a33dc533.x4528b3b385025289 = true;
      if (0 != 0)
        goto label_4;
      else
        goto label_4;
label_23:
      if (8 == 0)
        goto label_19;
      else
        goto label_21;
label_24:
      string[] strArray;
      strArray[3] = assemblyProductName;
      strArray[4] = " installed, the license will not be found. Normally, opening at least one form designer will ensure the licenses.licx file in your project is created and updated correctly. If you continue to see this message, ensure the following lines are present in the file.";
      if ((uint) allowExceptions - (uint) customerID <= uint.MaxValue)
      {
        str = string.Concat(strArray) + Environment.NewLine + Environment.NewLine + this.GetLicenseFileLines(type);
        if (int.MaxValue != 0)
          goto label_23;
      }
      else
        goto label_21;
label_28:
      strArray = new string[5];
      strArray[0] = "Warning: Although your development license for ";
      if (0 == 0)
      {
        strArray[1] = assemblyProductName;
        strArray[2] = " is valid, it has not been embedded into your application by Visual Studio. This means that on a machine without ";
        goto label_24;
      }
      else
        goto label_2;
label_37:
      this.GetLicenseFileLines(type);
      if ((uint) allowExceptions + (uint) allowExceptions > uint.MaxValue || x294bd621a33dc533.IsDebug)
        goto label_38;
label_20:
      if (context.UsageMode == LicenseUsageMode.Runtime)
      {
        string savedLicenseKey = this.GetSavedLicenseKey(context, type);
        if (savedLicenseKey != null && this.IsTypeKeyValid(savedLicenseKey, type))
          goto label_34;
label_18:
        if (!x294bd621a33dc533.x4528b3b385025289)
          goto label_19;
        else
          goto label_4;
label_34:
        if (1 != 0)
        {
          if (x294bd621a33dc533.IsDebug)
            goto label_35;
label_33:
          return (License) new xbd7c5470fc89975b();
label_35:
          this.WriteDebugMessage("valid");
          if ((uint) allowExceptions - (uint) num >= 0U)
            goto label_33;
          else
            goto label_18;
        }
        else
          goto label_23;
      }
      else
        goto label_4;
label_38:
      this.WriteDebugMessage("licreq," + ((object) context.UsageMode).ToString());
      goto label_20;
label_15:
      return (License) new xbd7c5470fc89975b();
label_39:
      if ((uint) allowExceptions <= uint.MaxValue)
        return (License) new xbd7c5470fc89975b();
      else
        goto label_7;
label_41:
      return (License) x1d91faf71382de33;
    }

    private string GetLicenseFileLines(System.Type type)
    {
      string name = type.Assembly.GetName().Name;
      if (0 == 0)
        goto label_7;
label_1:
      int index;
      ++index;
label_2:
      System.Type[] types;
      string str;
      if (index >= types.Length)
        return str;
label_3:
      System.Type type1 = types[index];
      if (type1.GetCustomAttributes(typeof (LicenseProviderAttribute), true).Length != 0)
      {
        if (str.Length != 0)
          str = str + Environment.NewLine;
        str = str + type1.FullName + "," + name;
        goto label_1;
      }
      else
        goto label_1;
label_7:
      if (int.MaxValue != 0)
      {
        str = string.Empty;
        types = type.Assembly.GetTypes();
        index = 0;
        goto label_2;
      }
      else
        goto label_3;
    }

    internal static void ShowMessage(string message, string title)
    {
      int num = (int) MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private bool DoesValidDevelopmentLicenseExist(Assembly assembly, IServiceProvider serviceProvider, out int customerID)
    {
      customerID = 0;
label_42:
      string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(assembly);
      RegistryKey registryKey1 = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Divelements Limited\\Registration", false);
label_26:
      if (registryKey1 != null)
        goto label_44;
      else
        goto label_23;
label_2:
      if (0 != 0)
        goto label_5;
      else
        goto label_47;
label_3:
      if (!x294bd621a33dc533.IsDebug)
      {
        if (1 != 0)
          goto label_2;
      }
      else
      {
        this.WriteDebugMessage("nokey");
        if (0 != 0)
          goto label_7;
      }
label_5:
      if (15 != 0)
      {
        if (0 == 0)
        {
          if (15 != 0)
            goto label_39;
          else
            goto label_34;
        }
        else
          goto label_17;
      }
label_7:
      if (!x294bd621a33dc533.IsDebug)
      {
        if (0 != 0)
          goto label_3;
        else
          goto label_47;
      }
      else
        goto label_10;
label_8:
      RegistryKey registryKey2;
      if (registryKey2 != null)
      {
        string s = (string) registryKey2.GetValue(assemblyProductName);
        if (s != null)
        {
          string[] strArray = x294bd621a33dc533.SplitLicenseString(s);
          if (8 != 0)
          {
            customerID = int.Parse(strArray[0], (IFormatProvider) CultureInfo.InvariantCulture);
            if (0 != 0 || strArray[1] == x294bd621a33dc533.GenerateLicenseKeyForCustomer(assembly, customerID))
              return true;
            else
              goto label_15;
          }
          else
            goto label_30;
        }
      }
      else
        goto label_3;
label_9:
      if ((int) byte.MaxValue != 0)
        goto label_7;
label_10:
      this.WriteDebugMessage("novalue");
      goto label_47;
label_13:
      string[] strArray1;
      strArray1[2] = " and your machine name is ";
      strArray1[3] = Environment.MachineName;
      if (int.MaxValue != 0)
      {
        strArray1[4] = ". A clean install of the product will solve this issue.";
        x294bd621a33dc533.ShowMessage(string.Concat(strArray1), assemblyProductName);
        goto label_47;
      }
label_14:
      if (-2 == 0)
        goto label_47;
label_15:
      if (x294bd621a33dc533.IsDebug)
        goto label_17;
label_16:
      strArray1 = new string[5];
      strArray1[0] = "A license key was found, but it is not valid. This usually means you are building against a different version of the assembly than the one you activated. You are building against version ";
      strArray1[1] = ((object) assembly.GetName().Version).ToString();
      goto label_13;
label_17:
      this.WriteDebugMessage("licinvalid");
      if (0 != 0)
      {
        if (0 == 0)
          goto label_14;
        else
          goto label_7;
      }
      else
        goto label_16;
label_23:
      registryKey2 = Registry.LocalMachine.OpenSubKey("Software\\\\Divelements Limited\\\\Registration", false);
      goto label_8;
label_30:
      string s1;
      string[] strArray2;
      if (s1 == null)
      {
        if (0 == 0)
        {
          if (x294bd621a33dc533.IsDebug)
          {
            this.WriteDebugMessage("novalue");
            if (0 != 0)
            {
              if (int.MinValue != 0)
              {
                if (0 == 0)
                  goto label_26;
              }
              else
                goto label_9;
            }
            else
              goto label_23;
          }
          else
            goto label_23;
        }
        else
          goto label_39;
      }
      else
      {
        strArray2 = x294bd621a33dc533.SplitLicenseString(s1);
        customerID = int.Parse(strArray2[0], (IFormatProvider) CultureInfo.InvariantCulture);
        goto label_34;
      }
label_32:
      string[] strArray3;
      if (-2 != 0)
      {
        strArray3[3] = Environment.MachineName;
        strArray3[4] = ". A clean install of the product will solve this issue.";
        x294bd621a33dc533.ShowMessage(string.Concat(strArray3), assemblyProductName);
        goto label_23;
      }
      else
        goto label_23;
label_34:
      if (strArray2[1] == x294bd621a33dc533.GenerateLicenseKeyForCustomer(assembly, customerID))
        return true;
      if (x294bd621a33dc533.IsDebug)
        goto label_37;
label_31:
      strArray3 = new string[5]
      {
        "A license key was found, but it is not valid. This usually means you are building against a different version of the assembly than the one you activated. You are building against version ",
        ((object) assembly.GetName().Version).ToString(),
        " and your machine name is ",
        null,
        null
      };
      goto label_32;
label_37:
      this.WriteDebugMessage("licinvalid");
      goto label_31;
label_39:
      if (-2 != 0)
      {
        if (0 != 0 || 0 == 0)
          goto label_47;
        else
          goto label_13;
      }
      else
        goto label_42;
label_44:
      do
      {
        s1 = (string) registryKey1.GetValue(assemblyProductName);
        if (0 == 0)
          goto label_45;
      }
      while (15 != 0);
      goto label_8;
label_45:
      if (0 == 0)
      {
        if (0 != 0)
          goto label_2;
        else
          goto label_30;
      }
      else
        goto label_34;
label_47:
      return false;
    }

    private void WriteDebugMessage(string message)
    {
      string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Divelements.Licensing.log");
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(path, true))
          streamWriter.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ": " + message);
      }
      catch
      {
      }
    }

    public static string GenerateLicenseKeyForCustomer(string productName, string computerName, int majorVersion, int minorVersion, int buildVersion, int customerID)
    {
      string s = productName + computerName.ToUpper(CultureInfo.InvariantCulture) + majorVersion.ToString() + minorVersion.ToString() + buildVersion.ToString() + customerID.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      byte[] hash;
      using (SHA1 shA1 = SHA1.Create())
        hash = shA1.ComputeHash(Encoding.ASCII.GetBytes(s));
      return Convert.ToBase64String(hash);
    }

    public static string GenerateLicenseKeyForCustomer(Assembly assembly, int customerID)
    {
      string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(assembly);
      string machineName = Environment.MachineName;
      Version version = assembly.GetName().Version;
      return x294bd621a33dc533.GenerateLicenseKeyForCustomer(assemblyProductName, machineName, version.Major, version.Minor, version.Build, customerID);
    }

    private bool IsTypeKeyValid(string key, System.Type type)
    {
      string[] strArray = x294bd621a33dc533.SplitLicenseString(key);
      int customerID = int.Parse(strArray[0], (IFormatProvider) CultureInfo.InvariantCulture);
      return strArray[1] == this.GenerateLicenseKeyForType(type, customerID);
    }

    private string GenerateLicenseKeyForType(System.Type type, int customerID)
    {
      string s = type.FullName + ((object) type.Assembly.GetName().Version).ToString() + customerID.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      byte[] hash;
      using (SHA1 shA1 = SHA1.Create())
        hash = shA1.ComputeHash(Encoding.ASCII.GetBytes(s));
      return Convert.ToBase64String(hash);
    }
  }
}
