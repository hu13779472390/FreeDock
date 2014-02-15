// Type: TD.SandDock.Rendering.ITabControlRenderer
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FQ.FreeDock.Rendering
{
  /// <summary>
  /// An interface defining a set of methods used to draw a tab control.
  /// 
  /// </summary>
  public interface ITabControlRenderer
  {
    /// <summary>
    /// Determines whether the renderer should draw on to the client area of a tab page.
    /// 
    /// </summary>
    bool ShouldDrawTabControlBackground { get; }

    /// <summary>
    /// Gets the amount of extra space around a tab.
    /// 
    /// </summary>
    int TabControlTabExtra { get; }

    /// <summary>
    /// Gets the height of a normal, single line tabstrip.
    /// 
    /// </summary>
    int TabControlTabStripHeight { get; }

    /// <summary>
    /// Gets the height of a tab.
    /// 
    /// </summary>
    int TabControlTabHeight { get; }

    /// <summary>
    /// Gets the amount of padding to use around TabPages.
    /// 
    /// </summary>
    Size TabControlPadding { get; }

    /// <summary>
    /// Indicates whether the TabControl should draw its own border when used with this renderer.
    /// 
    /// </summary>
    bool ShouldDrawControlBorder { get; }

    /// <summary>
    /// Draws a portion of the background of a tab page that is not part of the client area and is not part of the border either.
    /// 
    /// </summary>
    /// <param name="graphics">The Graphics object to draw with.</param><param name="bounds">The bounds of the area to draw.</param><param name="backColor">The background colour of the tab whose background should be drawn.</param>
    /// <remarks>
    /// 
    /// <para>
    /// When using the MultipleLine tab layout style, it is sometimes possible to see "through" lower tabs. In this case it needs to appear like the background of an upper tab is visible.
    /// </para>
    /// 
    /// </remarks>
    void DrawFakeTabControlBackgroundExtension(Graphics graphics, Rectangle bounds, Color backColor);

    /// <summary>
    /// Draws a button on a tab control.
    /// 
    /// </summary>
    /// <param name="graphics">The Graphics object to draw with.</param><param name="bounds">The region occupied by the button.</param><param name="buttonType">The type of button to draw.</param><param name="state">The state of the button.</param>
    void DrawTabControlButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state);

    /// <summary>
    /// Draws the background of a tab page.
    /// 
    /// </summary>
    /// <param name="graphics">The Graphics object to draw with.</param><param name="bounds">The bounds occupied by the tab.</param><param name="backColor">The background colour of the tab.</param><param name="client">Whether to draw the client area of a tab page (on the TabPage itself) or the border (on the parent TabControl).</param>
    /// <remarks>
    /// 
    /// <para>
    /// This method is always called to draw the portion of the visible tab page that is actually on the parent TabControl, i.e. the border. If the ShouldDrawTabControlBackground property returns true,
    ///             it is also used to directly draw the client area of the TabControl. To determine which scenario is happening, use the client parameter.
    /// </para>
    /// 
    /// </remarks>
    void DrawTabControlBackground(Graphics graphics, Rectangle bounds, Color backColor, bool client);

    /// <summary>
    /// Draws a tab.
    /// 
    /// </summary>
    /// <param name="graphics">The Graphics object to draw with.</param><param name="bounds">The bounds occupied by the tab.</param><param name="image">The image associated with the tab.</param><param name="text">The text associated with the tab.</param><param name="font">The font to draw text with.</param><param name="backColor">The background colour of the tab.</param><param name="foreColor">The foreground colour of the tab.</param><param name="state">The state of the tab.</param><param name="drawSeparator">Whether to draw a separator after the tab.</param>
    void DrawTabControlTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator);

    /// <summary>
    /// Measures a tab in order to find the minimum required size.
    /// 
    /// </summary>
    /// <param name="graphics">The Graphics object to measure with.</param><param name="image">The image of the document tab.</param><param name="text">The text of the document tab.</param><param name="font">The font to render text with.</param><param name="state">The state of the document tab.</param>
    /// <returns>
    /// The minimum size of the document tab.
    /// </returns>
    Size MeasureTabControlTab(Graphics graphics, Image image, string text, Font font, DrawItemState state);

    /// <summary>
    /// Draws the background of a tabstrip on a TabControl.
    /// 
    /// </summary>
    /// <param name="graphics">The Graphics object to draw width.</param><param name="bounds">The bounds to draw within.</param><param name="backColor">The background colour specified for the TabControl.</param>
    void DrawTabControlTabStripBackground(Graphics graphics, Rectangle bounds, Color backColor);

    /// <summary>
    /// Prepares the renderer for a rendering session.
    /// 
    /// </summary>
    /// <param name="tabHotKeys">How hotkeys should be handled when drawing text on tabs.</param>
    void StartRenderSession(HotkeyPrefix tabHotKeys);

    /// <summary>
    /// Releases resources used during a rendering session.
    /// 
    /// </summary>
    void FinishRenderSession();
  }
}
