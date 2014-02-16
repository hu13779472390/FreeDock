using System.Drawing;

namespace FQ.FreeDock.Rendering
{
    /// <summary>
    /// Represents a "box" modelled with width, height, margin and padding metrics.
    /// 
    /// </summary>
    public class BoxModel
    {
        /// <summary>
        /// Gets the width to add to a measurement, governed by the left and right margin and padding values.
        /// 
        /// </summary>
        public int ExtraWidth
        {
            get
            {
                return this.Margin.Left + this.Margin.Right + this.Padding.Left + this.Padding.Right;
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
                return this.Margin.Top + this.Margin.Bottom + this.Padding.Top + this.Padding.Bottom;
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
                return new Size(this.Width - this.Margin.Left - this.Margin.Right, this.Height - this.Margin.Top - this.Margin.Bottom);
            }
        }

        /// <summary>
        /// Gets/sets the height of the box.
        /// 
        /// </summary>
        public int Height { get; set; }


        /// <summary>
        /// Gets/sets the width of the box.
        /// 
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets/sets the margin of the box.
        /// 
        /// </summary>
        public BoxEdges Margin { get; set; }

        /// <summary>
        /// Gets/sets the padding of the box.
        /// 
        /// </summary>
        public BoxEdges Padding { get; set; }

        /// <summary>
        /// Initializes a new instance of the BoxModel class.
        /// 
        /// </summary>
        public BoxModel()
        {
            this.Margin = new BoxEdges();
            this.Padding = new BoxEdges();
        }

        /// <summary>
        /// Initializes a new instance of the BoxModel class, with the specified measurements.
        /// 
        /// </summary>
        /// <param name="width">The width of the box.</param><param name="height">The height of the box.</param><param name="paddingLeft">The left padding dimension.</param><param name="paddingTop">The top padding dimension.</param><param name="paddingRight">The right padding dimension.</param><param name="paddingBottom">The bottom padding dimension.</param><param name="marginLeft">The left margin dimension.</param><param name="marginTop">The top margin dimension.</param><param name="marginRight">The right margin dimension.</param><param name="marginBottom">The bottom margin dimension.</param>
        public BoxModel(int width, int height, int paddingLeft, int paddingTop, int paddingRight, int paddingBottom, int marginLeft, int marginTop, int marginRight, int marginBottom)
        {
            this.Width = width;
            this.Height = height;
            this.Padding = new BoxEdges(paddingLeft, paddingTop, paddingRight, paddingBottom);
            this.Margin = new BoxEdges(marginLeft, marginTop, marginRight, marginBottom);
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
            source.X += this.Padding.Left;
            source.Y += this.Padding.Top;
            source.Width -= this.Padding.Left + this.Padding.Right;
            source.Height -= this.Padding.Top + this.Padding.Bottom;
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
            source.X += this.Margin.Left;
            source.Y += this.Margin.Top;
            source.Width -= this.Margin.Left + this.Margin.Right;
            source.Height -= this.Margin.Top + this.Margin.Bottom;
            return source;
        }
    }
}
