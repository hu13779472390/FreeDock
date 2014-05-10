using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FQ.FreeDock.Design;

namespace FQ.FreeDock
{
    /// <summary>
    /// An extended DockContainer to display a hierarchy of documents.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// This class extends the DockContainer class with methods for tracking and managing documents on a single level, irrespective of the
    ///             hierarchy the documents may actually occupy.
    /// </para>
    /// 
    /// <para>
    /// You should not use this class directly.
    /// </para>
    /// 
    /// </remarks>
    [Designer(typeof(DocumentContainerDesigner))]
    [ToolboxItem(false)]
    public class DocumentContainer : DockContainer, IMessageFilter
    {
        private FQ.FreeDock.Rendering.BorderStyle borderStyle = FQ.FreeDock.Rendering.BorderStyle.Flat;
        private DocumentOverflowMode documentOverflow = DocumentOverflowMode.Scrollable;
        private int xabb78e5e36f68ff6 = -1;
        // 256;
        private const int WM_KEYDOWN = 0x100;
        // 257
        private const int WM_KEYUP = 0x101;
        private const int xa1cfcecc2bbf1b88 = 9;
        private const int x94f3e1f6055486d7 = 17;
        private const int x0e421de239ce3d08 = 16;
        private bool integralClose;
        private DockControl[] documents;

        internal bool x1ec2ea49664e1074
        {
            get
            {
                return this.documents != null;
            }
        }

        internal override bool CanShowCollapsed
        {
            get
            {
                return false;
            }
        }

        private bool AllowKeyboardNavigation
        {
            get
            {
                return this.Manager != null ? this.Manager.AllowKeyboardNavigation : true;
            }
        }

        [Description("The type of border to be drawn around the control.")]
        [DefaultValue(typeof(FQ.FreeDock.Rendering.BorderStyle), "Flat")]
        [Category("Appearance")]
        internal FQ.FreeDock.Rendering.BorderStyle BorderStyle
        {
            get
            {
                return this.borderStyle;
            }
            set
            {
                this.borderStyle = value;
                this.OnResize(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = base.DisplayRectangle;
                switch (this.borderStyle)
                {
                    case FQ.FreeDock.Rendering.BorderStyle.Flat:
                    case FQ.FreeDock.Rendering.BorderStyle.RaisedThin:
                    case FQ.FreeDock.Rendering.BorderStyle.SunkenThin:
                        rect.Inflate(-1, -1);
                        break;
                    case FQ.FreeDock.Rendering.BorderStyle.RaisedThick:
                    case FQ.FreeDock.Rendering.BorderStyle.SunkenThick:
                        rect.Inflate(-2, -2);
                        break;
                }
                return rect;
            }
        }

        internal bool IntegralClose
        {
            get
            {
                return this.integralClose;
            }
            set
            {
                this.integralClose = value;
                this.CalculateAllMetricsAndLayout();
            }
        }

        internal DocumentOverflowMode DocumentOverflow
        {
            get
            {
                return this.documentOverflow;
            }
            set
            {
                this.documentOverflow = value;
                this.CalculateAllMetricsAndLayout();
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(300, 300);
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [DefaultValue(typeof(Color), "AppWorkspace")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [DefaultValue(typeof(DockStyle), "Fill")]
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                if (value != DockStyle.Fill)
                    throw new ArgumentException("Only the Fill dock style is valid for this type of container.");
                base.Dock = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the DocumentContainer class.
        /// 
        /// </summary>
        public DocumentContainer()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = SystemColors.AppWorkspace;
        }

        internal override ControlLayoutSystem CreateNewControlLayoutSystem()
        {
            return new DocumentLayoutSystem();
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed 
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData != (Keys.Tab | Keys.Control) && keyData != (Keys.Tab | Keys.Shift | Keys.Control) || !this.AllowKeyboardNavigation)
                return base.ProcessCmdKey(ref msg, keyData);
            DockControl[] dockControls = this.Manager.GetDockControls(DockSituation.Document);
            if (dockControls.Length < 2)
                return true;
            DateTime[] keys = new DateTime[dockControls.Length];
            for (int i = 0; i < dockControls.Length; i++)
                keys[i] = dockControls[i].MetaData.LastFocused;
            Array.Sort<DateTime, DockControl>(keys, dockControls);
            this.documents = dockControls;
            this.xabb78e5e36f68ff6 = (keyData & Keys.Shift) != Keys.Shift ? 1 : this.documents.Length - 1;
            this.GetActiveDocument();
            Application.AddMessageFilter(this);
            return true;
        }

        private DockControl GetActiveDocument()
        {
            if (this.xabb78e5e36f68ff6 > this.documents.Length)
                this.xabb78e5e36f68ff6 = this.documents.Length;
            int index = this.documents.Length - 1 - this.xabb78e5e36f68ff6;
            this.documents[index].SetActive(true);
            return this.documents[index];
        }

        // reviewed
        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            if (m.Msg == 256 && m.WParam.ToInt32() == 9)
            {
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                    --this.xabb78e5e36f68ff6;
                else
                    ++this.xabb78e5e36f68ff6;
                if (this.xabb78e5e36f68ff6 > this.documents.Length - 1)
                    this.xabb78e5e36f68ff6 = 0;
                if (this.xabb78e5e36f68ff6 < 0)
                    this.xabb78e5e36f68ff6 = this.documents.Length - 1;
                this.GetActiveDocument();
                return true;
            }
            else
            {
                if (m.Msg == 256 && m.WParam.ToInt32() == 16)
                    return true;
                if ((m.Msg != 257 || m.WParam.ToInt32() != 17) && m.Msg != 256)
                    return false;
                DockControl dockControl = this.GetActiveDocument();
                this.xabb78e5e36f68ff6 = -1;
                this.documents = null;
                dockControl.SetActive(true);
                Application.RemoveMessageFilter(this);
                return true;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DockControl.DoPaint(this, e.Graphics, this.borderStyle);
        }
    }
}
