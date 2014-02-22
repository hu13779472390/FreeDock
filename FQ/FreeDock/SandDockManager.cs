using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Xml;
using FQ.FreeDock.Rendering;

namespace FQ.FreeDock
{
    /// <summary>
    /// The manager class in charge of a SandDock layout.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// The SandDockManager class is responsible for linking together the many DockContainers that make up a SandDock layout. DockContainers
    ///             should not exist without being bound to one.
    /// </para>
    /// 
    /// <para>
    /// This class provides a central location for global properties that affect rendering, docking hints and layout persistance.
    /// </para>
    /// 
    /// </remarks>
    [DefaultEvent("ActiveTabbedDocumentChanged")]
    [ToolboxBitmap(typeof(SandDockManager))]
    [Designer("FQ.FreeDock.Design.SandDockManagerDesigner, SandDock.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
    public class SandDockManager : Component
    {
        private DockingHints dockingHints = DockingHints.TranslucentFill;
        private DockingManager dockingManager = DockingManager.Whidbey;
        private int xdca928fc295dbb2a = 30;
        private int maximumDockContainerSize = 500;
        private bool allowDockContainerResize = true;
        private bool allowKeyboardNavigation = true;
        private bool enableTabbedDocuments = true;
        private bool allowMiddleButtonClosure = true;
        private FQ.FreeDock.Rendering.BorderStyle borderStyle = FQ.FreeDock.Rendering.BorderStyle.Flat;
        private DocumentOverflowMode documentOverflow = DocumentOverflowMode.Scrollable;
        private DocumentContainerWindowOpenPosition documentOpenPosition = DocumentContainerWindowOpenPosition.Last;
        internal ArrayList dockContainers;
        internal ArrayList autoHideBars;
        private Hashtable x8fb2a5bf0df0416f;
        private DockControl activeTabbedDocument;
        private RendererBase renderer;
        private bool raiseValidationEvents;
        private bool enableEmptyEnvironment;
        private bool selectTabsOnDrag;
        private bool autoSaveLayout;
        private bool integralClose;
        private DocumentContainer documentContainer;
        private bool serializeTabbedDocuments;
        private Form ownerForm;
        private Control dockSystemContainer;

        /// <summary>
        /// Indicates the last tabbed document to contain the focus.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This method will throw an InvalidOperationException if there is no tabbed document system in operation.
        /// </para>
        /// 
        /// </remarks>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DockControl ActiveTabbedDocument
        {
            get
            {
                return this.activeTabbedDocument;
            }
        }

        /// <summary>
        /// Indicates whether an empty container is left when all tabbed documents have been removed.
        /// 
        /// </summary>
        [Category("Behavior")]
        [Description("Indicates whether an empty container is left when all tabbed documents have been removed.")]
        [DefaultValue(false)]
        public bool EnableEmptyEnvironment
        {
            get
            {
                return this.enableEmptyEnvironment;
            }
            set
            {
                this.enableEmptyEnvironment = value;
            }
        }

        /// <summary>
        /// The type of border to be drawn around the tabbed document area.
        /// 
        /// </summary>
        [Description("The type of border to be drawn around the tabbed document area.")]
        [DefaultValue(typeof(FQ.FreeDock.Rendering.BorderStyle), "Flat")]
        [Category("Appearance")]
        public FQ.FreeDock.Rendering.BorderStyle BorderStyle
        {
            get
            {
                return this.borderStyle;
            }
            set
            {
                this.borderStyle = value;
                if (this.DocumentContainer != null)
                    this.DocumentContainer.x64b4c49ed703037e = this.borderStyle;
            }
        }

        /// <summary>
        /// Retrieves the DocumentContainer in the current SandDock layout.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This property will return a null reference if there is no DocumentContainer.
        /// </para>
        /// 
        /// </remarks>
        [Browsable(false)]
        public DocumentContainer DocumentContainer
        {
            get
            {
                return this.documentContainer;
            }
        }

        /// <summary>
        /// Determines how document tabs that overflow past the visible area are accessed.
        /// 
        /// </summary>
        [Description("Determines how document tabs that overflow past the visible area are accessed.")]
        [Category("Behavior")]
        [DefaultValue(typeof(DocumentOverflowMode), "Scrollable")]
        public DocumentOverflowMode DocumentOverflow
        {
            get
            {
                return this.documentOverflow;
            }
            set
            {
                if (value == this.documentOverflow)
                    return;
                this.documentOverflow = value;
                if (this.DocumentContainer == null && 0 == 0)
                    return;
                this.DocumentContainer.DocumentOverflow = this.DocumentOverflow;
            }
        }

        /// <summary>
        /// Specifies whether documents are opened at the first position or the last.
        /// 
        /// </summary>
        [Description("Specifies whether documents are opened at the first position or the last.")]
        [Category("Behavior")]
        [DefaultValue(typeof(DocumentContainerWindowOpenPosition), "Last")]
        public DocumentContainerWindowOpenPosition DocumentOpenPosition
        {
            get
            {
                return this.documentOpenPosition;
            }
            set
            {
                this.documentOpenPosition = value;
            }
        }

        /// <summary>
        /// Indicates whether the close button is displayed inside the active tab.
        /// 
        /// </summary>
        [Description("Indicates whether the close button is displayed inside the active tab.")]
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool IntegralClose
        {
            get
            {
                return this.integralClose;
            }
            set
            {
                if (value == this.integralClose)
                    return;
                this.integralClose = value;
                if (this.DocumentContainer != null)
                {
                    this.DocumentContainer.IntegralClose = this.IntegralClose;
                }
            }
        }

        /// <summary>
        /// Indicates whether tabbed documents can be shown in the centre of the container.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// If set to false, normal dockable windows will be shown in the centre rather than tabbed documents. Some application vendors prefer
        ///             to use this design where the whole container appears to be filled with dockable windows.
        /// </para>
        /// 
        /// <para>
        /// This property will throw an exception if its value is changed while there are DockControls being shown in the centre of the container. It
        ///             should only be set before any DockControls are created, or alternatively after closing any existing ones.
        /// </para>
        /// 
        /// </remarks>
        [Description("Indicates whether tabbed documents can be shown in the centre of the container.")]
        [DefaultValue(true)]
        [Category("Behavior")]
        public bool EnableTabbedDocuments
        {
            get
            {
                return this.enableTabbedDocuments;
            }
            set
            {
                if (this.FindDockedContainer(DockStyle.Fill) != null)
                    throw new InvalidOperationException("This property can only be changed when there are no DockControls being shown in the centre of the container.");
                this.enableTabbedDocuments = value;
            }
        }

        /// <summary>
        /// Gets all tabbed documents in the current window layout that are docked in the centre of the container.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This method retrieves only tabbed documents that are docked in the centre of the container. If you have enabled floating or docking
        ///             to other sides of the form you will need to keep track of your documents programmatically as they cannot be distinguished from dockable
        ///             windows by the manager.
        /// </para>
        /// 
        /// <para>
        /// If there are no tabbed documents, this method returns an empty array.
        /// </para>
        /// 
        /// </remarks>
        [Browsable(false)]
        [Obsolete("Use the GetDockControls method passing DockSituation.Document instead.")]
        public DockControl[] Documents
        {
            get
            {
                return this.GetDockControls(DockSituation.Document);
            }
        }

        /// <summary>
        /// Indicates whether the user-configured window layout is automatically persisted.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// When set to true, the SaveSettings and LoadSettings methods are automatically called at the correct points, serializing layout into the default
        ///             windows forms settings repository. This feature is only active when a debugger is not attached to the application.
        /// </para>
        /// 
        /// </remarks>
        [DefaultValue(false)]
        [Description("Indicates whether the user-configured window layout is automatically persisted.")]
        [Category("Behavior")]
        public bool AutoSaveLayout
        {
            get
            {
                return this.autoSaveLayout;
            }
            set
            {
                this.autoSaveLayout = value;
            }
        }

        /// <summary>
        /// Indicates whether the user will be able to use the keyboard to navigate between tabbed documents and dockable windows.
        /// 
        /// </summary>
        [Description("Indicates whether the user will be able to use the keyboard to navigate between tabbed documents and dockable windows.")]
        [DefaultValue(true)]
        [Category("Behavior")]
        public bool AllowKeyboardNavigation
        {
            get
            {
                return this.allowKeyboardNavigation;
            }
            set
            {
                this.allowKeyboardNavigation = value;
            }
        }

        /// <summary>
        /// Indicates whether the middle mouse button can be used to close windows by their tabs.
        /// 
        /// </summary>
        [Category("Behavior")]
        [Description("Indicates whether the middle mouse button can be used to close windows by their tabs.")]
        [DefaultValue(true)]
        public bool AllowMiddleButtonClosure
        {
            get
            {
                return this.allowMiddleButtonClosure;
            }
            set
            {
                this.allowMiddleButtonClosure = value;
            }
        }

        /// <summary>
        /// Indicates whether standard validation events are fired when the user changes tabs.
        /// 
        /// </summary>
        [Description("Indicates whether standard validation events are fired when the user changes tabs.")]
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool RaiseValidationEvents
        {
            get
            {
                return this.raiseValidationEvents;
            }
            set
            {
                this.raiseValidationEvents = value;
            }
        }

        /// <summary>
        /// Indicates whether window groups will respond when an OLE drag operation occurs over their tabs.
        /// 
        /// </summary>
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Indicates whether window groups will respond when an OLE drag operation occurs over their tabs.")]
        public bool SelectTabsOnDrag
        {
            get
            {
                return this.selectTabsOnDrag;
            }
            set
            {
                this.selectTabsOnDrag = value;
                foreach (Control control in this.dockContainers)
                    control.AllowDrop = value;
                foreach (Control control in this.autoHideBars)
                    control.AllowDrop = value;
            }
        }

        /// <summary>
        /// Indicates whether tabbed document layout will be serialized alongside dockable window layout.
        /// 
        /// </summary>
        [Description("Indicates whether tabbed document layout will be serialized alongside dockable window layout.")]
        [Category("Serialization")]
        [DefaultValue(false)]
        public bool SerializeTabbedDocuments
        {
            get
            {
                return this.serializeTabbedDocuments;
            }
            set
            {
                this.serializeTabbedDocuments = value;
            }
        }

        /// <summary>
        /// Indicates whether DockContainers can be resized by the user.
        /// 
        /// </summary>
        [DefaultValue(true)]
        [Description("Indicates whether DockContainers can be resized by the user.")]
        [Category("Behavior")]
        public bool AllowDockContainerResize
        {
            get
            {
                return this.allowDockContainerResize;
            }
            set
            {
                this.allowDockContainerResize = value;
                DockContainer[] dockContainerList = this.GetOrderedDockedDockContainerList();
                foreach (DockContainer container in dockContainerList)
                {
                    container.CalculateAllMetricsAndLayout();
                }
            }
        }

        /// <summary>
        /// The control that will act as a host for all docked windows. You should rarely, if ever, need to change this property.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// SandDock uses one central host for its docked windows. In rare circumstances you may want to change this container from the default
        ///             after adding SandDock - for example you may want the SandDock system kept within a panel on your form rather than simply in the form itself.
        /// </para>
        /// 
        /// </remarks>
        [Description("The control that will act as a container for all docked windows. You should rarely, if ever, need to change this property.")]
        [Category("Advanced")]
        public Control DockSystemContainer
        {
            get
            {
                return this.dockSystemContainer;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                if (value is DockContainer)
                    throw new ArgumentException("A DockContainer cannot act as a host for a SandDock layout.");
                if (value == this.dockSystemContainer)
                    return;
                ArrayList arrayList = new ArrayList();
                foreach (DockContainer dockContainer in this.dockContainers)
                {
                    if (dockContainer.Parent != null && dockContainer.Parent != value)
                        arrayList.Add(dockContainer);
                }
                while (this.dockSystemContainer != null)
                {
                    this.dockSystemContainer.Resize -= new EventHandler(this.OnDockSystemContainerResize);
                    if (int.MinValue != 0)
                        break;
                }
                this.dockSystemContainer = value;
                if (this.dockSystemContainer != null)
                    this.dockSystemContainer.Resize += new EventHandler(this.OnDockSystemContainerResize);
                value.Controls.AddRange((Control[])arrayList.ToArray(typeof(Control)));
            }
        }

        /// <summary>
        /// Indicates the type of visual artifacts drawn to the screen to indicate size and position while docking.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// While any kind of moving, docking or resizing operation is in progress artifacts are drawn to the screen to show the potential impact of
        ///             committing the layout change. SandDock supports more than one style of artifact, and this property controls which is active.
        /// </para>
        /// 
        /// <para>
        /// The default is TranslucentFill, which masks the area with a translucent selection colour. This option is only available on Windows 2000 and
        ///             later operating systems. If running on a previous operating system, SandDock will revert to the RubberBand drawing style.
        /// </para>
        /// 
        /// </remarks>
        [DefaultValue(typeof(DockingHints), "TranslucentFill")]
        [Description("Indicates the type of visual artifacts drawn to the screen to indicate size and position while docking.")]
        [Category("Appearance")]
        public DockingHints DockingHints
        {
            get
            {
                return this.dockingHints;
            }
            set
            {
                this.dockingHints = value;
            }
        }

        /// <summary>
        /// Indicates the minimum size of a docked strip of toolwindows.
        /// 
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(30)]
        [Description("Indicates the minimum size of a docked strip of toolwindows.")]
        public int MinimumDockContainerSize
        {
            get
            {
                return this.xdca928fc295dbb2a;
            }
            set
            {
                this.xdca928fc295dbb2a = value;
            }
        }

        /// <summary>
        /// Indicates the maximum size of a docked strip of toolwindows.
        /// 
        /// </summary>
        [DefaultValue(500)]
        [Description("Indicates the maximum size of a docked strip of toolwindows.")]
        [Category("Behavior")]
        public int MaximumDockContainerSize
        {
            get
            {
                return this.maximumDockContainerSize;
            }
            set
            {
                this.maximumDockContainerSize = value;
            }
        }

        /// <summary>
        /// Indicates the method of user interaction during a docking operation.
        /// 
        /// </summary>
        [DefaultValue(typeof(DockingManager), "Whidbey")]
        [Description("Indicates the method of user interaction during a docking operation.")]
        [Category("Behavior")]
        public DockingManager DockingManager
        {
            get
            {
                return this.dockingManager;
            }
            set
            {
                this.dockingManager = value;
            }
        }

        /// <summary>
        /// The form that owns the SandDock hierarchy this manager is responsible for.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This property must be set to ensure correct behaviour of the layout system as SandDock depends on certain events raised by the form. You
        ///             can only set this property once.
        /// </para>
        /// 
        /// </remarks>
        [Browsable(false)]
        public Form OwnerForm
        {
            get
            {
                return this.ownerForm;
            }
            set
            {

                if (this.ownerForm != null)
                {
                    if (this.ownerForm == value)
                        return;
                
                    this.ownerForm.Activated -= new EventHandler(this.OnOwnerFormActivated);
                    this.ownerForm.Deactivate -= new EventHandler(this.OnOwnerFormDeactivated);
                    this.ownerForm.Load -= new EventHandler(this.OnOwnerFormLoad);
                    this.ownerForm.Closing -= new CancelEventHandler(this.OnOwnerFormClosing);
                    this.ownerForm = value;
                    this.ownerForm.Activated += new EventHandler(this.OnOwnerFormActivated);
                    this.ownerForm.Deactivate += new EventHandler(this.OnOwnerFormDeactivated);
                    this.ownerForm.Load += new EventHandler(this.OnOwnerFormLoad);
                    this.ownerForm.Closing += new CancelEventHandler(this.OnOwnerFormClosing);
                    return;
                }
                else
                {
                    this.ownerForm = value;

                    if (this.ownerForm == null)
                    {
                        return;
                    }
                    this.ownerForm.Activated += new EventHandler(this.OnOwnerFormActivated);
                    this.ownerForm.Deactivate += new EventHandler(this.OnOwnerFormDeactivated);
                    this.ownerForm.Load += new EventHandler(this.OnOwnerFormLoad);
                    this.ownerForm.Closing += new CancelEventHandler(this.OnOwnerFormClosing);
                    return;

                }

//                label_4:
//    
//                this.ownerForm = value;
//  
//                if (this.ownerForm == null)
//                {
//                    return;
//                }
//                this.ownerForm.Activated += new EventHandler(this.OnOwnerFormActivated);
//                this.ownerForm.Deactivate += new EventHandler(this.OnOwnerFormDeactivated);
//                this.ownerForm.Load += new EventHandler(this.OnOwnerFormLoad);
//                this.ownerForm.Closing += new CancelEventHandler(this.OnOwnerFormClosing);
//                return;
//                label_6:
//                this.ownerForm.Activated -= new EventHandler(this.OnOwnerFormActivated);
//                this.ownerForm.Deactivate -= new EventHandler(this.OnOwnerFormDeactivated);
//                this.ownerForm.Load -= new EventHandler(this.OnOwnerFormLoad);
//                this.ownerForm.Closing -= new CancelEventHandler(this.OnOwnerFormClosing);
//                goto label_4;
//                label_10:
//                if (this.ownerForm == null)
//                    goto label_4;
//                else
//                    goto label_6;
            }
        }

        /// <summary>
        /// The renderer used to calculate object metrics and draw contents.
        /// 
        /// </summary>
        [Description("The renderer used to calculate object metrics and draw contents.")]
        [Category("Appearance")]
        public RendererBase Renderer
        {
            get
            {
                return this.renderer;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
         
                if (this.renderer != null)
                {
                    this.renderer.MetricsChanged -= new EventHandler(this.OnRendererMetricsChanged);
                    this.renderer.Dispose();
                }
 
                this.renderer = value;
                this.renderer.MetricsChanged += new EventHandler(this.OnRendererMetricsChanged);
                this.PropagateNewRenderer();
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                base.Site = value;

                label_8:
                if (value == null)
                    return;
                label_17:
                IDesignerHost designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
                if (designerHost != null)
                    goto label_12;
                label_5:
                if (designerHost == null)
                    return;
                if (1 != 0)
                {
                    if (!(designerHost.RootComponent is Control) && 3 != 0)
                        return;
                    if (this.DockSystemContainer != null)
                    {
                        if (2 == 0)
                            return;
                        else
                            return;
                    }
                }
                this.DockSystemContainer = this.FindDockSystemContainer(designerHost, (Control)designerHost.RootComponent);
                if (0 == 0)
                    return;
                else
                    goto label_8;
                label_12:
                if (!(designerHost.RootComponent is Form))
                {
                    if (0 == 0)
                        goto label_5;
                }
                else
                {
                    this.ownerForm = (Form)designerHost.RootComponent;
                    goto label_5;
                }
            }
        }

        /// <summary>
        /// Raised when the user starts dragging a control or layout system.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// This event can be used to present the user (via a statusbar or similar) with some helpful text describing how to manipulate controls in a redocking
        ///             operation.
        /// 
        /// </remarks>
        public event EventHandler DockingStarted;
        /// <summary>
        /// Raised when a docking or dragging operation has been completed.
        /// 
        /// </summary>
        public event EventHandler DockingFinished;
        /// <summary>
        /// Raised when the context menu for a DockControl should be shown.
        /// 
        /// </summary>
        public event ShowControlContextMenuEventHandler ShowControlContextMenu;
        /// <summary>
        /// Raised when a new dockable window receives the input focus.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This event should be used instead of the standard Enter or GotFocus events as it caters for floating windows as well as docked.
        /// </para>
        /// 
        /// </remarks>
        public event DockControlEventHandler DockControlActivated;
        /// <summary>
        /// Raised when a new DockControl is added to the layout.
        /// 
        /// </summary>
        public event DockControlEventHandler DockControlAdded;
        /// <summary>
        /// Raised when a DockControl is removed from the layout.
        /// 
        /// </summary>
        public event DockControlEventHandler DockControlRemoved;
        /// <summary>
        /// Raised during layout deserialization when a DockControl cannot be found.
        /// 
        /// </summary>
        public event ResolveDockControlEventHandler ResolveDockControl;
        /// <summary>
        /// Raised when a new tabbed document becomes active.
        /// 
        /// </summary>
        public event EventHandler ActiveTabbedDocumentChanged;
        /// <summary>
        /// Raised when a <see cref="T:TD.SandDock.DockControl"/> is about to be closed.
        /// 
        /// </summary>
        public event DockControlClosingEventHandler DockControlClosing;
        /// <summary>
        /// Raised when a list of active files should be displayed for the user to choose from.
        /// 
        /// </summary>
        public event ActiveFilesListEventHandler ShowActiveFilesList;

        /// <summary>
        /// Initializes a new instance of the SandDockManager class.
        /// 
        /// </summary>
        public SandDockManager()
        {
            this.renderer = (RendererBase)new WhidbeyRenderer();
            this.dockContainers = new ArrayList();
            this.x8fb2a5bf0df0416f = new Hashtable();
            this.autoHideBars = new ArrayList();
        }

        /// <summary>
        /// Finds the window that most recently received input focus.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// The window, if found.
        /// </returns>
        public DockControl FindMostRecentlyUsedWindow()
        {
            return this.FindMostRecentlyUsedWindow(DockSituation.None);
        }

        /// <summary>
        /// Finds the window that most recently received input focus.
        /// 
        /// </summary>
        /// <param name="dockSituation">The dock situation in which to find the window.</param>
        /// <returns>
        /// The window, if found.
        /// </returns>
        public DockControl FindMostRecentlyUsedWindow(DockSituation dockSituation)
        {
            return this.FindMostRecentlyUsedWindow(dockSituation, (DockControl)null);
        }

        internal DockControl FindMostRecentlyUsedWindow(DockSituation dockSituation, DockControl notThisOne)
        {
            DateTime dateTime = DateTime.MinValue;
            DockControl dockControl1 = (DockControl)null;
            DockControl[] dockControls = this.GetDockControls();
            int index = 0;
            if (0 == 0)
                goto label_5;
            label_3:
            if ((uint)index < 0U)
            {
                if (2 == 0)
                    goto label_10;
                else
                    goto label_6;
            }
            label_4:
            ++index;
            label_5:
            if (index >= dockControls.Length)
                return dockControl1;
            DockControl dockControl2 = dockControls[index];
            goto label_10;
            label_6:
            do
            {
                if (!(dockControl2.MetaData.LastFocused >= dateTime))
                    goto label_12;
                else
                    goto label_7;
                label_1:
                if (dockControl2.DockSituation != dockSituation)
                    continue;
                else
                    goto label_15;
                label_7:
                if (dockSituation != DockSituation.None)
                {
                    if (15 != 0 && 4 != 0)
                        goto label_1;
                }
                else
                    goto label_15;
                label_9:
                if (0 != 0)
                    goto label_7;
                else
                    goto label_1;
                label_12:
                if ((uint)index - (uint)index < 0U)
                {
                    if ((index & 0) == 0)
                        goto label_9;
                    else
                        goto label_7;
                }
                else
                    break;
            }
            while (0 != 0);
            goto label_4;
            label_15:
            dateTime = dockControl2.MetaData.LastFocused;
            dockControl1 = dockControl2;
            if (4 != 0)
            {
                if (4 == 0)
                    goto label_4;
                else
                    goto label_4;
            }
            else
                goto label_5;
            label_10:
            if (dockControl2 == notThisOne)
                goto label_3;
            else
                goto label_6;
        }

        /// <summary>
        /// Raises the ShowActiveFilesList event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected internal virtual void OnShowActiveFilesList(ActiveFilesListEventArgs e)
        {
            if (this.ShowActiveFilesList == null)
                return;
            this.ShowActiveFilesList((object)this, e);
        }

        private void SetActiveTabbedDocument(DockControl value)
        {
            if (value == null)
                goto label_6;
            else
                goto label_16;
            label_3:
            if (0 == 0)
                return;
            else
                goto label_6;
            label_5:
            this.OnActiveTabbedDocumentChanged(EventArgs.Empty);
            if (0 == 0)
                goto label_3;
            label_6:
            if (value == this.activeTabbedDocument)
            {
                if (-2 != 0)
                {
                    if (0 == 0)
                    {
                        if (0 == 0)
                        {
                            if (-1 != 0)
                            {
                                if (int.MaxValue != 0)
                                {
                                    if (3 != 0)
                                        return;
                                    else
                                        goto label_16;
                                }
                                else
                                    goto label_12;
                            }
                            else
                                goto label_16;
                        }
                    }
                    else
                        goto label_8;
                }
                else
                    goto label_3;
            }
            else
                goto label_19;
            label_10:
            this.activeTabbedDocument.DockSituationChanged -= new EventHandler(this.OnActiveTabbedDocumentDockSituationChanged);
            this.activeTabbedDocument.UpdateLayoutSystem();
            goto label_11;
            label_19:
            if (this.activeTabbedDocument == null)
                goto label_11;
            else
                goto label_10;
            label_8:
            this.activeTabbedDocument.UpdateLayoutSystem();
            goto label_5;
            label_11:
            this.activeTabbedDocument = value;
            label_12:
            if (this.activeTabbedDocument != null)
            {
                if (0 == 0)
                {
                    this.activeTabbedDocument.DockSituationChanged += new EventHandler(this.OnActiveTabbedDocumentDockSituationChanged);
                    goto label_8;
                }
                else
                    goto label_3;
            }
            else
                goto label_5;
            label_16:
            if (value.DockSituation != DockSituation.Document)
            {
                if (4 != 0)
                    throw new ArgumentException("The specified window is not currently being displayed as a document, therefore it cannot be set as the active document.", "value");
                else
                    goto label_11;
            }
            else
                goto label_6;
        }

        private void OnActiveTabbedDocumentDockSituationChanged(object sender, EventArgs e)
        {
            if (((DockControl)sender).DockSituation == DockSituation.Document)
                return;
            this.SetActiveTabbedDocument(this.FindMostRecentlyUsedWindow(DockSituation.Document));
        }

        internal AutoHideBar GetAutoHideBar(DockStyle dock)
        {
            if (dock == DockStyle.Fill || dock == DockStyle.None)
                return (AutoHideBar)null;
            AutoHideBar x10ac79a4257c7f52_1;
            foreach (AutoHideBar x10ac79a4257c7f52_2 in this.autoHideBars)
            {
                if (x10ac79a4257c7f52_2.Dock == dock)
                {
                    do
                    {
                        x10ac79a4257c7f52_1 = x10ac79a4257c7f52_2;
                    }
                    while (0 != 0);
                    goto label_15;
                }
            }
            this.DockSystemContainer.SuspendLayout();
            try
            {
                AutoHideBar x10ac79a4257c7f52_2 = new AutoHideBar();
                x10ac79a4257c7f52_2.Manager = this;
                do
                {
                    x10ac79a4257c7f52_2.Dock = dock;
                    x10ac79a4257c7f52_2.Parent = this.DockSystemContainer;
                }
                while (0 != 0);
                this.DockSystemContainer.Controls.SetChildIndex((Control)x10ac79a4257c7f52_2, this.GetOutsideControlIndex(this.DockSystemContainer, dock));
                x10ac79a4257c7f52_1 = x10ac79a4257c7f52_2;
            }
            finally
            {
                this.DockSystemContainer.ResumeLayout();
            }
            label_15:
            return x10ac79a4257c7f52_1;
        }

        /// <summary>
        /// Creates a new DockContainer suitable for display at the specified position.
        /// 
        /// </summary>
        /// <param name="dockLocation">The position in a container at which the DockContainer will reside.</param>
        /// <returns>
        /// A new DockContainer.
        /// </returns>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// Developers should override this method when they wish their own, derived DockContainer to be used instead of the default class. The default implementation of this method creates an instance of
        ///             DocumentContainer if the centre of the container is specified and tabbed documents are enabled, otherwise it creates an instance of DockContainer.
        /// </para>
        /// 
        /// </remarks>
        protected virtual DockContainer CreateNewDockContainerCore(ContainerDockLocation dockLocation)
        {
            if (dockLocation == ContainerDockLocation.Center && this.EnableTabbedDocuments)
                return (DockContainer)new DocumentContainer();
            else
                return new DockContainer();
        }

        /// <summary>
        /// Creates a new DockContainer in the registered DockSystemContainer.
        /// 
        /// </summary>
        /// <param name="dockLocation">The position in the container at which the DockContainer will reside.</param><param name="edge">The edge at which the DockContainer will reside.</param><param name="contentSize">The size of the content within the dock container.</param>
        /// <returns>
        /// The newly created DockContainer.
        /// </returns>
        public DockContainer CreateNewDockContainer(ContainerDockLocation dockLocation, ContainerDockEdge edge, int contentSize)
        {
            this.EnsureDockSystemContainer();
            this.DockSystemContainer.SuspendLayout();
            DockContainer dockContainer = null;
            try
            {
                DockContainer dockContainerCore = this.CreateNewDockContainerCore(dockLocation);
                label_23:
                int newIndex;
                DockStyle dockStyle;
                do
                {
                    dockContainerCore.Manager = this;
                    dockStyle = LayoutUtilities.xf8330a3964a419ba(dockLocation);
                    dockContainerCore.Dock = dockStyle;
                    dockContainerCore.ContentSize = contentSize;
                    IntPtr handle = dockContainerCore.Handle;
                    if (dockLocation == ContainerDockLocation.Center)
                        goto label_22;
                }
                while (false);
                goto label_20;
                label_18:
                this.DockSystemContainer.Controls.Add((Control)dockContainerCore);
                do
                {
                    this.DockSystemContainer.Controls.SetChildIndex((Control)dockContainerCore, newIndex);
                    if (0 == 0)
                    {
                        if ((uint)newIndex - (uint)contentSize > uint.MaxValue)
                            goto label_23;
                    }
                    else
                        goto label_18;
                }
                while ((contentSize | -2) == 0);
                IEnumerator enumerator = this.DockSystemContainer.Controls.GetEnumerator();
                try
                {
                    label_8:
                    while (enumerator.MoveNext())
                    {
                        x87cf4de36131799d x87cf4de36131799d = (Control)enumerator.Current as x87cf4de36131799d;
                        while (x87cf4de36131799d == null)
                        {
                            if ((uint)newIndex <= uint.MaxValue)
                            {
                                if ((newIndex | 15) != 0)
                                    goto label_8;
                            }
                            else
                                goto label_16;
                        }
                        x87cf4de36131799d.BringToFront();
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                        disposable.Dispose();
                }
                label_16:
                dockContainer = dockContainerCore;
                goto label_25;
                label_20:
                if (edge != ContainerDockEdge.Inside)
                {
                    newIndex = this.GetOutsideControlIndex(this.DockSystemContainer, dockStyle);
                    goto label_18;
                }
                else
                {
                    newIndex = this.GetInsideControlIndex(this.DockSystemContainer);
                    if ((uint)contentSize + (uint)newIndex >= 0U)
                        goto label_18;
                    else
                        goto label_25;
                }
                label_22:
                newIndex = 0;
                goto label_18;
            }
            finally
            {
                this.DockSystemContainer.ResumeLayout();
            }
            label_25:
            return dockContainer;
        }

        private int GetInsideControlIndex(Control container)
        {
            int num1 = int.MaxValue;
            int num2;
            if (false)
                goto label_3;
            else
                goto label_8;
            label_1:
            int index = 0;
            --index;
            label_2:
            if (index < 0)
            {
                if ((uint)num1 + (uint)num1 >= 0U)
                    return num1;
            }
            else
                goto label_9;
            label_6:
            Control control;
            while (false)
            {
                if (0 != 0 || 8 != 0)
                    goto label_3;
            }
            goto label_1;
            label_9:
            control = container.Controls[index];
            goto label_6;
            label_3:
            if ((control.Dock != DockStyle.None) && index < num1)
            {
                num1 = index;
                goto label_1;
            }
            else
                goto label_1;
            label_8:
            index = container.Controls.Count - 1;
            goto label_2;
        }

        internal DockContainer[] GetDockContainers(DockStyle dockStyle)
        {
            if (dockStyle == DockStyle.Fill)
            {
                int num;
                if (true)
                    goto label_14;
            }
            else
                goto label_10;
            label_2:
            int length = 0;
            DockContainer[] dockContainerArray1 = new DockContainer[length];
            DockContainer[] dockContainerArray2;
            Array.Copy((Array)dockContainerArray2, (Array)dockContainerArray1, length);
            return dockContainerArray1;
            label_10:
            if (this.DockSystemContainer == null)
                return new DockContainer[0];
            dockContainerArray2 = new DockContainer[this.DockSystemContainer.Controls.Count];
            if (0 != 0)
                ;
            int num1;
            if (true)
                goto label_13;
            label_4:
            int index = 0;
            --index;
            label_5:
            if (index >= 0 || (uint)index > uint.MaxValue)
            {
                DockContainer dockContainer = this.DockSystemContainer.Controls[index] as DockContainer;
                if (dockContainer != null)
                {
                    if ((uint)length + (uint)index <= uint.MaxValue)
                    {
                        while (dockContainer.Dock == dockStyle)
                        {
                            dockContainerArray2[length++] = dockContainer;
                            if (0 != 0)
                            {
                                if ((uint)index + (uint)index < 0U)
                                    goto label_2;
                            }
                            else
                                break;
                        }
                        goto label_4;
                    }
                    else
                        goto label_14;
                }
                else
                    goto label_4;
            }
            else
                goto label_2;
            label_13:
            length = 0;
            index = this.DockSystemContainer.Controls.Count - 1;
            goto label_5;
            label_14:
            throw new ArgumentException("dockStyle");
        }

        private int GetOutsideControlIndex(Control container, DockStyle dockStyle)
        {
            int num1 = container.Controls.Count;
//            if ((num1 & 0) != 0)
//            {
//                int num2;
//                if (true)
//                    goto label_12;
//                else
//                    goto label_10;
//            }
//            else
                
            goto label_18;
            label_3:
            int index = 0;
            if ((uint)index >= 0U)
                goto label_7;
            label_4:
            Control control;
            if (true)
            {
                if ((uint)num1 - (uint)index <= uint.MaxValue)
                    goto label_7;
                else
                    goto label_3;
            }
            label_5:
            if (control.Dock == dockStyle)
            {
                if (4 != 0)
                    goto label_19;
                else
                    goto label_10;
            }
            else
                goto label_3;
            label_7:
            --index;
            label_8:
            if (index < 0)
            {
                if ((index | 1) == 0)
                    goto label_7;
                else
                    goto label_19;
            }
            else
            {
                control = container.Controls[index];
                goto label_14;
            }
            label_10:
            if ((uint)index > uint.MaxValue)
                goto label_3;
            else
                goto label_7;
            label_12:
            num1 = index;
            if (0 == 0)
            {
                if (3 == 0)
                    goto label_5;
                else
                    goto label_4;
            }
            label_14:
            if (control.Dock == DockStyle.Fill)
                goto label_16;
            label_11:
            if (!(control is DockContainer))
                goto label_12;
            else
                goto label_4;
            label_16:
            if (control is MdiClient)
            {
                if (0 == 0)
                    goto label_11;
                else
                    goto label_12;
            }
            else
                goto label_19;
            label_18:
            index = container.Controls.Count - 1;
            goto label_8;
            label_19:
            return num1;
        }

        private void EnsureDockSystemContainer()
        {
            if (this.DockSystemContainer == null)
                throw new InvalidOperationException("This SandDockManager does not have its DockSystemContainer property set.");
        }

        /// <summary>
        /// Raises the ShowControlContextMenu event.
        /// 
        /// </summary>
        /// <param name="e">A ShowControlContextMenuEventArgs that contains the event data.</param>
        protected internal virtual void OnShowControlContextMenu(ShowControlContextMenuEventArgs e)
        {
            if (this.ShowControlContextMenu == null)
                return;
            this.ShowControlContextMenu((object)this, e);
        }

        internal void RegisterWindow(DockControl control)
        {
            this.x8fb2a5bf0df0416f[(object)control.Guid] = (object)control;
            this.OnDockControlAdded(new DockControlEventArgs(control));
        }

        internal void ReRegisterWindow(DockControl control, Guid oldGuid)
        {
            if (this.x8fb2a5bf0df0416f.Contains((object)oldGuid))
                this.x8fb2a5bf0df0416f.Remove((object)oldGuid);
            this.x8fb2a5bf0df0416f[(object)control.Guid] = (object)control;
        }

        internal void UnregisterWindow(DockControl control)
        {
            this.x8fb2a5bf0df0416f.Remove((object)control.Guid);
            this.OnDockControlRemoved(new DockControlEventArgs(control));
        }

        /// <summary>
        /// Raises the DockControlAdded event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected virtual void OnDockControlAdded(DockControlEventArgs e)
        {
            if (this.DockControlAdded == null)
                return;
            this.DockControlAdded((object)this, e);
        }

        /// <summary>
        /// Raises the DockControlRemoved event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected virtual void OnDockControlRemoved(DockControlEventArgs e)
        {
            if (this.DockControlRemoved == null)
                return;
            this.DockControlRemoved((object)this, e);
        }

        /// <summary>
        /// Raises the DockControlActivated event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected internal virtual void OnDockControlActivated(DockControlEventArgs e)
        {
            if (this.DockControlActivated != null)
                this.DockControlActivated((object)this, e);
            if (e.DockControl.DockSituation != DockSituation.Document)
                return;
            this.SetActiveTabbedDocument(e.DockControl);
            if (4 != 0)
                ;
        }

        private void EnsureHandles()
        {
        }

        /// <summary>
        /// Loads a layout of docked and floating windows from a string previously obtained from the GetLayout method.
        /// 
        /// </summary>
        public void SetLayout(string layout)
        {
            this.EnsureDockSystemContainer();
            int num1;
            ArrayList arrayList;
            int num2;
            FloatingDockContainer[] dockContainerList1;
            DockContainer[] dockContainerList2;
            XmlDocument xmlDocument;
            int num3;
            do
            {
                this.EnsureHandles();
                xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(layout);
                this.GetLayout();
                dockContainerList2 = this.GetOrderedDockedDockContainerList();
                dockContainerList1 = this.GetFloatingDockContainerList();
                num3 = 0;
                num2 = 0;
                arrayList = new ArrayList((ICollection)dockContainerList2);
                if ((uint)num3 <= uint.MaxValue)
                    goto label_82;
            }
            while (false);
            return;
            label_82:
            arrayList.AddRange((ICollection)dockContainerList1);
            DocumentContainer documentContainer = (DocumentContainer)null;
            if (this.SerializeTabbedDocuments)
                documentContainer = this.FindDockedContainer(DockStyle.Fill) as DocumentContainer;
            if (documentContainer != null)
                arrayList.Add((object)documentContainer);
            int index1;
            try
            {
                foreach (DockContainer dockContainer in arrayList)
                    dockContainer.x272ed7848e373c56();
                label_66:
                this.DockSystemContainer.SuspendLayout();
                IEnumerator enumerator = xmlDocument.GetElementsByTagName("Layout")[0].ChildNodes.GetEnumerator();
                int index2 = 0;
                int index3 = 0;
                try
                {
                    while (true)
                    {
                        DockContainer container2 = null;

                        if (enumerator.MoveNext())
                            goto label_59;
                        else
                            goto label_32;
                        label_29:
                        XmlNode xmlNode = null;
                        if (xmlNode.NodeType != XmlNodeType.Element)
                            continue;
                        label_30:
                        if (!(xmlNode.Name == "FloatingContainer"))
                            continue;
                        label_31:
                        FloatingDockContainer container1;
                        if (xmlNode.HasChildNodes)
                        {
                            do
                            {
                                container1 = (FloatingDockContainer)null;
                                if (num2 < dockContainerList1.Length)
                                {
                                    if ((uint)index3 >= 0U)
                                    {
                                        if ((uint)num3 <= uint.MaxValue)
                                            goto label_34;
                                    }
                                    else
                                        goto label_48;
                                }
                                else
                                    goto label_36;
                            }
                            while ((uint)index3 - (uint)num3 > uint.MaxValue);
                            goto label_29;
                        }
                        else
                            continue;
                        label_32:
                        if (0 != 0)
                        {
                            if ((uint)index2 + (uint)index3 >= 0U)
                                goto label_31;
                        }
                        else if (-1 != 0)
                        {
                            if (true)
                                break;
                            else
                                goto label_47;
                        }
                        else
                            goto label_30;
                        label_34:
                        if ((int)byte.MaxValue != 0)
                            container1 = dockContainerList1[num2++];
                        else
                            goto label_57;
                        label_36:
                        this.ReadFloatingContainerProperties(xmlNode, container1);
                        continue;
                        label_42:
                        if ((index3 & 0) == 0)
                            goto label_29;
                        label_43:
                        if (!(xmlNode.Name == "Container"))
                            goto label_46;
                        label_44:
                        if (xmlNode.HasChildNodes)
                            goto label_55;
                        else
                            goto label_29;
                        label_46:
                        if (xmlNode.Name == "DocumentContainer")
                            goto label_44;
                        else
                            goto label_42;
                        label_47:
                        container2 = null;
                        if (documentContainer != null)
                        {
                            container2 = (DockContainer)documentContainer;
                            documentContainer = (DocumentContainer)null;
                            goto label_49;
                        }
                        else
                            goto label_49;
                        label_48:
                        if (xmlNode.Name == "Container")
                            goto label_50;
                        label_49:
                        this.ReadContainerProperties(xmlNode, container2);
                        if ((uint)num3 - (uint)index3 >= 0U)
                        {
                            continue;
                        }
                        else
                            goto label_42;
                        label_50:
                        if (num3 < dockContainerList2.Length)
                        {
 
                            container2 = dockContainerList2[num3++];
                            goto label_49;

                        }
                        else
                            goto label_49;
                        label_55:
                        container2 = (DockContainer)null;
                        if (!(xmlNode.Name == "DocumentContainer"))
                        {
                            goto label_48;

                        }
                        else
                            goto label_47;
                        label_57:
                        if (xmlNode.Name == "Window")
                        {
                            this.ReadWindowProperties(xmlNode);
                            continue;
                        }
                        label_58:
                        if (xmlNode.NodeType == XmlNodeType.Element)
                        {
                            if ((uint)num3 >= 0U)
                                goto label_43;
                            else
                                goto label_46;
                        }
                        else
                            goto label_29;
                        label_59:
                        xmlNode = (XmlNode)enumerator.Current;
                        if (xmlNode.NodeType == XmlNodeType.Element)
                            goto label_57;
                        else
                            goto label_58;
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                        disposable.Dispose();
                }
                index1 = num3;
                do
                {
                    if (index1 >= dockContainerList2.Length)
                    {
                        if ((uint)index1 >= 0U)
                        {
                            label_23:
                            index3 = num2;
                            while (index3 < dockContainerList1.Length)
                            {
                                dockContainerList1[index3].Dispose();
                                if ((num2 | int.MaxValue) != 0)
                                {
                                    if ((uint)index1 >= 0U)
                                    {
                                        if (true)
                                            ++index3;
                                        else
                                            goto label_65;
                                    }
                                }
                                else
                                    goto label_23;
                            }
                            goto label_14;
                        }
                        else
                            goto label_10;
                    }
                    label_65:
                    dockContainerList2[index1].Dispose();
                    ++index1;
                }
                while ((uint)index3 + (uint)num2 <= uint.MaxValue);
                goto label_84;
                label_10:
                ++index2;
                label_11:
                DockControl[] dockControls = { };
                if (index2 >= 0) //if (index2 >= dockControls.Length)
                    return;
                DockControl dockControl = dockControls[index2];
                if ((uint)num2 - (uint)index3 <= uint.MaxValue)
                {
                    if (!dockControl.IsInContainer && dockControl.CloseAction == DockControlCloseAction.Dispose)
                    {
                        dockControl.Dispose();
                        goto label_10;
                    }
                    else
                        goto label_10;
                }
                else
                    goto label_15;
                label_14:
                if (documentContainer != null)
                    documentContainer.Dispose();
                label_15:
                dockControls = this.GetDockControls();
                index2 = 0;
                if ((uint)num2 + (uint)num2 < 0U)
                    goto label_66;
                else
                    goto label_11;
                label_84:
                ;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("The layout information provided could not be interpreted.", ex);
            }
            finally
            {
                foreach (DockContainer dockContainer in arrayList)
                {
                    if (dockContainer != null)
                    {
                        if (!dockContainer.IsDisposed)
                            dockContainer.xfe00f14c7d278916();
                        else if ((num2 | 2) != 0)
                        {
                            if (false)
                                ;
                        }
                        else
                            break;
                    }
                }
                this.DockSystemContainer.ResumeLayout();
            }
        }

        private bool ConvertStringToBool(string str)
        {
            return !(str == "0");
        }

        private System.Drawing.Point ConvertStringToPoint(string str)
        {
            return (System.Drawing.Point)TypeDescriptor.GetConverter(typeof(System.Drawing.Point)).ConvertFrom((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)str);
        }

        private System.Drawing.Size ConvertStringToSize(string str)
        {
            return (System.Drawing.Size)TypeDescriptor.GetConverter(typeof(System.Drawing.Size)).ConvertFrom((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)str);
        }

        internal static SizeF ConvertStringToSizeF(string str)
        {
            return (SizeF)TypeDescriptor.GetConverter(typeof(SizeF)).ConvertFrom((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)str);
        }

        private Rectangle ConvertStringToRectangle(string str)
        {
            return (Rectangle)TypeDescriptor.GetConverter(typeof(Rectangle)).ConvertFrom((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)str);
        }

        private void ReadWindowProperties(XmlNode node)
        {
            x245a5abec1c73d3a.x0a680eda7ec8bd81(this, node);
        }

        private void ReadFloatingContainerProperties(XmlNode node, FloatingDockContainer container)
        {
            Rectangle xda73fcb97c77d998 = this.ConvertStringToRectangle(node.Attributes["Bounds"].Value);
            Guid guid = Guid.NewGuid();
            if (node.Attributes["Guid"] != null)
            {
                guid = new Guid(node.Attributes["Guid"].Value);
                if (-1 == 0)
                    ;
            }
            if (container == null)
                container = new FloatingDockContainer(this, guid);
            IEnumerator enumerator = node.ChildNodes.GetEnumerator();
            try
            {
                label_5:
                while (true)
                {
                    if (!enumerator.MoveNext())
                    {
                        if (0 == 0)
                            goto label_15;
                    }
                    XmlNode splitNode = (XmlNode)enumerator.Current;
                    SplitLayoutSystem splitLayoutSystem;
                    do
                    {
                        if (splitNode.NodeType == XmlNodeType.Element && splitNode.Name == "SplitLayoutSystem")
                        {
                            splitLayoutSystem = this.ReadSplitLayoutSystem(splitNode, (DockContainer)container);
                            if (splitLayoutSystem == null)
                            {
                                if (0 == 0)
                                    container.Dispose();
                            }
                            else
                                goto label_7;
                        }
                        else
                            goto label_5;
                    }
                    while (0 != 0);
                    break;
                    label_7:
                    container.LayoutSystem = splitLayoutSystem;
                }
                return;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            label_15:
            container.x159713d3b60fae0c(xda73fcb97c77d998, true, false);
        }

        private void ReadContainerProperties(XmlNode containerNode, DockContainer container)
        {
            DockStyle xca9af438b5818619 = (DockStyle)int.Parse(containerNode.Attributes["Dock"].Value);
            int contentSize = 0;
            while (containerNode.Attributes["ContentSize"] != null)
            {
                contentSize = int.Parse(containerNode.Attributes["ContentSize"].Value);
                if ((uint)contentSize - (uint)contentSize >= 0U)
                {
                    if ((contentSize | 1) == 0)
                        ;
                    if ((contentSize & 0) == 0)
                        break;
                }
                else
                    goto label_1;
            }
            goto label_24;
            label_1:
            container.Dock = xca9af438b5818619;
            container.ContentSize = contentSize;
            IEnumerator enumerator = containerNode.ChildNodes.GetEnumerator();
            try
            {
                label_4:
                while (enumerator.MoveNext())
                {
                    label_15:
                    XmlNode splitNode = (XmlNode)enumerator.Current;
                    label_3:
                    do
                    {
                        if (splitNode.NodeType == XmlNodeType.Element && splitNode.Name == "SplitLayoutSystem")
                        {
                            SplitLayoutSystem splitLayoutSystem = this.ReadSplitLayoutSystem(splitNode, container);
                            label_11:
                            if (splitLayoutSystem == null)
                                goto label_13;
                            else
                                goto label_12;
                            label_8:
                            while (int.MinValue == 0)
                            {
                                if (0 == 0)
                                {
                                    if (3 != 0)
                                    {
                                        if (15 == 0)
                                            return;
                                        if ((uint)contentSize + (uint)contentSize <= uint.MaxValue)
                                            break;
                                    }
                                    else
                                        goto label_3;
                                }
                                else
                                    goto label_11;
                            }
                            container.LayoutSystem = splitLayoutSystem;
                            return;
                            label_12:
                            if ((uint)contentSize >= 0U)
                            {
                                if ((uint)contentSize + (uint)contentSize > uint.MaxValue)
                                    continue;
                                else
                                    goto label_8;
                            }
                            else
                                goto label_15;
                            label_13:
                            container.Dispose();
                            if ((uint)contentSize - (uint)contentSize < 0U)
                                goto label_8;
                            else
                                goto label_29;
                        }
                        else
                            goto label_4;
                    }
                    while ((uint)contentSize - (uint)contentSize <= uint.MaxValue);
                    goto label_19;
                    label_29:
                    break;
                    label_19:
                    break;
                }
                return;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            label_24:
            if (container == null)
            {
                container = this.CreateNewDockContainer(LayoutUtilities.x3650f3b579b2b4d2(xca9af438b5818619), ContainerDockEdge.Outside, contentSize);
                goto label_1;
            }
            else
                goto label_1;
        }

        private SplitLayoutSystem ReadSplitLayoutSystem(XmlNode splitNode, DockContainer container)
        {
            SizeF workingSize = SandDockManager.ConvertStringToSizeF(splitNode.Attributes["WorkingSize"].Value);
            workingSize.Width = Math.Max(workingSize.Width, 1f);
            workingSize.Height = Math.Max(workingSize.Height, 1f);
            Orientation splitMode = (Orientation)int.Parse(splitNode.Attributes["SplitMode"].Value);
            ArrayList arrayList = new ArrayList();
            IEnumerator enumerator = splitNode.ChildNodes.GetEnumerator();
            try
            {
                label_4:
                while (enumerator.MoveNext())
                {
                    XmlNode xmlNode;
                    SplitLayoutSystem splitLayoutSystem;
                    do
                    {
                        xmlNode = (XmlNode)enumerator.Current;
                        if (0 != 0 || xmlNode.NodeType == XmlNodeType.Element)
                            goto label_16;
                        else
                            goto label_9;
                        label_7:
                        if (xmlNode.NodeType != XmlNodeType.Element)
                        {
                            if (0 != 0 || -2 == 0)
                                continue;
                            else
                                goto label_4;
                        }
                        else
                            break;
                        label_9:
                        if (4 == 0)
                            ;
                        if (0 == 0)
                            goto label_7;
                        else
                            goto label_11;
                        label_16:
                        if (xmlNode.Name == "SplitLayoutSystem")
                        {
                            splitLayoutSystem = this.ReadSplitLayoutSystem(xmlNode, container);
                            if ((int)byte.MaxValue == 0)
                            {
                                if (-1 != 0)
                                    goto label_14;
                                else
                                    goto label_9;
                            }
                            else
                                goto label_6;
                        }
                        else
                            goto label_7;
                    }
                    while (0 != 0);
                    label_3:
                    if (xmlNode.Name == "ControlLayoutSystem")
                        goto label_12;
                    else
                        continue;
                    label_6:
                    if (splitLayoutSystem != null)
                        goto label_14;
                    else
                        continue;
                    label_11:
                    if (3 != 0)
                        goto label_3;
                    label_12:
                    ControlLayoutSystem controlLayoutSystem = this.ReadControlLayoutSystem(xmlNode, container);
                    if (controlLayoutSystem != null && 0 == 0)
                    {
                        arrayList.Add((object)controlLayoutSystem);
                        continue;
                    }
                    else
                        continue;
                    label_14:
                    arrayList.Add((object)splitLayoutSystem);
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            if (arrayList.Count != 0)
                return new SplitLayoutSystem(workingSize, splitMode, (LayoutSystemBase[])arrayList.ToArray(typeof(LayoutSystemBase)));
            else
                return (SplitLayoutSystem)null;
        }

        private ControlLayoutSystem ReadControlLayoutSystem(XmlNode controlNode, DockContainer container)
        {
            Guid guid1 = Guid.Empty;
            bool flag1;
            if (true)
                goto label_44;
            else
                goto label_38;
            label_2:
            ControlLayoutSystem newLayoutSystem;
            return newLayoutSystem;
            label_4:
            bool flag2;
            if (true)
            {
                if (-1 != 0)
                {
                    newLayoutSystem.Guid = guid1;
                    goto label_2;
                }
                else
                    goto label_47;
            }
            else
                goto label_40;
            label_38:
            if (controlNode.Attributes["SelectedControl"] != null)
                goto label_46;
            label_39:
            if (controlNode.Attributes["Guid"] == null)
                goto label_41;
            else
                goto label_40;
            label_46:
            Guid guid2 = new Guid(controlNode.Attributes["SelectedControl"].Value);
            if (false)
                ;
            DockControl dockControl = this.FindControl(guid2);
            goto label_39;
            label_40:
            guid1 = new Guid(controlNode.Attributes["Guid"].Value);
            label_41:
            ArrayList arrayList = new ArrayList();
            IEnumerator enumerator1 = controlNode.ChildNodes.GetEnumerator();
            try
            {
                label_12:
                if (!enumerator1.MoveNext())
                {
                    if (((flag2 ? 1 : 0) & 0) != 0)
                    {
                        if (15 == 0)
                            goto label_12;
                    }
                    else
                        goto label_3;
                }
                XmlNode xmlNode1 = (XmlNode)enumerator1.Current;
                if (xmlNode1.NodeType == XmlNodeType.Element && xmlNode1.Name == "Controls")
                {
                    IEnumerator enumerator2 = xmlNode1.ChildNodes.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            label_24:
                            XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
                            label_17:
                            if (xmlNode2.NodeType == XmlNodeType.Element)
                                goto label_19;
                            label_15:
                            if (-1 == 0)
                            {
                                if (1 == 0)
                                    goto label_17;
                            }
                            else
                                continue;
                            label_19:
                            if (!(xmlNode2.Name == "Control"))
                            {
                                if (-1 == 0)
                                    break;
                            }
                            else
                            {
                                DockControl control = this.FindControl(new Guid(xmlNode2.Attributes["Guid"].Value));
                                if (control != null)
                                {
                                    if (15 != 0)
                                    {
                                        if (1 != 0)
                                            arrayList.Add((object)control);
                                        else
                                            goto label_15;
                                    }
                                    else
                                        goto label_24;
                                }
                            }
                        }
                        goto label_12;
                    }
                    finally
                    {
                        IDisposable disposable = enumerator2 as IDisposable;
                        if (disposable != null)
                            disposable.Dispose();
                    }
                }
                else
                    goto label_12;
            }
            finally
            {
                IDisposable disposable = enumerator1 as IDisposable;
                if (true)
                    goto label_35;
                label_33:
                if (true)
                    goto label_37;
                label_35:
                if (disposable != null)
                {
                    disposable.Dispose();
                    goto label_33;
                }
                else if (false)
                    goto label_33;
                label_37:
                ;
            }
            label_3:
            SizeF size;
            if (arrayList.Count != 0)
            {
                do
                {
                    newLayoutSystem = container.CreateNewLayoutSystem(size);
                    newLayoutSystem.Controls.AddRange((DockControl[])arrayList.ToArray(typeof(DockControl)));
                    while (dockControl != null)
                    {
                        newLayoutSystem.SelectedControl = dockControl;
                        if (0 == 0)
                            break;
                    }
                    newLayoutSystem.Collapsed = flag2;
                    if (true)
                    {
                        if (!(guid1 != Guid.Empty))
                            goto label_2;
                    }
                    else
                        break;
                }
                while (1 == 0);
                goto label_4;
            }
            else
                goto label_47;
            label_44:
            size = SandDockManager.ConvertStringToSizeF(controlNode.Attributes["WorkingSize"].Value);
            if (true)
            {
                flag2 = this.ConvertStringToBool(controlNode.Attributes["Collapsed"].Value);
                dockControl = (DockControl)null;
                goto label_38;
            }
            else
                goto label_4;
            label_47:
            return (ControlLayoutSystem)null;
        }

        /// <summary>
        /// Locates a DockControl by its Guid property.
        /// 
        /// </summary>
        /// <param name="guid">The Guid of the control to locate.</param>
        /// <returns>
        /// The corresponding control, if one was found. If no control is found a null reference is returned.
        /// </returns>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// If no control is found this method raises the ResolveDockControl event to ask the host application to locate the DockControl.
        /// </para>
        /// 
        /// </remarks>
        public DockControl FindControl(Guid guid)
        {
            DockControl dockControl = (DockControl)this.x8fb2a5bf0df0416f[(object)guid];
            while ((int)byte.MaxValue != 0 && dockControl == null)
            {
                ResolveDockControlEventArgs e = new ResolveDockControlEventArgs(guid);
                this.OnResolveDockControl(e);
                if (0 != 0 || e.DockControl != null)
                {
                    e.DockControl.Manager = this;
                    if (0 == 0)
                    {
                        if (0 == 0)
                            return e.DockControl;
                    }
                    else
                        continue;
                }
                return (DockControl)null;
            }
            return dockControl;
        }

        private DockContainer[] GetOrderedDockedDockContainerList()
        {
            if (this.DockSystemContainer == null)
                return new DockContainer[0];
            ArrayList arrayList = new ArrayList();
            int num;
            if (false)
                goto label_6;
            else
                goto label_9;
            label_3:
            Control control;
            int index;
            if (index < this.DockSystemContainer.Controls.Count)
                control = this.DockSystemContainer.Controls[index];
            else
                goto label_10;
            label_6:
            if (this.dockContainers.Contains((object)control) && !(control is DocumentContainer))
                arrayList.Add((object)control);
            ++index;
            goto label_3;
            label_9:
            if (0 == 0)
            {
                index = 0;
                goto label_3;
            }
            label_10:
            return (DockContainer[])arrayList.ToArray(typeof(DockContainer));
        }

        private FloatingDockContainer[] GetFloatingDockContainerList()
        {
            ArrayList arrayList = new ArrayList();
            IEnumerator enumerator = this.dockContainers.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    DockContainer dockContainer = (DockContainer)enumerator.Current;
                    if (dockContainer.IsFloating)
                        arrayList.Add((object)dockContainer);
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                while (disposable != null)
                {
                    do
                    {
                        disposable.Dispose();
                    }
                    while (1 == 0);
                    if (0 == 0)
                        break;
                }
            }
            return (FloatingDockContainer[])arrayList.ToArray(typeof(FloatingDockContainer));
        }

        private string ConvertBoolToString(bool b)
        {
            return !b ? "0" : "1";
        }

        private string ConvertSizeToString(System.Drawing.Size size)
        {
            return (string)TypeDescriptor.GetConverter(typeof(System.Drawing.Size)).ConvertTo((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)size, typeof(string));
        }

        internal static string ConvertSizeFToString(SizeF size)
        {
            return (string)TypeDescriptor.GetConverter(typeof(SizeF)).ConvertTo((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)size, typeof(string));
        }

        private string ConvertPointToString(System.Drawing.Point point)
        {
            return (string)TypeDescriptor.GetConverter(typeof(System.Drawing.Point)).ConvertTo((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)point, typeof(string));
        }

        private string ConvertRectangleToString(Rectangle rectangle)
        {
            return (string)TypeDescriptor.GetConverter(typeof(Rectangle)).ConvertTo((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, (object)rectangle, typeof(string));
        }

        private string GetSettingsKey()
        {
            if (this.OwnerForm != null)
                return this.OwnerForm.GetType().FullName;
            else
                return "default";
        }

        /// <summary>
        /// Saves the layout into the default windows forms settings repository.
        /// 
        /// </summary>
        public void SaveLayout()
        {
            new LayoutSettings(this.GetSettingsKey())
            {
                LayoutXml = this.GetLayout()
            }.Save();
        }

        /// <summary>
        /// Loads the layout from the default windows forms settings repository.
        /// 
        /// </summary>
        public void LoadLayout()
        {
            LayoutSettings layoutSettings = new LayoutSettings(this.GetSettingsKey());
            if (layoutSettings.IsDefault || layoutSettings.LayoutXml == null || (layoutSettings.LayoutXml.Length == 0 || 0 != 0))
                return;
            this.SetLayout(layoutSettings.LayoutXml);
        }

        /// <summary>
        /// Creates a string representing the current layout of docked and floating windows.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// A string containing layout information.
        /// </returns>
        public string GetLayout()
        {
            this.EnsureDockSystemContainer();
            StringWriter stringWriter;
            do
            {
                int index1;
                if (true)
                    goto label_35;
                label_1:
                DocumentContainer documentContainer;
                XmlTextWriter writer;
                if (documentContainer.LayoutSystem.ContainsPersistableDockControls)
                    this.SaveContainerLayout((DockContainer)documentContainer, writer);
                label_2:
                writer.WriteEndElement();
                writer.WriteEndDocument();
                if ((uint)index1 - (uint)index1 <= uint.MaxValue)
                {
                    writer.Flush();
                    writer.Close();
                    continue;
                }
                else
                    goto label_21;
                label_4:
                if (this.SerializeTabbedDocuments)
                    goto label_1;
                else
                    goto label_2;
                label_7:
                int index2;
                FloatingDockContainer[] dockContainerList1;
                DockContainer container1;
                if (index2 >= dockContainerList1.Length)
                {
                    if ((index1 | 8) != 0)
                    {
                        documentContainer = this.FindDockedContainer(DockStyle.Fill) as DocumentContainer;
                        if ((uint)index1 > uint.MaxValue || documentContainer != null)
                            goto label_4;
                        else
                            goto label_2;
                    }
                    else
                        goto label_23;
                }
                else
                {
                    container1 = (DockContainer)dockContainerList1[index2];
                    if ((index1 | 1) != 0)
                    {
                        if ((uint)index1 + (uint)index1 < 0U)
                            goto label_23;
                    }
                    else
                        goto label_15;
                }
                label_10:
                if (container1.LayoutSystem.ContainsPersistableDockControls)
                    this.SaveContainerLayout(container1, writer);
                ++index2;
                if ((uint)index2 >= 0U)
                    goto label_7;
                else
                    goto label_23;
                label_12:
                DockContainer[] dockContainerList2;
                DockContainer container2 = null;
                if (index1 >= dockContainerList2.Length)
                {
                    dockContainerList1 = this.GetFloatingDockContainerList();
                    index2 = 0;
                    goto label_7;
                }
                else
                {
                    container2 = dockContainerList2[index1];
                    goto label_21;
                }
                label_15:
                if (true)
                {
                    this.SaveContainerLayout(container2, writer);
                    if (false)
                        goto label_10;
                }
                else
                    goto label_33;
                label_17:
                ++index1;
                goto label_12;
                label_21:
                if (0 == 0)
                {
                    if (container2.LayoutSystem.ContainsPersistableDockControls)
                    {
                        if (false)
                            goto label_36;
                        else
                            goto label_15;
                    }
                    else
                        goto label_17;
                }
                else
                    goto label_4;
                label_23:
                if (0 != 0)
                {
                    if ((uint)index2 - (uint)index2 <= uint.MaxValue)
                        continue;
                }
                else
                    goto label_2;
                label_25:
                writer.WriteStartDocument();
                ((XmlWriter)writer).WriteStartElement("Layout");
                foreach (DockControl control in (IEnumerable) this.x8fb2a5bf0df0416f.Values)
                {
                    if (control.PersistState)
                        this.SaveWindowLayout(control, writer);
                }
                label_33:
                dockContainerList2 = this.GetOrderedDockedDockContainerList();
                index1 = 0;
                if ((int)byte.MaxValue == 0)
                    goto label_4;
                else
                    goto label_12;
                label_35:
                stringWriter = new StringWriter();
                label_36:
                writer = new XmlTextWriter((TextWriter)stringWriter);
                writer.Formatting = Formatting.Indented;
                goto label_25;
            }
            while (4 == 0);
            return stringWriter.ToString();
        }

        private void SaveContainerLayout(DockContainer container, XmlTextWriter writer)
        {
            if (!(container is FloatingDockContainer))
                goto label_4;
            else
                goto label_9;
            label_2:
            writer.WriteEndElement();
            int num;
            if ((uint)num + (uint)num >= 0U)
                return;
            else
                goto label_9;
            label_4:
            if (container is DocumentContainer)
                goto label_8;
            label_5:
            ((XmlWriter)writer).WriteStartElement("Container");
            label_6:
            XmlTextWriter xmlTextWriter1 = writer;
            string localName1 = "Dock";
            num = (int)container.Dock;
            string str1 = num.ToString();
            xmlTextWriter1.WriteAttributeString(localName1, str1);
            if (container.Dock != DockStyle.Fill && container.Dock != DockStyle.None)
                goto label_3;
            label_1:
            this.SaveLayoutSystem((LayoutSystemBase)container.LayoutSystem, writer);
            goto label_2;
            label_3:
            XmlTextWriter xmlTextWriter2 = writer;
            string localName2 = "ContentSize";
            int contentSize = container.ContentSize;
            string str2 = contentSize.ToString();
            xmlTextWriter2.WriteAttributeString(localName2, str2);
            if ((uint)num + (uint)contentSize > uint.MaxValue)
                goto label_5;
            else
                goto label_1;
            label_8:
            ((XmlWriter)writer).WriteStartElement("DocumentContainer");
            goto label_6;
            label_9:
            FloatingDockContainer x410f3612b9a8f9de = (FloatingDockContainer)container;
            ((XmlWriter)writer).WriteStartElement("FloatingContainer");
            writer.WriteAttributeString("Bounds", this.ConvertRectangleToString(x410f3612b9a8f9de.FloatingBounds));
            writer.WriteAttributeString("Guid", x410f3612b9a8f9de.Guid.ToString());
            if (0 == 0)
            {
                this.SaveLayoutSystem((LayoutSystemBase)container.LayoutSystem, writer);
                writer.WriteEndElement();
            }
            else
                goto label_2;
        }

        private void SaveLayoutSystem(LayoutSystemBase layoutSystem, XmlTextWriter writer)
        {
            if (!(layoutSystem is SplitLayoutSystem))
                goto label_36;
            else
                goto label_38;
            label_22:
            writer.WriteAttributeString("WorkingSize", SandDockManager.ConvertSizeFToString(layoutSystem.WorkingSize));
            if (layoutSystem is SplitLayoutSystem)
                goto label_23;
            else
                goto label_17;
            label_2:
            writer.WriteEndElement();
            if (0 == 0)
                return;
            int num;
            if ((uint)num - (uint)num <= uint.MaxValue)
                goto label_38;
            else
                goto label_36;
            label_17:
            if (true)
            {
                if (int.MaxValue == 0 || layoutSystem is ControlLayoutSystem)
                {
                    ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)layoutSystem;
                    writer.WriteAttributeString("Guid", controlLayoutSystem.Guid.ToString());
                    if (false)
                        return;
                    writer.WriteAttributeString("Collapsed", this.ConvertBoolToString(controlLayoutSystem.Collapsed));
                    if (controlLayoutSystem.SelectedControl == null)
                        goto label_5;
                    else
                        goto label_14;
                    label_1:
                    writer.WriteEndElement();
                    goto label_2;
                    label_5:
                    ((XmlWriter)writer).WriteStartElement("Controls");
                    IEnumerator enumerator = controlLayoutSystem.Controls.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            DockControl dockControl = (DockControl)enumerator.Current;
                            if (dockControl.PersistState)
                            {
                                ((XmlWriter)writer).WriteStartElement("Control");
                                writer.WriteAttributeString("Guid", dockControl.Guid.ToString());
                                writer.WriteEndElement();
                            }
                        }
                        goto label_1;
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        if (disposable != null)
                            disposable.Dispose();
                    }
                    label_14:
                    if (true)
                        goto label_4;
                    else
                        goto label_15;
                    label_3:
                    writer.WriteAttributeString("SelectedControl", controlLayoutSystem.SelectedControl.Guid.ToString());
                    goto label_5;
                    label_4:
                    if (controlLayoutSystem.SelectedControl.PersistState)
                        goto label_3;
                    else
                        goto label_5;
                    label_15:
                    if ((int)byte.MaxValue != 0)
                    {
                        if ((num | 3) != 0)
                            goto label_3;
                        else
                            goto label_1;
                    }
                }
                else
                    goto label_2;
            }
            else
                goto label_24;
            label_23:
            SplitLayoutSystem splitLayoutSystem = (SplitLayoutSystem)layoutSystem;
            label_24:
            XmlTextWriter xmlTextWriter = writer;
            string localName = "SplitMode";
            num = (int)splitLayoutSystem.SplitMode;
            string str = num.ToString();
            xmlTextWriter.WriteAttributeString(localName, str);
            IEnumerator enumerator1 = splitLayoutSystem.LayoutSystems.GetEnumerator();
            try
            {
                while (enumerator1.MoveNext())
                {
                    LayoutSystemBase layoutSystem1 = (LayoutSystemBase)enumerator1.Current;
                    if (layoutSystem1.ContainsPersistableDockControls)
                        this.SaveLayoutSystem(layoutSystem1, writer);
                    else if ((uint)num + (uint)num < 0U)
                        goto label_2;
                }
                if (1 == 0)
                    goto label_2;
                else
                    goto label_2;
            }
            finally
            {
                IDisposable disposable = enumerator1 as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            label_36:
            if (!(layoutSystem is ControlLayoutSystem))
                return;
            ((XmlWriter)writer).WriteStartElement("ControlLayoutSystem");
            goto label_22;
            label_38:
            ((XmlWriter)writer).WriteStartElement("SplitLayoutSystem");
            goto label_22;
        }

        private void SaveWindowLayout(DockControl control, XmlTextWriter writer)
        {
            x245a5abec1c73d3a.x4229d31a884b2577(control, writer);
        }

        private void OnOwnerFormClosing(object sender, CancelEventArgs e)
        {
            if (!this.AutoSaveLayout)
                return;
            this.SaveLayout();
        }

        private void OnOwnerFormLoad(object sender, EventArgs e)
        {
            if (!this.AutoSaveLayout)
                return;
            this.LoadLayout();
        }

        /// <summary>
        /// Gets all DockControls known by the manager.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// An array containing the controls.
        /// </returns>
        public DockControl[] GetDockControls()
        {
            DockControl[] dockControlArray = new DockControl[this.x8fb2a5bf0df0416f.Count];
            this.x8fb2a5bf0df0416f.Values.CopyTo((Array)dockControlArray, 0);
            return dockControlArray;
        }

        /// <summary>
        /// Gets all windows known by the manager in a specific dock situation.
        /// 
        /// </summary>
        /// <param name="dockSituation">The dock situation with which to filter the list.</param>
        /// <returns>
        /// An array of windows.
        /// </returns>
        public DockControl[] GetDockControls(DockSituation dockSituation)
        {
            ArrayList arrayList = new ArrayList();
            IEnumerator enumerator = this.x8fb2a5bf0df0416f.Values.GetEnumerator();
            try
            {
                while (true)
                {
                    DockControl dockControl;
                    do
                    {
                        if (!enumerator.MoveNext())
                        {
                            if (1 != 0)
                                goto label_9;
                        }
                        dockControl = (DockControl)enumerator.Current;
                    }
                    while (dockControl.DockSituation != dockSituation);
                    arrayList.Add((object)dockControl);
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            label_9:
            return (DockControl[])arrayList.ToArray(typeof(DockControl));
        }

        /// <summary>
        /// Gets all DockContainers known by the manager.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// An array containing the containers.
        /// </returns>
        public DockContainer[] GetDockContainers()
        {
            return (DockContainer[])this.dockContainers.ToArray(typeof(DockContainer));
        }

        private bool ShouldSerializeRenderer()
        {
            return !(this.renderer is WhidbeyRenderer);
        }

        private void OnRendererMetricsChanged(object sender, EventArgs e)
        {
            this.PropagateNewRenderer();
        }

        private void PropagateNewRenderer()
        {
            foreach (DockContainer dockContainer in this.dockContainers)
                dockContainer.x4481febbc2e58301();
            IEnumerator enumerator = this.autoHideBars.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                    ((AutoHideBar)enumerator.Current).x4481febbc2e58301();
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                while (disposable != null)
                {
                    disposable.Dispose();
                    if (int.MaxValue != 0 && 4 != 0)
                        break;
                }
            }
        }

        internal void RegisterDockContainer(DockContainer container)
        {
            if (!(container is DocumentContainer))
                goto label_9;
            else
                goto label_14;
            label_4:
            this.documentContainer.x64b4c49ed703037e = this.BorderStyle;
            this.documentContainer.DocumentOverflow = this.DocumentOverflow;
            this.documentContainer.IntegralClose = this.IntegralClose;
            if (0 != 0)
                return;
            else
                return;
            label_5:
            container.AllowDrop = this.SelectTabsOnDrag;
            if (!(container is DocumentContainer))
            {
                if (15 != 0)
                {
                    if (2 != 0)
                        return;
                }
                else
                    goto label_4;
            }
            this.documentContainer = (DocumentContainer)container;
            goto label_4;
            label_9:
            while (!this.dockContainers.Contains((object)container))
            {
                this.dockContainers.Add((object)container);
                if (int.MaxValue != 0)
                    goto label_6;
            }
            goto label_10;
            label_6:
            if (this.DockSystemContainer != null || !(container.Parent is ContainerControl) || container.IsFloating)
                goto label_5;
            label_7:
            this.DockSystemContainer = container.Parent;
            if (0 != 0)
                goto label_4;
            else
                goto label_5;
            label_10:
            if (0 != 0)
                goto label_7;
            else
                goto label_6;
            label_14:
            if (-2 != 0)
            {
                if (this.documentContainer != null)
                    throw new InvalidOperationException("Only one DocumentContainer can exist in a SandDock layout.");
                else
                    goto label_9;
            }
            else
                goto label_5;
        }

        internal void UnregisterDockContainer(DockContainer container)
        {
            if (this.dockContainers.Contains((object)container))
                this.dockContainers.Remove((object)container);
            if (this.documentContainer != container)
                return;
            this.documentContainer = (DocumentContainer)null;
        }

        internal void RegisterAutoHideBar(AutoHideBar bar)
        {
            if (!this.autoHideBars.Contains(bar))
                this.autoHideBars.Add(bar);
            bar.AllowDrop = this.SelectTabsOnDrag;
        }

        internal void UnregisterAutoHideBar(AutoHideBar bar)
        {
            if (this.autoHideBars.Contains(bar))
                this.autoHideBars.Remove(bar);
        }

        internal DockContainer FindDockedContainer(DockStyle dockStyle)
        {
            foreach (DockContainer dockContainer in this.dockContainers)
            {
                if (dockContainer.Dock == dockStyle && !dockContainer.IsFloating)
                    return dockContainer;
            }
            return null;
        }

        /// <summary>
        /// Returns the first DockContainer found at the location provided.
        /// 
        /// </summary>
        /// <param name="location">The location at which to look for a DockContainer.</param>
        /// <returns>
        /// A DockContainer instance docked at the specified location.
        /// </returns>
        public DockContainer FindDockContainer(ContainerDockLocation location)
        {
            return this.FindDockedContainer(LayoutUtilities.xf8330a3964a419ba(location));
        }

        internal FloatingDockContainer FindFloatingDockContainer(Guid guid)
        {
            FloatingDockContainer[] dockContainerList = this.GetFloatingDockContainerList();
            int index = 0;
            while (index < dockContainerList.Length)
            {
                FloatingDockContainer x410f3612b9a8f9de1 = dockContainerList[index];
                if (!(x410f3612b9a8f9de1.Guid == guid))
                {
                    ++index;
                }
                else
                {
                    FloatingDockContainer x410f3612b9a8f9de2 = x410f3612b9a8f9de1;
                    if (8 != 0)
                        return x410f3612b9a8f9de2;
                }
            }
            return (FloatingDockContainer)null;
        }

        private Control FindDockSystemContainer(IDesignerHost designerHost, Control parent)
        {
            foreach (Control parent1 in parent.Controls)
            {
                if (parent1.Dock == DockStyle.Fill || 0 == 0 && 0 != 0)
                {
                    if (parent1.Site == null)
                    {

                    }
                    else if (parent1.Site.DesignMode && !parent1.Controls.IsReadOnly)
                        return this.FindDockSystemContainer(designerHost, parent1);
                }
            }
            return parent;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (0 == 0)
                    goto label_13;
                else
                    goto label_8;
                label_6:
                AutoHideBar[] x10ac79a4257c7f52Array1;
                for (int index = 0; index < x10ac79a4257c7f52Array1.Length; ++index)
                    x10ac79a4257c7f52Array1[index].Dispose();
                this.autoHideBars.Clear();
                goto label_5;
                label_8:
                AutoHideBar[] x10ac79a4257c7f52Array2 = new AutoHideBar[this.autoHideBars.Count];
                label_9:
                this.autoHideBars.CopyTo((Array)x10ac79a4257c7f52Array2);
                int index1;
                if (false)
                    return;
                x10ac79a4257c7f52Array1 = x10ac79a4257c7f52Array2;
                goto label_6;
                label_13:
                int num1;
                if (true)
                {
                    if (int.MaxValue != 0)
                        goto label_15;
                    label_12:
                    this.dockContainers.Clear();
                    goto label_8;
                    label_15:
                    DockContainer[] dockContainerArray1 = new DockContainer[this.dockContainers.Count];
                    int num2;
                    if (true)
                    {
                        this.dockContainers.CopyTo((Array)dockContainerArray1);
                        DockContainer[] dockContainerArray2 = dockContainerArray1;
                        for (index1 = 0; index1 < dockContainerArray2.Length; ++index1)
                            dockContainerArray2[index1].Dispose();
                        goto label_12;
                    }
                    else
                        goto label_9;
                }
                else
                    goto label_6;
            }
            label_5:
            base.Dispose(disposing);
        }

        /// <summary>
        /// Raises the DockControlClosing event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected internal virtual void OnDockControlClosing(DockControlClosingEventArgs e)
        {
            if (this.DockControlClosing != null)
                this.DockControlClosing(this, e);
        }

        /// <summary>
        /// Raises the DockingStarted event.
        /// 
        /// </summary>
        /// <param name="e">The data for the event.</param>
        protected internal virtual void OnDockingStarted(EventArgs e)
        {
            if (this.DockingStarted != null)
                this.DockingStarted(this, e);
        }

        /// <summary>
        /// Raises the DockingFinished event.
        /// 
        /// </summary>
        /// <param name="e">The data for the event.</param>
        protected internal virtual void OnDockingFinished(EventArgs e)
        {
            if (this.DockingFinished != null)
                this.DockingFinished(this, e);
        }

        /// <summary>
        /// Raises the ResolveDockControl event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event.</param>
        protected virtual void OnResolveDockControl(ResolveDockControlEventArgs e)
        {
            if (this.ResolveDockControl != null)
                this.ResolveDockControl(this, e);
        }

        /// <summary>
        /// Raises the ActiveTabbedDocumentChanged event.
        /// 
        /// </summary>
        /// <param name="e">The arguments associated with the event</param>
        protected internal virtual void OnActiveTabbedDocumentChanged(EventArgs e)
        {
            if (this.ActiveTabbedDocumentChanged != null)
                this.ActiveTabbedDocumentChanged(this, e);
        }

        private void OnDockSystemContainerResize(object sender, EventArgs e)
        {
            if (this.OwnerForm == null)
                goto label_60;
            else
                goto label_77;
            label_52:
            int num1;
            Form form1 = null;
            if (form1.ActiveMdiChild.WindowState == FormWindowState.Maximized)
                return;
            label_54:
            Rectangle rectangle = xedb4922162c60d3d.x41c62f474d3fb367(this.DockSystemContainer);
            num1 = -rectangle.Width;
            int num2 = -rectangle.Height;
            if (this.DockSystemContainer is ToolStripContentPanel)
                goto label_51;
            label_47:
            if (num1 > 0)
                goto label_48;
            label_1:
            int num3;
            int num4 = 0;
            int num5;
            int num6 = 0;
            if (num2 <= 0)
            {
                if (false)
                    goto label_34;
            }
            else
            {
                ArrayList arrayList = new ArrayList();
                if (true)
                {
                    if (true)
                    {
                        int num7 = 0;
                        IEnumerator enumerator1 = this.dockContainers.GetEnumerator();
                        try
                        {
                            while (enumerator1.MoveNext())
                            {
                                DockContainer dockContainer = (DockContainer)enumerator1.Current;
                                if (dockContainer.Dock == DockStyle.Top)
                                    goto label_6;
                                label_5:
                                if (dockContainer.Dock != DockStyle.Bottom)
                                    continue;
                                label_6:
                                num7 += dockContainer.Height;
                                arrayList.Add((object)dockContainer);
                                if (false)
                                    goto label_5;
                            }
                        }
                        finally
                        {
                            IDisposable disposable = enumerator1 as IDisposable;
                            while (disposable != null)
                            {
                                disposable.Dispose();
                                if ((uint)num4 + (uint)num4 >= 0U)
                                    break;
                            }
                        }
                        if (num7 <= 0)
                            return;
                        IEnumerator enumerator2 = arrayList.GetEnumerator();
                        try
                        {
                            label_15:
                            while (enumerator2.MoveNext())
                            {
                                do
                                {
                                    DockContainer dockContainer = (DockContainer)enumerator2.Current;
                                    int num8 = 0;
                                    if (true)
                                    {
                                        num8 = Convert.ToInt32((double)dockContainer.Height / (double)num7 * (double)num2);
                                        num7 -= dockContainer.Height;
                                    }
                                    num2 -= num8;
                                    dockContainer.ContentSize -= num8;
                                    if (num7 != 0)
                                        goto label_15;
                                }
                                while ((uint)num7 + (uint)num7 > uint.MaxValue);
                                break;
                            }
                            return;
                        }
                        finally
                        {
                            IDisposable disposable = enumerator2 as IDisposable;
                            while (disposable != null)
                            {
                                disposable.Dispose();
                                if (true)
                                    break;
                            }
                        }
                    }
                }
                else
                    goto label_34;
            }
            if (true)
                return;
            else
                goto label_77;
            label_34:
            ArrayList arrayList1;
            if (num4 > 0)
            {
                IEnumerator enumerator = arrayList1.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        DockContainer dockContainer = (DockContainer)enumerator.Current;
                        num5 = Convert.ToInt32((double)dockContainer.Width / (double)num4 * (double)num1);
         
         
                            num4 -= dockContainer.Width;
                            num1 -= num5;
                            dockContainer.ContentSize -= num5;
                            if (num4 == 0)
                                break;

                    }
                    goto label_1;
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                        disposable.Dispose();
                }
            }
            else
                goto label_1;
            label_48:
            if (true)
            {
                if (int.MinValue != 0)
                {
                    arrayList1 = new ArrayList();
                    num4 = 0;
                    IEnumerator enumerator = this.dockContainers.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            DockContainer dockContainer = null;
                            while (enumerator.MoveNext())
                            {
                                dockContainer = (DockContainer)enumerator.Current;
                                if (dockContainer.Dock == DockStyle.Left || dockContainer.Dock == DockStyle.Right)
                                    goto label_42;
                            }
                            if ((num1 & 0) == 0)
                                goto label_34;
                            label_42:
                            num4 += dockContainer.Width;
                            arrayList1.Add((object)dockContainer);
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        if (disposable != null)
                            disposable.Dispose();
                    }
                }
                else if (0 != 0)
                {
                    if ((uint)num2 - (uint)num1 <= uint.MaxValue)
                        goto label_77;
                    else
                        goto label_67;
                }
                else
                    goto label_34;
            }
            else
                goto label_52;
            label_51:
            if (rectangle.Height <= 0)
                return;
            if (false)
                goto label_72;
            else
                goto label_47;
            label_58:
            if (form1.ActiveMdiChild == null)
            {
                if (false)
                    return;
                else
                    goto label_54;
            }
            else
                goto label_65;
            label_60:
            if (this.DockSystemContainer != null)
                goto label_75;
            else
                goto label_54;
            label_65:
            Form form2;
            if (form1.ActiveMdiChild == form2)
                goto label_54;
            else
                goto label_52;
            label_67:
            if (form1 != null)
            {
                if (form1.WindowState == FormWindowState.Minimized)
                    return;
                else
                    goto label_58;
            }
            else
                goto label_54;
            label_72:
            form1 = form2.Parent.FindForm();
            goto label_67;
            label_75:
            form2 = this.DockSystemContainer.FindForm();
            if (true)
            {
                if (form2 == null)
                {
                    if (false)
                        goto label_58;
                    else
                        goto label_54;
                }
                else
                {
                    if (form2.WindowState == FormWindowState.Minimized)
                        return;
                    if (form2.Parent == null)
                        goto label_54;
                    else
                        goto label_72;
                }
            }
            else
                goto label_65;
            label_77:
            if (this.OwnerForm.WindowState == FormWindowState.Minimized)
                return;
            if (true)
            {
                if (true)
                    goto label_60;
                else
                    goto label_75;
            }
            else
                goto label_67;
        }

        private void OnOwnerFormActivated(object sender, EventArgs e)
        {
            foreach (DockContainer dockContainer in this.dockContainers)
            {
                if (!dockContainer.IsFloating)
                    dockContainer.xa2414c47d888068e(sender, e);
            }
        }

        private void OnOwnerFormDeactivated(object sender, EventArgs e)
        {
            foreach (DockContainer dockContainer in this.dockContainers)
            {
                if (!dockContainer.IsFloating)
                    dockContainer.x19e788b09b195d4f(sender, e);
            }
        }

        /// <summary>
        /// Activates the product for build machines and machines where no design-time support is required.
        /// 
        /// </summary>
        /// <param name="licenseKey">The license key to activate the product.</param>
        public static void ActivateProduct(string licenseKey)
        {
//            x294bd621a33dc533.ActivateProduct(licenseKey);
        }
    }
}
