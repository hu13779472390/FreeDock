using System;
using System.Drawing;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    abstract class x890231ddf317379e : IDisposable, IMessageFilter
    {
        private DockingHints hints = DockingHints.TranslucentFill;
        private Rectangle bounds = Rectangle.Empty;
        private int x189455fe88a3b711 = 21;
        private const int x3ab50d2ad9712e32 = 256;
        private const int xacaf912f8e96627a = 257;
        private const int x9e72e1fc89a4d09f = 260;
        private const int x0099d1a3582c25df = 261;
        private const int xcd390c5181df4669 = 15;
        private const int WM_KEYDOWN = 0x0100;
        // 256
        private const int WM_KEYUP = 0x0101;
        // 257
        private const int WM_SYSKEYDOWN = 0x0104;
        // 260
        private const int WM_SYSKEYUP = 0x0105;
        // 261
        private const int WM_PAINT = 0x000F;
        // 15

        private const int VK_SHIFT = 0x0010; // 16
        private const int VK_CONTROL = 0x0010; // 17
        private const int VK_MENU = 0x0011; // 18

        private Form xa6607dfd4b3038ad;
        private Control control;
        private bool xd0c8332c4cbc4175;
        private bool x21480c2e0df4efcd;
        private x7a797590a9beb775 x74e209c76c4b5a3e;

        public event EventHandler x868a32060451dd2e;

        public x890231ddf317379e(Control control, DockingHints dockingHints, bool hollow, int tabStripSize) : this(control, dockingHints, hollow)
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
                    this.hints = dockingHints;
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
            this.control = control;
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

        protected void xe5e4149f382149cc(Rectangle bounds, bool x067d6ddeefb41622)
        {
            if (this.bounds == bounds)
                return;
            if (this.hints == DockingHints.RubberBand)
            {
                this.x45e11bb29ea5a4f9();
            }

            if (this.hints != DockingHints.RubberBand)
            {
                this.x74e209c76c4b5a3e.xf00ba4096f8180b1(bounds, x067d6ddeefb41622);
                return;
            }
            else
            {
                if (this.x21480c2e0df4efcd)
                {
                    x130e0425ae2d4496.xda2defffc25953e0(null, bounds, x067d6ddeefb41622, this.x189455fe88a3b711);
                }
                else
                {
                    x130e0425ae2d4496.xe5e0d1644c72aafd(null, bounds);
                }

                this.bounds = bounds;
                this.xd0c8332c4cbc4175 = x067d6ddeefb41622;
                return;
            }
        }

        protected void x11972e8742c570b8()
        {
            if (this.hints == DockingHints.RubberBand)
                this.x45e11bb29ea5a4f9();
            else
                this.x74e209c76c4b5a3e.Hide();
        }

        private void x45e11bb29ea5a4f9()
        {
            if (this.bounds != Rectangle.Empty)
            {
                if (!this.x21480c2e0df4efcd)
                {
                    x130e0425ae2d4496.xe5e0d1644c72aafd(null, this.bounds);
                }
                else
                {
                    x130e0425ae2d4496.xda2defffc25953e0(null, this.bounds, this.xd0c8332c4cbc4175, this.x189455fe88a3b711);
                }
            }
            this.bounds = Rectangle.Empty;
        }

        public virtual void Commit()
        {
            this.Dispose();
        }

        public virtual void Cancel()
        {
            this.Dispose();
            if (this.x868a32060451dd2e != null)
                this.x868a32060451dd2e(this, EventArgs.Empty);
        }
        // reviewed
        public virtual void Dispose()
        {
            if (this.control != null)
                this.control.MouseCaptureChanged -= new EventHandler(this.x772288dc6422a53d);

            this.x11972e8742c570b8();
            if (this.hints == DockingHints.TranslucentFill)
            {
                this.x74e209c76c4b5a3e.Dispose();
                this.x74e209c76c4b5a3e = null;
            }

            if (this.xa6607dfd4b3038ad != null)
                this.xa6607dfd4b3038ad.Deactivate -= new EventHandler(this.xbf6ca0f637696dc9);
            Application.RemoveMessageFilter(this);
            this.xa6607dfd4b3038ad = null;
            this.control = null;
        }

        private void xbf6ca0f637696dc9(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            this.Cancel();
        }

        private void x7ec1a570ae92aafb()
        {
            if (this.hints == DockingHints.RubberBand)
                this.x45e11bb29ea5a4f9();
        }

        public abstract void OnMouseMove(System.Drawing.Point position);

        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                    this.x7ec1a570ae92aafb();
                    return false;
                case WM_KEYDOWN:
                    if (m.WParam.ToInt32() == VK_CONTROL)
                    {
                        this.OnMouseMove(Cursor.Position);
                        return false;
                    }
                    else
                    {
                        if (m.WParam.ToInt32() != VK_SHIFT)
                        {
                            this.Cancel();
                        }
                        return true;
                    }
                case WM_KEYUP:
                case WM_SYSKEYDOWN:
                case WM_SYSKEYUP:
                default:
                    break;
            }









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

                goto label_13;
            }
            label_21:
            wparam3 = m.WParam;
            if ((uint)wparam3 - (uint)wparam1 < 0U)
                goto label_12;
            else
                goto label_17;
            label_25:
            this.x7ec1a570ae92aafb();

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
            if (m.Msg == 257)
                goto label_23;
            else
                goto label_22;

            label_29:
            return false;
        }
    }
}
