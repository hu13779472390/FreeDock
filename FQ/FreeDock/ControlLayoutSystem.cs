using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using FQ.FreeDock.Rendering;

namespace FQ.FreeDock
{
    /// <summary>
    /// A layout system for grouping DockControls together.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// All DockControls must belong to a ControlLayoutSystem instance to be shown. These layout systems are responsible for grouping together
    ///             one or more DockControls and drawing tabs to choose between them. They are also responsible for drawing titlebars and system buttoms.
    /// </para>
    /// 
    /// </remarks>
    [TypeConverter(typeof(x44c2ba9761cb4dd2))]
    public class ControlLayoutSystem : LayoutSystemBase
    {
        private Guid guid = Guid.NewGuid();
        private Point x6afebf16b45c02e0 = Point.Empty;
        private const int x1e9b7c427b6c44fa = 19;
        private const int x26539fe4604823df = 15;
        private ControlLayoutSystem.DockControlCollection controls;
        private bool collapsed;
        internal Rectangle xb48529af1739dd06;
        internal Rectangle xa358da7dd5364cab;
        internal Rectangle x21ed2ecc088ef4e4;
        internal Rectangle joinCatchmentBounds;
        private DockControl selectedControl;
        private bool xf111a0cc60fdac46;
        //        private AutoHideBar autoHideBar;
        private ControlButton closeButton;
        private ControlButton pinButton;
        private ControlButton positionButton;
        private ControlButton highlightedButton;
        internal bool xfa5e20eb950b9ee1;
        internal bool xd30df1068ed42e28;
        private bool x49cf4e0157d9436c;
        private bool containsFocus;
        // reviewed with 2.4
        internal override DockControl[] AllControls
        {
            get
            {
                DockControl[] array = new DockControl[this.Controls.Count];
                this.Controls.CopyTo(array, 0);
                return array;
            }
        }
        // reviewed with 2.4
        internal int PopupSize
        {
            get
            {
                if (this.SelectedControl != null && this.SelectedControl.PopupSize != 0)
                    return this.SelectedControl.PopupSize;
                if (this.IsInContainer)
                    return this.DockContainer.ContentSize;
                else
                    return 200;
            }
            set
            {
                foreach (DockControl dockControl in this.Controls)
                    dockControl.PopupSize = value;
            }
        }
        // reviewed with 2.4
        internal override bool ContainsPersistableDockControls
        {
            get
            {
                foreach (DockControl dockControl in this.Controls)
                {
                    if (dockControl.PersistState)
                        return true;
                }
                return false;
            }
        }

        internal Guid Guid { get; set; }

        /// <summary>
        /// Gets/sets a value indicating whether the user will be prevented from initiating docking operations from this layout system.
        /// 
        /// </summary>
        public bool LockControls { get; set; }

        /// <summary>
        /// Indicates whether the layout system is popped up, if in a collapsed state.
        /// 
        /// </summary>
        // reviewed with 2.4
        public bool IsPoppedUp
        {
            get
            {
                return this.AutoHideBar != null ? this.AutoHideBar.ShowingLayoutSystem == this : false;
            }
        }

        /// <summary>
        /// A DockControlCollection representing the collection of controls contained within the layout system.
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ControlLayoutSystem.DockControlCollection Controls
        { 
            get
            {
                return this.controls;
            }
        }

        internal AutoHideBar AutoHideBar { get; private set; }
        // reviewed with 2.4
        internal Control ControlParent
        {
            get
            {
                if (!this.IsInContainer)
                    return null;
                if (this.IsPoppedUp)
                    return this.AutoHideBar.PopupContainer;
                else
                    return this.DockContainer;                            
            }
        }

        /// <summary>
        /// Indicates whether the layout system is collapsed (in auto-hide mode).
        /// 
        /// </summary>
        /// 
        // reviewed with 2.4
        [DefaultValue(false)]
        [Browsable(false)]
        public virtual bool Collapsed
        {
            get
            {
                return this.collapsed;
            }
            set
            {
                if (this.collapsed == value)
                    return;
                this.collapsed = value;

                this.HighlightedButton = null;
                if (this.collapsed)
                {
                    if (this.IsInContainer)
                    {
                        foreach (DockControl dockControl in this.Controls)
                        {
                            if (dockControl.Parent == this.DockContainer)
                                LayoutUtilities.xa7513d57b4844d46(dockControl);
                        }

                        AutoHideBar autoHideBar = this.DockContainer.Manager.GetAutoHideBar(this.DockContainer.Dock);
                        if (autoHideBar != null)
                            autoHideBar.LayoutSystems.Add(this);
                    }
                }
                else
                {
                    if (this.AutoHideBar != null)
                        this.AutoHideBar.LayoutSystems.Remove(this);
              
                    foreach (DockControl dockControl in this.Controls)
                    {
                        if (dockControl.Parent != this.DockContainer)
                            dockControl.Parent = this.DockContainer;
                    }
                }

                if (this.IsInContainer)
                    this.DockContainer.x7e9646eed248ed11();
            }
        }

        /// <summary>
        /// The dock control that is selected within the layout system.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// Only one dock control can be visible in a control layout system at one time. The tab for the selected dock control is drawn in a selected
        ///             stage. This can be set to a null reference, but it is not recommended to do so.
        /// </para>
        /// 
        /// </remarks>
        // reviewed with 2.4
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual DockControl SelectedControl
        {
            get
            {
                return this.selectedControl;
            }
            set
            {
                if (value != null && !this.controls.Contains(value))
                    throw new ArgumentOutOfRangeException("value");

                DockControl dockControl = this.selectedControl;
                this.selectedControl = value;
                this.x3e0280cae730d1f2();
                if (this.IsPoppedUp)
                {
                    if (dockControl != null)
                        dockControl.OnAutoHidePopupClosed(EventArgs.Empty);
                    if (this.selectedControl != null)
                        this.selectedControl.OnAutoHidePopupOpened(EventArgs.Empty);
                }
                this.xe20c835979d60df8(dockControl, this.selectedControl);
            }
        }
        // reviewed with 2.4
        internal ControlButton HighlightedButton
        {
            get
            {
                return this.highlightedButton;
            }
            set
            {
                if (value == this.highlightedButton)
                    return;
                if (this.highlightedButton != null)
                    this.xd541e2fc281b554b();

                this.highlightedButton = value;
                if (this.highlightedButton == null)
                    return;
                this.xd541e2fc281b554b();
            }
        }
        // reviewed with 2.4
        internal override bool AllowTab
        {
            get
            {
                foreach (DockControl dockControl in this.Controls)
                {
                    if (!dockControl.DockingRules.AllowTab)
                        return false;
                }
                return true;
            }
        }
        // reviewed with 2.4
        internal override bool AllowFloat
        {
            get
            {
                foreach (DockControl dockControl in this.Controls)
                {
                    if (!dockControl.DockingRules.AllowFloat)
                        return false;
                }
                return true;
            }
        }
        // reviewed with 2.4
        private bool AllowCollapse
        {
            get
            {
                foreach (DockControl dockControl in this.Controls)
                {
                    if (!dockControl.AllowCollapse)
                        return false;
                }
                return true;
            }
        }
        // reviewed with 2.4
        internal bool ContainsFocus
        {
            get
            {
                return this.containsFocus;
            }
            set
            {
                if (value == this.containsFocus)
                    return;
                this.containsFocus = value;
                this.xd541e2fc281b554b();
            }
        }

        internal Rectangle JoinCatchmentBounds
        {
            get
            {
                return this.joinCatchmentBounds;
            }
        }

        internal event SelectionChangedEventHandler SelectedControlChanged;

        /// <summary>
        /// Initializes a new instance of the ControlLayoutSystem class.
        /// 
        /// </summary>
        public ControlLayoutSystem()
        {
            this.controls = new ControlLayoutSystem.DockControlCollection(this);
            this.closeButton = new ControlButton();
            this.pinButton = new ControlButton();
            this.positionButton = new ControlButton();
        }

        /// <summary>
        /// Initializes a new instance of the ControlLayoutSystem class, with the specified initial dimensions.
        /// 
        /// </summary>
        /// <param name="desiredWidth">The desired width of this layout system, in pixels.</param><param name="desiredHeight">The desired height of this layout system, in pixels.</param>
        public ControlLayoutSystem(int desiredWidth, int desiredHeight) : this()
        {
            this.WorkingSize = new SizeF((float)desiredWidth, (float)desiredHeight);
        }

        /// <summary>
        /// Initializes a new instance of the ControlLayoutSystem class, with the specified initial dimensions, and with the specified child controls.
        /// 
        /// </summary>
        /// <param name="desiredWidth">The desired width of this layout system, in pixels.</param><param name="desiredHeight">The desired height of this layout system, in pixels.</param><param name="controls">An array of DockControls to populate this layout system with.</param><param name="selectedControl">The control to be made selected.</param>
        [Obsolete("Use the constructor that takes a SizeF instead.")]
        public ControlLayoutSystem(int desiredWidth, int desiredHeight, DockControl[] controls, DockControl selectedControl) : this(desiredWidth, desiredHeight)
        {
            this.controls.AddRange(controls);
            if (selectedControl != null)
                this.SelectedControl = selectedControl;
        }

        /// <summary>
        /// Initializes a new instance of the ControlLayoutSystem class, with the specified working size, and with the specified child controls.
        /// 
        /// </summary>
        /// <param name="workingSize">The working size of the layout system.</param><param name="windows">An array of DockControls to populate this layout system with.</param><param name="selectedWindow">The control to be made selected.</param>
        public ControlLayoutSystem(SizeF workingSize, DockControl[] windows, DockControl selectedWindow) : this()
        {
            this.WorkingSize = workingSize;
            this.Controls.AddRange(windows);
            if (selectedWindow != null)
                this.SelectedControl = selectedWindow;
 
        }

        /// <summary>
        /// Initializes a new instance of the ControlLayoutSystem class, with the specified initial dimensions, and with the specified child controls.
        /// 
        /// </summary>
        /// <param name="desiredWidth">The desired width of this layout system, in pixels.</param><param name="desiredHeight">The desired height of this layout system, in pixels.</param><param name="controls">An array of DockControls to populate this layout system with.</param><param name="selectedControl">The control to be made selected.</param><param name="collapsed">Whether the layout system should start collapsed.</param>
        public ControlLayoutSystem(int desiredWidth, int desiredHeight, DockControl[] controls, DockControl selectedControl, bool collapsed) : this(new SizeF((float)desiredWidth, (float)desiredHeight), controls, selectedControl)
        {
            this.Collapsed = collapsed;
        }

        /// <summary>
        /// Closes the popup for this layout system, if it is showing.
        /// 
        /// </summary>
        public void ClosePopup()
        {
            if (this.IsPoppedUp)
                this.AutoHideBar.xcdb145600c1b7224(true);
        }

        internal void xa85d8c17921cc878(AutoHideBar bar)
        {
            this.AutoHideBar = bar;
        }

        /// <summary>
        /// Called when the close button is clicked.
        /// 
        /// </summary>
        protected virtual void OnCloseButtonClick(EventArgs e)
        {
            if (this.SelectedControl == null)
                return;
            this.SelectedControl.x8ffe90e7fbccfccd(true);
        }

        /// <summary>
        /// Called when the pin button is clicked.
        /// 
        /// </summary>
        protected virtual void OnPinButtonClick()
        {
            this.Collapsed = !this.Collapsed;
            if (this.IsInContainer && this.SelectedControl != null)
            {
                if (this.Collapsed && this.AutoHideBar != null)
                {
                    this.AutoHideBar.xe6ff614263a59ef9(this.SelectedControl, true, false);
                    this.AutoHideBar.xcdb145600c1b7224(false);
                }
                else
                    this.SelectedControl.Activate();

            }
        }

        private void xe20c835979d60df8(DockControl oldSelection, DockControl newSelection)
        {
            if (this.SelectedControlChanged == null)
                return;
            this.SelectedControlChanged(oldSelection, newSelection);
        }

        /// <summary>
        /// Overridden
        /// 
        /// </summary>
        // reviewed with 2.4
        protected internal override void OnMouseDoubleClick()
        {
            Point point = this.DockContainer.PointToClient(Cursor.Position);
            if (this.DockContainer.Manager == null || this.LockControls)
                return;
            if (this.xb48529af1739dd06.Contains(point) && !this.closeButton.Bounds.Contains(point) && !this.pinButton.Bounds.Contains(point) && this.Controls.Count != 0)
                this.xa7b62e7d2cd81eb7();
            DockControl control = this.GetControlAt(point);
            if (control != null)
                control.OnTabDoubleClick();
        }

        private void xa7b62e7d2cd81eb7()
        {
            DockSituation dockSituation = this.SelectedControl.DockSituation;
            switch (dockSituation)
            {
                case DockSituation.Docked:
                case DockSituation.Document:
                    if (this.AllowFloat)
                        this.x18f55df6f6629e9f(DockSituation.Floating);
                    break;
                case DockSituation.Floating:
                    if (this.SelectedControl.MetaData.LastFixedDockSituation != DockSituation.Docked || !this.xe302f2203dc14a18(this.SelectedControl.MetaData.LastFixedDockSide))
                    {
                        if (this.SelectedControl.MetaData.LastFixedDockSituation == DockSituation.Document && this.xe302f2203dc14a18(ContainerDockLocation.Center))
                            this.x18f55df6f6629e9f(DockSituation.Document);
                    }
                    else
                        this.x18f55df6f6629e9f(DockSituation.Docked);
                    break;
            }
        }

        /// <summary>
        /// Overridden
        /// 
        /// </summary>
        // reviewed with 2.4
        protected internal override void OnMouseMove(MouseEventArgs e)
        {
            if (this.xd30df1068ed42e28)
                return;

            if (e.Button == MouseButtons.None)
                this.xf111a0cc60fdac46 = false;

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {

                if (this.x531514c39973cbc6 != null)
                {
                    this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
                    return;
                }
                else
                {
                    Rectangle rectangle = new Rectangle(this.x6afebf16b45c02e0, new Size(0, 0));
                    rectangle.Inflate(SystemInformation.DragSize);
                    if (!rectangle.Contains(e.X, e.Y) && this.IsInContainer && (this.x6afebf16b45c02e0 != Point.Empty && !this.Collapsed) && !this.LockControls)
                    {
                        DockControl controlAt = this.GetControlAt(this.x6afebf16b45c02e0);
                        this.x49cf4e0157d9436c = controlAt == null;
                        DockingHints dockingHints = this.DockContainer.Manager == null ? DockingHints.TranslucentFill : this.DockContainer.Manager.DockingHints;
                        DockingManager dockingManager = this.DockContainer.Manager == null ? DockingManager.Standard : this.DockContainer.Manager.DockingManager;
                        this.xe9a159cd1e028df2(this.DockContainer.Manager, this.DockContainer, (LayoutSystemBase)this, controlAt, this.SelectedControl.MetaData.DockedContentSize, this.x6afebf16b45c02e0, dockingHints, dockingManager);
                        return;
                    }
                }
            }

            if (!this.xf111a0cc60fdac46)
                this.HighlightedButton = this.x07083a4bfd59263d(e.X, e.Y);
        }

        internal override bool xe302f2203dc14a18(ContainerDockLocation location)
        {
            foreach (DockControl dockControl in this.Controls)
            {
                if (!dockControl.xe302f2203dc14a18(location))
                    return false;
            }
            return true;
        }

        internal virtual string xe0e7b93bedab6c05(Point position)
        {
            DockControl control = this.GetControlAt(position);
            if (control == null)
            {
                ControlButton controlButton = this.x07083a4bfd59263d(position.X, position.Y);
                if (controlButton == this.closeButton)
                    return SandDockLanguage.CloseText;
                if (controlButton == this.pinButton)
                    return SandDockLanguage.AutoHideText;
                if (controlButton == this.positionButton)
                    return SandDockLanguage.WindowPositionText;
                else
                    return "";
            }
            else
            {
                if (control.ToolTipText.Length != 0)
                    return control.ToolTipText;
                if (control.xcfac6723d8a41375)
                    return control.Text;
                else
                    return "";
            }
        }
        // reviewed with 2.4
        internal virtual ControlButton x07083a4bfd59263d(int x, int y)
        {
            if (this.closeButton.Enabled && this.closeButton.Bounds.Contains(x, y))
                return this.closeButton;
            if (this.pinButton.Enabled && this.pinButton.Bounds.Contains(x, y))
                return this.pinButton;
            if (this.positionButton.Enabled && this.positionButton.Bounds.Contains(x, y))
                return this.positionButton;
            return null;
        }

        internal override void x0ae87c4881d90427(object sender, EventArgs e)
        {
            base.x0ae87c4881d90427(sender, e);
            this.x6afebf16b45c02e0 = Point.Empty;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);
            DockControl control = this.GetControlAt(this.DockContainer.PointToClient(new Point(drgevent.X, drgevent.Y)));
            if (control == null || this.SelectedControl == control)
                return;
            control.Open(WindowOpenMethod.OnScreenActivate);
        }

        /// <summary>
        /// Overridden
        /// 
        /// </summary>
        protected internal override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.xb48529af1739dd06.Contains(e.X, e.Y) && this.SelectedControl != null)
                this.SelectedControl.Activate();

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (this.xb48529af1739dd06.Contains(e.X, e.Y))
                    this.x6afebf16b45c02e0 = new Point(e.X, e.Y);
                if (this.HighlightedButton != null)
                {
                    this.xfa5e20eb950b9ee1 = true;
                    this.xd541e2fc281b554b();
                    this.x11e90588eb0baaf1(this.HighlightedButton);
                    this.x6afebf16b45c02e0 = Point.Empty;
                    return;
                }
            }

            DockControl control = this.GetControlAt(new Point(e.X, e.Y));
            if (control == null)
                return;
            control.Activate();
            this.xf111a0cc60fdac46 = true;
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                this.x6afebf16b45c02e0 = new Point(e.X, e.Y);
        }

        /// <summary>
        /// Overridden
        /// 
        /// </summary>
        // reviewed with 2.4
        protected internal override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.x6afebf16b45c02e0 = Point.Empty;
            this.xf111a0cc60fdac46 = false;
            if (this.x531514c39973cbc6 == null)
            {
                DockControl dockControl;
                if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
                {
                    dockControl = this.GetControlAt(new Point(e.X, e.Y));
                    if (dockControl == null && this.xb48529af1739dd06.Contains(e.X, e.Y))
                        dockControl = this.SelectedControl;
          
                    if (dockControl != null && this.IsInContainer)
                    {
                        Point point = new Point(e.X, e.Y);
                        Point p = dockControl.Parent.PointToScreen(point);
                        point = dockControl.PointToClient(p);
                        this.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(dockControl, point, ContextMenuContext.RightClick));
                        return;
                    }
                }

                if ((e.Button & MouseButtons.Middle) == MouseButtons.Middle && this.IsInContainer && (this.DockContainer.Manager != null && this.DockContainer.Manager.AllowMiddleButtonClosure))
                {
                    DockControl controlAt = this.GetControlAt(new System.Drawing.Point(e.X, e.Y));
                    if (controlAt == null || !controlAt.AllowClose)
                        return;
                    controlAt.x8ffe90e7fbccfccd(true);
                }
                else
                {
                    if ((e.Button & MouseButtons.Left) != MouseButtons.Left || this.HighlightedButton == null)
                        return;
                    this.xa82f7b310984e03e(this.HighlightedButton);
                    this.xfa5e20eb950b9ee1 = false;
                    this.xd541e2fc281b554b();
                }
            }
            else
                this.x531514c39973cbc6.Commit();
        }

        internal virtual void x11e90588eb0baaf1(ControlButton controlButton)
        {
        }

        internal virtual void xa82f7b310984e03e(ControlButton controlButton)
        {
            if (this.HighlightedButton == this.closeButton)
                this.OnCloseButtonClick(EventArgs.Empty);
            else if (this.HighlightedButton == this.pinButton)
                this.OnPinButtonClick();
            else if (this.HighlightedButton == this.positionButton)
                this.xf0820a0467228c88();
        }

        private void xf0820a0467228c88()
        {
            this.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(this.SelectedControl, this.SelectedControl.PointToClient(this.SelectedControl.Parent.PointToScreen(new Point(this.positionButton.Bounds.Left, this.positionButton.Bounds.Bottom))), ContextMenuContext.OptionsButton));
        }

        /// <summary>
        /// Overridden
        /// 
        /// </summary>
        protected internal override void OnMouseLeave()
        {
            base.OnMouseLeave();
            this.HighlightedButton = null;
            this.xfa5e20eb950b9ee1 = false;
        }

        internal bool x61ce2417e4ef76f9()
        {
            if (!this.IsInContainer || this.SelectedControl == null || !this.SelectedControl.ContainsFocus)
                return false;
            this.ContainsFocus = true;
            if (this.SelectedControl != null)
                this.DockContainer.Manager.OnDockControlActivated(new DockControlEventArgs(this.SelectedControl));
            return true;
        }

        internal void x82dd941e2755ffd2()
        {
            this.ContainsFocus = false;
        }
        // reviewed with 2.4
        internal override void x84b6f3c22477dacb(RendererBase render, Graphics g, Font font)
        {
            if (this.DockContainer == null)
                return;
            Control container = this.DockContainer.IsFloating || this.DockContainer.Manager == null || this.DockContainer.Manager.DockSystemContainer == null ? this.DockContainer : this.DockContainer.Manager.DockSystemContainer;
            bool focused = !this.IsInContainer || !this.DockContainer.FriendDesignMode ? this.ContainsFocus : ((ISelectionService)this.DockContainer.x7159e85e85b84817(typeof(ISelectionService))).GetComponentSelected(this.SelectedControl);
            if (this.SelectedControl != null)
                render.DrawControlClientBackground(g, this.x21ed2ecc088ef4e4, this.SelectedControl.BackColor);
            else
                render.DrawControlClientBackground(g, this.x21ed2ecc088ef4e4, SystemColors.Control);
            if ((this.Controls.Count > 1 || this.DockContainer.FriendDesignMode) && this.xa358da7dd5364cab != Rectangle.Empty)
            {
                int selectedTabOffset = 0;
                if (this.selectedControl != null)
                    selectedTabOffset = this.selectedControl.TabBounds.X - this.Bounds.Left;
                render.DrawTabStripBackground(container, (Control)this.DockContainer, g, this.xa358da7dd5364cab, selectedTabOffset);
                foreach (DockControl control in this.Controls)
                {
                    DrawItemState state = DrawItemState.Default;
                    if (this.selectedControl == control)
                        state |= DrawItemState.Selected;
                    bool drawSeparator = false;
                    if (this.Controls != null && this.controls.IndexOf(control) == this.controls.IndexOf(this.selectedControl) - 1)
                        drawSeparator = false;
                    if (this.controls.IndexOf(control) == this.controls.Count - 1 && (render is WhidbeyRenderer))
                        drawSeparator = false;
                    render.DrawTabStripTab(g, control.tabBounds, control.WorkingTabImage, control.TabText, control.Font, control.BackColor, control.ForeColor, state, drawSeparator);
                }
            }

            Rectangle rectangle = this.xb48529af1739dd06;
            if (!(rectangle != Rectangle.Empty) || rectangle.Width <= 0 || rectangle.Height <= 0)
                return;
            render.DrawTitleBarBackground(g, rectangle, focused);
            if (this.closeButton.Enabled)
                rectangle.Width -= 21;
            if (this.pinButton.Enabled)
                rectangle.Width -= 21;
            if (this.positionButton.Enabled)
                rectangle.Width -= 21;

            Rectangle bounds = render.TitleBarMetrics.RemovePadding(rectangle);
            if (rectangle.Width > 8)
                render.DrawTitleBarText(g, rectangle, focused, this.selectedControl == null ? "Empty Layout System" : this.selectedControl.Text, this.selectedControl != null ? this.selectedControl.Font : this.DockContainer.Font);
            if (this.closeButton.Enabled && this.closeButton.Bounds.Left > this.xb48529af1739dd06.Left)
            {
                DrawItemState state = DrawItemState.Default;
                if (this.HighlightedButton == this.closeButton)
                {
                    state |= DrawItemState.HotLight;
                    if (this.xfa5e20eb950b9ee1)
                        state |= DrawItemState.Selected;
                }
                render.DrawTitleBarButton(g, this.closeButton.Bounds, SandDockButtonType.Close, state, focused, false);
            }
            if (this.pinButton.Enabled && this.pinButton.Bounds.Left > this.xb48529af1739dd06.Left)
            {
                DrawItemState state = DrawItemState.Default;
                if (this.HighlightedButton == this.pinButton)
                {
                    state |= DrawItemState.HotLight;
                    if (this.xfa5e20eb950b9ee1)
                        state |= DrawItemState.Selected;
                }
                render.DrawTitleBarButton(g, this.pinButton.Bounds, SandDockButtonType.Pin, state, focused, this.Collapsed);
            }
            if (!this.positionButton.Enabled || this.positionButton.Bounds.Left <= this.xb48529af1739dd06.Left)
                return;
            DrawItemState state1 = DrawItemState.Default;
            if (this.HighlightedButton == this.positionButton)
            {
                state1 |= DrawItemState.HotLight;
                if (this.xfa5e20eb950b9ee1)
                    state1 |= DrawItemState.Selected;
            }
            render.DrawTitleBarButton(g, this.positionButton.Bounds, SandDockButtonType.WindowPosition, state1, focused, false);
        }
        // reviewed with 2.4
        internal void xb30ec7cfdf3e5c19(Graphics g, RendererBase render, ControlButton controlButton, SandDockButtonType buttonType, bool x2fef7d841879a711)
        {
            if (!controlButton.Enabled)
                return;
            DrawItemState state = DrawItemState.Default;
            if (this.HighlightedButton == controlButton)
            {
                state |= DrawItemState.HotLight;
                if (this.xfa5e20eb950b9ee1)
                    state |= DrawItemState.Selected;
            }
            if (!x2fef7d841879a711)
                state |= DrawItemState.Disabled;
            render.DrawDocumentStripButton(g, controlButton.Bounds, buttonType, state);
        }
        // reviewed
        internal virtual void xd541e2fc281b554b()
        {
            if (this.AutoHideBar != null)
            {
                if (this.AutoHideBar.ShowingLayoutSystem == this)
                    this.AutoHideBar.xbb5f70c792fb9034(this.xb48529af1739dd06);
            }
            else
            {
                if (this.IsInContainer)
                    this.DockContainer.Invalidate(this.xb48529af1739dd06);
            }
        }

        internal override void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
        {
            base.x46ff430ed3944e0f(x11d58b056c032b03);
            label_26:
            if (x11d58b056c032b03 != null)
            {
                if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.None || x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.AlreadyActioned)
                    return;
            }
            else
                goto label_27;
            label_23:
            DockControl selectedControl = this.SelectedControl;
            if (0 == 0)
                goto label_29;
            else
                goto label_26;
            label_27:
            if (0 == 0)
                return;
            if (-2 != 0)
                goto label_23;
            label_29:
            if (0 != 0)
                return;
            SandDockManager manager = this.DockContainer.Manager;
            if (this.x49cf4e0157d9436c)
                goto label_16;
            else
                goto label_14;
            label_6:
            while (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.Float)
            {
                if (3 != 0)
                {
                    if (x11d58b056c032b03.dockContainer != null)
                        goto label_4;
                    else
                        goto label_9;
                    label_1:
                    selectedControl.Activate();
                    return;
                    label_4:
                    this.x6b145af772038ef2(manager, selectedControl, this.x49cf4e0157d9436c, x11d58b056c032b03);
                    if (selectedControl == null)
                    {
                        if (0 == 0)
                            return;
                        if ((int)byte.MaxValue != 0)
                            goto label_26;
                        else
                            goto label_23;
                    }
                    else
                        goto label_1;
                    label_9:
                    if (0 == 0)
                    {
                        if (int.MaxValue != 0)
                        {
                            if ((int)byte.MaxValue != 0 && x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.CreateNewContainer)
                                return;
                            else
                                goto label_4;
                        }
                    }
                    else
                        goto label_1;
                }
                else
                    goto label_11;
            }
            goto label_13;
            label_11:
            selectedControl.OpenFloating(x11d58b056c032b03.bounds, WindowOpenMethod.OnScreenActivate);
            if (0 != 0 || -2 != 0)
                return;
            label_12:
            this.Float(manager, x11d58b056c032b03.bounds, WindowOpenMethod.OnScreenActivate);
            if (0 == 0)
                return;
            label_13:
            selectedControl.MetaData.x87f4a9b62a380563(Guid.NewGuid());
            if (this.x49cf4e0157d9436c)
                goto label_12;
            else
                goto label_11;
            label_14:
            LayoutUtilities.xf1cbd48a28ce6e74(selectedControl);
            goto label_6;
            label_16:
            LayoutUtilities.x4487f2f8917e3fd0(this);
            goto label_6;
        }

        internal void x6b145af772038ef2(SandDockManager x91f347c6e97f1846, DockControl x43bec302f92080b9, bool x49cf4e0157d9436c, xedb4922162c60d3d.DockTarget x11d58b056c032b03)
        {
            DockContainer dockedContainer = null;
            if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.JoinExistingSystem)
            {
                if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.CreateNewContainer)
                {
                    if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.SplitExistingSystem)
                        return;
                    DockContainer dockContainer = x11d58b056c032b03.dockContainer;
                    DockControl[] controls;
                    if (!x49cf4e0157d9436c)
                        controls = new DockControl[1]
                        {
                            x43bec302f92080b9
                        };
                    else
                        controls = this.AllControls;
                    SizeF workingSize = this.WorkingSize;
                    ControlLayoutSystem newLayoutSystem = dockContainer.CreateNewLayoutSystem(controls, workingSize);
                    x11d58b056c032b03.layoutSystem.SplitForLayoutSystem((LayoutSystemBase)newLayoutSystem, x11d58b056c032b03.dockSide);
                    return;
                }
                else
                {
                    dockedContainer = x91f347c6e97f1846.FindDockedContainer(DockStyle.Fill);

                    if (x11d58b056c032b03.dockLocation != ContainerDockLocation.Center)
                        goto label_11;

                }
            }
            else
                goto label_23;
            label_10:
            while (dockedContainer != null)
            {
                ControlLayoutSystem controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem(dockedContainer);
                if (controlLayoutSystem == null)
                    return;
                if (x49cf4e0157d9436c)
                {
                    this.Dock(controlLayoutSystem);
                    return;
                }
                else
                {
                    x43bec302f92080b9.x02847d0dec2e498a(controlLayoutSystem, 0);
                    if (true)
                        return;
                }

            }
            label_11:
            if (!x49cf4e0157d9436c)
            {
                x43bec302f92080b9.DockInNewContainer(x11d58b056c032b03.dockLocation, x11d58b056c032b03.middle ? ContainerDockEdge.Inside : ContainerDockEdge.Outside);
                return;
            }
            else
            {
                this.x810df8ef88cf4bf2(x91f347c6e97f1846, x11d58b056c032b03.dockLocation, x11d58b056c032b03.middle ? ContainerDockEdge.Inside : ContainerDockEdge.Outside);
                return;
            }
            label_20:
            x43bec302f92080b9.x02847d0dec2e498a(x11d58b056c032b03.layoutSystem, x11d58b056c032b03.index);
            if (((x49cf4e0157d9436c ? 1 : 0) & 0) == 0)
                return;
            else
                goto label_10;
            label_23:
            if (x49cf4e0157d9436c)
                this.Dock(x11d58b056c032b03.layoutSystem, x11d58b056c032b03.index);
            else
                goto label_20;
        }

        /// <summary>
        /// Splits this layout and moves another one in to the specified side.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This method should be used to programmatically split an existing control layout system to receive another layout system. If the requested
        ///             split would result in a split with a different orientation than the parent, this layout system is removed from the parent and replaced with a new
        ///             split layout system to contain both layout systems.
        /// </para>
        /// 
        /// </remarks>
        // reviewed with 2.4
        public void SplitForLayoutSystem(LayoutSystemBase layoutSystem, DockSide side)
        {
            if (layoutSystem == null)
                throw new ArgumentNullException("layoutSystem");
      
            if (side == DockSide.None)
                throw new ArgumentException("side");
            if (layoutSystem.Parent != null)
                throw new InvalidOperationException("This layout system must be removed from its parent before it can be moved to a new layout system.");
            if (this.Parent == null)
                throw new InvalidOperationException("This layout system is not parented yet.");

            SplitLayoutSystem parent = this.Parent;
            if (parent.SplitMode == Orientation.Horizontal)
            {
                if (side == DockSide.Top || side == DockSide.Bottom)
                    this.x46d2db93dc2104ad(layoutSystem, side == DockSide.Top ? parent.LayoutSystems.IndexOf(this) : parent.LayoutSystems.IndexOf(this) + 1, true);
                else
                    this.xd2be843c6119e3c3(layoutSystem, Orientation.Vertical, side == DockSide.Left);
            }
            else
            {
                if (parent.SplitMode != Orientation.Vertical)
                    return;
                if (side == DockSide.Left || side == DockSide.Right)
                    this.x46d2db93dc2104ad(layoutSystem, side == DockSide.Left ? parent.LayoutSystems.IndexOf(this) : parent.LayoutSystems.IndexOf(this) + 1, false);
                else
                    this.xd2be843c6119e3c3(layoutSystem, Orientation.Horizontal, side == DockSide.Top);
            }
        }

        private void x46d2db93dc2104ad(LayoutSystemBase x6e150040c8d97700, int xc0c4c459c6ccbd00, bool xab8cd0402556fe8f)
        {
            SplitLayoutSystem parent = this.Parent;
            parent.LayoutSystems.xd7a3953bce504b63 = true;
            parent.LayoutSystems.Insert(xc0c4c459c6ccbd00, x6e150040c8d97700);
            parent.LayoutSystems.xd7a3953bce504b63 = false;
            parent.x8e9e04a70e31e166();
        }

        private void xd2be843c6119e3c3(LayoutSystemBase x6e150040c8d97700, Orientation xf65758d54b79fc7a, bool x6b161b1ae41c1651)
        {
            SplitLayoutSystem parent = this.Parent;
            SplitLayoutSystem splitLayoutSystem = new SplitLayoutSystem();
            splitLayoutSystem.SplitMode = xf65758d54b79fc7a;
            splitLayoutSystem.WorkingSize = this.WorkingSize;
            int index = parent.LayoutSystems.IndexOf(this);
            parent.LayoutSystems.xd7a3953bce504b63 = true;
            parent.LayoutSystems.Remove(this);
            parent.LayoutSystems.Insert(index, splitLayoutSystem);
            parent.LayoutSystems.xd7a3953bce504b63 = false;
            splitLayoutSystem.LayoutSystems.Add(this);
            if (x6b161b1ae41c1651)
                splitLayoutSystem.LayoutSystems.Insert(0, x6e150040c8d97700);
            else
                splitLayoutSystem.LayoutSystems.Add(x6e150040c8d97700);
            parent.x8e9e04a70e31e166();
        }

        internal void x18f55df6f6629e9f(DockSituation situation)
        {
            if (this.Controls.Count != 0)
            {
                while (this.SelectedControl.DockSituation != situation)
                {
                    label_18:
                    DockControl selectedControl = this.SelectedControl;
                    DockControl[] array = new DockControl[this.Controls.Count];
                    this.Controls.CopyTo(array, 0);
                    if (0 != 0)
                    {
                        if (0 == 0)
                            goto label_18;
                    }
                    else if (2 != 0)
                    {
                        if (0 != 0)
                            break;
                        LayoutUtilities.x4487f2f8917e3fd0(this);
                        this.Controls.Clear();
                        do
                        {
                            if (situation == DockSituation.Docked)
                                goto label_14;
                            else
                                goto label_12;
                            label_3:
                            DockControl[] controls = new DockControl[array.Length - 1];
                            do
                            {
                                Array.Copy((Array)array, 1, (Array)controls, 0, array.Length - 1);
                            }
                            while (0 != 0);
                            array[0].LayoutSystem.Controls.AddRange(controls);
                            continue;
                            label_12:
                            if (3 != 0)
                            {
                                do
                                {
                                    if (situation != DockSituation.Document)
                                    {
                                        if (situation == DockSituation.Floating)
                                        {
                                            if (-1 != 0)
                                                array[0].OpenFloating(WindowOpenMethod.OnScreenActivate);
                                            else
                                                goto label_20;
                                        }
                                        else
                                            goto label_2;
                                    }
                                    else
                                        goto label_10;
                                }
                                while (2 == 0);
                                goto label_3;
                                label_10:
                                array[0].OpenDocument(WindowOpenMethod.OnScreenActivate);
                                goto label_3;
                            }
                            else
                                break;
                            label_14:
                            array[0].OpenDocked(WindowOpenMethod.OnScreenActivate);
                            goto label_3;
                        }
                        while (0 != 0);
                        array[0].LayoutSystem.SelectedControl = selectedControl;
                        break;
                        label_2:
                        throw new InvalidOperationException();
                    }
                    else
                        goto label_20;
                }
                return;
            }
            label_20:
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Moves the control layout system in to a new floating container.
        /// 
        /// </summary>
        /// <param name="manager">The manager responsible for this layout.</param><param name="bounds">The desktop bounds of the floating window, in pixels.</param><param name="openMethod">The level to which the window is brought to the forefront.</param>
        public void Float(SandDockManager manager, Rectangle bounds, WindowOpenMethod openMethod)
        {
            if (this.Parent != null)
                LayoutUtilities.x4487f2f8917e3fd0(this);
            if (this.SelectedControl.MetaData.LastFloatingWindowGuid == Guid.Empty)
                this.SelectedControl.MetaData.x87f4a9b62a380563(Guid.NewGuid());
            FloatingDockContainer x410f3612b9a8f9de = new FloatingDockContainer(manager, this.SelectedControl.MetaData.LastFloatingWindowGuid);
            x410f3612b9a8f9de.LayoutSystem.LayoutSystems.Add(this);
            x410f3612b9a8f9de.x159713d3b60fae0c(bounds, true, openMethod == WindowOpenMethod.OnScreenActivate);
            if (openMethod != WindowOpenMethod.OnScreenActivate)
                return;
            this.SelectedControl.Activate();
        }

        /// <summary>
        /// Moves the unparented control layout system in to a new floating container.
        /// 
        /// </summary>
        /// <param name="manager">The manager responsible for this layout.</param>
        public void Float(SandDockManager manager)
        {
            if (this.SelectedControl == null)
                throw new InvalidOperationException("The layout system must have a selected control to be floated.");
            this.Float(manager, this.SelectedControl.xc0154d85fceb081c(), WindowOpenMethod.OnScreenActivate);
        }

        /// <summary>
        /// Moves this layout system in to an existing layout system.
        /// 
        /// </summary>
        /// <param name="layoutSystem">The layout system to move in to.</param>
        public void Dock(ControlLayoutSystem layout)
        {
            if (layout == null)
                throw new ArgumentNullException();
            this.Dock(layout, 0);
        }

        /// <summary>
        /// Moves this layout system in to an existing layout system, at the specified offset.
        /// 
        /// </summary>
        /// <param name="layoutSystem">The layout system to move in to.</param><param name="index">The offset of the new tabs in the existing layout system.</param>
        public void Dock(ControlLayoutSystem layout, int index)
        {
            if (layout == null)
                throw new ArgumentNullException();
            if (this.Parent != null)
                throw new InvalidOperationException("This layout system already has a parent. To remove it, use the parent layout system's LayoutSystems.Remove method.");
            DockControl selectedControl = this.SelectedControl;
            while (this.Controls.Count != 0)
            {
                DockControl control = this.Controls[0];
                this.Controls.RemoveAt(0);
                layout.Controls.Insert(index, control);
            }
            if (selectedControl != null)
                layout.SelectedControl = selectedControl;
        }
        // reveiwed with 2.4
        internal override void x56e964269d48cfcc(DockContainer dockContainer)
        {
            if (dockContainer == null && this.IsInContainer)
            {
                foreach (DockControl dockControl in this.Controls)
                {
                    if (dockControl.Parent == this.DockContainer)
                        LayoutUtilities.xa7513d57b4844d46(dockControl);
                }
            }

            if (dockContainer != null && !this.IsInContainer)
            {
                foreach (DockControl dockControl in this.Controls)
                {
                    if (dockControl.Parent != null)
                        LayoutUtilities.xa7513d57b4844d46((Control)dockControl);
                    dockControl.Location = new Point(dockContainer.Width, dockContainer.Height);
                    if (!this.Collapsed || !dockContainer.CanShowCollapsed)
                        dockControl.Parent = dockContainer;
                }
            }

            base.x56e964269d48cfcc(dockContainer);
            foreach (DockControl dockControl in this.Controls)
                dockControl.x56e964269d48cfcc(dockContainer);
            if (!this.Collapsed)
                return;
            if (dockContainer != null && dockContainer.Manager != null && this.AutoHideBar == null)
            {
                if (this.AutoHideBar == null)
                {
                    AutoHideBar autoHideBar = dockContainer.Manager.GetAutoHideBar(dockContainer.Dock);
                    if (autoHideBar != null)
                        autoHideBar.LayoutSystems.Add(this);
                }
            }
            else
            {
                if (this.AutoHideBar != null)
                    this.AutoHideBar.LayoutSystems.Remove(this);
            }          
        }

        /// <summary>
        /// Retrieves the dock control with a tab at the specified position.
        /// 
        /// </summary>
        /// <param name="position">The location, in client coordinates, to search.</param>
        /// <returns>
        /// The dock control found. If no dock control was found, a null reference is returned.
        /// </returns>
        public virtual DockControl GetControlAt(Point position)
        {
            if (this.xa358da7dd5364cab.Contains(position) && (!this.closeButton.Bounds.Contains(position)) && !this.pinButton.Bounds.Contains(position))
            {  
                foreach (DockControl dockControl in this.Controls)
                {
                    if (dockControl.TabBounds.Contains(position))
                        return dockControl;
                }
            }
            return null;
        }

        internal int x17fd454c85fad336(Point position)
        {
            int num = 0;
            foreach (DockControl dockControl in this.Controls)
            {
                Rectangle rectangle = dockControl.TabBounds;
                if (position.X > rectangle.Left + rectangle.Width / 2)
                    ++num;
            }
            return num;
        }

        internal void x3e0280cae730d1f2()
        {
            if (this.AutoHideBar != null)
                this.AutoHideBar.x200394302d96eb9b(this);
            if (!this.IsInContainer)
                return;
            if (this.DockContainer.IsFloating)
                this.DockContainer.CalculateAllMetricsAndLayout();
            else
                this.DockContainer.xec9697acef66c1bc(this, this.Bounds);
            this.DockContainer.Invalidate(this.Bounds);
        }
        // reviewed with 2.4
        private void x5425d90305f1baa5()
        {
            int num1;
            if (this.selectedControl == null)
            {
                this.closeButton.Enabled = false;
                this.pinButton.Enabled = false;
                this.positionButton.Enabled = false;
            }
            else
            {
                int y = this.xb48529af1739dd06.Top + this.xb48529af1739dd06.Height / 2 - 7;
                int num2 = this.xb48529af1739dd06.Right - 2;
                if (!this.selectedControl.AllowClose)
                    this.closeButton.Enabled = false;
                else
                {
                    this.closeButton.Enabled = true;
                    this.closeButton.Bounds = new Rectangle(num2 - 19, y, 19, 15);
                    num2 -= 21;
                }
 
                if (this.AllowCollapse && (!this.IsInContainer || this.DockContainer.CanShowCollapsed))
                {
                    this.pinButton.Enabled = true;
                    this.pinButton.Bounds = new Rectangle(num2 - 19, y, 19, 15);
                    num2 -= 21;
                }
                else
                    this.pinButton.Enabled = false;
        
                if (!this.selectedControl.ShowOptions)
                {
                    this.positionButton.Enabled = false;
                }
                else
                {
                    this.positionButton.Enabled = true;
                    this.positionButton.Bounds = new Rectangle(num2 - 19, y, 19, 15);
                    num1 = num2 - 21;
                }
            }                 
        }

        /// <summary>
        /// Calculates the regions of the constituent parts of the control layout system when it is collapsed.
        /// 
        /// </summary>
        /// <param name="renderer">The renderer from which object metrics can be calculated.</param><param name="bounds">The region occupied by the layout system.</param>
        protected internal virtual void LayoutCollapsed(RendererBase renderer, Rectangle bounds)
        {
            this.xb48529af1739dd06 = bounds;
            this.xb48529af1739dd06.Offset(0, renderer.TitleBarMetrics.Margin.Top);
            this.xb48529af1739dd06.Height = renderer.TitleBarMetrics.Height - (renderer.TitleBarMetrics.Margin.Top + renderer.TitleBarMetrics.Margin.Bottom);
            this.x5425d90305f1baa5();
            bounds.Offset(0, renderer.TitleBarMetrics.Height);
            bounds.Height -= renderer.TitleBarMetrics.Height;
            this.x21ed2ecc088ef4e4 = bounds;
            this.xa358da7dd5364cab = Rectangle.Empty;
            foreach (DockControl control in this.Controls)
            {
                Rectangle rectangle = renderer.AdjustDockControlClientBounds(this, control, this.x21ed2ecc088ef4e4);
                control.xbdd4aaac1291a8c7(control == this.selectedControl);
                control.Bounds = rectangle;
            }
        }

        /// <summary>
        /// Calculates the regions of the constituent parts of the control layout system.
        /// 
        /// </summary>
        /// <param name="renderer">The renderer to use to measure items.</param><param name="bounds">The region occupied by the layout system.</param><param name="floating">Whether the layout system is floating.</param><param name="titlebarBounds">The region occupied by the titlebar.</param><param name="tabstripBounds">The region occupied by the tabstrip.</param><param name="clientBounds">The region occupied by the client area.</param><param name="joinCatchmentBounds">The region that will accept other layout systems when they are dragged over it.</param>
        protected virtual void CalculateLayout(RendererBase renderer, Rectangle bounds, bool floating, out Rectangle titlebarBounds, out Rectangle tabstripBounds, out Rectangle clientBounds, out Rectangle joinCatchmentBounds)
        {
            if (floating)
            {
                titlebarBounds = Rectangle.Empty;
            }
            else
            {
                titlebarBounds = bounds;
                titlebarBounds.Offset(0, renderer.TitleBarMetrics.Margin.Top);
                titlebarBounds.Height = renderer.TitleBarMetrics.Height - (renderer.TitleBarMetrics.Margin.Top + renderer.TitleBarMetrics.Margin.Bottom);
                this.x5425d90305f1baa5();
                bounds.Offset(0, renderer.TitleBarMetrics.Height);
                bounds.Height -= renderer.TitleBarMetrics.Height;    
            }

            if (this.Controls.Count >= 1 || this.DockContainer.FriendDesignMode)
            {
                tabstripBounds = bounds;
                tabstripBounds.Y = tabstripBounds.Bottom - renderer.TabStripMetrics.Height;
                tabstripBounds.Height = renderer.TabStripMetrics.Height;
                tabstripBounds = renderer.TabStripMetrics.RemoveMargin(tabstripBounds);
                bounds.Height -= renderer.TabStripMetrics.Height;
            }
            else
                tabstripBounds = Rectangle.Empty;

            clientBounds = bounds;
            joinCatchmentBounds = titlebarBounds;       
        }

        private void x7fd1f193b21c8833()
        {
            foreach (DockControl dockControl in this.Controls)
                dockControl.x44fd51d909a57a2a();
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void Layout(RendererBase renderer, Graphics graphics, Rectangle bounds, bool floating)
        {
            base.Layout(renderer, graphics, bounds, floating);
            this.x7fd1f193b21c8833();
            if (this.Collapsed && this.DockContainer.CanShowCollapsed)
                return;

            this.CalculateLayout(renderer, bounds, floating, out this.xb48529af1739dd06, out this.xa358da7dd5364cab, out this.x21ed2ecc088ef4e4, out this.joinCatchmentBounds);
            this.xd30df1068ed42e28 = true;
            try
            {
                if (this.xb48529af1739dd06 != Rectangle.Empty)
                    this.x5425d90305f1baa5();
                this.x5d6e30ce9634c49e(renderer, graphics, this.xa358da7dd5364cab);
                foreach (DockControl dockControl in this.controls)
                {
                    if (dockControl != this.SelectedControl)
                        dockControl.xbdd4aaac1291a8c7(false);
                }

                foreach (DockControl control in this.controls)
                {
                    if (control == this.SelectedControl)
                    {
                        Rectangle rectangle = renderer.AdjustDockControlClientBounds(this, control, this.x21ed2ecc088ef4e4);
                        control.Bounds = rectangle;
                        control.xbdd4aaac1291a8c7(true);
                    }
                }
            }
            finally
            {
                this.xd30df1068ed42e28 = false;
            }
        }
        // reviewed with 2.4
        private void x5d6e30ce9634c49e(RendererBase render, Graphics g, Rectangle bounds)
        {
            int num1 = 0;
            int num2 = bounds.Width - (render.TabStripMetrics.Padding.Left + render.TabStripMetrics.Padding.Right);
            int[] numArray = new int[this.controls.Count];
            int index1 = 0;
            int num3 = 0;
            int index3 = 0;
            int left;
            int val1;
            foreach (DockControl dockControl in this.controls)
            {
                dockControl.xcfac6723d8a41375 = false;
                val1 = render.MeasureTabStripTab(g, dockControl.TabImage, dockControl.TabText, dockControl.Font, DrawItemState.Default).Width;
                if (dockControl.MinimumTabWidth != 0)
                    val1 = Math.Max(val1, dockControl.MinimumTabWidth);
                if (dockControl.MaximumTabWidth != 0 && dockControl.MaximumTabWidth < val1)
                {
                    val1 = dockControl.MaximumTabWidth;
                    dockControl.xcfac6723d8a41375 = true;
                }
                num1 += val1;
                numArray[index1++] = val1;
            }
            if (num1 > num2)
            {
                num3 = num1 - num2;
                for (index3 = 0; index3 < index1; ++index3)
                {
                    numArray[index3] -= (int)((double)num3 * ((double)numArray[index3] / (double)num1));
                    this.controls[index3].xcfac6723d8a41375 = true;
                }
            }
            bounds = render.TabStripMetrics.RemovePadding(bounds);
            left = bounds.Left;
            index1 = 0;
            for (int i = 0; i < this.controls.Count; ++i)
            {
                DockControl dockControl1 = this.controls[i];
                BoxModel tabMetrics = render.TabMetrics;
                Rectangle rectangle = new Rectangle(left + tabMetrics.Margin.Left, bounds.Top + tabMetrics.Margin.Top, tabMetrics.Padding.Left + numArray[index1] + tabMetrics.Padding.Right, bounds.Height - (tabMetrics.Margin.Top + tabMetrics.Margin.Bottom));
                dockControl1.tabBounds = rectangle;
                left += rectangle.Width + tabMetrics.ExtraWidth;
                ++index1;
            }
        }

        /// <summary>
        /// A collection of dock controls belonging to a ControlLayoutSystem.
        /// 
        /// </summary>
        public class DockControlCollection : CollectionBase
        {
            private ControlLayoutSystem parent;
            private bool x6278c23b2376c7c7;
            private bool xa536df1e17daee9d;

            /// <summary>
            /// Returns the dock control at the specified index in the collection.
            /// 
            /// </summary>
            public DockControl this [int index]
            {
                get
                {
                    return (DockControl)this.List[index];
                }
            }

            internal DockControlCollection(ControlLayoutSystem parent)
            {
                this.parent = parent;
            }

            internal int x259d21cdec19b1cf(int xff665e1cf667e663, bool x1743ddb153315e91)
            {
                if (xff665e1cf667e663 < 0 || xff665e1cf667e663 > this.Count)
                    xff665e1cf667e663 = !x1743ddb153315e91 ? 0 : this.Count;
                return xff665e1cf667e663;
            }

            /// <summary>
            /// Used to move an existing dock control to a new offset in the collection.
            /// 
            /// </summary>
            /// <param name="control">The control that needs to be moved.</param><param name="index">The new tab offset for the control.</param>
            /// <remarks>
            /// 
            /// <para>
            /// The control's offset in the collection governs the order in which its tab is displayed in the tabstrip.
            /// </para>
            /// 
            /// </remarks>
            // reviewed with 2.4
            public void SetChildIndex(DockControl control, int index)
            {
                if (control == null)
                    throw new ArgumentNullException("control");
                if (!this.Contains(control))
                    throw new ArgumentOutOfRangeException("control");
                if (index == this.IndexOf(control))
                    return;
                if (this.IndexOf(control) < index)
                    --index;
                this.xa536df1e17daee9d = true;
                this.List.Remove(control);
                this.List.Insert(index, control);
                this.xa536df1e17daee9d = false;
                this.parent.x3e0280cae730d1f2(); 
            }

            /// <summary>
            /// Overridden.
            /// 
            /// </summary>
            protected override void OnClear()
            {
                base.OnClear();
                foreach (DockControl dockControl in this)
                {
                    dockControl.SetControlLayoutSystem(null);
                    dockControl.x44fd51d909a57a2a();
                }
            }

            /// <summary>
            /// Overridden.
            /// 
            /// </summary>
            protected override void OnClearComplete()
            {
                base.OnClearComplete();
                this.parent.SelectedControl = null;
                this.parent.x3e0280cae730d1f2();
                if (this.parent.DockContainer != null)
                    this.parent.DockContainer.x5fc4eceec879ff0f();
            }

            /// <summary>
            /// Overridden.
            /// 
            /// </summary>
            // reviewed with 2.4
            protected override void OnInsertComplete(int index, object value)
            {
                base.OnInsertComplete(index, value);
                if (this.xa536df1e17daee9d)
                    return;
                DockControl dockControl = (DockControl)value;
                dockControl.SetControlLayoutSystem(this.parent);
                if (this.parent.IsInContainer && this.parent.DockContainer.Manager != null && this.parent.DockContainer.Manager != dockControl.Manager)
                    dockControl.Manager = this.parent.DockContainer.Manager;
                if (this.parent.IsInContainer)
                    dockControl.x56e964269d48cfcc(this.parent.DockContainer);
                if (this.parent.IsInContainer)
                {
                    if (dockControl.Parent != null)
                        LayoutUtilities.xa7513d57b4844d46((Control)dockControl);
                    dockControl.Parent = this.parent.ControlParent;
                }
                if (this.parent.selectedControl == null)
                    this.parent.SelectedControl = dockControl;
                if (this.parent.DockContainer != null)
                    this.parent.DockContainer.x5fc4eceec879ff0f();
                if (!this.x6278c23b2376c7c7)
                    this.parent.x3e0280cae730d1f2();
            }

            /// <summary>
            /// Overridden.
            /// 
            /// </summary>
            protected override void OnRemoveComplete(int index, object value)
            {
                base.OnRemoveComplete(index, value);
                if (this.xa536df1e17daee9d)
                    return;
                DockControl dockControl = (DockControl)value;
                dockControl.SetControlLayoutSystem(null);
                dockControl.x44fd51d909a57a2a();
                if (dockControl.Parent != null && dockControl.Parent == this.parent.ControlParent)
                    LayoutUtilities.xa7513d57b4844d46(dockControl);

                if (this.parent.selectedControl == value)
                    this.parent.SelectedControl = this.parent.controls.Count != 0 ? this[0] : null;
                if (this.parent.DockContainer != null)
                    this.parent.DockContainer.x5fc4eceec879ff0f();
                this.parent.x3e0280cae730d1f2();
            }

            /// <summary>
            /// Adds an array of dock controls in to the collection.
            /// 
            /// </summary>
            /// <param name="controls">The array of controls to add.</param>
            /// <remarks>
            /// 
            /// <para>
            /// When adding more than one control at a time to the collection you should use this method, as layout logic is postponed until after the
            ///             whole batch had been added.
            /// </para>
            /// 
            /// </remarks>
            // reviewed wit 2.4
            public void AddRange(DockControl[] controls)
            {
                this.x6278c23b2376c7c7 = true;
                foreach (DockControl control in controls)
                    this.Add(control);
                this.x6278c23b2376c7c7 = false;
                this.parent.x3e0280cae730d1f2();
            }

            /// <summary>
            /// Adds a dock control to the collection.
            /// 
            /// </summary>
            /// <param name="control">The control to add.</param>
            /// <returns>
            /// The new index of the control in the collection.
            /// </returns>
            public int Add(DockControl control)
            {
                if (this.List.Contains(control))
                    throw new InvalidOperationException("The DockControl already belongs to this ControlLayoutSystem.");
                int count = this.Count;
                this.Insert(count, control);
                return count;
            }

            /// <summary>
            /// Inserts a dock control in to the collection at a given offset.
            /// 
            /// </summary>
            /// <param name="index">The position to insert the control at.</param><param name="control">The control to insert.</param>
            // reviewed with 2.4
            public void Insert(int index, DockControl control)
            {
                if (control == null || control.LayoutSystem == this.parent && (this.IndexOf(control) == index || this.Count == 1))
                    return;

                if (control.LayoutSystem != null)
                {
                    if (this.Contains(control) && this.IndexOf(control) < index)
                        --index;
                    control.LayoutSystem.Controls.Remove(control);
                }
                this.List.Insert(index, control);
            }

            /// <summary>
            /// Removes the specified dock control from the collection.
            /// 
            /// </summary>
            /// <param name="control">The control to remove.</param>
            public void Remove(DockControl control)
            {
                if (control == null)
                    throw new ArgumentNullException("control");
                this.List.Remove(control);
            }

            /// <summary>
            /// Examines the collection to see if it contains the specified dock control.
            /// 
            /// </summary>
            /// <param name="control">The control to look for.</param>
            /// <returns>
            /// A value indicating whether the control was found.
            /// </returns>
            public bool Contains(DockControl control)
            {
                return this.List.Contains((object)control);
            }

            /// <summary>
            /// Returns the index of a dock control in the collection.
            /// 
            /// </summary>
            /// <param name="control">The control to look for.</param>
            /// <returns>
            /// The index of the dock control if found; otherwise -1.
            /// </returns>
            public int IndexOf(DockControl control)
            {
                return this.List.IndexOf((object)control);
            }

            /// <summary>
            /// Copies the contents of the collection in to the given array, starting at the specified offset.
            /// 
            /// </summary>
            /// <param name="array">The array to be copied in to.</param><param name="index">The index to start at.</param>
            public void CopyTo(DockControl[] array, int index)
            {
                this.List.CopyTo(array, index);
            }
        }

        internal delegate void SelectionChangedEventHandler(DockControl oldSelection,DockControl newSelection);
    }
}
