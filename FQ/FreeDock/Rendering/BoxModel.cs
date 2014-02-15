// Type: TD.SandDock.Rendering.BoxModel
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System.Drawing;

namespace FQ.FreeDock.Rendering
{
  /// <summary>
  /// Represents a "box" modelled with width, height, margin and padding metrics.
  /// 
  /// </summary>
  public class BoxModel
  {
    private BoxEdges x13ebc58426767551;
    private BoxEdges xcaf2e4729806e32b;
    private int x9b0739496f8b5475;
    private int x4d5aabc7a55b12ba;

    /// <summary>
    /// Gets the width to add to a measurement, governed by the left and right margin and padding values.
    /// 
    /// </summary>
    public int ExtraWidth
    {
      get
      {
        return this.x13ebc58426767551.Left + this.x13ebc58426767551.Right + this.xcaf2e4729806e32b.Left + this.xcaf2e4729806e32b.Right;
      }
    }

    /// <summary>
    /// Gets the height to add to a measurement, governed by the top and bottom margin and padding values.
    /// 
    /// </summary>
    public int ExtraHeight
    {
      get
      {
        return this.x13ebc58426767551.Top + this.x13ebc58426767551.Bottom + this.xcaf2e4729806e32b.Top + this.xcaf2e4729806e32b.Bottom;
      }
    }

    /// <summary>
    /// Gets the size of the box, without the margin values.
    /// 
    /// </summary>
    public Size InnerSize
    {
      get
      {
        return new Size(this.x9b0739496f8b5475 - this.x13ebc58426767551.Left - this.x13ebc58426767551.Right, this.x4d5aabc7a55b12ba - this.x13ebc58426767551.Top - this.x13ebc58426767551.Bottom);
      }
    }

    /// <summary>
    /// Gets/sets the height of the box.
    /// 
    /// </summary>
    public int Height
    {
      get
      {
        return this.x4d5aabc7a55b12ba;
      }
      set
      {
        this.x4d5aabc7a55b12ba = value;
      }
    }

    /// <summary>
    /// Gets/sets the width of the box.
    /// 
    /// </summary>
    public int Width
    {
      get
      {
        return this.x9b0739496f8b5475;
      }
      set
      {
        this.x9b0739496f8b5475 = value;
      }
    }

    /// <summary>
    /// Gets/sets the margin of the box.
    /// 
    /// </summary>
    public BoxEdges Margin
    {
      get
      {
        return this.x13ebc58426767551;
      }
      set
      {
        this.x13ebc58426767551 = value;
      }
    }

    /// <summary>
    /// Gets/sets the padding of the box.
    /// 
    /// </summary>
    public BoxEdges Padding
    {
      get
      {
        return this.xcaf2e4729806e32b;
      }
      set
      {
        this.xcaf2e4729806e32b = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the BoxModel class.
    /// 
    /// </summary>
    public BoxModel()
    {
      this.x13ebc58426767551 = new BoxEdges();
      this.xcaf2e4729806e32b = new BoxEdges();
    }

    /// <summary>
    /// Initializes a new instance of the BoxModel class, with the specified measurements.
    /// 
    /// </summary>
    /// <param name="width">The width of the box.</param><param name="height">The height of the box.</param><param name="paddingLeft">The left padding dimension.</param><param name="paddingTop">The top padding dimension.</param><param name="paddingRight">The right padding dimension.</param><param name="paddingBottom">The bottom padding dimension.</param><param name="marginLeft">The left margin dimension.</param><param name="marginTop">The top margin dimension.</param><param name="marginRight">The right margin dimension.</param><param name="marginBottom">The bottom margin dimension.</param>
    public BoxModel(int width, int height, int paddingLeft, int paddingTop, int paddingRight, int paddingBottom, int marginLeft, int marginTop, int marginRight, int marginBottom)
    {
      this.x9b0739496f8b5475 = width;
      this.x4d5aabc7a55b12ba = height;
      this.xcaf2e4729806e32b = new BoxEdges(paddingLeft, paddingTop, paddingRight, paddingBottom);
      this.x13ebc58426767551 = new BoxEdges(marginLeft, marginTop, marginRight, marginBottom);
    }

    /// <summary>
    /// Adjusts the specified rectangle to account for the configured padding values.
    /// 
    /// </summary>
    /// <param name="source">The rectangle to adjust.</param>
    /// <returns>
    /// A new rectangle without space taken up with padding.
    /// </returns>
    public Rectangle RemovePadding(Rectangle source)
    {
      source.X += this.xcaf2e4729806e32b.Left;
      source.Y += this.xcaf2e4729806e32b.Top;
      source.Width -= this.xcaf2e4729806e32b.Left + this.xcaf2e4729806e32b.Right;
      source.Height -= this.xcaf2e4729806e32b.Top + this.xcaf2e4729806e32b.Bottom;
      return source;
    }

    /// <summary>
    /// Adjusts the specified rectangle to account for the configured margin values.
    /// 
    /// </summary>
    /// <param name="source">The rectangle to adjust.</param>
    /// <returns>
    /// A new rectangle without space taken up with margin.
    /// </returns>
    public Rectangle RemoveMargin(Rectangle source)
    {
      source.X += this.x13ebc58426767551.Left;
      source.Y += this.x13ebc58426767551.Top;
      source.Width -= this.x13ebc58426767551.Left + this.x13ebc58426767551.Right;
      source.Height -= this.x13ebc58426767551.Top + this.x13ebc58426767551.Bottom;
      return source;
    }
  }
}
