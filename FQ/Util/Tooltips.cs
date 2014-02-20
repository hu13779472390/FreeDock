using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Security;

namespace FQ.Util
{
    class Tooltips : IDisposable
    {
        private bool xeefb7b23d49f09bc = true;

        private const int xdbb7427772b219d6 = 128;
        private const int xb644deafcaa222c4 = 2;
        private const int xb8a822e576f3bf60 = 1;
        private Control control;
        private bool x364c1e3b189d47fe;
        private bool x0e75cd3866dbb930;
        private Point location;
        private xab7df35839b7399e tipForm;
        private Timer timer;
        private Form x9238f6a5f034aeb5;

        private const int SWP_SHOWWINDOW = 0x0040;
        private const int SWP_NOACTIVATE = 0x0010;

        public bool xa6e4f463e64a5987
        {
            get
            {
                return this.xeefb7b23d49f09bc;
            }
            set
            {
                this.xeefb7b23d49f09bc = value;
            }
        }

        public bool x9ab519b46dd91330
        {
            get
            {
                return this.tipForm.x9ab519b46dd91330;
            }
            set
            {
                this.tipForm.x9ab519b46dd91330 = value;
            }
        }

        public event Tooltips.x58986a4a0b75e5b5 x9b21ee8e7ceaada3;

        public Tooltips(Control control)
        {
            this.control = control;
            control.MouseMove += new MouseEventHandler(this.x51529e0468abe27e);
            control.MouseLeave += new EventHandler(this.x664829383a59617c);
            control.MouseDown += new MouseEventHandler(this.x1c8953a8a8447816);
            control.MouseWheel += new MouseEventHandler(this.x5e1cbc67acfe3317);
            control.Disposed += new EventHandler(this.x77d9086325b6e538);
            control.FontChanged += new EventHandler(this.xb27df3b0091b2a36);
            this.tipForm = new Tooltips.xab7df35839b7399e(this);
            this.tipForm.MouseMove += new MouseEventHandler(this.x1aaaf41037533886);
            this.timer = new Timer();
            this.timer.Interval = SystemInformation.DoubleClickTime;
            this.timer.Tick += new EventHandler(this.x79a58a5d2c65c5a4);
        }

//        [DllImport("user32.dll")]
//        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int flags);

        public void Dispose()
        {
            if (this.x0e75cd3866dbb930)
                return;

            this.x47c79a4d207183de();
            this.tipForm.MouseMove -= new MouseEventHandler(this.x1aaaf41037533886);
            this.tipForm.Dispose();
            this.tipForm = null;
            this.control.MouseMove -= new MouseEventHandler(this.x51529e0468abe27e);
            this.control.MouseLeave -= new EventHandler(this.x664829383a59617c);
            this.control.MouseDown -= new MouseEventHandler(this.x1c8953a8a8447816);
            this.control.MouseWheel -= new MouseEventHandler(this.x5e1cbc67acfe3317);
            this.control.Disposed -= new EventHandler(this.x77d9086325b6e538);
            this.control.FontChanged -= new EventHandler(this.xb27df3b0091b2a36);
            this.control = null;
            this.timer.Tick -= new EventHandler(this.x79a58a5d2c65c5a4);
            this.timer.Dispose();
            this.x0e75cd3866dbb930 = true;
            return;
        }

        private static bool x7fb2e1ce54a27086()
        {
            bool flag = false;
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                flag = Environment.OSVersion.Version >= new Version(5, 1, 0, 0);
            return flag;
        }

//        [SecuritySafeCritical]
//        public void x4402a69f607144e3(Point point, string text)
//        {
//            this.xa6607dfd4b3038ad.Text = text;
//  
//            Size size;
//            do
//            {
//                size = Size.Ceiling(this.xa6607dfd4b3038ad.MeasureText(text));
//                size.Height += 4;
//                size.Width += 4;
//                point.Y += 19;
//
//                Screen screen = Screen.FromPoint(point);
//
//                if (point.X < screen.Bounds.Left)
//                    point.X = screen.Bounds.Left;
//
//                do
//                {
//                    if (point.X + size.Width <= screen.Bounds.Right)
//                    {
//                        if (point.Y < screen.Bounds.Top)
//                        {
//                            point.Y = screen.Bounds.Top;
//
//                            if (point.Y + size.Height > screen.Bounds.Bottom)
//                            {
//                                point.Y = screen.Bounds.Bottom - size.Height;
//                                continue;
//                            }
//                            else
//                                goto label_17;
//                        }
//                    }
//                    else
//                    {
//                        point.X = screen.Bounds.Right - size.Width;
//                        if (point.X >= screen.Bounds.Left)
//                        {
//
//                            if (point.Y < screen.Bounds.Top)
//                            {
//                                point.Y = screen.Bounds.Top;
//
//                                if (point.Y + size.Height > screen.Bounds.Bottom)
//                                {
//                                    point.Y = screen.Bounds.Bottom - size.Height;
//                                    continue;
//                                }
//                                else
//                                    goto label_17;
//                            }
//
//                            if (point.Y + size.Height > screen.Bounds.Bottom)
//                            {
//                                point.Y = screen.Bounds.Bottom - size.Height;
//                                continue;
//                            }
//                            else
//                                goto label_17;
//                        }
//                        else
//                            return;
//
//                    }
//                    point.Y = screen.Bounds.Top;
//                    if (point.Y + size.Height > screen.Bounds.Bottom)
//                    {
//                        point.Y = screen.Bounds.Bottom - size.Height;
//                        continue;
//                    }
//                    else
//                        goto label_17;
//
//                }
//                while (0 != 0);
//                if (point.Y >= screen.Bounds.Top)
//                {
//                    ++point.X;
//                }
//                else
//                {
//                    return;
//                }
//            }
//            while (0 != 0);
//
//            label_17:
//            Tooltips.SetWindowPos(this.xa6607dfd4b3038ad.Handle, -1, point.X, point.Y, size.Width, size.Height, 80);
//            VisualStyleElement normal = VisualStyleElement.ToolTip.Standard.Normal;
//            if (Application.RenderWithVisualStyles)
//            {
//                if (VisualStyleRenderer.IsElementDefined(normal))
//                {
//                    using (Graphics graphics = this.xa6607dfd4b3038ad.CreateGraphics())
//                    {
//                        this.xa6607dfd4b3038ad.Region = new VisualStyleRenderer(normal).GetBackgroundRegion((IDeviceContext)graphics, this.xa6607dfd4b3038ad.ClientRectangle);
//                    }
//                }
//   
//            }
//
//            this.xa6607dfd4b3038ad.Invalidate();
//            this.x364c1e3b189d47fe = true;
//            if (this.x9238f6a5f034aeb5 != null)
//                this.x9238f6a5f034aeb5.Deactivate -= new EventHandler(this.xdef19f2ef265bf1e);
//
//            this.x9238f6a5f034aeb5 = this.x624fa8b017460890(this.control);
//            if (this.x9238f6a5f034aeb5 == null)
//                return;
//            this.x9238f6a5f034aeb5.Deactivate += new EventHandler(this.xdef19f2ef265bf1e);
//            this.xa6607dfd4b3038ad.Owner = this.x9238f6a5f034aeb5;
//            return;
//
//
//        }
//


        [SecuritySafeCritical]
        public void x4402a69f607144e3(Point point, string text)
        {
            this.tipForm.Text = text;
            if ((int) byte.MaxValue == 0)
            {
                if (0 == 0)
                    goto label_5;
            }
            else
                goto label_43;
            label_3:
            this.x9238f6a5f034aeb5 = this.x624fa8b017460890(this.control);
            if (0 == 0 && this.x9238f6a5f034aeb5 == null)
                return;
            this.x9238f6a5f034aeb5.Deactivate += new EventHandler(this.xdef19f2ef265bf1e);
            this.tipForm.Owner = this.x9238f6a5f034aeb5;
            return;
            label_5:
            do
            {
                this.tipForm.Invalidate();
                this.x364c1e3b189d47fe = true;
                if (0 == 0)
                {
                    if (15 != 0)
                    {
                        if (this.x9238f6a5f034aeb5 != null)
                            this.x9238f6a5f034aeb5.Deactivate -= new EventHandler(this.xdef19f2ef265bf1e);
                        else
                            break;
                    }
                    else
                        goto label_41;
                }
                else
                    break;
            }
            while (0 != 0);
            goto label_3;
            label_41:
            return;
            label_43:
            Size size;
            do
            {
                size = Size.Ceiling(this.tipForm.x0a8f2a18d3b53839(text));
                label_44:
                size.Height += 4;
                if (8 != 0)
                {
                    size.Width += 4;
                    point.Y += 19;
                    label_35:
                    if (0 == 0)
                    {
                        Screen screen = Screen.FromPoint(point);
                        do
                        {
                            if (point.X < screen.Bounds.Left)
                                goto label_37;
                            else
                                goto label_33;
                            label_32:
                            continue;
                            label_33:
                            if (2 == 0)
                                goto label_34;
                            label_31:
                            if (0 != 0)
                                goto label_32;
                            else
                                break;
                            label_34:
                            if (0 == 0)
                            {
                                if (0 != 0)
                                {
                                    if (0 != 0)
                                        goto label_44;
                                    else
                                        goto label_31;
                                }
                                else
                                    goto label_32;
                            }
                            else
                                goto label_35;
                            label_37:
                            point.X = screen.Bounds.Left;
                            goto label_32;
                        }
                        while (0 != 0);
                        do
                        {
                            if (point.X + size.Width <= screen.Bounds.Right)
                            {
                                if (0 == 0)
                                    goto label_26;
                            }
                            else
                                goto label_29;
                            label_25:
                            point.Y = screen.Bounds.Top;
                            goto label_27;
                            label_26:
                            if (point.Y < screen.Bounds.Top)
                                goto label_25;
                            label_27:
                            if (point.Y + size.Height > screen.Bounds.Bottom)
                            {
                                if (-2 != 0)
                                {
                                    point.Y = screen.Bounds.Bottom - size.Height;
                                    continue;
                                }
                                else
                                    break;
                            }
                            else
                                goto label_17;
                            label_29:
                            point.X = screen.Bounds.Right - size.Width;
                            if (point.X >= screen.Bounds.Left)
                                goto label_26;
                            else
                                goto label_19;
                        }
                        while (0 != 0);
                        if (point.Y >= screen.Bounds.Top)
                            ++point.X;
                        else
                            goto label_47;
                    }
                    else
                        goto label_42;
                }
                else
                    goto label_9;
            }
            while (0 != 0);
            goto label_46;
            label_9:
            VisualStyleElement normal;
            if (!VisualStyleRenderer.IsElementDefined(normal))
            {
                if (0 == 0)
                    goto label_5;
                else
                    goto label_17;
            }
            label_12:
            using (Graphics graphics = this.tipForm.CreateGraphics())
            {
                this.tipForm.Region = new VisualStyleRenderer(normal).GetBackgroundRegion((IDeviceContext) graphics, this.tipForm.ClientRectangle);
                goto label_5;
            }
            label_17:

//            Tooltips.SetWindowPos(this.xa6607dfd4b3038ad.Handle, -1, point.X, point.Y, size.Width, size.Height, SWP_SHOWWINDOW | SWP_NOACTIVATE /*80*/);

            this.tipForm.Size = size;
            this.tipForm.Location = point;
//            this.tipForm.Show();

            normal = VisualStyleElement.ToolTip.Standard.Normal;
            if (Application.RenderWithVisualStyles)
            {
                if (int.MinValue == 0)
                {
                    if (int.MaxValue == 0)
                        goto label_43;
                    else
                        goto label_9;
                }
                else if (0 == 0)
                    goto label_9;
                else
                    goto label_12;
            }
            else
                goto label_5;
            label_47:
            return;
            label_19:
            return;
            label_42:
            return;
            label_46:
            if (0 == 0)
                goto label_17;
            else
                goto label_5;
        }

        public void x47c79a4d207183de()
        {
            this.tipForm.Owner = null;
            this.tipForm.Visible = false;
            this.x364c1e3b189d47fe = false;
            if (this.x9238f6a5f034aeb5 == null)
                return;
            this.x9238f6a5f034aeb5.Deactivate -= new EventHandler(this.xdef19f2ef265bf1e);
            this.x9238f6a5f034aeb5 = null;
        }

        private void x51529e0468abe27e(object xe0292b9ed559da7d, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None)
                goto label_19;
            else
                goto label_22;

            label_1:
            goto label_4;

            label_2:
            ;
            label_3:
            return;
            label_4:
            goto label_21;

            label_5:
            string xb41faee6912a2313;
            if (xb41faee6912a2313 != this.tipForm.Text)
            {
                this.x4402a69f607144e3(Cursor.Position, xb41faee6912a2313);
                return;
            }
            else
                goto label_1;

            label_19:
            if (!this.x364c1e3b189d47fe)
                goto label_8;
            else
                goto label_20;

            label_6:
            Point point;
            this.location = point;
            this.timer.Enabled = false;
            this.timer.Enabled = true;
            return;

            label_8:
            point = new Point(e.X, e.Y);
            if (!(point != this.location))
                return;
 
            goto label_6;

            label_20:
            xb41faee6912a2313 = this.x9b21ee8e7ceaada3(new Point(e.X, e.Y));

            if (xb41faee6912a2313 != null)
                goto label_13;
            label_11:
            this.x47c79a4d207183de();
            return;
            label_13:

            if (xb41faee6912a2313.Length != 0)
            {
                goto label_5;
            }
            else
                goto label_11;

            label_21:
            return;

            label_22:
            ;
        }

        private void x79a58a5d2c65c5a4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            string xb41faee6912a2313 = "";
            this.timer.Enabled = false;
            bool flag1;

            goto label_17;
            label_2:
            bool flag2;
   
            if (flag2 && this.control.Visible)
            {
                this.x4402a69f607144e3(Cursor.Position, xb41faee6912a2313);
            }
            return;

            label_4:
            int num;
            flag2 = num != 0;
            goto label_2;
            label_7:
            Form activeForm;
            Form form;
            num = activeForm != form ? (activeForm == form.Owner ? 1 : 0) : 1;
            goto label_4;

            label_17:
            Point point = this.control.PointToClient(Cursor.Position);
            Rectangle clientRectangle = this.control.ClientRectangle;

            if (clientRectangle.Contains(point))
            {
                xb41faee6912a2313 = this.x9b21ee8e7ceaada3(point);
                if (xb41faee6912a2313 == null)
                    goto label_16;
            }

            goto label_14;
            label_16:
            return;

            label_14:
            if (xb41faee6912a2313.Length == 0)
                return;
            form = this.x624fa8b017460890(this.control);
            activeForm = Form.ActiveForm;
            if (form == null || activeForm == null)
            {
                num = 0;
                goto label_4;
            }
            else
                goto label_7;


        }

        private Form x624fa8b017460890(Control control)
        {
            while (control.Parent != null)
                control = control.Parent;
            return control as Form;
        }

        private void x664829383a59617c(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            if (this.x364c1e3b189d47fe)
                this.x47c79a4d207183de();
            this.timer.Enabled = false;
        }

        private void x1c8953a8a8447816(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
        {
            if (this.x364c1e3b189d47fe)
                this.x47c79a4d207183de();
            this.timer.Enabled = false;
        }

        private void x5e1cbc67acfe3317(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
        {
            if (this.x364c1e3b189d47fe)
                this.x47c79a4d207183de();
            this.timer.Enabled = false;
        }

        private void x1aaaf41037533886(object sender, MouseEventArgs e)
        {
            this.x47c79a4d207183de();
        }

        private void xdef19f2ef265bf1e(object sender, EventArgs e)
        {
            this.x47c79a4d207183de();
        }

        private void x77d9086325b6e538(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            this.Dispose();
        }

        private void xb27df3b0091b2a36(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            this.tipForm.Font = this.control.Font;
        }

        private class xab7df35839b7399e : Form
        {
            private const int x3e8b9d6faeff6586 = 32;
            private const int x2b7f5d3ca7ec1edf = -2147483648;
            //            private const int xd708511d2241a4fb = 131072;
            //            private const int x836e53e090609b16 = 4132;
            //0x80000000
            private const int WS_GROUP = 0x00020000;
            private const int WS_EX_NOACTIVATE = 0x08000000;
            private const int SPI_GETDROPSHADOW = 0x1024;
            private Tooltips tooltips;
            private TextFormatFlags textFormatFlags;

            public bool x9ab519b46dd91330
            {
                get
                {
                    return (this.textFormatFlags & TextFormatFlags.HidePrefix) != TextFormatFlags.HidePrefix;
                }
                set
                {
                    if (value)
                    {
                        this.textFormatFlags |= TextFormatFlags.HidePrefix;
                        this.textFormatFlags &= ~TextFormatFlags.NoPrefix;
                    }
                    else
                    {
                        this.textFormatFlags &= ~TextFormatFlags.HidePrefix;
                        this.textFormatFlags |= TextFormatFlags.NoPrefix;
                    }
                }
            }

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams createParams = base.CreateParams;
                    if (this.tooltips != null)
                    {
                        if (this.tooltips.xa6e4f463e64a5987)
                        {
                            if (Tooltips.xab7df35839b7399e.x3b1aa41797c18588)
                            {
                                createParams.ClassStyle |= WS_GROUP;
                            }


                        }
//                        createParams.ExStyle |= 0x00000080 | 0x00000004;
                    }
                    return createParams;
                }
            }
            // DROPSHADOW?
            private static bool x3b1aa41797c18588
            {
                get
                {
//                    int i = 0;
//                    if (Tooltips.x7fb2e1ce54a27086())
//                    {
//                        Tooltips.xab7df35839b7399e.SystemParametersInfo(SPI_GETDROPSHADOW, 0, ref i, 0);
//                        return Convert.ToBoolean(i);
//                    }
                    return false;
                }
            }

            public xab7df35839b7399e(Tooltips tooltips)
            {
                this.tooltips = tooltips;
                this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
                this.Font = tooltips.control.Font;
                this.textFormatFlags = TextFormatFlags.NoClipping | TextFormatFlags.VerticalCenter;
                this.ShowInTaskbar = false;
                this.FormBorderStyle = FormBorderStyle.None;
                this.ControlBox = false;
                this.StartPosition = FormStartPosition.Manual;
            }
            //            [DllImport("user32.dll")]
            //            private static extern bool SystemParametersInfo(int nAction, int nParam, ref int i, int nUpdate);
            public SizeF x0a8f2a18d3b53839(string text)
            {
                SizeF sizeF1;
                using (Graphics graphics = this.CreateGraphics())
                {
                    VisualStyleElement normal = VisualStyleElement.ToolTip.Standard.Normal;
                    if (Application.RenderWithVisualStyles)
                    {
                        if (VisualStyleRenderer.IsElementDefined(normal))
                        {
                            VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(normal);
                            Rectangle textExtent = visualStyleRenderer.GetTextExtent(graphics, text, TextFormatFlags.Default);
                            sizeF1 = (SizeF)visualStyleRenderer.GetBackgroundExtent(graphics, textExtent).Size;
                            return sizeF1;
                        }
                    }
                    SizeF sizeF2 = (SizeF)TextRenderer.MeasureText(graphics, text, this.Font, new Size(SystemInformation.PrimaryMonitorSize.Width, int.MaxValue), this.textFormatFlags);
                    sizeF2.Width -= 2f;
                    sizeF2.Height += 2f;
                    sizeF1 = sizeF2;
                }
                return sizeF1;
            }

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                VisualStyleElement normal = VisualStyleElement.ToolTip.Standard.Normal;

                if (!Application.RenderWithVisualStyles)
                    goto label_8;
                else
                    goto label_10;

                label_1:
                Rectangle clientRectangle;
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, clientRectangle, SystemColors.InfoText, this.textFormatFlags);
                return;

                label_2:
                Pen pen1 = SystemPens.InfoText;

                label_3:
                Pen pen2 = pen1;
                e.Graphics.DrawLine(pen2, this.ClientRectangle.Left, this.ClientRectangle.Top, this.ClientRectangle.Right, this.ClientRectangle.Top);
                e.Graphics.DrawLine(pen2, this.ClientRectangle.Left, this.ClientRectangle.Top, this.ClientRectangle.Left, this.ClientRectangle.Bottom);
                e.Graphics.DrawLine(SystemPens.InfoText, this.ClientRectangle.Left, this.ClientRectangle.Bottom - 1, this.ClientRectangle.Right, this.ClientRectangle.Bottom - 1);
                e.Graphics.DrawLine(SystemPens.InfoText, this.ClientRectangle.Right - 1, this.ClientRectangle.Top, this.ClientRectangle.Right - 1, this.ClientRectangle.Bottom);
                clientRectangle = this.ClientRectangle;
                clientRectangle.Inflate(-2, -2);
                goto label_1;

                label_5:
                pen1 = SystemPens.Control;
                goto label_3;


                label_8:
                e.Graphics.FillRectangle(SystemBrushes.Info, this.ClientRectangle);
                if (!SystemInformation.HighContrast)
                    goto label_5;
                else
                    goto label_2;

                label_10:
                if (VisualStyleRenderer.IsElementDefined(normal))
                {
                    VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(normal);
                    visualStyleRenderer.DrawBackground((IDeviceContext)e.Graphics, this.ClientRectangle);
                    Rectangle textExtent = visualStyleRenderer.GetTextExtent((IDeviceContext)e.Graphics, this.ClientRectangle, this.Text, this.textFormatFlags);
                    textExtent.X = this.ClientRectangle.X + this.ClientRectangle.Width / 2 - textExtent.Width / 2;
                    textExtent.Y = this.ClientRectangle.Y + this.ClientRectangle.Height / 2 - textExtent.Height / 2;
                    visualStyleRenderer.DrawText(e.Graphics, textExtent, this.Text, false, this.textFormatFlags);
                    return;
                }
                else
                {
                    goto label_8;
                }


            }
        }

        internal delegate string x58986a4a0b75e5b5(Point location);
    }
}
