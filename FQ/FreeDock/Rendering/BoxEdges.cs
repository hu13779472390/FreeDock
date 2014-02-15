// Type: TD.SandDock.Rendering.BoxEdges
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

namespace FQ.FreeDock.Rendering
{
  /// <summary>
  /// Represents the measurements of the edges of a container.
  /// 
  /// </summary>
  public class BoxEdges
  {
    private int xa447fc54e41dfe06;
    private int xc941868c59399d3e;
    private int xaf9a0436a70689de;
    private int xfc2074a859a5db8c;

    /// <summary>
    /// The left dimension.
    /// 
    /// </summary>
    public int Left
    {
      get
      {
        return this.xa447fc54e41dfe06;
      }
    }

    /// <summary>
    /// The top dimension.
    /// 
    /// </summary>
    public int Top
    {
      get
      {
        return this.xc941868c59399d3e;
      }
    }

    /// <summary>
    /// The right dimension.
    /// 
    /// </summary>
    public int Right
    {
      get
      {
        return this.xfc2074a859a5db8c;
      }
    }

    /// <summary>
    /// The bottom dimension.
    /// 
    /// </summary>
    public int Bottom
    {
      get
      {
        return this.xaf9a0436a70689de;
      }
    }

    /// <summary>
    /// Initializes a new instance of the BoxEdges class.
    /// 
    /// </summary>
    public BoxEdges()
    {
    }

    /// <summary>
    /// Initializes a new instance of the BoxEdges class, with the specified dimensions.
    /// 
    /// </summary>
    /// <param name="left">The left dimension.</param><param name="top">The top dimension.</param><param name="right">The right dimension.</param><param name="bottom">The bottom dimension.</param>
    public BoxEdges(int left, int top, int right, int bottom)
    {
      this.xa447fc54e41dfe06 = left;
      this.xc941868c59399d3e = top;
      this.xfc2074a859a5db8c = right;
      this.xaf9a0436a70689de = bottom;
    }
  }
}
