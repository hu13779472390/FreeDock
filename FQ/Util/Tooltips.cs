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
        private bool dropShadow = true;
        private const int xdbb7427772b219d6 = 128;
        private const int xb644deafcaa222c4 = 2;
        private const int xb8a822e576f3bf60 = 1;
        private Control control;
        private bool x364c1e3b189d47fe;
        private bool x0e75cd3866dbb930;
        private Point location;
        private ToolTipForm tipForm;
        private Timer timer;
        private Form containingForm;
//        private const int SWP_SHOWWINDOW = 0x0040;
//        private const int SWP_NOACTIVATE = 0x0010;

        public bool DropShadow
        {
            get
            {
                return this.dropShadow;
            }
            set
            {
                this.dropShadow = value;
            }
        }

        public bool ShowPrefix
        {
            get
            {
                return this.tipForm.ShowPrefix;
            }
            set
            {
                this.tipForm.ShowPrefix = value;
            }
        }

        public event x58986a4a0b75e5b5 GetTooltipText;

        public Tooltips(Control control)
        {
            this.control = control;
            control.MouseMove += new MouseEventHandler(this.OnControlMouseMove);
            control.MouseLeave += new EventHandler(this.OnControlMouseLeave);
            control.MouseDown += new MouseEventHandler(this.OnControlMouseDown);
            control.MouseWheel += new MouseEventHandler(this.OnControlMouseWheel);
            control.Disposed += new EventHandler(this.OnControlDisposed);
            control.FontChanged += new EventHandler(this.OnControlFontChanged);
            this.tipForm = new Tooltips.ToolTipForm(this);
            this.tipForm.MouseMove += new MouseEventHandler(this.OnTipFormMouseMove);
            this.timer = new Timer();
            this.timer.Interval = SystemInformation.DoubleClickTime;
            this.timer.Tick += new EventHandler(this.OnTimerTick);
        }

//        [DllImport("user32.dll")]
//        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int flags);

        public void Dispose()
        {
            if (this.x0e75cd3866dbb930)
                return;

            this.x47c79a4d207183de();
            this.tipForm.MouseMove -= new MouseEventHandler(this.OnTipFormMouseMove);
            this.tipForm.Dispose();
            this.tipForm = null;
            this.control.MouseMove -= new MouseEventHandler(this.OnControlMouseMove);
            this.control.MouseLeave -= new EventHandler(this.OnControlMouseLeave);
            this.control.MouseDown -= new MouseEventHandler(this.OnControlMouseDown);
            this.control.MouseWheel -= new MouseEventHandler(this.OnControlMouseWheel);
            this.control.Disposed -= new EventHandler(this.OnControlDisposed);
            this.control.FontChanged -= new EventHandler(this.OnControlFontChanged);
            this.control = null;
            this.timer.Tick -= new EventHandler(this.OnTimerTick);
            this.timer.Dispose();
            this.x0e75cd3866dbb930 = true;
        }

        private static bool IsNT51()
        {
            bool flag = false;
//            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
//                flag = Environment.OSVersion.Version >= new Version(5, 1, 0, 0);
            return flag;
        }

        public void x4402a69f607144e3(Point point, string text)
        {
            this.tipForm.Text = text;
            goto label_43;


            label_5:
            this.tipForm.Invalidate();
            this.x364c1e3b189d47fe = true;
            if (this.containingForm != null)
                this.containingForm.Deactivate -= new EventHandler(this.xdef19f2ef265bf1e);
            this.containingForm = this.FindTopMostContainingForm(this.control);
            if (this.containingForm == null)
                return;
            this.containingForm.Deactivate += new EventHandler(this.xdef19f2ef265bf1e);
            this.tipForm.Owner = this.containingForm;
            return;

            label_43:
            Size size;
            do
            {
                size = Size.Ceiling(this.tipForm.MeasureText(text));
                size.Height += 4;
                size.Width += 4;
                point.Y += 19;
                Screen screen = Screen.FromPoint(point);
                if (point.X < screen.Bounds.Left)
                    point.X = screen.Bounds.Left;
                do
                {
                    if (point.X + size.Width <= screen.Bounds.Right)
                    {
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
                        point.Y = screen.Bounds.Bottom - size.Height;
                        continue;
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
            while (0 != 0);
            goto label_46;
            label_9:
            VisualStyleElement normal;
            if (!VisualStyleRenderer.IsElementDefined(normal))
            {
                goto label_5;
            }
            using (Graphics graphics = this.tipForm.CreateGraphics())
            {
                this.tipForm.Region = new VisualStyleRenderer(normal).GetBackgroundRegion((IDeviceContext)graphics, this.tipForm.ClientRectangle);
                goto label_5;
            }
            label_17:

//            Tooltips.SetWindowPos(this.tipForm.Handle, -1, point.X, point.Y, size.Width, size.Height, SWP_SHOWWINDOW | SWP_NOACTIVATE /*80*/);

            this.tipForm.Size = size;
            this.tipForm.Location = point;
            this.tipForm.Show();

            normal = VisualStyleElement.ToolTip.Standard.Normal;
            if (Application.RenderWithVisualStyles)
            {
                goto label_9;
            }
            else
                goto label_5;
            label_47:
            return;
            label_19:
            return;
   
            label_46:
            goto label_17;

        }

        public void x47c79a4d207183de()
        {
            this.tipForm.Owner = null;
            this.tipForm.Visible = false;
            this.x364c1e3b189d47fe = false;
            if (this.containingForm == null)
                return;
            this.containingForm.Deactivate -= new EventHandler(this.xdef19f2ef265bf1e);
            this.containingForm = null;
        }

        private void OnControlMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.None)
                return;
            goto label_19;


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
            Point point;
            if (!this.x364c1e3b189d47fe)
            {
                point = new Point(e.X, e.Y);
                if (point == this.location)
                    return;
                goto label_6;
            }
            else
                goto label_20;

            label_6:
  
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
            xb41faee6912a2313 = this.GetTooltipText(new Point(e.X, e.Y));
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
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            string xb41faee6912a2313 = "";
            this.timer.Enabled = false;

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
                xb41faee6912a2313 = this.GetTooltipText(point);
                if (xb41faee6912a2313 == null)
                    goto label_16;
            }

            goto label_14;
            label_16:
            return;

            label_14:
            if (xb41faee6912a2313.Length == 0)
                return;
            form = this.FindTopMostContainingForm(this.control);
            activeForm = Form.ActiveForm;
            if (form == null || activeForm == null)
            {
                num = 0;
                goto label_4;
            }
            else
                goto label_7;
        }

        private Form FindTopMostContainingForm(Control control)
        {
            while (control.Parent != null)
                control = control.Parent;
            return control as Form;
        }

        private void OnControlMouseLeave(object sender, EventArgs e)
        {
            if (this.x364c1e3b189d47fe)
                this.x47c79a4d207183de();
            this.timer.Enabled = false;
        }

        private void OnControlMouseDown(object sender, MouseEventArgs e)
        {
            if (this.x364c1e3b189d47fe)
                this.x47c79a4d207183de();
            this.timer.Enabled = false;
        }

        private void OnControlMouseWheel(object sender, MouseEventArgs e)
        {
            if (this.x364c1e3b189d47fe)
                this.x47c79a4d207183de();
            this.timer.Enabled = false;
        }

        private void OnTipFormMouseMove(object sender, MouseEventArgs e)
        {
            this.x47c79a4d207183de();
        }

        private void xdef19f2ef265bf1e(object sender, EventArgs e)
        {
            this.x47c79a4d207183de();
        }

        private void OnControlDisposed(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OnControlFontChanged(object sender, EventArgs e)
        {
            this.tipForm.Font = this.control.Font;
        }

        private class ToolTipForm : Form
        {
            private const int x3e8b9d6faeff6586 = 32;
            private const int x2b7f5d3ca7ec1edf = -2147483648;
            //            private const int xd708511d2241a4fb = 131072;
            //            private const int x836e53e090609b16 = 4132;
            //0x80000000
            private const int WS_GROUP = 0x00020000;
            private const int WS_EX_NOACTIVATE = 0x08000000;
            private const int WS_EX_TOOLWINDOW = 0x00000080;
            private const int SPI_GETDROPSHADOW = 0x1024;
            private Tooltips tooltips;
            private TextFormatFlags textFormatFlags;

            public bool ShowPrefix
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
                    if (this.tooltips != null && this.tooltips.DropShadow && ToolTipForm.CanDropShadow)
                    {
                        createParams.ClassStyle |= WS_GROUP;
                        createParams.ExStyle |= WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW;
                    }
                    return createParams;
                }
            }
            // DROPSHADOW?
            private static bool CanDropShadow
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

            // very import for tooltip 
            protected override bool ShowWithoutActivation
            {
                get
                { 
                    return true;
                }
            }

            public ToolTipForm(Tooltips tooltips)
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
            public SizeF MeasureText(string text)
            {
                SizeF sizeF1;
                using (Graphics graphics = this.CreateGraphics())
                {
                    VisualStyleElement normal = VisualStyleElement.ToolTip.Standard.Normal;
                    if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(normal))
                    {
                        VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(normal);
                        Rectangle textExtent = visualStyleRenderer.GetTextExtent(graphics, text, TextFormatFlags.Default);
                        sizeF1 = (SizeF)visualStyleRenderer.GetBackgroundExtent(graphics, textExtent).Size;
                    }
                    else
                    {
                        SizeF sizeF2 = (SizeF)TextRenderer.MeasureText(graphics, text, this.Font, new Size(SystemInformation.PrimaryMonitorSize.Width, int.MaxValue), this.textFormatFlags);
                        sizeF2.Width -= 2f;
                        sizeF2.Height += 2f;
                        sizeF1 = sizeF2;
                    }
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
                if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(normal))
                {
                    VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(normal);
                    visualStyleRenderer.DrawBackground((IDeviceContext)e.Graphics, this.ClientRectangle);
                    Rectangle textExtent = visualStyleRenderer.GetTextExtent((IDeviceContext)e.Graphics, this.ClientRectangle, this.Text, this.textFormatFlags);
                    textExtent.X = this.ClientRectangle.X + this.ClientRectangle.Width / 2 - textExtent.Width / 2;
                    textExtent.Y = this.ClientRectangle.Y + this.ClientRectangle.Height / 2 - textExtent.Height / 2;
                    visualStyleRenderer.DrawText(e.Graphics, textExtent, this.Text, false, this.textFormatFlags);
                }
                else
                {
                    e.Graphics.FillRectangle(SystemBrushes.Info, this.ClientRectangle);
                    Pen pen = SystemInformation.HighContrast ? SystemPens.InfoText : SystemPens.Control; 
                    e.Graphics.DrawLine(pen, this.ClientRectangle.Left, this.ClientRectangle.Top, this.ClientRectangle.Right, this.ClientRectangle.Top);
                    e.Graphics.DrawLine(pen, this.ClientRectangle.Left, this.ClientRectangle.Top, this.ClientRectangle.Left, this.ClientRectangle.Bottom);
                    e.Graphics.DrawLine(SystemPens.InfoText, this.ClientRectangle.Left, this.ClientRectangle.Bottom - 1, this.ClientRectangle.Right, this.ClientRectangle.Bottom - 1);
                    e.Graphics.DrawLine(SystemPens.InfoText, this.ClientRectangle.Right - 1, this.ClientRectangle.Top, this.ClientRectangle.Right - 1, this.ClientRectangle.Bottom);
                    Rectangle clientRectangle = this.ClientRectangle;
                    clientRectangle.Inflate(-2, -2);
                    TextRenderer.DrawText(e.Graphics, this.Text, this.Font, clientRectangle, SystemColors.InfoText, this.textFormatFlags);
                }
            }

        }

        internal delegate string x58986a4a0b75e5b5(Point location);
    }
}
