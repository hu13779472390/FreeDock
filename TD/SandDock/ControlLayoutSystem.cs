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
  [TypeConverter(typeof (x44c2ba9761cb4dd2))]
  public class ControlLayoutSystem : LayoutSystemBase
  {
    private Guid xb51cd75f17ace1ec = Guid.NewGuid();
    private System.Drawing.Point x6afebf16b45c02e0 = System.Drawing.Point.Empty;
    private const int x1e9b7c427b6c44fa = 19;
    private const int x26539fe4604823df = 15;
    private ControlLayoutSystem.DockControlCollection xe477cc01ecfef1fb;
    private bool xb9835bbd335d127e;
    internal Rectangle xb48529af1739dd06;
    internal Rectangle xa358da7dd5364cab;
    internal Rectangle x21ed2ecc088ef4e4;
    internal Rectangle xc78399ba98eab19f;
    private DockControl xbf5c00c8e3dd85fc;
    private bool xf111a0cc60fdac46;
    private x10ac79a4257c7f52 x4fb7dbcd13b8ce4b;
    private x0a9f5257a10031b2 x26e80f23e22a05ae;
    private x0a9f5257a10031b2 x65911b61bef3a921;
    private x0a9f5257a10031b2 x3b444f64233558c3;
    private x0a9f5257a10031b2 x502580ccb6d2ffd4;
    internal bool xfa5e20eb950b9ee1;
    private bool x04c163da360b887e;
    internal bool xd30df1068ed42e28;
    private bool x49cf4e0157d9436c;
    private bool xd34ff54c5dd91133;

    internal override DockControl[] x9476096be9672d38
    {
      get
      {
        DockControl[] array = new DockControl[this.Controls.Count];
        this.Controls.CopyTo(array, 0);
        return array;
      }
    }

    internal int xca843b3e9a1c605f
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
        IEnumerator enumerator = this.Controls.GetEnumerator();
        try
        {
          while (enumerator.MoveNext())
            ((DockControl) enumerator.Current).PopupSize = value;
        }
        finally
        {
          IDisposable disposable = enumerator as IDisposable;
          if (0 != 0 || disposable != null)
            disposable.Dispose();
        }
      }
    }

    internal override bool x56005f23d6948487
    {
      get
      {
        IEnumerator enumerator = this.Controls.GetEnumerator();
        bool flag1;
        try
        {
          DockControl dockControl;
          do
          {
            if (enumerator.MoveNext())
              goto label_5;
            else
              goto label_4;
label_2:
            continue;
label_4:
            bool flag2;
            if ((uint) flag2 - (uint) flag2 < 0U)
              goto label_2;
            else
              goto label_10;
label_5:
            dockControl = (DockControl) enumerator.Current;
            goto label_2;
          }
          while (!dockControl.PersistState);
          flag1 = true;
          if (0 == 0)
            goto label_11;
        }
        finally
        {
          IDisposable disposable = enumerator as IDisposable;
          if (disposable != null)
            disposable.Dispose();
        }
label_10:
        return false;
label_11:
        return flag1;
      }
    }

    internal Guid x0217cda8370c1f17
    {
      get
      {
        return this.xb51cd75f17ace1ec;
      }
      set
      {
        this.xb51cd75f17ace1ec = value;
      }
    }

    /// <summary>
    /// Gets/sets a value indicating whether the user will be prevented from initiating docking operations from this layout system.
    /// 
    /// </summary>
    public bool LockControls
    {
      get
      {
        return this.x04c163da360b887e;
      }
      set
      {
        this.x04c163da360b887e = value;
      }
    }

    /// <summary>
    /// Indicates whether the layout system is popped up, if in a collapsed state.
    /// 
    /// </summary>
    public bool IsPoppedUp
    {
      get
      {
        if (this.x10ac79a4257c7f52 != null)
          return this.x10ac79a4257c7f52.x23498f53d87354d4 == this;
        else
          return false;
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
        return this.xe477cc01ecfef1fb;
      }
    }

    internal x10ac79a4257c7f52 x10ac79a4257c7f52
    {
      get
      {
        return this.x4fb7dbcd13b8ce4b;
      }
    }

    internal Control x0e40cec3a0be4a70
    {
      get
      {
        if (!this.IsInContainer)
          return (Control) null;
        while (!this.IsPoppedUp)
        {
          if (0 == 0)
            return (Control) this.DockContainer;
        }
        return this.x10ac79a4257c7f52.x87cf4de36131799d;
      }
    }

    /// <summary>
    /// Indicates whether the layout system is collapsed (in auto-hide mode).
    /// 
    /// </summary>
    [DefaultValue(false)]
    [Browsable(false)]
    public virtual bool Collapsed
    {
      get
      {
        return this.xb9835bbd335d127e;
      }
      set
      {
        if (this.xb9835bbd335d127e == value)
          return;
        this.xb9835bbd335d127e = value;
        if (-1 == 0)
          return;
        this.x1f43ebe301d1df45 = (x0a9f5257a10031b2) null;
        if (!this.xb9835bbd335d127e)
          goto label_7;
        else
          goto label_3;
label_1:
        if (!this.IsInContainer)
          return;
        this.DockContainer.x7e9646eed248ed11();
        return;
label_3:
        if (!this.IsInContainer)
        {
          if ((uint) value - (uint) value <= uint.MaxValue)
          {
            if (3 != 0)
              goto label_1;
          }
          else
            goto label_8;
        }
        else
        {
          IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator();
          try
          {
label_28:
            if (!enumerator.MoveNext())
            {
              if (-2 != 0)
                goto label_20;
            }
            DockControl dockControl = (DockControl) enumerator.Current;
            while (dockControl.Parent == this.DockContainer)
            {
              LayoutUtilities.xa7513d57b4844d46((Control) dockControl);
              if (3 != 0)
              {
                if (4 != 0)
                  break;
              }
              else
                goto label_20;
            }
            goto label_28;
          }
          finally
          {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable != null)
              disposable.Dispose();
          }
label_20:
          x10ac79a4257c7f52 autoHideBar = this.DockContainer.Manager.GetAutoHideBar(this.DockContainer.Dock);
          if (autoHideBar != null)
          {
            if (4 == 0)
              return;
            if ((uint) value - (uint) value >= 0U && 0 == 0)
            {
              autoHideBar.x7fdaeb05cb5e84f3.xd6b6ed77479ef68c(this);
              goto label_1;
            }
            else
              goto label_1;
          }
          else
            goto label_1;
        }
label_7:
        if (this.x10ac79a4257c7f52 != null)
          this.x10ac79a4257c7f52.x7fdaeb05cb5e84f3.x52b190e626f65140(this);
label_8:
        IEnumerator enumerator1 = this.xe477cc01ecfef1fb.GetEnumerator();
        try
        {
label_10:
          if (!enumerator1.MoveNext())
          {
            if (((value ? 1 : 0) & 0) == 0)
              goto label_1;
          }
          else
            goto label_14;
label_13:
          DockControl dockControl;
          while (dockControl.Parent != this.DockContainer)
          {
            dockControl.Parent = (Control) this.DockContainer;
            if ((uint) value - (uint) value >= 0U)
              break;
          }
          goto label_10;
label_14:
          dockControl = (DockControl) enumerator1.Current;
          if (int.MinValue == 0)
            goto label_1;
          else
            goto label_13;
        }
        finally
        {
          IDisposable disposable = enumerator1 as IDisposable;
          if ((uint) value - (uint) value < 0U || disposable != null)
            disposable.Dispose();
        }
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
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual DockControl SelectedControl
    {
      get
      {
        return this.xbf5c00c8e3dd85fc;
      }
      set
      {
        if (value != null && !this.xe477cc01ecfef1fb.Contains(value))
          throw new ArgumentOutOfRangeException("value");
        if (this.SelectedControl == null || this.SelectedControl.Manager == null)
          goto label_13;
        else
          goto label_15;
label_9:
        this.x3e0280cae730d1f2();
label_2:
        if (this.IsPoppedUp)
          goto label_8;
label_1:
        DockControl x321bff1c322e5433;
        this.xe20c835979d60df8(x321bff1c322e5433, this.xbf5c00c8e3dd85fc);
        if (-1 != 0)
        {
          if (0 == 0)
            return;
          else
            goto label_8;
        }
        else
          goto label_4;
label_3:
        if (this.xbf5c00c8e3dd85fc != null || 0 != 0)
        {
          this.xbf5c00c8e3dd85fc.OnAutoHidePopupOpened(EventArgs.Empty);
          if (0 != 0)
            goto label_2;
          else
            goto label_1;
        }
        else
          goto label_1;
label_4:
        if (0 != 0)
          goto label_2;
        else
          goto label_3;
label_8:
        if (x321bff1c322e5433 != null)
        {
          x321bff1c322e5433.OnAutoHidePopupClosed(EventArgs.Empty);
          goto label_3;
        }
        else
          goto label_4;
label_13:
        x321bff1c322e5433 = this.xbf5c00c8e3dd85fc;
        this.xbf5c00c8e3dd85fc = value;
        goto label_9;
label_15:
        if (8 != 0)
        {
          if (this.SelectedControl.Manager.RaiseValidationEvents)
          {
            if (int.MinValue == 0)
              goto label_9;
          }
          else
            goto label_13;
        }
        if (this.SelectedControl.ValidateChildren())
          goto label_13;
      }
    }

    internal x0a9f5257a10031b2 x1f43ebe301d1df45
    {
      get
      {
        return this.x502580ccb6d2ffd4;
      }
      set
      {
        if (value == this.x502580ccb6d2ffd4)
          return;
        if (this.x502580ccb6d2ffd4 != null)
        {
          this.xd541e2fc281b554b();
          if (int.MaxValue == 0)
            return;
        }
        this.x502580ccb6d2ffd4 = value;
        if (this.x502580ccb6d2ffd4 == null)
          return;
        this.xd541e2fc281b554b();
      }
    }

    internal override bool x2f61709eaa5ebf76
    {
      get
      {
        foreach (DockControl dockControl in (CollectionBase) this.Controls)
        {
          if (!dockControl.DockingRules.AllowTab)
            return false;
          if (0 != 0)
            ;
        }
        return true;
      }
    }

    internal override bool x74e31f9641656e0b
    {
      get
      {
        foreach (DockControl dockControl in (CollectionBase) this.Controls)
        {
          if (!dockControl.DockingRules.AllowFloat)
          {
            if (-2 != 0)
              return false;
            else
              break;
          }
        }
        return true;
      }
    }

    private bool x43d7533e3cdb2944
    {
      get
      {
        IEnumerator enumerator = this.Controls.GetEnumerator();
        bool flag;
        try
        {
          while (enumerator.MoveNext())
          {
            if (!((DockControl) enumerator.Current).AllowCollapse)
            {
              flag = false;
              return flag;
            }
          }
        }
        finally
        {
          IDisposable disposable = enumerator as IDisposable;
          if (0 == 0)
            ;
          while (disposable != null)
          {
            disposable.Dispose();
            if (((flag ? 1 : 0) | 15) != 0 && int.MinValue != 0)
              break;
          }
        }
        return true;
      }
    }

    internal bool x317ed3bc8decf394
    {
      get
      {
        return this.xd34ff54c5dd91133;
      }
      set
      {
        if (value == this.xd34ff54c5dd91133)
          return;
        this.xd34ff54c5dd91133 = value;
        this.xd541e2fc281b554b();
      }
    }

    internal Rectangle xccb1fc68964285c2
    {
      get
      {
        return this.xc78399ba98eab19f;
      }
    }

    internal event ControlLayoutSystem.xf09a9df3c262275d xcc55983eb55360ac;

    /// <summary>
    /// Initializes a new instance of the ControlLayoutSystem class.
    /// 
    /// </summary>
    public ControlLayoutSystem()
    {
      this.xe477cc01ecfef1fb = new ControlLayoutSystem.DockControlCollection(this);
      this.x26e80f23e22a05ae = new x0a9f5257a10031b2();
      this.x65911b61bef3a921 = new x0a9f5257a10031b2();
      this.x3b444f64233558c3 = new x0a9f5257a10031b2();
    }

    /// <summary>
    /// Initializes a new instance of the ControlLayoutSystem class, with the specified initial dimensions.
    /// 
    /// </summary>
    /// <param name="desiredWidth">The desired width of this layout system, in pixels.</param><param name="desiredHeight">The desired height of this layout system, in pixels.</param>
    public ControlLayoutSystem(int desiredWidth, int desiredHeight)
      : this()
    {
      this.WorkingSize = new SizeF((float) desiredWidth, (float) desiredHeight);
    }

    /// <summary>
    /// Initializes a new instance of the ControlLayoutSystem class, with the specified initial dimensions, and with the specified child controls.
    /// 
    /// </summary>
    /// <param name="desiredWidth">The desired width of this layout system, in pixels.</param><param name="desiredHeight">The desired height of this layout system, in pixels.</param><param name="controls">An array of DockControls to populate this layout system with.</param><param name="selectedControl">The control to be made selected.</param>
    [Obsolete("Use the constructor that takes a SizeF instead.")]
    public ControlLayoutSystem(int desiredWidth, int desiredHeight, DockControl[] controls, DockControl selectedControl)
      : this(desiredWidth, desiredHeight)
    {
      do
      {
        this.xe477cc01ecfef1fb.AddRange(controls);
      }
      while (0 != 0);
      if (selectedControl == null)
        return;
      this.SelectedControl = selectedControl;
    }

    /// <summary>
    /// Initializes a new instance of the ControlLayoutSystem class, with the specified working size, and with the specified child controls.
    /// 
    /// </summary>
    /// <param name="workingSize">The working size of the layout system.</param><param name="windows">An array of DockControls to populate this layout system with.</param><param name="selectedWindow">The control to be made selected.</param>
    public ControlLayoutSystem(SizeF workingSize, DockControl[] windows, DockControl selectedWindow)
      : this()
    {
      if (15 == 0)
        return;
      this.WorkingSize = workingSize;
      this.Controls.AddRange(windows);
      if (2 == 0)
        goto label_6;
label_2:
      if (selectedWindow == null)
        return;
label_6:
      this.SelectedControl = selectedWindow;
      if (0 != 0)
        goto label_2;
    }

    /// <summary>
    /// Initializes a new instance of the ControlLayoutSystem class, with the specified initial dimensions, and with the specified child controls.
    /// 
    /// </summary>
    /// <param name="desiredWidth">The desired width of this layout system, in pixels.</param><param name="desiredHeight">The desired height of this layout system, in pixels.</param><param name="controls">An array of DockControls to populate this layout system with.</param><param name="selectedControl">The control to be made selected.</param><param name="collapsed">Whether the layout system should start collapsed.</param>
    public ControlLayoutSystem(int desiredWidth, int desiredHeight, DockControl[] controls, DockControl selectedControl, bool collapsed)
      : this(new SizeF((float) desiredWidth, (float) desiredHeight), controls, selectedControl)
    {
      this.Collapsed = collapsed;
    }

    /// <summary>
    /// Closes the popup for this layout system, if it is showing.
    /// 
    /// </summary>
    public void ClosePopup()
    {
      if (!this.IsPoppedUp)
        return;
      this.x10ac79a4257c7f52.xcdb145600c1b7224(true);
    }

    internal void xa85d8c17921cc878(x10ac79a4257c7f52 x4fb7dbcd13b8ce4b)
    {
      this.x4fb7dbcd13b8ce4b = x4fb7dbcd13b8ce4b;
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
      while (this.IsInContainer && this.SelectedControl != null)
      {
        if (!this.Collapsed || this.x10ac79a4257c7f52 == null)
        {
          this.SelectedControl.Activate();
          if (1 != 0)
            break;
        }
        else
        {
          this.x10ac79a4257c7f52.xe6ff614263a59ef9(this.SelectedControl, true, false);
          this.x10ac79a4257c7f52.xcdb145600c1b7224(false);
          if (0 == 0)
            break;
        }
      }
    }

    private void xe20c835979d60df8(DockControl x321bff1c322e5433, DockControl x31b34ee91c89cf69)
    {
      if (this.xcc55983eb55360ac == null)
        return;
      this.xcc55983eb55360ac(x321bff1c322e5433, x31b34ee91c89cf69);
    }

    /// <summary>
    /// Overridden
    /// 
    /// </summary>
    protected internal override void OnMouseDoubleClick()
    {
      System.Drawing.Point point = this.DockContainer.PointToClient(Cursor.Position);
      if (this.DockContainer.Manager == null || this.LockControls)
        return;
      if (this.xb48529af1739dd06.Contains(point))
        goto label_6;
label_4:
      DockControl controlAt = this.GetControlAt(point);
      if (controlAt == null)
        return;
      controlAt.OnTabDoubleClick();
      return;
label_6:
      if (!this.x26e80f23e22a05ae.xda73fcb97c77d998.Contains(point))
        goto label_7;
label_2:
      if (int.MaxValue != 0)
        goto label_4;
label_7:
      if (!this.x65911b61bef3a921.xda73fcb97c77d998.Contains(point))
      {
        if (this.Controls.Count == 0)
        {
          if (2 == 0)
          {
            if (1 != 0)
              goto label_2;
            else
              goto label_6;
          }
          else
            goto label_4;
        }
        else
          this.xa7b62e7d2cd81eb7();
      }
      else
        goto label_4;
    }

    private void xa7b62e7d2cd81eb7()
    {
      DockSituation dockSituation = this.SelectedControl.DockSituation;
label_16:
      switch (dockSituation)
      {
        case DockSituation.Docked:
        case DockSituation.Document:
          if (!this.x74e31f9641656e0b)
            break;
          this.x18f55df6f6629e9f(DockSituation.Floating);
          if (0 == 0)
            break;
          else
            break;
        case DockSituation.Floating:
          if (this.SelectedControl.MetaData.LastFixedDockSituation != DockSituation.Docked || !this.xe302f2203dc14a18(this.SelectedControl.MetaData.LastFixedDockSide))
          {
            while (this.SelectedControl.MetaData.LastFixedDockSituation == DockSituation.Document)
            {
              if (this.xe302f2203dc14a18(ContainerDockLocation.Center))
              {
                this.x18f55df6f6629e9f(DockSituation.Document);
                break;
              }
              else
              {
                if (-2 != 0)
                  break;
                if (15 == 0)
                {
                  if (0 != 0)
                    ;
                }
                else
                  goto label_16;
              }
            }
            break;
          }
          else
          {
            this.x18f55df6f6629e9f(DockSituation.Docked);
            break;
          }
      }
    }

    /// <summary>
    /// Overridden
    /// 
    /// </summary>
    protected internal override void OnMouseMove(MouseEventArgs e)
    {
      if (!this.xd30df1068ed42e28)
        goto label_34;
      else
        goto label_40;
label_1:
      if (this.xf111a0cc60fdac46)
      {
        if (1 != 0)
          return;
        else
          return;
      }
      else
      {
        this.x1f43ebe301d1df45 = this.x07083a4bfd59263d(e.X, e.Y);
        if (15 != 0)
          return;
        if (-1 == 0)
        {
          if (0 == 0)
            goto label_24;
          else
            goto label_15;
        }
        else
          goto label_33;
      }
label_3:
      if (3 == 0)
        goto label_1;
      else
        goto label_1;
label_8:
      Rectangle rectangle;
      if (!rectangle.Contains(e.X, e.Y) || 0 != 0)
      {
        if (this.IsInContainer && this.x6afebf16b45c02e0 != System.Drawing.Point.Empty)
        {
          if (1 != 0)
            goto label_10;
          else
            goto label_29;
label_7:
          if (!this.LockControls)
            goto label_26;
          else
            goto label_1;
label_10:
          if (!this.Collapsed)
            goto label_7;
          else
            goto label_1;
label_29:
          if (0 == 0)
            goto label_7;
          else
            goto label_26;
        }
        else
          goto label_1;
      }
      else if (4 != 0)
        goto label_3;
      else
        goto label_14;
label_11:
      if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
      {
        if (15 != 0)
          goto label_1;
        else
          goto label_8;
      }
      else
        goto label_31;
label_14:
      DockControl controlAt;
      DockingHints x48cee1d69929b4fe;
      DockingManager xab4835b6b3620991;
      this.xe9a159cd1e028df2(this.DockContainer.Manager, this.DockContainer, (LayoutSystemBase) this, controlAt, this.SelectedControl.MetaData.DockedContentSize, this.x6afebf16b45c02e0, x48cee1d69929b4fe, xab4835b6b3620991);
      return;
label_15:
      if (this.DockContainer.Manager != null)
        goto label_19;
label_16:
      xab4835b6b3620991 = DockingManager.Standard;
      if (1 != 0)
        goto label_23;
label_17:
      if (15 == 0)
      {
        if (15 == 0)
        {
          if (int.MaxValue == 0)
          {
            if (0 != 0)
            {
              if (0 == 0)
                goto label_24;
              else
                goto label_3;
            }
            else
              goto label_30;
          }
          else
            goto label_31;
        }
      }
      else
        goto label_15;
label_19:
      xab4835b6b3620991 = this.DockContainer.Manager.DockingManager;
      goto label_14;
label_23:
      if (0 == 0)
        goto label_14;
      else
        goto label_3;
label_24:
      if (0 != 0)
        ;
label_25:
      x48cee1d69929b4fe = this.DockContainer.Manager.DockingHints;
      goto label_15;
label_26:
      controlAt = this.GetControlAt(this.x6afebf16b45c02e0);
      this.x49cf4e0157d9436c = controlAt == null;
      if (-2 != 0)
      {
        if (this.DockContainer.Manager == null)
        {
          if (0 != 0)
            goto label_1;
        }
        else
          goto label_25;
      }
      x48cee1d69929b4fe = DockingHints.TranslucentFill;
      if (int.MaxValue != 0)
        goto label_17;
      else
        goto label_23;
label_30:
      this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
      return;
label_31:
      if (this.x531514c39973cbc6 == null)
      {
        rectangle = new Rectangle(this.x6afebf16b45c02e0, new System.Drawing.Size(0, 0));
        if (1 != 0)
        {
          rectangle.Inflate(SystemInformation.DragSize);
          goto label_8;
        }
        else
          goto label_16;
      }
      else
        goto label_30;
label_33:
      if (4 != 0)
        goto label_11;
label_34:
      if (e.Button == MouseButtons.None)
      {
        this.xf111a0cc60fdac46 = false;
        goto label_33;
      }
      else
        goto label_11;
label_40:
      if (1 == 0)
        goto label_26;
    }

    internal override bool xe302f2203dc14a18(ContainerDockLocation xb9c2cfae130d9256)
    {
      IEnumerator enumerator = this.Controls.GetEnumerator();
      bool flag;
      try
      {
label_3:
        if (enumerator.MoveNext())
          goto label_7;
        else
          goto label_5;
label_4:
        DockControl dockControl;
        if (!dockControl.xe302f2203dc14a18(xb9c2cfae130d9256))
          goto label_6;
        else
          goto label_3;
label_5:
        if ((uint) flag + (uint) flag >= 0U)
          goto label_12;
label_6:
        flag = false;
        if (8 == 0)
        {
          if (0 != 0)
            goto label_4;
          else
            goto label_3;
        }
        else
          goto label_13;
label_7:
        dockControl = (DockControl) enumerator.Current;
        goto label_4;
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        while (disposable != null)
        {
          disposable.Dispose();
          if (8 != 0 && ((flag ? 1 : 0) & 0) == 0)
            break;
        }
      }
label_12:
      return true;
label_13:
      return flag;
    }

    internal virtual string xe0e7b93bedab6c05(System.Drawing.Point x13d4cb8d1bd20347)
    {
      DockControl controlAt = this.GetControlAt(x13d4cb8d1bd20347);
      if (controlAt == null)
      {
        x0a9f5257a10031b2 x0a9f5257a10031b2 = this.x07083a4bfd59263d(x13d4cb8d1bd20347.X, x13d4cb8d1bd20347.Y);
        if (x0a9f5257a10031b2 == this.x26e80f23e22a05ae)
          return SandDockLanguage.CloseText;
        if (x0a9f5257a10031b2 == this.x65911b61bef3a921)
          return SandDockLanguage.AutoHideText;
        if (x0a9f5257a10031b2 == this.x3b444f64233558c3)
          return SandDockLanguage.WindowPositionText;
        else
          return "";
      }
      else
      {
        if (controlAt.ToolTipText.Length != 0)
          return controlAt.ToolTipText;
        if (!controlAt.xcfac6723d8a41375)
          return "";
        else
          return controlAt.Text;
      }
    }

    internal virtual x0a9f5257a10031b2 x07083a4bfd59263d(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
    {
      if (this.x26e80f23e22a05ae.x364c1e3b189d47fe)
        goto label_7;
label_1:
      if (!this.x65911b61bef3a921.x364c1e3b189d47fe)
        goto label_3;
label_2:
      if (this.x65911b61bef3a921.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
        goto label_6;
label_3:
      if (this.x3b444f64233558c3.x364c1e3b189d47fe && this.x3b444f64233558c3.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
        return this.x3b444f64233558c3;
      else
        return (x0a9f5257a10031b2) null;
label_6:
      return this.x65911b61bef3a921;
label_7:
      if (-2 == 0 || this.x26e80f23e22a05ae.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
        return this.x26e80f23e22a05ae;
      if ((uint) x1e218ceaee1bb583 + (uint) x08db3aeabb253cb1 < 0U)
      {
        if ((x1e218ceaee1bb583 & 0) == 0)
          goto label_2;
        else
          goto label_6;
      }
      else
        goto label_1;
    }

    internal override void x0ae87c4881d90427(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      base.x0ae87c4881d90427(xe0292b9ed559da7d, xfbf34718e704c6bc);
      this.x6afebf16b45c02e0 = System.Drawing.Point.Empty;
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override void OnDragOver(DragEventArgs drgevent)
    {
      base.OnDragOver(drgevent);
      if (3 == 0)
        return;
      DockControl controlAt = this.GetControlAt(this.DockContainer.PointToClient(new System.Drawing.Point(drgevent.X, drgevent.Y)));
      if (controlAt == null || this.SelectedControl == controlAt && 0 == 0)
        return;
      controlAt.Open(WindowOpenMethod.OnScreenActivate);
    }

    /// <summary>
    /// Overridden
    /// 
    /// </summary>
    protected internal override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      if (0 == 0)
        goto label_19;
label_14:
      do
      {
        if (this.xb48529af1739dd06.Contains(e.X, e.Y) && this.SelectedControl != null)
          this.SelectedControl.Activate();
label_15:
        if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
          goto label_6;
        else
          goto label_11;
label_5:
        if (this.x1f43ebe301d1df45 != null)
          goto label_9;
label_6:
        DockControl controlAt = this.GetControlAt(new System.Drawing.Point(e.X, e.Y));
        if (controlAt != null)
        {
          controlAt.Activate();
          if ((int) byte.MaxValue != 0)
          {
            this.xf111a0cc60fdac46 = true;
            if (int.MaxValue != 0)
            {
              if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
              {
                if (-2 != 0)
                  continue;
                else
                  goto label_5;
              }
              else
                goto label_18;
            }
            else
              goto label_15;
          }
          else
            goto label_15;
        }
        else
          goto label_17;
label_11:
        while (this.xb48529af1739dd06.Contains(e.X, e.Y))
        {
          this.x6afebf16b45c02e0 = new System.Drawing.Point(e.X, e.Y);
          if (-2 != 0)
          {
            if (2 != 0)
              goto label_5;
          }
          else
            goto label_14;
        }
        if (0 == 0)
          goto label_5;
        else
          goto label_9;
      }
      while (15 == 0);
      this.x6afebf16b45c02e0 = new System.Drawing.Point(e.X, e.Y);
      return;
label_18:
      return;
label_17:
      return;
label_9:
      this.xfa5e20eb950b9ee1 = true;
      this.xd541e2fc281b554b();
      this.x11e90588eb0baaf1(this.x1f43ebe301d1df45);
      this.x6afebf16b45c02e0 = System.Drawing.Point.Empty;
      return;
label_19:
      this.xf111a0cc60fdac46 = false;
      goto label_14;
    }

    /// <summary>
    /// Overridden
    /// 
    /// </summary>
    protected internal override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      if (8 == 0)
        return;
label_31:
      this.x6afebf16b45c02e0 = System.Drawing.Point.Empty;
label_32:
      this.xf111a0cc60fdac46 = false;
      if (this.x531514c39973cbc6 == null)
      {
        if (2 == 0)
          goto label_16;
        else
          goto label_12;
label_2:
        while (this.x1f43ebe301d1df45 != null)
        {
          this.xa82f7b310984e03e(this.x1f43ebe301d1df45);
          this.xfa5e20eb950b9ee1 = false;
          this.xd541e2fc281b554b();
          if ((int) byte.MaxValue != 0)
            break;
        }
        return;
label_10:
        if ((e.Button & MouseButtons.Middle) != MouseButtons.Middle || !this.IsInContainer || (this.DockContainer.Manager == null || !this.DockContainer.Manager.AllowMiddleButtonClosure))
        {
          if ((e.Button & MouseButtons.Left) != MouseButtons.Left || -2 == 0)
            return;
          else
            goto label_2;
        }
        else
        {
          if (0 != 0)
            return;
          DockControl controlAt = this.GetControlAt(new System.Drawing.Point(e.X, e.Y));
          if (controlAt == null || !controlAt.AllowClose)
            return;
          controlAt.x8ffe90e7fbccfccd(true);
          return;
        }
label_12:
        DockControl dockControl;
        if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
        {
          dockControl = this.GetControlAt(new System.Drawing.Point(e.X, e.Y));
          goto label_21;
        }
        else
          goto label_10;
label_16:
        System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);
        if (-1 != 0)
        {
          System.Drawing.Point p = dockControl.Parent.PointToScreen(point);
          point = dockControl.PointToClient(p);
          if (8 == 0)
            return;
          if (4 != 0)
          {
            this.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(dockControl, point, ContextMenuContext.RightClick));
            if ((int) byte.MaxValue != 0)
              return;
            if (4 == 0)
              goto label_31;
          }
          else
            goto label_32;
        }
        else
          goto label_2;
label_21:
        if (dockControl == null && this.xb48529af1739dd06.Contains(e.X, e.Y))
          goto label_25;
label_17:
        if (dockControl != null)
        {
          if (0 == 0)
          {
            if (!this.IsInContainer)
            {
              if (int.MinValue == 0)
                goto label_10;
              else
                goto label_10;
            }
            else
              goto label_16;
          }
        }
        else
          goto label_10;
label_25:
        dockControl = this.SelectedControl;
        goto label_17;
      }
      else
        this.x531514c39973cbc6.Commit();
    }

    internal virtual void x11e90588eb0baaf1(x0a9f5257a10031b2 x128517d7ded59312)
    {
    }

    internal virtual void xa82f7b310984e03e(x0a9f5257a10031b2 x128517d7ded59312)
    {
      if (this.x1f43ebe301d1df45 != this.x26e80f23e22a05ae)
      {
        if (this.x1f43ebe301d1df45 != this.x65911b61bef3a921)
        {
          if (this.x1f43ebe301d1df45 != this.x3b444f64233558c3 || 0 != 0)
            return;
          this.xf0820a0467228c88();
        }
        else
          this.OnPinButtonClick();
      }
      else
        this.OnCloseButtonClick(EventArgs.Empty);
    }

    private void xf0820a0467228c88()
    {
      this.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(this.SelectedControl, this.SelectedControl.PointToClient(this.SelectedControl.Parent.PointToScreen(new System.Drawing.Point(this.x3b444f64233558c3.xda73fcb97c77d998.Left, this.x3b444f64233558c3.xda73fcb97c77d998.Bottom))), ContextMenuContext.OptionsButton));
    }

    /// <summary>
    /// Overridden
    /// 
    /// </summary>
    protected internal override void OnMouseLeave()
    {
      base.OnMouseLeave();
      this.x1f43ebe301d1df45 = (x0a9f5257a10031b2) null;
      this.xfa5e20eb950b9ee1 = false;
    }

    internal bool x61ce2417e4ef76f9()
    {
      if (this.IsInContainer)
      {
        if (0 == 0)
          goto label_7;
label_5:
        if (this.SelectedControl != null)
          goto label_4;
label_2:
        return true;
label_4:
        this.DockContainer.Manager.OnDockControlActivated(new DockControlEventArgs(this.SelectedControl));
        goto label_2;
label_7:
        while (this.SelectedControl != null)
        {
          if (!this.SelectedControl.ContainsFocus)
          {
            if (int.MaxValue != 0)
              break;
          }
          else
          {
            this.x317ed3bc8decf394 = true;
            goto label_5;
          }
        }
      }
      return false;
    }

    internal void x82dd941e2755ffd2()
    {
      this.x317ed3bc8decf394 = false;
    }

    internal override void x84b6f3c22477dacb(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Font x26094932cf7a9139)
    {
      if (this.DockContainer == null)
        return;
label_79:
      Control container = this.DockContainer.IsFloating || (this.DockContainer.Manager == null || this.DockContainer.Manager.DockSystemContainer == null) ? (Control) this.DockContainer : this.DockContainer.Manager.DockSystemContainer;
      if (!this.IsInContainer || !this.DockContainer.x972331c8ecf83413)
        goto label_73;
      else
        goto label_74;
label_1:
      if (!this.x3b444f64233558c3.x364c1e3b189d47fe || this.x3b444f64233558c3.xda73fcb97c77d998.Left <= this.xb48529af1739dd06.Left)
        return;
      DrawItemState state1 = DrawItemState.Default;
      if (this.x1f43ebe301d1df45 == this.x3b444f64233558c3)
      {
        state1 |= DrawItemState.HotLight;
        goto label_4;
      }
      else
        goto label_5;
label_2:
      bool focused;
      Rectangle rectangle;
      if (rectangle.Width > 0 || ((focused ? 1 : 0) & 0) != 0)
      {
        if (rectangle.Height <= 0)
          return;
        x38870620fd380a6b.DrawTitleBarBackground(x41347a961b838962, rectangle, focused);
        goto label_34;
      }
      else if (int.MinValue != 0)
        return;
      else
        goto label_20;
label_4:
      if (this.xfa5e20eb950b9ee1)
        state1 |= DrawItemState.Selected;
label_5:
      x38870620fd380a6b.DrawTitleBarButton(x41347a961b838962, this.x3b444f64233558c3.xda73fcb97c77d998, SandDockButtonType.WindowPosition, state1, focused, false);
      return;
label_9:
      bool drawSeparator;
      if (this.x65911b61bef3a921.x364c1e3b189d47fe && this.x65911b61bef3a921.xda73fcb97c77d998.Left > this.xb48529af1739dd06.Left)
      {
        state1 = DrawItemState.Default;
        if (this.x1f43ebe301d1df45 == this.x65911b61bef3a921)
        {
          state1 |= DrawItemState.HotLight;
          if (this.xfa5e20eb950b9ee1)
          {
            if (0 == 0)
              state1 |= DrawItemState.Selected;
            else
              goto label_4;
          }
        }
        else if ((uint) focused + (uint) drawSeparator > uint.MaxValue)
          goto label_2;
      }
      else
        goto label_1;
label_10:
      x38870620fd380a6b.DrawTitleBarButton(x41347a961b838962, this.x65911b61bef3a921.xda73fcb97c77d998, SandDockButtonType.Pin, state1, focused, this.Collapsed);
      goto label_1;
label_14:
      if (!this.x26e80f23e22a05ae.x364c1e3b189d47fe)
        goto label_9;
label_20:
      int selectedTabOffset;
      if (this.x26e80f23e22a05ae.xda73fcb97c77d998.Left > this.xb48529af1739dd06.Left)
      {
        state1 = DrawItemState.Default;
        while (this.x1f43ebe301d1df45 == this.x26e80f23e22a05ae)
        {
          state1 |= DrawItemState.HotLight;
          if (this.xfa5e20eb950b9ee1)
          {
            state1 |= DrawItemState.Selected;
            if ((uint) selectedTabOffset - (uint) selectedTabOffset <= uint.MaxValue)
              goto label_18;
          }
          else
            goto label_18;
        }
        goto label_24;
label_18:
        x38870620fd380a6b.DrawTitleBarButton(x41347a961b838962, this.x26e80f23e22a05ae.xda73fcb97c77d998, SandDockButtonType.Close, state1, focused, false);
        if ((uint) drawSeparator - (uint) focused > uint.MaxValue)
          goto label_27;
        else
          goto label_9;
label_24:
        if ((uint) focused - (uint) drawSeparator < 0U)
        {
          if ((uint) drawSeparator > uint.MaxValue)
            return;
          else
            goto label_14;
        }
        else
          goto label_18;
      }
      else
        goto label_9;
label_27:
      if (!this.x3b444f64233558c3.x364c1e3b189d47fe)
      {
        if (0 != 0)
          goto label_30;
      }
      else
        goto label_32;
label_29:
      rectangle = x38870620fd380a6b.TitleBarMetrics.RemovePadding(rectangle);
      if (rectangle.Width > 8)
      {
        x38870620fd380a6b.DrawTitleBarText(x41347a961b838962, rectangle, focused, this.xbf5c00c8e3dd85fc == null ? "Empty Layout System" : this.xbf5c00c8e3dd85fc.Text, this.xbf5c00c8e3dd85fc != null ? this.xbf5c00c8e3dd85fc.Font : this.DockContainer.Font);
        if (((drawSeparator ? 1 : 0) & 0) != 0)
          goto label_10;
        else
          goto label_14;
      }
      else
        goto label_14;
label_30:
      if (!this.x65911b61bef3a921.x364c1e3b189d47fe)
      {
        if ((uint) drawSeparator + (uint) selectedTabOffset <= uint.MaxValue)
          goto label_27;
      }
      else
      {
        rectangle.Width -= 21;
        if ((selectedTabOffset | 4) != 0)
          goto label_27;
        else
          goto label_40;
      }
label_32:
      rectangle.Width -= 21;
      goto label_40;
label_33:
      rectangle.Width -= 21;
      if (0 == 0)
        goto label_30;
label_34:
      if (this.x26e80f23e22a05ae.x364c1e3b189d47fe)
        goto label_33;
      else
        goto label_30;
label_39:
      rectangle = this.xb48529af1739dd06;
      if (!(rectangle != Rectangle.Empty))
        return;
      else
        goto label_2;
label_40:
      if ((uint) selectedTabOffset >= 0U)
        goto label_29;
label_41:
      if (this.xe477cc01ecfef1fb.Count <= 1)
      {
        if ((uint) focused + (uint) selectedTabOffset >= 0U)
        {
          if (!this.DockContainer.x972331c8ecf83413)
            goto label_39;
        }
        else
          goto label_66;
      }
      if (!(this.xa358da7dd5364cab != Rectangle.Empty))
        goto label_39;
label_66:
      selectedTabOffset = 0;
      goto label_81;
label_69:
      if (this.SelectedControl == null)
      {
        x38870620fd380a6b.DrawControlClientBackground(x41347a961b838962, this.x21ed2ecc088ef4e4, SystemColors.Control);
        goto label_41;
      }
      else if ((uint) focused - (uint) focused >= 0U)
      {
        if (1 != 0)
        {
          x38870620fd380a6b.DrawControlClientBackground(x41347a961b838962, this.x21ed2ecc088ef4e4, this.SelectedControl.BackColor);
          goto label_41;
        }
        else if ((uint) selectedTabOffset + (uint) drawSeparator <= uint.MaxValue)
          goto label_41;
        else
          goto label_81;
      }
      else
        goto label_1;
label_73:
      focused = this.x317ed3bc8decf394;
      goto label_69;
label_74:
      if ((uint) drawSeparator + (uint) focused >= 0U)
      {
        focused = ((ISelectionService) this.DockContainer.x7159e85e85b84817(typeof (ISelectionService))).GetComponentSelected((object) this.SelectedControl);
        goto label_69;
      }
      else
        goto label_33;
label_81:
      if ((uint) drawSeparator - (uint) selectedTabOffset >= 0U)
      {
        if ((uint) drawSeparator - (uint) focused > uint.MaxValue || this.xbf5c00c8e3dd85fc != null)
        {
          selectedTabOffset = this.xbf5c00c8e3dd85fc.x123e054dab107457.X - this.Bounds.Left;
          if ((uint) selectedTabOffset + (uint) focused > uint.MaxValue)
            goto label_1;
        }
        x38870620fd380a6b.DrawTabStripBackground(container, (Control) this.DockContainer, x41347a961b838962, this.xa358da7dd5364cab, selectedTabOffset);
        if ((uint) selectedTabOffset - (uint) focused >= 0U)
        {
          IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator();
          try
          {
            while (true)
            {
              if (enumerator.MoveNext())
                goto label_57;
              else
                goto label_46;
label_44:
              DockControl control;
              DrawItemState state2;
              x38870620fd380a6b.DrawTabStripTab(x41347a961b838962, control.x123e054dab107457, control.x1999b243e321e38a, control.TabText, control.Font, control.BackColor, control.ForeColor, state2, drawSeparator);
              continue;
label_46:
              if (0 != 0)
                goto label_44;
              else
                goto label_39;
label_57:
              control = (DockControl) enumerator.Current;
              state2 = DrawItemState.Default;
              do
              {
                if (this.xbf5c00c8e3dd85fc == control)
                  goto label_56;
label_55:
                drawSeparator = true;
                if ((uint) focused - (uint) selectedTabOffset <= uint.MaxValue)
                {
                  if (this.xbf5c00c8e3dd85fc != null)
                  {
                    if ((uint) drawSeparator + (uint) selectedTabOffset >= 0U)
                      goto label_52;
                  }
                  else
                    break;
                }
                else
                  goto label_52;
label_51:
                drawSeparator = false;
                if (-1 != 0)
                  break;
label_52:
                if (this.xe477cc01ecfef1fb.IndexOf(control) != this.xe477cc01ecfef1fb.IndexOf(this.xbf5c00c8e3dd85fc) - 1)
                  continue;
                else
                  goto label_51;
label_56:
                state2 |= DrawItemState.Selected;
                goto label_55;
              }
              while (((focused ? 1 : 0) & 0) != 0);
              if (this.xe477cc01ecfef1fb.IndexOf(control) == this.xe477cc01ecfef1fb.Count - 1 && ((uint) focused - (uint) selectedTabOffset > uint.MaxValue || (uint) focused < 0U || x38870620fd380a6b is WhidbeyRenderer))
              {
                drawSeparator = false;
                goto label_44;
              }
              else
                goto label_44;
            }
          }
          finally
          {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable != null)
              disposable.Dispose();
          }
        }
        else if ((uint) selectedTabOffset + (uint) focused >= 0U)
          goto label_41;
        else
          goto label_29;
      }
      else
        goto label_79;
    }

    internal void xb30ec7cfdf3e5c19(Graphics x41347a961b838962, RendererBase x38870620fd380a6b, x0a9f5257a10031b2 x128517d7ded59312, SandDockButtonType x271bd5d42b3ea793, bool x2fef7d841879a711)
    {
      if (!x128517d7ded59312.x364c1e3b189d47fe)
        return;
      DrawItemState state = DrawItemState.Default;
      while (this.x1f43ebe301d1df45 == x128517d7ded59312)
      {
        if ((uint) x2fef7d841879a711 >= 0U)
          goto label_11;
label_4:
        if ((uint) x2fef7d841879a711 + (uint) x2fef7d841879a711 <= uint.MaxValue && (uint) x2fef7d841879a711 + (uint) x2fef7d841879a711 >= 0U)
          break;
label_5:
        if (this.xfa5e20eb950b9ee1)
        {
          state |= DrawItemState.Selected;
          if (((x2fef7d841879a711 ? 1 : 0) | 3) == 0)
            continue;
          else
            goto label_4;
        }
        else if (0 != 0)
          return;
        else
          break;
label_11:
        state |= DrawItemState.HotLight;
        goto label_5;
      }
      if (!x2fef7d841879a711)
        state |= DrawItemState.Disabled;
      x38870620fd380a6b.DrawDocumentStripButton(x41347a961b838962, x128517d7ded59312.xda73fcb97c77d998, x271bd5d42b3ea793, state);
    }

    internal virtual void xd541e2fc281b554b()
    {
      if (this.x10ac79a4257c7f52 != null)
      {
        if (1 != 0)
          ;
      }
      else
        goto label_7;
label_2:
      if (this.x10ac79a4257c7f52.x23498f53d87354d4 != this)
      {
        if (0 == 0)
          return;
      }
      else
      {
        this.x10ac79a4257c7f52.xbb5f70c792fb9034(this.xb48529af1739dd06);
        return;
      }
label_7:
      if (!this.IsInContainer)
        return;
      this.DockContainer.Invalidate(this.xb48529af1739dd06);
      if (0 != 0 || 2 == 0)
        goto label_2;
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
            if ((int) byte.MaxValue != 0)
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
              if ((int) byte.MaxValue != 0 && x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.CreateNewContainer)
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
      DockContainer dockedContainer;
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
            controls = this.x9476096be9672d38;
          SizeF workingSize = this.WorkingSize;
          ControlLayoutSystem newLayoutSystem = dockContainer.CreateNewLayoutSystem(controls, workingSize);
          x11d58b056c032b03.layoutSystem.SplitForLayoutSystem((LayoutSystemBase) newLayoutSystem, x11d58b056c032b03.dockSide);
          if (0 != 0)
            return;
          else
            return;
        }
        else
        {
          dockedContainer = x91f347c6e97f1846.FindDockedContainer(DockStyle.Fill);
          if ((uint) x49cf4e0157d9436c - (uint) x49cf4e0157d9436c >= 0U)
          {
            if (x11d58b056c032b03.dockLocation != ContainerDockLocation.Center)
              goto label_11;
          }
          else
            goto label_20;
        }
      }
      else
        goto label_23;
label_10:
      while (dockedContainer != null)
      {
        ControlLayoutSystem controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem(dockedContainer);
        if (0 == 0)
        {
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
            if ((uint) x49cf4e0157d9436c - (uint) x49cf4e0157d9436c <= uint.MaxValue)
              return;
          }
        }
        else if ((uint) x49cf4e0157d9436c >= 0U)
          goto label_23;
        else
          goto label_20;
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
    public void SplitForLayoutSystem(LayoutSystemBase layoutSystem, DockSide side)
    {
      if (layoutSystem == null)
      {
        if (-1 != 0)
          throw new ArgumentNullException("layoutSystem");
      }
      else
        goto label_22;
label_4:
      if (side != DockSide.Right)
      {
        this.xd2be843c6119e3c3(layoutSystem, Orientation.Horizontal, side == DockSide.Top);
        return;
      }
label_6:
      SplitLayoutSystem parent;
      this.x46d2db93dc2104ad(layoutSystem, side == DockSide.Left ? parent.LayoutSystems.IndexOf((LayoutSystemBase) this) : parent.LayoutSystems.IndexOf((LayoutSystemBase) this) + 1, false);
      return;
label_22:
      if (side == DockSide.None)
        throw new ArgumentException("side");
      if (layoutSystem.Parent != null)
        throw new InvalidOperationException("This layout system must be removed from its parent before it can be moved to a new layout system.");
      if (this.Parent == null)
        throw new InvalidOperationException("This layout system is not parented yet.");
      parent = this.Parent;
      if (parent.SplitMode != Orientation.Horizontal)
      {
        if (parent.SplitMode != Orientation.Vertical)
          return;
        if (side == DockSide.Left)
          goto label_6;
        else
          goto label_4;
      }
      else
      {
label_11:
        if (side == DockSide.Top)
          goto label_14;
label_8:
        if (side != DockSide.Bottom)
        {
          this.xd2be843c6119e3c3(layoutSystem, Orientation.Vertical, side == DockSide.Left);
          return;
        }
        else if (0 != 0)
          goto label_11;
label_14:
        do
        {
          this.x46d2db93dc2104ad(layoutSystem, side == DockSide.Top ? parent.LayoutSystems.IndexOf((LayoutSystemBase) this) : parent.LayoutSystems.IndexOf((LayoutSystemBase) this) + 1, true);
          if (0 != 0)
            goto label_12;
        }
        while (0 != 0);
        goto label_7;
label_12:
        if (int.MinValue == 0)
          goto label_11;
        else
          goto label_8;
label_7:;
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
      SplitLayoutSystem splitLayoutSystem;
      int num;
      do
      {
        splitLayoutSystem = new SplitLayoutSystem();
      }
      while ((uint) x6b161b1ae41c1651 + (uint) num < 0U);
      do
      {
        splitLayoutSystem.SplitMode = xf65758d54b79fc7a;
        splitLayoutSystem.WorkingSize = this.WorkingSize;
        int index = parent.LayoutSystems.IndexOf((LayoutSystemBase) this);
        parent.LayoutSystems.xd7a3953bce504b63 = true;
        if (((x6b161b1ae41c1651 ? 1 : 0) & 0) == 0)
          goto label_5;
label_4:
        parent.LayoutSystems.xd7a3953bce504b63 = false;
        splitLayoutSystem.LayoutSystems.Add((LayoutSystemBase) this);
        if (x6b161b1ae41c1651)
        {
          splitLayoutSystem.LayoutSystems.Insert(0, x6e150040c8d97700);
          continue;
        }
        else
          goto label_1;
label_5:
        parent.LayoutSystems.Remove((LayoutSystemBase) this);
        parent.LayoutSystems.Insert(index, (LayoutSystemBase) splitLayoutSystem);
        goto label_4;
      }
      while (8 == 0);
      goto label_2;
label_1:
      splitLayoutSystem.LayoutSystems.Add(x6e150040c8d97700);
label_2:
      parent.x8e9e04a70e31e166();
    }

    internal void x18f55df6f6629e9f(DockSituation x7e49ae9bddfdfd07)
    {
      if (this.Controls.Count != 0)
      {
        while (this.SelectedControl.DockSituation != x7e49ae9bddfdfd07)
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
              if (x7e49ae9bddfdfd07 == DockSituation.Docked)
                goto label_14;
              else
                goto label_12;
label_3:
              DockControl[] controls = new DockControl[array.Length - 1];
              do
              {
                Array.Copy((Array) array, 1, (Array) controls, 0, array.Length - 1);
              }
              while (0 != 0);
              array[0].LayoutSystem.Controls.AddRange(controls);
              continue;
label_12:
              if (3 != 0)
              {
                do
                {
                  if (x7e49ae9bddfdfd07 != DockSituation.Document)
                  {
                    if (x7e49ae9bddfdfd07 == DockSituation.Floating)
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
      if (this.Parent == null)
        goto label_12;
      else
        goto label_9;
label_1:
      x410f3612b9a8f9de x410f3612b9a8f9de;
      x410f3612b9a8f9de.x159713d3b60fae0c(bounds, true, openMethod == WindowOpenMethod.OnScreenActivate);
      if (openMethod != WindowOpenMethod.OnScreenActivate)
        return;
      this.SelectedControl.Activate();
      if (2 != 0)
        return;
label_4:
      x410f3612b9a8f9de.LayoutSystem.LayoutSystems.Add((LayoutSystemBase) this);
      if (int.MinValue != 0)
        goto label_1;
label_9:
      if (0 == 0)
        LayoutUtilities.x4487f2f8917e3fd0(this);
      else
        goto label_1;
label_12:
      do
      {
        if (this.SelectedControl.MetaData.LastFloatingWindowGuid == Guid.Empty)
          goto label_11;
        else
          goto label_6;
label_5:
        continue;
label_6:
        while (int.MaxValue != 0)
        {
          if (1 == 0)
          {
            if (0 == 0)
              goto label_9;
          }
          else
            goto label_3;
        }
        goto label_5;
label_11:
        this.SelectedControl.MetaData.x87f4a9b62a380563(Guid.NewGuid());
        goto label_5;
      }
      while (3 == 0);
label_3:
      x410f3612b9a8f9de = new x410f3612b9a8f9de(manager, this.SelectedControl.MetaData.LastFloatingWindowGuid);
      goto label_4;
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
    public void Dock(ControlLayoutSystem layoutSystem)
    {
      if (layoutSystem == null)
        throw new ArgumentNullException();
      this.Dock(layoutSystem, 0);
    }

    /// <summary>
    /// Moves this layout system in to an existing layout system, at the specified offset.
    /// 
    /// </summary>
    /// <param name="layoutSystem">The layout system to move in to.</param><param name="index">The offset of the new tabs in the existing layout system.</param>
    public void Dock(ControlLayoutSystem layoutSystem, int index)
    {
      if (layoutSystem == null)
        throw new ArgumentNullException();
      if (this.Parent != null)
        throw new InvalidOperationException("This layout system already has a parent. To remove it, use the parent layout system's LayoutSystems.Remove method.");
      DockControl selectedControl = this.SelectedControl;
      while (true)
      {
        DockControl control;
        if (this.xe477cc01ecfef1fb.Count == 0)
        {
          if (int.MaxValue != 0)
            break;
        }
        else
          control = this.xe477cc01ecfef1fb[0];
        this.xe477cc01ecfef1fb.RemoveAt(0);
        layoutSystem.Controls.Insert(index, control);
      }
      while (selectedControl != null)
      {
        layoutSystem.SelectedControl = selectedControl;
        if (2 != 0 && 3 != 0)
          break;
      }
    }

    internal override void x56e964269d48cfcc(DockContainer x0467b00af7810f0c)
    {
      if (x0467b00af7810f0c == null)
      {
        if (int.MinValue != 0)
          goto label_48;
        else
          goto label_6;
      }
      else
        goto label_37;
label_2:
      if (this.x10ac79a4257c7f52 == null)
      {
        if (3 == 0)
          goto label_39;
        else
          goto label_8;
      }
      else
        goto label_7;
label_6:
      if (0 == 0)
        goto label_2;
label_7:
      this.x10ac79a4257c7f52.x7fdaeb05cb5e84f3.x52b190e626f65140(this);
      return;
label_8:
      if ((int) byte.MaxValue != 0)
        return;
      else
        goto label_48;
label_37:
      if (x0467b00af7810f0c != null)
        goto label_25;
      else
        goto label_38;
label_15:
      x10ac79a4257c7f52 autoHideBar;
      autoHideBar.x7fdaeb05cb5e84f3.xd6b6ed77479ef68c(this);
      return;
label_24:
      base.x56e964269d48cfcc(x0467b00af7810f0c);
      do
      {
        foreach (DockControl dockControl in (CollectionBase) this.Controls)
          dockControl.x56e964269d48cfcc(x0467b00af7810f0c);
        if (this.Collapsed)
        {
          if (x0467b00af7810f0c != null)
          {
            if (x0467b00af7810f0c.Manager == null)
              goto label_11;
label_9:
            if (this.x10ac79a4257c7f52 == null)
              goto label_16;
            else
              goto label_14;
label_11:
            if (int.MaxValue == 0)
            {
              if (0 == 0)
                goto label_9;
            }
            else
              goto label_2;
label_14:;
          }
          else
            goto label_2;
        }
        else
          goto label_42;
      }
      while (2 == 0);
      goto label_6;
label_42:
      return;
label_16:
      autoHideBar = x0467b00af7810f0c.Manager.GetAutoHideBar(x0467b00af7810f0c.Dock);
      if (autoHideBar == null)
      {
        if (1 != 0)
          return;
        else
          goto label_8;
      }
      else
        goto label_15;
label_25:
      if (!this.IsInContainer)
      {
        IEnumerator enumerator = this.Controls.GetEnumerator();
        try
        {
          while (enumerator.MoveNext())
          {
            DockControl dockControl = (DockControl) enumerator.Current;
            if (-1 == 0 || dockControl.Parent != null)
              goto label_32;
label_30:
            dockControl.Location = new System.Drawing.Point(x0467b00af7810f0c.Width, x0467b00af7810f0c.Height);
            if (!this.Collapsed || !x0467b00af7810f0c.x0c2484ccd29b8358)
            {
              dockControl.Parent = (Control) x0467b00af7810f0c;
              continue;
            }
            else
              continue;
label_32:
            LayoutUtilities.xa7513d57b4844d46((Control) dockControl);
            goto label_30;
          }
          goto label_24;
        }
        finally
        {
          IDisposable disposable = enumerator as IDisposable;
          if (0 == 0)
            goto label_35;
label_34:
          disposable.Dispose();
          if (0 == 0)
            goto label_36;
label_35:
          if (disposable != null)
            goto label_34;
label_36:;
        }
      }
      else
        goto label_24;
label_38:
      if (4 == 0)
        goto label_15;
      else
        goto label_24;
label_39:
      IEnumerator enumerator1 = this.Controls.GetEnumerator();
      try
      {
        while (enumerator1.MoveNext())
        {
          DockControl dockControl = (DockControl) enumerator1.Current;
          if (dockControl.Parent == this.DockContainer)
            LayoutUtilities.xa7513d57b4844d46((Control) dockControl);
        }
        goto label_37;
      }
      finally
      {
        IDisposable disposable = enumerator1 as IDisposable;
        if (disposable != null)
          disposable.Dispose();
      }
label_48:
      if (this.IsInContainer)
        goto label_39;
      else
        goto label_37;
    }

    /// <summary>
    /// Retrieves the dock control with a tab at the specified position.
    /// 
    /// </summary>
    /// <param name="position">The location, in client coordinates, to search.</param>
    /// <returns>
    /// The dock control found. If no dock control was found, a null reference is returned.
    /// </returns>
    public virtual DockControl GetControlAt(System.Drawing.Point position)
    {
      if (this.xa358da7dd5364cab.Contains(position) && (0 != 0 || !this.x26e80f23e22a05ae.xda73fcb97c77d998.Contains(position)) && !this.x65911b61bef3a921.xda73fcb97c77d998.Contains(position))
        goto label_2;
label_1:
      return (DockControl) null;
label_2:
      IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
        {
          DockControl dockControl;
          do
          {
            dockControl = (DockControl) enumerator.Current;
          }
          while (3 == 0);
          if (dockControl.x123e054dab107457.Contains(position))
            return dockControl;
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

    internal int x17fd454c85fad336(System.Drawing.Point x13d4cb8d1bd20347)
    {
      int num = 0;
      IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
        {
          Rectangle rectangle = ((DockControl) enumerator.Current).x123e054dab107457;
          do
          {
            if (x13d4cb8d1bd20347.X > rectangle.Left + rectangle.Width / 2)
              ++num;
            else
              break;
          }
          while ((num & 0) != 0);
        }
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        if ((uint) num - (uint) num < 0U || 15 != 0)
          goto label_8;
label_7:
        disposable.Dispose();
        if ((num & 0) == 0 && (uint) num >= 0U)
          goto label_9;
label_8:
        if (disposable != null)
          goto label_7;
label_9:;
      }
      return num;
    }

    internal void x3e0280cae730d1f2()
    {
      if (this.x10ac79a4257c7f52 != null)
        goto label_7;
label_2:
      if (!this.IsInContainer)
      {
        if (4 != 0)
          return;
      }
      else
        goto label_8;
label_7:
      this.x10ac79a4257c7f52.x200394302d96eb9b(this);
      if (int.MinValue != 0)
        goto label_2;
label_8:
      if (!this.DockContainer.IsFloating)
        goto label_5;
      else
        goto label_4;
label_1:
      this.DockContainer.Invalidate(this.Bounds);
      return;
label_4:
      this.DockContainer.CalculateAllMetricsAndLayout();
      goto label_1;
label_5:
      this.DockContainer.xec9697acef66c1bc((LayoutSystemBase) this, this.Bounds);
      goto label_1;
    }

    private void x5425d90305f1baa5()
    {
      int num1;
      if (this.xbf5c00c8e3dd85fc == null)
      {
        if ((num1 | -1) != 0)
        {
          if (15 != 0)
          {
            this.x26e80f23e22a05ae.x364c1e3b189d47fe = false;
            this.x65911b61bef3a921.x364c1e3b189d47fe = false;
            this.x3b444f64233558c3.x364c1e3b189d47fe = false;
            return;
          }
          else
            goto label_12;
        }
        else
          goto label_14;
      }
      else
        goto label_22;
label_4:
      int num2;
      int y;
      if (!this.xbf5c00c8e3dd85fc.ShowOptions)
      {
        this.x3b444f64233558c3.x364c1e3b189d47fe = false;
        if ((uint) num2 - (uint) y <= uint.MaxValue)
        {
          if (2 != 0)
          {
            if (1 != 0)
              return;
            else
              goto label_14;
          }
        }
        else
          goto label_19;
      }
      else
      {
        this.x3b444f64233558c3.x364c1e3b189d47fe = true;
        this.x3b444f64233558c3.xda73fcb97c77d998 = new Rectangle(num2 - 19, y, 19, 15);
        num1 = num2 - 21;
        return;
      }
label_6:
      if ((uint) y - (uint) y < 0U)
        goto label_14;
label_7:
      this.x65911b61bef3a921.x364c1e3b189d47fe = false;
      goto label_4;
label_9:
      if (!this.x43d7533e3cdb2944)
      {
        if ((uint) y + (uint) num2 < 0U)
        {
          if (0 == 0)
            goto label_14;
        }
        else
          goto label_6;
      }
      else
        goto label_13;
label_12:
      if ((num2 | 1) != 0)
        goto label_15;
label_13:
      if (!this.IsInContainer)
        goto label_15;
label_14:
      if (this.DockContainer.x0c2484ccd29b8358)
        goto label_12;
      else
        goto label_7;
label_15:
      this.x65911b61bef3a921.x364c1e3b189d47fe = true;
      this.x65911b61bef3a921.xda73fcb97c77d998 = new Rectangle(num2 - 19, y, 19, 15);
      num2 -= 21;
      goto label_4;
label_19:
      if ((uint) num2 - (uint) num2 <= uint.MaxValue)
      {
        num2 -= 21;
        if ((uint) y - (uint) num2 < 0U)
          return;
        if ((num2 | 1) == 0)
        {
          if ((y | -2) != 0)
            goto label_15;
          else
            goto label_14;
        }
        else
          goto label_9;
      }
      else
        goto label_4;
label_22:
      y = this.xb48529af1739dd06.Top + this.xb48529af1739dd06.Height / 2 - 7;
      if (0 == 0)
        goto label_23;
label_18:
      this.x26e80f23e22a05ae.xda73fcb97c77d998 = new Rectangle(num2 - 19, y, 19, 15);
      if ((uint) num2 - (uint) y < 0U)
        goto label_13;
      else
        goto label_19;
label_23:
      num2 = this.xb48529af1739dd06.Right - 2;
      if (!this.xbf5c00c8e3dd85fc.AllowClose)
      {
        this.x26e80f23e22a05ae.x364c1e3b189d47fe = false;
        goto label_9;
      }
      else
      {
        this.x26e80f23e22a05ae.x364c1e3b189d47fe = true;
        goto label_18;
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
      if (-2 == 0)
        ;
      this.x5425d90305f1baa5();
      bounds.Offset(0, renderer.TitleBarMetrics.Height);
      bounds.Height -= renderer.TitleBarMetrics.Height;
      this.x21ed2ecc088ef4e4 = bounds;
      this.xa358da7dd5364cab = Rectangle.Empty;
      foreach (DockControl control in (CollectionBase) this.xe477cc01ecfef1fb)
      {
        Rectangle rectangle = renderer.AdjustDockControlClientBounds(this, control, this.x21ed2ecc088ef4e4);
        if (int.MinValue == 0)
          break;
        control.xbdd4aaac1291a8c7(control == this.xbf5c00c8e3dd85fc);
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
      if (!floating)
        goto label_9;
      else
        goto label_8;
label_6:
      if (this.Controls.Count <= 1 && !this.DockContainer.x972331c8ecf83413)
        tabstripBounds = Rectangle.Empty;
      else
        goto label_7;
label_3:
      clientBounds = bounds;
      if ((uint) floating - (uint) floating <= uint.MaxValue)
      {
        if (((floating ? 1 : 0) & 0) == 0)
        {
          joinCatchmentBounds = titlebarBounds;
          if (((floating ? 1 : 0) | 2) == 0)
            goto label_9;
        }
        if ((uint) floating + (uint) floating <= uint.MaxValue)
          return;
        else
          goto label_8;
      }
      else
        goto label_10;
label_7:
      tabstripBounds = bounds;
      tabstripBounds.Y = tabstripBounds.Bottom - renderer.TabStripMetrics.Height;
      tabstripBounds.Height = renderer.TabStripMetrics.Height;
      tabstripBounds = renderer.TabStripMetrics.RemoveMargin(tabstripBounds);
      bounds.Height -= renderer.TabStripMetrics.Height;
      goto label_3;
label_8:
      titlebarBounds = Rectangle.Empty;
      goto label_6;
label_9:
      titlebarBounds = bounds;
      titlebarBounds.Offset(0, renderer.TitleBarMetrics.Margin.Top);
      titlebarBounds.Height = renderer.TitleBarMetrics.Height - (renderer.TitleBarMetrics.Margin.Top + renderer.TitleBarMetrics.Margin.Bottom);
label_10:
      this.x5425d90305f1baa5();
      bounds.Offset(0, renderer.TitleBarMetrics.Height);
      bounds.Height -= renderer.TitleBarMetrics.Height;
      goto label_6;
    }

    private void x7fd1f193b21c8833()
    {
      foreach (DockControl dockControl in (CollectionBase) this.Controls)
        dockControl.x44fd51d909a57a2a();
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override void Layout(RendererBase renderer, Graphics graphics, Rectangle bounds, bool floating)
    {
      base.Layout(renderer, graphics, bounds, floating);
      if (4 == 0)
        return;
      do
      {
        this.x7fd1f193b21c8833();
        if (0 == 0 && !this.Collapsed || !this.DockContainer.x0c2484ccd29b8358)
          this.CalculateLayout(renderer, bounds, floating, out this.xb48529af1739dd06, out this.xa358da7dd5364cab, out this.x21ed2ecc088ef4e4, out this.xc78399ba98eab19f);
        else
          goto label_24;
      }
      while ((uint) floating < 0U);
      this.xd30df1068ed42e28 = true;
      try
      {
        if (this.xb48529af1739dd06 != Rectangle.Empty)
          this.x5425d90305f1baa5();
        this.x5d6e30ce9634c49e(renderer, graphics, this.xa358da7dd5364cab);
        foreach (DockControl dockControl in (CollectionBase) this.xe477cc01ecfef1fb)
        {
          if (dockControl != this.SelectedControl)
            dockControl.xbdd4aaac1291a8c7(false);
        }
        IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator();
        try
        {
          while (true)
          {
            DockControl control;
            do
            {
              if (enumerator.MoveNext())
                goto label_19;
              else
                goto label_18;
label_16:
              continue;
label_18:
              if (0 != 0)
                goto label_16;
              else
                goto label_1;
label_19:
              control = (DockControl) enumerator.Current;
              goto label_16;
            }
            while (control != this.SelectedControl);
            Rectangle rectangle = renderer.AdjustDockControlClientBounds(this, control, this.x21ed2ecc088ef4e4);
            control.Bounds = rectangle;
            control.xbdd4aaac1291a8c7(true);
          }
label_1:
          return;
        }
        finally
        {
          IDisposable disposable = enumerator as IDisposable;
          if (disposable != null)
            disposable.Dispose();
        }
      }
      finally
      {
        this.xd30df1068ed42e28 = false;
      }
label_24:;
    }

    private void x5d6e30ce9634c49e(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Rectangle xa358da7dd5364cab)
    {
      int num1 = 0;
label_36:
      int num2 = xa358da7dd5364cab.Width - (x38870620fd380a6b.TabStripMetrics.Padding.Left + x38870620fd380a6b.TabStripMetrics.Padding.Right);
label_14:
      int[] numArray = new int[this.xe477cc01ecfef1fb.Count];
      int index1 = 0;
      int index2;
      int num3;
      int index3;
      int left;
      int val1;
      foreach (DockControl dockControl in (CollectionBase) this.xe477cc01ecfef1fb)
      {
        dockControl.xcfac6723d8a41375 = false;
        val1 = x38870620fd380a6b.MeasureTabStripTab(x41347a961b838962, dockControl.TabImage, dockControl.TabText, dockControl.Font, DrawItemState.Default).Width;
        if ((val1 | (int) byte.MaxValue) != 0)
          goto label_23;
        else
          goto label_27;
label_19:
        if (dockControl.MaximumTabWidth == 0)
          goto label_21;
label_20:
        if (dockControl.MaximumTabWidth < val1)
          goto label_22;
label_21:
        num1 += val1;
        numArray[index1++] = val1;
        if ((uint) index2 + (uint) num2 <= uint.MaxValue)
        {
          if ((uint) num3 + (uint) index2 <= uint.MaxValue)
          {
            if ((num3 & 0) != 0)
              goto label_19;
          }
          else
            goto label_23;
        }
        if ((uint) index3 >= 0U)
          continue;
        else
          goto label_27;
label_22:
        val1 = dockControl.MaximumTabWidth;
        dockControl.xcfac6723d8a41375 = true;
        goto label_21;
label_23:
        if (dockControl.MinimumTabWidth == 0)
        {
          if ((uint) left - (uint) num2 > uint.MaxValue)
          {
            if ((uint) index3 + (uint) num3 <= uint.MaxValue)
              goto label_20;
            else
              goto label_22;
          }
          else
            goto label_19;
        }
        else
          goto label_28;
label_27:
        if ((uint) num3 - (uint) index3 < 0U)
          goto label_23;
label_28:
        val1 = Math.Max(val1, dockControl.MinimumTabWidth);
        goto label_19;
      }
label_33:
      if (num1 > num2)
        goto label_34;
label_13:
      xa358da7dd5364cab = x38870620fd380a6b.TabStripMetrics.RemovePadding(xa358da7dd5364cab);
      if ((uint) index3 - (uint) left <= uint.MaxValue)
      {
        if ((uint) left >= 0U)
          goto label_9;
        else
          goto label_8;
label_1:
        DockControl dockControl;
        if (index2 >= this.xe477cc01ecfef1fb.Count)
        {
          if (0 == 0)
            return;
          if ((uint) num3 <= uint.MaxValue)
            goto label_36;
        }
        else
          dockControl = this.xe477cc01ecfef1fb[index2];
label_8:
        BoxModel tabMetrics = x38870620fd380a6b.TabMetrics;
        if ((uint) val1 > uint.MaxValue)
          goto label_6;
label_5:
        Rectangle rectangle = new Rectangle(left + tabMetrics.Margin.Left, xa358da7dd5364cab.Top + tabMetrics.Margin.Top, tabMetrics.Padding.Left + numArray[index1] + tabMetrics.Padding.Right, xa358da7dd5364cab.Height - (tabMetrics.Margin.Top + tabMetrics.Margin.Bottom));
        if ((uint) left + (uint) num1 < 0U)
          goto label_33;
label_6:
        if ((uint) index1 >= 0U)
        {
          dockControl.x123e054dab107457 = rectangle;
          left += rectangle.Width + tabMetrics.ExtraWidth;
          if ((uint) left <= uint.MaxValue)
          {
            do
            {
              ++index1;
              ++index2;
            }
            while ((uint) index3 - (uint) num1 > uint.MaxValue);
          }
          if (1 == 0)
            return;
          else
            goto label_1;
        }
        else
          goto label_5;
label_9:
        left = xa358da7dd5364cab.Left;
        index1 = 0;
        index2 = 0;
        goto label_1;
      }
      else
        goto label_14;
label_34:
      num3 = num1 - num2;
      for (index3 = 0; index3 < index1; ++index3)
      {
        numArray[index3] -= (int) ((double) num3 * ((double) numArray[index3] / (double) num1));
        this.xe477cc01ecfef1fb[index3].xcfac6723d8a41375 = true;
      }
      goto label_13;
    }

    /// <summary>
    /// A collection of dock controls belonging to a ControlLayoutSystem.
    /// 
    /// </summary>
    public class DockControlCollection : CollectionBase
    {
      private ControlLayoutSystem xb6a159a84cb992d6;
      private bool x6278c23b2376c7c7;
      private bool xa536df1e17daee9d;

      /// <summary>
      /// Returns the dock control at the specified index in the collection.
      /// 
      /// </summary>
      public DockControl this[int index]
      {
        get
        {
          return (DockControl) this.List[index];
        }
      }

      internal DockControlCollection(ControlLayoutSystem parent)
      {
        this.xb6a159a84cb992d6 = parent;
      }

      internal int x259d21cdec19b1cf(int xff665e1cf667e663, bool x1743ddb153315e91)
      {
        if (xff665e1cf667e663 < 0 || xff665e1cf667e663 > this.Count || 0 != 0 && (0 != 0 || (uint) x1743ddb153315e91 - (uint) x1743ddb153315e91 <= uint.MaxValue))
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
      public void SetChildIndex(DockControl control, int index)
      {
        if (control == null)
        {
          if (0 != 0)
          {
            if ((uint) index >= 0U)
              goto label_9;
          }
          else
            goto label_14;
        }
        else
          goto label_10;
label_3:
        this.xa536df1e17daee9d = true;
        this.List.Remove((object) control);
        this.List.Insert(index, (object) control);
        this.xa536df1e17daee9d = false;
        if (8 == 0)
          ;
        this.xb6a159a84cb992d6.x3e0280cae730d1f2();
        if (-1 != 0)
        {
          if ((int) byte.MaxValue != 0)
            return;
          else
            goto label_14;
        }
label_9:
        throw new ArgumentOutOfRangeException("control");
label_10:
        if (this.Contains(control))
        {
          if (-2 != 0)
          {
            if (index == this.IndexOf(control))
              return;
            if (this.IndexOf(control) < index)
            {
              --index;
              goto label_3;
            }
            else
              goto label_3;
          }
          else
            goto label_3;
        }
        else
          goto label_9;
label_14:
        throw new ArgumentNullException("control");
      }

      /// <summary>
      /// Overridden.
      /// 
      /// </summary>
      protected override void OnClear()
      {
        base.OnClear();
        foreach (DockControl dockControl in (CollectionBase) this)
        {
          dockControl.xb2b69aae23a4ae6d((ControlLayoutSystem) null);
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
        this.xb6a159a84cb992d6.SelectedControl = (DockControl) null;
        this.xb6a159a84cb992d6.x3e0280cae730d1f2();
        if (this.xb6a159a84cb992d6.DockContainer == null)
          return;
        this.xb6a159a84cb992d6.DockContainer.x5fc4eceec879ff0f();
      }

      /// <summary>
      /// Overridden.
      /// 
      /// </summary>
      protected override void OnInsertComplete(int index, object value)
      {
        base.OnInsertComplete(index, value);
        if (this.xa536df1e17daee9d)
          return;
        DockControl dockControl = (DockControl) value;
        do
        {
          dockControl.xb2b69aae23a4ae6d(this.xb6a159a84cb992d6);
          if (this.xb6a159a84cb992d6.IsInContainer)
            goto label_20;
          else
            goto label_18;
label_2:
          while (!this.x6278c23b2376c7c7)
          {
            this.xb6a159a84cb992d6.x3e0280cae730d1f2();
            if ((uint) index - (uint) index <= uint.MaxValue)
            {
              if ((int) byte.MaxValue != 0)
                return;
              else
                goto label_8;
            }
          }
          continue;
label_6:
          this.xb6a159a84cb992d6.DockContainer.x5fc4eceec879ff0f();
          goto label_2;
label_7:
          if (this.xb6a159a84cb992d6.DockContainer != null)
            goto label_6;
          else
            goto label_2;
label_8:
          this.xb6a159a84cb992d6.SelectedControl = dockControl;
          goto label_7;
label_16:
          while (this.xb6a159a84cb992d6.IsInContainer)
          {
            dockControl.x56e964269d48cfcc(this.xb6a159a84cb992d6.DockContainer);
            if ((uint) index + (uint) index <= uint.MaxValue)
            {
              if (0 == 0 && 0 == 0)
                break;
            }
            else
              goto label_20;
          }
          do
          {
            if (this.xb6a159a84cb992d6.IsInContainer)
              goto label_12;
label_9:
            if (this.xb6a159a84cb992d6.xbf5c00c8e3dd85fc != null)
              continue;
            else
              goto label_8;
label_12:
            if (dockControl.Parent == null)
            {
              if (0 != 0)
                goto label_18;
            }
            else
              goto label_15;
label_14:
            dockControl.Parent = this.xb6a159a84cb992d6.x0e40cec3a0be4a70;
            if ((uint) index + (uint) index < 0U)
              continue;
            else
              goto label_9;
label_15:
            LayoutUtilities.xa7513d57b4844d46((Control) dockControl);
            goto label_14;
          }
          while ((uint) index > uint.MaxValue);
          if ((uint) index <= uint.MaxValue)
            goto label_7;
          else
            goto label_6;
label_18:
          if ((index & 0) == 0)
            goto label_16;
label_20:
          if (this.xb6a159a84cb992d6.DockContainer.Manager == null)
          {
            if ((uint) index - (uint) index > uint.MaxValue || 0 != 0)
              goto label_18;
            else
              goto label_16;
          }
          else if (this.xb6a159a84cb992d6.DockContainer.Manager != dockControl.Manager)
          {
            if ((index & 0) == 0)
            {
              dockControl.Manager = this.xb6a159a84cb992d6.DockContainer.Manager;
              goto label_16;
            }
            else
              goto label_6;
          }
          else
            goto label_16;
        }
        while ((uint) index - (uint) index < 0U);
      }

      /// <summary>
      /// Overridden.
      /// 
      /// </summary>
      protected override void OnRemoveComplete(int index, object value)
      {
        base.OnRemoveComplete(index, value);
        if ((index | int.MinValue) == 0)
        {
          if (0 == 0)
            goto label_4;
        }
        else
          goto label_16;
label_2:
        if (this.xb6a159a84cb992d6.xe477cc01ecfef1fb.Count != 0)
        {
          this.xb6a159a84cb992d6.SelectedControl = this[0];
        }
        else
        {
          this.xb6a159a84cb992d6.SelectedControl = (DockControl) null;
          if ((int) byte.MaxValue != 0)
          {
            if ((uint) index + (uint) index > uint.MaxValue)
              goto label_16;
          }
          else
            goto label_8;
        }
label_4:
        if (this.xb6a159a84cb992d6.DockContainer != null)
        {
          this.xb6a159a84cb992d6.DockContainer.x5fc4eceec879ff0f();
          if (0 != 0)
            return;
        }
label_6:
        this.xb6a159a84cb992d6.x3e0280cae730d1f2();
        return;
label_8:
        if (0 == 0)
        {
          if ((uint) index - (uint) index > uint.MaxValue)
            return;
        }
        else
          goto label_6;
label_11:
        if (this.xb6a159a84cb992d6.xbf5c00c8e3dd85fc != value)
          goto label_4;
        else
          goto label_2;
label_16:
        if (this.xa536df1e17daee9d)
          return;
        DockControl dockControl = (DockControl) value;
        dockControl.xb2b69aae23a4ae6d((ControlLayoutSystem) null);
        dockControl.x44fd51d909a57a2a();
        while (dockControl.Parent != null)
        {
          if (dockControl.Parent == this.xb6a159a84cb992d6.x0e40cec3a0be4a70)
          {
            LayoutUtilities.xa7513d57b4844d46((Control) dockControl);
            if ((uint) index + (uint) index <= uint.MaxValue)
              goto label_11;
          }
          else
            goto label_11;
        }
        if ((uint) index >= 0U)
          goto label_8;
        else
          goto label_4;
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
      public void AddRange(DockControl[] controls)
      {
        this.x6278c23b2376c7c7 = true;
        do
        {
          DockControl[] dockControlArray = controls;
          int index = 0;
label_3:
          if (index < dockControlArray.Length)
          {
            this.Add(dockControlArray[index]);
            do
            {
              ++index;
            }
            while (8 == 0);
            goto label_3;
          }
          else
          {
            this.x6278c23b2376c7c7 = false;
            this.xb6a159a84cb992d6.x3e0280cae730d1f2();
          }
        }
        while (0 != 0);
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
        if (this.List.Contains((object) control))
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
      public void Insert(int index, DockControl control)
      {
        if (control == null)
          return;
        if (control.LayoutSystem != this.xb6a159a84cb992d6)
          goto label_8;
        else
          goto label_17;
label_1:
        if (1 == 0)
          goto label_5;
        else
          goto label_3;
label_2:
        if ((uint) index > uint.MaxValue)
          goto label_1;
label_3:
        control.LayoutSystem.Controls.Remove(control);
label_4:
        this.List.Insert(index, (object) control);
        return;
label_5:
        if (this.Contains(control))
        {
          if (this.IndexOf(control) < index)
          {
            --index;
            goto label_1;
          }
          else
            goto label_2;
        }
        else
          goto label_3;
label_8:
        if (control.LayoutSystem == null)
          goto label_4;
        else
          goto label_5;
label_17:
        if (this.IndexOf(control) == index)
          return;
label_10:
        while (this.Count != 1)
        {
          while ((uint) index - (uint) index > uint.MaxValue || (uint) index + (uint) index > uint.MaxValue)
          {
            if (0 == 0)
            {
              if ((uint) index + (uint) index <= uint.MaxValue)
              {
                if (4 != 0)
                  break;
              }
              else
                goto label_2;
            }
            else
              goto label_10;
          }
          goto label_8;
        }
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
        this.List.Remove((object) control);
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
        return this.List.Contains((object) control);
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
        return this.List.IndexOf((object) control);
      }

      /// <summary>
      /// Copies the contents of the collection in to the given array, starting at the specified offset.
      /// 
      /// </summary>
      /// <param name="array">The array to be copied in to.</param><param name="index">The index to start at.</param>
      public void CopyTo(DockControl[] array, int index)
      {
        this.List.CopyTo((Array) array, index);
      }
    }

    internal delegate void xf09a9df3c262275d(DockControl oldSelection, DockControl newSelection);
  }
}
