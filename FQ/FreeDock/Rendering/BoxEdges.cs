namespace FQ.FreeDock.Rendering
{
    /// <summary>
    /// Represents the measurements of the edges of a container.
    /// 
    /// </summary>
    public class BoxEdges
    {
        /// <summary>
        /// The left dimension.
        /// 
        /// </summary>
        public int Left { get; private set; }

        /// <summary>
        /// The top dimension.
        /// 
        /// </summary>
        public int Top { get; private set; }

        /// <summary>
        /// The right dimension.
        /// 
        /// </summary>
        public int Right { get; private set; }

        /// <summary>
        /// The bottom dimension.
        /// 
        /// </summary>
        public int Bottom { get; private set; }

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
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }
    }
}
