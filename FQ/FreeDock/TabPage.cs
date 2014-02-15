using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    /// <summary>
    /// A single tab suitable for adding to a TabControl.
    /// 
    /// </summary>
    [Designer("TD.SandDock.Design.TabPageDesigner, SandDock.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
    [ToolboxItem(false)]
    public class TabPage : Panel
    {
        private Image xe058541ca798c059;
        private int x3214e09b677ccd2b;
        internal double x9b0739496f8b5475;
        internal int xa806b754814b9ae0;
        internal Rectangle x123e054dab107457;
        internal bool xcfac6723d8a41375;

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                if (!(this.Parent is TabControl))
                    return;
                this.Parent.Invalidate(this.x123e054dab107457);
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                base.Dock = value;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override AnchorStyles Anchor
        {
            get
            {
                return base.Anchor;
            }
            set
            {
                base.Anchor = value;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new int TabIndex
        {
            get
            {
                return base.TabIndex;
            }
            set
            {
                base.TabIndex = value;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new bool TabStop
        {
            get
            {
                return base.TabStop;
            }
            set
            {
                base.TabStop = value;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new bool Visible
        {
            get
            {
                return base.Visible;
            }
            set
            {
                base.Visible = value;
            }
        }

        /// <summary>
        /// Indicates the maximum width of the tab.
        /// 
        /// </summary>
        [Category("Layout")]
        [DefaultValue(0)]
        [Description("Indicates the maximum width of the tab.")]
        public int MaximumTabWidth
        {
            get
            {
                return this.x3214e09b677ccd2b;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Value must be greater than or equal to zero.");
                this.x3214e09b677ccd2b = value;
                if (!(this.Parent is TabControl))
                    return;
                ((TabControl)this.Parent).x436f6f3ee14607e0();
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [Browsable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                if (!(this.Parent is TabControl))
                    return;
                ((TabControl)this.Parent).x436f6f3ee14607e0();
            }
        }

        /// <summary>
        /// The image displayed next to the text on the tab.
        /// 
        /// </summary>
        [Category("Appearance")]
        [AmbientValue(typeof(Image), null)]
        [DefaultValue(typeof(Image), null)]
        [Description("The image displayed next to the text on the tab.")]
        public Image TabImage
        {
            get
            {
                return this.xe058541ca798c059;
            }
            set
            {
                this.xe058541ca798c059 = value;
                if (!(this.Parent is TabControl))
                    return;
                ((TabControl)this.Parent).x436f6f3ee14607e0();
            }
        }

        /// <summary>
        /// Indicates the area occupied by the tab of the TabPage.
        /// 
        /// </summary>
        [Browsable(false)]
        public Rectangle TabBounds
        {
            get
            {
                return this.x123e054dab107457;
            }
        }

        /// <summary>
        /// This property is obsolete and provided for backward compatibility reasons only.
        /// 
        /// </summary>
        [Browsable(false)]
        [Obsolete]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid Guid
        {
            get
            {
                return Guid.Empty;
            }
            set
            {
            }
        }

        /// <summary>
        /// This property is obsolete and provided for backward compatibility reasons only.
        /// 
        /// </summary>
        [Browsable(false)]
        [Obsolete]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Drawing.Size FloatingSize
        {
            get
            {
                return System.Drawing.Size.Empty;
            }
            set
            {
            }
        }

        /// <summary>
        /// This property is obsolete and provided for backward compatibility reasons only.
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete]
        public string TabText
        {
            get
            {
                return "";
            }
            set
            {
            }
        }

        /// <summary>
        /// Raised just before the control becomes visible for the first time.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This event facilitates deferred loading of complex controls by making it possible to keep your DockControl empty until it first becomes the selected
        ///             control in its parent layout system. You can then load its child controls only when needed, speeding up initial application load.
        /// </para>
        /// 
        /// </remarks>
        public event EventHandler Load;

        /// <summary>
        /// Initializes a new instance of the TabPage class.
        /// 
        /// </summary>
        public TabPage()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        /// <summary>
        /// Initializes a new instance of the TabPage class, with the specified text.
        /// 
        /// </summary>
        /// <param name="text">The text for the tab of the new TabPage.</param>
        public TabPage(string text)
      : this()
        {
            this.Text = text;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            int num = disposing ? 1 : 0;
            base.Dispose(disposing);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.OnLoad(EventArgs.Empty);
        }

        /// <summary>
        /// Raises the Load event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected virtual void OnLoad(EventArgs e)
        {
            if (this.Load == null)
                return;
            this.Load((object)this, e);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (this.ClientRectangle == Rectangle.Empty)
            {
                if (-2 == 0 || 0 == 0)
                    return;
            }
            else if (!(this.Parent is TabControl) || !((TabControl)this.Parent).Renderer.ShouldDrawTabControlBackground)
            {
                base.OnPaintBackground(pevent);
                return;
            }
            ((TabControl)this.Parent).Renderer.DrawTabControlBackground(pevent.Graphics, this.ClientRectangle, this.BackColor, true);
        }

        /// <summary>
        /// Overridden. Ensures that as the handle is created the index within the parent control does not change.
        /// 
        /// </summary>
        protected override void CreateHandle()
        {
            int newIndex = -1;
            do
            {
                if (this.Parent != null)
                    goto label_5;
                label_1:
                base.CreateHandle();
                if (this.Parent == null)
                    continue;
                else
                    goto label_2;
                label_5:
                newIndex = this.Parent.Controls.IndexOf((Control)this);
                if (0 != 0)
                    goto label_7;
                else
                    goto label_1;
            }
            while (4 == 0);
            goto label_6;
            label_2:
            this.Parent.Controls.SetChildIndex((Control)this, newIndex);
            return;
            label_6:
            return;
            label_7:
            ;
        }
    }
}
