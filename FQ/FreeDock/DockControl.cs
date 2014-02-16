using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FQ.FreeDock.Design;
using FQ.FreeDock.Rendering;

namespace FQ.FreeDock
{
    /// <summary>
    /// A control to be used in a docking layout.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// DockControl instances are grouped together in ControlLayoutSystems. They can act as containers to other controls.
    /// </para>
    /// 
    /// </remarks>
    [DefaultEvent("Closing")]
    [ToolboxItem(false)]
    [Designer(typeof(DockControlDesigner))]
    public abstract class DockControl : ContainerControl
    {
        internal Rectangle x123e054dab107457 = Rectangle.Empty;
        internal Rectangle x700c42042910e68b = Rectangle.Empty;
        private string xd84978f0dad7afcd = "";
        private string xc3d462fde66905e5 = string.Empty;
        private bool x6c3086899dc42885 = true;
        private bool x9b80917b168ce488 = true;
        private Guid xb51cd75f17ace1ec = Guid.NewGuid();
        private System.Drawing.Point xc868bd63c888e533 = new System.Drawing.Point(-1, -1);
        private bool x35db3fd5e409fffb = true;
        private bool x1def1a42ad5b7095 = true;
        private SandDockManager manager;
        private ControlLayoutSystem xb6a159a84cb992d6;
        private static Image x28afaed1891a17a1;
        private Image x564c6c527905c683;
        private FQ.FreeDock.Rendering.BorderStyle xacfbd7a08ba56c78;
        private bool xb98085e1d76c9b6d;
        private bool x4e7c2c44587adeda;
        private bool x131b418d4c565c70;
        internal bool xcfac6723d8a41375;
        private int x5614e4ef0596c91d;
        private int x3214e09b677ccd2b;
        private int xcf3ab1252c42eac6;
        private WindowMetaData xfffbdea061bfa120;
        private BindingContext x2464cce8c6385330;
        private System.Drawing.Size xca874006c41dfe29;
        private DockingRules xd447c58f1b8b8e4b;
        private DockControlCloseAction x8fbef9afc77bc952;
        private Control x3f02d9fd7ae06803;
        private DockSituation xef84499526c04953;

        /// <summary>
        /// Indicates whether keyboard navigation will be allowed from this control.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// The default implementation of this property obtains the value from the associated SandDockManager.
        /// </para>
        /// 
        /// </remarks>
        [Browsable(false)]
        protected virtual bool AllowKeyboardNavigation
        {
            get
            {
                if (this.Manager == null)
                    return true;
                else
                    return this.Manager.AllowKeyboardNavigation;
            }
        }

        /// <summary>
        /// Overridden. This property always returns the BindingContext of the container hosting the SandDock layout.
        /// 
        /// </summary>
        public override BindingContext BindingContext
        {
            get
            {
                if (this.x2464cce8c6385330 != null)
                    return this.x2464cce8c6385330;
                if (this.Manager != null && this.Manager.DockSystemContainer != null)
                    return this.Manager.DockSystemContainer.BindingContext;
                if (this.DesignMode)
                    return base.BindingContext;
                else
                    return (BindingContext)null;
            }
            set
            {
                this.x2464cce8c6385330 = value;
                base.BindingContext = value;
            }
        }

        /// <summary>
        /// The control that will be focused when the window is activated.
        /// 
        /// </summary>
        [Category("Behavior")]
        [Description("The control that will be focused when the window is activated.")]
        [DefaultValue(typeof(Control), null)]
        public Control PrimaryControl
        {
            get
            {
                return this.x3f02d9fd7ae06803;
            }
            set
            {
                this.x3f02d9fd7ae06803 = value;
            }
        }

        /// <summary>
        /// Indicates whether the window is collapsed when docked.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This setting is automatically applied to all sibling windows in the same group.
        /// </para>
        /// 
        /// </remarks>
        [DefaultValue(false)]
        [Description("Indicates whether the window is collapsed when docked.")]
        [Category("Layout")]
        public bool Collapsed
        {
            get
            {
                if (this.LayoutSystem == null)
                    return false;
                else
                    return this.LayoutSystem.Collapsed;
            }
            set
            {
                if (this.LayoutSystem == null)
                    return;
                this.LayoutSystem.Collapsed = value;
            }
        }

        /// <summary>
        /// Indicates what action will be performed when the DockControl is closed.
        /// 
        /// </summary>
        [Description("Indicates what action will be performed when the DockControl is closed.")]
        [DefaultValue(typeof(DockControlCloseAction), "HideOnly")]
        [Category("Behavior")]
        public virtual DockControlCloseAction CloseAction
        {
            get
            {
                return this.x8fbef9afc77bc952;
            }
            set
            {
                this.x8fbef9afc77bc952 = value;
            }
        }

        /// <summary>
        /// Meta data about the window and its position.
        /// 
        /// </summary>
        [Browsable(false)]
        public WindowMetaData MetaData
        {
            get
            {
                return this.xfffbdea061bfa120;
            }
        }

        internal bool xadad18dc04073a00
        {
            get
            {
                return this.xb98085e1d76c9b6d;
            }
            set
            {
                this.xb98085e1d76c9b6d = value;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [Browsable(false)]
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
        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle displayRectangle = base.DisplayRectangle;
                if (-2 == 0)
                    ;
                switch (this.xacfbd7a08ba56c78)
                {
                    case FQ.FreeDock.Rendering.BorderStyle.Flat:
                    case FQ.FreeDock.Rendering.BorderStyle.RaisedThin:
                    case FQ.FreeDock.Rendering.BorderStyle.SunkenThin:
                        displayRectangle.Inflate(-1, -1);
                        break;
                    case FQ.FreeDock.Rendering.BorderStyle.RaisedThick:
                    case FQ.FreeDock.Rendering.BorderStyle.SunkenThick:
                        displayRectangle.Inflate(-2, -2);
                        break;
                }
                return displayRectangle;
            }
        }

        /// <summary>
        /// Indicates whether the location of the DockControl will be included in layout serialization.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// Use this property when you are using temporary or incidental dockable windows at runtime that you do not wish to be included in layout
        ///             information persisted via a call to GetLayout.
        /// </para>
        /// 
        /// </remarks>
        [Description("Indicates whether the location of the DockControl will be included in layout serialization.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [Category("Behavior")]
        public virtual bool PersistState
        {
            get
            {
                return this.x35db3fd5e409fffb;
            }
            set
            {
                this.x35db3fd5e409fffb = value;
            }
        }

        /// <summary>
        /// The type of border to be drawn around the control.
        /// 
        /// </summary>
        [Category("Appearance")]
        [Description("The type of border to be drawn around the control.")]
        [DefaultValue(typeof(FQ.FreeDock.Rendering.BorderStyle), "None")]
        public FQ.FreeDock.Rendering.BorderStyle BorderStyle
        {
            get
            {
                return this.xacfbd7a08ba56c78;
            }
            set
            {
                this.xacfbd7a08ba56c78 = value;
                this.PerformLayout();
                this.Invalidate();
            }
        }

        /// <summary>
        /// The ControlLayoutSystem the DockControl belongs to.
        /// 
        /// </summary>
        [Browsable(false)]
        public ControlLayoutSystem LayoutSystem
        {
            get
            {
                return this.xb6a159a84cb992d6;
            }
        }

        /// <summary>
        /// The SandDockManager instance associated with the DockControl.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// If any form of docking will be used, it is essential that all DockControls know about the SandDockManager object responsible for
        ///             managing the docked layout. This property is automatically assigned to when a DockControl is first added to a DockContainer that knows
        ///             about the manager.
        /// </para>
        /// 
        /// </remarks>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public SandDockManager Manager
        {
            get
            {
                return this.manager;
            }
            set
            {
                if (value == this.manager)
                    return;

                if (this.manager != null)
                    this.manager.UnregisterWindow(this);
                this.manager = value;

                if (this.manager != null)
                    this.manager.RegisterWindow(this);
            }
        }

        /// <summary>
        /// The unique identifier for the window.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// Dockable windows need unique identifiers for layout serialization purposes. If any windows have the same identifier serialization will not
        ///             work correctly. The identifier can also be used to find windows.
        /// </para>
        /// 
        /// </remarks>
        [Description("The unique identifier for the window.")]
        [Category("Advanced")]
        public Guid Guid
        {
            get
            {
                return this.xb51cd75f17ace1ec;
            }
            set
            {
                Guid oldGuid = this.xb51cd75f17ace1ec;
                this.xb51cd75f17ace1ec = value;
                if (this.Manager == null)
                    return;
                this.Manager.ReRegisterWindow(this, oldGuid);
            }
        }

        /// <summary>
        /// Indicates whether the DockControl is docked to a side of the container.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This method will also return true if a window has been docked in the center of the container, but only if tabbed documents have been disabled. The method will return false if
        ///             the window is floating.
        /// </para>
        /// 
        /// </remarks>
        [Browsable(false)]
        [Obsolete("Use the DockSituation property instead.")]
        public bool IsDocked
        {
            get
            {
                if (this.x1a9802d2d8708515 && !(this.xb6a159a84cb992d6.DockContainer is DocumentContainer))
                    return !(this.xb6a159a84cb992d6.DockContainer is x410f3612b9a8f9de);
                else
                    return false;
            }
        }

        /// <summary>
        /// Indicates whether the DockControl is being displayed in the centre of the container as a tabbed document.
        /// 
        /// </summary>
        [Obsolete("Use the DockSituation property instead.")]
        [Browsable(false)]
        public bool IsTabbedDocument
        {
            get
            {
                if (this.x1a9802d2d8708515)
                    return this.xb6a159a84cb992d6.DockContainer is DocumentContainer;
                else
                    return false;
            }
        }

        /// <summary>
        /// Indicates whether the DockControl is in a floating container.
        /// 
        /// </summary>
        [Obsolete("Use the DockSituation property instead.")]
        [Browsable(false)]
        public bool IsFloating
        {
            get
            {
                if (this.x1a9802d2d8708515)
                    return this.xb6a159a84cb992d6.DockContainer.IsFloating;
                else
                    return false;
            }
        }

        [Browsable(false)]
        internal bool x1a9802d2d8708515
        {
            get
            {
                if (this.xb6a159a84cb992d6 != null)
                    return this.xb6a159a84cb992d6.DockContainer != null;
                else
                    return false;
            }
        }

        /// <summary>
        /// Indicates whether the DockControl is visible at any location on the screen.
        /// 
        /// </summary>
        [Browsable(false)]
        public bool IsOpen
        {
            get
            {
                bool flag = this.x1a9802d2d8708515 && this.xb6a159a84cb992d6 != null && this.xb6a159a84cb992d6.SelectedControl == this;
                do
                {
                    if (flag)
                    {
                        if (this.xb6a159a84cb992d6.Collapsed)
                            goto label_2;
                    }
                    else if (0 == 0)
                        break;
                }
                while (0 != 0);
                goto label_6;
                label_2:
                flag = this.xb6a159a84cb992d6.IsPoppedUp;
                label_6:
                return flag;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        [DefaultValue(typeof(Color), "Control")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                while (this.LayoutSystem != null)
                {
                    if (this.LayoutSystem.DockContainer == null)
                    {
                        if (int.MaxValue != 0)
                            break;
                    }
                    else
                    {
                        this.LayoutSystem.DockContainer.Invalidate(this.LayoutSystem.Bounds);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                if (int.MaxValue != 0 && this.LayoutSystem == null || this.LayoutSystem.DockContainer == null)
                    return;
                this.LayoutSystem.DockContainer.Invalidate(this.x123e054dab107457);
            }
        }

        /// <summary>
        /// Indicates the default size this control will assume when floating on its own.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// If the control is a part of a group of controls, the size of the group will be used instead of the control.
        /// 
        /// </remarks>
        [Description("Indicates the default size this control will assume when floating on its own.")]
        [Category("Layout")]
        [DefaultValue(typeof(System.Drawing.Size), "250, 400")]
        public System.Drawing.Size FloatingSize
        {
            get
            {
                return this.xca874006c41dfe29;
            }
            set
            {
                if (value.Width > 0)
                    goto label_5;
                label_3:
                throw new ArgumentOutOfRangeException("value");
                label_5:
                while (15 != 0 && value.Height > 0)
                {
                    this.xca874006c41dfe29 = value;
                    if (this.DockSituation != DockSituation.Floating || !(this.x410f3612b9a8f9de.xb1090c5821a633b5 != this.xca874006c41dfe29))
                        return;
                    if (0 == 0)
                    {
                        this.x410f3612b9a8f9de.xb1090c5821a633b5 = this.xca874006c41dfe29;
                        return;
                    }
                }
                goto label_3;
            }
        }

        /// <summary>
        /// Indicates the location of the floating window that will contain this control.
        /// 
        /// </summary>
        [Browsable(false)]
        [DefaultValue(typeof(System.Drawing.Point), "-1, -1")]
        public System.Drawing.Point FloatingLocation
        {
            get
            {
                return this.xc868bd63c888e533;
            }
            set
            {
                this.xc868bd63c888e533 = value;
                if (3 == 0)
                {
                    if (3 != 0)
                        goto label_6;
                    else
                        goto label_4;
                }
                else
                    goto label_9;
                label_2:
                if (0 == 0)
                {
                    if (-1 != 0)
                        return;
                    else
                        goto label_9;
                }
                label_3:
                if (!(this.x410f3612b9a8f9de.x12992900724b93dc != this.xc868bd63c888e533))
                    return;
                else
                    goto label_6;
                label_4:
                if (this.DockSituation == DockSituation.Floating)
                    goto label_3;
                else
                    goto label_2;
                label_6:
                this.x410f3612b9a8f9de.x12992900724b93dc = this.xc868bd63c888e533;
                return;
                label_9:
                if (0 != 0)
                    goto label_2;
                else
                    goto label_4;
            }
        }

        private x410f3612b9a8f9de x410f3612b9a8f9de
        {
            get
            {
                return this.xb6a159a84cb992d6.DockContainer as x410f3612b9a8f9de;
            }
        }

        /// <summary>
        /// Indicates whether the user will be able to float the control.
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("Use the DockingRules property instead.")]
        public bool AllowFloat
        {
            get
            {
                return this.DockingRules.AllowFloat;
            }
            set
            {
                this.DockingRules.AllowFloat = value;
            }
        }

        /// <summary>
        /// Indicates whether the user will be able to dock the window in the center of the container.
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("Use the DockingRules property instead.")]
        public bool AllowDockCenter
        {
            get
            {
                return this.DockingRules.AllowTab;
            }
            set
            {
                this.DockingRules.AllowTab = value;
            }
        }

        /// <summary>
        /// Indicates whether the user will be able to dock the control to the left-hand side of the form.
        /// 
        /// </summary>
        [Browsable(false)]
        [Obsolete("Use the DockingRules property instead.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowDockLeft
        {
            get
            {
                return this.DockingRules.AllowDockLeft;
            }
            set
            {
                this.DockingRules.AllowDockLeft = value;
            }
        }

        /// <summary>
        /// Indicates whether the user will be able to dock the control to the right-hand side of the form.
        /// 
        /// </summary>
        [Obsolete("Use the DockingRules property instead.")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowDockRight
        {
            get
            {
                return this.DockingRules.AllowDockRight;
            }
            set
            {
                this.DockingRules.AllowDockRight = value;
            }
        }

        /// <summary>
        /// Indicates whether the user will be able to dock the control to the top side of the form.
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("Use the DockingRules property instead.")]
        public bool AllowDockTop
        {
            get
            {
                return this.DockingRules.AllowDockTop;
            }
            set
            {
                this.DockingRules.AllowDockTop = value;
            }
        }

        /// <summary>
        /// Indicates whether the user will be able to dock the control to the bottom side of the form.
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("Use the DockingRules property instead.")]
        [Browsable(false)]
        public bool AllowDockBottom
        {
            get
            {
                return this.DockingRules.AllowDockBottom;
            }
            set
            {
                this.DockingRules.AllowDockBottom = value;
            }
        }

        /// <summary>
        /// The rules with which to govern where the user can move the window.
        /// 
        /// </summary>
        [Description("The rules with which to govern where the user can move the window.")]
        [Category("Behavior")]
        public DockingRules DockingRules
        {
            get
            {
                return this.xd447c58f1b8b8e4b;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.xd447c58f1b8b8e4b = value;
            }
        }

        /// <summary>
        /// Determines whether the user will be able to press tab to bring the focus within the window when docked.
        /// 
        /// </summary>
        [Category("Behavior")]
        [Description("Determines whether the user will be able to press tab to bring the focus within the window when docked.")]
        [DefaultValue(false)]
        public bool AllowKeyboardFocus
        {
            get
            {
                return this.GetStyle(ControlStyles.Selectable);
            }
            set
            {
                this.SetStyle(ControlStyles.Selectable, value);
            }
        }

        /// <summary>
        /// Indicates whether this control will be closable by the user.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// When this property is set to true, a close button will be displayed in the titlebar of the layout system containing this control when the control is selected.
        /// 
        /// </remarks>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [Obsolete("Use the AllowClose property instead.", true)]
        public bool Closable
        {
            get
            {
                return this.AllowClose;
            }
            set
            {
                this.AllowClose = value;
            }
        }

        /// <summary>
        /// Indicates whether this control will be closable by the user.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// When this property is set to true, a close button will be displayed in the titlebar of the layout system containing this control when the control is selected.
        /// 
        /// </remarks>
        [DefaultValue(true)]
        [Description("Indicates whether this control will be closable by the user.")]
        [Category("Docking")]
        public virtual bool AllowClose
        {
            get
            {
                return this.x6c3086899dc42885;
            }
            set
            {
                this.x6c3086899dc42885 = value;
                this.x7735d9a753c63a0a();
            }
        }

        /// <summary>
        /// Indicates the maximum width of the tab representing the window.
        /// 
        /// </summary>
        [DefaultValue(0)]
        [Category("Layout")]
        [Description("Indicates the maximum width of the tab representing the window.")]
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
                this.x7735d9a753c63a0a();
            }
        }

        /// <summary>
        /// Indicates the minimum width of the tab representing the window.
        /// 
        /// </summary>
        [Description("Indicates the minimum width of the tab representing the window.")]
        [DefaultValue(0)]
        [Category("Layout")]
        public int MinimumTabWidth
        {
            get
            {
                return this.xcf3ab1252c42eac6;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value");
                this.xcf3ab1252c42eac6 = value;
                this.x7735d9a753c63a0a();
            }
        }

        /// <summary>
        /// Indicates whether an options button will be displayed in the titlebar for this window.
        /// 
        /// </summary>
        [DefaultValue(true)]
        [Category("Appearance")]
        [Description("Indicates whether an options button will be displayed in the titlebar for this window.")]
        public bool ShowOptions
        {
            get
            {
                return this.x1def1a42ad5b7095;
            }
            set
            {
                this.x1def1a42ad5b7095 = value;
                this.x7735d9a753c63a0a();
            }
        }

        /// <summary>
        /// Indicates whether the user will be able to put this control in to auto-hide mode.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// If all DockControls in a control layout system have this property set to true, a pushpin button will be displayed in the titlebar of the layout system
        ///             containing this control when the control is selected.
        /// </para>
        /// 
        /// <para>
        /// Control layout systems are "pinned" by default. Pressing the pushpin button will "unpin" the layout system and it will collapse in to a thin bar
        ///             alongside the edge of the containing DockContainer. It can be retrieved by clicking on or hovering over the buttons in this bar.
        /// </para>
        /// 
        /// </remarks>
        [Category("Docking")]
        [DefaultValue(true)]
        [Description("Indicates whether the user will be able to put this control in to auto-hide mode.")]
        public virtual bool AllowCollapse
        {
            get
            {
                return this.x9b80917b168ce488;
            }
            set
            {
                this.x9b80917b168ce488 = value;
                if (-1 != 0)
                    goto label_4;
                label_1:
                this.Collapsed = false;
                label_3:
                this.x7735d9a753c63a0a();
                return;
                label_4:
                if (!value)
                {
                    while (0 == 0 && !this.Collapsed)
                    {
                        if (0 == 0)
                            goto label_3;
                    }
                    goto label_1;
                }
                else
                    goto label_3;
            }
        }

        /// <summary>
        /// Gets or sets the text that appears as a ToolTip for the control tab.
        /// 
        /// </summary>
        [Localizable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Description("Gets or sets the text that appears as a ToolTip for the control tab.")]
        public virtual string ToolTipText
        {
            get
            {
                return this.xd84978f0dad7afcd;
            }
            set
            {
                if (value == null)
                    value = string.Empty;
                this.xd84978f0dad7afcd = value;
            }
        }

        /// <summary>
        /// The text to display on the tab for the DockControl. This can be different to the standard text, shown in titlebars.
        /// 
        /// </summary>
        [Localizable(true)]
        [Category("Appearance")]
        [Description("The text to display on the tab for the DockControl. This can be different to the standard text.")]
        public virtual string TabText
        {
            get
            {
                if (this.xc3d462fde66905e5.Length == 0)
                    return this.Text;
                else
                    return this.xc3d462fde66905e5;
            }
            set
            {
                if (value == null)
                    value = string.Empty;
                this.xc3d462fde66905e5 = value;
                this.x7735d9a753c63a0a();
            }
        }

        /// <summary>
        /// The size of the control when popped up from a collapsed state. Leave this as zero for the default size.
        /// 
        /// </summary>
        [Description("The size of the control when popped up from a collapsed state. Leave this as zero for the default size.")]
        [DefaultValue(0)]
        [Category("Docking")]
        public int PopupSize
        {
            get
            {
                return this.x5614e4ef0596c91d;
            }
            set
            {
                if (value < 0)
                {
                    if ((uint)value - (uint)value <= uint.MaxValue)
                        goto label_12;
                    else
                        goto label_9;
                }
                else
                    goto label_13;
                label_5:
                if (this.MetaData.x057495d927e64b9e)
                {
                    if (2 == 0)
                        goto label_13;
                }
                else
                    goto label_10;
                label_7:
                if (this.LayoutSystem == null || this.LayoutSystem.x10ac79a4257c7f52 == null)
                    return;
                if (this.LayoutSystem.x10ac79a4257c7f52.x23498f53d87354d4 == this.LayoutSystem)
                {
                    this.LayoutSystem.x10ac79a4257c7f52.xca843b3e9a1c605f = value;
                    return;
                }
                else if ((value & 0) == 0)
                    return;
                else
                    goto label_12;
                label_9:
                if ((uint)value - (uint)value < 0U)
                    goto label_12;
                label_10:
                this.MetaData.x3ef4455ea4965093(value);
                if ((uint)value + (uint)value <= uint.MaxValue)
                    goto label_7;
                else
                    goto label_5;
                label_12:
                throw new ArgumentException("Value must be at least equal to zero.");
                label_13:
                this.x5614e4ef0596c91d = value;
                if ((uint)value + (uint)value >= 0U)
                    goto label_5;
                else
                    goto label_9;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                label_8:
                this.x7735d9a753c63a0a();
                while (this.DockSituation == DockSituation.Floating)
                {
                    if (this.x410f3612b9a8f9de.HasSingleControlLayoutSystem)
                        goto label_9;
                    else
                        goto label_6;
                    label_1:
                    if (4 != 0)
                    {
                        if (0 == 0)
                            break;
                        else
                            goto label_8;
                    }
                    else
                        continue;
                    label_6:
                    if (0 == 0 || int.MinValue == 0)
                        break;
                    else
                        goto label_1;
                    label_9:
                    if (this.LayoutSystem.SelectedControl != this)
                        break;
                    this.x410f3612b9a8f9de.xd1bdd0ee5924b59e();
                    goto label_1;
                }
            }
        }

        internal Image x1999b243e321e38a
        {
            get
            {
                if (this.x564c6c527905c683 == null)
                    return DockControl.x28afaed1891a17a1;
                else
                    return this.x564c6c527905c683;
            }
        }

        /// <summary>
        /// The bounds of the tab that represents the DockControl within its parent layout system.
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
        /// The situation in which the window is currently docked.
        /// 
        /// </summary>
        [Browsable(false)]
        public DockSituation DockSituation
        {
            get
            {
                return this.xef84499526c04953;
            }
        }

        /// <summary>
        /// The image displayed for this control on docking tabs.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// If this parameter is set to a null reference, the default tab image (the SandDock logo) is used. For this reason, this parameter should ideally always
        ///             be set.
        /// 
        /// </remarks>
        [DefaultValue(typeof(Image), null)]
        [AmbientValue(typeof(Image), null)]
        [Description("The image displayed for this control on docking tabs.")]
        [Category("Appearance")]
        public Image TabImage
        {
            get
            {
                return this.x564c6c527905c683;
            }
            set
            {
                this.x564c6c527905c683 = value;
                this.x7735d9a753c63a0a();
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override System.Drawing.Size DefaultSize
        {
            get
            {
                return new System.Drawing.Size(250, 400);
            }
        }

        /// <summary>
        /// Raised when the dockable window is about to be closed.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// This event is always raised in response to either the user closing the control, or programmatically using the Close method. Its event arguments
        ///             provide a means to cancel the close.
        /// 
        /// </remarks>
        public event DockControlClosingEventHandler Closing;
        /// <summary>
        /// Raised when the dockable window has just been closed.
        /// 
        /// </summary>
        public event EventHandler Closed;
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
        /// Raised when the popup window has been opened to show the DockControl when it is collapsed.
        /// 
        /// </summary>
        public event EventHandler AutoHidePopupOpened;
        /// <summary>
        /// Raised when the popup window showing the collapsed DockControl has been closed.
        /// 
        /// </summary>
        public event EventHandler AutoHidePopupClosed;
        /// <summary>
        /// Raised when the control changes from one dock state to another.
        /// 
        /// </summary>
        public event EventHandler DockSituationChanged;

        /// <summary>
        /// Initializes a new instance of the DockControl class.
        /// 
        /// </summary>
        protected DockControl()
        {
            if (3 != 0)
                goto label_13;
            label_1:
            this.SetStyle(ControlStyles.Selectable, false);
            if (15 != 0)
            {
                this.BackColor = SystemColors.Control;
                this.xca874006c41dfe29 = this.DefaultSize;
                return;
            }
            else
                goto label_9;
            label_5:
            this.xfffbdea061bfa120 = new WindowMetaData();
            this.xd447c58f1b8b8e4b = this.CreateDockingRules();
            if (this.xd447c58f1b8b8e4b == null)
                throw new InvalidOperationException();
            if (2 != 0)
            {
                this.SetStyle(ControlStyles.ResizeRedraw, true);
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                goto label_1;
            }
            else
                goto label_12;
            label_7:
            if (4 == 0)
                goto label_11;
            label_8:
            if (0 == 0 && 0 == 0)
                goto label_5;
            label_9:
            if (0 == 0)
            {
                if (0 != 0)
                    goto label_8;
                else
                    goto label_5;
            }
            else
                goto label_7;
            label_11:
            if (2 == 0)
                goto label_13;
            else
                goto label_9;
            label_12:
            DockControl.x28afaed1891a17a1 = Image.FromStream(typeof(DockControl).Assembly.GetManifestResourceStream("TD.SandDock.sanddock.png"));
            goto label_11;
            label_13:
            if (DockControl.x28afaed1891a17a1 == null)
                goto label_12;
            else
                goto label_7;
        }

        /// <summary>
        /// Initializes a new instance of the DockControl class, containing the specified control and with the specified text.
        /// 
        /// </summary>
        /// <param name="manager">The SandDockManager responsible for layout of the control.</param><param name="control">The control to host within the DockControl.</param><param name="text">The text of the DockControl.</param>
        protected DockControl(SandDockManager manager, Control control, string text)
      : this()
        {
            if (manager == null)
                throw new ArgumentNullException("manager");
            if (1 == 0)
                return;
            if (control == null)
                throw new ArgumentNullException("control");
            if (text == null)
                goto label_19;
            label_16:
            this.Manager = manager;
            if (0 == 0)
                goto label_10;
            else
                goto label_17;
            label_2:
            while (text != null)
            {
                this.Text = text;
                if (int.MinValue != 0)
                    break;
            }
            return;
            label_3:
            if (control == null)
                goto label_2;
            label_7:
            this.SuspendLayout();
            if (0 == 0)
            {
                if (0 == 0)
                {
                    this.Controls.Add(control);
                    control.Dock = DockStyle.Fill;
                    if (0 == 0)
                    {
                        if (4 != 0)
                        {
                            control.BringToFront();
                            if (8 == 0)
                                goto label_9;
                        }
                        if (0 == 0)
                        {
                            this.ResumeLayout();
                            control.Visible = true;
                            if ((int)byte.MaxValue == 0 || 0 != 0)
                                goto label_3;
                            else
                                goto label_20;
                        }
                        else
                            goto label_3;
                    }
                }
                else
                    goto label_2;
            }
            else
                goto label_16;
            label_9:
            Form form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            if (0 != 0)
                goto label_19;
            else
                goto label_3;
            label_10:
            if (!(control is Form))
            {
                if (0 == 0)
                    goto label_3;
                else
                    goto label_7;
            }
            else
                goto label_18;
            label_17:
            if (0 != 0)
                goto label_2;
            label_18:
            form = (Form)control;
            if (0 == 0)
                goto label_9;
            label_20:
            if (0 != 0)
                return;
            else
                goto label_2;
            label_19:
            text = string.Empty;
            goto label_16;
        }

        /// <summary>
        /// Creates the default set of docking rules for the window.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// An instance of the DockingRules class.
        /// </returns>
        protected abstract DockingRules CreateDockingRules();

        internal void xbdd4aaac1291a8c7(bool x364c1e3b189d47fe)
        {
            this.SetVisibleCore(x364c1e3b189d47fe);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.xb6a159a84cb992d6 != null && this.AllowKeyboardNavigation)
            {
                if (keyData == (Keys.Prior | Keys.Control))
                    goto label_35;
                else
                    goto label_16;
                label_2:
                if (keyData == Keys.Escape)
                    goto label_14;
                else
                    goto label_36;
                label_4:
                DockControl recentlyUsedWindow;
                recentlyUsedWindow.Activate();
                goto label_6;
                label_5:
                if (recentlyUsedWindow != null)
                    goto label_4;
                label_6:
                return true;
                label_11:
                if (this.xb6a159a84cb992d6.IsInContainer)
                {
                    this.xb6a159a84cb992d6.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(this, new System.Drawing.Point(0, 0), ContextMenuContext.Keyboard));
                    return true;
                }
                else
                    goto label_2;
                label_14:
                int index1;
                int index2 = 0;
                if (this.Manager != null)
                {
                    if (2 != 0)
                    {
                        if (this.DockSituation == DockSituation.Document)
                        {
                            if (false)
                                goto label_22;
                            else
                                goto label_36;
                        }
                        else
                        {
                            if (this.Manager.OwnerForm != null)
                                goto label_8;
                            label_7:
                            recentlyUsedWindow = this.Manager.FindMostRecentlyUsedWindow(DockSituation.Document);
                            if ((uint)index2 >= 0U)
                                goto label_5;
                            else
                                goto label_4;
                            label_8:
                            this.Manager.OwnerForm.Activate();
                            if (1 != 0)
                                goto label_7;
                            else
                                goto label_11;
                        }
                    }
                    else
                        goto label_25;
                }
                else
                    goto label_36;
                label_16:
                if (keyData != (Keys.Next | Keys.Control))
                {
                    if (keyData == (Keys.OemMinus | Keys.Alt))
                    {
                        if (0 == 0)
                            goto label_11;
                    }
                    else
                        goto label_2;
                }
                else
                    goto label_24;
                label_22:
                if (index2 >= this.xb6a159a84cb992d6.Controls.Count)
                    index2 = 0;
                this.xb6a159a84cb992d6.SelectedControl = this.xb6a159a84cb992d6.Controls[index2];
                if (this.xb6a159a84cb992d6.SelectedControl == this.xb6a159a84cb992d6.Controls[index2])
                    this.xb6a159a84cb992d6.Controls[index2].Activate();
                return true;
                label_24:
                index2 = this.xb6a159a84cb992d6.Controls.IndexOf(this) + 1;
                if (false)
                {
                    if (0 != 0)
                        goto label_5;
                    else
                        goto label_32;
                }
                else
                    goto label_30;
                label_25:
                if (this.xb6a159a84cb992d6.SelectedControl == this.xb6a159a84cb992d6.Controls[index1])
                    goto label_28;
                label_26:
                return true;
                label_28:
                this.xb6a159a84cb992d6.Controls[index1].Activate();
                if (false)
                {
                    if (1 != 0)
                        goto label_24;
                }
                else
                    goto label_26;
                label_30:
                if ((index2 | -2) != 0)
                    goto label_22;
                else
                    goto label_11;
                label_32:
                index1 = this.xb6a159a84cb992d6.Controls.Count - 1;
                label_34:
                this.xb6a159a84cb992d6.SelectedControl = this.xb6a159a84cb992d6.Controls[index1];
                if (0 == 0)
                    goto label_25;
                else
                    goto label_28;
                label_35:
                index1 = this.xb6a159a84cb992d6.Controls.IndexOf(this) - 1;
                if ((uint)index1 + (uint)index1 < 0U)
                {
                    if (0 == 0)
                    {
                        int num;
                        if (true)
                            goto label_2;
                        else
                            goto label_14;
                    }
                    else
                        goto label_11;
                }
                else if (index1 < 0)
                    goto label_32;
                else
                    goto label_34;
            }
            label_36:
            return base.ProcessCmdKey(ref msg, keyData);
        }

        internal void x7735d9a753c63a0a()
        {
            if (this.LayoutSystem == null)
                return;
            this.LayoutSystem.x3e0280cae730d1f2();
        }

        internal void x81444a37d39a0e4a()
        {
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void x63491667e252563e()
        {
            if (this.x4e7c2c44587adeda)
                return;
            if (this.Manager == null || (this.Manager.DocumentContainer == null || !this.Manager.DocumentContainer.x1ec2ea49664e1074))
                goto label_3;
            else
                goto label_9;
            label_2:
            if (this.Manager == null)
                return;
            this.Manager.OnDockControlActivated(new DockControlEventArgs(this));
            if (0 == 0)
                return;
            label_3:
            this.MetaData.x15481da58c59597a(DateTime.Now);
            goto label_2;
            label_9:
            if (int.MaxValue != 0)
                goto label_2;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (0 == 0)
                goto label_2;
            label_1:
            this.LayoutSystem.x317ed3bc8decf394 = true;
            goto label_4;
            label_2:
            while (this.LayoutSystem == null)
            {
                if ((int)byte.MaxValue != 0)
                    goto label_4;
            }
            goto label_1;
            label_4:
            this.x63491667e252563e();
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (this.LayoutSystem == null)
                return;
            this.LayoutSystem.x317ed3bc8decf394 = false;
        }

        /// <summary>
        /// Used to set metadata ready for the next time the window is opened.
        /// 
        /// </summary>
        /// <param name="dockSituation">The dock situation the window will adopt next time it is opened.</param>
        public void SetPositionMetaData(DockSituation dockSituation)
        {
            if (this.DockSituation != DockSituation.None)
            {
                if (3 != 0)
                    throw new InvalidOperationException("This operation is only valid when the window is not currently open.");
            }
            else
            {
                if (dockSituation == DockSituation.None)
                    throw new ArgumentException("dockSituation");
                this.xfffbdea061bfa120.xb0e0bc77d88737a8(dockSituation);
                this.xfffbdea061bfa120.x0ba17c4cff658fcf(dockSituation);
            }
        }

        /// <summary>
        /// Used to set metadata ready for the next time the window is opened.
        /// 
        /// </summary>
        /// <param name="dockSituation">The dock situation the window will adopt next time it is opened.</param><param name="dockLocation">The side of the container at which the window will sit next time it is docked.</param>
        public void SetPositionMetaData(DockSituation dockSituation, ContainerDockLocation dockLocation)
        {
            if (this.DockSituation != DockSituation.None)
                throw new InvalidOperationException("This operation is only valid when the window is not currently open.");
            if (dockSituation == DockSituation.None)
                throw new ArgumentException("dockSituation");
            if (int.MinValue == 0)
                goto label_11;
            label_4:
            if (dockLocation != ContainerDockLocation.Center)
            {
                this.xfffbdea061bfa120.xb0e0bc77d88737a8(dockSituation);
                if (dockSituation == DockSituation.Document || dockSituation == DockSituation.Docked)
                    this.xfffbdea061bfa120.x0ba17c4cff658fcf(dockSituation);
                this.xfffbdea061bfa120.xfca44c52f41f0e26(dockLocation);
                return;
            }
            label_6:
            throw new ArgumentException("dockLocation");
            label_11:
            if (0 != 0)
            {
                if (4 != 0)
                    goto label_4;
            }
            else
                goto label_6;
        }

        internal static void xe1da469e4d960f02(Control x43bec302f92080b9, Graphics x41347a961b838962, FQ.FreeDock.Rendering.BorderStyle xacfbd7a08ba56c78)
        {
            if (xacfbd7a08ba56c78 == FQ.FreeDock.Rendering.BorderStyle.None)
                return;
            Border3DStyle style;
            Rectangle rectangle;
            Color controlDark;
            do
            {
                rectangle = new Rectangle(0, 0, x43bec302f92080b9.Width, x43bec302f92080b9.Height);
                if (3 != 0 && xacfbd7a08ba56c78 != FQ.FreeDock.Rendering.BorderStyle.Flat)
                {
                    switch (xacfbd7a08ba56c78)
                    {
                        case FQ.FreeDock.Rendering.BorderStyle.Flat:
                            goto label_5;
                        case FQ.FreeDock.Rendering.BorderStyle.RaisedThick:
                            style = Border3DStyle.Raised;
                            if (0 == 0)
                            {
                                if (1 != 0)
                                    goto label_2;
                                else
                                    goto label_20;
                            }
                            else
                                break;
                        case FQ.FreeDock.Rendering.BorderStyle.RaisedThin:
                            goto label_3;
                        case FQ.FreeDock.Rendering.BorderStyle.SunkenThick:
                            goto label_4;
                        default:
                            goto label_1;
                    }
                }
                else
                    goto label_23;
                label_9:
                --rectangle.Width;
                --rectangle.Height;
                label_10:
                if (0 != 0)
                    ;
                continue;
                label_20:
                DockControl window = x43bec302f92080b9 as DockControl;
                Color backColor;
                if (window != null && window.Manager != null)
                {
                    if (0 == 0)
                    {
                        window.Manager.Renderer.ModifyDefaultWindowColors(window, ref backColor, ref controlDark);
                        goto label_9;
                    }
                    else
                        goto label_10;
                }
                else
                    goto label_9;
                label_23:
                backColor = x43bec302f92080b9.BackColor;
                controlDark = SystemColors.ControlDark;
                if (0 == 0)
                    goto label_20;
                else
                    goto label_21;
            }
            while (0 != 0);
            goto label_12;
            label_1:
            style = Border3DStyle.SunkenOuter;
            label_2:
            ControlPaint.DrawBorder3D(x41347a961b838962, rectangle, style);
            return;
            label_3:
            style = Border3DStyle.RaisedInner;
            goto label_2;
            label_4:
            style = Border3DStyle.Sunken;
            goto label_2;
            label_5:
            style = Border3DStyle.Flat;
            goto label_2;
            label_12:
            using (Pen pen = new Pen(controlDark))
            {
                x41347a961b838962.DrawRectangle(pen, rectangle);
                return;
            }
            label_21:
            ;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DockControl.xe1da469e4d960f02((Control)this, e.Graphics, this.xacfbd7a08ba56c78);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle clientRectangle = this.ClientRectangle;
            label_16:
            Color backColor;
            do
            {
                do
                {
                    switch (this.BorderStyle)
                    {
                        case FQ.FreeDock.Rendering.BorderStyle.Flat:
                        case FQ.FreeDock.Rendering.BorderStyle.RaisedThin:
                        case FQ.FreeDock.Rendering.BorderStyle.SunkenThin:
                            clientRectangle.Inflate(-1, -1);
                            if (4 == 0)
                                goto label_4;
                            else
                                break;
                        case FQ.FreeDock.Rendering.BorderStyle.RaisedThick:
                        case FQ.FreeDock.Rendering.BorderStyle.SunkenThick:
                            clientRectangle.Inflate(-2, -2);
                            break;
                    }
                    backColor = this.BackColor;
                }
                while (3 == 0);
                Color transparent = Color.Transparent;
                if (this.Manager != null)
                    goto label_10;
                label_6:
                while (clientRectangle != this.ClientRectangle)
                {
                    e.Graphics.SetClip(clientRectangle);
                    if (0 == 0)
                    {
                        if (int.MinValue != 0 && (int)byte.MaxValue != 0)
                        {
                            if (0 != 0)
                            {
                                if (4 == 0)
                                    goto label_3;
                            }
                            else
                                break;
                        }
                        else
                            continue;
                    }
                    goto label_16;
                }
                goto label_2;
                label_10:
                this.Manager.Renderer.ModifyDefaultWindowColors(this, ref backColor, ref transparent);
                goto label_6;
            }
            while (0 != 0);
            label_1:
            base.OnPaintBackground(e);
            return;
            label_2:
            if (this.BackgroundImage != null)
                goto label_1;
            label_3:
            xa811784015ed8842.x91433b5e99eb7cac(e.Graphics, backColor);
            label_4:
            if ((int)byte.MaxValue == 0)
                goto label_2;
        }

        internal void x56e964269d48cfcc(DockContainer x0467b00af7810f0c)
        {
            if (x0467b00af7810f0c != null)
            {
                if (0 == 0)
                    goto label_4;
                label_2:
                if (x0467b00af7810f0c.Manager != this.Manager)
                {
                    this.Manager = x0467b00af7810f0c.Manager;
                    goto label_3;
                }
                else
                    goto label_3;
                label_4:
                while (x0467b00af7810f0c.Manager != null)
                {
                    if (0 == 0)
                        goto label_2;
                }
            }
            label_3:
            this.x44fd51d909a57a2a();
        }

        internal void x44fd51d909a57a2a()
        {
            if (this.LayoutSystem == null || this.LayoutSystem.DockContainer == null)
                goto label_18;
            else
                goto label_17;
            label_1:
            x129cb2a2bdfd0ab2 xfffbdea061bfa120;
            if (xfffbdea061bfa120 != null)
                this.x301b78956138d163(xfffbdea061bfa120);
            label_2:
            DockSituation xbcea506a33cf9111;
            this.x409072a6bb877e49(xbcea506a33cf9111);
            return;
            label_5:
            if (this.Manager == null)
                goto label_1;
            label_8:
            DockContainer[] dockContainers = this.Manager.GetDockContainers(this.LayoutSystem.DockContainer.Dock);
            this.xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e = dockContainers.Length;
            this.xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 = Array.IndexOf<DockContainer>(dockContainers, this.LayoutSystem.DockContainer);
            goto label_1;
            label_11:
            this.xfffbdea061bfa120.x0ba17c4cff658fcf(DockSituation.Docked);
            if (int.MinValue != 0)
            {
                this.xfffbdea061bfa120.xfca44c52f41f0e26(LayoutUtilities.x3650f3b579b2b4d2(this.LayoutSystem.DockContainer.Dock));
                this.xfffbdea061bfa120.x3ef4455ea4965093(this.LayoutSystem.DockContainer.ContentSize);
                if (-2 != 0)
                    goto label_5;
                else
                    goto label_8;
            }
            else
                goto label_1;
            label_13:
            DockSituation dockSituation;
            switch (dockSituation)
            {
                case DockSituation.Docked:
                    xfffbdea061bfa120 = (x129cb2a2bdfd0ab2)this.xfffbdea061bfa120.xe62a3d24e0fde928;
                    goto label_11;
                case DockSituation.Document:
                    xfffbdea061bfa120 = this.xfffbdea061bfa120.x25e1dbd0e63329bf;
                    break;
                case DockSituation.Floating:
                    xfffbdea061bfa120 = this.xfffbdea061bfa120.xba74b873ae2f845a;
                    this.xfffbdea061bfa120.x87f4a9b62a380563(((x410f3612b9a8f9de)this.LayoutSystem.DockContainer).x0217cda8370c1f17);
                    if (-1 != 0)
                        goto label_1;
                    else
                        goto label_5;
                default:
                    if (15 != 0)
                    {
                        if (4 == 0)
                            break;
                        else
                            goto label_1;
                    }
                    else
                        goto case DockSituation.Document;
            }
            this.xfffbdea061bfa120.x0ba17c4cff658fcf(DockSituation.Document);
            if (0 == 0)
                goto label_1;
            label_15:
            if (xbcea506a33cf9111 != DockSituation.None)
                this.xfffbdea061bfa120.xb0e0bc77d88737a8(xbcea506a33cf9111);
            xfffbdea061bfa120 = (x129cb2a2bdfd0ab2)null;
            dockSituation = xbcea506a33cf9111;
            goto label_13;
            label_17:
            xbcea506a33cf9111 = LayoutUtilities.x8d287cc6f0a2f529(this.LayoutSystem.DockContainer);
            if (int.MaxValue == 0)
                goto label_2;
            else
                goto label_15;
            label_18:
            xbcea506a33cf9111 = DockSituation.None;
            if ((int)byte.MaxValue != 0)
            {
                if (int.MaxValue == 0)
                    goto label_11;
                else
                    goto label_15;
            }
            else
                goto label_13;
        }

        private void x301b78956138d163(x129cb2a2bdfd0ab2 xfffbdea061bfa120)
        {
            if (this.LayoutSystem == null)
                return;
            xfffbdea061bfa120.x703937d70a13725c = this.LayoutSystem.x0217cda8370c1f17;
            xfffbdea061bfa120.x8c8f170696764fac = this.LayoutSystem.Controls.IndexOf(this);
            xfffbdea061bfa120.x3a4e0c379519d4a2 = this.LayoutSystem.WorkingSize;
            xfffbdea061bfa120.x61743036ad30763d = LayoutUtilities.x27f6597db2aeb7d7(this.LayoutSystem);
        }

        private void x550f9212086279db()
        {
            if (this.IsDisposed)
                throw new ObjectDisposedException(this.GetType().Name);
        }

        internal void xb37e72cd3ce9b2b4()
        {
            this.CreateControl();
        }

        private void x298b2fdefeb76ab8()
        {
            this.x550f9212086279db();
            if (this.manager == null)
                throw new InvalidOperationException("No SandDockManager is associated with this DockControl. To create an association, set the Manager property.");
        }

        private void xc64dfbbdd2fa7bf6()
        {
            this.x298b2fdefeb76ab8();
            if (this.Manager.DockSystemContainer == null)
                throw new InvalidOperationException("The SandDockManager associated with this DockControl does not have its DockSystemContainer property set.");
        }

        /// <summary>
        /// Opens the window in a floating state.
        /// 
        /// </summary>
        public void OpenFloating()
        {
            this.OpenFloating(WindowOpenMethod.OnScreenActivate);
        }

        /// <summary>
        /// Opens the window in a floating state, forcing a new floating window to be created.
        /// 
        /// </summary>
        /// <param name="bounds">The screen boundaries at which to place the new floating window.</param><param name="openMethod">The level to which the window is brought to the forefront.</param>
        public void OpenFloating(Rectangle bounds, WindowOpenMethod openMethod)
        {
            this.x298b2fdefeb76ab8();
            if (int.MinValue != 0)
                goto label_3;
            label_1:
            if (0 != 0)
                ;
            this.MetaData.x87f4a9b62a380563(Guid.Empty);
            this.MetaData.xba74b873ae2f845a.x703937d70a13725c = Guid.Empty;
            this.FloatingLocation = bounds.Location;
            this.FloatingSize = bounds.Size;
            this.OpenFloating(openMethod);
            return;
            label_3:
            this.Remove();
            goto label_1;
        }

        /// <summary>
        /// Opens the window in a floating state, at the specified bounds.
        /// 
        /// </summary>
        /// <param name="openMethod">The level to which the window is brought to the forefront.</param>
        public void OpenFloating(WindowOpenMethod openMethod)
        {
            this.x298b2fdefeb76ab8();
            label_25:
            this.xb37e72cd3ce9b2b4();
            if (-1 == 0)
                return;
            while (this.DockSituation != DockSituation.Floating)
            {
                Rectangle xda73fcb97c77d998 = this.xc0154d85fceb081c();
                if (3 == 0)
                    goto label_13;
                else
                    goto label_24;
                label_8:
                ControlLayoutSystem controlLayoutSystem;
                controlLayoutSystem.x0217cda8370c1f17 = this.MetaData.xba74b873ae2f845a.x703937d70a13725c;
                x410f3612b9a8f9de x410f3612b9a8f9de;
                x410f3612b9a8f9de.LayoutSystem.LayoutSystems.Add((LayoutSystemBase)controlLayoutSystem);
                x410f3612b9a8f9de.x159713d3b60fae0c(xda73fcb97c77d998, true, openMethod == WindowOpenMethod.OnScreenActivate);
                if (0 == 0)
                    break;
                else
                    goto label_10;
                label_9:
                x410f3612b9a8f9de = new x410f3612b9a8f9de(this.Manager, this.xfffbdea061bfa120.LastFloatingWindowGuid);
                label_10:
                controlLayoutSystem = x410f3612b9a8f9de.CreateNewLayoutSystem(this, this.xfffbdea061bfa120.xba74b873ae2f845a.x3a4e0c379519d4a2);
                if (!(this.MetaData.xba74b873ae2f845a.x703937d70a13725c == Guid.Empty))
                    goto label_8;
                label_11:
                this.MetaData.xba74b873ae2f845a.x703937d70a13725c = Guid.NewGuid();
                goto label_8;
                label_13:
                if (this.xfffbdea061bfa120.LastFloatingWindowGuid == Guid.Empty)
                {
                    this.xfffbdea061bfa120.x87f4a9b62a380563(Guid.NewGuid());
                    goto label_9;
                }
                else
                    goto label_9;
                label_24:
                if (int.MinValue != 0)
                {
                    if (1 != 0)
                        goto label_21;
                    label_17:
                    if (controlLayoutSystem == null)
                    {
                        x410f3612b9a8f9de = this.Manager.FindFloatingDockContainer(this.MetaData.LastFloatingWindowGuid);
                        if (x410f3612b9a8f9de != null)
                        {
                            if (0 == 0)
                            {
                                x5678bb8d80c0f12e x5678bb8d80c0f12e = LayoutUtilities.x2f8f74d308cc9f3f((DockContainer)x410f3612b9a8f9de, this.MetaData.xba74b873ae2f845a.x61743036ad30763d);
                                controlLayoutSystem = x5678bb8d80c0f12e.x07bf3386da210f81.DockContainer.CreateNewLayoutSystem(this, this.MetaData.xba74b873ae2f845a.x3a4e0c379519d4a2);
                                if (this.MetaData.xba74b873ae2f845a.x703937d70a13725c == Guid.Empty)
                                    this.MetaData.xba74b873ae2f845a.x703937d70a13725c = Guid.NewGuid();
                                controlLayoutSystem.x0217cda8370c1f17 = this.MetaData.xba74b873ae2f845a.x703937d70a13725c;
                                if (2 != 0)
                                {
                                    x5678bb8d80c0f12e.x07bf3386da210f81.LayoutSystems.Insert(x5678bb8d80c0f12e.xd1bdf42207dd3638, (LayoutSystemBase)controlLayoutSystem);
                                    break;
                                }
                                else
                                    continue;
                            }
                            else if (int.MinValue != 0)
                                goto label_9;
                            else
                                goto label_8;
                        }
                        else
                            goto label_13;
                    }
                    else
                    {
                        controlLayoutSystem.Controls.Insert(Math.Min(this.MetaData.xba74b873ae2f845a.x8c8f170696764fac, controlLayoutSystem.Controls.Count), this);
                        if (openMethod == WindowOpenMethod.OnScreen)
                            break;
                        this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
                        if (int.MaxValue != 0)
                        {
                            if (15 != 0)
                                break;
                            else
                                goto label_11;
                        }
                        else
                            goto label_13;
                    }
                    label_21:
                    this.Remove();
                    controlLayoutSystem = LayoutUtilities.xba5fd484c0e6478b(this.Manager, DockSituation.Floating, this.MetaData.xba74b873ae2f845a);
                    goto label_17;
                }
                else
                    goto label_25;
            }
        }

        internal Rectangle xc0154d85fceb081c()
        {
            this.x298b2fdefeb76ab8();
            if (0 == 0 && (1 == 0 || this.xc868bd63c888e533.X == -1 && this.xc868bd63c888e533.Y == -1))
                this.xc868bd63c888e533 = this.GetDefaultFloatingLocation();
            return new Rectangle(this.xc868bd63c888e533, this.xca874006c41dfe29);
        }

        /// <summary>
        /// Calculates the default floating location for the window.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// When a window does not have a record of any previous floating coordinates, this method is called to get the default location. Once a window has been floated once, its
        ///             floating position is saved along with the serialized window layout and the method will not be called again.
        /// </para>
        /// 
        /// </remarks>
        /// 
        /// <returns>
        /// A location in screen coordinates.
        /// </returns>
        protected virtual System.Drawing.Point GetDefaultFloatingLocation()
        {
            System.Drawing.Point point;
            if (!this.x1a9802d2d8708515)
            {
                Rectangle workingArea = (this.Manager.DockSystemContainer == null ? Screen.PrimaryScreen : Screen.FromControl(this.Manager.DockSystemContainer)).WorkingArea;
                point = new System.Drawing.Point(workingArea.X + workingArea.Width / 2 - this.xca874006c41dfe29.Width / 2, workingArea.Y + workingArea.Height / 2 - this.xca874006c41dfe29.Height / 2);
                if (-1 != 0)
                    goto label_3;
            }
            do
            {
                point = this.LayoutSystem.DockContainer.PointToScreen(this.LayoutSystem.Bounds.Location) - new System.Drawing.Size(SystemInformation.CaptionHeight, SystemInformation.CaptionHeight);
            }
            while (0 != 0);
            label_3:
            return point;
        }

        /// <summary>
        /// Obtains a reference to the top-level Form object hosting the window while it is floating.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// An instance of the Form class.
        /// </returns>
        public Form GetFloatingForm()
        {
            if (this.DockSituation == DockSituation.Floating && this.Parent != null)
                return this.Parent.Parent as Form;
            else
                return (Form)null;
        }

        /// <summary>
        /// Opens the window at its last known position.
        /// 
        /// </summary>
        public abstract void Open();

        /// <summary>
        /// Opens the window at its last known location.
        /// 
        /// </summary>
        /// <param name="openMethod">The level to which the window is brought to the forefront.</param>
        public void Open(WindowOpenMethod openMethod)
        {
            this.x298b2fdefeb76ab8();
            if (0 == 0)
                goto label_5;
            label_1:
            this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
            if (0 != 0)
            {
                if (0 != 0)
                    ;
            }
            else if ((int)byte.MaxValue != 0)
                return;
            label_3:
            if (openMethod == WindowOpenMethod.OnScreen)
                return;
            else
                goto label_1;
            label_5:
            if (this.DockSituation == DockSituation.None)
            {
                switch (this.xfffbdea061bfa120.LastOpenDockSituation)
                {
                    case DockSituation.Docked:
                        this.OpenDocked(openMethod);
                        break;
                    case DockSituation.Document:
                        this.OpenDocument(openMethod);
                        break;
                    case DockSituation.Floating:
                        this.OpenFloating(openMethod);
                        break;
                    default:
                        goto label_3;
                }
            }
            else
                goto label_3;
        }

        internal void x6d1b64d6c637a91d(bool x53c0846b47593790)
        {
            if (this.LayoutSystem != null)
                goto label_8;
            label_1:
            if (!x53c0846b47593790)
                return;
            this.Activate();
            return;
            label_8:
            do
            {
                if (this.LayoutSystem.SelectedControl != this)
                    goto label_10;
                label_2:
                if (this.LayoutSystem.x10ac79a4257c7f52 != null)
                {
                    this.LayoutSystem.x10ac79a4257c7f52.xe6ff614263a59ef9(this, true, x53c0846b47593790);
                    if (((x53c0846b47593790 ? 1 : 0) | int.MinValue) != 0)
                        continue;
                }
                else
                    goto label_3;
                label_10:
                this.LayoutSystem.SelectedControl = this;
                if (this.LayoutSystem.SelectedControl != this)
                    goto label_11;
                else
                    goto label_2;
            }
            while (8 == 0);
            goto label_14;
            label_3:
            if (false)
                return;
            else
                goto label_1;
            label_11:
            return;
            label_14:
            if (false)
                ;
        }

        internal bool xe302f2203dc14a18(ContainerDockLocation xb9c2cfae130d9256)
        {
            switch (xb9c2cfae130d9256)
            {
                case ContainerDockLocation.Left:
                    return this.DockingRules.AllowDockLeft;
                case ContainerDockLocation.Right:
                    return this.DockingRules.AllowDockRight;
                case ContainerDockLocation.Top:
                    return this.DockingRules.AllowDockTop;
                case ContainerDockLocation.Bottom:
                    return this.DockingRules.AllowDockBottom;
                default:
                    return this.DockingRules.AllowTab;
            }
        }

        /// <summary>
        /// Removes the window from the layout.
        /// 
        /// </summary>
        public void Remove()
        {
            LayoutUtilities.xf1cbd48a28ce6e74(this);
        }

        /// <summary>
        /// Opens the DockControl at its last known docked location.
        /// 
        /// </summary>
        public void OpenDocked()
        {
            this.OpenDocked(this.xfffbdea061bfa120.LastFixedDockSide);
        }

        /// <summary>
        /// Opens the window at the specified docked location.
        /// 
        /// </summary>
        /// <param name="dockLocation">The location at which to open the window.</param>
        public void OpenDocked(ContainerDockLocation dockLocation)
        {
            if (dockLocation == this.xfffbdea061bfa120.LastFixedDockSide)
                this.OpenDocked(WindowOpenMethod.OnScreenSelect);
            else
                this.OpenDocked(dockLocation, WindowOpenMethod.OnScreenSelect);
        }

        /// <summary>
        /// Opens the window docked on the specified side of the container.
        /// 
        /// </summary>
        /// <param name="dockLocation">The side of the container at which to dock the window.</param><param name="openMethod">The level to which the window is brought to the forefront.</param>
        public void OpenDocked(ContainerDockLocation dockLocation, WindowOpenMethod openMethod)
        {
            if (dockLocation != ContainerDockLocation.Center)
                goto label_7;
            else
                goto label_5;
            label_3:
            this.OpenDocked(openMethod);
            return;
            label_5:
            if (0 == 0)
            {
                this.OpenDocument(openMethod);
                return;
            }
            else
                goto label_3;
            label_7:
            this.x298b2fdefeb76ab8();
            if (this.DockSituation == DockSituation.Docked && this.xfffbdea061bfa120.LastFixedDockSide == dockLocation)
                return;
            this.Remove();
            this.xfffbdea061bfa120.xfca44c52f41f0e26(dockLocation);
            this.xfffbdea061bfa120.xe62a3d24e0fde928.x703937d70a13725c = Guid.Empty;
            if (0 != 0)
                return;
            this.xfffbdea061bfa120.xe62a3d24e0fde928.x61743036ad30763d = new int[0];
            goto label_3;
        }

        /// <summary>
        /// Opens the window as a tabbed document.
        /// 
        /// </summary>
        /// <param name="openMethod">The level to which the window is brought to the forefront.</param>
        public void OpenDocument(WindowOpenMethod openMethod)
        {
            this.x298b2fdefeb76ab8();
            if ((int)byte.MaxValue == 0)
            {
                if (0 == 0)
                    goto label_13;
                else
                    goto label_6;
            }
            else
                goto label_23;
            label_5:
            if (openMethod == WindowOpenMethod.OnScreen || 0 != 0)
                return;
            this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
            if (-2 != 0)
                return;
            label_6:
            DockContainer container;
            ControlLayoutSystem controlLayoutSystem = container.CreateNewLayoutSystem(this, this.MetaData.x25e1dbd0e63329bf.x3a4e0c379519d4a2);
            label_7:
            container.LayoutSystem.LayoutSystems.Add((LayoutSystemBase)controlLayoutSystem);
            goto label_5;
            label_13:
            do
            {
                container = this.Manager.FindDockContainer(ContainerDockLocation.Center);
                if (4 != 0)
                {
                    if (container == null)
                        goto label_15;
                    label_11:
                    controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem(container);
                    if (controlLayoutSystem == null)
                        continue;
                    else
                        goto label_3;
                    label_15:
                    container = this.Manager.CreateNewDockContainer(ContainerDockLocation.Center, ContainerDockEdge.Inside, this.MetaData.DockedContentSize);
                    if (0 != 0)
                        goto label_11;
                    else
                        goto label_11;
                }
                else
                    goto label_7;
            }
            while (2 == 0);
            goto label_16;
            label_3:
            if (this.Manager.DocumentOpenPosition != DocumentContainerWindowOpenPosition.First)
            {
                controlLayoutSystem.Controls.Add(this);
                goto label_5;
            }
            else
            {
                controlLayoutSystem.Controls.Insert(0, this);
                goto label_5;
            }
            label_16:
            if (0 != 0)
                return;
            else
                goto label_6;
            label_23:
            this.xb37e72cd3ce9b2b4();
            if (this.DockSituation == DockSituation.Document || (2 == 0 || 0 != 0))
                return;
            if (0 == 0)
                goto label_22;
            label_18:
            controlLayoutSystem.Controls.Insert(Math.Min(this.xfffbdea061bfa120.xe62a3d24e0fde928.x8c8f170696764fac, controlLayoutSystem.Controls.Count), this);
            if (openMethod == WindowOpenMethod.OnScreen)
                return;
            this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
            return;
            label_22:
            this.Remove();
            if (0 == 0)
            {
                controlLayoutSystem = LayoutUtilities.xba5fd484c0e6478b(this.Manager, DockSituation.Document, this.xfffbdea061bfa120.x25e1dbd0e63329bf);
                if (controlLayoutSystem == null)
                    goto label_13;
                else
                    goto label_18;
            }
            else
                goto label_13;
        }

        /// <summary>
        /// Opens the window at the specified docked location.
        /// 
        /// </summary>
        /// <param name="openMethod">The level to which the window is brought to the forefront.</param>
        public void OpenDocked(WindowOpenMethod openMethod)
        {
            this.x298b2fdefeb76ab8();
            if (0 == 0)
                goto label_20;
            label_14:
            do
            {
                this.Remove();
                if (8 != 0)
                {
                    if (int.MinValue != 0)
                        goto label_16;
                    label_12:
                    if (-2 != 0)
                    {
                        if (int.MinValue != 0)
                        {
                            if (openMethod == WindowOpenMethod.OnScreen)
                                continue;
                            else
                                goto label_9;
                        }
                        else
                            break;
                    }
                    else
                        goto label_1;
                    label_16:
                    ControlLayoutSystem controlLayoutSystem = LayoutUtilities.xba5fd484c0e6478b(this.Manager, DockSituation.Docked, (x129cb2a2bdfd0ab2)this.xfffbdea061bfa120.xe62a3d24e0fde928);
                    if (controlLayoutSystem != null)
                    {
                        controlLayoutSystem.Controls.Insert(Math.Min(this.xfffbdea061bfa120.xe62a3d24e0fde928.x8c8f170696764fac, controlLayoutSystem.Controls.Count), this);
                        goto label_12;
                    }
                    else
                        goto label_4;
                }
                else
                    goto label_2;
            }
            while (2 == 0);
            goto label_19;
            label_1:
            this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
            return;
            label_2:
            if (openMethod == WindowOpenMethod.OnScreen)
                return;
            else
                goto label_1;
            label_4:
            x5678bb8d80c0f12e x5678bb8d80c0f12e = LayoutUtilities.x4689c8634e31fc55(this.Manager, this.xfffbdea061bfa120);
            ControlLayoutSystem newLayoutSystem = x5678bb8d80c0f12e.x07bf3386da210f81.DockContainer.CreateNewLayoutSystem(this, this.xfffbdea061bfa120.xe62a3d24e0fde928.x3a4e0c379519d4a2);
            if (this.MetaData.xe62a3d24e0fde928.x703937d70a13725c == Guid.Empty)
                goto label_5;
            label_3:
            newLayoutSystem.x0217cda8370c1f17 = this.MetaData.xe62a3d24e0fde928.x703937d70a13725c;
            x5678bb8d80c0f12e.x07bf3386da210f81.LayoutSystems.Insert(x5678bb8d80c0f12e.xd1bdf42207dd3638, (LayoutSystemBase)newLayoutSystem);
            goto label_2;
            label_5:
            this.MetaData.xe62a3d24e0fde928.x703937d70a13725c = Guid.NewGuid();
            goto label_3;
            label_9:
            this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
            return;
            label_19:
            if (4 == 0)
                return;
            else
                return;
            label_20:
            this.xb37e72cd3ce9b2b4();
            if (this.DockSituation != DockSituation.Docked && 0 == 0)
                goto label_14;
        }

        /// <summary>
        /// Causes the window to split itself off from other windows in its tab group.
        /// 
        /// </summary>
        /// <param name="direction">The side of the previous tab group at which to place the window.</param>
        public void Split(DockSide direction)
        {
            if (!this.x1a9802d2d8708515)
            {
                if (2 != 0)
                    goto label_9;
            }
            else
                goto label_10;
            label_4:
            if (direction == DockSide.None)
                throw new ArgumentException("direction");
            do
            {
                SizeF workingSize = this.LayoutSystem.WorkingSize;
                ControlLayoutSystem layoutSystem = this.LayoutSystem;
                if (15 != 0)
                {
                    LayoutUtilities.xf1cbd48a28ce6e74(this);
                    ControlLayoutSystem newLayoutSystem = layoutSystem.DockContainer.CreateNewLayoutSystem(this, workingSize);
                    layoutSystem.SplitForLayoutSystem((LayoutSystemBase)newLayoutSystem, direction);
                    this.Activate();
                    if (0 == 0)
                        goto label_8;
                }
                else
                    goto label_8;
            }
            while (2 != 0);
            goto label_10;
            label_8:
            if (0 == 0)
                return;
            label_9:
            throw new InvalidOperationException("A window cannot be split while it is not hosted in a DockContainer.");
            label_10:
            if (this.LayoutSystem.Controls.Count < 2)
                throw new InvalidOperationException("A minimum of 2 windows need to be present in a tab group before one can be split off. Check LayoutSystem.Controls.Count before calling this method.");
            else
                goto label_4;
        }

        /// <summary>
        /// Hides the DockControl, whatever its status.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This method removes the DockControl from its current container and optionally disposes it, depending on the CloseAction property.
        /// </para>
        /// 
        /// </remarks>
        public bool Close()
        {
            return this.x8ffe90e7fbccfccd(false);
        }

        internal bool x8ffe90e7fbccfccd(bool xc481dbe8dc50af3f)
        {
            DockControlClosingEventArgs e = new DockControlClosingEventArgs(this, false);
            if (0 == 0)
                goto label_14;
            label_2:
            if (this.CloseAction == DockControlCloseAction.Dispose)
                base.Dispose();
            else
                goto label_15;
            label_3:
            if (0 == 0)
            {
                if (1 != 0)
                    goto label_15;
                else
                    goto label_9;
            }
            else
                goto label_2;
            label_5:
            if (e.Cancel)
                return false;
            LayoutUtilities.xf1cbd48a28ce6e74(this);
            if (true)
            {
                this.OnClosed(EventArgs.Empty);
                goto label_2;
            }
            else
                goto label_15;
            label_9:
            if (false)
            {
                if (false)
                    goto label_3;
            }
            else
                goto label_12;
            label_11:
            this.OnClosing(e);
            goto label_5;
            label_12:
            if (!e.Cancel)
                goto label_11;
            else
                goto label_5;
            label_14:
            if (this.Manager != null)
            {
                this.Manager.OnDockControlClosing(e);
                goto label_12;
            }
            else
                goto label_9;
            label_15:
            return true;
        }

        /// <summary>
        /// Raises the Closing event.
        /// 
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected internal virtual void OnClosing(DockControlClosingEventArgs e)
        {
            if (this.Closing == null)
                return;
            this.Closing((object)this, e);
        }

        /// <summary>
        /// Raises the Closed event.
        /// 
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected internal virtual void OnClosed(EventArgs e)
        {
            if (this.Closed == null)
                return;
            this.Closed((object)this, e);
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
        /// Raises the DockSituationChanged event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected virtual void OnDockSituationChanged(EventArgs e)
        {
            if (this.DockSituationChanged == null)
                return;
            this.DockSituationChanged((object)this, e);
        }

        /// <summary>
        /// Called when the user double clicks on the Tab for the window.
        /// 
        /// </summary>
        protected internal virtual void OnTabDoubleClick()
        {
            switch (this.DockSituation)
            {
                case DockSituation.Docked:
                case DockSituation.Document:
                    if (!this.DockingRules.AllowFloat)
                        return;
                    this.OpenFloating(WindowOpenMethod.OnScreenActivate);
                    if (int.MaxValue != 0)
                        return;
                    else
                        goto label_6;
                case DockSituation.Floating:
                    if (this.xfffbdea061bfa120.LastFixedDockSituation != DockSituation.Docked)
                        goto label_6;
                    else
                        break;
                default:
                    return;
            }
            label_5:
            if (this.xe302f2203dc14a18(this.xfffbdea061bfa120.LastFixedDockSide))
            {
                this.OpenDocked(WindowOpenMethod.OnScreenActivate);
                return;
            }
            label_6:
            if (this.xfffbdea061bfa120.LastFixedDockSituation != DockSituation.Document)
                return;
            if (0 == 0)
            {
                if (!this.xe302f2203dc14a18(ContainerDockLocation.Center) || -2 == 0)
                    return;
                if (0 != 0)
                    ;
                this.OpenDocument(WindowOpenMethod.OnScreenActivate);
            }
            else
                goto label_5;
        }

        /// <summary>
        /// Shows the control and sets focus to it.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This method ensures the control is the selected one within the parent layout system and then sets focus to it.
        /// </para>
        /// 
        /// </remarks>
        public void Activate()
        {
            if (this.LayoutSystem == null || this.Parent == null)
                return;
            if (this.LayoutSystem.SelectedControl != this)
                goto label_20;
            label_15:
            if (this.DockSituation == DockSituation.Floating)
                goto label_18;
            label_17:
            if (!this.IsOpen || 0 != 0)
                return;
            this.x4e7c2c44587adeda = true;
            try
            {
                this.Parent.GetContainerControl().ActiveControl = this.ActiveControl;
                if (0 == 0)
                {
                    while (!this.ContainsFocus)
                    {
                        if (this.PrimaryControl != null)
                            goto label_10;
                        else
                            goto label_9;
                        label_4:
                        if (!this.ContainsFocus)
                        {
                            if (this.Controls.Count != 1)
                                goto label_7;
                            label_6:
                            this.Controls[0].Focus();
                            break;
                            label_7:
                            this.Focus();
                            if (0 == 0)
                            {
                                if (0 != 0)
                                    goto label_6;
                                else
                                    break;
                            }
                            else
                                goto label_10;
                        }
                        else if (0 == 0)
                            break;
                        else
                            continue;
                        label_9:
                        this.SelectNextControl((Control)this, true, true, true, true);
                        goto label_4;
                        label_10:
                        this.PrimaryControl.Focus();
                        goto label_4;
                    }
                }
            }
            finally
            {
                this.x4e7c2c44587adeda = false;
            }
            this.x63491667e252563e();
            return;
            label_18:
            this.x410f3612b9a8f9de.x5b7f6ddd07ded8cd();
            goto label_17;
            label_20:
            this.LayoutSystem.SelectedControl = this;
            if (this.LayoutSystem.SelectedControl == this)
                goto label_15;
        }

        /// <summary>
        /// Docks the DockControl next to an existing dockable window.
        /// 
        /// </summary>
        /// <param name="existingWindow">The dockable window to place the DockControl next to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use the OpenWith method instead.")]
        public void DockNextTo(DockControl existingWindow)
        {
            this.OpenWith(existingWindow);
        }

        /// <summary>
        /// Docks the window grouped with an existing window.
        /// 
        /// </summary>
        /// <param name="existingWindow">The dockable window to place the DockControl next to.</param>
        public void OpenWith(DockControl existingWindow)
        {
            if (existingWindow != null)
                goto label_4;
            else
                goto label_6;
            label_1:
            if (existingWindow.DockSituation == DockSituation.None)
                throw new InvalidOperationException("The specified window is not open.");
            this.Remove();
            existingWindow.LayoutSystem.Controls.Add(this);
            return;
            label_4:
            if (existingWindow == this)
                return;
            else
                goto label_1;
            label_6:
            if (0 == 0)
                throw new ArgumentNullException();
            else
                goto label_1;
        }

        /// <summary>
        /// Opens the window next to an existing window.
        /// 
        /// </summary>
        /// <param name="existingWindow">The existing window next to which to open the window.</param><param name="side">The side of the existing window at which to place the new window.</param>
        public void OpenBeside(DockControl existingWindow, DockSide side)
        {
            if (existingWindow != null)
            {
                if (existingWindow == this)
                    return;
                if (existingWindow.DockSituation == DockSituation.None)
                    throw new InvalidOperationException("The specified window is not open.");
                this.Remove();
                existingWindow.LayoutSystem.SplitForLayoutSystem((LayoutSystemBase)new ControlLayoutSystem(this.MetaData.xe62a3d24e0fde928.x3a4e0c379519d4a2, new DockControl[1]
                {
                    this
                }, this), side);
                if (0 != 0 || -1 != 0)
                    return;
            }
            throw new ArgumentNullException();
        }

        /// <summary>
        /// Docks the DockControl in a new DockContainer.
        /// 
        /// </summary>
        /// <param name="dockLocation">The location in the form at which to place the new container.</param><param name="edge">Whether to place the new container on the inside or outside of existing controls.</param>
        public void DockInNewContainer(ContainerDockLocation dockLocation, ContainerDockEdge edge)
        {
            this.xc64dfbbdd2fa7bf6();
            this.Remove();
            DockContainer newDockContainer = this.Manager.CreateNewDockContainer(dockLocation, edge, this.xfffbdea061bfa120.DockedContentSize);
            ControlLayoutSystem newLayoutSystem = newDockContainer.CreateNewLayoutSystem(this, (SizeF)this.FloatingSize);
            newDockContainer.LayoutSystem.LayoutSystems.Add((LayoutSystemBase)newLayoutSystem);
        }

        internal void x02847d0dec2e498a(ControlLayoutSystem x6e150040c8d97700, int xc0c4c459c6ccbd00)
        {
            if (this.xb6a159a84cb992d6 != x6e150040c8d97700)
            {
                LayoutUtilities.xf1cbd48a28ce6e74(this);
                x6e150040c8d97700.Controls.Insert(xc0c4c459c6ccbd00, this);
                goto label_3;
            }
            label_2:
            x6e150040c8d97700.Controls.SetChildIndex(this, xc0c4c459c6ccbd00);
            label_3:
            x6e150040c8d97700.SelectedControl = this;
            if ((uint)xc0c4c459c6ccbd00 < 0U)
                goto label_2;
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
        /// Raises the AutoHidePopupClosed event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected internal virtual void OnAutoHidePopupClosed(EventArgs e)
        {
            if (this.AutoHidePopupClosed == null)
                return;
            this.AutoHidePopupClosed((object)this, e);
        }

        /// <summary>
        /// Raises the AutoHidePopupOpened event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected internal virtual void OnAutoHidePopupOpened(EventArgs e)
        {
            if (this.AutoHidePopupOpened == null)
                return;
            this.AutoHidePopupOpened((object)this, e);
        }

        internal void xb2b69aae23a4ae6d(ControlLayoutSystem x6e150040c8d97700)
        {
            this.xb6a159a84cb992d6 = x6e150040c8d97700;
        }

        private bool ShouldSerializeDockingRules()
        {
            DockingRules dockingRules = this.CreateDockingRules();
            if (-1 == 0 || dockingRules.AllowDockTop == this.DockingRules.AllowDockTop && 0 == 0)
            {
                label_9:
                while (4 != 0)
                {
                    while (dockingRules.AllowDockBottom == this.DockingRules.AllowDockBottom)
                    {
                        if ((int)byte.MaxValue == 0)
                        {
                            if (0 != 0)
                            {
                                if (0 == 0)
                                {
                                    if (0 == 0)
                                        break;
                                }
                                else
                                    goto label_11;
                            }
                            else
                                goto label_9;
                        }
                        else if (0 == 0)
                            goto label_4;
                        else
                            goto label_1;
                    }
                    goto label_13;
                }
                goto label_10;
                label_1:
                if (0 != 0)
                    goto label_10;
                label_2:
                if (dockingRules.AllowDockRight != this.DockingRules.AllowDockRight || dockingRules.AllowTab != this.DockingRules.AllowTab)
                    goto label_13;
                else
                    goto label_11;
                label_4:
                if (dockingRules.AllowDockLeft != this.DockingRules.AllowDockLeft)
                    goto label_13;
                else
                    goto label_1;
                label_10:
                if (2 != 0)
                    goto label_4;
                else
                    goto label_2;
                label_11:
                return dockingRules.AllowFloat != this.DockingRules.AllowFloat;
            }
            label_13:
            return true;
        }

        private bool ShouldSerializeTabText()
        {
            if (this.xc3d462fde66905e5.Length != 0)
                return this.xc3d462fde66905e5 != this.Text;
            else
                return false;
        }

        private void x409072a6bb877e49(DockSituation xbcea506a33cf9111)
        {
            if (this.x131b418d4c565c70)
                throw new InvalidOperationException("The requested operation is not valid on a window that is currently engaged in an activity further up the call stack. Consider using BeginInvoke to postpone the operation until the stack has unwound.");
            if (xbcea506a33cf9111 == this.xef84499526c04953)
                return;
            this.xef84499526c04953 = xbcea506a33cf9111;
            this.x131b418d4c565c70 = true;
            try
            {
                this.OnDockSituationChanged(EventArgs.Empty);
            }
            finally
            {
                this.x131b418d4c565c70 = false;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (this.xadad18dc04073a00)
                return;
            this.x7735d9a753c63a0a();
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.xb6a159a84cb992d6 != null)
                    LayoutUtilities.xf1cbd48a28ce6e74(this);

                if (this.Manager != null)
                    this.Manager = null;
            }
            base.Dispose(disposing);


        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 33 && !this.ContainsFocus)
            {
                this.Activate();
            }
        }
    }
}
