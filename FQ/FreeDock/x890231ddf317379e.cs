using System;
using System.Drawing;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    abstract class x890231ddf317379e : IDisposable, IMessageFilter
    {
        private DockingHints x48cee1d69929b4fe = DockingHints.TranslucentFill;
        private Rectangle xca9fb28c817965fb = Rectangle.Empty;
        private int x189455fe88a3b711 = 21;
        private const int x3ab50d2ad9712e32 = 256;
        private const int xacaf912f8e96627a = 257;
        private const int x9e72e1fc89a4d09f = 260;
        private const int x0099d1a3582c25df = 261;
        private const int xcd390c5181df4669 = 15;
        private Form xa6607dfd4b3038ad;
        private Control x43bec302f92080b9;
        private bool xd0c8332c4cbc4175;
        private bool x21480c2e0df4efcd;
        private x7a797590a9beb775 x74e209c76c4b5a3e;

        public event EventHandler x868a32060451dd2e;

        public x890231ddf317379e(Control control, DockingHints dockingHints, bool hollow, int tabStripSize)
      : this(control, dockingHints, hollow)
        {
            this.x189455fe88a3b711 = tabStripSize;
        }

        public x890231ddf317379e(Control control, DockingHints dockingHints, bool hollow)
        {
            if (0 != 0)
            {
                bool flag;
                if (true)
                    goto label_20;
            }
            else
                goto label_22;
            label_16:
            bool flag1 = false;
            do
            {
                flag1 = OSFeature.Feature.IsPresent(OSFeature.LayeredWindows);
                if (false)
                    ;
                if (dockingHints == DockingHints.TranslucentFill && !flag1)
                    goto label_18;
                label_13:
                do
                {
                    this.x48cee1d69929b4fe = dockingHints;
                    if (0 == 0)
                    {
                        this.xa6607dfd4b3038ad = control.FindForm();
                        do
                        {
                            if (this.xa6607dfd4b3038ad != null)
                                this.xa6607dfd4b3038ad.Deactivate += new EventHandler(this.xbf6ca0f637696dc9);
                            control.MouseCaptureChanged += new EventHandler(this.x772288dc6422a53d);
                            if (4 != 0)
                                Application.AddMessageFilter((IMessageFilter)this);
                            else
                                goto label_3;
                        }
                        while (0 != 0);
                        label_2:
                        if (dockingHints == DockingHints.TranslucentFill)
                            this.x74e209c76c4b5a3e = new x7a797590a9beb775(hollow);
                        else
                            continue;
                        label_3:
                        if (true)
                            goto label_17;
                        else
                            goto label_2;
                    }
                    else
                        goto label_16;
                }
                while (false);
                continue;
                label_18:
                dockingHints = DockingHints.RubberBand;
                goto label_13;
            }
            while (false);
            goto label_19;
            label_17:
            return;
            label_19:
            if (true)
            {
                if ((uint)(flag1 ? 1 : 0) - (uint)(hollow ? 1 : 0) >= 0U)
                    return;
                else
                    goto label_22;
            }
            label_20:
            this.x21480c2e0df4efcd = hollow;
            goto label_16;
            label_22:
            this.x43bec302f92080b9 = control;
            if (true)
                goto label_20;
        }

        private void x772288dc6422a53d(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            this.Cancel();
        }

        internal static bool xca8cda6e489f8dd8()
        {
            bool flag = false;
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                flag = Environment.OSVersion.Version >= new Version(5, 0, 0, 0);
            return flag;
        }

        protected void xe5e4149f382149cc(Rectangle xda73fcb97c77d998, bool x067d6ddeefb41622)
        {
            if (this.xca9fb28c817965fb == xda73fcb97c77d998)
                return;
            if (this.x48cee1d69929b4fe == DockingHints.RubberBand)
                goto label_10;
            label_7:
            if (this.x48cee1d69929b4fe != DockingHints.RubberBand)
            {
                this.x74e209c76c4b5a3e.xf00ba4096f8180b1(xda73fcb97c77d998, x067d6ddeefb41622);
                return;
            }
            else
            {
                if (this.x21480c2e0df4efcd)
                {
                    x130e0425ae2d4496.xda2defffc25953e0((Control)null, xda73fcb97c77d998, x067d6ddeefb41622, this.x189455fe88a3b711);
                    if (0 != 0)
                        return;
                }
                else
                    x130e0425ae2d4496.xe5e0d1644c72aafd((Control)null, xda73fcb97c77d998);
                do
                {
                    this.xca9fb28c817965fb = xda73fcb97c77d998;
                }
                while (0 != 0);
                this.xd0c8332c4cbc4175 = x067d6ddeefb41622;
                return;
            }
            label_10:
            this.x45e11bb29ea5a4f9();
            goto label_7;
        }

        protected void x11972e8742c570b8()
        {
            if (this.x48cee1d69929b4fe == DockingHints.RubberBand)
                this.x45e11bb29ea5a4f9();
            else
                this.x74e209c76c4b5a3e.Hide();
        }

        private void x45e11bb29ea5a4f9()
        {
            if (this.xca9fb28c817965fb != Rectangle.Empty)
                goto label_2;
            label_1:
            this.xca9fb28c817965fb = Rectangle.Empty;
            return;
            label_2:
            if (!this.x21480c2e0df4efcd)
            {
                x130e0425ae2d4496.xe5e0d1644c72aafd((Control)null, this.xca9fb28c817965fb);
                goto label_1;
            }
            else
            {
                x130e0425ae2d4496.xda2defffc25953e0((Control)null, this.xca9fb28c817965fb, this.xd0c8332c4cbc4175, this.x189455fe88a3b711);
                goto label_1;
            }
        }

        public virtual void Commit()
        {
            this.Dispose();
        }

        public virtual void Cancel()
        {
            this.Dispose();
            if (this.x868a32060451dd2e == null)
                return;
            this.x868a32060451dd2e((object)this, EventArgs.Empty);
        }

        public virtual void Dispose()
        {
            if (this.x43bec302f92080b9 == null)
                goto label_9;
            label_8:
            this.x43bec302f92080b9.MouseCaptureChanged -= new EventHandler(this.x772288dc6422a53d);
            label_9:
            this.x11972e8742c570b8();
            if (this.x48cee1d69929b4fe == DockingHints.TranslucentFill)
                goto label_6;
            label_1:
            do
            {
                if (this.xa6607dfd4b3038ad == null)
                {
                    if (8 == 0)
                        goto label_4;
                }
                else
                    goto label_5;
                label_3:
                Application.RemoveMessageFilter((IMessageFilter)this);
                label_4:
                this.xa6607dfd4b3038ad = (Form)null;
                this.x43bec302f92080b9 = (Control)null;
                continue;
                label_5:
                this.xa6607dfd4b3038ad.Deactivate -= new EventHandler(this.xbf6ca0f637696dc9);
                goto label_3;
            }
            while (0 != 0);
            return;
            label_6:
            if (0 == 0)
            {
                this.x74e209c76c4b5a3e.Dispose();
                this.x74e209c76c4b5a3e = (x7a797590a9beb775)null;
                goto label_1;
            }
            else
                goto label_8;
        }

        private void xbf6ca0f637696dc9(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            this.Cancel();
        }

        private void x7ec1a570ae92aafb()
        {
            if (this.x48cee1d69929b4fe != DockingHints.RubberBand)
                return;
            this.x45e11bb29ea5a4f9();
        }

        public abstract void OnMouseMove(System.Drawing.Point position);

        public bool PreFilterMessage(ref Message m)
        {
            IntPtr wparam1 = default(IntPtr);
            if (m.Msg != 15)
                goto label_26;
            else
                goto label_25;
            label_1:

            IntPtr wparam2;
            IntPtr wparam3;
            if (m.Msg > 264)
            {
//                if ((uint)wparam1 - (uint)wparam2 > uint.MaxValue)
//                {
//                    if ((uint)wparam2 - (uint)wparam2 <= uint.MaxValue)
//                        goto label_6;
//                }
//                else if ((uint)wparam2 - (uint)wparam3 > uint.MaxValue)
//                {
//                    if (((int)(uint)wparam2 | -2) != 0)
//                        goto label_19;
//                    else
//                        goto label_17;
//                }
//                else
                goto label_29;
            }
            else
                goto label_7;
            label_4:
            return true;
            label_7:
            this.Cancel();
            goto label_4;
            label_5:
            if (m.Msg >= 256)
                goto label_1;
            else
                goto label_29;
            label_6:
            if (wparam2.ToInt32() == 18)
                return true;
            else
                goto label_5;
            label_8:
            if (m.Msg == 261)
                goto label_14;
            else
                goto label_5;
            label_12:

            goto label_8;


            label_13:
            if (m.Msg != 260)
                goto label_8;
            label_14:
            wparam2 = m.WParam;
            goto label_6;
            label_17:
            if (wparam3.ToInt32() == 16)
                return true;
            else
                goto label_13;
            label_19:
            while (m.Msg != 257)
            {
                if (((int)(uint)wparam1 & 0) == 0)
                {
                    if ((uint)wparam1 - (uint)wparam1 < 0U)
                    {
                        if (0 != 0)
                            goto label_1;
                        else
                            goto label_12;
                    }
                    else
                        goto label_13;
                }
            }
            label_21:
            wparam3 = m.WParam;
            if ((uint)wparam3 - (uint)wparam1 < 0U)
                goto label_12;
            else
                goto label_17;
            label_25:
            this.x7ec1a570ae92aafb();
            IntPtr num1;
            IntPtr num2;
            if (false)
                goto label_14;
            label_26:
            if (m.Msg == 256)
                goto label_23;
            else
                goto label_27;
            label_22:
            if (m.Msg == 256)
                goto label_21;
            else
                goto label_19;
            label_23:
            wparam1 = m.WParam;
            if (wparam1.ToInt32() == 17)
            {
                this.OnMouseMove(Cursor.Position);
                return false;
            }
            else
                goto label_22;
            label_27:
            if (-1 != 0)
            {
                if ((int)byte.MaxValue == 0 || m.Msg == 257)
                    goto label_23;
                else
                    goto label_22;
            }
            else
                goto label_5;
            label_29:
            return false;
        }
    }
}
