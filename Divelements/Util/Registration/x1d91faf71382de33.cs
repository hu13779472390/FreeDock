using Microsoft.Win32;
using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Divelements.Util.Registration
{
    internal class x1d91faf71382de33 : xbd7c5470fc89975b
    {
        private static bool x5ee2d89e2d4d8414;
        private bool xc71dae9225f5522a;

        public override bool Evaluation
        {
            get
            {
                return true;
            }
        }

        public override bool Locked
        {
            get
            {
                return this.xc71dae9225f5522a;
            }
        }

        public x1d91faf71382de33(bool expires)
        {
            string[] strArray;
            string assemblyProductName;
            if (0 == 0)
            {
                if (!expires)
                    return;
                this.xc71dae9225f5522a = this.xa1d7cab22b1cb36a();
                label_4:
                if (this.xc71dae9225f5522a)
                    goto label_11;
                else
                    goto label_5;
                label_2:
                if (4 != 0)
                    return;
                else
                    goto label_8;
                label_3:
                if (4 == 0)
                    goto label_4;
                label_5:
                if (true)
                {
                    if (0 != 0)
                    {
                        if (((expires ? 1 : 0) & 0) != 0)
                            goto label_18;
                    }
                    else
                        goto label_2;
                }
                else
                    goto label_11;
                label_8:
                if (-1 != 0)
                {
                    if (true)
                        return;
                    else
                        goto label_2;
                }
                else
                    goto label_3;
                label_11:
                if (x1d91faf71382de33.x5ee2d89e2d4d8414)
                {
                    if (0 != 0)
                    {
                        if (true)
                            goto label_3;
                    }
                    else
                        goto label_8;
                }
                else
                {
                    assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(Assembly.GetExecutingAssembly());
                    goto label_18;
                }
                label_15:
                strArray[2] = " has expired. The software will therefore now be limited, but you will not lose any work.";
                strArray[3] = Environment.NewLine;
                goto label_13;
                label_18:
                if (((expires ? 1 : 0) & 0) == 0)
                {
                    strArray = new string[5];
                    strArray[0] = "Your evaluation period for ";
                    strArray[1] = assemblyProductName;
                    goto label_15;
                }
                else
                    goto label_4;
            }
            label_13:
            strArray[4] = Environment.NewLine;
            x294bd621a33dc533.ShowMessage(string.Concat(strArray) + "You can purchase " + assemblyProductName + " online. After installing the commercial version, full functionality will be restored.", assemblyProductName);
            x1d91faf71382de33.x5ee2d89e2d4d8414 = true;
        }

        public x1d91faf71382de33()
      : this(true)
        {
        }

        private bool xa1d7cab22b1cb36a()
        {
            AssemblyName name1 = Assembly.GetExecutingAssembly().GetName();
            if (3 != 0)
                goto label_11;
            label_3:
            RegistryKey registryKey;
            if (registryKey == null)
            {
                try
                {
                    registryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\.NETFramework");
                }
                catch
                {
                    return true;
                }
            }
            DateTime dateTime = DateTime.MinValue;
            string name2;
            long num;
            try
            {
                string s = (string)registryKey.GetValue(name2);
                if (0 == 0 || ((int)(uint)num & 0) != 0)
                    ;
                if (s != null)
                {
                    dateTime = DateTime.FromFileTime(long.Parse(s));
                }
                else
                {
                    registryKey.SetValue(name2, (object)DateTime.Now.ToFileTime().ToString());
                    return false;
                }
            }
            finally
            {
                registryKey.Close();
            }
            return DateTime.Now > dateTime + new TimeSpan(60, 0, 0, 0);
            label_11:
            string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(Assembly.GetExecutingAssembly());
            using (SHA1 shA1 = SHA1.Create())
            {
                object[] objArray = new object[6];
                bool flag;
                do
                {
                    objArray[0] = (object)assemblyProductName;
                    if (true)
                    {
                        do
                        {
                            if (true)
                            {
                                objArray[1] = (object)name1.Version.Major;
                                objArray[2] = (object)".";
                            }
                            objArray[3] = (object)name1.Version.Minor;
                            objArray[4] = (object)".";
                            objArray[5] = (object)name1.Version.Build;
                            string s = string.Concat(objArray);
                            name2 = Convert.ToBase64String(shA1.ComputeHash(Encoding.Default.GetBytes(s)));
                        }
                        while (0 != 0);
                    }
                    else
                        break;
                }
                while (false);
            }
            registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\.NETFramework", true);
            goto label_3;
        }
    }
}
