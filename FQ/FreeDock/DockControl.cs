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
        private const int WM_MOUSEACTIVATE = 0x21;
        internal Rectangle tabBounds = Rectangle.Empty;
        internal Rectangle x700c42042910e68b = Rectangle.Empty;
        private string toolTipText = "";
        private string tabText = string.Empty;
        private bool allowClose = true;
        private bool allowCollapse = true;
        private Guid guid = Guid.NewGuid();
        private Point floatingLocation = new Point(-1, -1);
        private bool persistState = true;
        private bool showOptions = true;
        private SandDockManager manager;
        private ControlLayoutSystem layoutSystem;
        private static Image defaultTabImage;
        private Image tabImage;
        private FQ.FreeDock.Rendering.BorderStyle borderStyle;
        private bool ignoreFontEvents;
        private bool x4e7c2c44587adeda;
        private bool changingDockSituation;
        internal bool xcfac6723d8a41375;
        private int popupSize;
        private int maximumTabWidth;
        private int minimumTabWidth;
        private WindowMetaData metaData;
        private BindingContext bindingContext;
        private Size floatingSize;
        private DockingRules dockingRules;
        private DockControlCloseAction closeAction;
        private Control primaryControl;
        private DockSituation dockSituation;

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
                if (this.bindingContext != null)
                    return this.bindingContext;
                if (this.Manager != null && this.Manager.DockSystemContainer != null)
                    return this.Manager.DockSystemContainer.BindingContext;
                if (this.DesignMode)
                    return base.BindingContext;
                else
                    return null;
            }
            set
            {
                this.bindingContext = value;
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
                return this.primaryControl;
            }
            set
            {
                this.primaryControl = value;
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
                return this.LayoutSystem != null ? this.LayoutSystem.Collapsed : false;
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
                return this.closeAction;
            }
            set
            {
                this.closeAction = value;
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
                return this.metaData;
            }
        }

        internal bool IgnoreFontEvents
        {
            get
            {
                return this.ignoreFontEvents;
            }
            set
            {
                this.ignoreFontEvents = value;
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

                switch (this.borderStyle)
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
                return this.persistState;
            }
            set
            {
                this.persistState = value;
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
                return this.borderStyle;
            }
            set
            {
                this.borderStyle = value;
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
                return this.layoutSystem;
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
                return this.guid;
            }
            set
            {
                Guid oldGuid = this.guid;
                this.guid = value;
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
                if (this.IsInContainer && !(this.layoutSystem.DockContainer is DocumentContainer))
                    return !(this.layoutSystem.DockContainer is FloatingDockContainer);
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
                if (this.IsInContainer)
                    return this.layoutSystem.DockContainer is DocumentContainer;
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
                return this.IsInContainer ? this.layoutSystem.DockContainer.IsFloating : false;
            }
        }

        [Browsable(false)]
        internal bool IsInContainer
        {
            get
            {
                return this.layoutSystem != null ? this.layoutSystem.DockContainer != null : false;
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
                bool flag = this.IsInContainer && this.layoutSystem != null && this.layoutSystem.SelectedControl == this;
             
                if (flag && this.layoutSystem.Collapsed)
                    flag = this.layoutSystem.IsPoppedUp;

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
                if (this.LayoutSystem != null && this.LayoutSystem.DockContainer != null)
                    this.LayoutSystem.DockContainer.Invalidate(this.LayoutSystem.Bounds);
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
                if (this.LayoutSystem != null && this.LayoutSystem.DockContainer != null)
                    this.LayoutSystem.DockContainer.Invalidate(this.tabBounds);
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
        [DefaultValue(typeof(Size), "250, 400")]
        // reviewed with 2.4
        public Size FloatingSize
        {
            get
            {
                return this.floatingSize;
            }
            set
            {
                if (value.Width <= 0 || value.Height <= 0)
                    throw new ArgumentOutOfRangeException("value");

                this.floatingSize = value;
                if (this.DockSituation != DockSituation.Floating || !(this.FloatingDockContainer.FloatingSize != this.floatingSize))
                    return;

                this.FloatingDockContainer.FloatingSize = this.floatingSize;
            }
        }

        /// <summary>
        /// Indicates the location of the floating window that will contain this control.
        /// 
        /// </summary>
        [Browsable(false)]
        [DefaultValue(typeof(Point), "-1, -1")]
        // reviewed with 2.4
        public Point FloatingLocation
        {
            get
            {
                return this.floatingLocation;
            }
            set
            {
                this.floatingLocation = value;

                if (this.DockSituation != DockSituation.Floating || !(this.FloatingDockContainer.FloatingLocation != this.floatingLocation))
                    return;
                this.FloatingDockContainer.FloatingLocation = this.floatingLocation;
            }
        }

        private FloatingDockContainer FloatingDockContainer
        {
            get
            {
                return this.layoutSystem.DockContainer as FloatingDockContainer;
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
                return this.dockingRules;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.dockingRules = value;
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
                return this.allowClose;
            }
            set
            {
                this.allowClose = value;
                this.UpdateLayoutSystem();
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
                return this.maximumTabWidth;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Value must be greater than or equal to zero.");
                this.maximumTabWidth = value;
                this.UpdateLayoutSystem();
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
                return this.minimumTabWidth;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value");
                this.minimumTabWidth = value;
                this.UpdateLayoutSystem();
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
                return this.showOptions;
            }
            set
            {
                this.showOptions = value;
                this.UpdateLayoutSystem();
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
        // reviewed with 2.4
        public virtual bool AllowCollapse
        {
            get
            {
                return this.allowCollapse;
            }
            set
            {
                this.allowCollapse = value;
                if (!value && this.Collapsed)
                    this.Collapsed = false;
                this.UpdateLayoutSystem();
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
                return this.toolTipText;
            }
            set
            {
                this.toolTipText = value ?? string.Empty;
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
                return this.tabText.Length == 0 ? this.Text : this.tabText;
            }
            set
            {
                this.tabText = value ?? string.Empty;
                this.UpdateLayoutSystem();
            }
        }

        /// <summary>
        /// The size of the control when popped up from a collapsed state. Leave this as zero for the default size.
        /// 
        /// </summary>
        // reviewed
        [Description("The size of the control when popped up from a collapsed state. Leave this as zero for the default size.")]
        [DefaultValue(0)]
        [Category("Docking")]
        // reviewed with 2.4
        public int PopupSize
        {
            get
            {
                return this.popupSize;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Value must be at least equal to zero.");

                this.popupSize = value;

                if (!this.MetaData.x057495d927e64b9e)
                    this.MetaData.SetDockedContentSize(value);

                if (this.LayoutSystem != null && this.LayoutSystem.AutoHideBar != null && this.LayoutSystem.AutoHideBar.ShowingLayoutSystem == this.LayoutSystem)
                    this.LayoutSystem.AutoHideBar.PopupSize = value;
            }
        }
        // reviewed
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

                this.UpdateLayoutSystem();
                if (this.DockSituation == DockSituation.Floating && this.FloatingDockContainer.HasSingleControlLayoutSystem && this.LayoutSystem.SelectedControl == this)
                    this.FloatingDockContainer.xd1bdd0ee5924b59e();
            }
        }

        internal Image WorkingTabImage
        {
            get
            {
                return (this.tabImage != null) ? this.tabImage : DockControl.defaultTabImage;
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
                return this.tabBounds;
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
                return this.dockSituation;
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
                return this.tabImage;
            }
            set
            {
                this.tabImage = value;
                this.UpdateLayoutSystem();
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
                return new Size(250, 400);
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
            if (DockControl.defaultTabImage == null)
                DockControl.defaultTabImage = Image.FromStream(typeof(DockControl).Assembly.GetManifestResourceStream("FQ.FreeDock.sanddock.png"));
            this.metaData = new WindowMetaData();
            this.dockingRules = this.CreateDockingRules();
            if (this.dockingRules == null)
                throw new InvalidOperationException();

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.BackColor = SystemColors.Control;
            this.floatingSize = this.DefaultSize;
        }

        /// <summary>
        /// Initializes a new instance of the DockControl class, containing the specified control and with the specified text.
        /// 
        /// </summary>
        /// <param name="manager">The SandDockManager responsible for layout of the control.</param><param name="control">The control to host within the DockControl.</param><param name="text">The text of the DockControl.</param>
        // reviewed with 2.4
        protected DockControl(SandDockManager manager, Control control, string text) : this()
        {
            if (manager == null)
                throw new ArgumentNullException("manager");
            if (control == null)
                throw new ArgumentNullException("control");
            if (text == null)
                text = string.Empty;

            this.Text = text;
            this.Manager = manager;

            if (control != null)
            {
                if (control is Form)
                {
                    Form form = (Form)control;
                    form.TopLevel = false;
                    form.FormBorderStyle = FormBorderStyle.None;
                }
                this.SuspendLayout();
                this.Controls.Add(control);
                control.Dock = DockStyle.Fill;
                control.BringToFront();
                this.ResumeLayout();
                control.Visible = true;
            }
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

        internal void SetVisible(bool visible)
        {
            this.SetVisibleCore(visible);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed 
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.layoutSystem != null && this.AllowKeyboardNavigation)
            {
                if (keyData == (Keys.Prior | Keys.Control))
                {
                    int index1 = this.layoutSystem.Controls.IndexOf(this) - 1;
                    if (index1 < 0)
                        index1 = this.layoutSystem.Controls.Count - 1;
                    this.layoutSystem.SelectedControl = this.layoutSystem.Controls[index1];
                    this.layoutSystem.Controls[index1].Activate();
                    return true;
                }
                else if (keyData == (Keys.Next | Keys.Control))
                {
                    int index2 = this.layoutSystem.Controls.IndexOf(this) + 1;
                    if (index2 >= this.layoutSystem.Controls.Count)
                        index2 = 0;
                    this.layoutSystem.SelectedControl = this.layoutSystem.Controls[index2];
                    this.layoutSystem.Controls[index2].Activate();
                    return true;
                }
                else if (keyData == (Keys.OemMinus | Keys.Alt) && this.layoutSystem.IsInContainer)
                {
                    this.layoutSystem.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(this, new Point(0, 0), ContextMenuContext.Keyboard));
                    return true;
                }
                else if (keyData == Keys.Escape && this.Manager != null)
                {
                    if (this.DockSituation != DockSituation.Document)
                    {
                        if (this.Manager.OwnerForm != null)
                            this.Manager.OwnerForm.Activate();
                        DockControl recentlyUsedWindow = this.Manager.FindMostRecentlyUsedWindow(DockSituation.Document);
                        if (recentlyUsedWindow != null)
                            recentlyUsedWindow.Activate();
                        return true;
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        internal void UpdateLayoutSystem()
        {
            if (this.LayoutSystem != null)
                this.LayoutSystem.x3e0280cae730d1f2();
        }

        internal void x81444a37d39a0e4a()
        {
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
        // reviewed
        private void x63491667e252563e()
        {
            if (this.x4e7c2c44587adeda)
                return;
            if (this.Manager == null || this.Manager.DocumentContainer == null || !this.Manager.DocumentContainer.x1ec2ea49664e1074)
                this.MetaData.SetLastFocused(DateTime.Now);
            if (this.Manager != null)
                this.Manager.OnDockControlActivated(new DockControlEventArgs(this));
            return;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        // reviewed
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (this.LayoutSystem != null)
                this.LayoutSystem.ContainsFocus = true;
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
            if (this.LayoutSystem != null)
                this.LayoutSystem.ContainsFocus = false;
        }

        /// <summary>
        /// Used to set metadata ready for the next time the window is opened.
        /// 
        /// </summary>
        /// <param name="dockSituation">The dock situation the window will adopt next time it is opened.</param>
        // reviewed 
        public void SetPositionMetaData(DockSituation dockSituation)
        {
            if (this.DockSituation != DockSituation.None)
                throw new InvalidOperationException("This operation is only valid when the window is not currently open.");
            if (dockSituation == DockSituation.None)
                throw new ArgumentException("dockSituation");

            this.metaData.SetLastOpenDockSituation(dockSituation);
            this.metaData.SetLastFixedDockSituation(dockSituation);
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

            if (dockLocation == ContainerDockLocation.Center)
                throw new ArgumentException("dockLocation");

            this.metaData.SetLastOpenDockSituation(dockSituation);
            if (dockSituation == DockSituation.Document || dockSituation == DockSituation.Docked)
                this.metaData.SetLastFixedDockSituation(dockSituation);
            this.metaData.SetLastFixedDockSide(dockLocation);
        }
        // reviewed with 2.4
        internal static void DoPaint(Control control, Graphics g, FQ.FreeDock.Rendering.BorderStyle borderStyle)
        {
            if (borderStyle == FQ.FreeDock.Rendering.BorderStyle.None)
                return;
            Rectangle rectangle = new Rectangle(0, 0, control.Width, control.Height);
            if (borderStyle != FQ.FreeDock.Rendering.BorderStyle.Flat)
            {
                Border3DStyle style;
                switch (borderStyle)
                {
                    case FQ.FreeDock.Rendering.BorderStyle.Flat:
                        style = Border3DStyle.Flat;
                        break;
                    case FQ.FreeDock.Rendering.BorderStyle.RaisedThick:
                        style = Border3DStyle.Raised;
                        break;
                    case FQ.FreeDock.Rendering.BorderStyle.RaisedThin:
                        style = Border3DStyle.RaisedInner;
                        break;
                    case FQ.FreeDock.Rendering.BorderStyle.SunkenThick:
                        style = Border3DStyle.Sunken;
                        break;
                    default:
                        style = Border3DStyle.SunkenOuter;
                        break;
                }
                ControlPaint.DrawBorder3D(g, rectangle, style);
            }
            else
            {
                Color backColor = control.BackColor;
                Color controlDark = SystemColors.ControlDark;
                DockControl window = control as DockControl;
                if (window != null && window.Manager != null)
                    window.Manager.Renderer.ModifyDefaultWindowColors(window, ref backColor, ref controlDark);
                --rectangle.Width;
                --rectangle.Height;
                using (Pen pen = new Pen(controlDark))
                    g.DrawRectangle(pen, rectangle);
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

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle clientRectangle = this.ClientRectangle;
            switch (this.BorderStyle)
            {
                case FQ.FreeDock.Rendering.BorderStyle.Flat:
                case FQ.FreeDock.Rendering.BorderStyle.RaisedThin:
                case FQ.FreeDock.Rendering.BorderStyle.SunkenThin:
                    clientRectangle.Inflate(-1, -1);
                    break;
                case FQ.FreeDock.Rendering.BorderStyle.RaisedThick:
                case FQ.FreeDock.Rendering.BorderStyle.SunkenThick:
                    clientRectangle.Inflate(-2, -2);
                    break;
            }
            Color backColor = this.BackColor;
            Color transparent = Color.Transparent;
            if (this.Manager != null)
                this.Manager.Renderer.ModifyDefaultWindowColors(this, ref backColor, ref transparent);
            if (clientRectangle != this.ClientRectangle)
                e.Graphics.SetClip(clientRectangle);
            if (this.BackgroundImage != null)
                RenderHelper.ClearBackground(e.Graphics, backColor);
            base.OnPaintBackground(e);
        }

        internal void x56e964269d48cfcc(DockContainer container)
        {
            if (container != null)
            {
                if (container.Manager == null)
                    return;

                if (container.Manager != this.Manager)
                    this.Manager = container.Manager;
            }
            this.x44fd51d909a57a2a();
        }
        // reviewed
        internal void x44fd51d909a57a2a()
        {
            DockSituation xbcea506a33cf9111;
            if (this.LayoutSystem == null || this.LayoutSystem.DockContainer == null)
                xbcea506a33cf9111 = DockSituation.None;
            else
                xbcea506a33cf9111 = LayoutUtilities.CheckForDockSituation(this.LayoutSystem.DockContainer);
            if (xbcea506a33cf9111 != DockSituation.None)
                this.metaData.SetLastOpenDockSituation(xbcea506a33cf9111);
            x129cb2a2bdfd0ab2 xfffbdea061bfa120 = null;
            DockSituation dockSituation = xbcea506a33cf9111;
            switch (dockSituation)
            {
                case DockSituation.Docked:
                    xfffbdea061bfa120 = (x129cb2a2bdfd0ab2)this.metaData.xe62a3d24e0fde928;
                    this.metaData.SetLastFixedDockSituation(DockSituation.Docked);
                    this.metaData.SetLastFixedDockSide(LayoutUtilities.Convert(this.LayoutSystem.DockContainer.Dock));
                    this.metaData.SetDockedContentSize(this.LayoutSystem.DockContainer.ContentSize);
                    if (this.Manager != null)
                    {
                        DockContainer[] dockContainers = this.Manager.GetDockContainers(this.LayoutSystem.DockContainer.Dock);
                        this.metaData.xe62a3d24e0fde928.xd25c313925dc7d4e = dockContainers.Length;
                        this.metaData.xe62a3d24e0fde928.x71a5d248534c8557 = Array.IndexOf<DockContainer>(dockContainers, this.LayoutSystem.DockContainer);
                    }
                    break;
                case DockSituation.Document:
                    xfffbdea061bfa120 = this.metaData.x25e1dbd0e63329bf;
                    this.metaData.SetLastFixedDockSituation(DockSituation.Document);


                    break;
                case DockSituation.Floating:
                    xfffbdea061bfa120 = this.metaData.xba74b873ae2f845a;
                    this.metaData.SetLastFloatingWindowGuid(((FloatingDockContainer)this.LayoutSystem.DockContainer).Guid);
                    break;
            }
            if (xfffbdea061bfa120 != null)
                this.x301b78956138d163(xfffbdea061bfa120);
            this.x409072a6bb877e49(xbcea506a33cf9111);
        }

        private void x301b78956138d163(x129cb2a2bdfd0ab2 xfffbdea061bfa120)
        {
            if (this.LayoutSystem == null)
                return;
            xfffbdea061bfa120.Guid = this.LayoutSystem.Guid;
            xfffbdea061bfa120.x8c8f170696764fac = this.LayoutSystem.Controls.IndexOf(this);
            xfffbdea061bfa120.Sizes = this.LayoutSystem.WorkingSize;
            xfffbdea061bfa120.Indices = LayoutUtilities.GetIndexesTopDown(this.LayoutSystem);
        }

        private void EnsureNotDisposed()
        {
            if (this.IsDisposed)
                throw new ObjectDisposedException(this.GetType().Name);
        }

        internal void xb37e72cd3ce9b2b4()
        {
            this.CreateControl();
        }

        private void EnsureManager()
        {
            this.EnsureNotDisposed();
            if (this.manager == null)
                throw new InvalidOperationException("No SandDockManager is associated with this DockControl. To create an association, set the Manager property.");
        }

        private void xc64dfbbdd2fa7bf6()
        {
            this.EnsureManager();
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
            this.EnsureManager();
            this.Remove();
            this.MetaData.SetLastFloatingWindowGuid(Guid.Empty);
            this.MetaData.xba74b873ae2f845a.Guid = Guid.Empty;
            this.FloatingLocation = bounds.Location;
            this.FloatingSize = bounds.Size;
            this.OpenFloating(openMethod);
        }

        /// <summary>
        /// Opens the window in a floating state, at the specified bounds.
        /// 
        /// </summary>
        /// <param name="openMethod">The level to which the window is brought to the forefront.</param>
        public void OpenFloating(WindowOpenMethod openMethod)
        {
            this.EnsureManager();
            this.xb37e72cd3ce9b2b4();

            if (this.DockSituation != DockSituation.Floating)
            {
                Rectangle xda73fcb97c77d998 = this.GetFloatingBounds();
                this.Remove();
                ControlLayoutSystem controlLayoutSystem = LayoutUtilities.xba5fd484c0e6478b(this.Manager, DockSituation.Floating, this.MetaData.xba74b873ae2f845a);
                FloatingDockContainer x410f3612b9a8f9de;

                if (controlLayoutSystem == null)
                {
                    x410f3612b9a8f9de = this.Manager.FindFloatingDockContainer(this.MetaData.LastFloatingWindowGuid);
                    if (x410f3612b9a8f9de != null)
                    {
                        SplitLayoutEntry x5678bb8d80c0f12e = LayoutUtilities.x2f8f74d308cc9f3f((DockContainer)x410f3612b9a8f9de, this.MetaData.xba74b873ae2f845a.Indices);
                        controlLayoutSystem = x5678bb8d80c0f12e.SplitLayoutSystem.DockContainer.CreateNewLayoutSystem(this, this.MetaData.xba74b873ae2f845a.Sizes);
                        if (this.MetaData.xba74b873ae2f845a.Guid == Guid.Empty)
                            this.MetaData.xba74b873ae2f845a.Guid = Guid.NewGuid();
                        controlLayoutSystem.Guid = this.MetaData.xba74b873ae2f845a.Guid;

                        x5678bb8d80c0f12e.SplitLayoutSystem.LayoutSystems.Insert(x5678bb8d80c0f12e.Index, (LayoutSystemBase)controlLayoutSystem);
                    }
                    else
                    {
                        if (this.metaData.LastFloatingWindowGuid == Guid.Empty)
                            this.metaData.SetLastFloatingWindowGuid(Guid.NewGuid());
                        x410f3612b9a8f9de = new FloatingDockContainer(this.Manager, this.metaData.LastFloatingWindowGuid);
                        controlLayoutSystem = x410f3612b9a8f9de.CreateNewLayoutSystem(this, this.metaData.xba74b873ae2f845a.Sizes);
                        if (this.MetaData.xba74b873ae2f845a.Guid == Guid.Empty)
                            this.MetaData.xba74b873ae2f845a.Guid = Guid.NewGuid();
                        controlLayoutSystem.Guid = this.MetaData.xba74b873ae2f845a.Guid;
                        x410f3612b9a8f9de.LayoutSystem.LayoutSystems.Add((LayoutSystemBase)controlLayoutSystem);
                        x410f3612b9a8f9de.x159713d3b60fae0c(xda73fcb97c77d998, true, openMethod == WindowOpenMethod.OnScreenActivate);
                    }
                }
                else
                {
                    controlLayoutSystem.Controls.Insert(Math.Min(this.MetaData.xba74b873ae2f845a.x8c8f170696764fac, controlLayoutSystem.Controls.Count), this);
                    if (openMethod != WindowOpenMethod.OnScreen)
                        this.SetActive(openMethod == WindowOpenMethod.OnScreenActivate);
                }

            }
        }

        internal Rectangle GetFloatingBounds()
        {
            this.EnsureManager();
            if (this.floatingLocation.X == -1 && this.floatingLocation.Y == -1)
                this.floatingLocation = this.GetDefaultFloatingLocation();
            return new Rectangle(this.floatingLocation, this.floatingSize);
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
        // reviewed with 2.4
        protected virtual Point GetDefaultFloatingLocation()
        {
            Point point;
            if (!this.IsInContainer)
            {
                Rectangle workingArea = (this.Manager.DockSystemContainer == null ? Screen.PrimaryScreen : Screen.FromControl(this.Manager.DockSystemContainer)).WorkingArea;
                point = new System.Drawing.Point(workingArea.X + workingArea.Width / 2 - this.floatingSize.Width / 2, workingArea.Y + workingArea.Height / 2 - this.floatingSize.Height / 2);
            }
            else
                point = this.LayoutSystem.DockContainer.PointToScreen(this.LayoutSystem.Bounds.Location) - new System.Drawing.Size(SystemInformation.CaptionHeight, SystemInformation.CaptionHeight);
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
                return null;
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
            this.EnsureManager();
            if (this.DockSituation == DockSituation.None)
            {
                switch (this.metaData.LastOpenDockSituation)
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
                }
            }
            if (openMethod != WindowOpenMethod.OnScreen)
                this.SetActive(openMethod == WindowOpenMethod.OnScreenActivate);
        }

        internal void SetActive(bool active)
        {
            if (this.LayoutSystem != null)
            {
                if (this.LayoutSystem.SelectedControl != this)
                    this.LayoutSystem.SelectedControl = this;
                if (this.LayoutSystem.AutoHideBar != null)
                {
                    this.LayoutSystem.AutoHideBar.xe6ff614263a59ef9(this, true, active);
                    return;
                }
            }
            if (active)
                this.Activate();
        }

        internal bool AllowDock(ContainerDockLocation dockLation)
        {
            switch (dockLation)
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
            LayoutUtilities.RemoveDockControl(this);
        }

        /// <summary>
        /// Opens the DockControl at its last known docked location.
        /// 
        /// </summary>
        public void OpenDocked()
        {
            this.OpenDocked(this.metaData.LastFixedDockSide);
        }

        /// <summary>
        /// Opens the window at the specified docked location.
        /// 
        /// </summary>
        /// <param name="dockLocation">The location at which to open the window.</param>
        public void OpenDocked(ContainerDockLocation dockLocation)
        {
            if (dockLocation == this.metaData.LastFixedDockSide)
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
            if (dockLocation == ContainerDockLocation.Center)
                this.OpenDocument(openMethod);
            else
            {
                this.EnsureManager();
                if (this.DockSituation == DockSituation.Docked && this.metaData.LastFixedDockSide == dockLocation)
                    return;
                this.Remove();
                this.metaData.SetLastFixedDockSide(dockLocation);
                this.metaData.xe62a3d24e0fde928.Guid = Guid.Empty;
                this.metaData.xe62a3d24e0fde928.Indices = new int[0];
                this.OpenDocked(openMethod);
            }
        }

        /// <summary>
        /// Opens the window as a tabbed document.
        /// 
        /// </summary>
        /// <param name="openMethod">The level to which the window is brought to the forefront.</param>
        public void OpenDocument(WindowOpenMethod openMethod)
        {
            this.EnsureManager();
            this.xb37e72cd3ce9b2b4();
            if (this.DockSituation == DockSituation.Document)
                return;
            this.Remove();
            ControlLayoutSystem layout = LayoutUtilities.xba5fd484c0e6478b(this.Manager, DockSituation.Document, this.metaData.x25e1dbd0e63329bf);
            if (layout == null)
            {
                DockContainer container = this.Manager.FindDockContainer(ContainerDockLocation.Center);
                if (container == null)
                    container = this.Manager.CreateNewDockContainer(ContainerDockLocation.Center, ContainerDockEdge.Inside, this.MetaData.DockedContentSize);
                layout = LayoutUtilities.FindControlLayoutSystem(container);
                if (layout != null)
                {
                    if (this.Manager.DocumentOpenPosition != DocumentContainerWindowOpenPosition.First)
                        layout.Controls.Add(this);
                    else
                        layout.Controls.Insert(0, this);
                }
                else
                {
                    layout = container.CreateNewLayoutSystem(this, this.MetaData.x25e1dbd0e63329bf.Sizes);
                    container.LayoutSystem.LayoutSystems.Add(layout);
                }
            }
            else
                layout.Controls.Insert(Math.Min(this.metaData.xe62a3d24e0fde928.x8c8f170696764fac, layout.Controls.Count), this);

            if (openMethod != WindowOpenMethod.OnScreen)
                this.SetActive(openMethod == WindowOpenMethod.OnScreenActivate);
        }

        /// <summary>
        /// Opens the window at the specified docked location.
        /// 
        /// </summary>
        /// <param name="openMethod">The level to which the window is brought to the forefront.</param>
        public void OpenDocked(WindowOpenMethod openMethod)
        {
            this.EnsureManager();
            this.xb37e72cd3ce9b2b4();
            if (this.DockSituation == DockSituation.Docked)
                return;
            this.Remove();
            ControlLayoutSystem controlLayoutSystem = LayoutUtilities.xba5fd484c0e6478b(this.Manager, DockSituation.Docked, (x129cb2a2bdfd0ab2)this.metaData.xe62a3d24e0fde928);
            if (controlLayoutSystem != null)
                controlLayoutSystem.Controls.Insert(Math.Min(this.metaData.xe62a3d24e0fde928.x8c8f170696764fac, controlLayoutSystem.Controls.Count), this);
            else
            {
                SplitLayoutEntry x5678bb8d80c0f12e = LayoutUtilities.x4689c8634e31fc55(this.Manager, this.metaData);
                ControlLayoutSystem newLayoutSystem = x5678bb8d80c0f12e.SplitLayoutSystem.DockContainer.CreateNewLayoutSystem(this, this.metaData.xe62a3d24e0fde928.Sizes);
                if (this.MetaData.xe62a3d24e0fde928.Guid == Guid.Empty)
                    this.MetaData.xe62a3d24e0fde928.Guid = Guid.NewGuid();
                newLayoutSystem.Guid = this.MetaData.xe62a3d24e0fde928.Guid;
                x5678bb8d80c0f12e.SplitLayoutSystem.LayoutSystems.Insert(x5678bb8d80c0f12e.Index, (LayoutSystemBase)newLayoutSystem);
            }
           if (openMethod != WindowOpenMethod.OnScreen)
                this.SetActive(openMethod == WindowOpenMethod.OnScreenActivate);
            return;
        }

        /// <summary>
        /// Causes the window to split itself off from other windows in its tab group.
        /// 
        /// </summary>
        /// <param name="direction">The side of the previous tab group at which to place the window.</param>
        public void Split(DockSide direction)
        {
            if (!this.IsInContainer)
                throw new InvalidOperationException("A window cannot be split while it is not hosted in a DockContainer.");
            if (this.LayoutSystem.Controls.Count < 2)
                throw new InvalidOperationException("A minimum of 2 windows need to be present in a tab group before one can be split off. Check LayoutSystem.Controls.Count before calling this method.");
            if (direction == DockSide.None)
                throw new ArgumentException("direction");
    
            ControlLayoutSystem layout = this.LayoutSystem;
            LayoutUtilities.RemoveDockControl(this);
            ControlLayoutSystem newLayout = layout.DockContainer.CreateNewLayoutSystem(this, this.LayoutSystem.WorkingSize);
            layout.SplitForLayoutSystem(newLayout, direction);
            this.Activate();
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
            return this.DoClose(false);
        }
        // reviewed with 2.4
        internal bool DoClose(bool xc481dbe8dc50af3f)
        {
            DockControlClosingEventArgs e = new DockControlClosingEventArgs(this, false);

            if (this.Manager != null)
                this.Manager.OnDockControlClosing(e);
            if (!e.Cancel)
                this.OnClosing(e);
            if (e.Cancel)
                return false;

            LayoutUtilities.RemoveDockControl(this);
            this.OnClosed(EventArgs.Empty);
            if (this.CloseAction == DockControlCloseAction.Dispose)
                base.Dispose();
            return true;
        }

        /// <summary>
        /// Raises the Closing event.
        /// 
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected internal virtual void OnClosing(DockControlClosingEventArgs e)
        {
            if (this.Closing != null)
                this.Closing(this, e);
        }

        /// <summary>
        /// Raises the Closed event.
        /// 
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected internal virtual void OnClosed(EventArgs e)
        {
            if (this.Closed != null)
                this.Closed(this, e);
        }

        /// <summary>
        /// Raises the Load event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected virtual void OnLoad(EventArgs e)
        {
            if (this.Load != null)
                this.Load(this, e);
        }

        /// <summary>
        /// Raises the DockSituationChanged event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected virtual void OnDockSituationChanged(EventArgs e)
        {
            if (this.DockSituationChanged != null)
                this.DockSituationChanged(this, e);
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
                    if (this.DockingRules.AllowFloat)
                        this.OpenFloating(WindowOpenMethod.OnScreenActivate);
                    return;
                case DockSituation.Floating:
                    if (this.metaData.LastFixedDockSituation != DockSituation.Docked)
                    {
                        if (this.metaData.LastFixedDockSituation != DockSituation.Document)
                            return;
                        if (!this.AllowDock(ContainerDockLocation.Center))
                            return;
                        this.OpenDocument(WindowOpenMethod.OnScreenActivate);
                        return;
                    }
                    else
                    {
                        if (this.AllowDock(this.metaData.LastFixedDockSide))
                            this.OpenDocked(WindowOpenMethod.OnScreenActivate);
                        return;
                    }
                default:
                    return;
            }
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
        // reviewed with 2.4
        public void Activate()
        {
            if (this.LayoutSystem == null || this.Parent == null)
                return;
            if (this.LayoutSystem.SelectedControl != this)
                this.LayoutSystem.SelectedControl = this;
            if (this.DockSituation == DockSituation.Floating)
                this.FloatingDockContainer.x5b7f6ddd07ded8cd();
            if (!this.IsOpen)
                return;

            this.x4e7c2c44587adeda = true;
            try
            {
                this.Parent.GetContainerControl().ActiveControl = this.ActiveControl;
                if (!this.ContainsFocus)
                {
                    if (this.PrimaryControl != null)
                        this.PrimaryControl.Focus();
                    else
                        this.SelectNextControl(this, true, true, true, true);

                    if (!this.ContainsFocus)
                    {
                        if (this.Controls.Count != 1)
                            this.Focus();
                        else
                            this.Controls[0].Focus();
                    }
                }

            }
            finally
            {
                this.x4e7c2c44587adeda = false;
            }
            this.x63491667e252563e();
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
            if (existingWindow == null)
                throw new ArgumentNullException();
            if (existingWindow == this)
                return;
            if (existingWindow.DockSituation == DockSituation.None)
                throw new InvalidOperationException("The specified window is not open.");
            this.Remove();
            existingWindow.LayoutSystem.Controls.Add(this);
        }

        /// <summary>
        /// Opens the window next to an existing window.
        /// 
        /// </summary>
        /// <param name="existingWindow">The existing window next to which to open the window.</param><param name="side">The side of the existing window at which to place the new window.</param>
        public void OpenBeside(DockControl existingWindow, DockSide side)
        {
            if (existingWindow == null)
                throw new ArgumentNullException();
            if (existingWindow == this)
                return;
            if (existingWindow.DockSituation == DockSituation.None)
                throw new InvalidOperationException("The specified window is not open.");
            this.Remove();
            existingWindow.LayoutSystem.SplitForLayoutSystem(new ControlLayoutSystem(this.MetaData.xe62a3d24e0fde928.Sizes, new DockControl[] { this }, this), side);
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
            DockContainer newDockContainer = this.Manager.CreateNewDockContainer(dockLocation, edge, this.metaData.DockedContentSize);
            ControlLayoutSystem newLayoutSystem = newDockContainer.CreateNewLayoutSystem(this, (SizeF)this.FloatingSize);
            newDockContainer.LayoutSystem.LayoutSystems.Add((LayoutSystemBase)newLayoutSystem);
        }

        internal void x02847d0dec2e498a(ControlLayoutSystem layout, int index)
        {
            if (this.layoutSystem != layout)
            {
                LayoutUtilities.RemoveDockControl(this);
                layout.Controls.Insert(index, this);
            }
            else
                layout.Controls.SetChildIndex(this, index);

            layout.SelectedControl = this;
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
            if (this.AutoHidePopupClosed != null)
                this.AutoHidePopupClosed(this, e);
        }

        /// <summary>
        /// Raises the AutoHidePopupOpened event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected internal virtual void OnAutoHidePopupOpened(EventArgs e)
        {
            if (this.AutoHidePopupOpened != null)
                this.AutoHidePopupOpened(this, e);
        }

        internal void SetControlLayoutSystem(ControlLayoutSystem layoutSystem)
        {
            this.layoutSystem = layoutSystem;
        }

        private bool ShouldSerializeDockingRules()
        {
            DockingRules dockingRules = this.CreateDockingRules();

            if (dockingRules.AllowDockTop != this.DockingRules.AllowDockTop)
                return true;
            if (dockingRules.AllowDockBottom != this.DockingRules.AllowDockBottom)
                return true;
            if (dockingRules.AllowDockLeft != this.DockingRules.AllowDockLeft)
                return true;
            if (dockingRules.AllowDockRight != this.DockingRules.AllowDockRight)
                return true;
            if (dockingRules.AllowTab != this.DockingRules.AllowTab)
                return true;
            if (dockingRules.AllowFloat != this.DockingRules.AllowFloat)
                return true;
            else
                return false;
        }

        private bool ShouldSerializeTabText()
        {
            return this.tabText.Length != 0 ? this.tabText != this.Text : false;
        }

        private void x409072a6bb877e49(DockSituation dockSituation)
        {
            if (this.changingDockSituation)
                throw new InvalidOperationException("The requested operation is not valid on a window that is currently engaged in an activity further up the call stack. Consider using BeginInvoke to postpone the operation until the stack has unwound.");
            if (dockSituation == this.dockSituation)
                return;
            this.dockSituation = dockSituation;
            this.changingDockSituation = true;
            try
            {
                this.OnDockSituationChanged(EventArgs.Empty);
            }
            finally
            {
                this.changingDockSituation = false;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (this.IgnoreFontEvents)
                return;
            this.UpdateLayoutSystem();
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.layoutSystem != null)
                    LayoutUtilities.RemoveDockControl(this);
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
            if (m.Msg == WM_MOUSEACTIVATE && !this.ContainsFocus)
            {
                this.Activate();
            }
        }
    }
}
