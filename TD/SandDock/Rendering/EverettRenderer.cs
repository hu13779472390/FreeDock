// Type: TD.SandDock.Rendering.EverettRenderer
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using FQ.FreeDock;

namespace FQ.FreeDock.Rendering
{
  /// <summary>
  /// Provides a renderer that mimics the appearance of Microsoft Visual Studio.NET 2003.
  /// 
  /// </summary>
  public class EverettRenderer : RendererBase
  {
    private Color xef5f9f8a08f25e70 = SystemColors.InactiveCaption;
    private Color x4978f8b41a50b017 = SystemColors.ActiveCaption;
    private Color x228f9881a1be0e5d = SystemColors.ControlText;
    private Color xfca0e3085d5a7f42 = SystemColors.ControlLightLight;
    private Color x1da108dbfca32343 = SystemColors.ControlDarkDark;
    private Color x9c1f2f40026567ee = SystemColors.ControlDark;
    private Color x488edc060a6f4707 = SystemColors.ControlDarkDark;
    private static StringFormat xdc3f45c33fe25d85;
    private static StringFormat x7553dbb15fca5d00;
    private Color x7f2683d69c01d139;
    private SolidBrush x166a89f4cd379ec8;
    private Pen x7a0be2490cda8794;
    private Pen x050be261498a0c97;
    private Pen xa33e6094d9ed12d6;
    private SolidBrush x54c190ae969c389d;
    private StringFormat x2771fbe8bb84042b;
    private BoxModel _x066f993679e36022;
    private BoxModel _x3a1fa93b40743331;
    private BoxModel _x6defba3d5d846e0d;

    internal static StringFormat x27e1c82c97265861
    {
      get
      {
        if (EverettRenderer.xdc3f45c33fe25d85 == null)
        {
          do
          {
            EverettRenderer.xdc3f45c33fe25d85 = new StringFormat(StringFormat.GenericDefault);
            EverettRenderer.xdc3f45c33fe25d85.Alignment = StringAlignment.Near;
            EverettRenderer.xdc3f45c33fe25d85.LineAlignment = StringAlignment.Center;
          }
          while (0 != 0);
          EverettRenderer.xdc3f45c33fe25d85.Trimming = StringTrimming.EllipsisCharacter;
          EverettRenderer.xdc3f45c33fe25d85.FormatFlags |= StringFormatFlags.NoWrap;
        }
        return EverettRenderer.xdc3f45c33fe25d85;
      }
    }

    internal static StringFormat xc351c68a86733972
    {
      get
      {
        if (EverettRenderer.x7553dbb15fca5d00 == null)
        {
          EverettRenderer.x7553dbb15fca5d00 = new StringFormat(StringFormat.GenericDefault);
          EverettRenderer.x7553dbb15fca5d00.Alignment = StringAlignment.Near;
          if (0 == 0)
            EverettRenderer.x7553dbb15fca5d00.LineAlignment = StringAlignment.Center;
          EverettRenderer.x7553dbb15fca5d00.Trimming = StringTrimming.EllipsisCharacter;
          EverettRenderer.x7553dbb15fca5d00.FormatFlags |= StringFormatFlags.NoWrap;
          EverettRenderer.x7553dbb15fca5d00.FormatFlags |= StringFormatFlags.DirectionVertical;
        }
        return EverettRenderer.x7553dbb15fca5d00;
      }
    }

    /// <summary>
    /// The colour to draw the outline of collapsed tabs.
    /// 
    /// </summary>
    public Color CollapsedTabOutlineColor
    {
      get
      {
        return this.x9c1f2f40026567ee;
      }
      set
      {
        this.x9c1f2f40026567ee = value;
        this.CustomColors = true;
      }
    }

    /// <summary>
    /// The colour to draw the text on non-selected tabs.
    /// 
    /// </summary>
    public Color BackgroundTabForeColor
    {
      get
      {
        return this.x1da108dbfca32343;
      }
      set
      {
        this.x1da108dbfca32343 = value;
      }
    }

    /// <summary>
    /// The colour to draw the highlights on 3d objects with.
    /// 
    /// </summary>
    public Color HighlightColor
    {
      get
      {
        return this.xfca0e3085d5a7f42;
      }
      set
      {
        this.xfca0e3085d5a7f42 = value;
        this.CustomColors = true;
      }
    }

    /// <summary>
    /// The colour to draw the shadows on 3d objects with.
    /// 
    /// </summary>
    public Color ShadowColor
    {
      get
      {
        return this.x228f9881a1be0e5d;
      }
      set
      {
        this.x228f9881a1be0e5d = value;
        this.CustomColors = true;
      }
    }

    /// <summary>
    /// The colour to draw the background of tabstrips with.
    /// 
    /// </summary>
    public Color TabStripBackgroundColor
    {
      get
      {
        return this.x7f2683d69c01d139;
      }
    }

    /// <summary>
    /// The colour to draw the background of inactive titlebars with.
    /// 
    /// </summary>
    public Color InactiveTitleBarColor
    {
      get
      {
        return this.xef5f9f8a08f25e70;
      }
      set
      {
        this.xef5f9f8a08f25e70 = value;
        this.CustomColors = true;
      }
    }

    /// <summary>
    /// The colours to draw the background of active titlebars with.
    /// 
    /// </summary>
    public Color ActiveTitleBarColor
    {
      get
      {
        return this.x4978f8b41a50b017;
      }
      set
      {
        this.x4978f8b41a50b017 = value;
        this.CustomColors = true;
      }
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override TabTextDisplayMode TabTextDisplay
    {
      get
      {
        return TabTextDisplayMode.SelectedTab;
      }
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override BoxModel TitleBarMetrics
    {
      get
      {
        if (this._x6defba3d5d846e0d == null)
          this._x6defba3d5d846e0d = new BoxModel(0, SystemInformation.ToolWindowCaptionHeight + 2, 0, 0, 0, 0, 0, 0, 0, 2);
        return this._x6defba3d5d846e0d;
      }
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override BoxModel TabMetrics
    {
      get
      {
        if (this._x3a1fa93b40743331 == null)
          this._x3a1fa93b40743331 = new BoxModel(0, 0, 0, 0, 0, 0, 0, 0, 1, 0);
        return this._x3a1fa93b40743331;
      }
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override BoxModel TabStripMetrics
    {
      get
      {
        if (this._x066f993679e36022 == null)
          this._x066f993679e36022 = new BoxModel(0, Control.DefaultFont.Height + 9, 4, 0, 5, 1, 0, 2, 0, 0);
        return this._x066f993679e36022;
      }
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    public override System.Drawing.Size TabControlPadding
    {
      get
      {
        return new System.Drawing.Size(3, 3);
      }
    }

    internal virtual int xe5ad29d0f658e81f
    {
      get
      {
        return 5;
      }
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override int DocumentTabSize
    {
      get
      {
        return Control.DefaultFont.Height + 6;
      }
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override int DocumentTabStripSize
    {
      get
      {
        return Control.DefaultFont.Height + 8;
      }
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override int DocumentTabExtra
    {
      get
      {
        return 0;
      }
    }

    static EverettRenderer()
    {
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected override void GetColorsFromSystem()
    {
      this.x7f2683d69c01d139 = this.x2c04503a704e817c(SystemColors.Control);
    }

    private Color x2c04503a704e817c(Color xdd0e633cf3dbad19)
    {
      byte r = xdd0e633cf3dbad19.R;
      byte num1;
      if (((int) num1 | -2) != 0)
        goto label_10;
label_6:
      byte g;
      byte num2;
      byte b;
      int num3;
      while ((int) num2 > 220)
      {
        if (((int) r | -1) != 0)
          goto label_2;
        else
          goto label_8;
label_1:
        if ((uint) b > uint.MaxValue)
          continue;
        else
          goto label_3;
label_2:
        if ((uint) g > uint.MaxValue)
          goto label_1;
label_3:
        num3 = (int) (byte) ((uint) byte.MaxValue - (uint) num2);
        goto label_4;
label_8:
        if ((uint) num2 <= uint.MaxValue)
          goto label_1;
      }
      goto label_5;
label_4:
      byte num4 = (byte) num3;
      return Color.FromArgb((int) (byte) ((uint) r + (uint) (byte) ((double) num4 * ((double) r / (double) num2) + 0.5)), (int) (byte) ((uint) g + (uint) (byte) ((double) num4 * ((double) g / (double) num2) + 0.5)), (int) (byte) ((uint) b + (uint) (byte) ((double) num4 * ((double) b / (double) num2) + 0.5)));
label_5:
      num3 = 35;
      goto label_4;
label_10:
      g = xdd0e633cf3dbad19.G;
      b = xdd0e633cf3dbad19.B;
      num2 = Math.Max(Math.Max(r, g), b);
      if ((int) num2 == 0)
        return Color.FromArgb(35, 35, 35);
      else
        goto label_6;
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override Rectangle AdjustDockControlClientBounds(ControlLayoutSystem layoutSystem, DockControl control, Rectangle clientBounds)
    {
      if (!(layoutSystem is DocumentLayoutSystem))
        return base.AdjustDockControlClientBounds(layoutSystem, control, clientBounds);
      clientBounds.Inflate(-2, -2);
      return clientBounds;
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override void DrawControlClientBackground(Graphics graphics, Rectangle bounds, Color backColor)
    {
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override void DrawDocumentClientBackground(Graphics graphics, Rectangle bounds, Color backColor)
    {
      using (SolidBrush solidBrush = new SolidBrush(backColor))
        graphics.FillRectangle((Brush) solidBrush, bounds);
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override void DrawDocumentStripBackground(Graphics graphics, Rectangle bounds)
    {
      graphics.FillRectangle((Brush) this.x166a89f4cd379ec8, bounds);
      graphics.DrawLine(this.x050be261498a0c97, bounds.X, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override void DrawDockContainerBackground(Graphics graphics, DockContainer container, Rectangle bounds)
    {
      xa811784015ed8842.x91433b5e99eb7cac(graphics, container.BackColor);
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override System.Drawing.Size MeasureTabStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
    {
      return new System.Drawing.Size((int) Math.Ceiling((double) graphics.MeasureString(text, font, int.MaxValue, this.x2771fbe8bb84042b).Width) + 30, 18);
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override System.Drawing.Size MeasureDocumentStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
    {
      if ((state & DrawItemState.Focus) != DrawItemState.Focus)
        goto label_10;
      else
        goto label_5;
label_1:
      int num;
      return new System.Drawing.Size(num + this.DocumentTabExtra, 0);
label_2:
      num += 2 + this.xe5ad29d0f658e81f * 2 + 2;
      if ((num | 4) != 0 && image == null)
      {
        if (4 != 0)
          goto label_1;
        else
          goto label_5;
      }
label_3:
      num += 20;
      goto label_1;
label_5:
      using (Font font1 = new Font(font, FontStyle.Bold))
      {
        num = (int) Math.Ceiling((double) graphics.MeasureString(text, font1, 999, this.x2771fbe8bb84042b).Width);
        goto label_2;
      }
label_10:
      num = (int) Math.Ceiling((double) graphics.MeasureString(text, font, 999, this.x2771fbe8bb84042b).Width);
      if ((uint) num < 0U)
        goto label_3;
      else
        goto label_2;
    }

    /// <summary>
    /// Overridden,
    /// 
    /// </summary>
    protected internal override void DrawDocumentStripTab(Graphics graphics, Rectangle bounds, Rectangle contentBounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
    {
      if ((state & DrawItemState.Selected) != DrawItemState.Selected)
        goto label_17;
      else
        goto label_20;
label_1:
      Font font1;
      font1.Dispose();
      return;
label_17:
      if (drawSeparator)
      {
        graphics.DrawLine(SystemPens.ControlDark, bounds.Right, bounds.Top + 3, bounds.Right, bounds.Bottom - 3);
        if ((uint) drawSeparator < 0U)
          goto label_1;
      }
label_19:
      bounds = contentBounds;
      if (image == null)
      {
        if (0 != 0)
          goto label_16;
      }
      else
        goto label_15;
label_13:
      if (bounds.Width <= 8)
        return;
      font1 = font;
      if ((uint) drawSeparator < 0U || (state & DrawItemState.Focus) == DrawItemState.Focus)
        goto label_10;
label_8:
      if ((state & DrawItemState.Selected) == DrawItemState.Selected)
        goto label_3;
      else
        goto label_9;
label_2:
      if ((state & DrawItemState.Focus) != DrawItemState.Focus)
        return;
      else
        goto label_1;
label_3:
      using (SolidBrush solidBrush = new SolidBrush(foreColor))
      {
        graphics.DrawString(text, font1, (Brush) solidBrush, (RectangleF) bounds, this.x2771fbe8bb84042b);
        goto label_2;
      }
label_9:
      graphics.DrawString(text, font1, (Brush) this.x54c190ae969c389d, (RectangleF) bounds, this.x2771fbe8bb84042b);
      goto label_2;
label_10:
      font1 = new Font(font, FontStyle.Bold);
      goto label_8;
label_15:
      graphics.DrawImage(image, bounds.X + 4, bounds.Y + 2, 16, 16);
label_16:
      bounds.X += 20;
      bounds.Width -= 20;
      goto label_13;
label_20:
      using (SolidBrush solidBrush = new SolidBrush(backColor))
        graphics.FillRectangle((Brush) solidBrush, bounds);
      graphics.DrawLine(this.x050be261498a0c97, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
      graphics.DrawLine(this.x050be261498a0c97, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
      graphics.DrawLine(this.x7a0be2490cda8794, bounds.Right - 1, bounds.Top + 1, bounds.Right - 1, bounds.Bottom - 1);
      goto label_19;
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    public override void StartRenderSession(HotkeyPrefix hotKeys)
    {
      this.x166a89f4cd379ec8 = new SolidBrush(this.x7f2683d69c01d139);
      do
      {
        this.x7a0be2490cda8794 = new Pen(this.x228f9881a1be0e5d);
        if (8 != 0)
        {
          this.x050be261498a0c97 = new Pen(this.xfca0e3085d5a7f42);
          this.x54c190ae969c389d = new SolidBrush(this.x1da108dbfca32343);
          this.xa33e6094d9ed12d6 = new Pen(this.x9c1f2f40026567ee);
          this.x2771fbe8bb84042b = new StringFormat(StringFormat.GenericDefault);
        }
        this.x2771fbe8bb84042b.FormatFlags = StringFormatFlags.NoWrap;
        if (0 == 0)
        {
          this.x2771fbe8bb84042b.Alignment = StringAlignment.Center;
          this.x2771fbe8bb84042b.LineAlignment = StringAlignment.Center;
          this.x2771fbe8bb84042b.HotkeyPrefix = hotKeys;
        }
        else
          goto label_2;
      }
      while (0 != 0);
      return;
label_2:;
    }

    /// <summary>
    /// Overridden,
    /// 
    /// </summary>
    protected internal override void DrawSplitter(Control container, Control control, Graphics graphics, Rectangle bounds, Orientation orientation)
    {
    }

    /// <summary>
    /// Overridden,
    /// 
    /// </summary>
    protected internal override void DrawDocumentStripButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state)
    {
      this.x9271fbf5eef553db(graphics, bounds, state);
      do
      {
        if ((state & DrawItemState.Selected) == DrawItemState.Selected)
          goto label_14;
label_12:
        switch (buttonType)
        {
          case SandDockButtonType.Close:
            goto label_2;
          case SandDockButtonType.Pin:
            goto label_8;
          case SandDockButtonType.ScrollLeft:
            x9b2777bb8e78938b.xd70a4c1a2378c84e(graphics, bounds, this.x488edc060a6f4707, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
            if (4 == 0)
              goto case 5;
            else
              goto label_15;
          case SandDockButtonType.ScrollRight:
            goto label_1;
          case SandDockButtonType.WindowPosition:
            goto label_16;
          case SandDockButtonType.ActiveFiles:
            x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, SystemPens.ControlText);
            continue;
          default:
            goto label_10;
        }
label_14:
        bounds.Offset(1, 1);
        if (0 == 0 && 0 == 0)
          goto label_12;
      }
      while (0 != 0);
      goto label_13;
label_1:
      x9b2777bb8e78938b.x793dc1a7cf4113f9(graphics, bounds, this.x488edc060a6f4707, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
      return;
label_2:
      using (Pen x90279591611601bc = new Pen(this.x488edc060a6f4707))
      {
        x9b2777bb8e78938b.xb176aa01ddab9f3e(graphics, bounds, x90279591611601bc);
        return;
      }
label_13:
      return;
label_15:
      return;
label_16:
      return;
label_8:
      return;
label_10:;
    }

    internal virtual void x9271fbf5eef553db(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DrawItemState x01b557925841ae51)
    {
      if ((x01b557925841ae51 & DrawItemState.HotLight) != DrawItemState.HotLight)
        return;
      if (0 == 0)
        goto label_4;
label_2:
      Pen pen1;
      x41347a961b838962.DrawLine(pen1, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1);
      if (0 == 0)
        return;
label_4:
      Pen pen2;
      while ((x01b557925841ae51 & DrawItemState.Selected) == DrawItemState.Selected)
      {
        pen2 = this.x7a0be2490cda8794;
        if (0 == 0)
        {
          if (0 == 0)
          {
            pen1 = this.x050be261498a0c97;
            goto label_6;
          }
        }
        else
          goto label_2;
      }
      pen1 = this.x7a0be2490cda8794;
      pen2 = this.x050be261498a0c97;
label_6:
      x41347a961b838962.DrawLine(pen2, xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
      x41347a961b838962.DrawLine(pen2, xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1);
      x41347a961b838962.DrawLine(pen1, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
      if (0 == 0)
        goto label_2;
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override void DrawTitleBarButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state, bool focused, bool toggled)
    {
      --bounds.Width;
      if ((uint) focused + (uint) toggled <= uint.MaxValue)
        goto label_9;
label_4:
      SandDockButtonType sandDockButtonType = buttonType;
      if ((uint) focused > uint.MaxValue)
        goto label_11;
label_5:
      switch (sandDockButtonType)
      {
        case SandDockButtonType.Close:
          x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, focused ? SystemPens.ActiveCaptionText : SystemPens.ControlText);
          return;
        case SandDockButtonType.Pin:
          x9b2777bb8e78938b.x1477b5a75c8a8132(graphics, bounds, focused ? SystemPens.ActiveCaptionText : SystemPens.ControlText, toggled);
          return;
        case SandDockButtonType.ScrollLeft:
          return;
        case SandDockButtonType.ScrollRight:
          return;
        case SandDockButtonType.WindowPosition:
          x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, focused ? SystemPens.ActiveCaptionText : SystemPens.ControlText);
          return;
        default:
          return;
      }
label_9:
      --bounds.Height;
      if ((uint) toggled <= uint.MaxValue)
        this.x9271fbf5eef553db(graphics, bounds, state);
      else
        goto label_5;
label_11:
      if ((state & DrawItemState.Selected) == DrawItemState.Selected)
      {
        bounds.Offset(1, 1);
        goto label_4;
      }
      else
        goto label_4;
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override void DrawTabStripBackground(Control container, Control control, Graphics graphics, Rectangle bounds, int selectedTabOffset)
    {
      graphics.FillRectangle((Brush) this.x166a89f4cd379ec8, bounds);
      graphics.DrawLine(this.x7a0be2490cda8794, bounds.X, bounds.Y, bounds.Right, bounds.Y);
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override void DrawTabStripTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
    {
      if ((state & DrawItemState.Selected) != DrawItemState.Selected)
        goto label_15;
      else
        goto label_23;
label_2:
      using (SolidBrush solidBrush = new SolidBrush(foreColor))
      {
        graphics.DrawString(text, font, (Brush) solidBrush, (RectangleF) bounds, EverettRenderer.x27e1c82c97265861);
        return;
      }
label_12:
      do
      {
        if (bounds.Width >= 24)
          goto label_13;
label_8:
        bounds.X += 23;
        if ((uint) drawSeparator - (uint) drawSeparator >= 0U)
        {
          bounds.Width -= 25;
          if (((drawSeparator ? 1 : 0) & 0) == 0 && bounds.Width <= 8)
            continue;
          else
            goto label_1;
        }
        else
          goto label_7;
label_13:
        graphics.DrawImage(image, new Rectangle(bounds.X + 4, bounds.Y + 2, image.Width, image.Height));
        goto label_8;
      }
      while ((uint) drawSeparator > uint.MaxValue);
      goto label_14;
label_1:
      if ((state & DrawItemState.Selected) == DrawItemState.Selected)
        goto label_2;
label_7:
      graphics.DrawString(text, font, (Brush) this.x54c190ae969c389d, (RectangleF) bounds, EverettRenderer.x27e1c82c97265861);
      return;
label_14:
      if ((uint) drawSeparator >= 0U)
        return;
      else
        goto label_23;
label_15:
      if (!drawSeparator)
      {
        if ((uint) drawSeparator >= 0U)
        {
          if ((uint) drawSeparator < 0U)
            return;
          if ((uint) drawSeparator - (uint) drawSeparator >= 0U)
          {
            if (((drawSeparator ? 1 : 0) & 0) == 0)
              goto label_12;
            else
              goto label_23;
          }
        }
        else
          goto label_2;
      }
      else
      {
        graphics.DrawLine(SystemPens.ControlDark, bounds.Right, bounds.Top + 3, bounds.Right, bounds.Bottom - 3);
        goto label_12;
      }
label_21:
      graphics.DrawLine(this.x050be261498a0c97, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
      graphics.DrawLine(this.x7a0be2490cda8794, bounds.Left, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
      graphics.DrawLine(this.x7a0be2490cda8794, bounds.Right, bounds.Top, bounds.Right, bounds.Bottom - 1);
      goto label_12;
label_23:
      using (SolidBrush solidBrush = new SolidBrush(backColor))
      {
        graphics.FillRectangle((Brush) solidBrush, bounds);
        goto label_21;
      }
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override void DrawAutoHideBarBackground(Control container, Control autoHideBar, Graphics graphics, Rectangle bounds)
    {
      using (this.x166a89f4cd379ec8 = new SolidBrush(this.x7f2683d69c01d139))
        graphics.FillRectangle((Brush) this.x166a89f4cd379ec8, bounds);
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override void DrawCollapsedTab(Graphics graphics, Rectangle bounds, DockSide dockSide, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool vertical)
    {
      using (SolidBrush solidBrush = new SolidBrush(backColor))
        graphics.FillRectangle((Brush) solidBrush, bounds);
      if (dockSide == DockSide.Top)
        goto label_19;
      else
        goto label_22;
label_6:
      graphics.DrawString(text, font, (Brush) this.x54c190ae969c389d, (RectangleF) bounds, EverettRenderer.xc351c68a86733972);
      if (0 != 0)
        return;
      else
        return;
label_8:
      if (!vertical)
      {
        bounds.Offset(23, 0);
        graphics.DrawString(text, font, (Brush) this.x54c190ae969c389d, (RectangleF) bounds, EverettRenderer.x27e1c82c97265861);
        return;
      }
      else
      {
        bounds.Offset(0, 23);
        if (15 != 0)
          goto label_6;
      }
label_11:
      if (dockSide != DockSide.Left)
      {
        graphics.DrawLine(this.xa33e6094d9ed12d6, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom);
        goto label_16;
      }
label_12:
      bounds.Inflate(-2, -2);
      if (!vertical)
        goto label_10;
      else
        goto label_13;
label_7:
      graphics.DrawImage(image, new Rectangle(bounds.Left, bounds.Top, image.Width, image.Height));
      if (text.Length == 0)
        return;
      else
        goto label_8;
label_10:
      bounds.Offset(1, 0);
      goto label_7;
label_13:
      bounds.Offset(0, 1);
      if (((vertical ? 1 : 0) & 0) == 0)
        goto label_7;
      else
        goto label_6;
label_16:
      if (0 == 0)
        goto label_12;
      else
        goto label_11;
label_19:
      if (dockSide != DockSide.Right)
        goto label_25;
      else
        goto label_20;
label_14:
      if (dockSide == DockSide.Bottom)
        goto label_11;
label_18:
      graphics.DrawLine(this.xa33e6094d9ed12d6, bounds.Left, bounds.Bottom, bounds.Right, bounds.Bottom);
      goto label_11;
label_20:
      if (0 == 0)
      {
        if (0 != 0)
        {
          if ((uint) vertical > uint.MaxValue)
            goto label_24;
          else
            goto label_18;
        }
        else
          goto label_14;
      }
      else
        goto label_16;
label_25:
      graphics.DrawLine(this.xa33e6094d9ed12d6, bounds.Right, bounds.Top, bounds.Right, bounds.Bottom);
      goto label_14;
label_22:
      if (0 == 0)
      {
        if (0 != 0)
          return;
      }
      else
        goto label_8;
label_24:
      graphics.DrawLine(this.xa33e6094d9ed12d6, bounds.Left, bounds.Top, bounds.Right, bounds.Top);
      goto label_19;
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override void DrawTitleBarBackground(Graphics graphics, Rectangle bounds, bool focused)
    {
      if (!focused)
        goto label_4;
label_2:
      graphics.FillRectangle(SystemBrushes.ActiveCaption, bounds);
      if ((uint) focused + (uint) focused <= uint.MaxValue)
        return;
      else
        goto label_5;
label_4:
      graphics.FillRectangle(SystemBrushes.Control, bounds);
label_5:
      graphics.DrawLine(SystemPens.ControlDark, bounds.X + 1, bounds.Y, bounds.Right - 2, bounds.Y);
      graphics.DrawLine(SystemPens.ControlDark, bounds.X + 1, bounds.Bottom - 1, bounds.Right - 2, bounds.Bottom - 1);
      graphics.DrawLine(SystemPens.ControlDark, bounds.X, bounds.Y + 1, bounds.X, bounds.Bottom - 2);
      graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 1, bounds.Y + 1, bounds.Right - 1, bounds.Bottom - 2);
      if (0 != 0)
        goto label_2;
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    protected internal override void DrawTitleBarText(Graphics graphics, Rectangle bounds, bool focused, string text, Font font)
    {
      Brush brush = focused ? SystemBrushes.ActiveCaptionText : SystemBrushes.ControlText;
      bounds.Inflate(-3, 0);
      graphics.DrawString(text, font, brush, (RectangleF) bounds, EverettRenderer.x27e1c82c97265861);
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    public override void FinishRenderSession()
    {
      this.x166a89f4cd379ec8.Dispose();
      this.x7a0be2490cda8794.Dispose();
      if (0 != 0)
        ;
      this.x050be261498a0c97.Dispose();
      this.x54c190ae969c389d.Dispose();
      this.xa33e6094d9ed12d6.Dispose();
      this.x2771fbe8bb84042b.Dispose();
    }

    /// <summary>
    /// Overridden.
    /// 
    /// </summary>
    public override string ToString()
    {
      return "Everett";
    }
  }
}
